---
title: "ISymUnmanagedVariable::GetAddressField1 Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedVariable::GetAddressField1 Method
Gets the first address field for this variable. Its meaning depends on the kind of address.  
  
## Syntax  
  
```  
HRESULT GetAddressField1(  
    [out, retval] ULONG32* pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the first address field.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedVariable Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-interface.md)  
 [GetAddressField2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getaddressfield2-method.md)  
 [GetAddressField3 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getaddressfield3-method.md)  
 [GetAddressKind Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedvariable-getaddresskind-method.md)
