using GetGroupHoldingTask.Infrastructure.EntitiesConfigurations;
using GetGroupHoldingTask.Infrastructure.SeedData;
//using KSU.OutSourcing.Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;

namespace GetGroupHoldingTask.Infrastructure.SQLContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public static void Configure(DbContextOptionsBuilder<ApplicationDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        #region DbSets
        //public DbSet<LeadershipType> SampleEntity { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            try
            {
                #region Schema Configurations
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
                #endregion

                //#region Start Seed Data
                modelBuilder.StartSeedData();
                //#endregion
            }
            catch
            {
                throw;
            }
        }

    }
}
