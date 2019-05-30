---
title: dotnet aspnet-codegenerator command
description: The dotnet aspnet-codegenerator command scaffolds ASP.NET Core projects
ms.date: 06/15/2019
---
# dotnet aspnet-codegenerator

https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-2.2&tabs=visual-studio-code#scaffold-the-movie-model

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

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

# [.NET Core 2.1](#tab/netcore21)

```
dotnet aspnet-codegenerator [arguments] [-p|--project] [-n|--nuget-package-dir] [-c|--configuration] [-tfm|--target-framework] [-b|--build-base-path] [--no-build] 
dotnet aspnet-codegenerator [-h|--help]
```

# [.NET Core 2.2](#tab/netcore22)

```
dotnet aspnet-codegenerator [arguments] [-p|--project] [-n|--nuget-package-dir] [-c|--configuration] [-tfm|--target-framework] [-b|--build-base-path] [--no-build] 
dotnet aspnet-codegenerator [-h|--help]
```

---

## Description

The `dotnet aspnet-codegenerator ` global command runs the ASP.NET Core code generator and scaffolding engine.

## Arguments

`generator`

The code generator to run. The following generators are available:

| Generator | Operation |
| ----------------- | ------------ | 
| area      | Generates an MVC Area |
  controller| [Scaffolds a controller](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-2.2&tabs=visual-studio-code#scaffold-the-movie-model) |
  identity  | [Scaffolds Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-2.2&tabs=netcore-cli) |
  razorpage | [Scaffolds Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-2.2&tabs=visual-studio-code) |
  view      | Generates a view |


## Options

# [.NET Core 2.1](#tab/netcore21)

dotnet aspnet-codegenerator [arguments] [-p|--project] [-n|--nuget-package-dir] [-c|--configuration] [-tfm|--target-framework] [-b|--build-base-path] [--no-build] 

`-h|--help`

Prints out a short help for the command.

`--no-build`

Doesn't build the project before running. It also implicit sets the `--no-restore` flag.

`-p|--project <PATH>`

Specifies the path of the project file to run (folder name or full path). If not specified, it defaults to the current directory.

# [.NET Core 2.0](#tab/netcore22)

---

## Examples
