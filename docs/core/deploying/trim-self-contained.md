---
title: Trim self-contained applications
description: Learn how to trim self-contained apps to reduce their size. .NET Core bundles the runtime with an app that is published self-contained and generally includes more of the runtime then is necessary.
author: jamshedd
ms.author: jamshedd
ms.date: 01/23/2020
---
# Trim self-contained deployments and executables

When publishing an application self-contained, the .NET Core runtime is bundled together with the application. This bundling adds a significant amount of content to your packaged application.

When it comes to deploying your application, size is often an important factor. Keeping the size of the package application as small as possible is typically a goal for application developers.

Depending on the complexity of the application, only a subset of the runtime is required to run the application. These unused parts of the runtime are unnecessary and can be trimmed from the packaged application.

> [!NOTE]
> Trimming is an experimental feature in .NET Core 3.1 and is _only_ available to applications that are published self-contained.

## Trim your application

The following example shows how to trim your application using the [dotnet publish](../tools/dotnet-publish.md) command:

```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained true /p:PublishSingleFile=false /p:PublishTrimmed=true
```

The trimming feature works by examining the application binaries to discover and build a graph of the required runtime assemblies. The remaining runtime assemblies that aren't referenced are trimmed.

## Trimming issues when using reflection

There are scenarios in which the trimming functionality will fail to detect references. For example, an application that uses reflection could run into this issue because the dependency on the assembly will only be known at run time.

Trimming is only a problem if the reflection usage depends on a runtime assembly that isn't referenced directly. Keep in mind that your application code may not be using reflection directly, but a third-party assembly you're referencing may be using it.

When the code is referencing an API through reflection and you don't want the linker to trim the assembly that contains that API, you can modify your project file to exclude the assembly from the trimming process. The following example shows how to prevent an assembly called `System.Security` from being trimmed:

```xml
<ItemGroup>
    <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```

## See also

- [.NET Core application deployment](index.md)
