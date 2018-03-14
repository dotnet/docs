---
title: "ISymUnmanagedWriter::SetScopeRange Method"
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
  - "ISymUnmanagedWriter.SetScopeRange"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::SetScopeRange"
helpviewer_keywords: 
  - "SetScopeRange method [.NET Framework debugging]"
  - "ISymUnmanagedWriter::SetScopeRange method [.NET Framework debugging]"
ms.assetid: d4d98676-444b-46ca-bfe6-0d827385cd22
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::SetScopeRange Method
Defines the offset range for the specified lexical scope. The scope becomes the new current scope and is pushed onto a stack of scopes. Scopes must form a hierarchy. Siblings are not allowed to overlap.  
  
## Syntax  
  
```  
HRESULT OpenScope(  
    [in] ULONG32  scopeID,  
    [in] ULONG32  startOffset,  
    [in] ULONG32  endOffset);  
```  
  
#### Parameters  
 `scopeId`  
 [in] The scope identifier for the scope.  
  
 `startOffset`  
 [in] The offset, in bytes, of the first instruction in the lexical scope from the beginning of the method.  
  
 `endOffset`  
 [in] The offset, in bytes, of the last instruction in the lexical scope from the beginning of the method.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Remarks  
 [ISymUnmanagedWriter::OpenScope](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-openscope-method.md) returns an opaque scope identifier that can be used with `ISymUnmanagedWriter::SetScopeRange` to define a scope's starting and ending offset at a later time. In this case, the offsets passed to `ISymUnmanagedWriter::OpenScope` and [ISymUnmanagedWriter::CloseScope](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-closescope-method.md) are ignored. Scope identifiers are only valid in the current method.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
