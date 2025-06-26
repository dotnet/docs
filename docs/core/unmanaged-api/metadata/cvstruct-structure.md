---
description: "Learn more about: CVStruct Structure"
title: "CVStruct Structure"
ms.date: "03/30/2017"
api_name:
  - "CVStruct"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CVStruct"
helpviewer_keywords:
  - "CVStruct structure [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# CVStruct Structure

Contains information that is used when installing a module or a composite image.

## Syntax

```cpp
typedef struct {
    short Major;
    short Minor;
    short Sub;
    short Build;
} CVStruct;
```

## Members

|Member|Description|
|------------|-----------------|
|Major|Major version build number.|
|Minor|Minor version build number.|
|Sub|Sub-build number.|
|Build|Build number.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Structures](metadata-structures.md)
