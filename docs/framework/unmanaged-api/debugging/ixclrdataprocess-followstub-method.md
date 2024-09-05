---
description: "Learn more about: IXCLRDataProcess::FollowStub Method"
title: "IXCLRDataProcess::FollowStub Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataProcess::FollowStub Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::FollowStub Method"
helpviewer.keywords:
  - "IXCLRDataProcess::FollowStub Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::FollowStub Method

Given an address which is a CLR stub (and potentially state from a previous follow) determine the next execution address at which to check whether the stub has been exited.

NOTE: This method is obsolete.  Callers should utilize `IXCLRDataProcess::FollowStub2` whenever available.  Such is available if the process revision as returned by `IXCLRDataProcess::Request` is at least 7.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT FollowStub(
    [in] ULONG32 inFlags,
    [in] CLRDATA_ADDRESS inAddr,
    [in] CLRDATA_FOLLOW_STUB_BUFFER *inBuffer,
    [out] CLRDATA_ADDRESS *outAddr,
    [out] CLRDATA_FOLLOW_STUB_BUFFER *outBuffer,
    [out] ULONG32 *outFlags
);
```

## Parameters

`inFlags`\
[in] A set of flags describing how to follow the stub.  This must be a value of the `CLRDataFollowStubInFlag` enumeration which presently contains only one value: CLRDATA_FOLLOW_STUB_DEFAULT (0).

`inAddr`\
[in] The address of the stub to follow

`inBuffer`\
[in] An opaque data buffer used internally to maintain the state of walking a chain of stubs.  This should be NULL on the initial call to the `FollowStub` method.

`outAddr`\
[out] The next execution address determined from following the stub.

`outBuffer`\
[out] An opaque data buffer used internally to maintain the state of walking a chain of stubs.

`outFlags`\
[out] A set of flags describing the result of following the stub.  This is a value of the `CLRDataFollowStubOutFlag` enumeration.  If the value is `CLRDATA_FOLLOW_STUB_INTERMEDIATE` (0), the result is an intermediate step in following the stub and the caller can call FollowStub again.  If the value is `CLRDATA_FOLLOW_STUB_EXIT` (1), this is the end of the stub chain and the `outAddr` is the execution address at the end of the chain.

## Remarks

A given address can be determined to be a stub or not via usage of the `IXCLRDataProcess::GetAddressType` method returning a type of `CLRDATA_ADDRESS_RUNTIME_MANAGED_STUB` or `CLRDATA_ADDRESS_RUNTIME_UNMANAGED_STUB`.

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 47th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataProcess::FollowStub2 Method](ixclrdataprocess-followstub2-method.md)
- [IXCLRDataProcess::Request Method](ixclrdataprocess-request-method.md)
- [IXCLRDataProcess::GetAddressType Method](ixclrdataprocess-getaddresstype-method.md)
- [CLRDataFollowStubInFlag Enumeration](clrdatafollowstubinflag-enumeration.md)
- [CLRDataFollowStubOutFlag Enumeration](clrdatafollowstuboutflag-enumeration.md)
