---
description: "Learn more about: ISymUnmanagedReader::GetDocumentVersion Method"
title: "ISymUnmanagedReader::GetDocumentVersion Method"
ms.date: "03/30/2017"
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
---
# ISymUnmanagedReader::GetDocumentVersion Method

Gets the specified version of the specified document. The document version starts at 1 and is incremented each time the document is updated using the [UpdateSymbolStore](isymunmanagedreader-updatesymbolstore-method.md) method. If the `pbCurrent` parameter is `true`, this is the latest version of the document.  
  
## Syntax  
  
```cpp  
HRESULT GetDocumentVersion (  
    [in]  ISymUnmanagedDocument *pDoc,  
    [out] int* version,  
    [out] BOOL* pbCurrent);  
```  
  
## Parameters  

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
  
## See also

- [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)
