---
description: "Learn more about: CeeSectionRelocExtra Union"
title: "CeeSectionRelocExtra Union"
ms.date: "03/30/2017"
api_name:
  - "CeeSectionRelocExtra Union"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CeeSectionRelocExtra"
helpviewer_keywords:
  - "CeeSectionRelocExtra union [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# CeeSectionRelocExtra Union

Represents an address offset that is used by the [ICeeGen](iceegen-interface.md) interface to relocate a section.

## Syntax

```cpp
typedef union  {
    USHORT highAdj;
} CeeSectionRelocExtra;
```

## Members

|Member|Description|
|------------|-----------------|
|`highAdj`|The upper address adjustment for the section.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Unions](metadata-unions.md)
