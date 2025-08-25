using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ContosoUniversity.Data;
using System.Threading.Tasks;
using System;

namespace ContosoUniversity.Services
{
    public class DatabaseService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DatabaseService> _logger;

        public DatabaseService(IConfiguration configuration, ILogger<DatabaseService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<SchoolContext> GetWorkingContextAsync()
        {
            var sqlServerConnectionString = _configuration.GetConnectionString("DefaultConnection");
            var sqliteConnectionString = _configuration.GetConnectionString("SqliteConnection") 
                ?? "Data Source=ContosoUniversity.db";

            // Try SQL Server first if connection string is provided
            if (!string.IsNullOrEmpty(sqlServerConnectionString))
            {
                try
                {
                    var sqlServerOptionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
                    sqlServerOptionsBuilder.UseSqlServer(sqlServerConnectionString);
                    
                    var sqlServerContext = new SchoolContext(sqlServerOptionsBuilder.Options);
                    
                    if (await TestConnectionAsync(sqlServerContext))
                    {
                        _logger.LogInformation("Using SQL Server database");
                        return sqlServerContext;
                    }
                    
                    sqlServerContext.Dispose();
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "SQL Server connection failed, falling back to SQLite");
                }
            }

            // Fallback to SQLite
            var sqliteOptionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            sqliteOptionsBuilder.UseSqlite(sqliteConnectionString);
            
            var sqliteContext = new SchoolContext(sqliteOptionsBuilder.Options);
            _logger.LogInformation("Using SQLite database: {ConnectionString}", sqliteConnectionString);
            
            return sqliteContext;
        }

        private async Task<bool> TestConnectionAsync(SchoolContext context)
        {
            try
            {
                await context.Database.CanConnectAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}