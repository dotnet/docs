---
title: Install and manage SDK templates
description: Learn how to install .NET templates on Windows, Linux, and macOS.
author: adegeo
ms.author: adegeo
ms.date: 04/24/2020
zone_pivot_groups: operating-systems-set-one
no-loc: ['dotnet new', 'dotnet nuget add source']
---

# Manage .NET project and item templates

.NET provides a template system that enables users to install or uninstall packages containing templates from NuGet, a NuGet package file, or a file system directory. This article describes how to manage .NET templates through the .NET SDK CLI.

For more information about creating templates, see [Tutorial: Create templates](../tutorials/cli-templates-create-item-template.md).

## Install template

Template packages are installed through the [dotnet new install](../tools/dotnet-new-install.md) SDK command. You can either provide the NuGet package identifier of a template package, or a folder that contains the template files.

### NuGet hosted package

.NET CLI template packages are uploaded to [NuGet](https://www.nuget.org/) for wide distribution. Template packages can also be installed from a private feed. Instead of uploading a template package to a NuGet feed, *nupkg* template files can be distributed and manually installed, as described in the [Local NuGet package](#local-nuget-package) section.

For more information about configuring NuGet feeds, see [dotnet nuget add source](../tools/dotnet-nuget-add-source.md).

To install a template package from the default NuGet feed, use the `dotnet new install {package-id}` command:

```dotnetcli
dotnet new install Microsoft.DotNet.Web.Spa.ProjectTemplates
```

To install a template package from the default NuGet feed with a specific version, use the `dotnet new install {package-id}::{version}` command:

```dotnetcli
dotnet new install Microsoft.DotNet.Web.Spa.ProjectTemplates::2.2.6
```

### Local NuGet package

When a template package is created, a *nupkg* file is generated. If you have a *nupkg* file containing templates, you can install it with the `dotnet new install {path-to-package}` command:

::: zone pivot="os-windows"

```dotnetcli
dotnet new install c:\code\nuget-packages\Some.Templates.1.0.0.nupkg
```

::: zone-end

::: zone pivot="os-linux,os-macos"

```dotnetcli
dotnet new install ~/code/nuget-packages/Some.Templates.1.0.0.nupkg
```

::: zone-end

### Folder

As an alternative to installing template from a *nupkg* file, you can also install templates from a folder directly with the `dotnet new install {folder-path}` command. The folder specified is treated as the template package identifier for any template found. Any template found in the specified folder's hierarchy is installed.

::: zone pivot="os-windows"

```dotnetcli
dotnet new install c:\code\nuget-packages\some-folder\
```

::: zone-end

::: zone pivot="os-linux,os-macos"

```dotnetcli
dotnet new install ~/code/nuget-packages/some-folder/
```

::: zone-end

The `{folder-path}` specified on the command becomes the template package identifier for all templates found. As specified in the [List template packages](#list-template-packages) section, you can get a list of template packages installed with the `dotnet new uninstall` command. In this example, the template package identifier is shown as the folder used for install:

::: zone pivot="os-windows"

```console
dotnet new uninstall
Currently installed items:

... cut to save space ...

  c:\code\nuget-packages\some-folder
    Templates:
      A Template Console Class (templateconsole) C#
      Project for some technology (contosoproject) C#
    Uninstall Command:
      dotnet new uninstall c:\code\nuget-packages\some-folder
```

::: zone-end

::: zone pivot="os-linux,os-macos"

```console
dotnet new uninstall
Currently installed items:

... cut to save space ...

  /home/username/code/templates
    Templates:
      A Template Console Class (templateconsole) C#
      Project for some technology (contosoproject) C#
    Uninstall Command:
      dotnet new uninstall /home/username/code/templates
```

::: zone-end

## Uninstall template package

Template packages are uninstalled through the [dotnet new uninstall](../tools/dotnet-new-uninstall.md) SDK command. You can either provide the NuGet package identifier of a template package, or a folder that contains the template files.

### NuGet package

After a NuGet template package is installed, either from a NuGet feed or a *nupkg* file, you can uninstall it by referencing the NuGet package identifier.

To uninstall a template package, use the `dotnet new uninstall {package-id}` command:

```dotnetcli
dotnet new uninstall Microsoft.DotNet.Web.Spa.ProjectTemplates
```

### Folder

When templates are installed through a [folder path](#folder), the folder path becomes the template package identifier.

To uninstall a template package, use the `dotnet new uninstall {package-folder-path}` command:

::: zone pivot="os-windows"

```dotnetcli
dotnet new uninstall c:\code\nuget-packages\some-folder
```

::: zone-end

::: zone pivot="os-linux,os-macos"

```dotnetcli
dotnet new uninstall /home/username/code/templates
```

::: zone-end

## List template packages

By using the standard uninstall command without a package identifier, you can see a list of installed template packages along with the command that uninstalls each template package.

```console
dotnet new uninstall
Currently installed items:

... cut to save space ...

  c:\code\nuget-packages\some-folder
    Templates:
      A Template Console Class (templateconsole) C#
      Project for some technology (contosoproject) C#
    Uninstall Command:
      dotnet new uninstall c:\code\nuget-packages\some-folder
```

## Install template packages from other SDKs

If you've installed each version of the SDK sequentially, for example you installed SDK 6.0, then SDK 7.0, and so on, you'll have every SDK's templates installed. However, if you start with a later SDK version, like 7.0, only the templates for this version are included. Templates for any other release aren't included.

The .NET templates are available on NuGet, and you can install them like any other template. For more information, see [Install NuGet hosted package](#nuget-hosted-package).

| SDK              | NuGet Package Identifier                                                                                                      |
|------------------|-------------------------------------------------------------------------------------------------------------------------------|
| .NET Core 2.1    | [`Microsoft.DotNet.Common.ProjectTemplates.2.1`](https://www.nuget.org/packages/Microsoft.DotNet.Common.ProjectTemplates.2.1) |
| .NET Core 2.2    | [`Microsoft.DotNet.Common.ProjectTemplates.2.2`](https://www.nuget.org/packages/Microsoft.DotNet.Common.ProjectTemplates.2.2) |
| .NET Core 3.0    | [`Microsoft.DotNet.Common.ProjectTemplates.3.0`](https://www.nuget.org/packages/Microsoft.DotNet.Common.ProjectTemplates.3.0) |
| .NET Core 3.1    | [`Microsoft.DotNet.Common.ProjectTemplates.3.1`](https://www.nuget.org/packages/Microsoft.DotNet.Common.ProjectTemplates.3.1) |
| .NET 5.0         | [`Microsoft.DotNet.Common.ProjectTemplates.5.0`](https://www.nuget.org/packages/Microsoft.DotNet.Common.ProjectTemplates.5.0) |
| .NET 6.0         | [`Microsoft.DotNet.Common.ProjectTemplates.6.0`](https://www.nuget.org/packages/Microsoft.DotNet.Common.ProjectTemplates.6.0) |
| .NET 7.0         | [`Microsoft.DotNet.Common.ProjectTemplates.7.0`](https://www.nuget.org/packages/Microsoft.DotNet.Common.ProjectTemplates.7.0) |
| ASP.NET Core 2.1 | [`Microsoft.DotNet.Web.ProjectTemplates.2.1`](https://www.nuget.org/packages/Microsoft.DotNet.Web.ProjectTemplates.2.1)       |
| ASP.NET Core 2.2 | [`Microsoft.DotNet.Web.ProjectTemplates.2.2`](https://www.nuget.org/packages/Microsoft.DotNet.Web.ProjectTemplates.2.2)       |
| ASP.NET Core 3.0 | [`Microsoft.DotNet.Web.ProjectTemplates.3.0`](https://www.nuget.org/packages/Microsoft.DotNet.Web.ProjectTemplates.3.0)       |
| ASP.NET Core 3.1 | [`Microsoft.DotNet.Web.ProjectTemplates.3.1`](https://www.nuget.org/packages/Microsoft.DotNet.Web.ProjectTemplates.3.1)       |
| ASP.NET Core 5.0 | [`Microsoft.DotNet.Web.ProjectTemplates.5.0`](https://www.nuget.org/packages/Microsoft.DotNet.Web.ProjectTemplates.5.0)       |
| ASP.NET Core 6.0 | [`Microsoft.DotNet.Web.ProjectTemplates.6.0`](https://www.nuget.org/packages/Microsoft.DotNet.Web.ProjectTemplates.6.0)       |
| ASP.NET Core 7.0 | [`Microsoft.DotNet.Web.ProjectTemplates.7.0`](https://www.nuget.org/packages/Microsoft.DotNet.Web.ProjectTemplates.7.0)       |

For example, the .NET 7 SDK includes templates for a console app targeting .NET 7. If you wanted to target .NET Core 3.1, you would need to install the 3.1 template package.

01. Try creating an app that targets .NET Core 3.1.

    ```dotnetcli
    dotnet new console --framework netcoreapp3.1
    ```

    If you see an error message, you need to install the templates.

01. Install the .NET Core 3.1 project templates.

    ```dotnetcli
    dotnet new install Microsoft.DotNet.Common.ProjectTemplates.3.1
    ```

01. Try creating the app a second time.

    ```dotnetcli
    dotnet new console --framework netcoreapp3.1
    ```

    And you should see a message indicating the project was created.

    > The template "Console Application" was created successfully.
    >
    > Processing post-creation actions...
    > Running 'dotnet restore' on path-to-project-file.csproj...
    >   Determining projects to restore...
    >   Restore completed in 1.05 sec for path-to-project-file.csproj.
    >
    > Restore succeeded.

## See also

- [Tutorial: Create an item template](../tutorials/cli-templates-create-item-template.md)
- [dotnet new](../tools/dotnet-new.md)
- [dotnet nuget add source](../tools/dotnet-nuget-add-source.md)
