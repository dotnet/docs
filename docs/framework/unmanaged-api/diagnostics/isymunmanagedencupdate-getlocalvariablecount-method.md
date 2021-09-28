---
description: "Learn more about: ISymUnmanagedENCUpdate::GetLocalVariableCount Method"
title: "ISymUnmanagedENCUpdate::GetLocalVariableCount Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedENCUpdate.GetLocalVariableCount"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedENCUpdate::GetLocalVariableCount"
helpviewer_keywords: 
  - "ISymUnmanagedENCUpdate::GetLocalVariableCount method [.NET Framework debugging]"
  - "GetLocalVariableCount method [.NET Framework debugging]"
ms.assetid: 9777d8bb-4abc-4be8-aa7c-34f853eceb9c
topic_type: 
  - "apiref"
---
# ISymUnmanagedENCUpdate::GetLocalVariableCount Method

Gets the number of local variables.  
  
## Syntax  
  
```cpp  
HRESULT GetLocalVariableCount(  
    [in]  mdMethodDef  mdMethodToken,  
    [out] ULONG        *pcLocals);  
```  
  
## Parameters  

 `mdMethodToken`  
 [in] The metadata token of methods.  
  
 `pcLocals`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the number of local variables.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedENCUpdate Interface](isymunmanagedencupdate-interface.md)
