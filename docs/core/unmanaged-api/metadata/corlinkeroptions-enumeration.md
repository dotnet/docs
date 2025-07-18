---
description: "Learn more about: CorLinkerOptions Enumeration"
title: "CorLinkerOptions Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorLinkerOptions"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorLinkerOptions"
helpviewer_keywords:
  - "CorLinkerOptions enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# CorLinkerOptions Enumeration

Specifies flags to select options for the metadata linker.

## Syntax

```cpp
typedef enum CorLinkerOptions {
    MDAssembly          = 0x00000000,
    MDNetModule         = 0x00000001,
} CorLinkerOptions;
```

## Members

|Member|Description|
|------------|-----------------|
|`MDAssembly`|The private types and global functions are not preserved.|
|`MDNetModule`|The private types and global functions are preserved.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** CorHdr.h

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)
