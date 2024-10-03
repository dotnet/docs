---
description: "Learn more about: CLRDataFollowStubInFlag Enumeration"
title: "CLRDataFollowStubInFlag Enumeration"
ms.date: "07/02/2024"
api_name:
  - "CLRDataFollowStubInFlag"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataFollowStubInFlag"
helpviewer_keywords:
  - "CLRDataFollowStubInFlag enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataFollowStubInFlag Enumeration

A set of flags passed to `IXCLRDataProcess::FollowStub` and `IXCLRDataProcess::FollowStub2` that define how to follow the stub.

## Syntax

```cpp
typedef enum CLRDataFollowStubInFlag {
    CLRDATA_FOLLOW_STUB_DEFAULT = 0x00000000
} CLRDataFollowStubInFlag;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_FOLLOW_STUB_DEFAULT`|0x00000000|Default follow flag.  `inFlags` for the various FollowStub methods must be set to this value.|

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
