---
title: "ICorDebugCode2::GetCodeChunks Method"
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
  - "ICorDebugCode2.GetCodeChunks"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode2::GetCodeChunks"
helpviewer_keywords: 
  - "GetCodeChunks method [.NET Framework debugging]"
  - "ICorDebugCode2::GetCodeChunks method [.NET Framework debugging]"
ms.assetid: 210a2f02-2678-4555-bc4a-78a0408764c8
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugCode2::GetCodeChunks Method
Gets the chunks of code that this code object is composed of.  
  
## Syntax  
  
```  
HRESULT GetCodeChunks (  
    [in]  ULONG32     cbufSize,  
    [out] ULONG32     *pcnumChunks,  
    [out, size_is(cbufSize), length_is(*pcnumChunks)]   
        CodeChunkInfo chunks[]  
);  
```  
  
#### Parameters  
 `cbufSize`  
 [in] Size of the `chunks` array.  
  
 `pcnumChunks`  
 [out] The number of chunks returned in the `chunks` array.  
  
 `chunks`  
 [out] An array of "CodeChunkInfo" structures, each of which represents a single chunk of code. If the value of `cbufSize` is 0, this parameter can be null.  
  
## Remarks  
 The code chunks will never overlap, and they will follow the order in which they would have been concatenated by [ICorDebugCode::GetCode](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getcode-method.md). A Microsoft intermediate language (MSIL) code object in the .NET Framework version 2.0 will comprise a single code chunk.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 
