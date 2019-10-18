---
title: "ISymUnmanagedDocumentWriter::SetSource Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedDocumentWriter.SetSource"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDocumentWriter::SetSource"
helpviewer_keywords: 
  - "ISymUnmanagedDocumentWriter::SetSource method [.NET Framework debugging]"
  - "SetSource method [.NET Framework debugging]"
ms.assetid: ea5b9d9f-ff06-4bd3-8de5-6435343aba59
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedDocumentWriter::SetSource Method
Sets embedded source for a document that is being written.  
  
## Syntax  
  
```cpp  
HRESULT SetSource(  
    [in]  ULONG32  sourceSize,  
    [in, size_is(sourceSize)] BYTE  source[]);  
```  
  
## Parameters  
 `sourceSize`  
 [in] A `ULONG32` that contains the size of the `source` buffer.  
  
 `source`  
 [in] The buffer that stores the embedded source.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedDocumentWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddocumentwriter-interface.md)
