---
title: Packages, Metapackages and Frameworks
description: Packages, Metapackages and Frameworks
keywords: .NET, .NET Core
author: richlander
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 609b0845-49e7-4864-957b-21ffe1b93bf2
---

# Packages, Metapackages and Frameworks

.NET Core is a platform made of NuGet packages. Some product experiences benefit from fine-grained definition of packages while others from coarse-grained. To accommodate this duality, the product is distributed as a fine-grained set of packages and then described in coarser chunks with a package type informally called a "metapackage".

Each of the .NET Core packages support being run on multiple .NET runtimes, represented as
frameworks. Some of those frameworks are traditional frameworks, like `net46`, representing the .NET Framework. Another set is new frameworks that can be thought of as "package-based frameworks", which establish a new model for defining frameworks. These package-based frameworks are entirely formed and defined as packages, forming a strong relationship between packages and frameworks.

## Packages

.NET Core is split into a set of packages, which provide primitives, higher-level data types, app composition types and common utilities. Each of these packages represent a single assembly of the same name. For example, [System.Runtime](https://www.nuget.org/packages/System.Runtime) contains System.Runtime.dll. 

There are advantages to defining packages in a fine-grained manner:

- Fine-grained packages can ship on their own schedule with relatively limited testing of other packages.
- Fine-grained packages can provide differing OS and CPU support.
- Fine-grained packages can have dependencies specific to only one library.
- Apps are smaller because unreferenced packages don't become part of the app distribution.

Some of these benefits are only used in certain circumstances. For example, NET Core packages will typically ship on the same schedule with the same platform support. In the case of servicing, fixes can be distributed and installed as small single package updates. Due to the narrow scope of change, the validation and time to make a fix available is limited to what is needed for a single library.

The following is a list of the key NuGet packages for .NET Core:

- [System.Runtime](https://www.nuget.org/packages/System.Runtime) - The most fundamental .NET Core package, including [Object](http://docs.microsoft.com/dotnet/core/api/System.Object), [String](http://docs.microsoft.com/dotnet/core/api/System.String), [Array](http://docs.microsoft.com/dotnet/core/api/System.Array), [Action](http://docs.microsoft.com/dotnet/core/api/System.Action) and [IList&lt;T&gt;](http://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IList-1).
- [System.Collections](https://www.nuget.org/packages/System.Collections) - A set of (primarily) generic collections, including [List&lt;T&gt;](http://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.List-1) and [Dictionary&lt;K,V&gt;](http://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.Dictionary-2).
- [System.Net.Http](https://www.nuget.org/packages/System.Net.Http) - A set of types for HTTP network communication, including [HttpClient](http://docs.microsoft.com/dotnet/core/api/System.Net.Http.HttpClient) and [HttpResponseMessage](http://docs.microsoft.com/dotnet/core/api/System.Net.Http.HttpResponseMessage).
- [System.IO.FileSystem](https://www.nuget.org/packages/System.IO.FileSystem) - A set of types for reading and writing to local or networked disk-based storage, including [File](http://docs.microsoft.com/dotnet/core/api/System.IO.File) and [Directory](http://docs.microsoft.com/dotnet/core/api/System.IO.Directory).
- [System.Linq](https://www.nuget.org/packages/System.Linq) - A set of types for querying objects, including Enumerable and [ILookup&lt;TKey, TElement&gt;](http://docs.microsoft.com/dotnet/core/api/System.Linq.ILookup-2).
- [System.Reflection](https://www.nuget.org/packages/System.Reflection) - A set of types for loading, inspecting and activating types, including [Assembly](http://docs.microsoft.com/dotnet/core/api/System.Reflection.Assembly), [TypeInfo](http://docs.microsoft.com/dotnet/core/api/System.Reflection.TypeInfo) and [MethodInfo](http://docs.microsoft.com/dotnet/core/api/System.Reflection.MethodInfo).

Packages are referenced in project.json. In the example below, the [System.Runtime](https://www.nuget.org/packages/System.Runtime/) package is referenced. 

```json
{
  "dependencies": {
    "System.Runtime": "4.1.0"
  },
  "frameworks": {
    "netstandard1.6": {}
  }
}
```

In most cases, you will not reference the lower-level .NET Core packages directly since you'll end up with too many packages to manage. Instead, you'll reference a metapackage.

## Metapackages

Metapackages are a NuGet package convention for describing a set of packages that are meaningful together. They represent this set of packages by making them dependencies. They can optionally establish a
framework for this set of packages by specifying a framework. 

By referencing a metapackage, you are, in effect, adding a reference to each of its dependent packages as a single gesture. That means that all of the libraries in those packages (refs or libs) are available for IntelliSense (or similar experience) and for publishing (libs only) your app. 

Note: The 'lib' and 'ref' terms refer to folders in NuGet packages. 'ref' folders describe the public API of a package via assembly metadata. 'lib' folders contain the implementation of that public API for a given
framework. 

There are advantages to using metapackages:

- Provides a convenient user experience to reference a large set of fine-grained packages. 
- Defines a set of packages (including specific versions) that are tested and work well together.

The .NET Standard Library metapackage:

- [NETStandard.Library](https://www.nuget.org/packages/NETStandard.Library) - Describes the libraries that are part of the ".NET Standard Library". Applies to all .NET implementations (for example, .NET Framework, .NET Core and Mono) that support the .NET Standard Library. Establishes the 'netstandard' framework.

These are the key .NET Core metapackages:

- [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App) - Describes the libraries that are part of the .NET Core distribution. Establishes the [`.NETCoreApp` framework](https://github.com/dotnet/core-setup/blob/master/pkg/projects/Microsoft.NETCore.App/Microsoft.NETCore.App.pkgproj). Depends on the smaller `NETStandard.Library`.
- [Microsoft.NETCore.Portable.Compatibility](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) - A set of compatibility facades that enable mscorlib-based Portable Class Libraries (PCLs) to run on .NET Core.

Metapackages are referenced just like any other NuGet package in project.json. 

In the following example, the `NETStandard.Library` meta package is referenced, which is used for creating libraries that are portable across .NET runtimes.

```json
{
  "dependencies": {
    "NETStandard.Library": "1.6.0"
  },
  "frameworks": {
    "netstandard1.6": {}
  }
}
```

In the following example, the `Microsoft.NETCore.App` metapackage is referenced, which is used for creating apps and libraries that are intended to run on and take full advantage of .NET Core. It provides access to a larger set of libraries than are provided by `NETStandard.Library`.

```json
{
  "dependencies": {
    "Microsoft.NETCore.App": "1.0.0"
  },
  "frameworks": {
    "netcoreapp1.0": {}
  }
}
```

## Frameworks

.NET Core packages each support a set of frameworks, declared with framework folders (within the lib and ref folders mentioned earlier). Frameworks describe an available API set (and potentially other characteristics) that you can rely on when you target a given framework. They are versioned as new APIs are added.

For example, [System.IO.FileSystem](https://www.nuget.org/packages/System.IO.FileSystem) supports the following frameworks:

- .NETFramework,Version=4.6
- .NETStandard,Version=1.3
- 6 Xamarin platforms (for example, xamarinios10)

It is useful to contrast the first two of these frameworks, since they are examples of the two different ways that frameworks are defined.

The `.NETFramework,Version=4.6` framework represents the available APIs in the .NET Framework 4.6. You can produce libraries  compiled with the .NET Framework 4.6 reference assemblies and then distribute those libraries in NuGet packages in a net46 lib folder. It will be used for apps that target the .NET Framework 4.6 or that are compatible with it. This is how all frameworks have traditionally worked.

The `.NETStandard,Version=1.3` framework is a package-based framework. It relies on packages that target the framework to define and expose APIs in terms of the framework.

## Package-based Frameworks

There is a two-way relationship between frameworks and packages. The first part is defining the APIs available for a given framework, for example `netstandard1.3`. Packages that target `netstandard1.3` (or compatible frameworks, like `netstandard1.0`) define the APIs available for `netstandard1.3`. That may sound like a circular definition, but it isn't. By virtue of being "package-based", the API definition for the framework comes from packages. The framework itself doesn't define any APIs.

The second part of the relationship is asset selection. Packages can contain assets for multiple frameworks. Given a reference to a set of packages and/or metapackages, the framework is needed to determine which asset should be selected, for example `net46` or `netstandard1.3`. It is important to select the correct asset. For example, a `net46` asset is not likely to be compatible with .NET Framework 4.0 or .NET Core 1.0.

![Package-based Framework Composition](./media/packages/package-framework.png)

You can see this relationship in the image above. The *API* targets and defines the *framework*. The *framework* is used for *asset selection*. The *asset* gives you the API.

It is an interesting question of where a package-based framework's definition ends and where consumption of that definition starts. One can consider your view of the framework as a function of a given project.json file. Your dependencies create your view of the framework, independent of the publisher(s) of those dependencies.

The two primary package-based frameworks used with .NET Core are:

- `netstandard`
- `netcoreapp`

### .NET Standard

The .NET Standard (TFM: `netstandard`) framework represents the APIs defined by and built on top of the [.NET Standard Library](../standard/library.md). Libraries that are intended to run on multiple runtimes should target this framework. They will be supported on any .NET Standard compliant runtime, such as .NET Core, .NET Framework and Mono/Xamarin. Each of these runtimes supports a set of .NET Standard versions, depending on which APIs they implement. 

The `NETStandard.Library` metapackage targets the `netstandard` framework. The most common way to target `netstandard` is by referencing this metapackage. It describes and provides access to the ~40 .NET  libraries and associated APIs that define the .NET Standard Library. You can reference additional packages that target `netstandard` to get access to additional APIs.

A given [NETStandard.Library version](versions/index.md) matches the highest `netstandard` version it exposed (via its closure). The framework reference in project.json is used to select the correct assets from the underlying packages. In this case, `netstandard1.6` assets are required, as opposed to `netstandard1.4` or `net46`, for example. 

```json
{
  "dependencies": {
    "NETStandard.Library": "1.6.0"
  },
  "frameworks": {
    "netstandard1.6": {}
  }
}
```

The framework and metapackage references in project.json do not need to match. For example, the following project.json is valid.

```json
{
  "dependencies": {
    "NETStandard.Library": "1.6.0"
  },
  "frameworks": {
    "netstandard1.3": {}
  }
}
```

It may seem strange to target `netstandard1.3` but use the 1.6.0 version of `NETStandard.Library`. It is a valid use-case, since the metapackage maintains support for older `netstandard` versions. It could be the case you've standardized on the 1.6.0 version of the metapackage and use it for all your libraries, which target a variety of `netstandard` versions. With this approach, you only need to restore `NETStandard.Library` 1.6.0 and not earlier versions. 

The reverse would not be valid: targeting `netstandard1.6` with the 1.3.0 version of `NETStandard.Library`. You cannot target a higher framework with a lower metapackage, since the lower version metapackage will not expose any assets for that higher framework. The [versioning scheme] for metapackages asserts that metapackages match the highest version of the framework they describe. By virtue of the versioning scheme, the first version of `NETStandard.Library` is v1.6.0 given that it contains `netstandard1.6` assets. v1.3.0 is used in the example above, for symmetry with the example above, but does not actually exist.

### .NET Core Application

The .NET Core Application (TFM: `netcoreapp`) framework represents the packages and associated APIs that come with the .NET Core distribution and the console application model that it provides. .NET Core apps must use this framework, due to targeting the console application model, as should libraries that intended to run only on .NET Core. Using this framework restricts apps and libraries to running only on .NET Core. 

The `Microsoft.NETCore.App` metapackage targets the `netcoreapp` framework. It provides access to ~60 libraries, ~40 provided by the `NETStandard.Library` package and ~20 more in addition. You can reference additional libraries that target `netcoreapp` or compatible frameworks, such as `netstandard`, to get access to additional APIs. 

Most of the additional libraries provided by `Microsoft.NETCore.App` also target `netstandard` given that their dependencies are satisfied by other `netstandard` libraries. That means that `netstandard` libraries can also reference those packages as dependencies. 