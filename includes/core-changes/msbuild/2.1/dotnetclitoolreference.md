### Project tools now included in SDK

The .NET Core 2.1 SDK now includes common CLI tooling, and you no longer need to reference these tools from the project.

#### Change description

In .NET Core 2.0, projects reference external .NET tools with the `<DotNetCliToolReference>` project setting. In .NET Core 2.1, some of these tools are included with the .NET Core SDK, and the setting is no longer needed. If you include references to these tools in your project, you'll receive an error similar to the following: **The tool 'Microsoft.EntityFrameworkCore.Tools.DotNet' is now included in the .NET Core SDK.**

Tools now included in .NET Core 2.1 SDK:

| \<DotNetCliToolReference> value                   | Tool                                                                                                            |
|------------------------------------------------|-----------------------------------------------------------------------------------------------------------------|
| `Microsoft.DotNet.Watcher.Tools`               | `dotnet-watch`               |
| `Microsoft.Extensions.SecretManager.Tools`     | [dotnet-user-secrets](https://github.com/dotnet/aspnetcore/blob/main/src/Tools/dotnet-user-secrets/README.md) |
| `Microsoft.Extensions.Caching.SqlConfig.Tools` | [dotnet-sql-cache](https://github.com/dotnet/aspnetcore/blob/main/src/Tools/dotnet-sql-cache/README.md)       |
| `Microsoft.EntityFrameworkCore.Tools.DotNet`   | [dotnet-ef](/ef/core/miscellaneous/cli/dotnet)                                                                  |

#### Version introduced

.NET Core SDK 2.1.300

#### Recommended action

Remove the `<DotNetCliToolReference>` setting from your project.

#### Category

MSBuild

#### Affected APIs

N/A
