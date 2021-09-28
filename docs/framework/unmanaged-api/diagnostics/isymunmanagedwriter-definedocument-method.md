---
description: "Learn more about: ISymUnmanagedWriter::DefineDocument Method"
title: "ISymUnmanagedWriter::DefineDocument Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.DefineDocument"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::DefineDocument"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::DefineDocument method [.NET Framework debugging]"
  - "DefineDocument method [.NET Framework debugging]"
ms.assetid: c3bf15b0-3250-4bbe-b9b5-c5d695289b6f
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::DefineDocument Method

Defines a source document. GUIDs are provided for known languages, vendors, and document types.  
  
## Syntax  
  
```cpp  
HRESULT DefineDocument(  
    [in]  const WCHAR  *url,  
    [in]  const GUID   *language,  
    [in]  const GUID   *languageVendor,  
    [in]  const GUID   *documentType,  
    [out, retval] ISymUnmanagedDocumentWriter**  pRetVal);  
```  
  
## Parameters  

 `url`  
 [in] A pointer to a `WCHAR` that defines the uniform resource locator (URL) that identifies the document.  
  
 `language`  
 [in] A pointer to a GUID that defines the document language.  
  
 `languageVendor`  
 [in] A pointer to a GUID that defines the identity of the vendor for the document language.  
  
 `documentType`  
 [in] A pointer to a GUID that defines the type of the document.  
  
 `pRetVal`  
 [out] A pointer to the returned [ISymUnmanagedWriter](isymunmanagedwriter-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
