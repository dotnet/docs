---
title: "ISymUnmanagedDocument::GetLanguage Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocument.GetLanguage"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetLanguage"
helpviewer_keywords: 
  - "ISymUnmanagedDocument::GetLanguage method [.NET Framework debugging]"
  - "GetLanguage method [.NET Framework debugging]"
ms.assetid: c6639418-e9f2-4a99-8ce2-ec9876e0bc79
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedDocument::GetLanguage Method
Gets the language identifier of this document  
  
## Syntax  
  
```cpp  
HRESULT GetLanguage(  
    [out, retval]  GUID*  pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] A pointer to a variable that receives the language identifier.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See also

- [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
