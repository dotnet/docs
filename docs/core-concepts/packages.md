Packages, Metapackages and Frameworks
=====================================

.NET Core is a platform of NuGet packages. Some product experiences benefit from fine-grained definition of packages while others from course-grained. To accomodate this duality, the product is distributed as a fine-grained set of packages and then described in courser chunks with a package type informally called "metapackage".

.NET Core packages each support being run on multiple .NET runtimes, represented as target frameworks. Some of those frameworks are traditional frameworks, like `net46`, representing the .NET Framework 4.6. Another set is new frameworks that can be thought of as "package-based frameworks", which establish a new model for defining frameworks. These package-based frameworks are entirely formed and defined as packages, forming a strong relationship between packages and frameworks.

Packages
========

.NET Core is split into a set of packages, which provide primitives, higher-level data types, app composition types and common utilities. Each of these packages represent a single assembly of the same name (eponymous naming). For example, [System.Runtime](https://www.nuget.org/packages/System.Runtime) contains System.Runtime.dll. 

There are advantages to defining packages in a fine-grained manner:

- Fine-grained packages can ship on their own schedule with relatively limited testing of other packages.
- Fine-grained packages can provide differing OS and CPU support.
- Fine-grained packages can have dependencies specific to only one library.
- Apps are smaller because unreferenced packages don't becomes part of the app distribution.

Some of these benefits are only used in certain circumstances. For example, NET Core packages will typically ship on the same schedule with the same platform support. In the case of servicing, fixes can be distributed and installed as small single package updates. Due to the narrow scope of change, the validation and time to make a fix avaiable is limited to what is needed for a single library.

Some key packages:

- [System.Runtime](https://www.nuget.org/packages/System.Runtime) - The bottom-most .NET Core package, including [Object](http://dotnet.github.io/api/System.Object], [System.String](http://dotnet.github.io/api/System.String), [Array](http://dotnet.github.io/api/System.Array), [Action](http://dotnet.github.io/api/System.Action) and [IList&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Generic.IList'1).
- [System.Collections](https://www.nuget.org/packages/System.Collections) - A set of (primarily) generic collections, including [List&lt;T&gt;](http://dotnet.github.io/api/System.Collections.GenericList'1) and [Dictionary&lt;K,V&gt;](http://dotnet.github.io/api/System.Collections.Generic.Dictionary'1,'2).
- [System.Net.Http](https://www.nuget.org/packages/System.Net.Http) - A set of types for HTTP network communication, including [HttpClient](http://dotnet.github.io/api/System.Net.Http.HttpClient) and [HttpResponseMessage](http://dotnet.github.io/api/System.Net.Http.HttpResponseMessage).
- [System.IO.FileSystem](https://www.nuget.org/packages/System.IO.FileSystem) - A set of types for reading and writing to local or networked disk-based storage, including File and Directory.
- [System.Linq](https://www.nuget.org/packages/System.Linq) - A set types for querying objects, including Enumerable and [ILookup&lt;TKey, TElement&gt](http://dotnet.github.io/api/System.Linq.ILookup'1,'2');.
- [System.Reflection](https://www.nuget.org/packages/System.Reflection) - A set of types for loading, inspecting and activating types, including Assembly, TypeInfo and MethodInfo.

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

In most cases, you will not reference the lower-level .NET Core packages directly since you'll end up with too many packages to manage. Instead, you'll reference a metapackages.

Metapackages
============

Metapackages are a NuGet package convention for describing a set of packages that are meaningful together. They represent this set of packages by making them dependencies. They can optionally establish a target framework for this set of packages by specifying a framework. 

By referencing a metapackage, you are, in effect, adding a reference to each of its dependent packages as a single gesture. That means that all of the libraries in those packages (refs or libs) are available for Intellisense (or similar experience) and for publishing (libs only) your app. 

There are advantages to using metapackages:

- Provide a convenient user experience to reference a large set of fine-grained packages. 
- Defines a set of packages (including specific versions) that are tested and work well together.

Note: The 'lib' and 'ref' terms refer to folders in NuGet packages. 'ref' folders describe the public API of a package via assembly metadata. 'lib' folders contain the implementation of that public API for a given target framework. 

The key .NET Core metapackages:

- [Microsoft.NETCore.App](https://www.nuget.org/packages/Microsoft.NETCore.App) - Describes the libraries that are part of the .NET Core distribution (including the libraries that are part of the .NET Core SDK). Establishes the `netcoreapp` framework. TODO: Add reference to RTM commit.
- [Microsoft.NETCore.Portable.Compatibility](https://www.nuget.org/packages/Microsoft.NETCore.Portable.Compatibility) - A set of compatibility facades that enable mscorlib-based Portable Class Libraries (PCLs) to run on .NET Core.

The .NET Standard Library metapackage:

- [NETStandard.Library](https://www.nuget.org/packages/Microsoft.NETCore.App/Microsoft.NETCore.App) - Describes the libraries that are part of the ".NET Standard Library". Applies to all .NET implementations (for example, .NET Framework, .NET Core and Mono) that support the .NET Standard Library. Establishes the 'netstandard' framework.

Meta-packages are referenced just like any other NuGet package in project.json. 

In the following example, the NETStandard.Library meta package is referenced, which is used for creating libraries that are portable across .NET runtimes.

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

In the following example, the `Microsoft.NETCore.App` metapackage is referenced, which is used for creating apps and libraries that are intended to run on and take full advantage of .NET Core. It provides access to a larger set of libraries than are provided by `NETStandard.Library`.

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

The `net46` framework represents the available APIs in the .NET Framework 4.6. You can produce libraries that were compiled with the .NET Framework 4.6 reference assemblies and then distribute those libraries in NuGet packages in a net46 lib folder. It will be used for apps that target the .NET Framework 4.6 or are compatible with it. This is how all framework targets have traditionally worked.

The `netstandard1.3` framework is a package-based target framework, so doesn't expose or describe any APIs in the absense of packages that target that framework. It is the interplay of the framework and the packages that define the set of APIs that are available when targeting the framework.

Package-based Target Frameworks
===============================

There is a two-way relationship between frameworks and packages. The first part is defining the APIs available for a given framework, for example 'netstandard1.3'. Continuing with that example, there are no APIs that are inherently part of `netstandard1.3`. All of the `netstandard1.3` APIs come from packages that target `netstandard1.3` or compatible frameworks, such as `netstandard1.0`. These packages and the APIs they expose define the framework. Again, without the presence of packages that target `netstandard1.3`, there would be no APIs available for the framework.

The second part of the relationship is asset selection. Packages can contain assets for multiple frameworks. Given a reference to a set of packages and/or metapackages, the target framework is needed to determine which asset that should be selected, for example `net46` or `netstandard1.3`. It important to select the correct asset. For example, a `net46` asset is not likely to be compatible with .NET Framework 4.0 or .NET Core 1.0.

It is an interesting question of where a package-based target framework's definition ends and where consumption of that definition starts. There isn't a crisp answer for that. The answer is a function of a given project.json file. Your dependencies create your view of the framework, independent of the publisher(s) of those dependencies. This means that we can consider the defintion of `netstandard` to be greater than the libraries that are nominally part of .NET Core or shipped by Microsoft.

The two primary package-based target frameworks used with .NET Core are:

- `netstandard`
- `netcoreapp`

.NET Standard
-------------

The `netstandard` (".NET Standard") framework represents the APIs defined by and built on top of the [.NET Standard Library](../concepts/dotnet-standard-library.md). Libraries that are intended to run on multiple runtimes should use this target. They will be supported on any .NET Standard compliant runtime, such as .NET Core, .NET Framework and Mono/Xamarin. Each of these runtimes supports a set of .NET Standard versions, depending on which APIs they implement. 

The `NETStandard.Library` metapackage targets the `netstandard` framework. The most common way to target `netstandard` is by referencing this metapackage. It desribes and provides access to the ~40 .NET  libraries and associated APIs that define the .NET Standard Library. You can reference additional packages that target `netstandard` to get access to additional APIs. These higher-level packages can be thought of as "targeting netstandard" or as "a .NET Standard Library" but they do not define "the .NET Standard Library".

Most of the fundamental .NET libraries are platform-specific in some way: to a specific set of runtimes, to a specific set of OSes and/or CPUs, or have a platform-specific native dependency. As a result, `NETStandard.Library`, which references these fundamental libraries as a set, defines which platforms a new netstandard version supports at its maximum. Higher-level libraries cannot broaden this set of supported platforms.

.NET Core Application
---------------------

The `netcoreapp` (".NET Core Application") framework represents the packages and associated APIs that come with the .NET Core distribution and the console application model that it provides. .NET Core apps must use this framework, due to targeting the console application model, as should libraries that intended to run only on .NET Core. Using this framework restricts apps and libraries to running only on .NET Core. 

The `Microsoft.NETCore.App` metapackage targets the `netcoreapp` framework. It provides access to to ~60 libraries, ~40 provided by the `NETStandard.Library` package and ~20 more in addition. You can reference additional libraries that target `netcoreapp` or compatible frameworks, such as `netstandard`, to get access to additional APIs. 

Most of the additional libraries provided by `Microsoft.NETCore.App` also target `netstandard` given that their dependencies are satisfied by other `netstandard` libraries. That means that `netstandard` libraries can also reference those packages as dependencies. 
