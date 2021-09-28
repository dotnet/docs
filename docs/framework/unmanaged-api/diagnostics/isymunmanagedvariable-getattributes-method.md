---
description: "Learn more about: ISymUnmanagedVariable::GetAttributes Method"
title: "ISymUnmanagedVariable::GetAttributes Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedVariable.GetAttributes"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetAttributes"
helpviewer_keywords: 
  - "GetAttributes method [.NET Framework debugging]"
  - "ISymUnmanagedVariable::GetAttributes method [.NET Framework debugging]"
ms.assetid: 80f168af-a6a6-4c8f-b9e6-8a82dc834ed5
topic_type: 
  - "apiref"
---
# ISymUnmanagedVariable::GetAttributes Method

Gets the attribute flags for this variable.  
  
## Syntax  
  
```cpp  
HRESULT GetAttributes(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the attributes. The returned value will be one of the values defined in the [CorSymVarFlag](corsymvarflag-enumeration.md) enumeration.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedVariable Interface](isymunmanagedvariable-interface.md)
