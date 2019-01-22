---
title: "ISymUnmanagedDocument::GetLanguageVendor Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocument.GetLanguageVendor"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::GetLanguageVendor"
helpviewer_keywords: 
  - "GetLanguageVendor method [.NET Framework debugging]"
  - "ISymUnmanagedDocument::GetLanguageVendor method [.NET Framework debugging]"
ms.assetid: 1d4b702e-4922-441d-8b44-03804284f70b
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedDocument::GetLanguageVendor Method
Gets the language vendor of this document.  
  
## Syntax  
  
```  
HRESULT GetLanguageVendor(  
    [out, retval]  GUID*  pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to a variable that receives the language vendor.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See also
 [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
