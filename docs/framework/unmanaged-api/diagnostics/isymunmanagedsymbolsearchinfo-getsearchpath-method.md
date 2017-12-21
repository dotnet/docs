---
title: "ISymUnmanagedSymbolSearchInfo::GetSearchPath Method"
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
  - "ISymUnmanagedSymbolSearchInfo.GetSearchPath"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedSymbolSearchInfo::GetSearchPath"
helpviewer_keywords: 
  - "GetSearchPath method [.NET Framework debugging]"
  - "ISymUnmanagedSymbolSearchInfo::GetSearchPath method [.NET Framework debugging]"
ms.assetid: b588d470-53c2-4492-be8c-957323eaca0b
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedSymbolSearchInfo::GetSearchPath Method
Gets the search path.  
  
## Syntax  
  
```  
HRESULT GetSearchPathLength(  
    [out] ULONG32 *pcchPath);  
```  
  
#### Parameters  
 `pcchPath`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the search path.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedSymbolSearchInfo Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedsymbolsearchinfo-interface.md)
