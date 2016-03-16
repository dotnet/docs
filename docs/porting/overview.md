# Overview of the Porting Process

By [Phillip Carter](https://github.com/cartermp)

If you've got code running on .NET Framework you may be interested in running your code on .NET Core.  This article covers evaluate if porting to .NET Core is reasonable for you, an overview of the porting process, and a list of the tools you may use to port.

## Should you port?

The first thing you need to do is evaluate if it makes sense to port .NET Framework code over to .NET Core in the first place.  .NET Core offers some attractive capabilities, such as:

- Using ASP.NET Core to write great web apps and services which you can write and deploy on your OS of choice
- Console applications that can be ahead-of-time (AOT) compiled into native code with minimal dependencies
- The ability to deploy apps and services app-local and with different versions of .NET Core side-by-side
- The ability to write a UWP app that will run on multiple Windows 10 devices

Your code could be a good candidate for porting to .NET Core if...

- Your code is a library and you want to expand its reach
- You have a compelling business case to run code on more than just Windows
- You want to take advantage of app-local deployment and build self-contained console applications
- You have expertise on non-Windows platforms you wish to leverage
- You're looking for an opportunity to implement an architectural change for your services (e.g. a monolithic service to microservices deployed to containers)
- You love new open source technology and want to cut your teeth on .NET Core

Your code may not be a good candidate for porting if...

- Your code is heavily tied to a Windows GUI or depends on Windows-specific features
- You have no business needs or expertise which would warrant running on more than Windows
- You don't have a need for app-local deployment or self-contained console apps
- You're happy with your code running on .NET Framework as it is today

If it makes sense to port at this time, then read on!

## Overview of the Porting Process

The recommended process for porting follows a series of steps.  Here's a short overview of the process in general.  There will be other specific steps to take when porting libraries, apps and services.

1. Identify and account for your third-party dependencies.

   This will involve understanding what your 3rd party dependencies are, how you depend on them, how to see if they also run on .NET Core, and steps you can take if they don't.
   
2. Change all projects you wish to port to target .NET Framework 4.6.1.

   This ensures that you can use API alternatives for .NET Framework-specific targets in the cases where .NET Core can't support a particular API.
   
3. Use the API Portability Analyzer to analyze your assemblies and develop a plan based on its results.

   The API Portability Analyzer tool will analyze your compiled assemblies and generate a report which shows a high-level portability summary and a breakdown of each API you're using that isn't available on .NET Core.  You can use this report alongside an analysis of your codebase to develop a plan for how you'll port your code over.
   
4. Port your tests over to xUnit and NUnit.

   MSTest doesn't support .NET Core, so you'll have to use either xUnit or NUnit to test your .NET Core targets.  Because porting to .NET Core is such a big change to your codebase, it's highly recommended to get your tests ported so that you can run tests as you port projects over.
   
5. Determine which project system in Visual Studio is appropriate for your needs.

   There are now two project systems in Visual Studio which support .NET Core: the traditional project system and the new `xproj` project system.  Both offer capabilities that the other does not, so it's critical that you pick the correct project system.  This will be covered in other articles.
   
6. Execute your plan for porting!

   Each porting article covers a recommended overall approach, but because each codebase is different you may have a plan that differs considerably from what is generally recommended.

## Tools needed

Here's a short list of the tools you'll likely use when porting to .NET Core:

* NuGet - [client](https://dist.nuget.org/index.html) or [Nuget Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer), the package manager for the .NET Platform.
* ApiPort - [command line tool](https://github.com/Microsoft/dotnet-apiport/releases) or [Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b), a toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core, with an assembly-by-assembly breakdown of issues.

## Next steps

[Analyzing your 3rd party dependencies.](third-party-deps.md)
   