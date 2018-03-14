---
title: "ISymUnmanagedScope::GetChildren Method"
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
  - "ISymUnmanagedScope.GetChildren"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetChildren"
helpviewer_keywords: 
  - "ISymUnmanagedScope::GetChildren method [.NET Framework debugging]"
  - "GetChildren method [.NET Framework debugging]"
ms.assetid: 0bed524e-cc48-4bf0-b9fa-25d665e63ddb
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedScope::GetChildren Method
Gets the children of this scope.  
  
## Syntax  
  
```  
HRESULT GetChildren(  
    [in]  ULONG32  cChildren,  
    [out] ULONG32  *pcChildren,  
    [out, size_is(cChildren),  
        length_is(*pcChildren)] ISymUnmanagedScope* children[]);  
```  
  
#### Parameters  
 `cChildren`  
 [in] A `ULONG32` that indicates the size of the `children` array.  
  
 `pcChildren`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the children.  
  
 `children`  
 [out] The returned array of children.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)  
 [GetParent Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getparent-method.md)
