---
title: "ISymUnmanagedDocument::GetDocumentType Method"
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
  - "ISymUnmanagedDocument.GetDocumentType"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetDocumentType"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetDocumentType method [.NET Framework debugging]"
  - "GetDocumentType method [.NET Framework debugging]"
ms.assetid: 2d381ab1-7e7c-4281-af2b-e54d879b3ef8
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDocument::GetDocumentType Method
Gets the document type of this document.  
  
## Syntax  
  
```  
HRESULT GetDocumentType(  
    [out, retval] GUID*  pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] Pointer to a variable that receives the document type.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See Also  
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
