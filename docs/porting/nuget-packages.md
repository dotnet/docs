# Porting NuGet Packages

This article covers how to get your ported .NET Framework code to NuGet.  Although the packaging format has not changed, your code has not fundamentally changed with .NET Core code (compared with .NET Framework code), there are different avenues with which you can package your code.

## Prerequisities

This article assumes that you have already ported your code to .NET Core.  If you have not done that, you can follow [Porting Your Libraries](libraries.md), as it contains relevant information if your code is a library or a framework.

If you wish to use cross-platform tools, you'll have to download the [.NET CLI](http://aka.ms/dotnetcoregs)

## Using the Cross-Platform .NET CLI to Generate a NuGet Package

With the .NET CLI, you can build a NuGet package on your OS of choice.

For example, imagine you had a solution with two projects based on [.NET Standard 1.5](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md#mapping-the-net-platform-standard-to-platforms): `Library.Core` and `Library`.  `Library` is where all the public APIs live, and `Library.Core` is where all the core logic is performed.

Navigate to the `Library` directory:

```$ cd Library```

And simply package you code for release!

```$ dotnet pack -c release```

You can inspect the generated package data as such:

```
$ cd bin/release && ls
Library.CSharp.1.0.0.nupkg Library.CSharp.1.0.0.symbols.nupkg netstandard1.5
```

Refer to the [NuGet docs](https://docs.nuget.org) to understand the generated files.

The three artifacts are the `.nupkg` and symbols for NuGet, and the target framework moniker (TFM) folder containing the `.dll` and `.pdb` files.  You can now upload to NuGet by heading over to [nuget.org](nuget.org), registering for an account, and using the Package Upload UI.  Alternatively, you can set up a feed at [myget.org](myget.org) for any prerelease process you may wish to have.

## Other Scenarios

If you wish to create a NuGet package for other scenarios, please consult the [official NuGet documentation](https://docs.nuget.org/create).