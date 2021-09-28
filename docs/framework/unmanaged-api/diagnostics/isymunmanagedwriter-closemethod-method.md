---
description: "Learn more about: ISymUnmanagedWriter::CloseMethod Method"
title: "ISymUnmanagedWriter::CloseMethod Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.CloseMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::CloseMethod"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::CloseMethod method [.NET Framework debugging]"
  - "CloseMethod method [.NET Framework debugging]"
ms.assetid: b8025e04-f0e5-40c8-849c-8cd51323420e
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::CloseMethod Method

Closes the current method. Once a method is closed, no more symbols can be defined within it.  
  
## Syntax  
  
```cpp  
HRESULT CloseMethod();  
```  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
- [OpenMethod Method](isymunmanagedwriter-openmethod-method.md)
