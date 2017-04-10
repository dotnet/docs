---
title: "ISymUnmanagedScope::GetNamespaces Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ISymUnmanagedScope.GetNamespaces"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetNamespaces"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetNamespaces method, ISymUnmanagedScope interface [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetNamespaces method [.NET Framework debugging]"
ms.assetid: c44b0440-04bd-460a-84fb-41afecf44503
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedScope::GetNamespaces Method
Gets the namespaces that are being used within this scope.  
  
## Syntax  
  
```  
HRESULT GetNamespaces(  
    [in]  ULONG32  cNameSpaces,  
    [out] ULONG32  *pcNameSpaces,  
    [out, size_is(cNameSpaces),  
        length_is(*pcNameSpaces)]  
        ISymUnmanagedNamespace* namespaces[]);  
```  
  
#### Parameters  
 `cNameSpaces`  
 [in] The size of the `namespaces` array.  
  
 `pcNameSpaces`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the namespaces.  
  
 `namespaces`  
 [out] The array that receives the namespaces.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)