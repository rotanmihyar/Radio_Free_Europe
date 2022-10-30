using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Radio_Free_Europe.DataAccess
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions<DatabaseService> options) : base(options)
        {
        }

        /// <summary>
        /// Apply database migration if any
        /// </summary>
        public void Migrate()
        {
            Policy
                .Handle<Exception>()
                .WaitAndRetry(10, r => TimeSpan.FromSeconds(10))
                .Execute(() => Database.Migrate());
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}