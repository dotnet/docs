---
description: "Learn more about: ISymUnmanagedReader::GetMethodFromDocumentPosition Method"
title: "ISymUnmanagedReader::GetMethodFromDocumentPosition Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetMethodFromDocumentPosition"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetMethodFromDocumentPosition"
helpviewer_keywords: 
  - "GetMethodFromDocumentPosition method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetMethodFromDocumentPosition method [.NET Framework debugging]"
ms.assetid: 55773dbc-9053-46e3-8a3c-86caa9d91fb4
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader::GetMethodFromDocumentPosition Method

Returns the method that contains the breakpoint at the given position in a document.  
  
## Syntax  
  
```cpp  
HRESULT GetMethodFromDocumentPosition (  
    [in]  ISymUnmanagedDocument*  document,  
    [in]  ULONG32  line,  
    [in]  ULONG32  column,  
    [out, retval] ISymUnmanagedMethod**  pRetVal);  
```  
  
## Parameters  

 `document`  
 [in] The specified document.  
  
 `line`  
 [in] The line of the specified document.  
  
 `column`  
 [in] The column of the specified document.  
  
 `pRetVal`  
 [out] A pointer to the address of a [ISymUnmanagedMethod Interface](isymunmanagedmethod-interface.md) object that represents the method containing the breakpoint.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)
