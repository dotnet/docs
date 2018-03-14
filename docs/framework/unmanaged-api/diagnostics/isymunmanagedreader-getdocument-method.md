---
title: "ISymUnmanagedReader::GetDocument Method"
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
  - "ISymUnmanagedReader.GetDocument"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetDocument"
helpviewer_keywords: 
  - "ISymUnmanagedReader::GetDocument method [.NET Framework debugging]"
  - "GetDocument method [.NET Framework debugging]"
ms.assetid: bb203853-6a6d-4027-b9e9-603a7f28b9d3
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::GetDocument Method
Finds a document. The document language, vendor, and type are optional.  
  
## Syntax  
  
```  
HRESULT GetDocument (  
    [in]  WCHAR  *url,  
    [in]  GUID   language,  
    [in]  GUID   languageVendor,  
    [in]  GUID   documentType,  
    [out, retval] ISymUnmanagedDocument** pRetVal);  
```  
  
#### Parameters  
 `url`  
 [in] The URL that identifies the document.  
  
 `language`  
 [in] The document language. This parameter is optional.  
  
 `languageVendor`  
 [in] The identity of the vendor for the document language. This parameter is optional.  
  
 `documentType`  
 [in] The type of the document. This parameter is optional.  
  
 `pRetVal`  
 [out] A pointer to the returned interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
