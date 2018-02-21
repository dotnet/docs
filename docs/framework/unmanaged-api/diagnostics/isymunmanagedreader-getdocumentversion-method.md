---
title: "ISymUnmanagedReader::GetDocumentVersion Method"
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
  - "ISymUnmanagedReader.GetDocumentVersion"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetDocumentVersion"
helpviewer_keywords: 
  - "GetDocumentVersion method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetDocumentVersion method [.NET Framework debugging]"
ms.assetid: a51f1f64-e084-44c5-830c-2222da5a6bbf
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::GetDocumentVersion Method
Gets the specified version of the specified document. The document version starts at 1 and is incremented each time the document is updated using the [UpdateSymbolStore](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-updatesymbolstore-method.md) method. If the `pbCurrent` parameter is `true`, this is the latest version of the document.  
  
## Syntax  
  
```  
HRESULT GetDocumentVersion (  
    [in]  ISymUnmanagedDocument *pDoc,  
    [out] int* version,  
    [out] BOOL* pbCurrent);  
```  
  
#### Parameters  
 `pDoc`  
 [in] The specified document.  
  
 `version`  
 [out] A pointer to a variable that receives the version of the specified document.  
  
 `pbCurrent`  
 [out] A pointer to a variable that receives `true` if this is the latest version of the document, or `false` if it isn't the latest version.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
