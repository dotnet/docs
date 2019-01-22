---
title: "ISymUnmanagedReader::GetDocuments Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetDocuments"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetDocuments"
helpviewer_keywords: 
  - "GetDocuments method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetDocuments method [.NET Framework debugging]"
ms.assetid: e3b73a3f-d089-4101-a9a9-5e0765d05b61
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedReader::GetDocuments Method
Returns an array of all the documents defined in the symbol store.  
  
## Syntax  
  
```  
HRESULT GetDocuments (  
    [in]  ULONG32  cDocs,  
    [out] ULONG32  *pcDocs,  
    [out, size_is (cDocs),  
        length_is (*pcDocs)] ISymUnmanagedDocument *pDocs[]);  
```  
  
#### Parameters  
 `cDocs`  
 [in] The size of the `pDocs` array.  
  
 `pcDocs`  
 [out] A pointer to a variable that receives the array length.  
  
 `pDocs`  
 [out] A pointer to a variable that receives the document array.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
