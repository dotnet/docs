---
title: "ISymUnmanagedWriter::SetUserEntryPoint Method"
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
  - "ISymUnmanagedWriter.SetUserEntryPoint"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::SetUserEntryPoint"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::SetUserEntryPoint method [.NET Framework debugging]"
  - "SetUserEntryPoint method [.NET Framework debugging]"
ms.assetid: d4dcc575-3ac8-4453-9be1-2b24f47363d7
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::SetUserEntryPoint Method
Specifies the user-defined method that is the entry point for this module. For example, this entry point could be the user's main method instead of compiler-generated stubs before main.  
  
## Syntax  
  
```  
HRESULT SetUserEntryPoint(  
    [in] mdMethodDef entryMethod);  
```  
  
#### Parameters  
 `entryMethod`  
 [in] The metadata token for the method that is the user entry point.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
