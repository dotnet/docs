---
description: "Learn more about: ESymbolReadingPolicy Enumeration"
title: "ESymbolReadingPolicy Enumeration"
ms.date: "03/30/2017"
api_name:
  - "ESymbolReadingPolicy"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ESymbolReadingPolicy"
helpviewer_keywords:
  - "ESymbolReadingPolicy enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ESymbolReadingPolicy Enumeration

Contains values that set the policy for reading program database (PDB) files.

## Syntax

```cpp
typedef enum {
    eSymbolReadingNever,
    eSymbolReadingAlways,
    eSymbolReadingFullTrustOnly
} ESymbolReadingPolicy;
```

## Members

|Member|Description|
|------------|-----------------|
|`eSymbolReadingAlways`|Specifies that the debugger should always read PDB files.|
|`eSymbolReadingFullTrustOnly`|Specifies that the debugger should read only PDB files that are associated with full-trust assemblies.|
|`eSymbolReadingNever`|Specifies that the debugger should never read PDB files.|

## Remarks

 The `ESymbolReadingPolicy` enumeration is used with the [ICLRDebugManager::SetSymbolReadingPolicy](iclrdebugmanager-setsymbolreadingpolicy-method.md) method.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Enumerations](hosting-enumerations.md)
