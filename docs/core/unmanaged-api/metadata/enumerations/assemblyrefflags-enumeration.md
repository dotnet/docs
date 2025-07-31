---
description: "Learn more about: AssemblyRefFlags Enumeration"
title: "AssemblyRefFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "AssemblyRefFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "AssemblyRefFlags"
topic_type:
  - "apiref"
---
# AssemblyRefFlags Enumeration

Contains values that describe features of an assembly reference.

## Syntax

```cpp
typedef enum {
    arfFullOriginator = 0x0001
} AssemblyRefFlags;
```

## Members

| Member | Description |
|------------|-----------------|
| `arfFullOriginator` | Specifies that the assembly reference contains full, unhashed information about the publisher of the assembly. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

## See also

- [IMetaDataAssemblyEmit Interface](../interfaces/imetadataassemblyemit-interface.md)
- [DefineAssemblyRef Method](../interfaces/imetadataassemblyemit-defineassemblyref-method.md)
