---
title: Runtime package store (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: This topic explains the runtime package store and target manifests used by .NET Core.
keywords: .NET, .NET Core, dotnet store, runtime package store
author: bleroy
ms.author: mairaw
ms.date: 06/26/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 9521d8b4-25fc-412b-a65b-4c975ebf6bfd
---

# Runtime package store (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

Starting with .NET Core 2.0, it's possible to package and deploy apps against a known set of packages that exist in the target environment. The benefits are faster deployments, lower disk space usage, and improved startup performance in some cases.

This feature is implemented as a *runtime package store*, which is a directory on disk next to the the [`dotnet` host](../tools/dotnet.md) where packages are stored (typically at *.dotnet/store* in the user's profile). Under this directory, there are subdirectories for architectures and [target frameworks](../../standard/frameworks.md). The file layout is similar to the way that [NuGet assets are laid out on disk](https://docs.microsoft.com/nuget/create-packages/supporting-multiple-target-frameworks#framework-version-folder-structure):

\dotnet
&nbsp;&nbsp;\store
&nbsp;&nbsp;&nbsp;&nbsp;\x64
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\net47
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.applicationinsights
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.aspnetcore
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\netcoreapp2.0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.applicationinsights
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.aspnetcore
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...
&nbsp;&nbsp;&nbsp;&nbsp;\x86
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\net47
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.applicationinsights
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.aspnetcore
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\netcoreapp2.0
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.applicationinsights
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;\microsoft.aspnetcore
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...

The second part of the implementation is a *target manifest*, which is a list of packages that describe the runtime package store. Developers can target this manifest when publishing their app. The target manifest is typically provided by the owner of the targeted production environment.

The feature is also used implicitly by ASP.NET apps: The set of packages composing the ASP.NET web framework is installed as part of the setup packages authored by Microsoft. When publishing an ASP.NET app, the published app is trimmed to the app's included packages and not the framework's packages.

## Publishing an app against a target manifest

If you have a target manifest file on disk, you specify the path and file name when publishing your app with the [`dotnet publish`](../tools/dotnet-publish.md) command:

```console
dotnet publish --manifest <PATH_TO_MANIFEST_FILE>
```

**Example**

```console
dotnet publish --manifest manifest.xml
```

You're required to deploy the resulting published app to an environment that has the packages described in the target manifest. Failing to do so results in the app failing to start.

Specify multiple target manifests when publishing an app by repeating the option and value. When you do so, the app is trimmed for the union of packages specified in the target manifest files provided to the command.

## Specifying target manifests in the project file

Instead of specifying target manifests with the [`dotnet publish`](../tools/dotnet-publish.md) command, you can specify them in the project file as a semicolon-separated list of paths under a **\<TargetManifestFiles>** tag.

```xml
<PropertyGroup>
  <TargetManifestFiles>target-manifest.xml</TargetManifestFiles>
</PropertyGroup>
```

Specify the target manifests in the project file only when the target environment for the app is well-known, such as for ASP.NET projects. This isn't the case for open-source projects. The users of an open-source project likely deploy to different production environments, which probably have different sets of packages pre-installed. Maintainers of the project can't make assumptions about the target manifest in such open-source environments, so developers should instead rely on the `--manifest` option of [`dotnet publish`](../tools/dotnet-publish.md).

## ASP.NET implicit store

The default ASP.NET targets in the `Microsoft.NET.Sdk.Web` SDK include target manifests. As a consequence, running `dotnet publish` for an ASP.NET app results in a published app that contains only the app and its assets and not ASP.NET itself.

When an ASP.NET published app is deployed, make sure that the target environment has ASP.NET installed, as the presence of .NET Core alone isn't sufficient. If the app is deployed to an environment that doesn't include ASP.NET, you can opt out of the implicit store by specifying  **\<PublishWithAspNetCoreTargetManifest>** set to `false` in the project file as shown below:

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

Provision the runtime package store by executing `dotnet store` with the manifest file, runtime, and framework:

```console
dotnet store --manifest <PATH_TO_MANIFEST_FILE> --runtime <RUNTIME_IDENTIFIER> --framework <FRAMEWORK>
```

You can pass multiple target manifest paths to a single [`dotnet store`](../tools/dotnet-store.md) command by repeating the option and path in the command.

By default, the output of the command is a package store under the *.dotnet/store* subdirectory of the user's profile. You can specify a different location using the `--output <OUTPUT_DIRECTORY>` option. The root directory of the store contains a target manifest *artifact.xml* file. This file can be made available for download and be used by app authors who want to target this store when publishing.

## See also

[dotnet-publish](../tools/dotnet-publish.md)   
[dotnet-store](../tools/dotnet-store.md)   
