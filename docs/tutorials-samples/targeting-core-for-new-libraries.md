# Targeting with .NET Core Libraries

**This is a draft and is subject to change as the toolchain evolves.**

Targeting .NET Core for new libraries can be done a number of ways, depending on the platform(s) you wish to support.

## Prerequisites

You must have .NET Core installed on your machine.  [These instructions](http://dotnet.github.io/getting-started/) will get you what that you need to start building new libraries on .NET Core.

The sections of this document dealing with .NET 4.5 Framework, .NET 4.0 Framework, or Portable Class Libraries (PCLs) require Windows and the .NET Framework installed.  The best way to do this is to [install Visual Studio](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx).  Alternatively, you can [install .NET Framework 4.6](https://www.microsoft.com/en-us/download/details.aspx?id=48130) as a standalone package.  This will contain all the depndencies required for .NET Framework 4.5, 4.0, and any PCLs you may wish to support.

## How do I target .NET Core?

For the purposes of building a library, targeting ".NET Core" means targeting the .NET Standard Platform.  To see what that means exactly, see [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/standard-platform.md).

A distilled version is this:

You need to pick a version of `dotnetXX` (where `XX` is a version number) to add to your `project.json` file.

1. If you don't care about backwards compatibility, target `dotnet55`.
2. If you care about compatibility with any of the following:

    - .NET Framework versions from 4.5 and up (and you don't need [these libraries](LINK))
    - Windows Phone
    - Windows Phone Silverlight
    - Universal Windows Platform
    - DNX Core
    - Xamarin Platforms
    - Mono 

    Then [refer to this table](https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/standard-platform.md#existing-net-standard-platform-versions) and choose the version of the `dotnetXX` moniker you need.
    
    For example, if you wanted to have compatibility with .NET Core and .NET Framework 4.6, you would pick `dotnet55`:

    ```
    {
        "frameworks":{
            "dotnet55":{}
        }
    }
    ```
    
    If you wanted to be compatible with Windows Phone Silverlight 8, you would pick `dotnet51`:
    
    ```
    {
        "frameworks":{
            "dotnet51":{}
        }
    }
    ```
3. If you care about compatibility with the .NET Framework versions 4.0 or below, or need to support [these .NET 4.5 libraries](LINK), skip to the next section.

## How do I target both .NET Core and .NET Framework?

**NOTE:** This requires Windows and .NET Framework installed on your machine.  Refer to the [Prerequisites](#Prerequisites) to get dependencies installed.

You may need a library to work on .NET Core *and* .NET Framework 4.0 or older.  You may also need to use specific libraries available in .NET 4.5 which are unavailable in .NET Core (such as `SYSTEM.FIXME.SOON`).  For these scenarios, you will need to specifically target the versions of .NET Framework you support.

This is done by adding relevant Target Framework Moniker, such as `net45` to your `project.json` file.

For example, you may want to support .NET Framework 4.0 and 4.5, but use the most up-to-date libraries for your .NET Core target.  Setting up your `project.json` file like this will do the trick:

```
{
    "frameworks":{
        "net40":{},
        "net45":{},
        "dotnet55":{
            "dependencies":{
                "System.Runtime":"4.0.0-rc1-*"
            }
        }
    }
}
```

And that's it!  Run `dnu restore` and `dnu build` from the command line, and your library can now be built!  You will now notice three new entries in your `/bin` folder:

```
/bin
   /Debug
      /net40
      /net45
      /dotnet
```

Finally, running `dnu pack` will build a NuGet package, and your `/bin/Debug` folder will look like this:

```
/bin
   /Debug
      /net40
      /net45
      /dotnet
      Lib.1.0.0.nupkg
      Lib.1.0.0.symbols.nupkg
```

And now you have the necessary files to publish a NuGet package!

**NOTE:** This assumes your code will compile across *both* .NET Core and .NET Framework.  Read the section on cross-compiling with `#if`s on how to compile the same file differently for each target if you are using features which are unavailable in some of your targets.

## How do I target a Portable Class Library (PCL)?

**NOTE:** This requires Windows and .NET Framework installed on your machine.  Refer to the [Prerequisites](#Prerequisites) to get dependencies installed.

Targeting a PCL profile is a bit trickier.  For starters, [reference this list of PCL profiles](http://embed.plnkr.co/03ck2dCtnJogBKHJ9EjY/preview) to ensure you have the correct target.  Hover over the Name of each entry for the framework identifier, which you will need.

You will then need to do two things:

1. List the dependencies for each target *inside* of that target.  The "global" `dependencies` section cannot be used.
2. List the framework assemblies you are using in your code *inside* the PCL target profile section.  This will require, at a minimum, `mscorlib`, `System`, and `System.Core`.

Here is an example targeting PCL Profile 328 and .NET Core, using only `System.Runtime` as a dependency for .NET Core.

```
{
    "frameworks":{
        "dotnet55":{
           "dependencies":{
                "System.Runtime":"4.0.0-rc1-*"
            }
        },
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

This will allow you to target .NET Core 5.1, .NET Core 5.5, .NET Framework 4.0, Windows 8, Windows Phone 8.1, WIndows Phone Silverlight 8.1, and Silverlight 5.0.

Run `dnu restore` and `dnu build` from the command line, and your library can now be built!  You will now notice three new entries in your `/bin/Debug` folder:

```
/bin
   /Debug
      /dotnet51
      /dotnet55
      /portable-net40+sl50+netcore45+wpa81+wp8
```

Each folder contains distinct `.dll`s corresponding to that target.

Finally, run `dnu pack` to build a NuGet pakage, and your `/bin/Debug` folder should look like this:

```
/bin
   /Debug
      /dotnet51
      /dotnet55
      /portable-net40+sl50+netcore45+wpa81+wp8
      Lib.1.0.0.nupkg
      Lib.1.0.0.symbols.nupkg
```

And now you can publish a NuGet package!

**NOTE:** This assumes your code will compile across *both* .NET Core and .NET Framework.  Read the section on cross-compiling with `#if`s on how to compile the same file differently for each target if you are using features which are unavailable in some of your targets.

## How do I cross-compile for .NET Core and .NET Framework?

**NOTE:** This requires Windows and .NET Framework installed on your machine.  Refer to the [Prerequisites](#Prerequisites) to get dependencies installed.

If you need to support .NET Framework and .NET Core, you may find yourself needing to use different APIs to accomplish the same task.  You may also wish to support different language constructs (such as `async` and `await`, which only became available with .NET Framework 4.5) and support modern APIs within the same file.  A great way to do this is to cross-compile with `#if` guards.

For example, in .NET Core you can use `HttpClient` in the `System.Net.Http` API to perform network operations over Http.  However, the .NET 4.0 Framework does not include `HttpClient`!  Instead, you may need to use `WebClient` from the `System.Net` assembly.

First, the `project.json` file should look something like this:

```
{
    "frameworks":{
        "net40":{
            "frameworkAssemblies": {
                "System.Net":"",
                "System.Text.RegularExpressions":""
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

Note that framework assemblies being used are explicitly referenced in the `net40` target, and NuGet references are also explictly listed in the `dotnet55` target.

Next, your `using`s in your source file can be adjusted like this:

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

* `NET20` -->  .NET Framework 2.0
* `NET35` -->  .NET Framework 3.5
* `NET40` -->  .NET Frameowrk 4.0
* `NET45` -->  .NET Framework 4.5
* `NET451` --> .NET Framework 4.5.1
* `NET452` --> .NET Framework 4.5.2
* `NET46` --> .NET Framework 4.6

And further down in the source, you can use guards to use those libraries conditionally:

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

### But What about Portable Class Libraries (PCLs)?

PCLs add one more thing to do before you can use `#if`s to conditionally compile different targets: **you need to add a compilation definition in your** `project.json` **file**.

For example, if you wanted to target PCL profile 328 (.NET 4.0, Windows 8, Windows Phone Silverlight 8, Windows Phone 8.1, Silverlight 5.0), you may want to refer to it to as "PORTABLE328" when cross-compiling.  Simply add it to the `project.json` file as a `compilationOptions` attribute:

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

And that's it! Because `PORTABLE328` is now recognized by the compiler, and the generated `.dll` which corresponds to PCL Profile 328 will not include `System.Net.Http` or `System.Threading.Tasks`.