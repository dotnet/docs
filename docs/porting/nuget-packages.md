# Porting NuGet Packages

This article covers how to get your ported .NET Framework code on NuGet.  Although not much has changed, there are different avenues with which you can package your code.

## Prerequisities

This article assumes that you have already ported your code to .NET Core.  If you have not done that, you can follow [Porting Your Libraries](libraries.md), as it contains relevant information if your code is a library or a framework.

Cross-platform: [.NET CLI](aka.ms/dotnetcoregs)

## Using the Cross-Platform .NET CLI to Generate a NuGet Package

With the .NET CLI, you can build a NuGet package on your OS of choice.

For example, imagine you had a solution with two projects: `Package.Core` and `Package`.  `Package` is where all the public APIs live, and `Package.Core` is where all the executing code is placed.  This package is based on .NET Standard 1.5.

Navigate to the `Package` directory:

```$ cd Package```

And simply build your package for release!

```$ dotnet pack -c release```

You can inspect the generated package data as such:

```
$ cd bin/release && ls
Package.CSharp.1.0.0.nupkg Package.CSharp.1.0.0.symbols.nupkg netstandard1.5
```

The three artifacts are the `.nupkg` and symbols for NuGet, and the `netstandard` folder containing the `.dll` and `.pdb` files.  You can now upload to NuGet by heading over to [nuget.org](nuget.org), optionally registering for an account, and using the Package Upload UI.

## Other Scenarios

If you wish to create a NuGet package for other scenarios, the [official NuGet documentation](https://docs.nuget.org/create) contains all of the information you need.