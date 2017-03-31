---
title: "ISymUnmanagedDocument::GetDocumentType Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ISymUnmanagedDocument.GetDocumentType"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetDocumentType"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetDocumentType method [.NET Framework debugging]"
  - "GetDocumentType method [.NET Framework debugging]"
ms.assetid: 2d381ab1-7e7c-4281-af2b-e54d879b3ef8
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
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