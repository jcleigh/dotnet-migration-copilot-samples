# ContosoUniversity - Database Configuration

## SQLite Fallback Support

This application now supports automatic fallback to SQLite when SQL Server is not available.

### How it works

1. **Primary**: The application first attempts to connect to SQL Server using the `DefaultConnection` connection string
2. **Fallback**: If SQL Server is not available or the connection fails, it automatically falls back to SQLite
3. **Configuration**: Both connection strings are defined in `appsettings.json`

### Connection Strings

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContosoUniversity;Trusted_Connection=True;MultipleActiveResultSets=true",
    "SqliteConnection": "Data Source=ContosoUniversity.db"
  }
}
```

### Database Files

- **SQLite**: When using SQLite, the database file `ContosoUniversity.db` will be created in the application root directory
- **SQL Server**: Uses LocalDB or full SQL Server instance as configured

### Benefits

- **Development Friendly**: Works immediately without requiring SQL Server setup
- **Portable**: SQLite database is a single file that can be easily shared or backed up
- **Automatic**: No manual configuration needed - the fallback is handled automatically
- **Logging**: Clear logging indicates which database provider is being used

### Technical Implementation

- **DatabaseService**: Handles the connection testing and fallback logic
- **Dependency Injection**: Properly integrated with ASP.NET Core DI container
- **Entity Framework**: Both SQL Server and SQLite providers are configured
- **Error Handling**: Comprehensive exception handling with logging

The fallback mechanism ensures the application can run in any environment, making it perfect for development, testing, and deployment scenarios.