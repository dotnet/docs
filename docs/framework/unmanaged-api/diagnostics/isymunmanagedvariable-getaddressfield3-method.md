---
description: "Learn more about: ISymUnmanagedVariable::GetAddressField3 Method"
title: "ISymUnmanagedVariable::GetAddressField3 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedVariable.GetAddressField3"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetAddressField3"
helpviewer_keywords: 
  - "ISymUnmanagedVariable::GetAddressField3 method [.NET Framework debugging]"
  - "GetAddressField3 method [.NET Framework debugging]"
ms.assetid: 4d834721-ad8d-439d-b356-c6b4aef022fc
topic_type: 
  - "apiref"
---
# ISymUnmanagedVariable::GetAddressField3 Method

Gets the third address field for this variable. Its meaning depends on the kind of address.  
  
## Syntax  
  
```cpp  
HRESULT GetAddressField3(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the third address field.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedVariable Interface](isymunmanagedvariable-interface.md)
- [GetAddressField1 Method](isymunmanagedvariable-getaddressfield1-method.md)
- [GetAddressField2 Method](isymunmanagedvariable-getaddressfield2-method.md)
- [GetAddressKind Method](isymunmanagedvariable-getaddresskind-method.md)
