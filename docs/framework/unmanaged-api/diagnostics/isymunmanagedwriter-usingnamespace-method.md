---
title: "ISymUnmanagedWriter::UsingNamespace Method"
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
  - "ISymUnmanagedWriter.UsingNamespace"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::UsingNamespace"
helpviewer_keywords: 
  - "UsingNamespace method [.NET Framework debugging]"
  - "ISymUnmanagedWriter::UsingNamespace method [.NET Framework debugging]"
ms.assetid: 8d746e0a-d158-4983-88da-db0a0856bc0b
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::UsingNamespace Method
Specifies that the given fully qualified namespace name is being used within the currently open lexical scope. The namespace will be used within all scopes that inherit from the currently open scope. Closing the current scope will also stop the use of the namespace.  
  
## Syntax  
  
```  
HRESULT UsingNamespace(  
    [in] const WCHAR *fullName);  
```  
  
#### Parameters  
 `fullName`  
 [in] A pointer to the fully qualified name of the namespace.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
