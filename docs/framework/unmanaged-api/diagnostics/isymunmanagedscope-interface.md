---
title: "ISymUnmanagedScope Interface"
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
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedScope Interface
Represents a lexical scope within a method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetChildren Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getchildren-method.md)|Gets the children of this scope.|  
|[GetEndOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getendoffset-method.md)|Gets the end offset for this scope.|  
|[GetLocalCount Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getlocalcount-method.md)|Gets a count of the local variables defined within this scope.|  
|[GetLocals Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getlocals-method.md)|Gets the local variables defined within this scope.|  
|[GetMethod Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getmethod-method.md)|Gets the method that contains this scope.|  
|[GetNamespaces Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getnamespaces-method.md)|Gets the namespaces that are being used within this scope.|  
|[GetParent Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getparent-method.md)|Gets the parent scope of this scope.|  
|[GetStartOffset Method](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-getstartoffset-method.md)|Gets the start offset for this scope.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [Diagnostics Symbol Store Interfaces](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-interfaces.md)  
 [ISymUnmanagedScope2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope2-interface.md)
