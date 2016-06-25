# Analyzing your 3rd Party Dependencies

The first step in the porting process is to understand your third party dependencies, figure out which of them (if any), don't run on .NET Core, and develop a contingency plan for those which don't run on .NET Core.

## Prerequisites

This article will assume you are using Windows and Visual Studio.  For your NuGet package dependencies, you may also wish to download the [Nuget Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer).

## Analyzing NuGet Packages

Analyzing NuGet packages for portability is very easy.  Because a NuGet package is itself a set of folders which contain platform-specific assemblies, all you have to do is check to see if there is a folder which contains a .NET Core assembly.

Inspecting NuGet Package folders is easiest with the [NuGet Package Explorer](https://github.com/NuGetPackageExplorer/NuGetPackageExplorer).  Here's how to do it.

1. Open the NuGet Package Explorer.
2. Click "Open package from online feed".
3. Search for the name of the package.
4. Expand the "lib" folder on the right-hand side and look at folder names.

You can also see what a package supports on [nuget.org](nuget.org) under the **Dependencies** section of the page for that package.

In either case, you'll need to look for a folder or entry on [nuget.org](nuget.org) with any of the following names:

```
netstandard1.0
netstandard1.1
netstandard1.2
netstandard1.3
netstandard1.4
netstandard1.5
netstandard1.6
netcoreapp1.0
```

These are the Target Framework Monikers (TFM for short) which map to versions of [The .NET Standard Library](../standard/library.md).  Note that `netcoreapp1.0`, while compatible, is for applications and not libraries.  Although there's nothing wrong with using a library which is `netcoreapp1.0`-based, that library may not be intended for anything *other* than consumption by other `netcoreapp1.0` applications.

There are also some legacy TFMs used in pre-release versions of .NET Core that may also be compatible:

```
dnxcore50
dotnet1.0
dotnet1.1
dotnet1.2
dotnet1.3
dotnet1.4
dotnet1.5
```

**While these may work with your code, there is no guarantee of compatibility**.  Be on the lookout for when these packages update to The .NET STandard Library.

### What to do when your NuGet package dependency doesn't run on .NET Core

There are a few things you can do if a NuGet package you depend on won't run on .NET Core.

1. If the project is open source and hosted somewhere like GitHub, you can engage the developer(s) directly.
2. You can contact the author directly on nuget.org by searching for the package and clicking "Contact Owners" on the left hand side of the package's page.
3. You can look for another package that runs on .NET Core which accomplishes the same task as the package you were using.
4. You can attempt to write the code the package was doing yourself.
5. You could eliminate the dependency on the package by changing the functionality of your app, at least until a compatible version of the package becomes available.

If you're unable to resolve your issue with any of the above, you may have to port to .NET Core at a later date.

## Analyzing Dependencies which aren't NuGet Packages

You may have a dependency that isn't a NuGet package, such as a `.dll` in the filesystem.  The only way to determine the portability of that dependency is to run the [ApiPort tool](https://github.com/Microsoft/dotnet-apiport/blob/master/docs/HowTo/Introduction.md).

## Next steps

If you're porting a library, check out [Porting your Lbraries](libraries.md).