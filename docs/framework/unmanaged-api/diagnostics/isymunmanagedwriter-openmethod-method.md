---
description: "Learn more about: ISymUnmanagedWriter::OpenMethod Method"
title: "ISymUnmanagedWriter::OpenMethod Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.OpenMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::OpenMethod"
helpviewer_keywords: 
  - "ISymUnmanagedWriter::OpenMethod method [.NET Framework debugging]"
  - "OpenMethod method [.NET Framework debugging]"
ms.assetid: fb90cb7f-af88-45e8-a99f-80a0bbddb08b
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::OpenMethod Method

Opens a method into which symbol information is emitted. The given method becomes the current method for calls to define sequence points, parameters, and lexical scopes. There is an implicit lexical scope around the entire method. Reopening a method that was previously closed erases any previously defined symbols for that method. There can be only one open method at a time.  
  
## Syntax  
  
```cpp  
HRESULT OpenMethod(  
    [in] mdMethodDef method);  
```  
  
## Parameters  

 `method`  
 [in] The metadata token for the method to be opened.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
- [CloseMethod Method](isymunmanagedwriter-closemethod-method.md)
- [OpenMethod2 Method](isymunmanagedwriter3-openmethod2-method.md)
