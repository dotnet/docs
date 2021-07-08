---
title: dotnet workload command
description: The 'dotnet workload' command installs, updates, and lists optional workloads.
ms.date: 07/08/2021
---
# dotnet workload

**This article applies to:** ✔️ .NET 6 (preview) and later versions

## Name

`dotnet workload [command]` - Installs or updates or lists optional workloads.

## Synopsis

```dotnetcli
dotnet workload [command] [-h|--help]
```

## Description

The `dotnet workload` commands install or update or list optional workloads.

## Options

- **`-h|--help`**

  Prints out a description of how to use the command.

## `list` command

Lists available workloads.

### Synopsis

```dotnetcli
dotnet workload list [-v|--verbosity <LEVEL>]

dotnet workload list [-h|--help]
```

### Options

- **`-h|--help`**

  Prints out a description of how to use the command.
  
- **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`.

## `install` command

Installs a workload.

### Synopsis

```dotnetcli
dotnet workload install [--add-source <SOURCE>] [--configfile <FILE>]
    [--disable-parallel] [--download-to-cache <CACHE>] [--from-cache <CACHE>]
    [--ignore-failed-sources] [--include-previews] [--interactive]
    [--no-cache] [--sdk-version <VERSION>] [--skip-manifest-update]
    [-v|--verbosity <LEVEL>]

dotnet workload install -h|--help
```

### Arguments

- **`PACKAGE_ID`**

  The NuGet Package Id of the workload to install.

### Options

- **`--add-source <SOURCE>`**

  Add an additional NuGet package source to use during installation.

- **`--configfile <FILE>`**

  The NuGet configuration file to use.

- **`--disable-parallel`**

  Prevent restoring multiple projects in parallel.

- **`--download-to-cache <CACHE>`**

  Download packages needed to install a workload to a folder which can be used for offline installation.

- **`--from-cache <CACHE>`**

  Complete the operation from cache (offline).

- **`--ignore-failed-sources`**

  Treat package source failures as warnings.

- **`--include-previews`**

  Allow prerelease workload manifests.

- **`--interactive`**

  Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--no-cache`**

  Do not cache packages and http requests.

- **`--sdk-version <VERSION>`**

  The version of the SDK.

- **`--skip-manifest-update`**

  Skip updating the workload manifests.

- **`-v|--verbosity <LEVEL>`**

  Sets the MSBuild verbosity level. Allowed values are `q[uiet]`, `m[inimal]`, `n[ormal]`, `d[etailed]`, and `diag[nostic]`. The default is `minimal`.


- **`-h|--help`**

  Prints out a description of how to use the command.

- **`--in-root`**

  Places the projects in the root of the solution, rather than creating a [solution folder](/visualstudio/ide/solutions-and-projects-in-visual-studio#solution-folder). Can't be used with `-s|--solution-folder`. Available since .NET Core 3.0 SDK.

- **`-s|--solution-folder <PATH>`**

  The destination [solution folder](/visualstudio/ide/solutions-and-projects-in-visual-studio#solution-folder) path to add the projects to. Can't be used with `--in-root`. Available since .NET Core 3.0 SDK.

### `remove`

Removes a project or multiple projects from the solution file.

#### Synopsis

```dotnetcli
dotnet sln [<SOLUTION_FILE>] remove <PROJECT_PATH> [<PROJECT_PATH>...]
dotnet sln [<SOLUTION_FILE>] remove [-h|--help]
```

#### Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If is left unspecified, the command searches the current directory for one and fails if there are multiple solution files.

- **`PROJECT_PATH`**

  The path to the project or projects to add to the solution. Unix/Linux shell [globbing pattern](https://en.wikipedia.org/wiki/Glob_(programming)) expansions are processed correctly by the `dotnet sln` command.

#### Options

- **`-h|--help`**

  Prints out a description of how to use the command.

## Examples

- List the projects in a solution:

  ```dotnetcli
  dotnet sln todo.sln list
  ```

- Add a C# project to a solution:

  ```dotnetcli
  dotnet sln add todo-app/todo-app.csproj
  ```

- Remove a C# project from a solution:

  ```dotnetcli
  dotnet sln remove todo-app/todo-app.csproj
  ```

- Add multiple C# projects to the root of a solution:

  ```dotnetcli
  dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj --in-root
  ```

- Add multiple C# projects to a solution:

  ```dotnetcli
  dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj
  ```

- Remove multiple C# projects from a solution:

  ```dotnetcli
  dotnet sln todo.sln remove todo-app/todo-app.csproj back-end/back-end.csproj
  ```

- Add multiple C# projects to a solution using a globbing pattern (Unix/Linux only):

  ```dotnetcli
  dotnet sln todo.sln add **/*.csproj
  ```

- Add multiple C# projects to a solution using a globbing pattern (Windows PowerShell only):

  ```dotnetcli
  dotnet sln todo.sln add (ls -r **/*.csproj)
  ```

- Remove multiple C# projects from a solution using a globbing pattern (Unix/Linux only):

  ```dotnetcli
  dotnet sln todo.sln remove **/*.csproj
  ```

- Remove multiple C# projects from a solution using a globbing pattern (Windows PowerShell only):

  ```dotnetcli
  dotnet sln todo.sln remove (ls -r **/*.csproj)
  ```

- Create a solution, a console app, and two class libraries. Add the projects to the solution, and use the `--solution-folder` option of `dotnet sln` to organize the class libraries into a solution folder.

  ```dotnetcli
  dotnet new sln -n mysolution
  dotnet new console -o myapp
  dotnet new classlib -o mylib1
  dotnet new classlib -o mylib2
  dotnet sln mysolution.sln add myapp\myapp.csproj
  dotnet sln mysolution.sln add mylib1\mylib1.csproj --solution-folder mylibs
  dotnet sln mysolution.sln add mylib2\mylib2.csproj --solution-folder mylibs
  ```

  The following screenshot shows the result in Visual Studio 2019 **Solution Explorer**:

  :::image type="content" source="media/dotnet-sln/dotnet-sln-solution-folder.png" alt-text="Solution Explorer showing class library projects grouped into a solution folder.":::

## See also

- [dotnet/sdk GitHub repo](https://github.com/dotnet/sdk) (.NET CLI source)
