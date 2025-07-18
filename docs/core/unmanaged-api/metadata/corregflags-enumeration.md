---
description: "Learn more about: CorRegFlags Enumeration"
title: "CorRegFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorRegFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorRegFlags"
helpviewer_keywords:
  - "CorRegFlags enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# CorRegFlags Enumeration

Provides flag values used for registration when installing a module or composite image.

## Syntax

```cpp
typedef enum
{
    regNoCopy  = 0x00000001,
    regConfig  = 0x00000002,
    regHasRefs = 0x00000004
} CorRegFlags;
```

## Members

|Member|Description|
|------------|-----------------|
|`regNoCopy`|Specifies that files should not be copied into the destination.|
|`regConfig`|Specifies that the module or composite is a configuration.|
|`regHasRefs`|Specifies that the module or composite has class references.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)
