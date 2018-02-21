---
title: "ISymUnmanagedSourceServerModule::GetSourceServerData Method"
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
  - "ISymUnmanagedSourceServerModule.GetSourceServerData"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedSourceServerModule::GetSourceServerData"
helpviewer_keywords: 
  - "ISymUnmanagedSourceServerModule::GetSourceServerData method [.NET Framework debugging]"
  - "GetSourceServerData method [.NET Framework debugging]"
ms.assetid: 20bdf8ff-2d15-4c64-8950-6888f642d6c0
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedSourceServerModule::GetSourceServerData Method
Returns the source server data for the module. The caller must free resources by using `CoTaskMemFree`.  
  
## Syntax  
  
```  
HRESULT GetSourceServerData(  
    [out] ULONG* pDataByteCount,   
    [out, size_is (, *pDataByteCount)] BYTE** ppData);  
```  
  
#### Parameters  
 `pDataByteCount`  
 [out] A pointer to a `ULONG32` that receives the size, in bytes, of the source server data.  
  
 `ppData`  
 [out] A pointer to the returned `pDataByteCount` value.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedSourceServerModule Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedsourceservermodule-interface.md)
