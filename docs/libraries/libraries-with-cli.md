# Writing Libraries with Cross Platform Tools

By [Phillip Carter](https://github.com/cartermp)

**Some details are subject to change as the toolchain evolves.**

Targeting .NET Core for libraries can be done entirely with the .NET CLI tools, which are a foundational set of tools used by Visual Studio, ASP.NET, and other technologies.  They provide an efficient and low-level experience that works across any supported OS.  You can still build libraries with Visual Studio, and if that is your preferred experience then you should [refer to the Visual Studio guide](libraries-with-vs.md).  This document will focus on using the CLI tools directly.

* [Prerequisities](#prerequisites)
* [How to target .NET Core](#how-to-target-net-core)
* [How to target .NET Framework](#how-to-target-net-framework)
* [How to target a Portable Class Library (PCL)](#how to target a portable class-library-pcl)
* [How to cross-compile for .NET Core and .NET Framework](#how-to-cross-compile-for-net-core-and-net-framework)
* [How to test libraries on .NET Core](#how-to-test-libraries-on-net-core)
* [How to create a NuGet Package with your Library](#how-to-create-a-nuget-package-with-your-library)

## Prerequisites

You must have .NET Core installed on your machine.  You have two options:

* [DNX](http://aspnet.readthedocs.org/en/latest/getting-started/index.html), which is part of ASP.NET 5 RC1 and is included in Visual Studio Update 1.

* [.NET CLI](http://dotnet.github.io/getting-started/), which will be used by .NET Core and ASP.NET RC2 and will replace DNX.

Either toolchain can be used to build and publish libraries today.

The sections of this document dealing with .NET Framework versions or Portable Class Libraries (PCLs) need the .NET Framework installed.  This is only supported on Windows.

To do this, [install the .NET Framework](http://getdotnet.azurewebsites.net).

Additionally, if you wish to support older targets, you will need to install targeting/developer packs for older framework versions from the [target platforms page](http://getdotnet.azurewebsites.net/target-dotnet-platforms.html).  Refer to this table:

| .NET Framework Version | Thing to download |
| ---------------------- | ----------------- |
| 4.6 | .NET Framework 4.6 Targeting Pack |
| 4.5.2 | .NET Framework 4.5.2 Developer Pack |
| 4.5.1 | .NET Framework 4.5.1 Developer Pack |
| 4.5 | Windows Software Development Kit for Windows 8 |
| 4.0 | Windows SDK for Windows 7 and .NET Framework 4 |
| 2.0 and 3.5 | .NET Framework 3.5 SP1 Runtime (or Windows 8+ version) |

## How to target .NET Core

For the purposes of building a library, targeting ".NET Core" means targeting the .NET Platform Standard.  To see what that means exactly, see [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/standard-platform.md).

Note that as of this time, `netstandardX.X` is not supported.  You'll have to use the `dotnet` monikers.  Here's a mapping:

| dotnet | netstandard |
|--------| ----------- |
| dotnet51 | netstandard1.0 |
| dotnet52 | netstandard1.1 |
| dotnet53 | netstandard1.2 |
| dotnet54 | netstandard1.3 |
| dotnet55 | netstandard1.4 |


The following is what you need to know about .NET Platform Standard targeting:

The version of the .NET Platform Standard you pick will be a tradeoff between access to the newest APIs and ability to target more .NET platforms and Framework versions.  You can do that by picking a version of `dotnetXX` (Where `XX` is a version number) and adding it to your `project.json` file.

1. You can use the latest version of the .NET Platform Standard - `dotnet55` - which is for when you want access to the most APIs and don't want to worry about targeting anything other than .NET Core 1.0 or .NET Framework 4.6 and higher. 
2. You can use a lower version of the .NET Platform Standard to target earlier .NET platforms and versions. The cost here is not having access to some of the latest APIs. Example targets:

    - .NET Framework 4.5.2, 4.5.1, or 4.5
    - Windows Phone
    - Windows Phone Silverlight
    - Universal Windows Platform
    - DNX Core
    - Xamarin Platforms
    - Mono 

    [Refer to the platform mapping table](https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/standard-platform.md#mapping-the-net-platform-standard-to-platforms) to choose the `dotnetXX` moniker you need to target.
    
    For example, if you wanted to have compatibility with .NET Core and .NET Framework 4.6, you would pick `dotnet54`.

    ```javascript
    {
        "frameworks":{
            "dotnet54":{}
        }
    }
    ```
    
    For example, you need to target `dotnet51` to support Windows Phone Silverlight 8. The .NET Platform Standard versions in a backward-compatible way. That means that `dotnet51` libraries run on `dotnet52` platforms and later (e.g. .NET Framework 4.6 and .NET Core). When targeting `dotnet51`, you get the benefit of more platform reach than `dotnet52` but have access to fewer APIs. Each .NET Platform Standard version adds APIs and drops platforms. You should select the Standard version that has the right mix of APIs and platform support for your needs.
    
3. If you want to target the .NET Framework versions 4.0 or below, or you wish to use an API available in .NET Framework but not in .NET Core (e.g. `System.Drawing`), you'll need to read the next sections.

## How to target .NET Framework

**NOTE:** These instructions assume you have .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

Keep in mind that some of the .NET Framework versions used here are no longer in support.  [Refer to this FAQ](https://support.microsoft.com/gp/framework_faq/en-us) about unsupported versions.

You may want to reach the maximum developers and projects, so use .NET Framework 4 as your baseline target.  From a project targeting perspective, this is quite simple!  You will need to specifically target the version of .NET Framework with its relevant Target Framework Moniker.  These are mapped out here:

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
```

For example, here's how you would write a library which targets .NET Framework 4.0:

```javascript
{
    "frameworks":{
        "net40":{}
    }
}
```

And that's it!  Although this compiled only for .NET Framework 4.0, you can use the library on newer versions of .NET Framework.

## How to target a Portable Class Library (PCL)

**NOTE:** These instructions assume you have .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

Targeting a PCL profile is a bit trickier.  For starters, [reference this list of PCL profiles](http://embed.plnkr.co/03ck2dCtnJogBKHJ9EjY/preview) to make sure you have the correct target.  Hover over the name of each entry for the framework identifier, which you will need.

You will then need to do two things:

1. List the dependencies for each target *inside* of that target's node in the `project.json`.  The "global" `dependencies` section cannot be used because these dependencies are framework-specific.
2. List the framework assemblies you are using in your code *inside* the `frameworkAssemblies` node.  This will require, at a minimum, `mscorlib`, `System`, and `System.Core`.  For other APIs (such as `System.Linq`), you will need to find the assembly which corresponds to the API call you're using.  You'll need to then manually list that assembly.

Here is an example targeting PCL Profile 328. Profile 328 supports: .NET Standard 1.4, .NET Framework 4.0, Windows 8, Windows Phone 8.1, Windows Phone Silverlight 8.1, and Silverlight 5.0.

```
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

Using DNX:

```
$ dnu restore
$ dnu build
```

Using .NET CLI:

```
$ dotnet restore
$ dotnet compile
```

You will now notice two new entries in your `/bin/Debug` folder:

```
/bin
   /Debug
      /dotnet55
      /portable-net40+sl50+netcore45+wpa81+wp8
```

Each folder contains distinct `.dll` files corresponding to their named target.

## How to cross-compile for .NET Core and .NET Framework

**NOTE:** These instructions assume you have .NET Framework installed on your machine.  Refer to the [Prerequisites](#prerequisites) to get dependencies installed.

You may need to support older versions of .NET Framework when supporting both .NET Framework and .NET Core.  You may also wish to use newer APIs and language constructs for newer targets.  You can do this by using `#if` directives.

For example, in .NET Core and .NET Framework versions 4.5 and higher, you can use `HttpClient` class from the `System.Net.Http` namespace to perform network operations over HTTP.  However, earlier versions of .NET Framework don't have `HttpClient`.  Instead, you may wish to use `WebClient` from `System.Net` instead.

First, the `project.json` file should look something like this:

```javascript
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
        "dotnet55":{
            "dependencies": {
                "System.Runtime":"4.0.0-rc1-*",
                "System.Net.Http": "4.0.1-beta-23409",
                "System.Text.RegularExpressions": "4.0.11-beta-23409",
                "System.Threading.Tasks": "4.0.11-beta-23409"
            }
        }
    }
}

```

Note that .NET Framework assemblies being used are explicitly referenced in the `net40` and `net452` target, and NuGet references are also explicitly listed in the `dotnet55` target.  This is required when cross-compiling with `#if` directives.

Next, your `using` directives in your source file can be adjusted like this:

```csharp
#if NET40
// This only compiles for non-.NET 4.0 targets
using System.Net;
#else
// This compiles for all other targets
using System.Net.Http;
using System.Threading.Tasks;
#endif
```

The compiler is aware of the following names:

```
NET20  -->  .NET Framework 2.0
NET35  -->  .NET Framework 3.5
NET40  -->  .NET Framework 4.0
NET45  -->  .NET Framework 4.5
NET451 -->  .NET Framework 4.5.1
NET452 -->  .NET Framework 4.5.2
NET46  -->  .NET Framework 4.6
```

And further down in the source, you can use `#if` directives to use those libraries conditionally:

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
        // .NET 4.0 does not have async/await
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

And that's it!

### But What about Portable Class Libraries (PCL)?

If you want to cross-compile with a PCL target, you'll need to do one more thing before using `#if` directives to conditionally compile different targets: You'll need to add a compilation definition in your `project.json` file in order to target a PCL with #if directives in the source code.

For example, if you wanted to target [PCL profile 328](http://embed.plnkr.co/03ck2dCtnJogBKHJ9EjY/preview) (.NET 4.0, Windows 8, Windows Phone Silverlight 8, Windows Phone 8.1, Silverlight 5.0), you may want to refer to it to as "PORTABLE328" when cross-compiling.  Simply add it to the `project.json` file as a `compilationOptions` attribute:

```
{
    "frameworks":{
        "dotnet55":{
           "dependencies":{
                "System.Runtime":"4.0.0-rc1-*",
                "System.Net.Http":"4.0.0-rc1-*",
                "System.Thread.Tasks":"4.0.0-rc1-*"
            }
        },
        ".NETPortable,Version=v4.0,Profile=Profile328":{
            "compilationOptions": {
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

And that's it! Because `PORTABLE328` is now recognized by the compiler, the PCL Profile 328 library generated by a compiler will not include `System.Net.Http` or `System.Threading.Tasks`.

## How to use multiple projects

A common need for larger libraries is to place functionality in different projects.  For example, a library supplying functionality to both C# and F# consumers may have a core project, a C# project, and an F# project.  Here's how a potential folder structure would look:

```
/MyLibrary
|__global.json
|__/MyLibrary.Core
   |__Sources
   |__project.json
|__/MyLibrary.CSharp
   |__Sources
   |__project.json
|__/MyLibrary.FSharp
   |__Sources
   |__project.json
```

The `global.json` file would look like this:

```javascript
{
    "projects":[
        "MyLibrary.Core",
        "MyLibrary.CSharp",
        "MyLibrary.FSharp"
    ]
}
```

And the `project.json` for both `MyLibrary.FSharp` and `MyLibrary.CSharp` would include a reference to `MyLibrary.Core`:

```javascript
{
    "dependencies":{
        "MyLibrary.Core":""
        ...
    }
    ...
}
```

To build it all, you would open a command line at the root of the project (`/MyLibrary`).

Using DNX:

```
$ dnu restore
$ cd ../MyLibrary.CSharp
$ dnu build
$ cd ../MyLibrary.FSharp
$ dnu build
```
    
Using .NET CLI:
   
```
$ dotnet restore
$ cd ../MyLibrary.CSharp
$ dotnet build
$ cd ../MyLibrary.FSharp
$ dotnet build
```

Note that `MyLibrary.Core` is automatically built because it was listed as a dependency.

Any source files which use functionality in `MyLibrary.Core` can now just use it:

C#:

```csharp
using MyLibrary.Core;
```
F#:

```fsharp
open MyLibrary.Core
```

And that's it!

Important takeaways:

* Projects are just folders with files in them.
* There is a `global.json` file at the top level of your library which needs the names of each project (folder name).
* A project using another project needs to register a dependency in its `project.json` before it can be used.

## How to test libraries on .NET Core

**Note: You can only use DNX to test at this time**

It's important to be able to test across platforms.  You can do this using [Xunit](http://xunit.github.io/), which is also the testing tool used by .NET Core projects.  Getting a test to work across platforms can be done like this:

1. Create a folder for your test project to live in.  It's best to be consistent with your source folder:
    
    ```
    /src
       /Library
    /test
       /LibraryTests
    ```
    
2. Add a `global.json` file to the root directory of your library.

    ```
    /src
       /Library
    /test
       /LibraryTests
    global.json
    ```
    
    And put the names of the src and test folders:
    
    ```javascript
    {
    	"projects": [
    		"src", "test"
    	]
    }
    ```

3. Add a new `project.json` file under your test library folder.  Make sure you have the following:

    * A reference to `xunit` version `2.1.0-*`.
    * A version to `xunit.runner.dnx` version `2.1.0-rc1-*`.
    * A reference to the library under test (e.g. "Library" if its namespace is `Library`).
    * A new command called `test` which references `xunit.runner.dnx`.

    An example `project.json` testing the library called "Library" might look like this:

    ```javascript
    {
    	"commands": {
    		"test":"xunit.runner.dnx"
    	},
    	"frameworks": {
    		"dnxcore50":{
    			"dependencies": {
    				"Library":"",
    				"System.Runtime":"4.0.0-rc1-*",
    				"xunit":"2.1.0",
    				"xunit.runner.dnx": "2.1.0-rc1-*"
    			}
    		}
    	}
    }
    ```

4. Grab the dependencies for the `rc1` version of `xunit.runner.dnx` by opening a command prompt, navigating to the root of your library, and typing the following:

    `$ dnu restore -s "https://myget.org/F/xunit"`
    
    Due to the pre-release nature of creating libraries right now, you need to get the test runner for Xunit from the Xunit prerelease fed.  This will not be necessary in the future when `xunit.runner.dnx` has a release version placed in NuGet.
   
5. Grab all other dependencies across the project:

    ```$ dnu restore```

6. Navigate to your test project and run tests with `dnx test`:

    ```
    $ cd path-to-test-project
    $ dnx test
    ```

And that's it!  You can now test your library across all platforms across all platforms using command line tools.  To continue testing now that you have everything set up, testing your library is very simple:

1. Make changes to your library.
2. Run tests from the command line, in your test directory, with `$ dnx test`.

There's no need to re-build your libraries.

Just remember to run `$ dnu restore` from the command line any time you add a new dependency and you'll be good to go!

## How to create a NuGet Package with your Library

Imagine that you just wrote an awesome new library that you think other developers could use.  You can create a NuGet package to do exactly that!  It's quite easy with the new tooling.

Note: this document will use the [new-library](https://github.com/dotnet/core-docs/samples/core-projects/libraries/new-library) library as an example.

You should navigate to the directory where the library lives:

`$ cd src/Library`

Then it's just a single command from the command line!

Using DNX:
    
`$ dnu pack`
    
Using .NET CLI:
    
`$ dotnet pack`

Your `/bin/Debug` folder will now look like this:

```
/bin
   /Debug
      /net40
      /net45
      /dotnet55
      Lib.1.0.0.nupkg
      Lib.1.0.0.symbols.nupkg
```

And now you have the necessary files to publish a NuGet package!  If you want to build a NuGet package with release mode binaries, all you need to do is add the `-c`/`--configuration` switch and use `release` as the argument.

Using DNX:

`$ dnu pack --configuration release`

Using .NET CLI:

`$ dotnet pack --configuration release`

And now you'll have a new `release` folder in `/bin` containing your NuGet package:

```
/bin
   /release
      /net40
      /net45
      /dotnet55
      Lib.1.0.0.nupkg
      Lib.1.0.0.symbols.nupkg
```