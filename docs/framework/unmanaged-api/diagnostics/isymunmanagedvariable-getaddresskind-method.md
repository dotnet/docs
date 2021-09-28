---
description: "Learn more about: ISymUnmanagedVariable::GetAddressKind Method"
title: "ISymUnmanagedVariable::GetAddressKind Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedVariable.GetAddressKind"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetAddressKind"
helpviewer_keywords: 
  - "GetAddressKind method [.NET Framework debugging]"
  - "ISymUnmanagedVariable::GetAddressKind method [.NET Framework debugging]"
ms.assetid: a71563c0-62f2-4eb4-970c-825d61827613
topic_type: 
  - "apiref"
---
# ISymUnmanagedVariable::GetAddressKind Method

Gets the kind of address of this variable.  
  
## Syntax  
  
```cpp  
HRESULT GetAddressKind(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the value. The possible values are defined in the [CorSymAddrKind](corsymaddrkind-enumeration.md) enumeration.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedVariable Interface](isymunmanagedvariable-interface.md)
