---
description: "Learn more about: ISymUnmanagedVariable::GetAddressField1 Method"
title: "ISymUnmanagedVariable::GetAddressField1 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedVariable.GetAddressField1"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedVariable::GetAddressField1"
helpviewer_keywords: 
  - "GetAddressField1 method [.NET Framework debugging]"
  - "ISymUnmanagedVariable::GetAddressField1 method [.NET Framework debugging]"
ms.assetid: 25788ed1-0ce3-4b97-96fc-88f8997812a3
topic_type: 
  - "apiref"
---
# ISymUnmanagedVariable::GetAddressField1 Method

Gets the first address field for this variable. Its meaning depends on the kind of address.  
  
## Syntax  
  
```cpp  
HRESULT GetAddressField1(  
    [out, retval] ULONG32* pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the first address field.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedVariable Interface](isymunmanagedvariable-interface.md)
- [GetAddressField2 Method](isymunmanagedvariable-getaddressfield2-method.md)
- [GetAddressField3 Method](isymunmanagedvariable-getaddressfield3-method.md)
- [GetAddressKind Method](isymunmanagedvariable-getaddresskind-method.md)
