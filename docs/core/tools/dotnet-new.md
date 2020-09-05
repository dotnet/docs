---
title: dotnet new command
description: The dotnet new command creates new .NET Core projects based on the specified template.
no-loc: [Blazor, WebAssembly]
ms.date: 09/01/2020
---
# dotnet new

**This article applies to:** ✔️ .NET Core 2.0 SDK and later versions

## Name

`dotnet new` - Creates a new project, configuration file, or solution based on the specified template.

## Synopsis

```dotnetcli
dotnet new <TEMPLATE> [--dry-run] [--force] [-i|--install {PATH|NUGET_ID}]
    [-lang|--language {"C#"|"F#"|VB}] [-n|--name <OUTPUT_NAME>]
    [--nuget-source <SOURCE>] [-o|--output <OUTPUT_DIRECTORY>]
    [-u|--uninstall] [--update-apply] [--update-check] [Template options]

dotnet new <TEMPLATE> [-l|--list] [--type <TYPE>]

dotnet new -h|--help
```

## Description

The `dotnet new` command creates a .NET Core project or other artifacts based on a template.

The command calls the [template engine](https://github.com/dotnet/templating) to create the artifacts on disk based on the specified template and options.

### Implicit restore

[!INCLUDE[dotnet restore note](~/includes/dotnet-restore-note.md)]

## Arguments

- **`TEMPLATE`**

  The template to instantiate when the command is invoked. Each template might have specific options you can pass. For more information, see [Template options](#template-options).

  You can run `dotnet new --list` or `dotnet new -l` to see a list of all installed templates. If the `TEMPLATE` value isn't an exact match on text in the **Templates** or **Short Name** column from the returned table, a substring match is performed on those two columns.

  Starting with .NET Core 3.0 SDK, the CLI searches for templates in NuGet.org when you invoke the `dotnet new` command in the following conditions:

  - If the CLI can't find a template match when invoking `dotnet new`, not even partial.
  - If there's a newer version of the template available. In this case, the project or artifact is created but the CLI warns you about an updated version of the template.

  The following table shows the templates that come pre-installed with the .NET Core SDK. The default language for the template is shown inside the brackets. Click on the short name link to see the specific template options.

| Templates                                    | Short name                      | Language     | Tags                                  | Introduced |
|----------------------------------------------|---------------------------------|--------------|---------------------------------------|------------|
| Console Application                          | [console](#console)             | [C#], F#, VB | Common/Console                        | 1.0        |
| Class library                                | [classlib](#classlib)           | [C#], F#, VB | Common/Library                        | 1.0        |
| WPF Application                              | [wpf](#wpf)                     | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF Class library                            | [wpflib](#wpf)                  | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF Custom Control Library                   | [wpfcustomcontrollib](#wpf)     | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| WPF User Control Library                     | [wpfusercontrollib](#wpf)       | [C#], VB     | Common/WPF                            | 3.0 (5.0 for VB)|
| Windows Forms (WinForms) Application         | [winforms](#winforms)           | [C#], VB     | Common/WinForms                       | 3.0 (5.0 for VB)|
| Windows Forms (WinForms) Class library       | [winformslib](#winforms)        | [C#], VB     | Common/WinForms                       | 3.0 (5.0 for VB)|
| Worker Service                               | [worker](#web-others)           | [C#]         | Common/Worker/Web                     | 3.0        |
| Unit Test Project                            | [mstest](#test)                 | [C#], F#, VB | Test/MSTest                           | 1.0        |
| NUnit 3 Test Project                         | [nunit](#nunit)                 | [C#], F#, VB | Test/NUnit                            | 2.1.400    |
| NUnit 3 Test Item                            | `nunit-test`                    | [C#], F#, VB | Test/NUnit                            | 2.2        |
| xUnit Test Project                           | [xunit](#test)                  | [C#], F#, VB | Test/xUnit                            | 1.0        |
| Razor Component                              | `razorcomponent`                | [C#]         | Web/ASP.NET                           | 3.0        |
| Razor Page                                   | [page](#page)                   | [C#]         | Web/ASP.NET                           | 2.0        |
| MVC ViewImports                              | [viewimports](#namespace)       | [C#]         | Web/ASP.NET                           | 2.0        |
| MVC ViewStart                                | `viewstart`                     | [C#]         | Web/ASP.NET                           | 2.0        |
| Blazor Server App                            | [blazorserver](#blazorserver)   | [C#]         | Web/Blazor                            | 3.0        |
| Blazor WebAssembly App                       | `blazorwasm`                    | [C#]         | Web/Blazor/WebAssembly                | 3.1.300    |
| ASP.NET Core Empty                           | [web](#web)                     | [C#], F#     | Web/Empty                             | 1.0        |
| ASP.NET Core Web App (Model-View-Controller) | [mvc](#web-options)             | [C#], F#     | Web/MVC                               | 1.0        |
| ASP.NET Core Web App                         | [webapp, razor](#web-options)   | [C#]         | Web/MVC/Razor Pages                   | 2.2, 2.0   |
| ASP.NET Core with Angular                    | [angular](#spa)                 | [C#]         | Web/MVC/SPA                           | 2.0        |
| ASP.NET Core with React.js                   | [react](#spa)                   | [C#]         | Web/MVC/SPA                           | 2.0        |
| ASP.NET Core with React.js and Redux         | [reactredux](#reactredux)       | [C#]         | Web/MVC/SPA                           | 2.0        |
| Razor Class Library                          | [razorclasslib](#razorclasslib) | [C#]         | Web/Razor/Library/Razor Class Library | 2.1        |
| ASP.NET Core Web API                         | [webapi](#webapi)               | [C#], F#     | Web/WebAPI                            | 1.0        |
| ASP.NET Core gRPC Service                    | [grpc](#web-others)             | [C#]         | Web/gRPC                              | 3.0        |
| dotnet gitignore file                        | `gitignore`                     |              | Config                                | 3.0        |
| global.json file                             | [globaljson](#globaljson)       |              | Config                                | 2.0        |
| NuGet Config                                 | `nugetconfig`                   |              | Config                                | 1.0        |
| Dotnet local tool manifest file              | `tool-manifest`                 |              | Config                                | 3.0        |
| Web Config                                   | `webconfig`                     |              | Config                                | 1.0        |
| Solution File                                | `sln`                           |              | Solution                              | 1.0        |
| Protocol Buffer File                         | [proto](#namespace)             |              | Web/gRPC                              | 3.0        |

## Options

- **`--dry-run`**

  Displays a summary of what would happen if the given command were run if it would result in a template creation. Available since .NET Core 2.2 SDK.

- **`--force`**

  Forces content to be generated even if it would change existing files. This is required when the template chosen would override existing files in the output directory.

- **`-h|--help`**

  Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template. For example, `dotnet new mvc --help`.

- **`-i|--install <PATH|NUGET_ID>`**

  Installs a template pack from the `PATH` or `NUGET_ID` provided. If you want to install a prerelease version of a template package, you need to specify the version in the format of `<package-name>::<package-version>`. By default, `dotnet new` passes \* for the version, which represents the latest stable package version. See an example in the [Examples](#examples) section.
  
  If a version of the template was already installed when you run this command, the template will be updated to the specified version, or to the latest stable version if no version was specified.

  For information on creating custom templates, see [Custom templates for dotnet new](custom-templates.md).

- **`-l|--list`**

  Lists templates containing the specified name. If no name is specified, lists all templates.

- **`-lang|--language {C#|F#|VB}`**

  The language of the template to create. The language accepted varies by the template (see defaults in the [arguments](#arguments) section). Not valid for some templates.

  > [!NOTE]
  > Some shells interpret `#` as a special character. In those cases, enclose the language parameter value in quotes. For example, `dotnet new console -lang "F#"`.

- **`-n|--name <OUTPUT_NAME>`**

  The name for the created output. If no name is specified, the name of the current directory is used.

- **`--nuget-source <SOURCE>`**

  Specifies a NuGet source to use during install. Available since .NET Core 2.1 SDK.

- **`-o|--output <OUTPUT_DIRECTORY>`**

  Location to place the generated output. The default is the current directory.

- **`--type <TYPE>`**

  Filters templates based on available types. Predefined values are `project`, `item`, and `other`.

- **`-u|--uninstall [PATH|NUGET_ID]`**

  Uninstalls a template pack at the `PATH` or `NUGET_ID` provided. When the `<PATH|NUGET_ID>` value isn't specified, all currently installed template packs and their associated templates are displayed. When specifying `NUGET_ID`, don't include the version number.

  If you don't specify a parameter to this option, the command lists the installed templates and details about them.

  > [!NOTE]
  > To uninstall a template using a `PATH`, you need to fully qualify the path. For example, *C:/Users/\<USER>/Documents/Templates/GarciaSoftware.ConsoleTemplate.CSharp* will work, but *./GarciaSoftware.ConsoleTemplate.CSharp* from the containing folder will not.
  > Don't include a final terminating directory slash on your template path.

- **`--update-apply`**

  Checks if there are updates available for the template packs that are currently installed and installs them. Available since .NET Core 3.0 SDK.

- **`--update-check`**

  Checks if there are updates available for the template packs that are currently installed. Available since .NET Core 3.0 SDK.

## Template options

Each project template may have additional options available. The core templates have the following additional options:

### console

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Available since .NET Core 3.0 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#. Available since .NET Core 2.2 SDK.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  If specified, doesn't execute an implicit restore during project creation. Available since .NET Core 2.2 SDK.

***

### classlib

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp<version>` to create a .NET Core Class Library or `netstandard<version>` to create a .NET Standard Class Library. The default value is `netstandard2.0`.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#. Available since .NET Core 2.2 SDK.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

### <a name="wpf"></a> wpf, wpflib, wpfcustomcontrollib, wpfusercontrollib

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. The default value is `netcoreapp3.1`. Available since .NET Core 3.1 SDK.

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

### <a name="winforms"></a> winforms, winformslib

- **`--langVersion <VERSION_NUMBER>`**

  Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3.

  For a list of default C# versions, see [Defaults](../../csharp/language-reference/configure-language-version.md#defaults).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

### <a name="web-others"></a> worker, grpc

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. The default value is `netcoreapp3.1`. Available since .NET Core 3.1 SDK.

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

### <a name="test"></a> mstest, xunit

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option available since .NET Core 3.0 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |

- **`-p|--enable-pack`**

  Enables packaging for the project using [dotnet pack](dotnet-pack.md).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

### nunit

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.2         | `netcoreapp2.2` |
  | 2.1         | `netcoreapp2.1` |

- **`-p|--enable-pack`**

  Enables packaging for the project using [dotnet pack](dotnet-pack.md).

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

### page

- **`-na|--namespace <NAMESPACE_NAME>`**

  Namespace for the generated code. The default value is `MyApp.Namespace`.

- **`-np|--no-pagemodel`**

  Creates the page without a PageModel.

***

### <a name="namespace"></a> viewimports, proto

- **`-na|--namespace <NAMESPACE_NAME>`**

  Namespace for the generated code. The default value is `MyApp.Namespace`.

***

### blazorserver

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

### web

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.1` |

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--no-https`**

  Turns off HTTPS.

***

### <a name="web-options"></a> mvc, webapp

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
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--use-browserlink`**

  Includes BrowserLink in the project. Option not available in .NET Core 2.2 and 3.1 SDK.

- **`-rrc|--razor-runtime-compilation`**

  Determines if the project is configured to use [Razor runtime compilation](/aspnet/core/mvc/views/view-compilation#runtime-compilation) in Debug builds. Option available since .NET Core 3.1.201 SDK.

***

### <a name="spa"></a> angular, react

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
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.0` |

***

### reactredux

- **`--exclude-launch-settings`**

  Excludes *launchSettings.json* from the generated template.

- **`-f|--framework <FRAMEWORK>`**

  Specifies the [framework](../../standard/frameworks.md) to target. Option not available in .NET Core 2.2 SDK.

  The following table lists the default values according to the SDK version number you're using:

  | SDK version | Default value   |
  |-------------|-----------------|
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.0` |

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`--no-https`**

  Turns off HTTPS.

***

### razorclasslib

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

- **`-s|--support-pages-and-views`**

  Supports adding traditional Razor pages and Views in addition to components to this library. Available since .NET Core 3.0 SDK.

***
  
### webapi

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
  | 3.1         | `netcoreapp3.1` |
  | 3.0         | `netcoreapp3.0` |
  | 2.1         | `netcoreapp2.1` |

- **`--no-restore`**

  Doesn't execute an implicit restore during project creation.

***

### globaljson

- **`--sdk-version <VERSION_NUMBER>`**

  Specifies the version of the .NET Core SDK to use in the *global.json* file.

***

## Examples

- Create a C# console application project by specifying the template name:

  ```dotnetcli
  dotnet new "Console Application"
  ```

- Create an F# console application project in the current directory:

  ```dotnetcli
  dotnet new console -lang "F#"
  ```

- Create a .NET Standard class library project in the specified directory:

  ```dotnetcli
  dotnet new classlib -lang VB -o MyLibrary
  ```

- Create a new ASP.NET Core C# MVC project in the current directory with no authentication:

  ```dotnetcli
  dotnet new mvc -au None
  ```

- Create a new xUnit project:

  ```dotnetcli
  dotnet new xunit
  ```

- List all templates available for Single Page Application (SPA) templates:

  ```dotnetcli
  dotnet new spa -l
  ```

- List all templates matching the *we* substring. No exact match is found, so substring matching runs against both the short name and name columns.

  ```dotnetcli
  dotnet new we -l
  ```

- Attempt to invoke the template matching *ng*. If a single match can't be determined, list the templates that are partial matches.

  ```dotnetcli
  dotnet new ng
  ```

- Install version 2.0 of the SPA templates for ASP.NET Core:

  ```dotnetcli
  dotnet new -i Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0
  ```

- List the installed templates and details about them, including how to uninstall them:

  ```dotnetcli
  dotnet new -u
  ```

- Create a *global.json* in the current directory setting the SDK version to 3.1.101:

  ```dotnetcli
  dotnet new globaljson --sdk-version 3.1.101
  ```

## See also

- [Custom templates for dotnet new](custom-templates.md)
- [Create a custom template for dotnet new](../tutorials/cli-templates-create-item-template.md)
- [dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)
- [Available templates for dotnet new](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)
