# Overview of the Porting Process

By [Phillip Carter](https://github.com/cartermp)

If you've got code running on the .NET Framework, you may be interested in running your code on .NET Core.  This article covers an overview of the porting process and a list of the tools you may find helpful when porting to .NET Core.

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

* NuGet - [Nuget Client](https://dist.nuget.org/index.html) or [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer), the package manager for the .NET Platform.
* Api Portability Analyzer - [command line tool](https://github.com/Microsoft/dotnet-apiport/releases) or [Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/1177943e-cfb7-4822-a8a6-e56c7905292b), a toolchain that can generate a report of how portable your code is between .NET Framework and .NET Core, with an assembly-by-assembly breakdown of issues.  See [Tooling to help you on the process](tooling.md) for more information.
* Reverse Package Search - A [useful web service](https://packagesearch.azurewebsites.net) that allows you to search for a type and find packages containing that type.

## Next steps

[Analyzing your third-party dependencies.](third-party-deps.md)
   