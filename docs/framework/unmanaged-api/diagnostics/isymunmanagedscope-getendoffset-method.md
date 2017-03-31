---
title: "ISymUnmanagedScope::GetEndOffset Method | Microsoft Docs"
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
  - "ISymUnmanagedScope.GetEndOffset"
apilocation: 
  - "diasymreader.dll"
apitype: "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetEndOffset"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ISymUnmanagedScope::GetEndOffset method [.NET Framework debugging]"
  - "GetEndOffset method, ISymUnmanagedScope interface [.NET Framework debugging]"
ms.assetid: 1d0b15c9-8059-435f-9fce-346a08b9bd36
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ISymUnmanagedScope::GetEndOffset Method
Gets the end offset for this scope.  
  
## Syntax  
  
```  
HRESULT GetEndOffset(  
    [out, retval] ULONG32* pRetVal);  
```  
  
#### Parameters  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the end offset.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)   
 [GetStartOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getstartoffset-method.md)