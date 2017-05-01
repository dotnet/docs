---
title: Porting to .NET Core - Libraries
description: Porting to .NET Core - Libraries
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: a0fd860d-d6b6-4659-b325-8a6e6f5fa4a1
---

# Porting to .NET Core - Libraries

With the release of .NET Core 1.0, there is an opportunity to port existing library code so that it can run cross-platform. This article discusses the .NET Standard Library, unavailable technologies, how to account for the smaller number of APIs available on .NET Core 1.0, how to use the tooling that ships with .NET Core SDK Preview 2, and recommended approaches to porting your code.

Porting is a task that may take time, especially if you have a large codebase. You should also be prepared to adapt the guidance here as needed to best fit your code. Every codebase is different, so this article attempts to frame things in a flexible way, but you may find yourself needing to diverge from the prescribed guidance.

## Prerequisites

This article assumes you are using Visual Studio 2017 or later on Windows. The bits required for building .NET Core code are not available on previous versions of Visual Studio.

This article also assumes that you understand the [recommended porting process](index.md) and that you have resolved any issues with [third-party dependencies](third-party-deps.md).

## Targeting the .NET Standard Library

The best way to build a cross-platform library for .NET Core is to target the [.NET Standard Library](../../standard/library.md). The .NET Standard Library is the formal specification of .NET APIs that are intended to be available on all .NET runtimes. It is supported by the .NET Core runtime.

What this means is that you'll have to make a tradeoff between APIs you can use and platforms you can support, and pick the version of the .NET Platform Standard that best suits the tradeoff you wish to make.

As of right now, there are 7 different versions to consider: .NET Standard 1.0 through 1.6. If you pick a higher version, you get access to more APIs at the cost of running on fewer targets. If you pick a lower version, your code can run on more targets but at the cost of fewer APIs available to you.

For your convenience, here is a matrix of each .NET Standard version and each specific area it runs on:

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

A key thing to understand is that **a project targeting a lower version cannot reference a project targeting a higher version**. For example, a project targeting the .NET Platform Standard version 1.2 cannot reference projects that target .NET Platform Standard version 1.3 or higher. Projects **can** reference lower versions, though, so a project targeting .NET Platform Standard 1.3 can reference a project targeting .NET Platform Standard 1.2 or lower.

It's recommended that you pick the lowest possible .NET Standard version and use that throughout your project.

Read more in [.NET Platform Standard Library](../../standard/library.md).

## Key Technologies Not Yet Available on the .NET Standard or .NET Core

You may be using some technologies available for the .NET Framework that are not currently available for .NET Core. Each of the following sub-sections corresponds to one of those technologies. Alternative options are listed if it is feasible for you to adopt them.

### App Domains

AppDomains can be used for different purposes on the .NET Framework. For code isolation, we recommend separate processes and/or containers as an alternative. For dynamic loading of assemblies, we recommend the new @System.Runtime.Loader.AssemblyLoadContext class.

### Remoting

