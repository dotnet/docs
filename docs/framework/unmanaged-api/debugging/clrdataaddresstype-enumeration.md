---
description: "Learn more about: CLRDataAddressType Enumeration"
title: "CLRDataAddressType Enumeration"
ms.date: "07/01/2024"
api_name:
  - "CLRDataAddressType"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataAddressType"
helpviewer_keywords:
  - "CLRDataAddressType enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataAddressType Enumeration

Indicates the type of data contained at a given address

## Syntax

```cpp
typedef enum CLRDataModuleExtentType {
    CLRDATA_ADDRESS_UNRECOGNIZED,
    CLRDATA_ADDRESS_MANAGED_METHOD,
    CLRDATA_ADDRESS_RUNTIME_MANAGED_CODE,
    CLRDATA_ADDRESS_RUNTIME_UNMANAGED_CODE,
    CLRDATA_ADDRESS_GC_DATA,
    CLRDATA_ADDRESS_RUNTIME_MANAGED_STUB,
    CLRDATA_ADDRESS_RUNTIME_UNMANAGED_STUB
} CLRDataModuleExtentType;
```

## Members

|Member|Description|
|------------|-----------------|
|`CLRDATA_ADDRESS_UNRECOGNIZED`|The data at the address is not recognized.|
|`CLRDATA_ADDRESS_MANAGED_METHOD`|The data at the address is a managed method.|
|`CLRDATA_ADDRESS_RUNTIME_MANAGED_CODE`|The data at the address is managed code associated with the runtime.|
|`CLRDATA_ADDRESS_RUNTIME_UNMANAGED_CODE`|The data at the address is unmanaged code associated with the runtime.|
|`CLRDATA_ADDRESS_GC_DATA`|The data at the address is data for the GC.|
|`CLRDATA_ADDRESS_RUNTIME_MANAGED_STUB`|The data at the address is a managed stub.|
|`CLRDATA_ADDRESS_RUNTIME_UNMANAGED_STUB`|The data at the address is an unmanaged stub.|

## Remarks

This enumeration lives inside the runtime and is not exposed through any headers or library files. To use it, define the enumeration as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataProcess::GetAddressType Method](ixclrdataprocess-getaddresstype-method.md)
