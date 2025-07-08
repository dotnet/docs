---
description: "Learn more about: CLRDataFollowStubOutFlag Enumeration"
title: "CLRDataFollowStubOutFlag Enumeration"
ms.date: "07/02/2024"
api_name:
  - "CLRDataFollowStubOutFlag"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataFollowStubOutFlag"
helpviewer_keywords:
  - "CLRDataFollowStubOutFlag enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataFollowStubOutFlag Enumeration

A set of flags returned from `IXCLRDataProcess::FollowStub` and `IXCLRDataProcess::FollowStub2` that indicate the result of following a stub.

## Syntax

```cpp
typedef enum CLRDataFollowStubOutFlag {
    CLRDATA_FOLLOW_STUB_INTERMEDIATE = 0x00000000,
    CLRDATA_FOLLOW_STUB_EXIT = 0x00000001
} CLRDataFollowStubOutFlag;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_FOLLOW_STUB_INTERMEDIATE`|0x00000000|The result of following is an intermediate stub.  Callers can call `FollowStub` or `FollowStub2` again to continue following the chain.|
|`CLRDATA_FOLLOW_STUB_EXIT`|0x00000001|The result of following is the exit of the stub.  The returned address is the execution address at the end of the stub chain.|

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
- [IXCLRDataProcess::FollowStub Method](ixclrdataprocess-followstub-method.md)
- [IXCLRDataProcess::FollowStub2 Method](ixclrdataprocess-followstub2-method.md)
