---
title: "CorBindToRuntime Function"
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
  - "CorBindToRuntime"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CorBindToRuntime"
helpviewer_keywords: 
  - "CorBindToRuntime function [.NET Framework hosting]"
ms.assetid: 799740aa-46ec-4532-95da-6444565b4971
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorBindToRuntime Function
Enables unmanaged hosts to load the common language runtime (CLR) into a process.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT CorBindToRuntime (  
    [in]  LPCWSTR     pwszVersion,   
    [in]  LPCWSTR     pwszBuildFlavor,   
    [in]  REFCLSID    rclsid,   
    [in]  REFIID      riid,   
    [out] LPVOID FAR  *ppv  
);  
```  
  
#### Parameters  
 `pwszVersion`  
 [in] A string describing the version of the CLR you want to load.  
  
 A version number in the .NET Framework consists of four parts separated by periods: *major.minor.build.revision*. The string passed as `pwszVersion` must start with the character "v" followed by the first three parts of the version number (for example, "v1.0.1529").  
  
 Some versions of the CLR are installed with a policy statement that specifies compatibility with previous versions of the CLR. By default, the startup shim evaluates `pwszVersion` against policy statements and loads the latest version of the runtime that is compatible with the version being requested. A host can force the shim to skip policy evaluation and load the exact version specified in `pwszVersion` by passing a value of  `STARTUP_LOADER_SAFEMODE` for the `flags` parameter, as described below.  
  
 If the caller specifies null for `pwszVersion`, the latest version of the runtime is loaded. Passing null gives the host no control over which version of the runtime is loaded. Although this approach may be appropriate in some scenarios, it is strongly recommended that the host supply a specific version to load.  
  
 `pwszBuildFlavor`  
 [in] A string that specifies whether to load the server or the workstation build of the CLR. Valid values are `svr` and `wks`. The server build is optimized to take advantage of multiple processors for garbage collections, and the workstation build is optimized for client applications running on a single-processor machine.  
  
 If `pwszBuildFlavor` is set to null, the workstation build is loaded. When running on a single-processor machine, the workstation build is always loaded, even if `pwszBuildFlavor` is set to `svr`. However, if `pwszBuildFlavor` is set to `svr` and concurrent garbage collection is specified (see the description of the `flags` parameter), the server build is loaded.  
  
 `rclsid`  
 [in] The `CLSID` of the coclass that implements either the [ICorRuntimeHost](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md) or the [ICLRRuntimeHost](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md) interface. Supported values are CLSID_CorRuntimeHost or CLSID_CLRRuntimeHost.  
  
 `riid`  
 [in] The `IID` of the requested interface from `rclsid`. Supported values are IID_ICorRuntimeHost or IID_ICLRRuntimeHost.  
  
 `ppv`  
 [out] The returned interface pointer to `riid`.  
  
## Remarks  
 If `pwszVersion` specifies a runtime version that does not exist, `CorBindToRuntimeEx` returns an HRESULT value of CLR_E_SHIM_RUNTIMELOAD.  
  
## Execution Context and Flow of Windows Identity  
 In version 1 of the CLR, the <xref:System.Security.Principal.WindowsIdentity> object does not flow across asynchronous points such as new threads, thread pools, or timer callbacks. In version 2.0 of the CLR, an <xref:System.Threading.ExecutionContext> object wraps some information about the currently executing thread and flows it across any asynchronous point, but not across application domain boundaries. Similarly, the <xref:System.Security.Principal.WindowsIdentity> object also flows across any asynchronous point. Therefore, the current impersonation on the thread, if any, flows too.  
  
 You can alter the flow in two ways:  
  
1.  By modifying the <xref:System.Threading.ExecutionContext> settings to suppress the flow on a per-thread basis (see the <xref:System.Threading.ExecutionContext.SuppressFlow%2A>, <xref:System.Security.SecurityContext.SuppressFlow%2A>, and <xref:System.Security.SecurityContext.SuppressFlowWindowsIdentity%2A> methods).  
  
2.  By changing the process default mode to the version 1 compatibility mode, where the <xref:System.Security.Principal.WindowsIdentity> object does not flow across any asynchronous point, regardless of the <xref:System.Threading.ExecutionContext> settings on the current thread. How you change the default mode depends on whether you use a managed executable or an unmanaged hosting interface to load the CLR:  
  
    1.  For managed executables, you must set the `enabled` attribute of the [\<legacyImpersonationPolicy>](../../../../docs/framework/configure-apps/file-schema/runtime/legacyimpersonationpolicy-element.md) element to `true`.  
  
    2.  For unmanaged hosting interfaces, set the `STARTUP_LEGACY_IMPERSONATION` flag in the `flags` parameter when calling the `CorBindToRuntimeEx` function.  
  
     The version 1 compatibility mode applies to the entire process and to all the application domains in the process.  
  
## Remarks  
 [CorBindToRuntimeEx](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimeex-function.md) and `CorBindToRuntime` perform the same operation, but the `CorBindToRuntimeEx` function allows you to set flags to specify the behavior of the CLR.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [CorBindToCurrentRuntime Function](../../../../docs/framework/unmanaged-api/hosting/corbindtocurrentruntime-function.md)  
 [CorBindToRuntimeByCfg Function](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimebycfg-function.md)  
 [CorBindToRuntimeEx Function](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimeex-function.md)  
 [CorBindToRuntimeHost Function](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimehost-function.md)  
 [ICorRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
