---
description: "Learn more about: IXCLRDataExceptionState::Request Method"
title: "IXCLRDataExceptionState::Request Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataExceptionState::Request Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionState::Request Method"
helpviewer.keywords:
  - "IXCLRDataExceptionState::Request Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionState::Request Method

Requests to populate the buffer given with the exception's data.

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
|`CLRDATA_REQUEST_REVISION`|0xe0000000|Request the revision of the exception.  The revision is a ULONG32 numeric value.|  

`inBufferSize`\
[in] size of the input buffer to be passed in.

`inBuffer`\
[in, size_is(inBufferSize)] Buffer pointer for the raw data to be sent in the request.

`outBufferSize`\
[in] Size of the output buffer.

`outBuffer`\
[out, size_is(outBufferSize)] Buffer pointer to used to store the request response.

## Remarks

The provided method is part of the `IXCLRDataExceptionState` interface and corresponds to the 10th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataExceptionState Interface](ixclrdataexceptionstate-interface.md)
