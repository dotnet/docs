# Analyzing your 3rd Party Dependencies

By [Phillip Carter](https://github.com/cartermp)

The first step in the porting process is to understand your third party dependencies, figure out which of them (if any), don't run on .NET Core, and develop a contingency plan for those which don't run on .NET Core.

## Prerequisites

This article will assume you are using Windows and Visual Studio.  For your NuGet package dependencies, you may also wish to download the [Nuget Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer).

## Analyzing NuGet Packages

Analyzing NuGet packages for portability is very easy.  Because a NuGet package is itself a set of folders which contain platform-specific assemblies, all you have to do is check to see if there is a folder which contains a .NET Core assembly.

There are a few different folder names that are valid for .NET Core (these are also called Target Framework Monikers, or TFMs for short).  They are:

1. `netstandard1x` or `netstandard1.x`, where `x` is a value from `0` to `5`.
2. `dotnet5x` or `dotnet5.x`, where `x` is a value from `1` to `5`.
3. `dnxcore50`

Note that the latter options, `dotnet5x` and `dnxcore50`, are legacy TFMs from the early prerelease of .NET Core.  The vast majority of NuGet packages you encounter should be `netstandard`-based.

Inspecting this is easiest with the [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer).  Here's how to do it.

1. Open the NuGet Package Explorer.
2. Click "Open package from online feed".
3. Search for the name of the package.
4. Expand the "lib" folder on the right-hand side and look for a TFM that is valid for .NET Core.

### What to do when your NuGet package dependency doesn't run on .NET Core

Oh no!  There are a few things you can do if a NuGet package you depend on won't run on .NET Core.

1. If the project is open source and hosted somewhere like GitHub, you can engage the developer(s) directly.
2. You can contact the author directly on nuget.org by searching for the package and clicking "Contact Owners" on the left hand side of the package's page.
3. You can look for another package that runs on .NET Core which accomplishes the same task as the package you were using.
4. You can attempt to write the code the package was doing yourself.
5. You could eliminate the dependency on the package by changing the functionality of your app, at least until a .NET Core version of the package becomes available.

If you're unable to resolve an incompatible 3rd party dependency, you may have to port to .NET Core at a later date.

## Analyzing Dependencies which aren't NuGet Packages

You may have an external dependency that isn't a NuGet package, such as a `.dll` in the filesystem.  You'll have to run the API Portability Analyzer tool on a project which references this `.dll`.

Because of this, it's recommended that you simply move on to the next steps, where you'll go through the process of running the tool and seeing a portability report for your projects.

## Next steps

If you're porting a library, check out [Porting your libraries](libraries.md).

If you're porting an app, check out [Porting your applications](applications.md).