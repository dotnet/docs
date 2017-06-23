---
title: Runtime package store | Microsoft Docs
description: Runtime package store and target manifests
keywords: .NET, .NET Core
author: bleroy
ms.author: mairaw
ms.date: 04/13/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 9521d8b4-25fc-412b-a65b-4c975ebf6bfd
---

# Runtime package store

Starting with .NET Core 2.0, it's possible to package and deploy apps against a known set of packages that exist on the target environment. The benefits in doing so are smaller deployments, lower disk space usage, and improved startup performance in some cases.

This feature is implemented by a runtime package store, which is a location on disk where packages are stored. The runtime can find, access, and use the packages in this store. That location is a *store* directory, next to [the `dotnet` host](../tools/dotnet.md). Under this directory, there are subdirectories for [target frameworks](../../standard/frameworks.md), under which the package store follows a NuGet layout.

The second part of the implementation is a *target manifest*, which is a list of packages that compose a runtime package store. Developers can target this manifest when publishing their app. The target manifest is typically provided by the owner of the targeted production environment.

The feature is also used implicitly by ASP.NET apps: The set of packages composing the ASP.NET web framework is installed as part of the setup packages authored by Microsoft. When publishing an ASP.NET app, the published app is trimmed to the app's included packages and not the framework's packages.

## Publishing an app against a target manifest

If you have a target manifest file on disk, you specify the path and file name when publishing your app with the [`dotnet publish`](../tools/dotnet-publish.md) command:

```console
dotnet publish --manifest <PATH_TO_MANIFEST_FILE>
```

**Example**

```console
dotnet publish --manifest c:\Users\Garcia\Documents\Manifests\manifest.xml
```

You're required to deploy the resulting published app to an environment that has the packages described in the target manifest. Failing to do so results in the app failing to start.

You can specify multiple target manifests when publishing an app. In this case, the app is trimmed for the union of packages specified in the target manifests.

## Specifying target manifests in the project file

Instead of specifying target manifests with the [`dotnet publish`](../tools/dotnet-publish.md) command, you can specify them in the project file as a semicolon-separated list of paths under a **\<TargetManifestFiles>** tag.

```xml
<PropertyGroup>
  <TargetManifestFiles>path/to/the/target-manifest.xml</TargetManifestFiles>
</PropertyGroup>
```

Specify the target manifests in the project file only when the target environment for the app is well-known, such as for ASP.NET projects. This is not the case for open-source projects. The users of an open-source project likely deploy to different production environments, which probably have different sets of packages pre-installed. Maintainers of the project can't make assumptions about the target manifest in such open-source environments, so developers should instead rely on the `--manifest` option of [`dotnet publish`](../tools/dotnet-publish.md).

## ASP.NET implicit store

The default ASP.NET targets in the `Microsoft.NET.Sdk.Web` SDK include target manifests. As a consequence, running `dotnet publish` for an ASP.NET app results in a published app that contains only the app and its assets and not ASP.NET itself.

When an ASP.NET published app gets deployed, make sure that the target environment has ASP.NET installed, as the presence of .NET Core alone isn't sufficient.

If the app will be deployed to an environment that doesn't include ASP.NET, you can opt out of the implicit store by specifying a **\<PublishWithAspNetCoreTargetManifest>** flag set to `false` in the project file as shown below:

```xml
<PropertyGroup>
  <PublishWithAspNetCoreTargetManifest>false</PublishWithAspNetCoreTargetManifest>
</PropertyGroup>
```

## Preparing a runtime environment

The administrator of a runtime environment can optimize for certain types of apps by building a runtime package store and the corresponding target manifest.

The first step is to create an XML file that describes the packages that must compose the runtime package store. This file format is compatible with the project file format (*csproj* for example). The following example shows how to add `Newtonsoft.Json` and `System.Runtime.Serialization.Primitives` to the package store in the XML file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="10.0.3" />
    <PackageReference Include="System.Runtime.Serialization.Primitives" Version="4.3.0" />
  </ItemGroup>
</Project>
```

The runtime package store can then be provisioned by running `dotnet store` with the manifest file, runtime, and framework:

```console
dotnet store --manifest <PATH_TO_MANIFEST_FILE> --runtime <RUNTIME_IDENTIFIER> --framework <FRAMEWORK>
```

Multiple target manifest paths can be passed to a single [`dotnet store`](../tools/dotnet-store.md) command by repeating the option and path in the command.

By default, the output of the command is a package store under the *.dotnet/store* subdirectory of the user's profile. You can specify a different location using the `--output <OUTPUT_DIRECTORY>` option. The root directory of the store contains a target manifest *artifact.xml* file. This file can be made available for download and be used by app authors who want to target this store when publishing.

## See also

[dotnet-publish](../tools/dotnet-publish.md)   
[dotnet-store](../tools/dotnet-store.md)   
