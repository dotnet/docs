---
title: Developing Libraries with Cross Platform Tools
description: Developing Libraries with Cross Platform Tools
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 9f6e8679-bd7e-4317-b3f9-7255a260d9cf
---

# Developing Libraries with Cross Platform Tools

> [!WARNING]
> This topic hasn't been updated to the latest version of the tooling yet.

This article covers how to write libraries for .NET using cross-platform CLI tools.  The CLI provides an efficient and low-level experience that works across any supported OS.  You can still build libraries with Visual Studio, and if that is your preferred experience [refer to the Visual Studio guide](libraries-with-vs.md).

## Prerequisites

You need [the .NET Core SDK and CLI](https://www.microsoft.com/net/core) installed on your machine.

For the sections of this document dealing with .NET Framework versions or Portable Class Libraries (PCL), you need the [.NET Framework](http://getdotnet.azurewebsites.net/) installed on a Windows machine.  

Additionally, if you wish to support older .NET Framework targets, you need to install targeting/developer packs for older framework versions from the [.NET target platforms page](http://getdotnet.azurewebsites.net/target-dotnet-platforms.html).  Refer to this table:

| .NET Framework Version | What to download |
| ---------------------- | ----------------- |
| 4.6.1 | .NET Framework 4.6.1 Targeting Pack |
| 4.6 | .NET Framework 4.6 Targeting Pack |
| 4.5.2 | .NET Framework 4.5.2 Developer Pack |
| 4.5.1 | .NET Framework 4.5.1 Developer Pack |
| 4.5 | Windows Software Development Kit for Windows 8 |
| 4.0 | Windows SDK for Windows 7 and .NET Framework 4 |
| 2.0, 3.0, and 3.5 | .NET Framework 3.5 SP1 Runtime (or Windows 8+ version) |

## How to target the .NET Standard

If you're not quite familiar with the .NET Standard, refer to [the .NET Standard Library](../../standard/library.md) to learn more.

In that article, there is a table which maps .NET Standard versions to various implementations:

| Platform Name | Alias |  |  |  |  |  | | |
| :---------- | :--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |
|.NET Standard | netstandard | 1.0 | 1.1 | 1.2 | 1.3 | 1.4 | 1.5 | 1.6 |
|.NET Core|netcoreapp|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|1.0|
|.NET Framework|net|&rarr;|4.5|4.5.1|4.6|4.6.1|4.6.2|4.6.3|
|Mono/Xamarin Platforms||&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|*|
|Universal Windows Platform|uap|&rarr;|&rarr;|&rarr;|&rarr;|10.0|||
|Windows|win|&rarr;|8.0|8.1|||||
|Windows Phone|wpa|&rarr;|&rarr;|8.1|||||
|Windows Phone Silverlight|wp|8.0|||||||

Here's what this table means for the purposes of creating a library:

The version of the .NET Platform Standard you pick will be a tradeoff between access to the newest APIs and ability to target more .NET platforms and Framework versions.  You control the range of targetable platforms and versions by picking a version of `netstandardX.X` (Where `X.X` is a version number) and adding it to your `project.json` file.

Additionally, the corresponding [NuGet package to depend on](https://www.nuget.org/packages/NETStandard.Library/) is `NETStandard.Library` version `1.6.0`.  Although there's nothing preventing you from depending on `Microsoft.NETCore.App` like with console apps, it's generally not recommended.  If you need APIs from a package not specified in `NETStandard.Library`, you can always specify that package in addition to `NETStandard.Library` in the `dependencies` section of your `project.json` file.

You have three primary options when targeting the .NET Standard, depending on your needs.

1. You can use the latest version of the .NET Standard - `netstandard1.6` - which is for when you want access to the most APIs and don't mind if you have less reach across implementations.
2. You can use a lower version of the .NET Standard to target earlier .NET implementations. The cost here is not having access to some of the latest APIs.
    
    For example, if you wanted to have guaranteed compatibility with .NET Framework 4.6 and higher, you would pick `netstandard1.3`:

    ```json
    {
        "dependencies":{
            "NETStandard.Library":"1.6.0"
        },
        "frameworks":{
            "netstandard1.3":{}
        }
    }
    ```
    
    .NET Standard versions are backward compatible. That means that `netstandard1.0` libraries run on `netstandard1.1` platforms and higher.  However, there is no forward compatibility - lower .NET Standard platforms cannot reference higher ones.  This means that `netstandard1.0` libraries cannot reference libraries targeting `netstandard1.1` or higher.  Select the Standard version that has the right mix of APIs and platform support for your needs.
    
3. If you want to target the .NET Framework versions 4.0 or below, or you wish to use an API available in the .NET Framework but not in the .NET Standard (for example, `System.Drawing`), read the following sections and learn how to multitarget.

## How to target the .NET Framework

> [!NOTE]
> These instructions assume you have the .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

Keep in mind that some of the .NET Framework versions used here are no longer in support.  Refer to the [.NET Framework Support Lifecycle Policy FAQ](https://support.microsoft.com/gp/framework_faq/en-us) about unsupported versions.

If you want to reach the maximum number of developers and projects, use the .NET Framework 4 as your baseline target. To target the .NET Framework, you will need to begin by using the correct Target Framework Moniker (TFM) that corresponds to the .NET Framework version you wish to support.

```
.NET Framework 2.0   --> net20
.NET Framework 3.0   --> net30
.NET Framework 3.5   --> net35
.NET Framework 4.0   --> net40
.NET Framework 4.5   --> net45
.NET Framework 4.5.1 --> net451
.NET Framework 4.5.2 --> net452
.NET Framework 4.6   --> net46
.NET Framework 4.6.1 --> net461
.NET Framework 4.6.2 --> net462
.NET Framework 4.6.3 --> net463
```

For example, here's how you would write a library which targets the .NET Framework 4:

```json
{
    "frameworks":{
        "net40":{}
    }
}
```

And that's it!  Although this compiled only for the .NET Framework 4, you can use the library on newer versions of the .NET Framework.

## How to target a Portable Class Library (PCL)

> [!NOTE]
> These instructions assume you have the .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

Targeting a PCL profile is a bit trickier than targeting .NET Standard or the .NET Framework.  For starters, [reference this list of PCL profiles](http://embed.plnkr.co/03ck2dCtnJogBKHJ9EjY/preview) to find the NuGet target which corresponds to the PCL profile you are targeting.

Then, you need to do the following:

1. Create a new entry under `frameworks` in your `project.json`, named `.NETPortable,Version=v{version},Profile=Profile{profile}`, where `{version}` and `{profile}` correspond to a PCL version number and Profile number, respectively.
2. In this new entry, list every single assembly used for that target under a `frameworkAssemblies` entry.  This includes `mscorlib`, `System`, and `System.Core`.
3. If you are multitargeting (see the next section), you must explicitly list dependencies for each target under their target entries.  You won't be able to use a global `dependencies` entry anymore.

The following is an example targeting PCL Profile 328. Profile 328 supports: .NET Standard 1.4, .NET Framework 4, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8.1, and Silverlight 5.

```json
{
    "frameworks":{
        ".NETPortable,Version=v4.0,Profile=Profile328":{
            "frameworkAssemblies":{
                "mscorlib":"",
                "System":"",
                "System.Core":""
            }
        }
    }
}
```

When you build a project that includes PCL Profile 328 as a framework in the *project.json* file, it will have this subfolder in the */bin/debug* folder:

```
portable-net40+sl50+netcore45+wpa81+wp8/
```

This folder contains the `.dll` files necessary to run your library.

## How to Multitarget

> [!NOTE]
> The following instructions assume you have the .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) section to learn which dependencies you need to install and where to download them from.

You may need to target older versions of the .NET Framework when your project supports both the .NET Framework and .NET Core. In this scenario, if you want to use newer APIs and language constructs for the newer targets, use `#if` directives in your code. You also might need to add different packages and dependencies in your `project.json file` for each platform you're targeting to include the different APIs needed for each case.

For example, let's say you have a library that performs networking operations over HTTP. For .NET Standard and the .NET Framework versions 4.5 or higher, you can use the `HttpClient` class from the `System.Net.Http` namespace. However, earlier versions of the .NET Framework don't have the `HttpClient` class, so you could use the `WebClient` class from the `System.Net` namespace for those instead.

So, the `project.json` file could look like this:

```json
{
    "frameworks":{
        "net40":{
            "frameworkAssemblies": {
                "System.Net":"",
                "System.Text.RegularExpressions":""
            }
        },
        "net452":{
            "frameworkAssemblies":{
                "System.Net":"",
                "System.Net.Http":"",
                "System.Text.RegularExpressions":"",
                "System.Threading.Tasks":""
            }
        },
        "netstandard1.6":{
            "dependencies": {
                "NETStandard.Library":"1.6.0",
            }
        }
    }
}
```

Note that the .NET Framework assemblies need to be referenced explicitly in the `net40` and `net452` target, and NuGet references are also explicitly listed in the `netstandard1.6` target.  This is required in multitargeting scenarios.

Next, the `using` statements in your source file can be adjusted like this:

```csharp
#if NET40
// This only compiles for the .NET Framework 4 targets
using System.Net;
#else
// This compiles for all other targets
using System.Net.Http;
using System.Threading.Tasks;
#endif
```

The build system is aware of the following preprocessor symbols used in `#if` directives:

```
.NET Framework 2.0   --> NET20
.NET Framework 3.5   --> NET35
.NET Framework 4.0   --> NET40
.NET Framework 4.5   --> NET45
.NET Framework 4.5.1 --> NET451
.NET Framework 4.5.2 --> NET452
.NET Framework 4.6   --> NET46
.NET Framework 4.6.1 --> NET461
.NET Framework 4.6.2 --> NET462
.NET Standard 1.0    --> NETSTANDARD1_0
.NET Standard 1.1    --> NETSTANDARD1_1
.NET Standard 1.2    --> NETSTANDARD1_2
.NET Standard 1.3    --> NETSTANDARD1_3
.NET Standard 1.4    --> NETSTANDARD1_4
.NET Standard 1.5    --> NETSTANDARD1_5
.NET Standard 1.6    --> NETSTANDARD1_6
```

And in the middle of the source, you can use `#if` directives to use those libraries conditionally. For example:

```csharp
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
            string url = "http://www.dotnetfoundation.org/";
          
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
        // .NET 4.5+ can use async/await!
        public async Task<string> GetDotNetCountAsync()
        {
            string url = "http://www.dotnetfoundation.org/";
            
            // HttpClient is thread-safe, so no need to explicitly lock here
            var result = await _client.GetStringAsync(url);
            
            int dotNetCount = Regex.Matches(result, ".NET").Count;
            
            return $"dotnetfoundation.orgmentions .NET {dotNetCount} times in its HTML!";
        }
#endif
    }
```

When you build a project that includes `net40`, `net45`, and `netstandard1.6` as frameworks in the *project.json* file, it will have these subfolders in the */bin/debug* folder:

```
net40/
net45/
netstandard1.6/
```

### But What about Multitargeting with Portable Class Libraries?

If you want to cross-compile with a PCL target, you must add a build definition in your `project.json` file under `buildOptions` in your PCL target.  You can then use `#if` directives in the source which use the build definition as a preprocessor symbol.

For example, if you want to target [PCL profile 328](http://embed.plnkr.co/03ck2dCtnJogBKHJ9EjY/preview) (The .NET Framework 4, Windows 8, Windows Phone Silverlight 8, Windows Phone 8.1, Silverlight 5), you could to refer to it to as "PORTABLE328" when cross-compiling.  Simply add it to the `project.json` file as a `buildOptions` attribute:

```json
{
    "frameworks":{
        "netstandard1.6":{
           "dependencies":{
                "NETStandard.Library":"1.6.0",
            }
        },
        ".NETPortable,Version=v4.0,Profile=Profile328":{
            "buildOptions": {
                "define": [ "PORTABLE328" ]
            },
            "frameworkAssemblies":{
                "mscorlib":"",
                "System":"",
                "System.Core":"",
                "System.Net"
            }
        }
    }
}

```

Now you can conditionally compile against that target:

```csharp
#if !PORTABLE328
using System.Net.Http;
using System.Threading.Tasks;
// Potentially other namespaces which aren't compatible with Profile 328
#endif
```

Because `PORTABLE328` is now recognized by the compiler, the PCL Profile 328 library generated by a compiler will not include `System.Net.Http` or `System.Threading.Tasks`.

When you build a project that includes PCL Profile 328 and `netstandard1.6` as frameworks in the *project.json* file, it will have these subfolders in the */bin/debug* folder:

```
portable-net40+sl50+netcore45+wpa81+wp8/
netstandard1.6/
```

## How to use native dependencies

You may wish to write a library which depends on a native `.dll` file.  If you're writing such a library, you have have two options:

1. Reference the native `.dll` directly in your `project.json`.
2. Package that `.dll` into its own NuGet package and depend on that package.

For the first option, you'll need to include the following in your `project.json` file:

1. Setting `allowUnsafe` to `true` in a `buildOptions` section.
2. Specifying a [Runtime Identifier (RID)](../rid-catalog.md) in a `runtimes` section.
3. Specifying the path to the native `.dll` file(s) that you are referencing.

Here's an example `project.json` for a native `.dll` file in the root directory of the project which runs on Windows:

```json
{
    "buildOptions":{
        "allowUnsafe":true
    },
    "runtimes":{
        "win10-x64":{}
    },
    "packOptions":{
        "files":{
            "mappings":{
                "runtimes/win10-x64/native":{
                    "includeFiles":[ "native-lib.dll"]
                }
            }            
        }
    }
}
```

If you're distributing your library as a package, it's recommended that you place the `.dll` file at the root level of your project.

For the second option, you'll need to build a NuGet package out of your `.dll` file(s), host on a NuGet or MyGet feed, and depend on it directly.  You'll still need to set `allowUnsafe` to `true` in the `buildOptions` section of your `project.json`.  Here's an example (assuming `MyNativeLib` is a Nuget package at version `1.2.0`):

```json
{
    "buildOptions":{
        "allowUnsafe":true
    },
    "dependencies":{
        "MyNativeLib":"1.2.0"
    }
}
```

To see an example of packaging up cross-platform native binaries, check out the [ASP.NET Libuv Package](https://github.com/aspnet/libuv-package) and the [corresponding reference in KestrelHttpServer](https://github.com/aspnet/KestrelHttpServer/blob/1.0.0/src/Microsoft.AspNetCore.Server.Kestrel/project.json#L19).

## How to test libraries on .NET Core

It's important to be able to test across platforms.  It's easiest to use [xUnit](http://xunit.github.io/), which is also the testing tool used by .NET Core projects.  How you set up your solution with test projects will depend on the [structure of your solution](#structuring-a-solution).  The following example assumes that all source projects are under a top-level `/src` folder and all test projects are under a top-level `/test` folder.

1. Ensure you have a `global.json` file at the solution level which understands where the test projects are:
    
    ```json
    {
        "projects":[ "src", "test"]
    }
    ```
    
    Your solution folder structure should then look like this:
    
    ```
    /SolutionWithSrcAndTest
    |__global.json
    |__/src
    |__/test
    ```
    
2. Create a new test project by creating a project folder under your `/test` folder, and a `project.json` file in the new project folder.  To create the `project.json` file you can run the `dotnet new` command and modify the `project.json` file afterwards.  The file should have the following:

   * `netcoreapp1.0` listed as the only entry under `frameworks`.
   * A reference to `Microsoft.NETCore.App` version `1.0.0`.
   * A reference to xUnit version `2.2.0-beta2-build3300`.
   * A reference to `dotnet-test-xunit` version `2.2.0-preview2-build1029`
   * A project reference to the library being tested.
   * The entry `"testRunner":"xunit"`.
   
   Here's an example (`LibraryUnderTest` version `1.0.0` is the library being tested):
   
   ```json
   {
        "testRunner":"xunit",
        "dependencies":{
            "LibraryUnderTest":{
                "version":"1.0.0",
                "target":"project"
            },
            "Microsoft.NETCore.App":{
                "version":"1.0.0",
                "type":"platform"
            },
            "xunit":"2.2.0-beta2-build3300",
            "dotnet-test-xunit":"2.2.0-preview2-build1029",
        },
        "frameworks":{
            "netcoreapp1.0":{}
        }
   }
   ```
3. Restore packages by running `dotnet restore`.  You should do this at the solution level if you haven't restored packages yet.

4. Navigate to your test project and run tests with `dotnet test`:

    ```
    $ cd path-to-your-test-project
    $ dotnet test
    ```

And that's it!  You can now test your library across all platforms using command line tools.  To continue testing now that you have everything set up, testing your library is very simple:

1. Make changes to your library.
2. Run tests from the command line, in your test directory, with `dotnet test` command.

Your code will be automatically rebuilt when you invoke `dotnet test` command.

Just remember to run `dotnet restore` from the command line any time you add a new dependency and you'll be good to go!

## How to use multiple projects

A common need for larger libraries is to place functionality in different projects.

Imagine you wished to build a library which could be consumed in idiomatic C# and F#.  That would mean that consumers of your library consume them in ways which are natural to C# or F#.  For example, in C# you might consume the library like this:

```csharp
var convertResult = await AwesomeLibrary.ConvertAsync(data);
var result = AwesomeLibrary.Process(convertResult);
```  

In F#, it might look like this:

```fsharp
let result =
    data
    |> AwesomeLibrary.convertAsync 
    |> Async.RunSynchronously 
    |> AwesomeLibrary.process
```

Consumption scenarios like this mean that the APIs being accessed have to have a different structure for C# and F#.  A common approach to accomplishing this is to factor all of the logic of a library into a core project, with C# and F# projects defining the API layers that call into that core project.  The rest of the section will use the following names:

* **AwesomeLibrary.Core** - A core project which contains all logic for the library
* **AwesomeLibrary.CSharp** - A project with public APIs intended for consumption in C#
* **AwesomeLibrary.FSharp** - A project with public APIs intended for consumption in F#

### Project-to-project referencing

The best way to reference a project is to do the following:

1. Make sure the project you wish to reference has a good name for its containing folder on disk.  This will be the name used to reference your project.
2. Reference the name from (1) in the `project.json` file of the consuming project specifying `"target":"project"`.

The `project.json` files for both **AwesomeLibrary.CSharp** and **AwesomeLibrary.FSharp** now need to reference **AwesomeLibrary.Core** as a `project` target.  If you aren't multitargeting, you can use the global `dependencies` entry:

```json
{
    "dependencies":{
        "AwesomeLibrary.Core":{
            "target":"project"
        }
    }
}
```

If you are multitargeting, you may not be able to use a global `dependencies` entry and may have to reference **AwesomeLibrary.Core** in a target-level `dependencies` entry.  For example, if you were targeting `netstandard1.6`, you could do so like this:

```json
{
    "frameworks":{
        "netstandard1.6":{
            "dependencies":{
                "AwesomeLibrary.Core":{
                    "target":"project"
                }
            }
        }
    }
}
```

### Structuring a Solution

Another important aspect of multi-project solutions is establishing a good overall project structure. To structure a multi-project library, you must use top-level `/src` and `/test` folders:

```
/AwesomeLibrary
|__global.json
|__/src
   |__/AwesomeLibrary.Core
      |__Source Files
      |__project.json
   |__/AwesomeLibrary.CSharp
      |__Source Files
      |__project.json
   |__/AwesomeLibrary.FSharp
      |__Source Files
      |__project.json
|__/test
   |__/AwesomeLibrary.Core.Tests
      |__Test Files
      |__project.json
   |__/AwesomeLibrary.CSharp.Tests
      |__Test Files
      |__project.json
   |__/AwesomeLibrary.FSharp.Tests
      |__Test Files
      |__project.json
```

The `global.json` file for this solution would look like this:

```json
{
    "projects":["src", "test"]
}
```

This approach follows the same pattern established by project templates in the `dotnet new` command establish, where all projects are placed under a `/src` directory and all tests are placed under a `/test` directory.

Here's how you could restore packages, build, and test your entire project:

```
$ dotnet restore
$ cd src/AwesomeLibrary.FSharp
$ dotnet build
$ cd ../AwesomeLibrary.CSharp
$ dotnet build
$ cd ../../test/AwesomeLibrary.Core.Tests
$ dotnet test
$ cd ../AwesomeLibrary.CSharp.Tests
$ dotnet test
$ cd ../AwesomeLibrary.FSharp.Tests
$ dotnet test
```

And that's it!
