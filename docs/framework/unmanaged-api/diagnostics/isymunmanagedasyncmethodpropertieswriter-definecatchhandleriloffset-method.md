---
title: "ISymUnmanagedAsyncMethodPropertiesWriter::DefineCatchHandlerILOffset Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 92af7896-2201-408d-8b1b-23e28001eeac
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedAsyncMethodPropertiesWriter::DefineCatchHandlerILOffset Method
Sets the IL offset for the compiler-generated catch handler that wraps an async method.  
  
 The IL offset of the generated catch is used by the debugger to handle the catch as if it were non-user code even though it might occur in a user code method. In particular, it is used in response to a **CatchHandlerFound** exception event.  
  
## Syntax  
  
```idl  
HRESULT DefineCatchHandlerILOffset(    [in] ULONG32 catchHandlerOffset);  
```  
  
#### Parameters  
  
|Parameter|Description|  
|---------------|-----------------|  
|`catchHandlerOffset`||  
  
## Return Value  
 Returns `HRESULT`.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedAsyncMethodPropertiesWriter Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedasyncmethodpropertieswriter-interface.md)
