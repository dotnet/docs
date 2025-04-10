---
title: .NET default templates for dotnet new
description: The information about dotnet new templates shipped with dotnet SDK.
ms.custom: updateeachrelease
no-loc: [Blazor, WebAssembly]
ms.date: 02/21/2024
---
# .NET default templates for dotnet new

When you install the [.NET SDK](https://dotnet.microsoft.com/download), you receive over a dozen built-in templates for creating projects and files, including console apps, class libraries, unit test projects, ASP.NET Core apps (including [Angular](https://angular.io/) and [React](https://reactjs.org/) projects), and configuration files. To list the built-in templates, run the `dotnet new list` command:

```dotnetcli
dotnet new list
```

[!INCLUDE [templates](../../../includes/templates.md)]

## Template options

Each template may have additional options available. To show the additional options available for the template use the `--help` option with the template name argument, for example: `dotnet new console --help`.
In case the template supports multiple languages, this command will show help for the template in the default language. By combining it with the `--language` option, you can see the help for other languages: `dotnet new console --help --language F#`.
The templates that ship with the .NET SDK have the following additional options:

## `console`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Available since .NET Core 3.0 SDK.

  The following table lists the default values according to the SDK version you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

  The ability to create a project for an earlier TFM depends on having that version of the SDK installed. For example, if you have only the .NET 9 SDK installed, then the only value available for `--framework` is `net9.0`. If, for example, you install the .NET 8 SDK, the value `net8.0` becomes available for `--framework`. So by specifying `--framework net8.0` you can target .NET 8 even while running `dotnet new` in the .NET 9 SDK.

  Alternatively, to create a project that targets a framework earlier than the SDK that you're using, you might be able to do it by installing the NuGet package for the template. [Common](https://www.nuget.org/packages?q=Microsoft.DotNet.Common.ProjectTemplates), [web](https://www.nuget.org/packages?q=Microsoft.DotNet.Web.ProjectTemplates), and [SPA](https://www.nuget.org/packages?q=Microsoft.DotNet.Web.Spa.ProjectTemplates) project types use different packages per target framework moniker (TFM). For example, to create a `console` project that targets `netcoreapp1.0`, run [`dotnet new install`](dotnet-new-install.md) on `Microsoft.DotNet.Common.ProjectTemplates.1.x`.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/language-versioning.md#defaults).

- **`--no-restore`**

  If specified, doesn't execute an implicit restore during project creation.

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`. Available only for C#.

***

## `classlib`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Values: `net9.0`, `net8.0`, or `net7.0` to create a .NET Class Library, or `netstandard2.1` or `netstandard2.0` to create a .NET Standard Class Library. The default value for .NET SDK 9.0.x is `net9.0`.

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/language-versioning.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="wpf"></a> `wpf`, `wpflib`, `wpfcustomcontrollib`, `wpfusercontrollib`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. For the .NET 9 SDK, the default value is `net9.0`.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/language-versioning.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="winforms"></a> `winforms`, `winformslib`

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/language-versioning.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="web-others"></a> `worker`, `grpc`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. The default value for .NET 9 SDK is `net9.0`.

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## <a name="mstest"></a> `mstest`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

The ability to create a project for an earlier TFM depends on having that version of the SDK installed. For example, if you have only the .NET 9 SDK installed, then the only value available for `--framework` is `net9.0`. If you install, for example, the .NET 8 SDK, the value `net8.0` becomes available for `--framework`. So by specifying `--framework net8.0` you can target .NET 8 even while running `dotnet new` in the .NET 9 SDK.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--sdk`**

  Use MSTest.Sdk project style.

- **`--test-runner <TEST_RUNNER>`**

   The runner/platform for the test project. The possible values are:

  - `VSTest` - VSTest platform (Default).
  - `MSTest` - Microsoft.Testing.Platform.

- **`--coverage-tool <COVERAGE_TOOL>`**

  The coverage tool to use for the test project. The possible values are:

  - `Microsoft.CodeCoverage` - Microsoft Code Coverage (Default).
  - `coverlet` - coverlet coverage tool.

- **`--extensions-profile <EXTENSIONS_PROFILE>`**

  The SDK extensions profile when using Microsoft.Testing.Platform. The possible values are:

  - `Default` - Default extensions profile (Default).
  - `None` - No extensions are enabled.
  - `AllMicrosoft` - Enable all extensions shipped by Microsoft (including extensions with a restrictive license).

- **`--fixture <FIXTURE>`**

  The fixture kinds to include in the test project. The possible values are:

  - `None` - No fixture methods.
  - `AssemblyInitialize` - AssemblyInitialize fixture method.
  - `AssemblyCleanup` - AssemblyCleanup fixture method.
  - `ClassInitialize` - ClassInitialize fixture method.
  - `ClassCleanup` - ClassCleanup fixture method.
  - `TestInitialize` - TestInitialize fixture method.
  - `TestCleanup` - TestCleanup fixture method.

  Where multiple values are allowed.

- **`-p|--enable-pack`**

  Enables packaging for the project using [dotnet pack](dotnet-pack.md).

***

## <a name="mstest-class"></a> `mstest-class`

- **`--fixture <FIXTURE>`**

  The fixture kinds to include in the test project. The possible values are:

  - `None` - No fixture methods.
  - `AssemblyInitialize` - AssemblyInitialize fixture method.
  - `AssemblyCleanup` - AssemblyCleanup fixture method.
  - `ClassInitialize` - ClassInitialize fixture method.
  - `ClassCleanup` - ClassCleanup fixture method.
  - `TestInitialize` - TestInitialize fixture method.
  - `TestCleanup` - TestCleanup fixture method.

  Where multiple values are allowed.

***

## <a name="xunit"></a> `xunit`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

The ability to create a project for an earlier TFM depends on having that version of the SDK installed. For example, if you have only the .NET 9 SDK installed, then the only value available for `--framework` is `net9.0`. If you install, for example, the .NET 8 SDK, the value `net8.0` becomes available for `--framework`. So by specifying `--framework net8.0` you can target .NET 8 even while running `dotnet new` in the .NET 9 SDK.

- **`-p|--enable-pack`**

  Enables packaging for the project using [dotnet pack](dotnet-pack.md).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="nunit"></a> `nunit`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

The ability to create a project for an earlier TFM depends on having that version of the SDK installed. For example, if you have only the .NET 9 SDK installed, then the only value available for `--framework` is `net9.0`. If you install, for example, the .NET 8 SDK, the value `net8.0` becomes available for `--framework`. So by specifying `--framework net8.0` you can target .NET 8 even while running `dotnet new` in the .NET 9 SDK.

- **`-p|--enable-pack`**

  Enables packaging for the project using [dotnet pack](dotnet-pack.md).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## `page`

- **`-na|--namespace <NAMESPACE_NAME>`**

  Namespace for the generated code. The default value is `MyApp.Namespace`.

- **`-np|--no-pagemodel`**

  Creates the page without a PageModel.

***

## <a name="namespace"></a> `viewimports`, `proto`

- **`-na|--namespace <NAMESPACE_NAME>`**

  Namespace for the generated code. The default value is `MyApp.Namespace`.

***

## `blazorserver`

**Discontinued since .NET 8 SDK.**

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `Individual` - Individual authentication.
  - `IndividualB2C` - Individual authentication with Azure AD B2C.
  - `SingleOrg` - Organizational authentication for a single tenant. [Entra External ID](/entra/external-id/) tenants also use `SingleOrg`.
  - `MultiOrg` - Organizational authentication for multiple tenants.
  - `Windows` - Windows authentication.

- **`--aad-b2c-instance <INSTANCE>`**

  The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

- **`-ssp|--susi-policy-id <ID>`**

  The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

- **`-rp|--reset-password-policy-id <ID>`**

  The reset password policy ID for this project. Use with `IndividualB2C` authentication.

- **`-ep|--edit-profile-policy-id <ID>`**

  The edit profile policy ID for this project. Use with `IndividualB2C` authentication.

- **`--aad-instance <INSTANCE>`**

  The Azure Active Directory instance to connect to. Use with `SingleOrg` or `MultiOrg` authentication. The default value is `https://login.microsoftonline.com/`.

- **`--client-id <ID>`**

  The Client ID for this project. Use with `IndividualB2C`, `SingleOrg`, or `MultiOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

- **`--domain <DOMAIN>`**

  The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

- **`--tenant-id <ID>`**

  The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

- **`--callback-path <PATH>`**

  The request path within the application's base path of the redirect URI. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `/signin-oidc`.

- **`-r|--org-read-access`**

  Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-https`**

  Turns off HTTPS. This option only applies if `Individual`, `IndividualB2C`, `SingleOrg`, or `MultiOrg` aren't being used for `--auth`.

- **`-uld|--use-local-db`**

  Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--kestrelHttpPort`**

  Port number to use for the HTTP endpoint in *launchSettings.json*.

- **`--kestrelHttpsPort`**

  Port number to use for the HTTPS endpoint in *launchSettings.json*. This option is not applicable when the parameter `no-https` is used (but `no-https` is ignored when an individual or organizational authentication setting is chosen for `--auth`).

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## `blazor`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  This template is available for .NET 8 or later.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated app.

- **`-int|--interactivity <None|Server|Webassembly|Auto >`**

  Specifies which interactive render mode to use for interactive components. The possible values are:

  - `None` - No interactivity (static server-side rendering only).
  - `Server` - (Default) Runs the app on the server with interactive server-side rendering.
  - `WebAssembly` - Runs the app using client-side rendering in the browser with WebAssembly.
  - `Auto` - Uses interactive server-side rendering while downloading the Blazor bundle and activating the Blazor runtime on the client, then uses client-side rendering with WebAssembly.

- **`--empty`**

  Omits sample pages and styling that demonstrate basic usage patterns.

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `Individual` - Individual authentication.

- **`-uld|--use-local-db`**

  Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` authentication.

- **`-ai|--all-interactive`**

  Makes every page interactive by applying an interactive render mode at the top level. If `false`, pages use static server-side rendering by default and can be marked interactive on a per-page or per-component basis. This option is only effective if the `-i|--interactivity` option isn't set to `None`.

- **`--no-https`**

  Turns off HTTPS. This option only applies if `Individual` isn't chosen for the `-au|--auth` option.

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method is generated instead of top-level statements.

***

## `blazorwasm`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`-ho|--hosted`**

  Includes an ASP.NET Core host for the Blazor WebAssembly app.

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `Individual` - Individual authentication.
  - `IndividualB2C` - Individual authentication with Azure AD B2C.
  - `SingleOrg` - Organizational authentication for a single tenant. Entra External ID tenants also use SingleOrg.

- **`--authority <AUTHORITY>`**

  The authority of the OIDC provider. Use with `Individual` authentication. The default value is `https://login.microsoftonline.com/`.

- **`--aad-b2c-instance <INSTANCE>`**

  The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://aadB2CInstance.b2clogin.com/`.

- **`-ssp|--susi-policy-id <ID>`**

  The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

- **`--aad-instance <INSTANCE>`**

  The Azure Active Directory instance to connect to. Use with `SingleOrg` authentication. The default value is `https://login.microsoftonline.com/`.

- **`--client-id <ID>`**

  The Client ID for this project. Use with `IndividualB2C`, `SingleOrg`, or `Individual` authentication in standalone scenarios. The default value is `33333333-3333-3333-33333333333333333`.

- **`--domain <DOMAIN>`**

  The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

- **`--app-id-uri <URI>`**

  The App ID Uri for the server API you want to call. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `api.id.uri`.

- **`--api-client-id <ID>`**

  The Client ID for the API that the server hosts. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `11111111-1111-1111-11111111111111111`.

- **`-s|--default-scope <SCOPE>`**

  The API scope the client needs to request to provision an access token. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `user_impersonation`.

- **`--tenant-id <ID>`**

  The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

- **`-r|--org-read-access`**

  Allows this application read-access to the directory. Only applies to `SingleOrg` authentication.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`-p|--pwa`**

  produces a Progressive Web Application (PWA) supporting installation and offline use.

- **`--no-https`**

  Turns off HTTPS. This option only applies if `Individual`, `IndividualB2C`, or `SingleOrg` aren't being used for `--auth`.

- **`-uld|--use-local-db`**

  Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

- **`--called-api-url <URL>`**

  URL of the API to call from the web app. Only applies to `SingleOrg` or `IndividualB2C` authentication without an ASP.NET Core host specified. The default value is `https://graph.microsoft.com/v1.0/me`.

- **`--calls-graph`**

  Specifies if the web app calls Microsoft Graph. Only applies to `SingleOrg` authentication.

- **`--called-api-scopes <SCOPES>`**

  Scopes to request to call the API from the web app. Only applies to `SingleOrg` or `IndividualB2C` authentication without an ASP.NET Core host specified. The default is `user.read`.

- **`--kestrelHttpPort`**

  Port number to use for the HTTP endpoint in *launchSettings.json*.

- **`--kestrelHttpsPort`**

  Port number to use for the HTTPS endpoint in *launchSettings.json*. This option is not applicable when the parameter `no-https` is used (but `no-https` is ignored when an individual or organizational authentication setting is chosen for `--auth`).

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## `web`

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--no-https`**

  Turns off HTTPS.

- **`--kestrelHttpPort`**

  Port number to use for the HTTP endpoint in *launchSettings.json*.

- **`--kestrelHttpsPort`**

  Port number to use for the HTTPS endpoint in *launchSettings.json*. This option is not applicable when the parameter `no-https` is used (but `no-https` is ignored when an individual or organizational authentication setting is chosen for `--auth`).

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## <a name="web-options"></a> `mvc`, `webapp`

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `Individual` - Individual authentication.
  - `IndividualB2C` - Individual authentication with Azure AD B2C.
  - `SingleOrg` - Organizational authentication for a single tenant. Entra External ID tenants also use SingleOrg.
  - `MultiOrg` - Organizational authentication for multiple tenants.
  - `Windows` - Windows authentication.

- **`--aad-b2c-instance <INSTANCE>`**

  The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

- **`-ssp|--susi-policy-id <ID>`**

  The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

- **`-rp|--reset-password-policy-id <ID>`**

  The reset password policy ID for this project. Use with `IndividualB2C` authentication.

- **`-ep|--edit-profile-policy-id <ID>`**

  The edit profile policy ID for this project. Use with `IndividualB2C` authentication.

- **`--aad-instance <INSTANCE>`**

  The Azure Active Directory instance to connect to. Use with `SingleOrg` or `MultiOrg` authentication. The default value is `https://login.microsoftonline.com/`.

- **`--client-id <ID>`**

  The Client ID for this project. Use with `IndividualB2C`, `SingleOrg`, or `MultiOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

- **`--domain <DOMAIN>`**

  The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

- **`--tenant-id <ID>`**

  The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

- **`--callback-path <PATH>`**

  The request path within the application's base path of the redirect URI. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `/signin-oidc`.

- **`-r|--org-read-access`**

  Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-https`**

  Turns off HTTPS. This option only applies if `Individual`, `IndividualB2C`, `SingleOrg`, or `MultiOrg` aren't being used.

- **`-uld|--use-local-db`**

  Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option available since .NET Core 3.0 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--use-browserlink`**

  Includes BrowserLink in the project.

- **`-rrc|--razor-runtime-compilation`**

  Determines if the project is configured to use [Razor runtime compilation](/aspnet/core/mvc/views/view-compilation#runtime-compilation) in Debug builds.

- **`--kestrelHttpPort`**

  Port number to use for the HTTP endpoint in *launchSettings.json*.

- **`--kestrelHttpsPort`**

  Port number to use for the HTTPS endpoint in *launchSettings.json*. This option is not applicable when the parameter `no-https` is used (but `no-https` is ignored when an individual or organizational authentication setting is chosen for `--auth`).

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## <a name="spa"></a> `angular`, `react`

**Discontinued since .NET 8 SDK.**

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use.

  The possible values are:

  - `None` - No authentication (Default).
  - `Individual` - Individual authentication.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--no-https`**

  Turns off HTTPS. This option only applies if authentication is `None`.

- **`-uld|--use-local-db`**

  Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication. Available since .NET Core 3.0 SDK.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  > [!NOTE]
  > There isn't a React template for `net8.0`, however, if you're interested in developing React apps with ASP.NET Core, see [Overview of Single Page Apps (SPAs) in ASP.NET Core](/aspnet/core/client-side/spa/intro?view=aspnetcore-8.0&preserve-view=true).

  | SDK version | Default value   |
  |-------------|-----------------|
  | 7.0         | `net7.0`        |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--kestrelHttpPort`**

  Port number to use for the HTTP endpoint in *launchSettings.json*.

- **`--kestrelHttpsPort`**

  Port number to use for the HTTPS endpoint in *launchSettings.json*. This option is not applicable when the parameter `no-https` is used (but `no-https` is ignored when an individual or organizational authentication setting is chosen for `--auth`).

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## `razorclasslib`

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`-s|--support-pages-and-views`**

  Supports adding traditional Razor pages and Views in addition to components to this library.

***

## `webapiaot`

Creates a web API project with AOT publish enabled. For more information, see [Native AOT deployment](/dotnet/core/deploying/native-aot) and [The Web API (Native AOT) template](/aspnet/core/fundamentals/native-aot#the-web-api-native-aot-template).

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## `webapi`

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `IndividualB2C` - Individual authentication with Azure AD B2C.
  - `SingleOrg` - Organizational authentication for a single tenant. Entra External ID tenants also use SingleOrg.
  - `Windows` - Windows authentication.

- **`--aad-b2c-instance <INSTANCE>`**

  The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

- **`-minimal|--use-minimal-apis`**

  Create a project that uses the [ASP.NET Core minimal API](/aspnet/core/fundamentals/minimal-apis). Default is `false`, but this option is overridden by `-controllers`. Since the default for `-controllers` is `false`, entering `dotnet new webapi` without specifying either option creates a minimal API project.

- **`-ssp|--susi-policy-id <ID>`**

  The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

- **`--aad-instance <INSTANCE>`**

  The Azure Active Directory instance to connect to. Use with `SingleOrg` authentication. The default value is `https://login.microsoftonline.com/`.

- **`--client-id <ID>`**

  The Client ID for this project. Use with `IndividualB2C` or `SingleOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

- **`-controllers|--use-controllers`**

  Whether to use controllers instead of minimal APIs. If both this option and `-minimal` are specified, this option overrides the value specified by `-minimal`. Default is `false`. Available since .NET 8 SDK.

- **`--domain <DOMAIN>`**

  The domain for the directory tenant. Use with `IndividualB2C` or `SingleOrg` authentication. The default value is `qualified.domain.name`.

- **`--tenant-id <ID>`**

  The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

- **`-r|--org-read-access`**

  Allows this application read-access to the directory. Only applies to `SingleOrg` authentication.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-openapi`**

  Turns off OpenAPI (Swagger) support. `AddOpenApi` and `MapOpenApi` aren't called.

- **`--no-https`**

  Turns off HTTPS. No *https* launch profile is created in `launchSettings.json`. `app.UseHsts` and `app.UseHttpsRedirection` aren't called in *Program.cs*/*Startup.cs*. This option only applies if `IndividualB2C` or `SingleOrg` aren't being used for authentication.

- **`-uld|--use-local-db`**

  Specifies LocalDB should be used instead of SQLite. Only applies to `IndividualB2C` authentication.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 9.0         | `net9.0`        |
  | 8.0         | `net8.0`        |
  | 7.0         | `net7.0`        |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--use-program-main`**

  If specified, an explicit `Program` class and `Main` method will be used instead of top-level statements. Available since .NET SDK 6.0.300. Default value: `false`.

***

## `apicontroller`

API Controller with or without read/write actions.

- **`-p:n|--name <NAME>`**

  The namespace for the generated code. Default is `MyApp.Namespace`.

- **`-ac|--actions`**

  Create a controller with read/write actions. Default is `false`.

***

## `globaljson`

- **`--sdk-version <VERSION_NUMBER>`**

  Specifies the version of the .NET SDK to use in the *global.json* file.

- **`--roll-forward <ROLL_FORWARD_POLICY>`**

  The roll-forward policy to use when selecting an SDK version, either as a fallback when a specific SDK version is missing or as a directive to use a later version.
  For more information, see [global-json](global-json.md#rollforward).

## `editorconfig`

Creates an *.editorconfig* file for configuring code style preferences.

- **`--empty`**

  Creates an empty *.editorconfig* instead of the defaults for .NET.

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new list command](dotnet-new-list.md)
- [Custom templates for dotnet new](custom-templates.md)
- [Create a custom template for dotnet new](../tutorials/cli-templates-create-item-template.md)
- [Implicit using directives](../project-sdk/overview.md#implicit-using-directives)
