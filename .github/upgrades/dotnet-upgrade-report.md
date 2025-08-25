# .NET 9.0 Upgrade Report

## Project target framework modifications

| Project name                                   | Old Target Framework    | New Target Framework         | Commits                   |
|:-----------------------------------------------|:-----------------------:|:----------------------------:|---------------------------|
| ContosoUniversity.csproj                      |   net48                | net9.0                       | Multiple commits          |

## NuGet Packages

| Package Name                                    | Old Version | New Version | Commit Id                                 |
|:------------------------------------------------|:-----------:|:-----------:|-------------------------------------------|
| Antlr4                                          |   -         |  4.6.6      | ed5863e8                                  |
| Microsoft.Bcl.AsyncInterfaces                  |   -         |  9.0.8      | 375b458e                                  |
| Microsoft.Bcl.HashCode                         |   -         |  6.0.0      | 375b458e                                  |
| Microsoft.Data.SqlClient                       |   -         |  6.1.1      | 375b458e                                  |
| Microsoft.EntityFrameworkCore                  |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.EntityFrameworkCore.Abstractions     |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.EntityFrameworkCore.Analyzers        |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.EntityFrameworkCore.Relational       |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.EntityFrameworkCore.SqlServer        |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.EntityFrameworkCore.Tools            |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Caching.Abstractions      |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Caching.Memory            |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Configuration             |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Configuration.Abstractions|   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Configuration.Binder      |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.DependencyInjection       |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.DependencyInjection.Abstractions |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Logging                   |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Logging.Abstractions      |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Options                   |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Extensions.Primitives                |   3.1.32    |  9.0.8      | 375b458e                                  |
| Microsoft.Identity.Client                      |   4.21.1    |  4.76.0     | 375b458e                                  |
| System.Collections.Immutable                   |   1.7.1     |  9.0.8      | 375b458e                                  |
| System.Diagnostics.DiagnosticSource            |   4.7.1     |  9.0.8      | 375b458e                                  |
| System.Runtime.CompilerServices.Unsafe         |   4.5.3     |  6.1.2      | 375b458e                                  |
| System.Configuration.ConfigurationManager      |   -         |  9.0.8      | 375b458e                                  |

## All commits

| Commit ID              | Description                                |
|:-----------------------|:-------------------------------------------|
| 41c4c492               | Commit upgrade plan                        |
| fca7d1e7               | Update SqlClient.SNI.runtime version in csproj file |
| 78188600               | Add System using directive to Program.cs  |
| b9b60ed6               | Add System.Collections.Generic using to InstructorsController |
| 3fb4227a               | Migrate to ASP.NET Core: remove Web.config, update controllers |
| 2d24da3e               | System.Messaging feature upgrade completed |
| 5aae20dc               | GlobalFilterCollection feature upgrade completed |
| ed5863e8               | Migrate to SDK-style project and .NET 9; cleanup files |
| 2a423be2               | Fix TryUpdateModelAsync lambda issue in InstructorsController |
| f1944dec               | Replace HttpPostedFileBase with IFormFile in CoursesController |
| 21897d6c               | Commit changes before fixing errors        |
| fee3c1b3               | Add missing semicolon in Program.cs       |
| b076ff0a               | Global.asax.cs feature upgrade completed  |
| d86a7cc8               | RouteCollection feature upgrade completed  |
| a741106c               | Commit changes before fixing errors        |
| 59b4d022               | Remove RequireSystemWebAdapterSession calls |
| 9ee0e5cf               | System.Web.Optimization bundling feature upgrade completed |
| 375b458e               | Update ContosoUniversity.csproj dependencies to latest versions |
| a2e4c27b               | Fix TryUpdateModelAsync CS1503 error      |
| 09d3ba1e               | Fix TryUpdateModelAsync prefix parameter  |
| e0983c85               | Replace TryUpdateModel with TryUpdateModelAsync |
| e950941b               | Replace Server.MapPath with ASP.NET Core equivalent |
| 33ac21d6               | Remove JsonRequestBehavior.AllowGet from NotificationsController |
| d4258a84               | Add Microsoft.AspNetCore.Http using directive |
| 6ba7a1c6               | Replace ContentLength with Length for IFormFile |
| f2d00966               | Replace SaveAs with CopyTo for file uploads |
| d7330da2               | Fix TryUpdateModelAsync IValueProvider parameter |
| 57860a7c               | Add missing prefix parameter to TryUpdateModelAsync |

## Project feature upgrades

Contains summary of modifications made to the project assets during different upgrade stages.

### ContosoUniversity.csproj

Here is what changed for the project during upgrade:

- **Project conversion**: Converted from .NET Framework 4.8 project to SDK-style .NET 9.0 project
- **System.Web.Optimization bundling and minification feature upgrade completed**: replaced all @Scripts.Render and @Styles.Render with direct tags, removed BundleConfig and related references.
- **GlobalFilterCollection feature upgrade completed**: global error and status code handling moved to middleware and controller actions, StatusCode view added.
- **RouteCollection feature upgrade completed**: default MVC route mapping added to Program.cs using app.MapControllerRoute.
- **System.Messaging feature upgrade completed**: converted to in-memory queue using ConcurrentQueue and updated dependency injection.
- **Global.asax.cs feature upgrade completed**: application initialization moved to Program.cs, database initialization converted to ASP.NET Core pattern, Global.asax.cs removed.
- **ASP.NET Core migration**: Updated all controllers to use ASP.NET Core patterns, replaced System.Web.Mvc with Microsoft.AspNetCore.Mvc
- **File upload modernization**: Replaced HttpPostedFileBase with IFormFile and updated file handling methods
- **Dependency injection**: Updated NotificationService and BaseController to use ASP.NET Core dependency injection
- **View imports**: Added _ViewImports.cshtml to resolve namespace issues in Razor views
- **Security vulnerabilities fixed**: Updated Microsoft.Data.SqlClient from 2.1.4 to 6.1.1 and Microsoft.Identity.Client from 4.21.1 to 4.76.0

## Next steps

- Test the application thoroughly to ensure all functionality works correctly with .NET 9.0
- Consider updating any remaining legacy patterns to modern ASP.NET Core equivalents
- Review and update any custom middleware or services for optimal performance
- Update deployment configuration for ASP.NET Core hosting model