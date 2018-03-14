---
title: "ISymUnmanagedWriter::CloseMethod Method"
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
  - "ISymUnmanagedWriter.CloseMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::CloseMethod"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::CloseMethod method [.NET Framework debugging]"
  - "CloseMethod method [.NET Framework debugging]"
ms.assetid: b8025e04-f0e5-40c8-849c-8cd51323420e
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::CloseMethod Method
Closes the current method. Once a method is closed, no more symbols can be defined within it.  
  
## Syntax  
  
```  
HRESULT CloseMethod();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)  
 [OpenMethod Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-openmethod-method.md)
