---
title: Port libraries to .NET
description: Learn how to port library projects from the .NET Framework to .NET.
author: cartermp
ms.date: 03/04/2021
---
# Port .NET Framework libraries to .NET

Learn how to port .NET Framework library code to .NET, where it runs cross-platform and expands the reach of the apps that use it.

## Prerequisites

This article assumes that you:

- Are using Visual Studio 2019 or later?
  - .NET 5 requires Visual Studio 2019 (v16.9) or later.
  - .NET Core 3.1 requires Visual Studio 2019 (v16.4) or later.
- Understand the [recommended porting process](index.md).
- Have resolved any issues with [third-party dependencies](third-party-deps.md).

Familiarize yourself with the content of the following articles:

- [.NET Standard.](../../standard/net-standard.md)\
This article describes the formal specification of .NET APIs that are intended to be available on all .NET implementations.

- [Develop libraries with the .NET CLI.](../tutorials/libraries.md)\
This article explains how to write libraries using the .NET CLI.

- [.NET project SDKs.](../project-sdk/overview.md)\
This article describes the SDK-style project file format.

- [Analyze your dependencies to port code from .NET Framework to .NET.](third-party-deps.md)\
This article discusses the portability of third-party dependencies, and what to do when a NuGet package dependency doesn't run on .NET.

## Retarget to .NET Framework 4.7.2

If your code isn't targeting .NET Framework 4.7.2, we recommended that you retarget to .NET Framework 4.7.2. This ensures the availability of the latest API alternatives for cases where .NET Standard doesn't support existing APIs.

For each of the projects you wish to port, do the following in Visual Studio:

01. Right-click on the project and select **Properties**.
01. In the **Target Framework** dropdown, select **.NET Framework 4.7.2**.
01. Recompile the project.

Because your projects now target .NET Framework 4.7.2, use that version of the .NET Framework as your base for porting code.

## Determine portability

The next step is to run the API Portability Analyzer (ApiPort) to generate a portability report for analysis.

Make sure you understand the [API Portability Analyzer (ApiPort)](../../standard/analyzers/portability-analyzer.md) and how to generate portability reports for targeting .NET. How you do this likely varies based on your needs and personal tastes. The following sections detail a few different approaches. You may find yourself mixing steps of these approaches depending on how your code is structured.

### Deal primarily with the compiler

This approach works well for small projects or projects that don't use many .NET Framework APIs. The approach is simple:

01. Optionally, run ApiPort on your project. If you run ApiPort, gain knowledge from the report on issues you'll need to address.
01. Copy all of your code over into a new .NET project.
01. While referring to the portability report (if generated), solve compiler errors until the project fully compiles.

Although it's unstructured, this code-focused approach often resolves issues quickly. A project that contains only data models might be an ideal candidate for this approach.

### Stay on the .NET Framework until portability issues are resolved

This approach might be the best if you prefer to have code that compiles during the entire process. The approach is as follows:

01. Run ApiPort on a project.
01. Address issues by using different APIs that are portable.
01. Take note of any areas where you're prevented from using a direct alternative.
01. Repeat the prior steps for all projects you're porting until you're confident each is ready to be copied over into a new .NET project.
01. Copy the code into a new .NET project.
01. Work out any issues where you noted that a direct alternative doesn't exist.

This careful approach is more structured than simply working out compiler errors, but it's still relatively code-focused and has the benefit of always having code that compiles. The way you resolve certain issues that couldn't be addressed by just using another API varies greatly. You may find that you need to develop a more comprehensive plan for certain projects, which is covered in the next approach.

### Develop a comprehensive plan of attack

This approach might be best for larger and more complex projects, where restructuring code or completely rewriting certain areas of code might be necessary to support .NET. The approach is as follows:

01. Run ApiPort on a project.
01. Understand where each non-portable type is used and how that affects overall portability.

    - Understand the nature of those types. Are they small in number but used frequently? Are they large in number but used infrequently? Is their use concentrated, or is it spread throughout your code?
    - Is it easy to isolate code that isn't portable so that you can deal with it more effectively?
    - Do you need to refactor your code?
    - For those types that aren't portable, are there alternative APIs that accomplish the same task? For example, if you're using the <xref:System.Net.WebClient> class, use the <xref:System.Net.Http.HttpClient> class instead.
    - Are there different portable APIs available to accomplish a task, even if it's not a drop-in replacement? For example, if you're using <xref:System.Xml.Schema.XmlSchema> to parse XML but don't require XML schema discovery, you could use <xref:System.Xml.Linq> APIs and implement parsing yourself instead of relying on an API.

01. If you have assemblies that are difficult to port, is it worth leaving them on .NET Framework for now? Here are some things to consider:

    - You may have some functionality in your library that's incompatible with .NET because it relies too heavily on .NET Framework or Windows-specific functionality. Is it worth leaving that functionality behind for now and releasing a temporary .NET version of your library with fewer features until resources are available to port the features?
    - Would a refactor help?

01. Is it reasonable to write your own implementation of an unavailable .NET Framework API?

    You could consider copying, modifying, and using code from the [.NET Framework reference source](https://github.com/Microsoft/referencesource). The reference source code is licensed under the [MIT License](https://github.com/Microsoft/referencesource/blob/master/LICENSE.txt), so you have significant freedom to use the source as a basis for your own code. Just be sure to properly attribute Microsoft in your code.

01. Repeat this process as needed for different projects.

The analysis phase could take some time depending on the size of your codebase. Spending time in this phase to thoroughly understand the scope of changes needed and to develop a plan usually saves you time in the end, particularly if you have a complex codebase.

Your plan could involve making significant changes to your codebase while still targeting .NET Framework 4.7.2. This is a more structured version of the previous approach. How you go about executing your plan is dependent on your codebase.

### Mixed approach

It's likely that you'll mix the above approaches on a per-project basis. Do what makes the most sense to you and for your codebase.

## Port your tests

The best way to make sure everything works when you've ported your code is to test your code as you port it to .NET. To do this, you'll need to use a testing framework that builds and runs tests for .NET. Currently, you have three options:

- [xUnit](https://xunit.net/)
  - [Getting Started](https://xunit.net/docs/getting-started/netcore/cmdline)
  - [Tool to convert an MSTest project to xUnit](https://github.com/dotnet/codeformatter/tree/main/src/XUnitConverter)
- [NUnit](https://nunit.org/)
  - [Getting Started](https://github.com/nunit/docs/wiki/Installation)
  - [Blog post about migrating from MSTest to NUnit](https://www.florian-rappl.de/News/Page/275/convert-mstest-to-nunit)
- [MSTest](/visualstudio/test/unit-test-basics)

## Recommended approach

Ultimately, the porting effort depends heavily on how your .NET Framework code is structured. A good way to port your code is to begin with the *base* of your library, which is the foundational components of your code. This might be data models or some other foundational classes and methods that everything else uses directly or indirectly.

01. Port the test project that tests the layer of your library that you're currently porting.
01. Copy over the base of your library into a new .NET project and select the version of .NET Standard you wish to support.
01. Make any changes needed to get the code to compile. Much of this may require adding NuGet package dependencies to your *csproj* file.
01. Run the tests and make any needed adjustments.
01. Pick the next layer of code to port over and repeat the prior steps.

If you start with the base of your library and move outward from the base and test each layer as needed, porting is a systematic process where problems are isolated to one layer of code at a time.

## Next steps

>[!div class="nextstepaction"]
>[Organize projects for .NET](project-structure.md)
