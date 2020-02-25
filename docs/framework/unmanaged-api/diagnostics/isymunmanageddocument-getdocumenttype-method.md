---
title: "ISymUnmanagedDocument::GetDocumentType Method"
ms.date: "03/30/2017"
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
---
# ISymUnmanagedDocument::GetDocumentType Method
Gets the document type of this document.  
  
## Syntax  
  
```cpp  
HRESULT GetDocumentType(  
    [out, retval] GUID*  pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] Pointer to a variable that receives the document type.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See also

- [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
