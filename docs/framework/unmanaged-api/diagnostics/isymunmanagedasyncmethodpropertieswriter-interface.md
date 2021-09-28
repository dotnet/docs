---
description: "Learn more about: ISymUnmanagedAsyncMethodPropertiesWriter Interface"
title: "ISymUnmanagedAsyncMethodPropertiesWriter Interface"
ms.date: "03/30/2017"
ms.assetid: caa71820-8058-4b6a-93a2-25ee757d92d3
---
# ISymUnmanagedAsyncMethodPropertiesWriter Interface

Allows you to define optional async method information for each method symbol. Always use with an opened method; that is, between calls to the [OpenMethod Method](isymunmanagedwriter-openmethod-method.md) and the [CloseMethod Method](isymunmanagedwriter-closemethod-method.md).  
  
## Syntax  
  
```idl  
[object,uuid(FC073774-1739-4232-BD56-A027294BEC15),pointer_default(unique)]interface ISymUnmanagedAsyncMethodPropertiesWriter : IUnknown  
```  
  
## Methods  

 This interface contains the following methods:  
  
|Method|Description|  
|------------|-----------------|  
|[DefineAsyncStepInfo Method](isymunmanagedasyncmethodpropertieswriter-defineasyncstepinfo-method.md)|Define a group of async await operations in the current method.<br /><br /> Each yield offset matches an await's return instruction, identifying a potential yield. Each `breakpointMethod`/`breakpointOffset` pair identifies where the asynchronous operation will resume; it may be in a different method.|  
|[DefineCatchHandlerILOffset Method](isymunmanagedasyncmethodpropertieswriter-definecatchhandleriloffset-method.md)|Sets the IL offset for the compiler-generated catch handler that wraps an async method.<br /><br /> The IL offset of the generated catch is used by the debugger to handle the catch as if it were non-user code, even though it may occur in a user code method. In particular, it is used in response to a **CatchHandlerFound** exception event.|  
|[DefineKickoffMethod Method](isymunmanagedasyncmethodpropertieswriter-definekickoffmethod-method.md)|Sets the starting method that initiates the async operation.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
