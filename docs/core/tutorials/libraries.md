---
title: Develop libraries with the .NET CLI
description: Learn how to create .NET libraries using the .NET CLI. You'll create a library that supports multiple frameworks.
author: cartermp
ms.topic: how-to
ms.date: 11/23/2021
---
# Develop libraries with the .NET CLI

This article covers how to write libraries for .NET using the .NET CLI. The CLI provides an efficient and low-level experience that works across any supported OS. You can still build libraries with Visual Studio, and if that is your preferred experience [refer to the Visual Studio guide](library-with-visual-studio.md).

## Prerequisites

You need the [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

For the sections of this document dealing with .NET Framework versions, you need the [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) installed on a Windows machine.

Additionally, if you wish to support older .NET Framework targets, you need to install targeting packs or developer packs from the [.NET Framework downloads page](https://dotnet.microsoft.com/download/dotnet-framework). Refer to this table:

| .NET Framework version | What to download                                       |
| ---------------------- | ------------------------------------------------------ |
| 4.6.1                  | .NET Framework 4.6.1 Targeting Pack                    |
| 4.6                    | .NET Framework 4.6 Targeting Pack                      |
| 4.5.2                  | .NET Framework 4.5.2 Developer Pack                    |
| 4.5.1                  | .NET Framework 4.5.1 Developer Pack                    |
| 4.5                    | Windows Software Development Kit for Windows 8         |
| 4.0                    | Windows SDK for Windows 7 and .NET Framework 4         |
| 2.0, 3.0, and 3.5      | .NET Framework 3.5 SP1 Runtime (or Windows 8+ version) |

## How to target .NET 5+ or .NET Standard

You control your project's target framework by adding it to your project file (*.csproj* or *.fsproj*). For guidance on how to choose between targeting .NET 5+ or .NET Standard see [.NET 5+ and .NET Standard](../../standard/net-standard.md#net-5-and-net-standard).

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>
</Project>
```

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
  </PropertyGroup>
</Project>
```

If you want to target .NET Framework versions 4.0 or below, or you wish to use an API available in .NET Framework but not in .NET Standard (for example, `System.Drawing`), read the following sections and learn how to multitarget.

## How to target .NET Framework

> [!NOTE]
> These instructions assume you have .NET Framework installed on your machine. Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

Keep in mind that some of the .NET Framework versions used here are no longer supported. Refer to the [.NET Framework Support Lifecycle Policy FAQ](/lifecycle/faq/dotnet-framework) about unsupported versions.

If you want to reach the maximum number of developers and projects, use .NET Framework 4.0 as your baseline target. To target .NET Framework, begin by using the correct Target Framework Moniker (TFM) that corresponds to the .NET Framework version you wish to support.

| .NET Framework version | TFM      |
| ---------------------- | -------- |
| .NET Framework 2.0     | `net20`  |
| .NET Framework 3.0     | `net30`  |
| .NET Framework 3.5     | `net35`  |
| .NET Framework 4.0     | `net40`  |
| .NET Framework 4.5     | `net45`  |
| .NET Framework 4.5.1   | `net451` |
| .NET Framework 4.5.2   | `net452` |
| .NET Framework 4.6     | `net46`  |
| .NET Framework 4.6.1   | `net461` |
| .NET Framework 4.6.2   | `net462` |
| .NET Framework 4.7     | `net47`  |
| .NET Framework 4.8     | `net48`  |

You then insert this TFM into the `TargetFramework` section of your project file. For example, here's how you would write a library that targets .NET Framework 4.0:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net40</TargetFramework>
  </PropertyGroup>
</Project>
```

And that's it! Although this compiled only for .NET Framework 4, you can use the library on newer versions of .NET Framework.

## How to multitarget

> [!NOTE]
> The following instructions assume you have the .NET Framework installed on your machine. Refer to the [Prerequisites](#prerequisites) section to learn which dependencies you need to install and where to download them from.

You may need to target older versions of the .NET Framework when your project supports both the .NET Framework and .NET. In this scenario, if you want to use newer APIs and language constructs for the newer targets, use `#if` directives in your code. You also might need to add different packages and dependencies for each platform you're targeting to include the different APIs needed for each case.

For example, let's say you have a library that performs networking operations over HTTP. For .NET Standard and the .NET Framework versions 4.5 or higher, you can use the `HttpClient` class from the `System.Net.Http` namespace. However, earlier versions of the .NET Framework don't have the `HttpClient` class, so you could use the `WebClient` class from the `System.Net` namespace for those instead.

Your project file could look like this:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net40;net45</TargetFrameworks>
  </PropertyGroup>

  <!-- Need to conditionally bring in references for the .NET Framework 4.0 target -->
  <ItemGroup Condition="'$(TargetFramework)' == 'net40'">
    <Reference Include="System.Net" />
  </ItemGroup>

  <!-- Need to conditionally bring in references for the .NET Framework 4.5 target -->
  <ItemGroup Condition="'$(TargetFramework)' == 'net45'">
    <Reference Include="System.Net.Http" />
    <Reference Include="System.Threading.Tasks" />
  </ItemGroup>
</Project>
```

You'll notice three major changes here:

1. The `TargetFramework` node has been replaced by `TargetFrameworks`, and three TFMs are expressed inside.
1. There is an `<ItemGroup>` node for the `net40` target pulling in one .NET Framework reference.
1. There is an `<ItemGroup>` node for the `net45` target pulling in two .NET Framework references.

The build system is aware of the following preprocessor symbols used in `#if` directives:

[!INCLUDE [Preprocessor symbols](../../../includes/preprocessor-symbols.md)]

Here is an example making use of conditional compilation per-target:

```csharp
using System;
using System.Text.RegularExpressions;
#if NET40
// This only compiles for the .NET Framework 4 targets
using System.Net;
#else
 // This compiles for all other targets
using System.Net.Http;
using System.Threading.Tasks;
#endif

namespace MultitargetLib
{
    public class Library
    {
#if NET40
        private readonly WebClient _client = new WebClient();
        private readonly object _locker = new object();
#else
        private readonly HttpClient _client = new HttpClient();
#endif

#if NET40
        // .NET Framework 4.0 does not have async/await
        public string GetDotNetCount()
        {
            string url = "https://www.dotnetfoundation.org/";

            var uri = new Uri(url);

            string result = "";

            // Lock here to provide thread-safety.
            lock(_locker)
            {
                result = _client.DownloadString(uri);
            }

            int dotNetCount = Regex.Matches(result, ".NET").Count;

            return $"Dotnet Foundation mentions .NET {dotNetCount} times!";
        }
#else
        // .NET Framework 4.5+ can use async/await!
        public async Task<string> GetDotNetCountAsync()
        {
            string url = "https://www.dotnetfoundation.org/";

            // HttpClient is thread-safe, so no need to explicitly lock here
            var result = await _client.GetStringAsync(url);

            int dotNetCount = Regex.Matches(result, ".NET").Count;

            return $"dotnetfoundation.org mentions .NET {dotNetCount} times in its HTML!";
        }
#endif
    }
}
```

If you build this project with `dotnet build`, you'll notice three directories under the `bin/` folder:

```
net40/
net45/
netstandard2.0/
```

Each of these contains the `.dll` files for each target.

## How to test libraries on .NET

It's important to be able to test across platforms. You can use either [xUnit](https://xunit.net/) or MSTest out of the box. Both are perfectly suitable for unit testing your library on .NET. How you set up your solution with test projects will depend on the [structure of your solution](#structuring-a-solution). The following example assumes that the test and source directories live in the same top-level directory.

> [!NOTE]
> This uses some [.NET CLI](../tools/index.md) commands. See [dotnet new](../tools/dotnet-new.md) and [dotnet sln](../tools/dotnet-sln.md) for more information.

1. Set up your solution. You can do so with the following commands:

   ```dotnetcli
   mkdir SolutionWithSrcAndTest
   cd SolutionWithSrcAndTest
   dotnet new sln
   dotnet new classlib -o MyProject
   dotnet new xunit -o MyProject.Test
   dotnet sln add MyProject/MyProject.csproj
   dotnet sln add MyProject.Test/MyProject.Test.csproj
   ```

   This will create projects and link them together in a solution. Your directory for `SolutionWithSrcAndTest` should look like this:

   ```
   /SolutionWithSrcAndTest
   |__SolutionWithSrcAndTest.sln
   |__MyProject/
   |__MyProject.Test/
   ```

1. Navigate to the test project's directory and add a reference to `MyProject.Test` from `MyProject`.

   ```dotnetcli
   cd MyProject.Test
   dotnet add reference ../MyProject/MyProject.csproj
   ```

1. Restore packages and build projects:

   ```dotnetcli
   dotnet restore
   dotnet build
   ```

1. Verify that xUnit runs by executing the `dotnet test` command. If you chose to use MSTest, then the MSTest console runner should run instead.

And that's it! You can now test your library across all platforms using command-line tools. To continue testing now that you have everything set up, testing your library is very simple:

1. Make changes to your library.
1. Run tests from the command line, in your test directory, with `dotnet test` command.

Your code will be automatically rebuilt when you invoke `dotnet test` command.

## How to use multiple projects

A common need for larger libraries is to place functionality in different projects.

Imagine you want to build a library that could be consumed in idiomatic C# and F#. That would mean that consumers of your library consume it in ways that are natural to C# or F#. For example, in C# you might consume the library like this:

```csharp
using AwesomeLibrary.CSharp;

public Task DoThings(Data data)
{
    var convertResult = await AwesomeLibrary.ConvertAsync(data);
    var result = AwesomeLibrary.Process(convertResult);
    // do something with result
}
```

In F#, it might look like this:

```fsharp
open AwesomeLibrary.FSharp

let doWork data = async {
    let! result = AwesomeLibrary.AsyncConvert data // Uses an F# async function rather than C# async method
    // do something with result
}
```

Consumption scenarios like this mean that the APIs being accessed have to have a different structure for C# and F#.  A common approach to accomplishing this is to factor all of the logic of a library into a core project, with C# and F# projects defining the API layers that call into that core project.  The rest of the section will use the following names:

* **AwesomeLibrary.Core** - A core project that contains all logic for the library
* **AwesomeLibrary.CSharp** - A project with public APIs intended for consumption in C#
* **AwesomeLibrary.FSharp** - A project with public APIs intended for consumption in F#

You can run the following commands in your terminal to produce the same structure as this guide:

```dotnetcli
mkdir AwesomeLibrary && cd AwesomeLibrary
dotnet new sln
mkdir AwesomeLibrary.Core && cd AwesomeLibrary.Core && dotnet new classlib
cd ..
mkdir AwesomeLibrary.CSharp && cd AwesomeLibrary.CSharp && dotnet new classlib
cd ..
mkdir AwesomeLibrary.FSharp && cd AwesomeLibrary.FSharp && dotnet new classlib -lang "F#"
cd ..
dotnet sln add AwesomeLibrary.Core/AwesomeLibrary.Core.csproj
dotnet sln add AwesomeLibrary.CSharp/AwesomeLibrary.CSharp.csproj
dotnet sln add AwesomeLibrary.FSharp/AwesomeLibrary.FSharp.fsproj
```

This will add the three projects above and a solution file that links them together. Creating the solution file and linking projects will allow you to restore and build projects from a top level.

### Project-to-project referencing

The best way to reference a project is to use the .NET CLI to add a project reference. From the **AwesomeLibrary.CSharp** and **AwesomeLibrary.FSharp** project directories, you can run the following command:

```dotnetcli
dotnet add reference ../AwesomeLibrary.Core/AwesomeLibrary.Core.csproj
```

The project files for both **AwesomeLibrary.CSharp** and **AwesomeLibrary.FSharp** will now reference **AwesomeLibrary.Core** as a `ProjectReference` target.  You can verify this by inspecting the project files and seeing the following in them:

```xml
<ItemGroup>
  <ProjectReference Include="..\AwesomeLibrary.Core\AwesomeLibrary.Core.csproj" />
</ItemGroup>
```

You can add this section to each project file manually if you prefer not to use the .NET CLI.

### Structuring a solution

Another important aspect of multi-project solutions is establishing a good overall project structure. You can organize code however you like, and as long as you link each project to your solution file with `dotnet sln add`, you will be able to run `dotnet restore` and `dotnet build` at the solution level.
