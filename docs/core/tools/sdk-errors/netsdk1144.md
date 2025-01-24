---
title: "NETSDK1144: Optimizing assemblies for size failed"
description: How to resolve the 'optimizing for size failed' message.
author: tdykstra
ms.topic: error-reference
ms.date: 01/14/2025
ai-usage: ai-assisted
f1_keywords:
- NETSDK1144
---
# NETSDK1144: Optimizing assemblies for size failed

## Error Message

The error `NETSDK1144` is reported when an error occurs in the trimming process. The full error message is similar to the following example:

> Optimizing assemblies for size failed. Optimization can be disabled by setting the `PublishTrimmed` property to false.

To disable trimming, set the `PublishTrimmed` property to `false` in the project file or the command line:

   ```xml
   <PropertyGroup>
     <PublishTrimmed>false</PublishTrimmed>
   </PropertyGroup>
   ```

   ```dotnetcli
   dotnet publish /p:PublishTrimmed=false
   ```

Here's an example of a `.csproj` file with trimming disabled:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <RuntimeIdentifier>linux-arm</RuntimeIdentifier>
    <PublishTrimmed>false</PublishTrimmed>
  </PropertyGroup>
</Project>
```
