---
title: "ISymUnmanagedWriter2::DefineLocalVariable2 Method"
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
  - "ISymUnmanagedWriter2.DefineLocalVariable2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter2::DefineLocalVariable2"
helpviewer_keywords: 
  - "ISymUnmanagedWriter2::DefineLocalVariable2 method [.NET Framework debugging]"
  - "DefineLocalVariable2 method [.NET Framework debugging]"
ms.assetid: e774eefe-858c-4362-8d2d-28ebf2ba1a24
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter2::DefineLocalVariable2 Method
Defines a single variable in the current lexical scope. This method can be called multiple times for a variable of the same name that has multiple homes throughout a scope. In this case, however, the values of the `startOffset` and `endOffset` parameters must not overlap.  
  
## Syntax  
  
```  
HRESULT DefineLocalVariable2(  
    [in] const WCHAR  *name,  
    [in] ULONG32      attributes,  
    [in] mdSignature  sigToken,  
    [in] ULONG32      addrKind,  
    [in] ULONG32      addr1,  
    [in] ULONG32      addr2,  
    [in] ULONG32      addr3,  
    [in] ULONG32      startOffset,  
    [in] ULONG32      endOffset);  
```  
  
#### Parameters  
 `name`  
 [in] The local variable name.  
  
 `attributes`  
 [in] The local variable attributes.  
  
 `sigToken`  
 [in] The metadata token of the signature.  
  
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
 **Header:** CorSym.idl  
  
## See Also  
 [ISymUnmanagedWriter2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter2-interface.md)  
 [DefineLocalVariable Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-definelocalvariable-method.md)
