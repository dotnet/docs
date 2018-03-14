---
title: "ISymUnmanagedWriter::DefineParameter Method"
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
  - "ISymUnmanagedWriter.DefineParameter"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::DefineParameter"
helpviewer_keywords: 
  - "DefineParameter method [.NET Framework debugging]"
  - "ISymUnmanagedWriter::DefineParameter method [.NET Framework debugging]"
ms.assetid: a8e3dd32-6a44-4371-9a74-f417b11998c8
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter::DefineParameter Method
Defines a single parameter in the current method. The parameter type is taken from the parameter's position (sequence) within the method's signature.  
  
 If parameters are defined in the metadata for a given method, you do not have to define them again by using this method. The symbol readers must check the normal metadata for the parameters before checking the symbol store.  
  
## Syntax  
  
```  
HRESULT DefineParameter(  
    [in] const WCHAR  *name,  
    [in] ULONG32      attributes,  
    [in] ULONG32      sequence,  
    [in] ULONG32      addrKind,  
    [in] ULONG32      addr1,  
    [in] ULONG32      addr2,  
    [in] ULONG32      addr3);  
```  
  
#### Parameters  
 `name`  
 [in] The parameter name.  
  
 `attributes`  
 [in] The parameter attributes.  
  
 `sequence`  
 [in] The parameter signature.  
  
 `addrKind`  
 [in] The address type.  
  
 `addr1`  
 [in] The first address for the parameter specification.  
  
 `addr2`  
 [in] The second address for the parameter specification.  
  
 `addr3`  
 [in] The third address for the parameter specification.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-interface.md)
