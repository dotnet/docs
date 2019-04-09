---
title: "ISymENCUnmanagedMethod::GetDocumentsForMethodCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymENCUnmanagedMethod.GetDocumentsForMethodCount"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymENCUnmanagedMethod::GetDocumentsForMethodCount"
helpviewer_keywords: 
  - "GetDocumentsForMethodCount method [.NET Framework debugging]"
  - "ISymENCUnmanagedMethod::GetDocumentsForMethodCount method [.NET Framework debugging]"
ms.assetid: cc1a823a-3ff3-4a33-b641-96edc93d2b17
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymENCUnmanagedMethod::GetDocumentsForMethodCount Method
Gets the number of documents that this method has lines in.  
  
## Syntax  
  
```  
HRESULT GetDocumentsForMethodCount(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the documents.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymENCUnmanagedMethod Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymencunmanagedmethod-interface.md)
