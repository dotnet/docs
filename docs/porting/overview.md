# Overview of the Porting Process

By [Phillip Carter](https://github.com/cartermp)

If you've got code running on .NET Framework you may be interested in running your code on .NET Core.  This article covers evaluating if porting to .NET Core is feasible for you, an overview of the porting process, and a list of the tools you may use to port.

## Should you port?

The first thing you need to do is evaluate if it makes sense to port .NET Framework code over to .NET Core in the first place. .NET Core offers some attractive capabilities, such as:

- Using ASP.NET Core and .NET Core to write great web apps and services which you can write and deploy on OS X, supported Linux distributions, or Windows
- The ability to deploy apps and services with different versions of the .NET Core runtime installed side-by-side
- The ability to write a UWP app that will run on multiple Windows 10 devices
- The ability to utilize the advancements of .NET Core while your code lives seamlessly alongside .NET Framework code, such as a WinForms GUI consuming .NET Core microservices

Your code could be a good candidate for porting to .NET Core if...

- You have an ASP.NET web app that you'd like to deploy to Linux
- Your code is a library and you want to expand its reach
- You have a compelling business case to run code on more than just Windows
- You want to take advantage of more flexible deployment
- You have expertise on non-Windows platforms you wish to leverage
- You're looking for an opportunity to implement an architectural change for your services (e.g. a monolithic service to microservices deployed to containers)
- You wish to take advantage of performance advancements made in .NET Core and ASP.NET Core
- You love new open source technology and want to cut your teeth on .NET Core

Your code may not be a good candidate for porting if...

- Your code is tied to a Windows GUI or depends on Windows-specific features
- You have no business needs or expertise which would warrant running on more than Windows
- You don't have a need for more flexible deployment or self-contained console apps
- You're happy with your code running on .NET Framework as it is today
- Your code depends heavily on COM interop

If it makes sense to port, then read on!

## Overview of the Porting Process

The recommended process for porting follows a series of steps.  Here's a short overview of the process in general.  Each of these parts of the process are covered in more detail in further articles.

1. Identify and account for your third-party dependencies.

   This will involve understanding what your third-party dependencies are, how you depend on them, how to see if they also run on .NET Core, and steps you can take if they don't.
   
2. Change all projects you wish to port to target .NET Framework 4.6.1.

   This ensures that you can use API alternatives for .NET Framework-specific targets in the cases where .NET Core can't support a particular API.
   
3. Use the [API Portability Analyzer tool](tooling.md) to analyze your assemblies and develop a plan based on its results.

   The API Portability Analyzer tool will analyze your compiled assemblies and generate a report which shows a high-level portability summary and a breakdown of each API you're using that isn't available on .NET Core.  You can use this report alongside an analysis of your codebase to develop a plan for how you'll port your code over.
   
4. Port your tests over to xUnit and NUnit.

   MSTest doesn't support .NET Core, so you'll have to port your tests to either xUnit or NUnit if you wish to test your .NET Core targets.  Because porting to .NET Core is such a big change to your codebase, it's highly recommended to get your tests ported so that you can run tests as you port code over.
   
5. Determine which project system in Visual Studio is appropriate for your needs.

   There are now two project systems in Visual Studio which support .NET Core: the traditional project system and the new `xproj` project system.  Both offer capabilities that the other does not, so it's critical that you pick the correct project system.  Details on this decision can be found in [Porting your libraries](libraries.md) and [Porting your applications](applications.md).
   
6. Execute your plan for porting!

## Tools to help

Here's a short list of the tools you'll likely use when porting to .NET Core:

* NuGet - [client](https://dist.nuget.org/index.html) or [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer), the package manager for the .NET Platform.
* ApiPort - [command line tool](https://github.com/Microsoft/dotnet-apiport/releases) or [Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b), a toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core, with an assembly-by-assembly breakdown of issues.
* Reverse Package Search - A [useful web service](https://packagesearch.azurewebsites.net) that allows you to search for a type and find packages containing that type.

## Aside: Co-evolving your .NET Core and .NET Framework code

.NET Framework is the best way to build applications for the Windows platform.  As such, there's a good chance that you have significant amounts of code that is simply not applicable when considering porting to .NET Core.  And that's just fine!  The introduction of .NET Core opens up even more possibilities for your existing assets.

Imagine being able to continue using .NET Framework and Windows for your application, but being able to build and deploy different services you consume with the freedom that .NET Core offers.  A WPF GUI could consume services written in .NET Core, and the code for both the GUI and the services could live in the same Visual Studio solution.  This would allow a seamless debugging experience while allowing you to then deploy those services to Linux in Docker containers.  This kind of scenario is something we're excited to enable with .NET Core.

.NET Core also offers binary sharing, allowing you to write code once that is guaranteed to run on both your .NET Framework code and your .NET Core code.  This binary compatibility, which is covered by the [.NET Platform Standard](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md), allows you to continue to create components of your system in a modular way.

## Next steps

[Analyzing your third-party dependencies.](third-party-deps.md)
   