---
title: Trim self-contained applications
description: Learn how to trim self-contained apps to reduce their size. .NET Core bundles the runtime with an app that is published self-contained and generally includes more of the runtime then is necessary.
author: jamshedd
ms.author: jamshedd
ms.date: 04/03/2020
---
# Trim self-contained deployments and executables

When publishing an application self-contained, the .NET Core runtime is bundled together with the application. This bundling adds a significant amount of content to your packaged application. When it comes to deploying your application, size is often an important factor. Keeping the size of the package application as small as possible is typically a goal for application developers.

Depending on the complexity of the application, only a subset of the runtime is required to run the application. These unused parts of the runtime are unnecessary and can be trimmed from the packaged application.

The trimming feature works by examining the application binaries to discover and build a graph of the required runtime assemblies. The remaining runtime assemblies that aren't referenced are trimmed.

> [!NOTE]
> Trimming is an experimental feature in .NET Core 3.1 and is _only_ available to applications that are published self-contained.

## Prevent assemblies from being trimmed

There are scenarios in which the trimming functionality will fail to detect references. For example, your application, or a library referenced by your application, that uses reflection may look for an assembly that isn't directly referenced. Trimming is unaware of these indirect references and would exclude the library from the published folder.

When the code is indirectly referencing an assembly through reflection, you can prevent the assembly from being trimmed with the `<TrimmerRootAssembly>` setting. The following example shows how to prevent an assembly called `System.Security` assembly from being trimmed:

```xml
<ItemGroup>
    <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```

## Trim your app - dotnet

The following example shows how to trim your application using the [dotnet publish](../tools/dotnet-publish.md) command. When you publish, you need to set the following three settings:

- Publish as self-contained: `--self-contained true`
- Disable single-file publishing: `-p:PublishSingleFile=false`
- Enable trimming: `p:PublishTrimmed=true`

The following example publishes an app for Windows 10 as self-contained and trims the output.

```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained true -p:PublishSingleFile=false -p:PublishTrimmed=true
```

## See also

- [.NET Core application deployment](index.md)
- [Publish .NET Core apps with .NET Core CLI](deploy-with-cli.md)
- [Publish .NET Core apps with Visual Studio](deploy-with-vs.md)
