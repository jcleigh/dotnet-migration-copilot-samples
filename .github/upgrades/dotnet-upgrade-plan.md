# .NET 9.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 9.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 9.0 upgrade.
3. Upgrade ContosoUniversity.csproj

## Settings

This section contains settings and data used by execution steps.

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                                    | Current Version | New Version | Description                                |
|:------------------------------------------------|:---------------:|:-----------:|:-------------------------------------------|
| Antlr                                           | 3.4.1.9004      | 4.6.6       | Recommended for .NET 9.0                  |
| Microsoft.Bcl.AsyncInterfaces                  | 1.1.1           | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Bcl.HashCode                         | 1.1.1           | 6.0.0       | Recommended for .NET 9.0                  |
| Microsoft.Data.SqlClient                       | 2.1.4           | 6.1.1       | Security vulnerability                     |
| Microsoft.EntityFrameworkCore                  | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.EntityFrameworkCore.Abstractions     | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.EntityFrameworkCore.Analyzers        | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.EntityFrameworkCore.Relational       | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.EntityFrameworkCore.SqlServer        | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.EntityFrameworkCore.Tools            | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Caching.Abstractions      | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Caching.Memory            | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Configuration             | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Configuration.Abstractions| 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Configuration.Binder      | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.DependencyInjection       | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.DependencyInjection.Abstractions | 3.1.32   | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Logging                   | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Logging.Abstractions      | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Options                   | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Extensions.Primitives                | 3.1.32          | 9.0.8       | Recommended for .NET 9.0                  |
| Microsoft.Identity.Client                      | 4.21.1          | 4.76.0      | Security vulnerability                     |
| System.Collections.Immutable                   | 1.7.1           | 9.0.8       | Recommended for .NET 9.0                  |
| System.Diagnostics.DiagnosticSource            | 4.7.1           | 9.0.8       | Recommended for .NET 9.0                  |
| System.Runtime.CompilerServices.Unsafe         | 4.5.3           | 6.1.2       | Recommended for .NET 9.0                  |

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### ContosoUniversity.csproj modifications

Project properties changes:
  - Target framework should be changed from `net48` to `net9.0`
  - Project file needs to be converted to SDK-style

NuGet packages changes:
  - Microsoft.Data.SqlClient should be updated from `2.1.4` to `6.1.1` (*security vulnerability*)
  - Microsoft.Identity.Client should be updated from `4.21.1` to `4.76.0` (*security vulnerability*)
  - Microsoft.EntityFrameworkCore should be updated from `3.1.32` to `9.0.8` (*recommended for .NET 9.0*)
  - Microsoft.EntityFrameworkCore.SqlServer should be updated from `3.1.32` to `9.0.8` (*recommended for .NET 9.0*)
  - All other packages listed in aggregate modifications table above

Feature upgrades:
  - System.Web.Optimization bundling and minification feature upgrade: replace with actual HTML tags pointing to content files
  - RouteCollection feature upgrade: convert route registration to ASP.NET Core route mappings
  - GlobalFilterCollection feature upgrade: convert to ASP.NET Core middleware registrations
  - System.Messaging feature upgrade: convert to MSMQ in .NET Core
  - Global.asax.cs feature upgrade: convert application initialization to .NET Core and clean up Global.asax.cs

Other changes:
  - Remove incompatible packages: Microsoft.AspNet.Web.Optimization
  - Remove packages included with framework: Microsoft.AspNet.Mvc, Microsoft.AspNet.Razor, Microsoft.AspNet.WebPages, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Microsoft.Web.Infrastructure, NETStandard.Library, System.Buffers, System.ComponentModel.Annotations, System.Memory, System.Numerics.Vectors, System.Threading.Tasks.Extensions