---
description: "Learn more about: COUNINITIEE Enumeration"
title: "COUNINITIEE Enumeration"
ms.date: "03/30/2017"
api_name:
  - "COUNINITIEE"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "COUNINITIEE"
helpviewer_keywords:
  - "COUNINITIEE enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# COUNINITIEE Enumeration

Specifies constants used by [CoUninitializeEE](../hosting/couninitializeee-function.md) when initializing the common language runtime.

## Syntax

```cpp
typedef enum tagCOUNINITEE
{
    COUNINITEE_DEFAULT  = 0x0,
    COUNINITEE_DLL      = 0x1
} COUNINITIEE;
```

## Members

|Member|Description|
|------------|-----------------|
|`COUNINITEE_DEFAULT`|Indicates default uninitialization mode.|
|`COUNINITEE_DLL`|Indicates uninitialization mode for unloading an assembly.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)
