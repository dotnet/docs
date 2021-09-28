---
description: "Learn more about: ISymUnmanagedScope2::GetConstants Method"
title: "ISymUnmanagedScope2::GetConstants Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope2.GetConstants"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope2::GetConstants"
helpviewer_keywords: 
  - "ISymUnmanagedScope2::GetConstants method [.NET Framework debugging]"
  - "GetConstants method [.NET Framework debugging]"
ms.assetid: f241b620-9ec5-42fd-92ef-3b22329db72a
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope2::GetConstants Method

Gets the local constants defined within this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetConstants(  
     [in]  ULONG32  cConstants,  
     [out] ULONG32  *pcConstants,  
     [out, size_is(cConstants),  
         length_is(*pcConstants)] ISymUnmanagedConstant*
             constants[]);  
```  
  
## Parameters  

 `cConstants`  
 [in] The length of the buffer that the `pcConstants` parameter points to.  
  
 `pcConstants`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the constants.  
  
 `constants`  
 [out] The buffer that stores the constants.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope2 Interface](isymunmanagedscope2-interface.md)
