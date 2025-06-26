---
description: "Learn more about: ICLRRuntimeHost Interface"
title: "ICLRRuntimeHost Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeHost"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeHost"
helpviewer_keywords: 
  - "ICLRRuntimeHost interface [.NET Framework hosting]"
ms.assetid: cb0c5f65-3791-47bc-b833-2f84f4101ba5
topic_type: 
  - "apiref"
---
# ICLRRuntimeHost Interface

Provides functionality similar to that of the [ICorRuntimeHost](icorruntimehost-interface.md) interface provided in the .NET Framework version 1, with the following changes:  
  
- The addition of the [SetHostControl](iclrruntimehost-sethostcontrol-method.md) method to set the host control interface.  
  
- The omission of some methods provided by `ICorRuntimeHost`.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ExecuteApplication Method](iclrruntimehost-executeapplication-method.md)|Used in manifest-based ClickOnce deployment scenarios to specify the application to be activated in a new domain.|  
|[ExecuteInAppDomain Method](iclrruntimehost-executeinappdomain-method.md)|Specifies the <xref:System.AppDomain> in which to execute the specified managed code.|  
|[ExecuteInDefaultAppDomain Method](iclrruntimehost-executeindefaultappdomain-method.md)|Invokes the specified method of the specified type in the specified assembly.|  
|[GetCLRControl Method](iclrruntimehost-getclrcontrol-method.md)|Gets an interface pointer of type [ICLRControl](iclrcontrol-interface.md) that hosts can use to customize aspects of the common language runtime (CLR).|  
|[GetCurrentAppDomainId Method](iclrruntimehost-getcurrentappdomainid-method.md)|Gets the numeric identifier of the <xref:System.AppDomain> that is currently executing.|  
|[SetHostControl Method](iclrruntimehost-sethostcontrol-method.md)|Sets the host control interface. You must call `SetHostControl` before calling `Start`.|  
|[Start Method](iclrruntimehost-start-method.md)|Initializes the CLR into a process.|  
|[Stop Method](iclrruntimehost-stop-method.md)|Stops the execution of code by the runtime.|  
|[UnloadAppDomain Method](iclrruntimehost-unloadappdomain-method.md)|Unloads the <xref:System.AppDomain> that corresponds to the specified numeric identifier.|  
  
## Remarks  

 Starting with the .NET Framework 4, use the [ICLRMetaHost](iclrmetahost-interface.md) interface to get a pointer to the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface, and then call the [ICLRRuntimeInfo::GetInterface](iclrruntimeinfo-getinterface-method.md) method to get a pointer to `ICLRRuntimeHost`. In earlier versions of the .NET Framework, the host gets a pointer to an `ICLRRuntimeHost` instance by calling [CorBindToRuntimeEx](corbindtoruntimeex-function.md) or [CorBindToCurrentRuntime](corbindtocurrentruntime-function.md). To provide implementations of any of the technologies provided in .NET Framework version 2.0, you must use `ICLRRuntimeHost` instead of `ICorRuntimeHost`.  
  
> [!IMPORTANT]
> Do not call the [Start](iclrruntimehost-start-method.md) method before calling the [ExecuteApplication](iclrruntimehost-executeapplication-method.md) method to activate a manifest-based application. If the `Start` method is called first, the `ExecuteApplication` method call will fail.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../../framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [CorBindToCurrentRuntime Function](corbindtocurrentruntime-function.md)
- [CorBindToRuntimeEx Function](corbindtoruntimeex-function.md)
- [ICLRControl Interface](iclrcontrol-interface.md)
- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [CLRRuntimeHost Coclass](clrruntimehost-coclass.md)
