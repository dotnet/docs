---
title: "ISymUnmanagedWriter3::OpenMethod2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter3.OpenMethod2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter3::OpenMethod2"
helpviewer_keywords: 
  - "ISymUnmanagedWriter3::OpenMethod2 method [.NET Framework debugging]"
  - "OpenMethod2 method [.NET Framework debugging]"
ms.assetid: 025e358c-448f-4423-a2f2-57acf437c8a5
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter3::OpenMethod2 Method
Opens a method and provides its real section offset in the image.  
  
## Syntax  
  
```cpp  
HRESULT OpenMethod2(   
    [in] mdMethodDef method,  
    [in] ULONG32 isect,  
    [in] ULONG32 offset);  
```  
  
## Parameters  
 `method`  
 [in] The metadata token for the method to be opened.  
  
 `isect`  
 [in] The section offset in the image.  
  
 `offset`  
 [in] The offset in the image.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter3 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter3-interface.md)
- [OpenMethod Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-openmethod-method.md)
