---
title: Creating a NuGet Package with Cross Platform Tools
description: Creating a NuGet Package with Cross Platform Tools
keywords: .NET, .NET Core, NuGet
author: cartermp
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 2f0415c1-110b-433d-87c1-ae3d543a8844
---

## How to Create a NuGet Package with Cross Platform Tools

Imagine that you just wrote an awesome new library that you would like to distribute over NuGet.  You can create a NuGet package with cross platform tools to do exactly that!  The following example assumes a library called **SuperAwesomeLibrary** which targets `netstandard1.0`.

> If you have transitive dependencies; that is, a project which depends on another project, you'll need to make sure to restore packages for your entire solution with the `dotnet restore` command before creating a NuGet package.

After ensuring packages are restored, you can navigate to the directory where a library lives:

`$ cd src/SuperAwesomeLibrary`

Then it's just a single command from the command line:
    
`$ dotnet pack`

Your `/bin/Debug` folder will now look like this:

```
$ ls bin/Debug

netstandard1.0/
SuperAwesomeLibrary.1.0.0.nupkg
SuperAwesomeLibrary.1.0.0.symbols.nupkg
```

And now you have the necessary files to publish a NuGet package!

> For .NET Core 1.0, libraries are expected to be distributed as NuGet packages. This can only be done with `dotnet pack` when using the .NET CLI.  It is important that you use `dotnet pack` instead of `dotnet publish` for this.  Using `dotnet publish` for a library will result in an error.

If you want to build a NuGet package with release mode binaries, all you need to do is add the `-c`/`--configuration` switch and use `release` as the argument.

`$ dotnet pack --configuration release`

And now you'll have a new `release` folder in `/bin` containing your NuGet package:

```
$ ls bin/release

netstandard1.0/
SuperAwesomeLibrary.1.0.0.nupkg
SuperAwesomeLibrary.1.0.0.symbols.nupkg
```