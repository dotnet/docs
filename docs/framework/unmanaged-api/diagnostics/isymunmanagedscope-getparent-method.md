---
title: "ISymUnmanagedScope::GetParent Method"
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
  - "ISymUnmanagedScope.GetParent"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetParent"
helpviewer_keywords: 
  - "GetParent method [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetParent method [.NET Framework debugging]"
ms.assetid: c7963c87-6ec5-49b3-a5cd-e0fe0c43f9b4
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedScope::GetParent Method
Gets the parent scope of this scope.  
  
## Syntax  
  
```  
HRESULT GetParent(  
    [out, retval] ISymUnmanagedScope** pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to the returned [ISymUnmanagedScope](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md) interface.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)  
 [GetChildren Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getchildren-method.md)
