---
title: "NETSDK1022: Duplicate items were included."
description: How to resolve the duplicate item message based on default includes.
author: marcpopMSFT
ms.topic: error-reference
ms.date: 10/9/2020
f1_keywords:
- NETSDK1022
---
# NETSDK1022: Duplicate items were included.

**This article applies to:** ✔️ .NET Core 2.1.100 SDK and later versions

Starting in Visual Studio 2017 / MSBuild version 15.3, the .NET SDK automatically includes items from the project directory by default.  This includes `Compile` and `Content` targets.  This should greatly clean up your project file and reduce the complexity you have there.

You can revert to the earlier behavior by setting the correct property to false.

Example for `Compile` items:

```xml
<PropertyGroup>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
</PropertyGroup>
```
