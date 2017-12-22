---
title: "ISymUnmanagedMethod::GetOffset Method"
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
  - "ISymUnmanagedMethod.GetOffset"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetOffset"
helpviewer_keywords: 
  - "GetOffset method, ISymUnmanagedMethod interface [.NET Framework debugging]"
  - "ISymUnmanagedMethod::GetOffset method [.NET Framework debugging]"
ms.assetid: 8bf3cb62-89bf-4159-ad53-de606aba89e8
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedMethod::GetOffset Method
Returns the offset within this method that corresponds to a given position within a document.  
  
## Syntax  
  
```  
HRESULT GetOffset(  
    [in]  ISymUnmanagedDocument*  document,  
    [in]  ULONG32                 line,  
    [in]  ULONG32                 column,  
    [out, retval] ULONG32*        pRetVal);  
```  
  
#### Parameters  
 `document`  
 [in] A pointer to the document for which the offset is requested.  
  
 `line`  
 [in] The document line for which the offset is requested.  
  
 `column`  
 [in] The document column for which the offset is requested.  
  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the offsets.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
