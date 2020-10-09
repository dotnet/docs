---
title: "NETSDK1022: Duplicate '{0}' items were included. The .NET SDK includes '{0}' items from your project directory by default. You can either remove these items from your project file, or set the '{1}' property to '{2}' if you want to explicitly include them in your project file. For more information, see {4}. The duplicate items were: {3}"
description: How to resolve the duplicate item message based on default includes
author: marcpopMSFT
ms.topic: error-reference
ms.date: 10/9/2020
f1_keywords:
- NETSDK1022
---
# NETSDK1022: NETSDK1022: Duplicate '{0}' items were included.

**This article applies to:** ✔️ .NET 2.1.100 SDK and later versions
Starting in 15.3, the .NET SDK automatically includes items from the project directory be default.  This includes `Compile` and `Content` targets.  This should greatly clean up your project file and reduce the complexity you have there.

You can revert to the earlier behavior by setting the correct property to false
Example for `Compile` items
```xml
<PropertyGroup>
    <EnableDefaultCompileItems>false</EnableDefaultCompileItems>
</PropertyGroup>
```
