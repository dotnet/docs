---
title: "ISymUnmanagedWriter2::DefineConstant2 Method"
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
  - "ISymUnmanagedWriter2.DefineConstant2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter2::DefineConstant2"
helpviewer_keywords: 
  - "DefineConstant2 method [.NET Framework debugging]"
  - "ISymUnmanagedWriter2::DefineConstant2 method [.NET Framework debugging]"
ms.assetid: dd2bc956-7dbe-49fc-a646-daa0d267f2df
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter2::DefineConstant2 Method
Defines a name for a constant value.  
  
## Syntax  
  
```  
HRESULT DefineConstant2(  
    [in] const WCHAR  *name,  
    [in] VARIANT      value,  
    [in] mdSignature  sigToken);  
```  
  
#### Parameters  
 `name`  
 [in] The constant name.  
  
 `value`  
 [in] The value of the constant.  
  
 `sigToken`  
 [in] The metadata token of the constant.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter2-interface.md)  
 [DefineConstant Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-defineconstant-method.md)
