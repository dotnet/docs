
# Porting Libraries to .NET Core

By [Phillip Carter](https://github.com/cartermp)

Libraries are some of the most natural projects to port from .NET Framework to .NET Core.  This article covers all of the steps you'll need to take to get to the point where you can focus on your code.  It covers the following:

- Learning about important discontinued technologies for .NET Core
- Picking the correct .NET Platform Standard for your library
- Understanding the basics of the .NET Core project model
- Understanding how multitargeting works in .NET Core
- If applicable, retargeting your code to .NET Framework 4.6.1
- Determining the portability of your code
- Picking the correct project system in Visual Studio based on your needs
- Porting your tests
- Recommended approach for porting your code

It's quite a lot of content, but porting is a task that will take some time, especially if you have a large codebase.  You should also be prepared to adapt the guidance here as needed to best fit your code.  Every codebase is different, so this article attempts to frame things in a flexible way, but you may find yourself needing to diverge from the prescribed guidance.

## Prerequisites

This article assumes you are using Visual Studio 2015 on Windows.

This article also assumes that you have understood the [overview of the porting process](overview.md) and that you have resolved any issues with [3rd party dependencies](third-party-deps.md).  If you haven't done this already, it's highly recommended that you do that before moving forward.

## Technologies Discontinued for .NET Core

There are some technologies available for .NET Framework that you may use, but are outright unavailable for .NET Core.  These are technologies that we no longer promote for .NET Framework applications, and thus did not bring to .NET Core.

### App Domains
**Why was it discontinued?** AppDomains require runtime support and are generally quite expensive. While still implemented by CoreCLR, it’s not available in .NET Native and we don’t plan on adding this capability there.

**What should you use instead?** AppDomains were used for different purposes. For code isolation, we recommend processes and/or containers. For dynamic loading of assemblies, we recommend the new [AssemblyLoadContext](http://dotnet.github.io/api/System.Runtime.Loader.AssemblyLoadContext.html) class.

### Remoting
**Why was it discontinued?** The idea of .NET remoting — which is transparent remote procedure calls — has been identified as a problematic architecture. Outside of that realm, it’s also used for cross AppDomain communication. On top of that, remoting requires runtime support and is quite heavyweight.

**What should you use instead?** For communication across processes, inter-process communication (IPC) should be used, such as pipes or memory mapped files. Across machines, you should use a network based solution, preferably a low-overhead plain text protocol such as HTTP.

### Binary serialization
**Why was it discontinued?** After a decade of servicing, we’ve learned that serialization is incredibly complicated and a huge compatibility burden for the types supporting it. Thus, we made the decision that serialization should be a protocol implemented on top of the available public APIs. However, binary serialization requires intimate knowledge of the types because it allows to serialize object graphs, which includes private state.

**What should you use instead?** Choose the serialization technology that fits your goals for formatting and footprint. Popular choices include [data contract serialization](http://dotnet.github.io/api/System.Runtime.Serialization.DataContractSerializer.html), [XML serialization](http://dotnet.github.io/api/System.Xml.Serialization.XmlSerializer.html), [JSON.NET](http://www.newtonsoft.com/json), and [protobuf-net](https://github.com/mgravell/protobuf-net).

### Sandboxing
**Why was it discontinued?** Sandboxing, i.e. relying on the runtime or the framework to constrain which resources a managed application can access, is considered a non-goal for .NET Core. Sandboxing applications and components is also really hard to get right, which is we recommend you not to rely on it. It also makes the implementation more complicated and often negatively affects performance of applications that don’t use sandboxing. Hence, we do not offer sandboxing features in .NET Core.

**What should you use instead?** Use operating system provided security boundaries, such as user accounts for running processes with the least set of privileges.

To learn about all of the discontinued tech, read [Unsupported Technologies](https://github.com/dotnet/corefx/blob/master/Documentation/project-docs/porting.md#unsupported-technologies),

## Targeting the .NET Platform Standard

The first thing to understand about porting a library to .NET Core is that you must target a version of the [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md).  In fact, it's accurate to say that targeting .NET Core means targeting a version of the .NET Platform Standard.

Long story short, this means that you'll have to make a tradeoff between APIs you can use and platforms you can support, and pick the version of the .NET Platform standard that best suits the tradeoff you wish to make.

As of right now, there are 6 different versions to consider: .NET Platform Standard 1.0 through 1.5.  If you pick a higher version, you get access to more APIs at the cost of running on less targets.  If you pick a lower version, your code can run on more targets but at the cost of less APIs available to you.

A key thing to understand is that **a project targeting a lower version cannot reference a project targeting a higher version**.  For example, a project targeting the .NET Platform Standard version 1.2 cannot reference projects that target .NET Platform Standard version 1.3 or higher.  Projects **can** reference lower versions, though, so a project targeting .NET Platform Standard 1.3 can reference a project targeting .NET Platform Standard 1.2 or lower.

It's recommended that you pick a single .NET Platform Standard version and use that throughout your library.

Read more in [The .NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md).

## .NET Core project model overview

.NET Core introduces a new project model that you may wish to spend some time understanding before you begin porting your code.  Rather than provide a comparison with the .NET Framework project model, this section covers the essential pieces.

### The project file: `project.json`

.NET Core projects are defined by a directory containing a `project.json` file.  This file is where all aspects of the project are declared, including package dependencies, compiler configuration, runtime configuration, and more.

The `dotnet restore` command reads this project file, restores all dependencies of the project, and generates a `project.lock.json` file.  This file contains all the necessary information the build system needs to build the project.

To learn more about the `project.json` file, read the .NET Core project system docs. **NOTE: need link here to the official docs we're generating**.

### The solution file: `global.json`

The `global.json` file is an optional file to include in a solution which contains multiple projects.  It typically resides in the root directory of a set of projects.  It can be used to inform the build system of different subdirectories which can contain projects.  This is for larger systems composed of many projects.

To learn more about the `global.json` file, check out the .NET Core project system docs.

## How to Multitarget with .NET Core

Many libraries multitarget to have as wide of a reach as possible.  With .NET Core, multitargeting is a "first class citizen", meaning that you can easily generate platform-specific assemblies.

Multitargeting is as simple as adding the correct Target Framework Moniker (TFM) to your `project.json` file, pulling in the correct dependecies (`dependencies` for .NET Core and `frameworkAssemblies` for .NET Framework), and potentially using `#if` directives to conditionally compile source.

For example, imagine you were building a library where you wanted to perform some networking, and you wanted that library to run on all .NET Framework versions, a Portable Class Library (PCL) Profile, and .NET Core.  For .NET Core and .NET Framework 4.5+ targets, you may use `System.Net.Http` and `async`/`await`.  However, for earlier versions of .NET Framework, those APIs aren't available.

Here's a sample `project.json` for that scenario targeting .NET Framework versions 2.0, 3.5, 4.0, 4.5, and .NET Platform Standard 1.5:

```javascript
{
    "frameworks":{
        "net20":{
            "frameworkAssemblies":{
                "System.Net":""
            }
        },
        "net35":{
            "frameworkAssemblies":{
                "System.Net":""
            }
        },
        "net40":{
            "frameworkAssemblies":{
                "System.Net":""
            }
        },
        "net45":{
            "frameworkAssemblies":{
                "System.Net.Http":"",
                "System.Threading.Tasks":""
            }
        },
        ".NETPortable,Version=v4.5,Profile=Profile259": {
            "compilationOptions": {
                "define": [ "PORTABLE" ]
             },
             "frameworkAssemblies":{
                 "mscorlib":"",
                 "System":"",
                 "System.Core":"",
                 "System.Net.Http":""
             }
        },
        "netstandard15":{
            "dependencies":{
                "NETSTandard.Library":"1.0.0",
                "System.Net.Http":"1.0.0",
                "System.Threading.Tasks":"1.0.0"
            }
        },
    }
}
```

Note that PCL targets are special: they require you to specify a compilation definition for the compiler to recognize, and they require you to specify all of the assemblies where your dependencies live.  

Your source code could then include those dependencies like this:

```csharp
#if (NET20 || NET35 || NET40 || PORTABLE)
using System.Net;
#else
using System.Net.Http;
using System.Threading.Tasks;
#endif
```

Note that all of the .NET Framework targets have names recognized by the compiler:

```
NET20
NET35
NET40
NET45
NET451
NET452
NET46
NET461
NET462
```

As mentioned above, if you are targeting a PCL then you will have to specify a compilation definition for the compiler to understand.

## Targeting your code for .NET Framework 4.6.1

If your code is not targeting .NET Framework 4.6.1, it's highly recommended that you retarget.  This ensures that you can use API alternatives for cases where .NET Core can't support existing APIs.

For each of your projects in Visual Studio you wish to port, do the following:

1. Right-click on the project and select Properties
2. In the "Target Framework" dropdown, select ".NET Framework 4.6.1".
3. Recompile your projects.

And that's it!  Because your projects now target .NET Framework 4.6.1, you can use that version of .NET Framework as your base for porting code.

## Determining the portability of your code

The next step is to run the API Portability Analyzer to generate a portability report that you can begin to analyze.

You'll need to make sure you [understand the API Portability tool](tooling.md) and can generate portability reports for targeting .NET Core.  How you do this will likely vary based on your needs and personal tastes.  What follows are a few different approaches - you may find yourself mixing each approach depending on how your code is structured.

### Dealing primarily with the compiler

This approach may be the best for small projects or projects which don't use many .NET Framework APIs.  The approach is very simple:

1. Run API Port on your project.
2. Take a quick glance and perhaps use the report as a reference for future errors.
3. Copy all of your code over into a new .NET Core project.
4. Work out compiler errors until it compiles, referring to the portability report if needed.
5. Repeat as needed.

Although this approach is very unstructured, the code-focused approach can lead to resolving any issues quickly, and may be the best approach for smaller projects or libraries.  A project that contains only data models may be an ideal candidate here.

### Staying on .NET Framework until portability issues are resolved

This approach may be the best if you prefer to have code that compiles during the entire process.  The approach is as follows:

1. Run API Port on a project.
2. Address issues by using different APIs which are portable.
3. Keep note of any areas where you can't use a direct alternative.
4. Repeat steps 1-3 for all projects you're porting until you're confident each is ready to be copied over into a .NET Core project.
5. Copy the code into a new .NET Core projects.
6. Work out any issues that you've kept note of.

This careful approach is more structured than simply working out compiler errors, but it is still relatively code-focused and has the benefit of always having code that can compile.  The way you resolve certain issues that couldn't be addressed by just using another API can vary greatly.  You may find that you need to develop a more comprehensive plan for certain projects, which is covered as the next approach.

### Developing a comprehensive plan of attack

This approach may be best for larger and more complex projects, where restructuring of code or rewriting certain areas may be necessary to support .NET Core.  The approach is as follows:

1. Run API Port on a project.
2. Understand where in your code each non-portable type is being used and how that affects overall portability.

   a.  Understand the nature of those types.  Are they small in number, but used frequently?  Are they large in number, but used infrequently?  Is their use concentrated, or is it spread throughout your code?
   
   b. Is it easy to isolate code that isn't portable so you can deal with it more easily?
   
   c. Would you need to refactor your code?
   
   d. For those types which aren't portable, are there alternative APIs that accomplish the same task?  For example, if you're using the `WebClient` class, you may be able to use the `HttpClient` class instead.
   
   e. Are there different portable APIs you can use to accomplish a task, even if it's not a drop-in replacement?  For example, if you're using `XmlSchema` to help parse XML but you don't require XML schema discovery, you could use Linq to XML APIs and hand-parse the data.

3. If you have assemblies that are difficult to port, is it worth leaving them on .NET Framework for now?

   a. You may have some functionality in your library that's incompatible with .NET Core because it relies too heavily on .NET Framework- or Windows-specific functionality.  Is it worth leaving that functionality behind for now and releasing a .NET Core version of your library with less features for the time being?
   
   b. Would a refactor help here?
   
4. Is it reasonable to write some code a .NET Framework API was doing yourself?

   a. You could consider copying, modifying, and using code from the [.NET Framework Reference Source](https://github.com/Microsoft/referencesource).  It's licensed under the [MIT License](https://github.com/Microsoft/referencesource/blob/master/LICENSE.txt) so you have significant freedom in doing this.  Just make sure to properly attribute Microsoft in your code!
   
5. Repeat this process as needed for different projects.
6. Once you have a plan, execute that plan.
 
The analysis phase could take some time depending on how large your codebase is.  Spending time in this phase to thoroughly understand the scope of changes needed and to develop a plan can save you a lot of time in the long run, particularly if you have a more complex codebase.

Your plan could involve making significant changes to your codebase while still targeting .NET Framework 4.6.1, making this a more structured version of the previous approach.  How you go about executing your plan will be dependent on your codebase.

### Mixing approaches

It's likely that you'll mix the above approaches on a per-project basis.  You should do what makes the most sense to you and for your codebase.

## Picking your project system in Visual Studio: xproj or traditional projects

In addition to a new project model, .NET Core introduces a new project system, xproj, in Visual Studio.  You'll have to pick the correct project system based on your needs.

### When to pick xproj

The new Xproj project system utilizes the capabilities of the `project.json`-based project model to offer two major features over existing project types: seamless multitargeting by building multiple assemblies and the ability to directly generate a NuGet package on build.

However, it comes at the cost of lacking certain features you may use, such as:

- Support for F# or VB
- Generating satellite assemblies with localized resource strings
- Referencing a `.dll` file on the filesystem

If your project needs are relatively minimal and you can take advantage of the new features of xproj, you should pick it as your project system.  This can be done in Visual Studio as such:

1. File | New Project.
2. Select ".NET Core" under Visual C#.
3. Selecting the "Class Library (.NET Core)" template. 

### When to pick a traditional project system

You can target .NET Core with the traditional project system in Visual Studio, by creating a Portable Class Library (PCL) and selecting ".NET Core" in the project configuration dialog.

If you have more intricate project system needs, this should be your choice.  It may also be the best choice if you're mixing .NET Core and .NET Framework code in a larger solution.  Note that if you wish to multitarget by generating platform-specific assemblies like with the `xproj` project system, you'll need to create a "Bait and Switch" PCL, [as described here](https://blogs.msdn.microsoft.com/dsplaisted/2012/08/27/how-to-make-portable-class-libraries-work-for-you/).

## Porting your tests (if applicable)

The best way to make sure everything works when you've ported your code is to *test your code as you port it to .NET Core*.  To do this, you'll need to use a testing framework that will build and run tests for .NET Core.  Currently, you have two options:

* [xUnit](https://xunit.github.io/)
   - [Getting Started](http://xunit.github.io/docs/getting-started-dnx.html)
   - [Tool to convert an MSTest project to xUnit](https://github.com/dotnet/codeformatter/tree/master/src/XUnitConverter)
* [NUnit](http://www.nunit.org/)
  - [Getting Started](https://github.com/nunit/docs/wiki/Installation)
  - [Blog post about migrating from MSTest to NUnit](http://www.florian-rappl.de/News/Page/275/convert-mstest-to-nunit)
  
Currently, MSTest does not run on .NET Core.  If you're using MSTest, you'll have to migrate to xUnit or NUnit.  If you've been using Xunit or Nunit to write your tests for your library, great!

## Recommended approach to porting

Finally, porting the code itself!  Ultimately, the actual porting effort will depend heavily on how your .NET Framework code is structured.  That being said, here is a recommended approach which may work well with your codebase.

A good way to port your code is to begin with the "base" of your library.  This may be data models or some other foundational classes and methods that everything else uses directly or indirectly.

1. Copy over the "base" of your library into the new .NET Core project and select the version of the .NET Platform Standard you wish to support.
2. Make any changes needed to get the code to compile.

   a. Much of this may just require adding NuGet package dependencies to your `project.json`.
   
   b. It may helpful to comment out old code as you slowly get things compiling.

3. Run tests and make any needed adjustments.
   
4. Pick the next layer of code to port over and repeat steps 2 and 3!

If you methodically move "out" from the "base" of your library, testing each layer as needed, you break down the porting job more systematically, thus localizing the problems to one layer of code at a time.

## Next Steps

If you want to distribute through NuGet, read about that in [Porting NuGet Packages](nuget-packages.md).
