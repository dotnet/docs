---
title: Runtime package store
description: Runtime package store and target manifests
keywords: .NET, .NET Core
author: beleroy
ms.date: 04/13/2017
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
---

# Runtime package store

Starting with .NET Core 2.0, it is possible to package and deploy applications against a known set of packages that is known to exist on the target environment. The benefits in doing so is that it is possible to deploy smaller published applications, to use less disk space, and in some cases to improve startup performance.

This feature is implemented by a runtime package store, which is a location on disk where packages are stored, that the runtime can find, access, and use. That location is a `store` directory, next to the `dotnet` host. Under this directory, there are subdirectories for target frameworks, under which the package store follows a NuGet layout.

The second part of the implementation is a "target manifest", which is a description of the list of packages that compose a runtime package store, and that developers can target when publishing their application. The target manifest is typically provided by the owner of the targeted production environment.

The feature is also used implicitly by ASP.NET applications: the set of packages composing the ASP.NET Web framework is installed as part of the setup packages authored by Microsoft. When publishing an ASP.NET application, a special task in the SDK finds the right manifest and configures the publication task to use it, resulting in the published application being trimmed to only include the application's packages, and not the framework's packages.

## Publishing an application against a target manifest

If you have a target manifest file on disk, you may use it when publishing:

```
dotnet publish --manifest path/to/the/target-manifest.csproj
```

The resulting published application should only be deployed to an environment that has the packages described in the target manifest. Failing to do so would result in the application not starting.

It is possible to specify multiple target manifests when publishing an application. The application will then be trimmed for the union of packages specified in those target manifests.

## Specifying a target manifest in the project file

It is possible, instead of specifying a target manifest in a `dotnet publish` command, to specify the manifest or manifests to use in the project file under a `TargetManifest` tag.

```xml
<PropertyGroup>
  <TargetManifest>path/to/the/target-manifest.csproj</TargetManifest>
</PropertyGroup>
```

This should only be done when the target environment for the application is well-known. This is the case for example for ASP.NET projects, and for that reason, ASP.NET project templates include a target manifest (with a special value that is mapped to the corresponding target manifest's path when publishing):

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetManifest>aspnet/2.0.0</TargetManifest>
  </PropertyGroup>
```

A different case would be an open source project: the users of the project will likely deploy to a variety of different production environments, which may have different sets of packages pre-installed. Maintainers of the project can't make assumptions about the target manifest, and users should instead rely on the `--manifest` option of `dotnet publish` instead.

## Preparing a runtime environment

The administrator of a runtime environment can optimize for certain types of applications by building a runtime package store and the corresponding target manifest.

The first step is to create an empty project and to add the packages that must compose the runtime package store. The runtime package store can then be provisioned by running a `dotnet store --manifest target-manifest.csproj` command. It is possible to pass multiple target manifest paths to the `dotnet store` command.

The target manifest that was used to build the runtime package store can be made available to be downloaded by application authors who must be able to publish against it.

## See Also

* [dotnet-publish](../tools/dotnet-publish.md)
* [dotnet-store](../tools/dotnet-store.md)