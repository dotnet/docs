---
title: Trimming Self-Contained Deployments and Executables 
description: Trimming Self-Contained Deployments and Executables 
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---

# Trimming Self-Contained Deployments and Executables 

When publishing Self-Contained Deployments (SCD) as well as Self-Contained Executables (SCE), the .NET Core runtime is bundled together with the application. This adds a significant amount of content to your packaged application. Depending on the complexity of the application, only a subset of the runtime is required to run the application. These unused parts of the runtime are unnecessary and can be trimmed from the packaged application. Starting in .NET 3.0, support has been added to remove the unnecessary .NET Core assemblies from the final deployment.

When it comes to deploying your application, size is often an important factor. Keeping the size of the package application as small as possible is a typical goal for application developers.

This feature is available for both Self-Contained Deployments (SCD) as well as Self-Contained Executables (SCE).

_Note: Trimming is an experimental feature in .NET Core 3.0. This feature is not available for Framework-Dependent Deployments (FDD) and Framework-Dependent Executables (FDE) since they don't include .NET Core assemblies._  


```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained true /p:PublishSingleFile=false /p:PublishTrimmed=true
```

The trimming feature works by examining the application binaries to discover and build a graph of the required runtime assemblies. The remaining runtime assemblies that are not referenced are trimmed.

There are scenarios in which the trimming functionality will fail to detect references. For example, an application that utilizes reflection. This will only be a problem if the reflection usage adds a dependency on a runtime assembly that is otherwise not referenced directly. Keep in mind that your application code may not be using reflection but a third party assembly you reference does.

When a type is being referenced through reflection, and you do not want that assembly trimmed away by the linker you can provide a hint to the linker:

```xml
<ItemGroup>
    <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```
