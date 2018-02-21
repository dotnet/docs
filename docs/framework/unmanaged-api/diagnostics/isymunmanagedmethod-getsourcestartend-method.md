---
title: "ISymUnmanagedMethod::GetSourceStartEnd Method"
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
  - "ISymUnmanagedMethod.GetSourceStartEnd"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetSourceStartEnd"
helpviewer_keywords: 
  - "GetSourceStartEnd method [.NET Framework debugging]"
  - "ISymUnmanagedMethod::GetSourceStartEnd method [.NET Framework debugging]"
ms.assetid: 2a420900-01f1-4461-8777-3a34a6dc1426
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedMethod::GetSourceStartEnd Method
Gets the start and end document positions for the source of this method. The first array position is the start, and the second array position is the end.  
  
## Syntax  
  
```  
HRESULT GetSourceStartEnd(  
    [in]  ISymUnmanagedDocument  *docs[2],  
    [in]  ULONG32                lines[2],  
    [in]  ULONG32                columns[2],  
    [out] BOOL                   *pRetVal);  
```  
  
#### Parameters  
 `docs`  
 [in] The starting and ending source documents.  
  
 `lines`  
 [in] The starting and ending lines in the corresponding source documents.  
  
 `columns`  
 [in] The starting and ending columns in the corresponding source documents.  
  
 `pRetVal`  
 [out] `true` if positions were defined; otherwise, `false`.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedmethod-interface.md)
