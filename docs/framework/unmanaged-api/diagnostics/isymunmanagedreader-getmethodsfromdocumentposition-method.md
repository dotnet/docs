---
description: "Learn more about: ISymUnmanagedReader::GetMethodsFromDocumentPosition Method"
title: "ISymUnmanagedReader::GetMethodsFromDocumentPosition Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetMethodsFromDocumentPosition"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetMethodsFromDocumentPosition"
helpviewer_keywords: 
  - "GetMethodsFromDocumentPosition method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetMethodsFromDocumentPosition method [.NET Framework debugging]"
ms.assetid: 83605f1e-e4f3-49e6-859b-f13cad68bb54
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader::GetMethodsFromDocumentPosition Method

Returns an array of methods, each of which contains the breakpoint at the given position in a document.  
  
## Syntax  
  
```cpp  
HRESULT GetMethodsFromDocumentPosition (  
    [in]  ISymUnmanagedDocument* document,  
    [in]  ULONG32 line,  
    [in]  ULONG32 column,  
    [in]  ULONG32 cMethod,  
    [out] ULONG32* pcMethod,  
    [out, size_is (cMethod),  
        length_is (*pcMethod)] ISymUnmanagedMethod* pRetVal[]);  
```  
  
## Parameters  

 `document`  
 [in] The specified document.  
  
 `line`  
 [in] The line of the specified document.  
  
 `column`  
 [in] The column of the specified document.  
  
 `cMethod`  
 [in] The size of the `pRetVal` array.  
  
 `pcMethod`  
 [out] A pointer to a variable that receives the number of elements returned in the `pRetVal` array.  
  
 `pRetVal`  
 [out] An array of pointers, each of which points to an [ISymUnmanagedMethod](isymunmanagedmethod-interface.md) object that represents a method containing the breakpoint.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)
