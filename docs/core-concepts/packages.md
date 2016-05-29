Packages, Metapackages and Frameworks
=====================================

.NET Core is a platform of NuGet packages. Some product experiences benefit from fine-grained definition of packages while others from course-grained. To accomodate this duality, the product is distributed as a fine-grained set of packages and then described in courser chunks with a package type called a "metapackage".

.NET Core packages each support a set of target frameworks. A subset of those frameworks are existing frameworks, like `net46`. Another subset is new frameworks that can be thought of as "package-based frameworks", which establish a new model for defining frameworks. These package-based frameworks are entirely formed and defined as packages, forming a strong relationship between packages, metapackages and frameworks.

There are many package, frameworks and eventually metapackages (since they are new). This document describes how these mechanisms are used with .NET Core. They may be used differently by other products. 

Packages
========

.NET Core is split into a set of packages, which provide primitives, higher-level data types, app composition types and common utilities. Each of these packages represent a single assembly of the same name (eponymous). For example, [System.Runtime](https://www.nuget.org/packages/System.Runtime) contains System.Runtime.dll. 

There are advantages to defining packages in a fine-grained manner:

- Fine-grained packages can ship on their own schedule with relatively limited testing of other packages.
- Fine-grained packages can provide differing levels of OS and CPU support.
- Fine-grained packages can have dependencies specific to only one library.
- Apps are smaller because unreferenced packages don't becomes part of the app distribution.

Some of these benefits are only used in certain circumstances. .NET Core packages will typically ship on the same schedule with the same platform support, even though it's possible to ship each of them on separate cadences. In the case of servicing, fine-grained packages are beneficial. When a library needs to be serviced, the update can be distributed and installed as a single and small package update, and requires only the amount of process and testing required for a single library. Similarly, libraries can be ported to a new platform, one at a time, using package boundaries as the way to communicate support for the new platform. 

Some key packages:

- [System.Runtime](https://www.nuget.org/packages/System.Runtime) - The bottom-most .NET Core package, including System.Object, System.String, System.Array, System.Action and System.Collections.Generic.IList&lt;T&gt;.
- [System.Collections](https://www.nuget.org/packages/System.Collections) - A set of (primarily) generic collections, including List&lt;T&gt; and Dictionary&lt;K,V&gt;.
- [System.Net.Http](https://www.nuget.org/packages/System.Net.Http) - A set of types for HTTP network communication, including [HttpClient](http://dotnet.github.io/api/System.Net.Http.HttpClient) and [HttpResponseMessage](http://dotnet.github.io/api/System.Net.Http.HttpResponseMessage).
- [System.IO.FileSystem](https://www.nuget.org/packages/System.IO.FileSystem) - A set types for reading and writing to local or networked disk-based storage, including File and Directory.
- [System.Linq](https://www.nuget.org/packages/System.Linq) - A set types for querying objects, including Enumerable and ILookup&lt;TKey, TElement&gt;.
- [System.Reflection](https://www.nuget.org/packages/System.Reflection) - A set types for inspecting and activating types, including Assembly, TypeInfo, MethodInfo.

Packages are referenced in project.json. In the example below, the [System.Runtime](https://www.nuget.org/packages/System.Runtime/) package is referenced. 

```json
{
  "dependencies": {
    "System.Runtime": "4.1.0"
  },
  "frameworks": {
    "netstandard1.5": {}
  }
}

In most cases, you will not reference the lower-level .NET Core packages directly since you'll end up with too many packages to manage. Instead, you'll use metapackages.

Metapackages
============

Metapackages describe a set of packages that are meaningful together. By referencing a metapackage, you are, in effect, adding a reference to each of its dependent packages as a single gesture. That means that all of the libraries in those packages (refs or libs) are present in Intellisense (or similar experience) and available for deployment (libs only) for constructing your app. 

There are advantages to using metapackages:

- Provide a convenient user experience to reference a large set of fine-grained packages. 
- Provides a set of packages that are tested and work well together.

Note: The 'lib' and 'ref' terms refer to folders in NuGet packages. 'ref' folders describe the public API of a package via assembly metadata. 'lib' folders contain the implementation of that public API for a given target framework. 

The key .NET Core metapackages:

- [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App) - Describes the libraries that are part of the .NET Core distribution (.NET Core and .NET Core SDK).
- [Microsoft.NETCore.Portable.Compatibility](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) - A set of compatibility facades that enable mscorlib-based Portable Class Libraries (PCLs) to run on .NET Core.

The .NET Standard Library metapackage:

- [NETStandard.Library](https://www.nuget.org/packages/Microsoft.NETCore.App/Microsoft.NETCore.App) - Describes the libraries that are part of the ".NET Standard Library". Applies to all .NET implementations (for example, .NET Framework and Mono) that support the .NET Standard Library.

Meta-packages are referenced just like any other NuGet package in project.json. 

In the example below, the NETStandard.Library meta package is referenced, which is used for creating libraries that are portable across .NET runtimes.

```json
{
  "dependencies": {
    "NETStandard.Library": "1.5.0"
  },
  "frameworks": {
    "netstandard1.5": {}
  }
}
```

In the example below, the `Microsoft.NETCore.App` metapackage is referenced, which is used for creating apps and libraries that are intended to full take advantage of but only run on .NET Core. It provides access to a larger set of libraries than are provided by `NETStandard.Library`.

```json
{
  "dependencies": {
    "Microsoft.NETCore.App": "1.0.0"
  },
  "frameworks": {
    "netcoreapp": {}
  }
}
```

Target Frameworks
=================

.NET Core packages each support a set of target frameworks, declared with target framework folders (within the lib and ref folders mentioned earlier). Target frameworks describe an available API set (and potentially other characteristics) that you can rely on when you target a given framework. They are versioned as new APIs are added.

For example, [System.IO.FileSystem](https://www.nuget.org/packages/System.IO.FileSystem) supports the following target frameworks:

- net46
- netstandard1.3
- 6 different Xamarin platforms (for example, xamarinios10)

It is useful to contrast the first two of these target frameworks, since they are examples of the two different ways that target frameworks are defined.

The `net46` framework represents the available APIs in the .NET Framework 4.6.1. You can compile NuGet . This is how all framework targets have traditionally worked.

The `netstandard1.3` framework is a package-based target framework, so doesn't expose or describe any APIs in the absense of packages that target that framework. It is the interplay of the framework and the packages that define the available API.

Package-based Target Frameworks
===============================

There is a two-way relationship between frameworks and .NET Core packages. The first part is defining the API available for a given framework, for example 'netstandard1.3'. Continuing with that example, the .NET Core packages target `netstandard1.3` or other compatible frameworks, such as `netstandard1.0`. The APIs exposed for `netstandard1.3` or compatible frameworks end up defining the framework. Without the packages being present, there would be no APIs available for the framework. 

The second part of the relationship is asset selection. Packages can contain assets for multiple frameworks. Given a reference to a set of packages and/or metapackages, the target framework is needed to determine which asset that should be selected, for example `net46` or `netstandard1.3`.

It is an interesting question of where a package-based target framework's definition ends and where consumption of that definition starts. There isn't a single answer for that. The answer is a function of a given project.json file. Your dependencies create your view of the framework, independent of the publisher(s) of those dependencies.

The two primary package-based target frameworks used with .NET Core are:

- `netstandard`
- `netcoreapp`

The `netstandard` framework represents the APIs defined by and built on top of the .NET Standard Library. Libraries that are intended to run on multiple runtimes should use this target. They will be supported on any .NET Standard compliant runtime, such as .NET Core, .NET Framework and Mono/Xamarin. Each runtime supports a set of .NET Standard versions, depending on which APIs they implement. 

The `NETStandard.Library` metapackage targets the `netstandard` framework. The most common way to target `netstandard` will be by referencing this metapackage. It provides access to ~40 .NET  libraries and their associated APIs. You can reference additional packages that target `netstandard` to get access to more APIs.

The `netcoreapp` framework represents the APIs compatible with the .NET Core distribution, which you can get via the .NET Core installer or a package manager. It matches the `Microsoft.NETCore.App` metapackage. .NET Core apps should use this framework, as should libraries that require significant funtionality beyond .NET Standard.

The netstandard framework represents and exposes the libraries (and the underlying APIs) in the NETStandard.Library meta-package. Other packages layer on top and can target multiple versions of netstandard. netstandard includes the most and most important platform-specific implementations for .NET Core. As a result, it defines which platforms a new netstandard version supports at its maximum.

Everytime there is a new major or minor release of the NetStandard.Library meta-package, there will be a subset of the underlying packages that include a new netstandard folder. That's the change that creates the new netstandard versions. Packages that don't expose new APIs will not include these new folders, unless they take an implementation dependency on a new package that does add new APIs.

In most cases, higher-level packages, from Microsoft or 3rd parties, will not need to support multiple netstandard versions, but will target the lowest netstandard version that satisfies their API dependency and platform breadth needs. If you need to get access to newer APIs in later netstandard versions but want to maintain their platform support, you can target multiple netstandard versions, but can continue to offer the same API (where possible) for developers to consume. Many existing NuGet packages already do this, across net20, net46 and PCL, for example.

Most .NET Core packages will use the new ".NET Standard" (netstandard) framework, which is intended to be supported on all modern .NET platforms. They may also support other frameworks.

Target Frameworks
-----------------




Other .NET platforms could support this framework, but are not expected to.


The [NETStandard.Library version](versioning.md) matches the highest `netstandard` version it supports. The framework reference in project.json is used to select the correct assets from the underlying packages. In this case, `netstandard1.5` assets are required, as opposed to `netstandard1.4` or `net46`, for example. The framework and metapackage references in project.json do not need to match. For example, the following project.json is also valid.

```json
{
  "dependencies": {
    "NETStandard.Library": "1.5.0"
  },
  "frameworks": {
    "netstandard1.3": {}
  }
}
```

It may seem strange to target `netstandard1.3` but use the 1.5.0 version of `NETStandard.Library`. It is a valid use-case, since the metapackage maintains support for older `netstandard` versions. It could be the case you've standardized on the 1.5.0 version of the metapackage and use it for all your libraries, which target a variety of `netstandard` versions. With this approach, you only need to restore `NETStandard.Library` 1.5.0 and not earlier versions. The reverse would not be valid. You cannot use `netstandard1.5` assets with the 1.3.0 version of NETStandard.Library. 
