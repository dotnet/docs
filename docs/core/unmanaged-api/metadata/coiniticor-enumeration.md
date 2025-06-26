---
description: "Learn more about: COINITICOR Enumeration"
title: "COINITICOR Enumeration"
ms.date: "03/30/2017"
api_name:
  - "COINITICOR"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "COINITICOR"
helpviewer_keywords:
  - "COINITICOR enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# COINITICOR Enumeration

Specifies constants used by [CoInitializeCor](../hosting/coinitializecor-function.md) when it initializes the common language runtime.

## Syntax

```cpp
typedef enum tagCOINITCOR
{
    COINITCOR = 0x0
} COINITICOR;
```

## Members

|Member|Description|
|------------|-----------------|
|`COINITCOR`|Indicates the default initialization mode.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)
