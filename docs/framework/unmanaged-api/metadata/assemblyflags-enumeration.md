---
description: "Learn more about: AssemblyFlags Enumeration"
title: "AssemblyFlags Enumeration"
ms.date: 07/28/2025
api_name:
  - "AssemblyFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "AssemblyFlags"
topic_type:
  - "apiref"
---
# AssemblyFlags Enumeration

Contains values that describe run-time features of an assembly.

## Syntax

```cpp
typedef enum _AssemblyFlags {
    afNone              = 0x00000000,
    afInMemory          = 0x00000001,
    afCleanModules      = 0x00000002,
    afNoRefHash         = 0x00000004,
    afNoDupTypeCheck    = 0x00000008,
    afDupeCheckTypeFwds = 0x00000010,
} AssemblyFlags;
```

## Members

| Member             | Description                                                         |
|--------------------|---------------------------------------------------------------------|
| `afNone`           | Normal case.                                                        |
| `afInMemory`       | An InMemory single-file assembly the filename == AssemblyName.      |
| `afCleanModules`   | Use DeleteToken and Merging to remove the AssemblyAttributesGoHere. |
| `afNoRefHash`      | Do not generate hashes for AssemblyRefs.                            |
| `afNoDupTypeCheck` | Do not check for duplicate types (ExportedType table + manifest file's TypeDef table). |
| `afDupeCheckTypeFwds` | Do dupe checking for type forwarders. This is so you can specify afNoDupTypeCheck for regular typedefs + afDupeCheckTypeFwds. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** MsCorEE.h

 **Library:** Included as a resource in MsCorEE.dll

## See also

- [IMetaDataAssemblyEmit Interface](../interfaces/imetadataassemblyemit-interface.md)
