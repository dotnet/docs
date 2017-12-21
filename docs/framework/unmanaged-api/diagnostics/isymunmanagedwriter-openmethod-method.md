---
title: "ISymUnmanagedWriter::OpenMethod Method"
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
  - "ISymUnmanagedWriter.OpenMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::OpenMethod"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::OpenMethod method [.NET Framework debugging]"
  - "OpenMethod method [.NET Framework debugging]"
ms.assetid: fb90cb7f-af88-45e8-a99f-80a0bbddb08b
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::OpenMethod Method
Opens a method into which symbol information is emitted. The given method becomes the current method for calls to define sequence points, parameters, and lexical scopes. There is an implicit lexical scope around the entire method. Reopening a method that was previously closed erases any previously defined symbols for that method. There can be only one open method at a time.  
  
## Syntax  
  
```  
HRESULT OpenMethod(  
    [in] mdMethodDef method);  
```  
  
#### Parameters  
 `method`  
 [in] The metadata token for the method to be opened.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)  
 [CloseMethod Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-closemethod-method.md)  
 [OpenMethod2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter3-openmethod2-method.md)
