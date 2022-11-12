using Autofac.Core;
using AutoMapper;
using GetGroupHoldingTask.Infrastructure.SQLContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SharedKernal.Common.Configuration;
using SharedKernal.Common.Enum;
using SharedKernal.Middlewares.Exception;
using SharedKernal.Middlewares.JWTSettings;
using SharedKernal.Middlewares.Swagger;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

/// <summary>
/// 
/// </summary>
namespace GetGroupHoldingTask.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class Engine
    {
        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider Container { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static string[] AllowedOrigins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public static void Initialize(this IConfiguration configuration)
        {

            var _databaseConfiguration = new DatabaseConfiguration();
            configuration.Bind(nameof(DatabaseConfiguration), _databaseConfiguration);

            var _swaggerSettings = new SwaggerSettings();
            configuration.Bind(nameof(SwaggerSettings), _swaggerSettings);

            var _jwtSettings = new JwtSettings();
            configuration.Bind(nameof(JwtSettings), _jwtSettings);

          

            IConfigurationSection originsSection = configuration.GetSection("AllowedOrigins");
            AllowedOrigins = originsSection.AsEnumerable().Where(s => s.Value != null).Select(a => a.Value).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public static void Initialize(this IServiceCollection service)
        {
            //service.AddControllers()
            //       .AddControllersAsServices();
            //service.AddOptions();

            service.AddControllers().AddControllersAsServices().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            #region DbContext & Identity
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.AddInterceptors(new DbContextInterceptor());
                options.UseSqlServer(DatabaseConfiguration.ConnectionString);
                options.EnableSensitiveDataLogging();
            }, optionsLifetime: ServiceLifetime.Scoped);

            #endregion

            #region AllowedOrigins
            service.AddCors(options =>
            {
                options.AddPolicy(nameof(AllowedOrigins), builder => builder.WithOrigins(AllowedOrigins).AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            #endregion

            service.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            #region App localization
            service.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(nameof(LanguageLetter.Ar).ToLower());
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo(nameof(LanguageLetter.En).ToLower()), new CultureInfo(nameof(LanguageLetter.Ar).ToLower()) };

                options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.CustomRequestCultureProvider(context =>
                {
                    var userLangs = context.Request.Headers["Accept-Language"].ToString();
                    var firstLang = userLangs.Split(',').FirstOrDefault();
                    var defaultLang = string.IsNullOrEmpty(firstLang) ? nameof(LanguageLetter.Ar).ToLower() : firstLang;
                    return Task.FromResult(new Microsoft.AspNetCore.Localization.ProviderCultureResult(defaultLang, defaultLang));
                }));
            });
            #endregion

            #region Authentication
            service.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = JwtSettings.RequireExpirationTime,
                    ValidateIssuer = JwtSettings.ValidateIssuer,
                    ValidateAudience = JwtSettings.ValidateAudience,
                    ValidAudience = JwtSettings.ValidAudience,
                    ValidIssuer = JwtSettings.ValidIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecurityKey))
                };
            });
            #endregion

            #region AutoMapper
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new Mapper.StructureMapper());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);
            #endregion

           

            service.AddSwaggerDocumentation(documentName: SwaggerSettings.Name, title: SwaggerSettings.Title, version: SwaggerSettings.Version, description: SwaggerSettings.Description);
            service.AddEndpointsApiExplorer();
            service.AddSwaggerGen();
            service.AddMemoryCache();
            service.AddHttpContextAccessor();
            service.AddHttpClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void Initialize(this IApplicationBuilder app)
        {
            //Container = app.ApplicationServices;

            app.UseSwaggerDocumentation(documentName: SwaggerSettings.Name, title: SwaggerSettings.Title, version: SwaggerSettings.Version);

            app.UseMiddleware<ExceptionHandler>();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRequestLocalization();

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
               
            });
        }

      
    }

}