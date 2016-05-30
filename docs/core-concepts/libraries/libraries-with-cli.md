# Writing Libraries with Cross Platform Tools

By [Phillip Carter](https://github.com/cartermp)

**Some details are subject to change as the toolchain evolves.**

Targeting .NET Core for libraries can be done entirely with the .NET CLI tools, which are a foundational set of tools used by Visual Studio and ASP.NET Core.  They provide an efficient and low-level experience that works across any supported OS.  You can still build libraries with Visual Studio, and if that is your preferred experience then you should [refer to the Visual Studio guide](libraries-with-vs.md).  This document will focus on using the CLI tools directly.

* [Prerequisites](#prerequisites)
* [How to target .NET Core](#how-to-target-net-core)
* [How to target the .NET Framework](#how-to-target-the-net-framework)
* [How to target a Portable Class Library (PCL)](#how-to-target-a-portable-class-library-pcl)
* [How to multitarget](#how-to-multitarget)
* [How to use native dependencies](#how-to-use-native-dependencies)
* [How to test libraries on .NET Core](#how-to-test-libraries-on-net-core)
* [How to use multiple projects](#how-to-use-multiple-projects)
* [How to create a NuGet Package with your Library](#how-to-create-a-nuget-package-with-your-library)

## Prerequisites

You must have .NET Core installed on your machine.  You will need [the .NET Core SDK and CLI](https://www.microsoft.com/net/core).

The sections of this document dealing with the .NET Framework versions or Portable Class Libraries (PCL) need the .NET Framework installed.  They are only supported on Windows.  To do this, [install the .NET Framework](http://getdotnet.azurewebsites.net).

Additionally, if you wish to support older targets, you will need to install targeting/developer packs for older framework versions from the [target platforms page](http://getdotnet.azurewebsites.net/target-dotnet-platforms.html).  Refer to this table:

| .NET Framework Version | What to download |
| ---------------------- | ----------------- |
| 4.6 | .NET Framework 4.6 Targeting Pack |
| 4.5.2 | .NET Framework 4.5.2 Developer Pack |
| 4.5.1 | .NET Framework 4.5.1 Developer Pack |
| 4.5 | Windows Software Development Kit for Windows 8 |
| 4.0 | Windows SDK for Windows 7 and .NET Framework 4 |
| 2.0, 3.0, and 3.5 | .NET Framework 3.5 SP1 Runtime (or Windows 8+ version) |

## How to target .NET Core

For the purposes of building a library, targeting ".NET Core" means targeting the .NET Platform Standard.  To see what that means exactly, see [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md).

The following is what you need to know about .NET Platform Standard targeting:

The version of the .NET Platform Standard you pick will be a tradeoff between access to the newest APIs and ability to target more .NET platforms and Framework versions.  You can do that by picking a version of `netstandardXX` (Where `XX` is a version number) and adding it to your `project.json` file.

Additionally, the corresponding [NuGet package to depend on](https://www.nuget.org/packages/NETStandard.Library/) is `NETStandard.Library` version `1.5.0-rc2-24027`.  Although there's nothing preventing you from depending on `Microsoft.NETCore.App` like with console apps, it's generally not recommended.  If you need APIs from a package not specified in `NETStandard.Library`, you can always specify that package in addition to `NETStandard.Library` in the `dependencies` section of your `project.json` file.

You have three primary options when targeting .NET Core, depending on your needs.

1. You can use the latest version of the .NET Platform Standard - `netstandard1.5` - which is for when you want access to the most APIs and don't want to worry about targeting anything other than .NET Core 1.0 or the .NET Framework 4.6.2 and higher. 
2. You can use a lower version of the .NET Platform Standard to target earlier .NET platforms and versions. The cost here is not having access to some of the latest APIs. Example targets:

    - .NET Framework 4.5.2, 4.5.1, or 4.5
    - Windows Phone
    - Windows Phone Silverlight
    - Universal Windows Platform
    - Xamarin Platforms
    - Mono

    [Refer to the platform mapping table](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md#mapping-the-net-platform-standard-to-platforms) to choose the `netstandardXX` moniker you need to target.
    
    For example, if you wanted to have compatibility with .NET Core and .NET Framework 4.6, you would pick `netstandard1.3`.

    ```json
    {
        "dependencies":{
            "NETStandard.Library":"1.5.0-rc2-24027"
        },
        "frameworks":{
            "netstandard1.3":{}
        }
    }
    ```
    
    The .NET Platform Standard versions in a backward-compatible way. That means that `netstandard1.0` libraries run on `netstandard1.1` platforms and higher. When targeting `netstandard1.0`, you get the benefit of more platform reach than `netstandard1.1` but have access to fewer APIs. Each .NET Platform Standard version adds APIs and drops platforms. You should select the Standard version that has the right mix of APIs and platform support for your needs.
    
3. If you want to target the .NET Framework versions 4.0 or below, or you wish to use an API available in the .NET Framework but not in .NET Core (for example, `System.Drawing`), read the following sections and learn how to multitarget.

## How to target the .NET Framework

**NOTE:** These instructions assume you have the .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

Keep in mind that some of the .NET Framework versions used here are no longer in support.  Refer to the [.NET Framework Support Lifecycle Policy FAQ](https://support.microsoft.com/gp/framework_faq/en-us) about unsupported versions.

If you want to reach the maximum developers and projects, use the .NET Framework 4 as your baseline target. To target the .NET Framework, you will need to begin by using the correct Target Framework Moniker (TFM) that corresponds to the .NET Framework version you wish to support.

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

**NOTE:** These instructions assume you have the .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

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

You can now build.

```
$ dotnet restore
$ dotnet build
```

Notice the following entry in the `/bin/Debug` folder:

```
$ ls bin/Debug

portable-net40+sl50+netcore45+wpa81+wp8/
```

This folder contains the `.dll` files necessary to run your library.

## How to Multitarget

**NOTE:** These following instructions assume you have the .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) section to learn which dependencies you need to install and where to download them from.

You may need to target older versions of the .NET Framework when your project supports both the .NET Framework and .NET Core. In this scenario, if you want to use newer APIs and language constructs for the newer targets, use `#if` directives in your code. You also might need to add different packages and dependencies in your `project.json file` for each platform you're targeting to include the different APIs needed for each case.

For example, let's say you have a library that performs networking operations over HTTP. For .NET Core and the .NET Framework versions 4.5 or higher, you can use the `HttpClient` class from the `System.Net.Http` namespace. However, earlier versions of the .NET Framework don't have the `HttpClient` class, so you could use the `WebClient` class from the `System.Net` namespace for those instead.

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
        "netstandard1.5":{
            "dependencies": {
                "NETStandard.Library":"1.5.0-rc2",
            }
        }
    }
}
```

Note that the .NET Framework assemblies need to be referenced explicitly in the `net40` and `net452` target, and NuGet references are also explicitly listed in the `netstandard1.5` target.  This is required in multitargeting scenarios.

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

Now you can build.

```
$ dotnet restore
$ dotnet build
```

Your `/bin/Debug` folder will look like this:

```
$ ls bin/Debug

net40/
net45/
netstandard1.5/
```

### But What about Multitargeting with Portable Class Libraries?

If you want to cross-compile with a PCL target, you must add a build definition in your `project.json` file under `buildOptions` in your PCL target.  You can then use `#if` directives in the source which use the build definition as a preprocessor symbol.

For example, if you want to target [PCL profile 328](http://embed.plnkr.co/03ck2dCtnJogBKHJ9EjY/preview) (The .NET Framework 4, Windows 8, Windows Phone Silverlight 8, Windows Phone 8.1, Silverlight 5), you could to refer to it to as "PORTABLE328" when cross-compiling.  Simply add it to the `project.json` file as a `buildOptions` attribute:

```json
{
    "frameworks":{
        "netstandard1.5":{
           "dependencies":{
                "NETStandard.Library":"1.5.0-rc2-final",
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

Now you can build.

```
$ dotnet restore
$ dotnet build
```

Your `/bin/Debug` folder will look like this:

```
$ ls bin/Debug

portable-net40+sl50+netcore45+wpa81+wp8/
netstandard1.5/
```

## How to use native dependencies

You may wish to write a library which depends on a native `.dll` file.  If you're writing such a library, you have have two options:

1. Reference the native `.dll` directly in your `project.json`.
2. Package that `.dll` into its own NuGet package and depend on that package.

For the first option, you'll need to include the following in your `project.json` file:

1. Setting `allowUnsafe` to `true` in a `buildOptions` section.
2. Specifying the path to the native `.dll`(s) with a [Runtime Identifier (RID)](../rid-catalog.md) under `files` in the `packOptions` section.

If you're distributing your library as a package, it's recommended that you place the `.dll` file at the root level of your project.  Here's an example `project.json` for a native `.dll` file that runs on Windows x64:

```json
{
    "buildOptions":{
        "allowUnsafe":true
    },
    "packOptions":{
        "files":{
            "runtimes/win7-x64/native/":"native-lib.dll"
        }
    }
}
```

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

To see an example of packaging up cross-platform native binaries, check out the [ASP.NET Libuv Package](https://github.com/aspnet/libuv-package) and the [corresponding reference in KestrelHttpServer](https://github.com/aspnet/KestrelHttpServer/blob/dev/src/Microsoft.AspNetCore.Server.Kestrel/project.json#L18).

## How to test libraries on .NET Core

It's important to be able to test across platforms.  It's easiest to use [xUnit](http://xunit.github.io/), which is also the testing tool used by .NET Core projects.  Setting up your solution with test projects will depend on the [structure of your solution](#structuring-your-solution).  The following example assumes that all source projects are under a top-level `/src` folder and all test projects are under a top-level `/test` folder.

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
    
2. Create a new test project by creating a `project.json` file under your `/test` folder.  You can also run the `dotnet new` command and modify the `project.json` file afterwards.  It should have the following:

   * `netcoreapp1.0` listed as the only entry under `frameworks`.
   * `dnxcore50` and `portable-net45+win8` added as `imports` under `netcoreapp1.0`.
   * A reference to `Microsoft.NETCore.App` version `1.0.0-rc2-3002702`.
   * A reference to xUnit version `2.1.0`.
   * A reference to `dotnet-test-xunit` version `1.0.0-rc2-build10025`
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
                "type":"platform",
                "version":"1.0.0-rc2"
            },
            "xunit":"2.1.0",
            "dotnet-test-xunit":"1.0.0-rc2",
        },
        "frameworks":{
            "netcoreapp1.0":{
                "imports":[ "dnxcore50", "portable-net45+win8" ]
            }
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

Consumtion scenarios like this mean that the APIs being accessed have to have a different structure for C# and F#.  A common approach to accomplishing this is to factor all of the logic of a library into a core project, with C# and F# projects defining the API layers that call into that core project.  The rest of the section will use the following names:

* **AwesomeLibrary.Core** - A core project which contains all logic for the library
* **AwesomeLibrary.CSharp** - A project with public APIs intended for consumption in C#
* **AwesomeLibrary.FSharp** - A project with public APIs intended for consumption in F#

### Project-to-project referencing

To reference a project, you need to do two things:

1. Understand the name and version number of the project you wish to reference.
2. List that project as a dependency using the name and version number from (1).

In the above case, you may wish to set up the `project.json` for **AwesomeLibrary.Core** as follows:

```json
{
    "name":"AwesomeLibrary.Core",
    "version":"1.0.0"
}
```

You can use these entries in the `project.json` to control the name and version of the project.  If you don't specify these, the default configuration is to use the name of the containing folder as the name and 1.0.0 as the version number.

The `project.json` files for both **AwesomeLibrary.CSharp** and **AwesomeLibrary.FSharp** now need to reference **AwesomeLibrary.Core** as a `project` target.  If you aren't multitargeting, you can use the global `dependencies` entry:

```json
{
    "dependencies":{
        "AwesomeLibrary.Core":{
            "version":"1.0.0",
            "target":"project"
        }
    }
}
```

> **Note:** Failure to list the reference as a `project` target may result in NuGet resolving the dependency with an existing NuGet package which happens to have the same name.  Always specify `"target":"project"` when referencing a project in the same solution.

If you are multitargeting, you may not be able to use a global `dependencies` entry and may have to reference **AwesomeLibrary.Core** in a target-level `dependencies` entry.  For example, if you were targeting `netstandard1.5`, you could do so like this:

```json
{
    "frameworks":{
        "netstandard1.5":{
            "dependencies":{
                "AwesomeLibrary.Core":{
                    "version":"1.0.0",
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
/test
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

## How to create a NuGet Package with your Library

Imagine that you just wrote an awesome new library that you think other developers could use.  You can create a NuGet package to do exactly that!  It's quite easy with the .NET CLI.  The following example assumes a library called **Lib** which targets `netstandard1.0`.

> If you have transitive dependencies; that is, a project which depends on another project, you'll need to make sure to restore packages for your entire solution.

After ensuring packages are restored, you can navigate to the directory where a library lives:

`$ cd src/Library`

Then it's just a single command from the command line:
    
`$ dotnet pack`

Your `/bin/Debug` folder will now look like this:

```
$ ls bin/Debug

netstandard1.0/
Lib.1.0.0.nupkg
Lib.1.0.0.symbols.nupkg
```

And now you have the necessary files to publish a NuGet package!

> For .NET Core RC2, libraries are expected to be distributed as NuGet packages. This can only be done with `dotnet pack` when using the .NET CLI.  It is important that you use `dotnet pack` instead of `dotnet publish` for this.  Using `dotnet publish` for a library will error out.

If you want to build a NuGet package with release mode binaries, all you need to do is add the `-c`/`--configuration` switch and use `release` as the argument.

`$ dotnet pack --configuration release`

And now you'll have a new `release` folder in `/bin` containing your NuGet package:

```
$ ls bin/release

netstandard1.0/
Lib.1.0.0.nupkg
Lib.1.0.0.symbols.nupkg
```
