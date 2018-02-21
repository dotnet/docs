---
title: "ICorDebugCode::GetCode Method"
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
  - "ICorDebugCode.GetCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode::GetCode"
helpviewer_keywords: 
  - "ICorDebugCode::GetCode method [.NET Framework debugging]"
  - "GetCode method, ICorDebugCode interface [.NET Framework debugging]"
ms.assetid: 7137e3d1-1dad-48d8-8c37-16ac816534d3
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugCode::GetCode Method
Gets all the code for the specified function, formatted for disassembly. This method has been deprecated in the .NET Framework version 2.0. Use [ICorDebugCode2::GetCodeChunks](../../../../docs/framework/unmanaged-api/debugging/icordebugcode2-getcodechunks-method.md) instead.  
  
## Syntax  
  
```  
HRESULT GetCode (  
    [in] ULONG32     startOffset,   
    [in] ULONG32     endOffset,  
    [in] ULONG32     cBufferAlloc,  
    [out, size_is(cBufferAlloc),  
        length_is(*pcBufferSize)] BYTE buffer[],  
    [out] ULONG32    *pcBufferSize  
);  
```  
  
#### Parameters  
 `startOffset`  
 [in] The offset of the beginning of the function.  
  
 `endOffset`  
 [in] The offset of the end of the function.  
  
 `cBufferAlloc`  
 [in] The size of the `buffer` array into which the code will be returned.  
  
 `buffer`  
 [out] The array into which the code will be returned.  
  
 `pcBufferSize`  
 [out] The number of bytes returned.  
  
## Remarks  
 If the function's code has been divided into multiple chunks, they are concatenated in order of increasing native offset. Instruction boundaries are not checked.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See Also  
 [GetCodeChunks Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode2-getcodechunks-method.md)  
 
