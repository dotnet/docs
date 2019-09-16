---
title: dotnet new command
description: The dotnet new command creates new .NET Core projects based on the specified template.
ms.date: 05/06/2019
---
# dotnet new

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet new` - Creates a new project, configuration file, or solution based on the specified template.

## Synopsis

<!-- markdownlint-disable MD025 -->

# [.NET Core 2.2](#tab/netcore22)

```console
dotnet new <TEMPLATE> [--dry-run] [--force] [-i|--install] [-lang|--language] [-n|--name] [--nuget-source] [-o|--output] [-u|--uninstall] [Template options]
dotnet new <TEMPLATE> [-l|--list] [--type]
dotnet new [-h|--help]
```

# [.NET Core 2.1](#tab/netcore21)

```console
dotnet new <TEMPLATE> [--force] [-i|--install] [-lang|--language] [-n|--name] [--nuget-source] [-o|--output] [-u|--uninstall] [Template options]
dotnet new <TEMPLATE> [-l|--list] [--type]
dotnet new [-h|--help]
```

# [.NET Core 2.0](#tab/netcore20)

```console
dotnet new <TEMPLATE> [--force] [-i|--install] [-lang|--language] [-n|--name] [-o|--output] [-u|--uninstall] [Template options]
dotnet new <TEMPLATE> [-l|--list] [--type]
dotnet new [-h|--help]
```

# [.NET Core 1.x](#tab/netcore1x)

```console
dotnet new <TEMPLATE> [-lang|--language] [-n|--name] [-o|--output] [-all|--show-all] [-h|--help] [Template options]
dotnet new <TEMPLATE> [-l|--list]
dotnet new [-all|--show-all]
dotnet new [-h|--help]
```

---

## Description

The `dotnet new` command provides a convenient way to initialize a valid .NET Core project.

The command calls the [template engine](https://github.com/dotnet/templating) to create the artifacts on disk based on the specified template and options.

## Arguments

`TEMPLATE`

The template to instantiate when the command is invoked. Each template might have specific options you can pass. For more information, see [Template options](#template-options).

If the `TEMPLATE` value isn't an exact match on text in the **Templates** or **Short Name** column, a substring match is performed on those two columns.

# [.NET Core 2.2](#tab/netcore22)

The command contains a default list of templates. Use `dotnet new -l` to obtain a list of the available templates. The following table shows the templates that come pre-installed with the .NET Core SDK 2.2.100. The default language for the template is shown inside the brackets.

| Templates                                    | Short Name        | Language     | Tags                                  |
|----------------------------------------------|-------------------|--------------|---------------------------------------|
| Console Application                          | `console`         | [C#], F#, VB | Common/Console                        |
| Class library                                | `classlib`        | [C#], F#, VB | Common/Library                        |
| Unit Test Project                            | `mstest`          | [C#], F#, VB | Test/MSTest                           |
| NUnit 3 Test Project                         | `nunit`           | [C#], F#, VB | Test/NUnit                            |
| NUnit 3 Test Item                            | `nunit-test`      | [C#], F#, VB | Test/NUnit                            |
| xUnit Test Project                           | `xunit`           | [C#], F#, VB | Test/xUnit                            |
| Razor Page                                   | `page`            | [C#]         | Web/ASP.NET                           |
| MVC ViewImports                              | `viewimports`     | [C#]         | Web/ASP.NET                           |
| MVC ViewStart                                | `viewstart`       | [C#]         | Web/ASP.NET                           |
| ASP.NET Core Empty                           | `web`             | [C#], F#     | Web/Empty                             |
| ASP.NET Core Web App (Model-View-Controller) | `mvc`             | [C#], F#     | Web/MVC                               |
| ASP.NET Core Web App                         | `webapp`, `razor` | [C#]         | Web/MVC/Razor Pages                   |
| ASP.NET Core with Angular                    | `angular`         | [C#]         | Web/MVC/SPA                           |
| ASP.NET Core with React.js                   | `react`           | [C#]         | Web/MVC/SPA                           |
| ASP.NET Core with React.js and Redux         | `reactredux`      | [C#]         | Web/MVC/SPA                           |
| Razor Class Library                          | `razorclasslib`   | [C#]         | Web/Razor/Library/Razor Class Library |
| ASP.NET Core Web API                         | `webapi`          | [C#], F#     | Web/WebAPI                            |
| global.json file                             | `globaljson`      |              | Config                                |
| NuGet Config                                 | `nugetconfig`     |              | Config                                |
| Web Config                                   | `webconfig`       |              | Config                                |
| Solution File                                | `sln`             |              | Solution                              |

# [.NET Core 2.1](#tab/netcore21)

The command contains a default list of templates. Use `dotnet new -l` to obtain a list of the available templates. The following table shows the templates that come pre-installed with the .NET Core SDK 2.1.300. The default language for the template is shown inside the brackets.

| Templates                                    | Short Name      | Language     | Tags                                  |
|----------------------------------------------|-----------------|--------------|---------------------------------------|
| Console Application                          | `console`       | [C#], F#, VB | Common/Console                        |
| Class library                                | `classlib`      | [C#], F#, VB | Common/Library                        |
| Unit Test Project                            | `mstest`        | [C#], F#, VB | Test/MSTest                           |
| xUnit Test Project                           | `xunit`         | [C#], F#, VB | Test/xUnit                            |
| Razor Page                                   | `page`          | [C#]         | Web/ASP.NET                           |
| MVC ViewImports                              | `viewimports`   | [C#]         | Web/ASP.NET                           |
| MVC ViewStart                                | `viewstart`     | [C#]         | Web/ASP.NET                           |
| ASP.NET Core Empty                           | `web`           | [C#], F#     | Web/Empty                             |
| ASP.NET Core Web App (Model-View-Controller) | `mvc`           | [C#], F#     | Web/MVC                               |
| ASP.NET Core Web App                         | `razor`         | [C#]         | Web/MVC/Razor Pages                   |
| ASP.NET Core with Angular                    | `angular`       | [C#]         | Web/MVC/SPA                           |
| ASP.NET Core with React.js                   | `react`         | [C#]         | Web/MVC/SPA                           |
| ASP.NET Core with React.js and Redux         | `reactredux`    | [C#]         | Web/MVC/SPA                           | 
| Razor Class Library                          | `razorclasslib` | [C#]         | Web/Razor/Library/Razor Class Library |
| ASP.NET Core Web API                         | `webapi`        | [C#], F#     | Web/WebAPI                            |
| global.json file                             | `globaljson`    |              | Config                                |
| NuGet Config                                 | `nugetconfig`   |              | Config                                |
| Web Config                                   | `webconfig`     |              | Config                                |
| Solution File                                | `sln`           |              | Solution                              |

# [.NET Core 2.0](#tab/netcore20)

The command contains a default list of templates. Use `dotnet new -l` to obtain a list of the available templates. The following table shows the templates that come pre-installed with the .NET Core SDK 2.0.0. The default language for the template is shown inside the brackets.

| Templates                                    | Short Name    | Language     | Tags                |
|----------------------------------------------|---------------|--------------|---------------------|
| Console Application                          | `console`     | [C#], F#, VB | Common/Console      |
| Class library                                | `classlib`    | [C#], F#, VB | Common/Library      |
| Unit Test Project                            | `mstest`      | [C#], F#, VB | Test/MSTest         |
| xUnit Test Project                           | `xunit`       | [C#], F#, VB | Test/xUnit          |
| ASP.NET Core Empty                           | `web`         | [C#], F#     | Web/Empty           |
| ASP.NET Core Web App (Model-View-Controller) | `mvc`         | [C#], F#     | Web/MVC             |
| ASP.NET Core Web App                         | `razor`       | [C#]         | Web/MVC/Razor Pages |
| ASP.NET Core with Angular                    | `angular`     | [C#]         | Web/MVC/SPA         |
| ASP.NET Core with React.js                   | `react`       | [C#]         | Web/MVC/SPA         |
| ASP.NET Core with React.js and Redux         | `reactredux`  | [C#]         | Web/MVC/SPA         |
| ASP.NET Core Web API                         | `webapi`      | [C#], F#     | Web/WebAPI          |
| global.json file                             | `globaljson`  |              | Config              |
| Nuget Config                                 | `nugetconfig` |              | Config              |
| Web Config                                   | `webconfig`   |              | Config              |
| Solution File                                | `sln`         |              | Solution            |
| Razor Page                                   | `page`        |              | Web/ASP.NET         |
| MVC ViewImports                              | `viewimports` |              | Web/ASP.NET         |
| MVC ViewStart                                | `viewstart`   |              | Web/ASP.NET         |

# [.NET Core 1.x](#tab/netcore1x)

The command contains a default list of templates. Use `dotnet new -all` to obtain a list of the available templates. The following table shows the templates that come pre-installed with the .NET Core SDK 1.0.1. The default language for the template is shown inside the brackets.

| Templates            | Short Name    | Language | Tags           |
|----------------------|---------------|----------|----------------|
| Console Application  | `console`     | [C#], F# | Common/Console |
| Class library        | `classlib`    | [C#], F# | Common/Library |
| Unit Test Project    | `mstest`      | [C#], F# | Test/MSTest    |
| xUnit Test Project   | `xunit`       | [C#], F# | Test/xUnit     |
| ASP.NET Core Empty   | `web`         | [C#]     | Web/Empty      |
| ASP.NET Core Web App | `mvc`         | [C#], F# | Web/MVC        |
| ASP.NET Core Web API | `webapi`      | [C#]     | Web/WebAPI     |
| Nuget Config         | `nugetconfig` |          | Config         |
| Web Config           | `webconfig`   |          | Config         |
| Solution File        | `sln`         |          | Solution       |

---

## Options

# [.NET Core 2.2](#tab/netcore22)

`--dry-run`

Displays a summary of what would happen if the given command were run if it would result in a template creation.

`--force`

Forces content to be generated even if it would change existing files. This is required when the output directory already contains a project.

`-h|--help`

Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template, such as `dotnet new mvc --help`.

`-i|--install <PATH|NUGET_ID>`

Installs a source or template pack from the `PATH` or `NUGET_ID` provided. If you want to install a prerelease version of a template package, you need to specify the version in the format of `<package-name>::<package-version>`. By default, `dotnet new` passes \* for the version, which represents the last stable package version. See an example at the [Examples](#examples) section.

For information on creating custom templates, see [Custom templates for dotnet new](custom-templates.md).

`-l|--list`

Lists templates containing the specified name. If invoked for the `dotnet new` command, it lists the possible templates available for the given directory. For example if the directory already contains a project, it doesn't list all project templates.

`-lang|--language {C#|F#|VB}`

The language of the template to create. The language accepted varies by the template (see defaults in the [arguments](#arguments) section). Not valid for some templates.

> [!NOTE]
> Some shells interpret `#` as a special character. In those cases, you need to enclose the language parameter value, such as `dotnet new console -lang "F#"`.

`-n|--name <OUTPUT_NAME>`

The name for the created output. If no name is specified, the name of the current directory is used.

`--nuget-source`

Specifies a NuGet source to use during install.

`-o|--output <OUTPUT_DIRECTORY>`

Location to place the generated output. The default is the current directory.

`--type`

Filters templates based on available types. Predefined values are "project", "item", or "other".

`-u|--uninstall <PATH|NUGET_ID>`

Uninstalls a source or template pack at the `PATH` or `NUGET_ID` provided. When excluding the `<PATH|NUGET_ID>` value, all currently installed template packs and their associated templates are displayed.

> [!NOTE]
> To uninstall a template using a `PATH`, you need to fully qualify the path. For example, *C:/Users/\<USER>/Documents/Templates/GarciaSoftware.ConsoleTemplate.CSharp* will work, but *./GarciaSoftware.ConsoleTemplate.CSharp* from the containing folder will not.
> Additionally, do not include a final terminating directory slash on your template path.

# [.NET Core 2.1](#tab/netcore21)

`--force`

Forces content to be generated even if it would change existing files. This is required when the output directory already contains a project.

`-h|--help`

Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template, such as `dotnet new mvc --help`.

`-i|--install <PATH|NUGET_ID>`

Installs a source or template pack from the `PATH` or `NUGET_ID` provided. If you want to install a prerelease version of a template package, you need to specify the version in the format of `<package-name>::<package-version>`. By default, `dotnet new` passes \* for the version, which represents the last stable package version. See an example at the [Examples](#examples) section.

For information on creating custom templates, see [Custom templates for dotnet new](custom-templates.md).

`-l|--list`

Lists templates containing the specified name. If invoked for the `dotnet new` command, it lists the possible templates available for the given directory. For example if the directory already contains a project, it doesn't list all project templates.

`-lang|--language {C#|F#|VB}`

The language of the template to create. The language accepted varies by the template (see defaults in the [arguments](#arguments) section). Not valid for some templates.

> [!NOTE]
> Some shells interpret `#` as a special character. In those cases, you need to enclose the language parameter value, such as `dotnet new console -lang "F#"`.

`-n|--name <OUTPUT_NAME>`

The name for the created output. If no name is specified, the name of the current directory is used.

`--nuget-source`

Specifies a NuGet source to use during install.

`-o|--output <OUTPUT_DIRECTORY>`

Location to place the generated output. The default is the current directory.

`--type`

Filters templates based on available types. Predefined values are "project", "item" or "other".

`-u|--uninstall <PATH|NUGET_ID>`

Uninstalls a source or template pack at the `PATH` or `NUGET_ID` provided.

> [!NOTE]
> To uninstall a template using a `PATH`, you need to fully qualify the path. For example, *C:/Users/\<USER>/Documents/Templates/GarciaSoftware.ConsoleTemplate.CSharp* will work, but *./GarciaSoftware.ConsoleTemplate.CSharp* from the containing folder will not.
> Additionally, do not include a final terminating directory slash on your template path.

# [.NET Core 2.0](#tab/netcore20)

`--force`

Forces content to be generated even if it would change existing files. This is required when the output directory already contains a project.

`-h|--help`

Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template, such as `dotnet new mvc --help`.

`-i|--install <PATH|NUGET_ID>`

Installs a source or template pack from the `PATH` or `NUGET_ID` provided. If you want to install a prerelease version of a template package, you need to specify the version in the format of `<package-name>::<package-version>`. By default, `dotnet new` passes \* for the version, which represents the last stable package version. See an example at the [Examples](#examples) section.

For information on creating custom templates, see [Custom templates for dotnet new](custom-templates.md).

`-l|--list`

Lists templates containing the specified name. If invoked for the `dotnet new` command, it lists the possible templates available for the given directory. For example if the directory already contains a project, it doesn't list all project templates.

`-lang|--language {C#|F#|VB}`

The language of the template to create. The language accepted varies by the template (see defaults in the [arguments](#arguments) section). Not valid for some templates.

> [!NOTE]
> Some shells interpret `#` as a special character. In those cases, you need to enclose the language parameter value, such as `dotnet new console -lang "F#"`.

`-n|--name <OUTPUT_NAME>`

The name for the created output. If no name is specified, the name of the current directory is used.

`-o|--output <OUTPUT_DIRECTORY>`

Location to place the generated output. The default is the current directory.

`--type`

Filters templates based on available types. Predefined values are "project", "item" or "other".

`-u|--uninstall <PATH|NUGET_ID>`

Uninstalls a source or template pack at the `PATH` or `NUGET_ID` provided.

> [!NOTE]
> To uninstall a template using a source `PATH`, you need to fully qualify the path. For example, *C:/Users/\<USER>/Documents/Templates/GarciaSoftware.ConsoleTemplate.CSharp* will work, but *./GarciaSoftware.ConsoleTemplate.CSharp* from the containing folder will not. Additionally, do not include a final terminating directory slash on your template path.
> 
> If you are unable to determine the `PATH` or `NUGET_ID` argument needed to uninstall a template, running `dotnet new --uninstall` without an argument will list all installed templates and the argument required to uninstall them.

# [.NET Core 1.x](#tab/netcore1x)

`-all|--show-all`

Shows all templates for a specific type of project when running in the context of the `dotnet new` command alone. When running in the context of a specific template, such as `dotnet new web -all`, `-all` is interpreted as a force creation flag. This is required when the output directory already contains a project.

`-h|--help`

Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template, such as `dotnet new mvc --help`.

`-l|--list`

Lists templates containing the specified name. If invoked for the `dotnet new` command, it lists the possible templates available for the given directory. For example if the directory already contains a project, it doesn't list all project templates.

`-lang|--language {C#|F#}`

The language of the template to create. The language accepted varies by the template (see defaults in the [arguments](#arguments) section). Not valid for some templates.

> [!NOTE]
> Some shells interpret `#` as a special character. In those cases, you need to enclose the language parameter value, such as `dotnet new console -lang "F#"`.

`-n|--name <OUTPUT_NAME>`

The name for the created output. If no name is specified, the name of the current directory is used.

`-o|--output <OUTPUT_DIRECTORY>`

Location to place the generated output. The default is the current directory.

---

## Template options

Each project template may have additional options available. The core templates have the following additional options:

# [.NET Core 2.2](#tab/netcore22)

**console**

`--langVersion <VERSION_NUMBER>` - Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**angular, react, reactredux**

`--exclude-launch-settings` - Exclude *launchSettings.json* from the generated template.

`--no-restore` - Doesn't execute an implicit restore during project creation.

`--no-https` - Project doesn't require HTTPS. This option only applies if `IndividualAuth` or `OrganizationalAuth` are not being used.

**razorclasslib**

`--no-restore` - Doesn't execute an implicit restore during project creation.

**classlib**

`-f|--framework <FRAMEWORK>` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp2.2` to create a .NET Core Class Library or `netstandard2.0` to create a .NET Standard Class Library. The default value is `netstandard2.0`.

`--langVersion <VERSION_NUMBER>` - Sets the `LangVersion` property in the created project file. For example, use `--langVersion 7.3` to use C# 7.3. Not supported for F#.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**mstest, xunit**

`-p|--enable-pack` - Enables packaging for the project using [dotnet pack](dotnet-pack.md).

`--no-restore` - Doesn't execute an implicit restore during project creation.

**nunit**

`-f|--framework <FRAMEWORK>` - Specifies the [framework](../../standard/frameworks.md) to target. The default value is `netcoreapp2.1`.

`-p|--enable-pack` - Enables packaging for the project using [dotnet pack](dotnet-pack.md).

`--no-restore` - Doesn't execute an implicit restore during project creation.

**page**

`-na|--namespace <NAMESPACE_NAME>` - Namespace for the generated code. The default value is `MyApp.Namespace`.

`-np|--no-pagemodel` - Creates the page without a PageModel.

**viewimports**

`-na|--namespace <NAMESPACE_NAME>` - Namespace for the generated code. The default value is `MyApp.Namespace`.

**web**

`--exclude-launch-settings` - Exclude *launchSettings.json* from the generated template.

`--no-restore` - Doesn't execute an implicit restore during project creation.

`--no-https` - Project doesn't require HTTPS. This option only applies if `IndividualAuth` or `OrganizationalAuth` are not being used.

**mvc, webapp**

`-au|--auth <AUTHENTICATION_TYPE>` - The type of authentication to use. The possible values are:

- `None` - No authentication (Default).
- `Individual` - Individual authentication.
- `IndividualB2C` - Individual authentication with Azure AD B2C.
- `SingleOrg` - Organizational authentication for a single tenant.
- `MultiOrg` - Organizational authentication for multiple tenants.
- `Windows` - Windows authentication.

`--aad-b2c-instance <INSTANCE>` - The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

`-ssp|--susi-policy-id <ID>` - The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

`-rp|--reset-password-policy-id <ID>` - The reset password policy ID for this project. Use with `IndividualB2C` authentication.

`-ep|--edit-profile-policy-id <ID>` - The edit profile policy ID for this project. Use with `IndividualB2C` authentication.

`--aad-instance <INSTANCE>` - The Azure Active Directory instance to connect to. Use with `SingleOrg` or `MultiOrg` authentication. The default value is `https://login.microsoftonline.com/`.

`--client-id <ID>` - The Client ID for this project. Use with `IndividualB2C`, `SingleOrg`, or `MultiOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

`--domain <DOMAIN>` - The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

`--tenant-id <ID>` - The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

`--callback-path <PATH>` - The request path within the application's base path of the redirect URI. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `/signin-oidc`.

`-r|--org-read-access` - Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

`--exclude-launch-settings` - Exclude *launchSettings.json* from the generated template.

`--no-https` - Project doesn't require HTTPS. `app.UseHsts` and `app.UseHttpsRedirection` aren't added to `Startup.Configure`. This option only applies if `Individual`, `IndividualB2C`, `SingleOrg`, or `MultiOrg` aren't being used.

`-uld|--use-local-db` - Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**webapi**

`-au|--auth <AUTHENTICATION_TYPE>` - The type of authentication to use. The possible values are:

- `None` - No authentication (Default).
- `IndividualB2C` - Individual authentication with Azure AD B2C.
- `SingleOrg` - Organizational authentication for a single tenant.
- `Windows` - Windows authentication.

`--aad-b2c-instance <INSTANCE>` - The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

`-ssp|--susi-policy-id <ID>` - The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

`--aad-instance <INSTANCE>` - The Azure Active Directory instance to connect to. Use with `SingleOrg` authentication. The default value is `https://login.microsoftonline.com/`.

`--client-id <ID>` - The Client ID for this project. Use with `IndividualB2C` or `SingleOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

`--domain <DOMAIN>` - The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

`--tenant-id <ID>` - The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

`-r|--org-read-access` - Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

`--exclude-launch-settings` - Exclude *launchSettings.json* from the generated template.

`--no-https` - Project doesn't require HTTPS. `app.UseHsts` and `app.UseHttpsRedirection` aren't added to `Startup.Configure`. This option only applies if `Individual`, `IndividualB2C`, `SingleOrg`, or `MultiOrg` aren't being used.

`-uld|--use-local-db` - Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**globaljson**

`--sdk-version <VERSION_NUMBER>` - Specifies the version of the .NET Core SDK to use in the *global.json* file.

# [.NET Core 2.1](#tab/netcore21)

**console, angular, react, reactredux, razorclasslib**

`--no-restore` - Doesn't execute an implicit restore during project creation.

**classlib**

`-f|--framework <FRAMEWORK>` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp2.1` to create a .NET Core Class Library or `netstandard2.0` to create a .NET Standard Class Library. The default value is `netstandard2.0`.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**mstest, xunit**

`-p|--enable-pack` - Enables packaging for the project using [dotnet pack](dotnet-pack.md).

`--no-restore` - Doesn't execute an implicit restore during project creation.

**globaljson**

`--sdk-version <VERSION_NUMBER>` - Specifies the version of the .NET Core SDK to use in the *global.json* file.

**web**

`--exclude-launch-settings` - Exclude *launchSettings.json* from the generated template.

`--no-restore` - Doesn't execute an implicit restore during project creation.

`--no-https` - Project doesn't require HTTPS. This option only applies if `IndividualAuth` or `OrganizationalAuth` are not being used.

**webapi**

`-au|--auth <AUTHENTICATION_TYPE>` - The type of authentication to use. The possible values are:

- `None` - No authentication (Default).
- `IndividualB2C` - Individual authentication with Azure AD B2C.
- `SingleOrg` - Organizational authentication for a single tenant.
- `Windows` - Windows authentication.

`--aad-b2c-instance <INSTANCE>` - The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

`-ssp|--susi-policy-id <ID>` - The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

`--aad-instance <INSTANCE>` - The Azure Active Directory instance to connect to. Use with `SingleOrg` authentication. The default value is `https://login.microsoftonline.com/`.

`--client-id <ID>` - The Client ID for this project. Use with `IndividualB2C` or `SingleOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

`--domain <DOMAIN>` - The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

`--tenant-id <ID>` - The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

`-r|--org-read-access` - Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

`--exclude-launch-settings` - Exclude *launchSettings.json* from the generated template.

`-uld|--use-local-db` - Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

`--no-restore` - Doesn't execute an implicit restore during project creation.

`--no-https` - Project doesn't require HTTPS. `app.UseHsts` and `app.UseHttpsRedirection` aren't added to `Startup.Configure`. This option only applies if `Individual`, `IndividualB2C`, `SingleOrg`, or `MultiOrg` aren't being used.

**mvc, razor**

`-au|--auth <AUTHENTICATION_TYPE>` - The type of authentication to use. The possible values are:

- `None` - No authentication (Default).
- `Individual` - Individual authentication.
- `IndividualB2C` - Individual authentication with Azure AD B2C.
- `SingleOrg` - Organizational authentication for a single tenant.
- `MultiOrg` - Organizational authentication for multiple tenants.
- `Windows` - Windows authentication.

`--aad-b2c-instance <INSTANCE>` - The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

`-ssp|--susi-policy-id <ID>` - The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

`-rp|--reset-password-policy-id <ID>` - The reset password policy ID for this project. Use with `IndividualB2C` authentication.

`-ep|--edit-profile-policy-id <ID>` - The edit profile policy ID for this project. Use with `IndividualB2C` authentication.

`--aad-instance <INSTANCE>` - The Azure Active Directory instance to connect to. Use with `SingleOrg` or `MultiOrg` authentication. The default value is `https://login.microsoftonline.com/`.

`--client-id <ID>` - The Client ID for this project. Use with `IndividualB2C`, `SingleOrg`, or `MultiOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

`--domain <DOMAIN>` - The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

`--tenant-id <ID>` - The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

`--callback-path <PATH>` - The request path within the application's base path of the redirect URI. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `/signin-oidc`.

`-r|--org-read-access` - Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

`--exclude-launch-settings` - Exclude *launchSettings.json* from the generated template.

`--use-browserlink` - Includes BrowserLink in the project.

`-uld|--use-local-db` - Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

`--no-restore` - Doesn't execute an implicit restore during project creation.

`--no-https` - Project doesn't require HTTPS. `app.UseHsts` and `app.UseHttpsRedirection` aren't added to `Startup.Configure`. This option only applies if `Individual`, `IndividualB2C`, `SingleOrg`, or `MultiOrg` aren't being used.

**page**

`-na|--namespace <NAMESPACE_NAME>` - Namespace for the generated code. The default value is `MyApp.Namespace`.

`-np|--no-pagemodel` - Creates the page without a PageModel.

**viewimports**

`-na|--namespace <NAMESPACE_NAME>` - Namespace for the generated code. The default value is `MyApp.Namespace`.

# [.NET Core 2.0](#tab/netcore20)

**console, angular, react, reactredux**

`--no-restore` - Doesn't execute an implicit restore during project creation.

**classlib**

`-f|--framework <FRAMEWORK>` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp2.0` to create a .NET Core Class Library or `netstandard2.0` to create a .NET Standard Class Library. The default value is `netstandard2.0`.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**mstest, xunit**

`-p|--enable-pack` - Enables packaging for the project using [dotnet pack](dotnet-pack.md).

`--no-restore` - Doesn't execute an implicit restore during project creation.

**globaljson**

`--sdk-version <VERSION_NUMBER>` - Specifies the version of the .NET Core SDK to use in the *global.json* file.

**web**

`--use-launch-settings` - Includes *launchSettings.json* in the generated template output.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**webapi**

`-au|--auth <AUTHENTICATION_TYPE>` - The type of authentication to use. The possible values are:

- `None` - No authentication (Default).
- `IndividualB2C` - Individual authentication with Azure AD B2C.
- `SingleOrg` - Organizational authentication for a single tenant.
- `Windows` - Windows authentication.

`--aad-b2c-instance <INSTANCE>` - The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

`-ssp|--susi-policy-id <ID>` - The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

`--aad-instance <INSTANCE>` - The Azure Active Directory instance to connect to. Use with `SingleOrg` authentication. The default value is `https://login.microsoftonline.com/`.

`--client-id <ID>` - The Client ID for this project. Use with `IndividualB2C` or `SingleOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

`--domain <DOMAIN>` - The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

`--tenant-id <ID>` - The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

`-r|--org-read-access` - Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

`--use-launch-settings` - Includes *launchSettings.json* in the generated template output.

`-uld|--use-local-db` - Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**mvc, razor**

`-au|--auth <AUTHENTICATION_TYPE>` - The type of authentication to use. The possible values are:

- `None` - No authentication (Default).
- `Individual` - Individual authentication.
- `IndividualB2C` - Individual authentication with Azure AD B2C.
- `SingleOrg` - Organizational authentication for a single tenant.
- `MultiOrg` - Organizational authentication for multiple tenants.
- `Windows` - Windows authentication.

`--aad-b2c-instance <INSTANCE>` - The Azure Active Directory B2C instance to connect to. Use with `IndividualB2C` authentication. The default value is `https://login.microsoftonline.com/tfp/`.

`-ssp|--susi-policy-id <ID>` - The sign-in and sign-up policy ID for this project. Use with `IndividualB2C` authentication.

`-rp|--reset-password-policy-id <ID>` - The reset password policy ID for this project. Use with `IndividualB2C` authentication.

`-ep|--edit-profile-policy-id <ID>` - The edit profile policy ID for this project. Use with `IndividualB2C` authentication.

`--aad-instance <INSTANCE>` - The Azure Active Directory instance to connect to. Use with `SingleOrg` or `MultiOrg` authentication. The default value is `https://login.microsoftonline.com/`.

`--client-id <ID>` - The Client ID for this project. Use with `IndividualB2C`, `SingleOrg`, or `MultiOrg` authentication. The default value is `11111111-1111-1111-11111111111111111`.

`--domain <DOMAIN>` - The domain for the directory tenant. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `qualified.domain.name`.

`--tenant-id <ID>` - The TenantId ID of the directory to connect to. Use with `SingleOrg` authentication. The default value is `22222222-2222-2222-2222-222222222222`.

`--callback-path <PATH>` - The request path within the application's base path of the redirect URI. Use with `SingleOrg` or `IndividualB2C` authentication. The default value is `/signin-oidc`.

`-r|--org-read-access` - Allows this application read-access to the directory. Only applies to `SingleOrg` or `MultiOrg` authentication.

`--use-launch-settings` - Includes *launchSettings.json* in the generated template output.

`--use-browserlink` - Includes BrowserLink in the project.

`-uld|--use-local-db` - Specifies LocalDB should be used instead of SQLite. Only applies to `Individual` or `IndividualB2C` authentication.

`--no-restore` - Doesn't execute an implicit restore during project creation.

**page**

`-na|--namespace <NAMESPACE_NAME>`- Namespace for the generated code. The default value is `MyApp.Namespace`.

`-np|--no-pagemodel` - Creates the page without a PageModel.

**viewimports**

`-na|--namespace <NAMESPACE_NAME>`- Namespace for the generated code. The default value is `MyApp.Namespace`.

# [.NET Core 1.x](#tab/netcore1x)

**console, xunit, mstest, web, webapi**

`-f|--framework <FRAMEWORK>` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp1.0` or `netcoreapp1.1`. The default value is `netcoreapp1.0`.

**classlib**

`-f|--framework <FRAMEWORK>` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp1.0`, `netcoreapp1.1`, or `netstandard1.0` to `netstandard1.6`. The default value is `netstandard1.4`.

**mvc**

`-f|--framework <FRAMEWORK>` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp1.0` or `netcoreapp1.1`. The default value is `netcoreapp1.0`.

`-au|--auth <AUTHENTICATION_TYPE>` - The type of authentication to use. Values: `None` or `Individual`. The default value is `None`.

`-uld|--use-local-db` - Specifies whether or not to use LocalDB instead of SQLite. Values: `true` or `false`. The default value is `false`.

---

## Examples

Create a C# console application project by specifying the template name:

`dotnet new "Console Application"`

Create an F# console application project in the current directory:

`dotnet new console -lang F#`

Create a .NET Standard class library project in the specified directory (available only with .NET Core SDK 2.0 or later versions):

`dotnet new classlib -lang VB -o MyLibrary`

Create a new ASP.NET Core C# MVC project in the current directory with no authentication:

`dotnet new mvc -au None`

Create a new xUnit project:

`dotnet new xunit`

List all templates available for MVC:

`dotnet new mvc -l`

List all templates matching the *we* substring. No exact match is found, so substring matching runs against both the short name and name columns.

`dotnet new we -l`

Attempt to invoke the template matching *ng*. If a single match can't be determined, list the templates that are partial matches.

`dotnet new ng`

Install version 2.0 of the Single Page Application templates for ASP.NET Core (command option available for .NET Core SDK 1.1 and later versions only):

`dotnet new -i Microsoft.DotNet.Web.Spa.ProjectTemplates::2.0.0`

Create a *global.json* in the current directory setting the SDK version to 2.0.0 (available only with .NET Core SDK 2.0 or later versions):

`dotnet new globaljson --sdk-version 2.0.0`

## See also

- [Custom templates for dotnet new](custom-templates.md)
- [Create a custom template for dotnet new](../tutorials/create-custom-template.md)
- [dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)
- [Available templates for dotnet new](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)
