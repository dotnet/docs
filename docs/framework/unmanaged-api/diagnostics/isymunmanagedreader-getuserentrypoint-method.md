---
title: "ISymUnmanagedReader::GetUserEntryPoint Method"
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
  - "ISymUnmanagedReader.GetUserEntryPoint"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetUserEntryPoint"
helpviewer_keywords: 
  - "GetUserEntryPoint method [.NET Framework debugging]"
  - "ISymUnmanagedReader::GetUserEntryPoint method [.NET Framework debugging]"
ms.assetid: 3fd3a34c-d176-46e9-9996-fb1646cff9b0
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedReader::GetUserEntryPoint Method
Returns the method that was specified as the user entry point for the module, if any. For example, this method could be the user's main method rather than compiler-generated stubs before the main method.  
  
## Syntax  
  
```  
HRESULT GetUserEntryPoint (  
    [out, retval]  mdMethodDef  *pToken);  
```  
  
#### Parameters  
 `pToken`  
 [out] A pointer to a variable that receives the entry point.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
