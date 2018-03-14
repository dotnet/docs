---
title: "ISymUnmanagedWriter::DefineLocalVariable Method"
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
  - "ISymUnmanagedWriter.DefineLocalVariable"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::DefineLocalVariable"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::DefineLocalVariable method [.NET Framework debugging]"
  - "DefineLocalVariable method [.NET Framework debugging]"
ms.assetid: 6fab8a58-3883-490f-8b27-64042c90f104
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::DefineLocalVariable Method
Defines a single variable in the current lexical scope. This method can be called multiple times for a variable of the same name that has multiple homes throughout a scope. In this case, however, the values of the `startOffset` and `endOffset` parameters must not overlap.  
  
## Syntax  
  
```  
HRESULT DefineLocalVariable(  
    [in] const WCHAR  *name,  
    [in] ULONG32      attributes,  
    [in] ULONG32      cSig,  
    [in, size_is(cSig)] unsigned char signature[],  
    [in] ULONG32      addrKind,  
    [in] ULONG32      addr1,  
    [in] ULONG32      addr2,  
    [in] ULONG32      addr3,  
    [in] ULONG32      startOffset,  
    [in] ULONG32      endOffset);  
```  
  
#### Parameters  
 `name`  
 [in] A pointer to a `WCHAR` that defines the local variable name.  
  
 `attributes`  
 [in] The local variable attributes.  
  
 `cSig`  
 [in] A `ULONG32` that indicates the size, in bytes, of the `signature` buffer.  
  
 `signature`  
 [in] The local variable signature.  
  
 `addrKind`  
 [in] The address type.  
  
 `addr1`  
 [in] The first address for the parameter specification.  
  
 `addr2`  
 [in] The second address for the parameter specification.  
  
 `addr3`  
 [in] The third address for the parameter specification.  
  
 `startOffset`  
 [in] The start offset for the variable. This parameter is optional. If it is 0, this parameter is ignored and the variable is defined throughout the entire scope. If it is a nonzero value, the variable falls within the offsets of the current scope.  
  
 `endOffset`  
 [in] The end offset for the variable. This parameter is optional. If it is 0, this parameter is ignored and the variable is defined throughout the entire scope. If it is a nonzero value, the variable falls within the offsets of the current scope.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)  
 [DefineGlobalVariable Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-defineglobalvariable-method.md)  
 [DefineLocalVariable2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter2-definelocalvariable2-method.md)
