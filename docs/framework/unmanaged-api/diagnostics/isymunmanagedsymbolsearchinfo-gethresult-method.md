---
title: "ISymUnmanagedSymbolSearchInfo::GetHRESULT Method"
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
  - "ISymUnmanagedSymbolSearchInfo.GetHRESULT"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedSymbolSearchInfo::GetHRESULT"
helpviewer_keywords: 
  - "ISymUnmanagedSymbolSearchInfo::GetHRESULT method [.NET Framework debugging]"
  - "GetHRESULT method [.NET Framework debugging]"
ms.assetid: 6999dc3d-65d7-4bf6-bb0a-6efc0fc72588
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedSymbolSearchInfo::GetHRESULT Method
Gets the HRESULT.  
  
## Syntax  
  
```  
HRESULT GetHRESULT(  
    [out] HRESULT *phr);  
```  
  
#### Parameters  
 `phr`  
 [out] A pointer to the HRESULT.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedSymbolSearchInfo Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedsymbolsearchinfo-interface.md)
