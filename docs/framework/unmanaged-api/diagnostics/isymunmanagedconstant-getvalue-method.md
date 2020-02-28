---
title: "ISymUnmanagedConstant::GetValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedConstant.GetValue"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedConstant::GetValue"
helpviewer_keywords: 
  - "GetValue method, ISymUnmanagedConstant interface [.NET Framework debugging]"
  - "ISymUnmanagedConstant::GetValue method [.NET Framework debugging]"
ms.assetid: 0036fc10-e768-47a8-b9cf-bf47faf8d194
topic_type: 
  - "apiref"
---
# ISymUnmanagedConstant::GetValue Method
Gets the value of the constant.  
  
## Syntax  
  
```cpp  
HRESULT GetValue(  
    [out]  VARIANT* pValue  
);  
```  
  
## Parameters  
 `pValue`  
 [out] A pointer to a variable that receives the value.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedConstant Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-interface.md)
- [GetName Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-getname-method.md)
- [GetSignature Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedconstant-getsignature-method.md)
