---
title: .NET default templates for dotnet new
description: The information about dotnet new templates shipped with dotnet SDK.
ms.custom: updateeachrelease
no-loc: [Blazor, WebAssembly]
ms.date: 11/23/2021
---
# .NET default templates for dotnet new

When you install the [.NET SDK](https://dotnet.microsoft.com/download), you receive over a dozen built-in templates for creating projects and files, including console apps, class libraries, unit test projects, ASP.NET Core apps (including [Angular](https://angular.io/) and [React](https://reactjs.org/) projects), and configuration files. To list the built-in templates, run the `dotnet new` command with the `-l|--list` option:

```dotnetcli
dotnet new --list
```

The following table shows the templates that come pre-installed with the .NET SDK. The default language for the template is shown inside the brackets. Click on the short name link to see the specific template options.

| Templates                                    | Short name                        | Language     | Tags                                  | Introduced |
|----------------------------------------------|-----------------------------------|--------------|---------------------------------------|------------|
| Console Application                          | [`console`](#console)             | [C#], F#, VB | Common/Console                        | 1.0        |
| Class library                                | [`classlib`](#classlib)           | [C#], F#, VB | Common/Library                        | 1.0        |
| WPF Application                              | [`wpf`](#wpf)                     | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF Class library                            | [`wpflib`](#wpf)                  | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF Custom Control Library                   | [`wpfcustomcontrollib`](#wpf)     | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF User Control Library                     | [`wpfusercontrollib`](#wpf)       | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| Windows Forms (WinForms) Application         | [`winforms`](#winforms)           | [C#], VB     | Common/WinForms                       | 3.0 (5.0 for VB)|
| Windows Forms (WinForms) Class library       | [`winformslib`](#winforms)        | [C#], VB     | Common/WinForms                       | 3.0 (5.0 for VB)|
| Worker Service                               | [`worker`](#web-others)           | [C#]         | Common/Worker/Web                     | 3.0        |
| Unit Test Project                            | [`mstest`](#test)                 | [C#], F#, VB | Test/MSTest                           | 1.0        |
| NUnit 3 Test Project                         | [`nunit`](#nunit)                 | [C#], F#, VB | Test/NUnit                            | 2.1.400    |
| NUnit 3 Test Item                            | `nunit-test`                      | [C#], F#, VB | Test/NUnit                            | 2.2        |
| xUnit Test Project                           | [`xunit`](#test)                  | [C#], F#, VB | Test/xUnit                            | 1.0        |
| Razor Component                              | `razorcomponent`                  | [C#]         | Web/ASP.NET                           | 3.0        |
| Razor Page                                   | [`page`](#page)                   | [C#]         | Web/ASP.NET                           | 2.0        |
| MVC ViewImports                              | [`viewimports`](#namespace)       | [C#]         | Web/ASP.NET                           | 2.0        |
| MVC ViewStart                                | `viewstart`                       | [C#]         | Web/ASP.NET                           | 2.0        |
| Blazor Server App                            | [`blazorserver`](#blazorserver)   | [C#]         | Web/Blazor                            | 3.0        |
| Blazor WebAssembly App                       | [`blazorwasm`](#blazorwasm)       | [C#]         | Web/Blazor/WebAssembly                | 3.1.300    |
| ASP.NET Core Empty                           | [`web`](#web)                     | [C#], F#     | Web/Empty                             | 1.0        |
| ASP.NET Core Web App (Model-View-Controller) | [`mvc`](#web-options)             | [C#], F#     | Web/MVC                               | 1.0        |
| ASP.NET Core Web App                         | [`webapp, razor`](#web-options)   | [C#]         | Web/MVC/Razor Pages                   | 2.2, 2.0   |
| ASP.NET Core with Angular                    | [`angular`](#spa)                 | [C#]         | Web/MVC/SPA                           | 2.0        |
| ASP.NET Core with React.js                   | [`react`](#spa)                   | [C#]         | Web/MVC/SPA                           | 2.0        |
| ASP.NET Core with React.js and Redux         | [`reactredux`](#reactredux)       | [C#]         | Web/MVC/SPA                           | 2.0        |
| Razor Class Library                          | [`razorclasslib`](#razorclasslib) | [C#]         | Web/Razor/Library/Razor Class Library | 2.1        |
| ASP.NET Core Web API                         | [`webapi`](#webapi)               | [C#], F#     | Web/WebAPI                            | 1.0        |
| ASP.NET Core gRPC Service                    | [`grpc`](#web-others)             | [C#]         | Web/gRPC                              | 3.0        |
| dotnet gitignore file                        | `gitignore`                       |              | Config                                | 3.0        |
| global.json file                             | [`globaljson`](#globaljson)       |              | Config                                | 2.0        |
| NuGet Config                                 | `nugetconfig`                     |              | Config                                | 1.0        |
| Dotnet local tool manifest file              | `tool-manifest`                   |              | Config                                | 3.0        |
| Web Config                                   | `webconfig`                       |              | Config                                | 1.0        |
| Solution File                                | `sln`                             |              | Solution                              | 1.0        |
| Protocol Buffer File                         | [`proto`](#namespace)             |              | Web/gRPC                              | 3.0        |
| EditorConfig file                            | `editorconfig`(#editorconfig)     |              | Config                                | 6.0        |

## Template options

Each template may have additional options available. The core templates have the following additional options:

## `console`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Available since .NET Core 3.0 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |

  The ability to create a project for an earlier TFM depends on having that version of the SDK installed. For example, if you have only SDK 5.0 installed, then the only value available for `--framework` is `net5.0`. If you install SDK 3.1, the value `netcoreapp3.1` becomes available for `--framework`. If you install SDK 2.1, `netcoreapp2.1` becomes available, and so on. So by specifying `--framework netcoreapp2.1` you can use SDK 2.1 even while running `dotnet new` in SDK 5.0.

  Alternatively, to create a project that targets a framework earlier than the SDK that you're using, you might be able to do it by installing the NuGet package for the template. [Common](https://www.nuget.org/packages?q=Microsoft.DotNet.Common.ProjectTemplates), [web](https://www.nuget.org/packages?q=Microsoft.DotNet.Web.ProjectTemplates), and [SPA](https://www.nuget.org/packages?q=Microsoft.DotNet.Web.Spa.ProjectTemplates) project types use different packages per target framework moniker (TFM). For example, to create a `console` project that targets `netcoreapp1.0`, run [`dotnet new --install`](dotnet-new-install.md) on `Microsoft.DotNet.Common.ProjectTemplates.1.x`.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#. Available since .NET Core 2.2 SDK.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  If specified, doesn't execute an implicit restore during project creation. Available since .NET Core 2.2 SDK.

***

## `classlib`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Values: `net6.0`, `net5.0`, or `netcoreapp3.1` to create a .NET Class Library or `netstandard<version>` to create a .NET Standard Class Library. The default value for .NET 6 SDK is `net6.0`.

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#. Available since .NET Core 2.2 SDK.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="wpf"></a> `wpf`, `wpflib`, `wpfcustomcontrollib`, `wpfusercontrollib`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. For the .NET 6 SDK, the default value is `net6.0`. Available since .NET Core 3.1 SDK.

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="winforms"></a> `winforms`, `winformslib`

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="web-others"></a> `worker`, `grpc`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. The default value is `netcoreapp3.1`. Available since .NET Core 3.1 SDK.

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## <a name="test"></a> `mstest`, `xunit`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option available since .NET Core 3.0 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`-p|--enable-pack`**

  Enables packaging for the project using [dotnet pack](dotnet-pack.md).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## `nunit`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.2         | `netcoreapp2.2` |
  | 2.1         | `netcoreapp2.1` |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

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

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `Individual` - Individual authentication.
  - `IndividualB2C` - Individual authentication with Azure AD B2C.
  - `SingleOrg` - Organizational authentication for a single tenant.
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

***

## `blazorwasm`

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |

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
  - `SingleOrg` - Organizational authentication for a single tenant.

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

***

## `web`

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.1` |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--no-https`**

  Turns off HTTPS.

***

## <a name="web-options"></a> `mvc`, `webapp`

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `Individual` - Individual authentication.
  - `IndividualB2C` - Individual authentication with Azure AD B2C.
  - `SingleOrg` - Organizational authentication for a single tenant.
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
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--use-browserlink`**

  Includes BrowserLink in the project. Option not available in .NET Core 2.2 and 3.1 SDK.

- **`-rrc|--razor-runtime-compilation`**

  Determines if the project is configured to use [Razor runtime compilation](/aspnet/core/mvc/views/view-compilation#runtime-compilation) in Debug builds. Option available since .NET Core 3.1.201 SDK.

***

## <a name="spa"></a> `angular`, `react`

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. Available since .NET Core 3.0 SDK.

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

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.0` |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

***

## `reactredux`

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.0` |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--no-https`**

  Turns off HTTPS.

***

## `razorclasslib`

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`-s|--support-pages-and-views`**

  Supports adding traditional Razor pages and Views in addition to components to this library. Available since .NET Core 3.0 SDK.

***

## `webapi`

- **`-au|--auth <AUTHENTICATION_TYPE>`**

  The type of authentication to use. The possible values are:

  - `None` - No authentication (Default).
  - `IndividualB2C` - Individual authentication with Azure AD B2C.
  - `SingleOrg` - Organizational authentication for a single tenant.
  - `Windows` - Windows authentication.

- **`--aad-b2c-instance <INSTANCE>`**

  The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

- **`-ssp|--susi-policy-id <ID>`**

  The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

- **`--aad-instance <INSTANCE>`**

  The Azure Active Directory instance to connect to. Use with `SingleOrg` authentication. The default value is `https://login.microsoftonline.com/`.

- **`--client-id <ID>`**

  The Client ID for this project. Use with `IndividualB2C` or `SingleOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

- **`--domain <DOMAIN>`**

  The domain for the directory tenant. Use with `IndividualB2C` or `SingleOrg` authentication. The default value is `qualified.domain.name`.

- **`--tenant-id <ID>`**

  The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

- **`-r|--org-read-access`**

  Allows this application read-access to the directory. Only applies to `SingleOrg` authentication.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-https`**

  Turns off HTTPS. `app.UseHsts` and `app.UseHttpsRedirection` aren't added to `Startup.Configure`. This option only applies if `IndividualB2C` or `SingleOrg` aren't being used for authentication.

- **`-uld|--use-local-db`**

  Specifies LocalDB should be used instead of SQLite. Only applies to `IndividualB2C` authentication.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 6.0         | `net6.0`        |
  | 5.0         | `net5.0`        |
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.1` |

  To create a project that targets a framework earlier than the SDK that you're using, see [`--framework` for `console` projects](#template-options) earlier in this article.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

## `globaljson`

- **`--sdk-version <VERSION_NUMBER>`**

  Specifies the version of the .NET SDK to use in the *global.json* file.

## `editorconfig`

Creates an *.editorconfig* file for configuring code style preferences.

- **`--empty`**

  Creates an empty *.editorconfig* instead of the defaults for .NET.

## See also

- [dotnet new command](dotnet-new.md)
- [dotnet new --list option](dotnet-new-list.md)
- [Custom templates for dotnet new](custom-templates.md)
- [Create a custom template for dotnet new](../tutorials/cli-templates-create-item-template.md)
- [Implicit using directives](../project-sdk/overview.md#implicit-using-directives)
