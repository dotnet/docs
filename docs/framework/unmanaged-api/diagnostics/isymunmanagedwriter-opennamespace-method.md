---
title: "ISymUnmanagedWriter::OpenNamespace Method"
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
  - "ISymUnmanagedWriter.OpenNamespace"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::OpenNamespace"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::OpenNamespace method [.NET Framework debugging]"
  - "OpenNamespace method [.NET Framework debugging]"
ms.assetid: 426f4e4f-e60d-4ad1-b546-a10e3c55c283
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::OpenNamespace Method
Opens a new namespace. Call this method before defining methods or variables that occupy a namespace. Namespaces can be nested.  
  
## Syntax  
  
```  
HRESULT OpenNamespace(  
    [in] const WCHAR *name);  
```  
  
#### Parameters  
 `name`  
 [in] A pointer to the name of the new namespace.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)  
 [CloseNamespace Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-closenamespace-method.md)
