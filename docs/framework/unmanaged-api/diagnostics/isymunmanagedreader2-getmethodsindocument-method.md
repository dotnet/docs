---
description: "Learn more about: ISymUnmanagedReader2::GetMethodsInDocument Method"
title: "ISymUnmanagedReader2::GetMethodsInDocument Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader2.GetMethodsInDocument"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader2::GetMethodsInDocument"
helpviewer_keywords: 
  - "ISymUnmanagedReader2::GetMethodsInDocument method [.NET Framework debugging]"
  - "GetMethodsInDocument method [.NET Framework debugging]"
ms.assetid: c7ae84d6-81e8-4cb7-a1f9-d48b6cde5d79
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader2::GetMethodsInDocument Method

Gets every method that has line information in the provided document.  
  
## Syntax  
  
```cpp  
HRESULT GetMethodsInDocument(  
    [in]  ISymUnmanagedDocument *document,  
    [in]  ULONG32 cMethod,  
    [out] ULONG32* pcMethod,  
    [out, size_is(cMethod),  
        length_is(*pcMethod)] ISymUnmanagedMethod* pRetVal[]);  
```  
  
## Parameters  

 `document`  
 [in] A pointer to the document.  
  
 `cMethod`  
 [in] A `ULONG32` that indicates the size of the  `pRetVal` array.  
  
 `pcMethod`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the methods.  
  
 `pRetVal`  
 [out] A pointer to the buffer that receives the methods.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReader2 Interface](isymunmanagedreader2-interface.md)
