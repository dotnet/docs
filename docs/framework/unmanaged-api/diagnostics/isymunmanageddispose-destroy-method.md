---
title: "ISymUnmanagedDispose::Destroy Method"
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
  - "ISymUnmanagedDispose.Destroy"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedDispose::Destroy"
helpviewer_keywords: 
  - "ISymUnmanagedDispose::Destroy method [.NET Framework debugging]"
  - "Destroy method [.NET Framework debugging]"
ms.assetid: a854ab9f-d2ba-470e-867f-808c1e7bd07a
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedDispose::Destroy Method
Causes the underlying object to release all internal references and return failure on any subsequent method calls.  
  
## Syntax  
  
```  
HRESULT Destroy();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedDispose Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanageddispose-interface.md)
