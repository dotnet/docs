---
description: "Learn more about: ISymUnmanagedWriter2::DefineConstant2 Method"
title: "ISymUnmanagedWriter2::DefineConstant2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter2.DefineConstant2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter2::DefineConstant2"
helpviewer_keywords: 
  - "DefineConstant2 method [.NET Framework debugging]"
  - "ISymUnmanagedWriter2::DefineConstant2 method [.NET Framework debugging]"
ms.assetid: dd2bc956-7dbe-49fc-a646-daa0d267f2df
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter2::DefineConstant2 Method

Defines a name for a constant value.  
  
## Syntax  
  
```cpp  
HRESULT DefineConstant2(  
    [in] const WCHAR  *name,  
    [in] VARIANT      value,  
    [in] mdSignature  sigToken);  
```  
  
## Parameters  

 `name`  
 [in] The constant name.  
  
 `value`  
 [in] The value of the constant.  
  
 `sigToken`  
 [in] The metadata token of the constant.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter2 Interface](isymunmanagedwriter2-interface.md)
- [DefineConstant Method](isymunmanagedwriter-defineconstant-method.md)
