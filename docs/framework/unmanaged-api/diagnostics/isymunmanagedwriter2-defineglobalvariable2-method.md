---
description: "Learn more about: ISymUnmanagedWriter2::DefineGlobalVariable2 Method"
title: "ISymUnmanagedWriter2::DefineGlobalVariable2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter2.DefineGlobalVariable2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter2::DefineGlobalVariable2"
helpviewer_keywords: 
  - "ISymUnmanagedWriter2::DefineGlobalVariable2 method [.NET Framework debugging]"
  - "DefineGlobalVariable2 method [.NET Framework debugging]"
ms.assetid: 04d569d6-a151-4957-9872-f3f694c3e4a9
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter2::DefineGlobalVariable2 Method

Defines a single global variable.  
  
## Syntax  
  
```cpp  
HRESULT DefineGlobalVariable2(  
    [in] const WCHAR  *name,  
    [in] ULONG32      attributes,  
    [in] mdSignature  sigToken,  
    [in] ULONG32      addrKind,  
    [in] ULONG32      addr1,  
    [in] ULONG32      addr2,  
    [in] ULONG32      addr3);  
```  
  
## Parameters  

 `name`  
 [in] The global variable name.  
  
 `attributes`  
 [in] The global variable attributes.  
  
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
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl  
  
## See also

- [ISymUnmanagedWriter2 Interface](isymunmanagedwriter2-interface.md)
- [DefineGlobalVariable Method](isymunmanagedwriter-defineglobalvariable-method.md)
