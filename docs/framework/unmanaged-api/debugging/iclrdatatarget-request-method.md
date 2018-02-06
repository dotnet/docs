---
title: "ICLRDataTarget::Request Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICLRDataTarget.Request"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::Request"
helpviewer_keywords: 
  - "ICLRDataTarget::Request method [.NET Framework debugging]"
  - "Request method [.NET Framework debugging]"
ms.assetid: 4723bd1c-eddb-4ed2-897a-010024a47e01
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget::Request Method
Called by the common language runtime (CLR) data access services to request an operation, as defined by the implementation.  
  
## Syntax  
  
```  
HRESULT Request (  
    [in] ULONG32            reqCode,  
    [in] ULONG32            inBufferSize,  
    [in, size_is(inBufferSize)]   
        BYTE                *inBuffer,  
    [in] ULONG32            outBufferSize,  
    [out, size_is(outBufferSize)]   
        BYTE                *outBuffer  
);  
```  
  
#### Parameters  
 `reqCode`  
 [in] User-defined.  
  
 `inBufferSize`  
 [in] The size of the input buffer, which is used for the incoming request.  
  
 `inBuffer`  
 [in] A buffer containing the request.  
  
 `outBufferSize`  
 [in] The size of the output buffer, which is used for the response.  
  
 `outBuffer`  
 [out] A Buffer containing the response.  
  
## Remarks  
 The `Request` method facilitates the addition of unspecified custom operations. That is, this method provides extensibility without requiring revision of the interface definition.  
  
 This method is implemented by the writer of the debugging application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)
