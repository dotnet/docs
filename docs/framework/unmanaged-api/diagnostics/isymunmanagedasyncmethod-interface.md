---
description: "Learn more about: ISymUnmanagedAsyncMethod Interface"
title: "ISymUnmanagedAsyncMethod Interface"
ms.date: "03/30/2017"
ms.assetid: f2de5224-fd91-45de-9e58-bc600c6d22f1
---
# ISymUnmanagedAsyncMethod Interface

This interface is the reading complement to [ISymUnmanagedAsyncMethodPropertiesWriter Interface](isymunmanagedasyncmethodpropertieswriter-interface.md).  
  
## Syntax  
  
```idl  
[object,uuid(B20D55B3-532E-4906-87E7-25BD5734ABD2),pointer_default(unique)]interface ISymUnmanagedAsyncMethod : IUnknown  
```  
  
## Methods  

 This interface contains the following methods:  
  
|Method|Description|  
|------------|-----------------|  
|[GetAsyncStepInfo Method](isymunmanagedasyncmethod-getasyncstepinfo-method.md)|See [DefineAsyncStepInfo Method](isymunmanagedasyncmethodpropertieswriter-defineasyncstepinfo-method.md).|  
|[GetAsyncStepInfoCount Method](isymunmanagedasyncmethod-getasyncstepinfocount-method.md)|See [DefineAsyncStepInfo Method](isymunmanagedasyncmethodpropertieswriter-defineasyncstepinfo-method.md).|  
|[GetCatchHandlerILOffset Method](isymunmanagedasyncmethod-getcatchhandleriloffset-method.md)|See [DefineCatchHandlerILOffset Method](isymunmanagedasyncmethodpropertieswriter-definecatchhandleriloffset-method.md).|  
|[GetKickoffMethod Method](isymunmanagedasyncmethod-getkickoffmethod-method.md)|See [DefineKickoffMethod Method](isymunmanagedasyncmethodpropertieswriter-definekickoffmethod-method.md).|  
|[HasCatchHandlerILOffset Method](isymunmanagedasyncmethod-hascatchhandleriloffset-method.md)|See [DefineCatchHandlerILOffset Method](isymunmanagedasyncmethodpropertieswriter-definecatchhandleriloffset-method.md).|  
|[IsAsyncMethod Method](isymunmanagedasyncmethod-isasyncmethod-method.md)|Checks if the method has async information or not.<br /><br /> If this method returns `FALSE` then it is invalid to call any other methods in this interface. They will all return `E_UNEXPECTED` in this case.|  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Interfaces](diagnostics-symbol-store-interfaces.md)
