---
description: "Learn more about: ISymUnmanagedWriter::DefineGlobalVariable Method"
title: "ISymUnmanagedWriter::DefineGlobalVariable Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.DefineGlobalVariable"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::DefineGlobalVariable"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::DefineGlobalVariable method [.NET Framework debugging]"
  - "DefineGlobalVariable method [.NET Framework debugging]"
ms.assetid: 843c904a-8176-4d8f-bd47-b4d4c29f4c5c
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::DefineGlobalVariable Method

Defines a single global variable.  
  
## Syntax  
  
```cpp  
HRESULT DefineGlobalVariable(  
    [in] const WCHAR  *name,  
    [in] ULONG32      attributes,  
    [in] ULONG32      cSig,  
    [in, size_is(cSig)] unsigned char signature[],  
    [in] ULONG32      addrKind,  
    [in] ULONG32      addr1,  
    [in] ULONG32      addr2,  
    [in] ULONG32      addr3);  
```  
  
## Parameters  

 `name`  
 [in] A pointer to a `WCHAR` that defines the global variable name.  
  
 `attributes`  
 [in] The global variable attributes.  
  
 `cSig`  
 [in] A `ULONG32` that indicates the size, in characters, of the `signature` buffer.  
  
 `signature`  
 [in] The global variable signature.  
  
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
  
## See also

- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
- [DefineLocalVariable Method](isymunmanagedwriter-definelocalvariable-method.md)
- [DefineGlobalVariable2 Method](isymunmanagedwriter2-defineglobalvariable2-method.md)
