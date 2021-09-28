---
description: "Learn more about: ISymUnmanagedReader::GetSymAttribute Method"
title: "ISymUnmanagedReader::GetSymAttribute Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetSymAttribute"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetSymAttribute"
helpviewer_keywords: 
  - "GetSymAttribute method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetSymAttribute method [.NET Framework debugging]"
ms.assetid: c675ce7e-76e7-45ff-8273-3b6489a2767c
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader::GetSymAttribute Method

Gets a custom attribute based upon its name. Unlike metadata custom attributes, these custom attributes are held in the symbol store.  
  
## Syntax  
  
```cpp  
HRESULT GetSymAttribute (  
    [in]  mdToken  parent,  
    [in]  WCHAR    *name,  
    [in]  ULONG32  cBuffer,  
    [out] ULONG32  *pcBuffer,  
    [out, size_is (cBuffer),  
        length_is (*pcBuffer)] BYTE buffer[]);  
```  
  
## Parameters  

 `parent`  
 [in] The metadata token for the object for which the attribute is requested.  
  
 `name`  
 [in] A pointer to the variable that indicates the attribute to retrieve.  
  
 `cBuffer`  
 [in] The size of the `buffer` array.  
  
 `pcBuffer`  
 [out] A pointer to the variable that receives the length of the attribute data.  
  
 `buffer`  
 [out] A pointer to the variable that receives the attribute data.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedReader Interface](isymunmanagedreader-interface.md)
