---
description: "Learn more about: ISymUnmanagedWriter::DefineConstant Method"
title: "ISymUnmanagedWriter::DefineConstant Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.DefineConstant"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::DefineConstant"
helpviewer_keywords: 
  - "DefineConstant method [.NET Framework debugging]"
  - "ISymUnmanagedWriter::DefineConstant method [.NET Framework debugging]"
ms.assetid: 9e986986-2223-4d5f-b040-85d716146924
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::DefineConstant Method

Defines a name for a constant value.  
  
## Syntax  
  
```cpp  
HRESULT DefineConstant(  
    [in] const WCHAR *name,  
    [in] VARIANT value,  
    [in] ULONG32 cSig,  
    [in, size_is(cSig)] unsigned char signature[]);  
```  
  
## Parameters  

 `name`  
 [in] A pointer to a `WCHAR` that defines the constant name.  
  
 `value`  
 [in] The value of the constant.  
  
 `cSig`  
 [in] The size of the `signature` array.  
  
 `signature`  
 [in] The type signature for the constant.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
- [DefineConstant2 Method](isymunmanagedwriter2-defineconstant2-method.md)
