using Autofac;
using Autofac.Extensions.DependencyInjection;
using GetGroupHoldingTask.Domain.Repositories.Entity;
using GetGroupHoldingTask.Infrastructure;
using GetGroupHoldingTask.Infrastructure.DependencyResolution;
using GetGroupHoldingTask.Infrastructure.SQLContext;
using GetGroupHoldingTask.Presentation.API.Controllers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SharedKernal.DataRepositories;
using ILogger = SharedKernal.Middlewares.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Configuration.Initialize();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
                    .Enrich.FromLogContext()
                    .WriteTo.Console());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().PropertiesAutowired().SingleInstance();
    DependencyResolutionFacade.Initialize(container: builder);
    #region Register Controller For Property DI
    System.Type controllerBaseType = typeof(BaseController);
    builder.RegisterAssemblyTypes(typeof(Program).Assembly).Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType).PropertiesAutowired();
    #endregion
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));

builder.Services.Initialize();
IHttpContextAccessor httpContextAccessor = builder.Services.BuildServiceProvider().GetRequiredService<IHttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.Initialize();
using (var scope = app.Services.CreateScope())
{
    try
    {
        var services = scope.ServiceProvider;

        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetService<ILogger>();
        logger.Error("Migration error" + ex.Message);
        throw;
    }

}
app.Run();
