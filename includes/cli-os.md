---
author: tdykstra
ms.author: tdykstra
ms.date: 08/12/2021
ms.topic: include
---
- **`--os <OS>`**

  Specifies the target operating system (OS). This is a shorthand syntax for setting the [Runtime Identifier (RID)](../docs/core/rid-catalog.md), where the provided value is combined with the default RID. For example, on a `win-x64` machine, specifying `--os linux` sets the RID to `linux-x64`. If you use this option, don't use the `-r|--runtime` option. Available since .NET 6.
