---
title: "ISymUnmanagedBinder::GetReaderFromStream Method"
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
  - "ISymUnmanagedBinder.GetReaderFromStream"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedBinder::GetReaderFromStream"
helpviewer_keywords: 
  - "ISymUnmanagedBinder::GetReaderFromStream method [.NET Framework debugging]"
  - "GetReaderFromStream method [.NET Framework debugging]"
ms.assetid: aa38efd4-de7e-4482-a5d3-adc152093460
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedBinder::GetReaderFromStream Method
Given a metadata interface and a stream that contains the symbol store, returns the correct [ISymUnmanagedReader](isymunmanagedreader-interface.md) structure that will read the debugging symbols from the given symbol store.  
  
## Syntax  
  
```  
HRESULT GetReaderFromStream(  
    [in]  IUnknown  *importer,  
    [in]  IStream   *pstream,  
    [out,retval] ISymUnmanagedReader **pRetVal);  
```  
  
#### Parameters  
 `importer`  
 [in] A pointer to the metadata import interface.  
  
 `pstream`  
 [in] A pointer to the stream that contains the symbol store.  
  
 `pRetVal`  
 [out] A pointer that is set to the returned [ISymUnmanagedReader](isymunmanagedreader-interface.md) interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedBinder Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedbinder-interface.md)
