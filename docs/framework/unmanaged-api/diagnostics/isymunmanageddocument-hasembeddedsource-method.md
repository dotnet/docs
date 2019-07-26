---
title: "ISymUnmanagedDocument::HasEmbeddedSource Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocument.HasEmbeddedSource"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocument::HasEmbeddedSource"
helpviewer_keywords: 
  - "HasEmbeddedSource method [.NET Framework debugging]"
  - "ISymUnmanagedDocument::HasEmbeddedSource method [.NET Framework debugging]"
ms.assetid: 385fc4d3-365c-4645-b7b0-6c4c5344b79f
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedDocument::HasEmbeddedSource Method
Returns `true` if the document has source embedded in the debugging symbols; otherwise, returns `false`.  
  
## Syntax  
  
```cpp  
HRESULT HasEmbeddedSource(  
   [out, retval]  BOOL  *pRetVal);  
```  
  
## Parameters  
 `pRetVal`  
 [out] A pointer to a variable that indicates whether the document has source embedded in the debugging symbols.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## See also

- [ISymUnmanagedDocument Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocument-interface.md)
