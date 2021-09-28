---
description: "Learn more about: ISymUnmanagedWriter::CloseScope Method"
title: "ISymUnmanagedWriter::CloseScope Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter.CloseScope"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter::CloseScope"
helpviewer_keywords: 
  - "CloseScope method [.NET Framework debugging]"
  - "ISymUnmanagedWriter::CloseScope method [.NET Framework debugging]"
ms.assetid: 6dade525-7770-4cb4-bafd-4bb995ad0d87
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter::CloseScope Method

Closes the current lexical scope.  
  
## Syntax  
  
```cpp  
HRESULT CloseScope(  
    [in] ULONG32 endOffset);  
```  
  
## Parameters  

 `endOffset`  
 [in] The offset from the beginning of the method of the point at the end of the last instruction in the lexical scope, in bytes.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Remarks  

 Once a scope is closed, no more variables can be defined within it.  
  
 [ISymUnmanagedWriter::OpenScope](isymunmanagedwriter-openscope-method.md) returns an opaque scope identifier that can be used with [ISymUnmanagedWriter::SetScopeRange](isymunmanagedwriter-setscoperange-method.md) to later define a scope's starting and ending offset. In this case, the offsets passed to `ISymUnmanagedWriter::OpenScope` and `ISymUnmanagedWriter::CloseScope` are ignored. Scope identifiers are valid only in the current method.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
