---
title: "ISymUnmanagedWriter3::Commit Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter3.Commit"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter3::Commit"
helpviewer_keywords: 
  - "Commit method, ISymUnmanagedWriter3 interface [.NET Framework debugging]"
  - "ISymUnmanagedWriter3::Commit method [.NET Framework debugging]"
ms.assetid: f6961922-46ec-4d2c-8369-85f880731f37
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter3::Commit Method
Commits the changes written so far to the stream.  
  
## Syntax  
  
```cpp  
HRESULT Commit();  
```  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter3 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter3-interface.md)
