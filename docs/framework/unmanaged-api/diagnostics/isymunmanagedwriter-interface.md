---
title: "ISymUnmanagedWriter Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ISymUnmanagedWriter"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedWriter"
helpviewer_keywords: 
  - "ISymUnmanagedWriter interface [.NET Framework debugging]"
ms.assetid: 7d6733ec-f081-4166-bc17-de09e16dc304
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedWriter Interface
Represents a symbol writer, and provides methods to define documents, sequence points, lexical scopes, and variables.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Abort Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-abort-method.md)|Closes the symbol writer without committing the symbols to the symbol store.|  
|[Close Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-close-method.md)|Closes the symbol writer after committing the symbols to the symbol store.|  
|[CloseMethod Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-closemethod-method.md)|Closes the current method. Once a method is closed, no more symbols can be defined within it.|  
|[CloseNamespace Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-closenamespace-method.md)|Closes the most recently opened namespace.|  
|[CloseScope Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-closescope-method.md)|Closes the current lexical scope.|  
|[DefineConstant Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-defineconstant-method.md)|Defines a name for a constant value.|  
|[DefineDocument Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-definedocument-method.md)|Defines a source document.|  
|[DefineField Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-definefield-method.md)|Defines a single variable that is not within a method.|  
|[DefineGlobalVariable Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-defineglobalvariable-method.md)|Defines a single global variable.|  
|[DefineLocalVariable Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-definelocalvariable-method.md)|Defines a single variable in the current lexical scope.|  
|[DefineParameter Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-defineparameter-method.md)|Defines a single parameter in the current method.|  
|[DefineSequencePoints Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-definesequencepoints-method.md)|Defines a group of sequence points within the current method.|  
|[GetDebugInfo Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-getdebuginfo-method.md)|Returns the information necessary for a compiler to write the debug directory entry in the portable executable (PE) file header.|  
|[Initialize Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-initialize-method.md)|Sets the metadata emitter interface with which this writer will be associated, and sets the output file name to which the debugging symbols will be written.|  
|[Initialize2 Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-initialize2-method.md)|Sets the metadata emitter interface with which this writer will be associated, sets the output file name to which the debugging symbols will be written, and sets the final location of the program database (PDB) file.|  
|[OpenMethod Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-openmethod-method.md)|Opens a method into which symbol information is emitted.|  
|[OpenNamespace Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-opennamespace-method.md)|Opens a new namespace.|  
|[OpenScope Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-openscope-method.md)|Opens a new lexical scope in the current method.|  
|[RemapToken Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-remaptoken-method.md)|Notifies the symbol writer that a metadata token has been remapped as the metadata was emitted.|  
|[SetMethodSourceRange Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-setmethodsourcerange-method.md)|Specifies the true start and end of a method within a source file.|  
|[SetScopeRange Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-setscoperange-method.md)|Defines the offset range for the specified lexical scope.|  
|[SetSymAttribute Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-setsymattribute-method.md)|Defines a custom attribute based upon its name.|  
|[SetUserEntryPoint Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-setuserentrypoint-method.md)|Specifies the user-defined method that is the entry point for this module.|  
|[UsingNamespace Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter-usingnamespace-method.md)|Specifies that the given fully qualified namespace name is being used within the currently open lexical scope.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [Diagnostics Symbol Store Interfaces](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-interfaces.md)  
 [ISymUnmanagedWriter2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter2-interface.md)  
 [ISymUnmanagedWriter3 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedwriter3-interface.md)
