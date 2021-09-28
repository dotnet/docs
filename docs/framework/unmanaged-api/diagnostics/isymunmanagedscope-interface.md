---
description: "Learn more about: ISymUnmanagedScope Interface"
title: "ISymUnmanagedScope Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope"
helpviewer_keywords: 
  - "ISymUnmanagedScope interface [.NET Framework debugging]"
ms.assetid: 3db7a220-cfe9-4810-8ca8-a094bb8e0f5b
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope Interface

Represents a lexical scope within a method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetChildren Method](isymunmanagedscope-getchildren-method.md)|Gets the children of this scope.|  
|[GetEndOffset Method](isymunmanagedscope-getendoffset-method.md)|Gets the end offset for this scope.|  
|[GetLocalCount Method](isymunmanagedscope-getlocalcount-method.md)|Gets a count of the local variables defined within this scope.|  
|[GetLocals Method](isymunmanagedscope-getlocals-method.md)|Gets the local variables defined within this scope.|  
|[GetMethod Method](isymunmanagedscope-getmethod-method.md)|Gets the method that contains this scope.|  
|[GetNamespaces Method](isymunmanagedscope-getnamespaces-method.md)|Gets the namespaces that are being used within this scope.|  
|[GetParent Method](isymunmanagedscope-getparent-method.md)|Gets the parent scope of this scope.|  
|[GetStartOffset Method](isymunmanagedscope-getstartoffset-method.md)|Gets the start offset for this scope.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedScope2 Interface](isymunmanagedscope2-interface.md)
