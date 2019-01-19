---
title: "IXCLRDataModule::Request Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataModule::Request Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::Request Method"
helpviewer.keywords:
  - "IXCLRDataModule::Request Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataModule::Request Method

Requests to populate the buffer given with the module's data.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax
```
HRESULT Request([in] ULONG32 reqCode,
    [in] ULONG32 inBufferSize,
    [in, size_is(inBufferSize)] BYTE* inBuffer,
    [in] ULONG32 outBufferSize,
    [out, size_is(outBufferSize)] BYTE* outBuffer);
```

### Parameters

`reqCode`
[in] Request type to be sent.

`inBufferSize`
[in] size of the input buffer to be passed in.

`inBuffer`
[in, size_is(inBufferSize)] Buffer pointer for the raw data to be sent in the request.

`outBufferSize`
[in] Size of the output buffer.

`outBuffer`
[out, size_is(outBufferSize)] Buffer pointer to used to store the request response.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 36th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None   
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See Also
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [IXCLRDataModule Interface](../../../../docs/framework/unmanaged-api/debugging/ixclrdatamodule-interface.md)
