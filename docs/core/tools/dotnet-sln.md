---
title: dotnet sln command
description: The dotnet-sln command provides a convenient option to add, remove, and list projects in a solution file.
ms.date: 05/18/2022
---
# dotnet sln

**This article applies to:** ✔️ .NET Core 3.1 SDK and later versions

## Name

`dotnet sln` - Lists or modifies the projects in a .NET solution file.

## Synopsis

```dotnetcli
dotnet sln [<SOLUTION_FILE>] [command]

dotnet sln [command] -h|--help
```

## Description

The `dotnet sln` command provides a convenient way to list and modify projects in a solution file.

### Create a solution file

To use the `dotnet sln` command, the solution file must already exist. If you need to create one, use the [dotnet new](dotnet-new.md) command with the `sln` template name.

The following example creates a *.sln* file in the current folder, with the same name as the folder:

```dotnetcli
dotnet new sln
```

The following example creates a *.sln* file in the current folder, with the specified file name:

```dotnetcli
dotnet new sln --name MySolution
```

The following example creates a *.sln* file in the specified folder, with the same name as the folder:

```dotnetcli
dotnet new sln --output MySolution
```

## Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If this argument is omitted, the command searches the current directory for one. If it finds no solution file or multiple solution files, the command fails.

## Options

[!INCLUDE [help](../../../includes/cli-help.md)]

## Commands

### `list`

Lists all projects in a solution file.

#### Synopsis

```dotnetcli
dotnet sln list [-h|--help]
```

#### Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If this argument is omitted, the command searches the current directory for one. If it finds no solution file or multiple solution files, the command fails.

#### Options

[!INCLUDE [help](../../../includes/cli-help.md)]

### `add`

Adds one or more projects to the solution file.

#### Synopsis

```dotnetcli
dotnet sln [<SOLUTION_FILE>] add [--in-root] [-s|--solution-folder <PATH>] <PROJECT_PATH> [<PROJECT_PATH>...]
dotnet sln add [-h|--help]
```

#### Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If it is unspecified, the command searches the current directory for one and fails if there are multiple solution files.

- **`PROJECT_PATH`**

  The path to the project or projects to add to the solution. Unix/Linux shell [globbing pattern](https://en.wikipedia.org/wiki/Glob_(programming)) expansions are processed correctly by the `dotnet sln` command.

  If `PROJECT_PATH` includes folders that contain the project folder, that portion of the path is used to create [solution folders](/visualstudio/ide/solutions-and-projects-in-visual-studio#solution-folder). For example, the following commands create a solution with `myapp` in solution folder `folder1/folder2`:

  ```dotnetcli
  dotnet new sln
  dotnet new console --output folder1/folder2/myapp
  dotnet sln add folder1/folder2/myapp
  ```

  You can override this default behavior by using the `--in-root` or the `-s|--solution-folder <PATH>` option.

#### Options

[!INCLUDE [help](../../../includes/cli-help.md)]

- **`--in-root`**

  Places the projects in the root of the solution, rather than creating a [solution folder](/visualstudio/ide/solutions-and-projects-in-visual-studio#solution-folder). Can't be used with `-s|--solution-folder`.

- **`-s|--solution-folder <PATH>`**

  The destination [solution folder](/visualstudio/ide/solutions-and-projects-in-visual-studio#solution-folder) path to add the projects to. Can't be used with `--in-root`.

### `remove`

Removes one or more projects from the solution file.

#### Synopsis

```dotnetcli
dotnet sln [<SOLUTION_FILE>] remove <PROJECT_PATH> [<PROJECT_PATH>...]
dotnet sln [<SOLUTION_FILE>] remove [-h|--help]
```

#### Description
The `dotnet sln remove` command removes one or more projects from a `.sln` (solution) file.  
This command updates the solution file but **does not delete** the project files from disk.

#### Arguments

- **`SOLUTION_FILE`**  
  The solution file to modify. If unspecified, the command searches for a `.sln` file in the current directory.  
  If multiple solution files exist, an error is returned.

- **`PROJECT_PATH`**  
  One or more paths to the project files (`.csproj` or `.vbproj`) that should be removed from the solution.  
  Unix/Linux shell [globbing patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported.

#### Options

[!INCLUDE [help](../../../includes/cli-help.md)]

---

### **Examples**

#### **Remove a single project from a solution**
```dotnetcli
dotnet sln todo.sln remove todo-app/todo-app.csproj
```
**Expected Output:**
```
Removed project(s) from solution file.
```

#### **Remove multiple projects from a solution**
```dotnetcli
dotnet sln todo.sln remove todo-app/todo-app.csproj back-end/back-end.csproj
```
**Expected Output:**
```
Removed project(s) from solution file.
```

#### **Remove a project when a solution file is automatically detected**
```dotnetcli
dotnet sln remove todo-app/todo-app.csproj
```
**Expected Output:**
```
Removed project(s) from solution file.
```

#### **Remove multiple projects using a globbing pattern (Unix/Linux only)**
```dotnetcli
dotnet sln todo.sln remove **/*.csproj
```

#### **Remove multiple projects using a globbing pattern (Windows PowerShell only)**
```dotnetcli
dotnet sln todo.sln remove (ls -r **/*.csproj)
```

---

### **Notes**
- If the solution file **does not exist**, the command will fail with an error.  
- If a specified project is **not part of the solution**, the command will display a message but continue execution.  
- **This command does not delete** the project files from disk; it only removes them from the solution file.  
- If a solution file is not explicitly provided, `dotnet sln remove` will attempt to find one in the current directory.  

---

### **See Also**
- [`dotnet sln`](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-sln)  
- [`dotnet sln add`](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-sln#add)  
- [Working with .NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/)  
```


- [dotnet/sdk GitHub repo](https://github.com/dotnet/sdk) (.NET CLI source)
