---
title: "ISymUnmanagedWriter::OpenScope Method"
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
  - "ISymUnmanagedWriter.OpenScope"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::OpenScope"
helpviewer_keywords: 
  - "OpenScope method, ISymUnmanagedWriter interface [.NET Framework debugging]"
  - "ISymUnmanagedWriter::OpenScope method [.NET Framework debugging]"
ms.assetid: dbea0644-3873-4329-90b8-624163e87467
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::OpenScope Method
Opens a new lexical scope in the current method. The scope becomes the new current scope and is pushed onto a stack of scopes. Scopes must form a hierarchy. Siblings are not allowed to overlap.  
  
## Syntax  
  
```  
HRESULT OpenScope(  
    [in] ULONG32 startOffset,  
    [out, retval] ULONG32* pRetVal);  
```  
  
#### Parameters  
 `startOffset`  
 [in] The offset of the first instruction in the lexical scope, in bytes, from the beginning of the method.  
  
 `pRetVal`  
 [out] A pointer to a `ULONG32` that receives the scope identifier.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Remarks  
 `ISymUnmanagedWriter::OpenScope` returns an opaque scope identifier that can be used with [ISymUnmanagedWriter::SetScopeRange](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-setscoperange-method.md) to define a scope's starting and ending offset at a later time. In this case, the offsets passed to `ISymUnmanagedWriter::OpenScope` and [ISymUnmanagedWriter::CloseScope](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-closescope-method.md) are ignored. Scope identifiers are valid only in the current method.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
