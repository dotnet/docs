---
description: "Learn more about: ISymUnmanagedMethod::GetSequencePointCount Method"
title: "ISymUnmanagedMethod::GetSequencePointCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedMethod.GetSequencePointCount"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetSequencePointCount"
helpviewer_keywords: 
  - "ISymUnmanagedMethod::GetSequencePointCount method [.NET Framework debugging]"
  - "GetSequencePointCount method [.NET Framework debugging]"
ms.assetid: 836133e8-6108-4b9b-b0a9-bce4e08dccda
topic_type: 
  - "apiref"
---
# ISymUnmanagedMethod::GetSequencePointCount Method

Gets the count of sequence points within this method.  
  
## Syntax  
  
```cpp  
HRESULT GetSequencePointCount(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the sequence points.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedMethod Interface](isymunmanagedmethod-interface.md)
