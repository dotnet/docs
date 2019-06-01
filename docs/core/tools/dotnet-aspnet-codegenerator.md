---
title: dotnet aspnet-codegenerator command
description: The dotnet aspnet-codegenerator command scaffolds ASP.NET Core projects
ms.date: 06/15/2019
---
# dotnet aspnet-codegenerator

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-2.2&tabs=visual-studio-code#scaffold-the-movie-model

[!INCLUDE [topic-appliesto-net-core-21plus.md](../../../includes/topic-appliesto-net-core-21plus.md)]

## Name

`dotnet aspnet-codegenerator` - Runs the ASP.NET Core scaffolding engine.

## Installing aspnet-codegenerator

`aspnet-codegenerator` is a [global tool](global-tools.md) that must be installed. The following command installs the lastest stable version of the `aspnet-codegenerator` tool:

```console
dotnet tool install --g dotnet-aspnet-codegenerator
```

The following command updates `aspnet-codegenerator` to the latest stable version available from the installed .NET Core SDKs:

```console
dotnet tool update -g aspnet-codegenerator
```

## Synopsis

```
dotnet aspnet-codegenerator [arguments] [-p|--project] [-n|--nuget-package-dir] [-c|--configuration] [-tfm|--target-framework] [-b|--build-base-path] [--no-build] 
dotnet aspnet-codegenerator [-h|--help]
```

## Description

The `dotnet aspnet-codegenerator ` global command runs the ASP.NET Core code generator and scaffolding engine.

## Arguments

`generator`

The code generator to run. The following generators are available:

| Generator | Operation |
| ----------------- | ------------ | 
| area      | Generates an [Area](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/areas?view=aspnetcore-2.2) |
  controller| [Scaffolds a controller](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-2.2&tabs=visual-studio-code#scaffold-the-movie-model) |
  identity  | [Scaffolds Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-2.2&tabs=netcore-cli) |
  razorpage | [Scaffolds Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-2.2&tabs=visual-studio-code) |
  view      | Generates a [view](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/overview?view=aspnetcore-2.2) |

## Options

<!-- dotnet build to dotnet help use **bold** on options, most don't -->

**`-n|--nuget-package-dir`**

Specifies the NuGet package directory.

**`-c|--configuration {Debug|Release}`**

  Defines the build configuration. The default value is `Debug`.

**`-tfm|--target-framework`**

Target [Framework](../../standard/frameworks.md) to use. For example, `net46`.

<!-- REVIEW: Is this specified on the command line or in the project file? -->

**`-b|--build-base-path`**

The build base path.

**`-h|--help`**

Prints out a short help for the command.

**`--no-build`**

Doesn't build the project before running. It also implicit sets the `--no-restore` flag.

**`-p|--project <PATH>`**

Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

## Generator options

The following sections detail the options available for the supported generators:

* Area
* Controller
* Identity  
* Razorpage
* View

### Controller options

The following table lists options for  `aspnet-codegenerator` `controller` and `razorpage`:

[!INCLUDE [aspnet-codegenerator-args-md.md](../../../includes/aspnet-codegenerator-args-md.md)]

The following table lists options unique to  `aspnet-codegenerator controller`:

| Option               | Description|
| ----------------- | ------------ |
| --controllerName or -name | Name of the controller. |
| --useAsyncActions or -async | Generate async controller actions. |
| --noViews or -nv | Generate [CRUD](https://wikipedia.org/wiki/Create,_read,_update_and_delete) views. |
| --restWithNoViews or -api  | Generate a Controller with REST style API. `noViews` is assumed and any view related options are ignored. |
  | --readWriteActions or -actions | Generate controller with read/write actions without a model. |

Use the `-h` switch for help on the `aspnet-codegenerator controller` command:

```console
dotnet aspnet-codegenerator controller -h
```

See [Scaffold the movie model](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-2.2&tabs=visual-studio-code#scaffold-the-movie-model) for an example of using `dotnet aspnet-codegenerator controller`.

### Razorpage options

#### Razorpage generator arguments

Razor Pages can be individually scaffolded by specifying the name of the new page and the template to use. The supported templates are:

* `Empty`
* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

For example, the following command uses the Edit template to generate *MyEdit.cshtml* and *MyEdit.cshtml.cs*:

```console
dotnet aspnet-codegenerator razorpage MyEdit Edit -m Movie -dc RazorPagesMovieContext -outDir Pages\Movies
```

Typically, the template and generated file name is not specified, and the following templates are created:

* `Create`
* `Edit`
* `Delete`
* `Details`
* `List`

The following table lists options for  `aspnet-codegenerator` `razorpage` and `controller`:

[!INCLUDE [aspnet-codegenerator-args-md.md](../../../includes/aspnet-codegenerator-args-md.md)]

The following table lists options unique to  `aspnet-codegenerator razorpage`:

| Option               | Description|
| ----------------- | ------------ |
|   --namespaceName or -namespace | The name of the namespace to use for the generated PageModel |
| --partialView or -partial | Generate a partial view. Layout options -l and -udl are ignored if this is specified. |
| --noPageModel or -npm | Switch to not generate a PageModel class for Empty template |

Use the `-h` switch for help on the `aspnet-codegenerator razorpage` command:

```console
dotnet aspnet-codegenerator razorpage -h
```

See [Scaffold the movie model](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-2.2&tabs=visual-studio-code#scaffold-the-movie-model) for an example of using `dotnet aspnet-codegenerator razorpage`.