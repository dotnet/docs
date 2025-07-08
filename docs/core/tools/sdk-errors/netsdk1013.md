---
title: "NETSDK1013: The TargetFramework value was not recognized."
description: How to determine and set a valid TargetFramework value
author: marcpop
ms.topic: error-reference
ms.date: 10/9/2020
f1_keywords:
- NETSDK1013
---
# NETSDK1013: The TargetFramework value was not recognized

**This article applies to:** ✔️ .NET Core 3.1.100 SDK and later versions

The SDK tries to parse the values provided in the project file for `<TargetFramework>` or `<TargetFrameworks>` into a well known value. If the value is not recognized, the `TargetFrameworkIdentifier` or `TargetFrameworkVersion` value might be set to an empty string or `Unsupported`.

To resolve this, check the spelling of your `TargetFramework` value from the list of [supported frameworks](../../../standard/frameworks.md).
You can also set the `TargetFrameworkIdentifier` and `TargetFrameworkVersion` properties directly in your project file.

```xml
<PropertyGroup Condition="'$(TargetFrameworkIdentifier)' == ''">
  <TargetFrameworkIdentifier>.NETCoreApp</TargetFrameworkIdentifier>
  <TargetFrameworkVersion>8.0</TargetFrameworkVersion>
</PropertyGroup>
```
