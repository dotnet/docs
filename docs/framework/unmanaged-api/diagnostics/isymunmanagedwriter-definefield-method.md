---
title: "ISymUnmanagedWriter::DefineField Method"
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
  - "ISymUnmanagedWriter.DefineField"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::DefineField"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::DefineField method [.NET Framework debugging]"
  - "DefineField method, ISymUnmanagedWriter interface [.NET Framework debugging]"
ms.assetid: c6a1f797-dbf4-40f5-ab99-d9b4bfb26148
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::DefineField Method
Defines a single variable that is not within a method. This method is used for certain fields in classes, bit fields, and so on.  
  
## Syntax  
  
```  
HRESULT DefineField(  
    [in] mdTypeDef    parent,  
    [in] const WCHAR  *name,  
    [in] ULONG32      attributes,  
    [in] ULONG32      cSig,  
    [in, size_is(cSig)] unsigned char signature[],  
    [in] ULONG32      addrKind,  
    [in] ULONG32      addr1,  
    [in] ULONG32      addr2,  
    [in] ULONG32      addr3);  
```  
  
#### Parameters  
 `parent`  
 [in] The metadata type or method token.  
  
 `name`  
 [in] The field name.  
  
 `attributes`  
 [in] The field attributes.  
  
 `cSig`  
 [in] A `ULONG32` that is the size, in characters, of the buffer required to contain the field signature.  
  
 `signature`  
 [in] The array of field signatures.  
  
 `addrKind`  
 [in] The address type.  
  
 `addr1`  
 [in] The first address for the field specification.  
  
 `addr2`  
 [in] The second address for the field specification.  
  
 `addr3`  
 [in] The third address for the field specification.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
