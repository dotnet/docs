---
description: "Learn more about: ISymUnmanagedWriter2 Interface"
title: "ISymUnmanagedWriter2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedWriter2"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter2"
helpviewer_keywords: 
  - "ISymUnmanagedWriter2 interface [.NET Framework debugging]"
ms.assetid: 8e78faa4-cf43-44fb-a91d-94d6df692a25
topic_type: 
  - "apiref"
---
# ISymUnmanagedWriter2 Interface

Represents a symbol writer, and provides methods to define documents, sequence points, lexical scopes, and variables. This interface extends the [ISymUnmanagedWriter](isymunmanagedwriter-interface.md) interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DefineConstant2 Method](isymunmanagedwriter2-defineconstant2-method.md)|Defines a name for a constant value.|  
|[DefineGlobalVariable2 Method](isymunmanagedwriter2-defineglobalvariable2-method.md)|Defines a single global variable.|  
|[DefineLocalVariable2 Method](isymunmanagedwriter2-definelocalvariable2-method.md)|Defines a single variable in the current lexical scope.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
- [ISymUnmanagedWriter Interface](isymunmanagedwriter-interface.md)
- [ISymUnmanagedWriter3 Interface](isymunmanagedwriter3-interface.md)