For communication across processes, inter-process communication (IPC) mechanisms can be used as an alternative to Remoting, such as [Pipes](https://docs.microsoft.com/dotnet/core/api/system.io.pipes) or [Memory Mapped Files](https://docs.microsoft.com/dotnet/core/api/system.io.memorymappedfiles.memorymappedfile).

Across machines, you can use a network based solution as an alternative, preferably a low-overhead plain text protocol such as HTTP. [KestrelHttpServer](https://github.com/aspnet/KestrelHttpServer), the web server used by ASP.NET Core, is an option here. Remote proxy generation via [Castle.Core](https://github.com/castleproject/Core) is also an option to consider.

### Binary Serialization

As an alternative to Binary Serialization, there are multiple different serialization technologies to choose. You should choose one that fits your goals for formatting and footprint. Popular choices include:

* [JSON.NET](http://www.newtonsoft.com/json) for JSON
* @System.Runtime.Serialization.DataContractSerializer for both XML and JSON
* @System.Xml.Serialization.XmlSerializer for XML
* [protobuf-net](https://github.com/mgravell/protobuf-net) for Protocol Buffers

Refer to the linked resources to learn about their benefits and choose the ones for your needs. There are many other serialization formats and technologies out there, many of which are open source.

### Sandboxes

As an alternative to Sandboxing, you can use operating system provided security boundaries, such as user accounts for running processes with the least set of privileges.

## Overview of `project.json`

The [project.json project model](../tools/project-json.md) is a project model that ships with .NET Core SDK 1.0 Preview 2. It offers some benefits you may wish to take advantage of today:

* Simple multitargeting where target-specific assemblies can be generated from a single build.
* The ability to easily generate a NuGet package with a build of the project.
* No need to list files in your project file.
* Unification of NuGet package dependencies and project-to-project dependencies.

> While `project.json` is eventually going to be deprecated, it can be used to build libraries on the .NET Standard today.

### The Project File: `project.json`

.NET Core projects are defined by a directory containing a `project.json` file. This file is where aspects of the project are declared, such as package dependencies, compiler configuration, runtime configuration, and more.

The `dotnet restore` command reads this project file, restores all dependencies of the project, and generates a `project.lock.json` file. This file contains all the necessary information the build system needs to build the project.

To learn more about the `project.json` file, read the [project.json reference](../tools/project-json.md).

### The Solution File: `global.json`

The `global.json` file is an optional file to include in a solution which contains multiple projects. It typically resides in the root directory of a set of projects. It can be used to inform the build system of different subdirectories which can contain projects. This is for larger systems composed of several projects.

For example, you can organize your code into top-level `/src` and `/test` folder as such:

```json
{
    "projects":[ "src", "test" ]
}
```

You can then have multiple `project.json` files under their own sub-folders inside `/src` and `/test`.

### How to Multitarget with `project.json`

Many libraries multitarget to have as wide of a reach as possible. With .NET Core, multitargeting is a "first class citizen", meaning that you can easily generate platform-specific assemblies with a single build.

Multitargeting is as simple as adding the correct Target Framework Moniker (TFM) to your `project.json` file, using the correct dependencies for each target (`dependencies` for .NET Core and `frameworkAssemblies` for .NET Framework), and potentially using `#if` directives to conditionally compile the source code for platform-specific API usage.

For example, imagine you are building a library where you wanted to perform some network operations, and you wanted that library to run on all .NET Framework versions, a Portable Class Library (PCL) Profile, and .NET Core. For .NET Core and .NET Framework 4.5+ targets, you may use `System.Net.Http` library and `async`/`await`. However, for earlier versions of .NET Framework, those APIs aren't available.

Here's a sample `frameworks` section for a `project.json` that targets the .NET Framework versions 2.0, 3.5, 4.0, 4.5, and .NET Standard 1.6:

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
            "buildOptions": {
                "define": [ "PORTABLE" ]
             },
             "frameworkAssemblies":{
                 "mscorlib":"",
                 "System":"",
                 "System.Core":"",
                 "System.Net.Http":""
             }
        },
        "netstandard16":{
            "dependencies":{
                "NETStandard.Library":"1.6.0",
                "System.Net.Http":"4.0.1",
                "System.Threading.Tasks":"4.0.11"
            }
        },
    }
}
```

Note that PCL targets are special: they require you to specify a build definition for the compiler to recognize, and they require you to specify all of the assemblies you use, including `mscorlib`.

Your source code could then use the dependencies like this:

```csharp
#if (NET20 || NET35 || NET40 || PORTABLE)
using System.Net;
#else
using System.Net.Http;
using System.Threading.Tasks;
#endif
```

Note that all of the .NET Framework and .NET Standard targets have names recognized by the compiler:

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

As mentioned above, if you are targeting a PCL, then you will have to specify a build definition for the compiler to understand. There is no default definition that the compiler can use.

### Using `project.json` in Visual Studio

You have two options for using `project.json` in Visual Studio:

1. A new xproj project type.
2. A retargeted PCL project which supports .NET Standard.

There are different benefits and drawbacks for each.

#### When to Pick an Xproj Project

The new Xproj project system in Visual Studio utilizes the capabilities of the `project.json`-based project model to offer two major features over existing project types: seamless multitargeting by building multiple assemblies and the ability to directly generate a NuGet package on build.

However, it comes at the cost of lacking certain features you may use, such as:

- Support for F# or Visual Basic
- Generating satellite assemblies with localized resource strings
- Directly referencing a `.dll` file on the filesystem
- The ability to reference a csproj-based project in the Reference Manager (depending on the `.dll` file directly is supported, though)

If your project needs are relatively minimal and you can take advantage of the new features of xproj, you should pick it as your project system. This can be done in Visual Studio as such:

1. Ensure you are using Visual Studio 2015 or later.
2. Select File | New Project.
3. Select ".NET Core" under Visual C#.
4. Select the "Class Library (.NET Core)" template. 

#### When to Pick a PCL project

You can target .NET Core with the traditional project system in Visual Studio, by creating a Portable Class Library (PCL) and selecting ".NET Core" in the project configuration dialog. Then you'll need to retarget the project to be based on the .NET Standard:

1. Right-click on the project file in Visual Studio and select Properties.
2. Under Build, select "Convert to .NET Standard".

If you have more advanced project system needs, this should be your choice. Note that if you wish to multitarget by generating platform-specific assemblies like with the `xproj` project system, you'll need to create a "Bait and Switch" PCL, as described in [How to Make Portable Class Libraries Work for You](https://blogs.msdn.microsoft.com/dsplaisted/2012/08/27/how-to-make-portable-class-libraries-work-for-you/).

## Retargeting your .NET Framework Code to .NET Framework 4.6.2

If your code is not targeting .NET Framework 4.6.2, it's recommended that you retarget. This ensures that you can use the latest API alternatives for cases where the .NET Standard can't support existing APIs.

For each of your projects in Visual Studio you wish to port, do the following:

1. Right-click on the project and select Properties
2. In the "Target Framework" dropdown, select ".NET Framework 4.6.2".
3. Recompile your projects.

And that's it! Because your projects now target .NET Framework 4.6.2, you can use that version of .NET Framework as your base for porting code.

## Determining the Portability of Your Code

The next step is to run the API Portability Analyzer (ApiPort) to generate a portability report that you can begin to analyze.

You'll need to make sure you understand the [API Portability tool (ApiPort)](https://github.com/Microsoft/dotnet-apiport/blob/master/docs/HowTo/) and can generate portability reports for targeting .NET Core. How you do this will likely vary based on your needs and personal tastes. What follows are a few different approaches - you may find yourself mixing each approach depending on how your code is structured.

### Dealing Primarily with the Compiler

This approach may be the best for small projects or projects which don't use many .NET Framework APIs. The approach is very simple:

1. Optionally run ApiPort on your project.
2. If ApiPort was ran, take a quick glance at the report.
3. Copy all of your code over into a new .NET Core project.
4. Work out compiler errors until it compiles, referring to the portability report if needed.
5. Repeat as needed.

Although this approach is very unstructured, the code-focused approach can lead to resolving any issues quickly, and may be the best approach for smaller projects or libraries. A project that contains only data models may be an ideal candidate here.

### Staying on the .NET Framework until Portability Issues are Resolved

This approach may be the best if you prefer to have code that compiles during the entire process. The approach is as follows:

1. Run ApiPort on a project.
2. Address issues by using different APIs which are portable.
3. Keep note of any areas where you can't use a direct alternative.
4. Repeat steps 1-3 for all projects you're porting until you're confident each is ready to be copied over into a .NET Core project.
5. Copy the code into a new .NET Core projects.
6. Work out any issues that you've kept note of.

This careful approach is more structured than simply working out compiler errors, but it is still relatively code-focused and has the benefit of always having code that can compile. The way you resolve certain issues that couldn't be addressed by just using another API can vary greatly. You may find that you need to develop a more comprehensive plan for certain projects, which is covered as the next approach.

### Developing a Comprehensive Plan of Attack

This approach may be best for larger and more complex projects, where restructuring of code or rewriting certain areas may be necessary to support .NET Core. The approach is as follows:

1. Run ApiPort on a project.
2. Understand where in your code each non-portable type is being used and how that affects overall portability.

   a. Understand the nature of those types. Are they small in number, but used frequently? Are they large in number, but used infrequently? Is their use concentrated, or is it spread throughout your code?
   
   b. Is it easy to isolate code that isn't portable so you can deal with it more easily?
   
   c. Would you need to refactor your code?
   
   d. For those types which aren't portable, are there alternative APIs that accomplish the same task? For example, if you're using the `WebClient` class, you may be able to use the `HttpClient` class instead.
   
   e. Are there different portable APIs you can use to accomplish a task, even if it's not a drop-in replacement? For example, if you're using `XmlSchema` to help parse XML, but you don't require XML schema discovery, you could use `System.Linq.Xml` APIs and hand-parse the data.

3. If you have assemblies that are difficult to port, is it worth leaving them on .NET Framework for now? Here are some things to consider:

   a. You may have some functionality in your library that's incompatible with .NET Core because it relies too heavily on .NET Framework- or Windows-specific functionality. Is it worth leaving that functionality behind for now and releasing a .NET Core version of your library with less features for the time being?
   
   b. Would a refactor help here?
   
4. Is it reasonable to write your own implementation of an unavailable .NET Framework API?

   You could consider instead copying, modifying, and using code from the [.NET Framework Reference Source](https://github.com/Microsoft/referencesource). It's licensed under the [MIT License](https://github.com/Microsoft/referencesource/blob/master/LICENSE.txt), so you have significant freedom in doing this. Just be sure to properly attribute Microsoft in your code!
   
5. Repeat this process as needed for different projects.
6. Once you have a plan, execute that plan.
 
The analysis phase could take some time depending on how large your codebase is. Spending time in this phase to thoroughly understand the scope of changes needed and to develop a plan can save you a lot of time in the long run, particularly if you have a more complex codebase.

Your plan could involve making significant changes to your codebase while still targeting .NET Framework 4.6.2, making this a more structured version of the previous approach. How you go about executing your plan will be dependent on your codebase.

### Mixing Approaches

It's likely that you'll mix the above approaches on a per-project basis. You should do what makes the most sense to you and for your codebase.

## Porting your Tests

The best way to make sure everything works when you've ported your code is to test your code as you port it to .NET Core. To do this, you'll need to use a testing framework that will build and run tests for .NET Core. Currently, you have three options:

* [xUnit](https://xunit.github.io/)
   - [Getting Started](http://xunit.github.io/docs/getting-started-dotnet-core.html)
   - [Tool to convert an MSTest project to xUnit](https://github.com/dotnet/codeformatter/tree/master/src/XUnitConverter)
* [NUnit](http://www.nunit.org/)
  - [Getting Started](https://github.com/nunit/docs/wiki/Installation)
  - [Blog post about migrating from MSTest to NUnit](http://www.florian-rappl.de/News/Page/275/convert-mstest-to-nunit)
* [MSTest](https://msdn.microsoft.com/library/ms243147.aspx)

## Recommended Approach to Porting

Finally, porting the code itself! Ultimately, the actual porting effort will depend heavily on how your .NET Framework code is structured. That being said, here is a recommended approach which may work well with your codebase.

A good way to port your code is to begin with the "base" of your library. This may be data models or some other foundational classes and methods that everything else uses directly or indirectly.

1. Port the test project which tests the layer of your library that you're currently porting.
2. Copy over the "base" of your library into a new .NET Core project and select the version of the .NET Standard you wish to support.
3. Make any changes needed to get the code to compile. Much of this may require adding NuGet package dependencies to your `project.json` file.
4. Run tests and make any needed adjustments.
5. Pick the next layer of code to port over and repeat steps 2 and 3!

If you methodically move outward from the base of your library and test each layer as needed, porting will be a systematic process where problems are isolated to one layer of code at a time.
