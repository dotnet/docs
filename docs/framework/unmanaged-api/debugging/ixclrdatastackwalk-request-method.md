---
description: "Learn more about: IXCLRDataStackWalk::Request Method"
title: "IXCLRDataStackWalk::Request Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataStackWalk::Request Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataStackWalk::Request Method"
helpviewer.keywords:
  - "IXCLRDataStackWalk::Request Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataStackWalk::Request Method

Requests to populate the buffer given with the process's data.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT Request(
    [in] ULONG32 reqCode,
    [in] ULONG32 inBufferSize,
    [in, size_is(inBufferSize)] BYTE* inBuffer,
    [in] ULONG32 outBufferSize,
    [out, size_is(outBufferSize)] BYTE* outBuffer);
```

## Parameters

`reqCode`\
[in] Request type to be sent.

Requests can be one of the following:

|Member|Value|Description|  
|------------|-----------------|-----------------|  
|`CLRDATA_REQUEST_REVISION`|0xe0000000|Request the revision of the stack walk.  The revision is a ULONG32 numeric value.|  
|`CLRDATA_STACK_WALK_REQUEST_SET_FIRST_FRAME`|0xe1000000|Tell the stack walker whether the current state represents the first frame of the stack or not.  The value is a ULONG32 boolean value.  Note that callers of `SetContext` may use this to indicate to the stack walker whether the set register context represents the real register context of a thread or some intermediate unwind.|

`inBufferSize`\
[in] size of the input buffer to be passed in.

`inBuffer`\
[in, size_is(inBufferSize)] Buffer pointer for the raw data to be sent in the request.

`outBufferSize`\
[in] Size of the output buffer.

`outBuffer`\
[out, size_is(outBufferSize)] Buffer pointer to used to store the request response.

## Remarks

The provided method is part of the `IXCLRDataStackWalk` interface and corresponds to the 10th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
- [IXCLRDataStackWalk::SetContext Method](ixclrdatastackwalk-setcontext-method.md)
