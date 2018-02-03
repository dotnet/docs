---
title: "ISymENCUnmanagedMethod::GetDocumentsForMethod Method"
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
  - "ISymENCUnmanagedMethod.GetDocumentsForMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymENCUnmanagedMethod::GetDocumentsForMethod"
helpviewer_keywords: 
  - "GetDocumentsForMethod method [.NET Framework debugging]"
  - "ISymENCUnmanagedMethod::GetDocumentsForMethod method [.NET Framework debugging]"
ms.assetid: bd6ccde5-d578-48d8-abed-b474fbd48d13
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymENCUnmanagedMethod::GetDocumentsForMethod Method
Gets the documents that this method has lines in.  
  
## Syntax  
  
```  
HRESULT GetDocumentsForMethod(  
    [in]  ULONG32  cDocs,  
    [out] ULONG32  *pcDocs,   
    [in, size_is(cDocs)] ISymUnmanagedDocument* documents[]);  
```  
  
#### Parameters  
 `cDocs`  
 [in] The length of the buffer pointed to by `pcDocs`.  
  
 `pcDocs`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the documents.  
  
 `documents`  
 [in] The buffer that contains the documents.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, an error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymENCUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymencunmanagedmethod-interface.md)
