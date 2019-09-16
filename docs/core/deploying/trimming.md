---
title: Trimming Self-Contained Deployments and Executables 
description: Trimming Self-Contained Deployments and Executables 
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---

# Trimming Self-Contained Deployments and Executables 

When it comes to deploying your application, size is often a critical factor. keeping the size of the package application as small as possible is a typical goal for application developers.

The dotnet publish verb now supports _Trimming_, which is removing of unused .NET Core assemblies from the final deployment. This feature is available for both Self-Contained Deployments (SCD) as well as Self-Contained Executables (SCE).

_Note: Trimming is an experimental feature in .NET Core 3.0. This feature is not available for Framework-Dependent Deployments (FDD) and Framework-Dependent Executables (FDE) since they don't include .NET Core assemblies._  


```dotnetcli
dotnet publish -c Release -r win10-x64 --self-contained true /p:PublishSingleFile=false /p:PublishTrimmed=true
```

There are some risks in trimming executables. For example, programs may use reflection and types loaded through reflection may get trimmed which would be undesirable.

Such factors should be taken into consideration before deciding to trim a self-contained deployment.

Note: when a type is being referenced through reflection, and you do not want that assembly trimmed away by the linker you can provide a hint to the linker:

```xml
<ItemGroup>
    <TrimmerRootAssembly Include="System.Security" />
</ItemGroup>
```
