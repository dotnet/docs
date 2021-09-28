---
description: "Learn more about: CorBindToRuntimeEx Function"
title: "CorBindToRuntimeEx Function"
ms.date: "03/30/2017"
api_name: 
  - "CorBindToRuntimeEx"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CorBindToRuntimeEx"
helpviewer_keywords: 
  - "CorBindToRuntimeEx function [.NET Framework hosting]"
ms.assetid: aae9fb17-5d01-41da-9773-1b5b5b642d81
topic_type: 
  - "apiref"
---
# CorBindToRuntimeEx Function

Enables unmanaged hosts to load the common language runtime (CLR) into a process. The [CorBindToRuntime](corbindtoruntime-function.md) and `CorBindToRuntimeEx` functions perform the same operation, but the `CorBindToRuntimeEx` function allows you to set flags to specify the behavior of the CLR.  
  
 This function has been deprecated in the .NET Framework 4.  
  
 This function takes a set of parameters that allow a host to do the following:  
  
- Specify the version of the runtime that will be loaded.  
  
- Indicate whether the server or workstation build should be loaded.  
  
- Control whether concurrent garbage collection or non-concurrent garbage collection is done.  
  
> [!NOTE]
> Concurrent garbage collection is not supported in applications running the WOW64 x86 emulator on 64-bit systems that implement the Intel Itanium architecture (formerly called IA-64). For more information about using WOW64 on 64-bit Windows systems, see [Running 32-bit Applications](/windows/desktop/WinProg64/running-32-bit-applications).  
  
- Control whether assemblies are loaded as domain-neutral.  
  
- Obtain an interface pointer to an [ICorRuntimeHost](icorruntimehost-interface.md) that can be used to set additional options for configuring an instance of the CLR before it is started.  
  
## Syntax  
  
```cpp  
HRESULT CorBindToRuntimeEx (  
    [in]  LPCWSTR      pwszVersion,
    [in]  LPCWSTR      pwszBuildFlavor,
    [in]  DWORD        startupFlags,
    [in]  REFCLSID     rclsid,
    [in]  REFIID       riid,
    [out] LPVOID FAR  *ppv  
);  
```  
  
## Parameters  

 `pwszVersion`  
 [in] A string describing the version of the CLR you want to load.  
  
 A version number in the .NET Framework consists of four parts separated by periods: *major.minor.build.revision*. The string passed as `pwszVersion` must start with the character "v" followed by the first three parts of the version number (for example, "v1.0.1529").  
  
 Some versions of the CLR are installed with a policy statement that specifies compatibility with previous versions of the CLR. By default, the startup shim evaluates `pwszVersion` against policy statements and loads the latest version of the runtime that is compatible with the version being requested. A host can force the shim to skip policy evaluation and load the exact version specified in `pwszVersion` by passing a value of  `STARTUP_LOADER_SAFEMODE` for the `startupFlags` parameter, as described below.  
  
 If the caller specifies null for `pwszVersion`, `CorBindToRuntimeEx` identifies the set of installed runtimes whose version numbers are lower than the .NET Framework 4 runtime, and loads the latest version of the runtime from that set. It won't load the .NET Framework 4 or later, and fails if no earlier version is installed. Note that passing null gives the host no control over which version of the runtime is loaded. Although this approach may be appropriate in some scenarios, it is strongly recommended that the host supply a specific version to load.  
  
 `pwszBuildFlavor`  
 [in] A string that specifies whether to load the server or the workstation build of the CLR. Valid values are `svr` and `wks`. The server build is optimized to take advantage of multiple processors for garbage collections, and the workstation build is optimized for client applications running on a single-processor machine.  
  
 If `pwszBuildFlavor` is set to null, the workstation build is loaded. When running on a single-processor machine, the workstation build is always loaded, even if `pwszBuildFlavor` is set to `svr`. However, if `pwszBuildFlavor` is set to `svr` and concurrent garbage collection is specified (see the description of the `startupFlags` parameter), the server build is loaded.  
  
 `startupFlags`  
 [in] A combination of values of the [STARTUP_FLAGS](startup-flags-enumeration.md) enumeration. These flags control concurrent garbage collection, domain-neutral code, and the behavior of the `pwszVersion` parameter. The default is single domain if no flag is set. The following values are valid:  
  
- `STARTUP_CONCURRENT_GC`  
  
- `STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN`  
  
- `STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN`  
  
- `STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN_HOST`  
  
- `STARTUP_LOADER_SAFEMODE`  
  
- `STARTUP_LEGACY_IMPERSONATION`  
  
- `STARTUP_LOADER_SETPREFERENCE`  
  
- `STARTUP_SERVER_GC`  
  
- `STARTUP_HOARD_GC_VM`  
  
- `STARTUP_SINGLE_VERSION_HOSTING_INTERFACE`  
  
- `STARTUP_LEGACY_IMPERSONATION`  
  
- `STARTUP_DISABLE_COMMITTHREADSTACK`  
  
- `STARTUP_ALWAYSFLOW_IMPERSONATION`  
  
 For descriptions of these flags, see the [STARTUP_FLAGS](startup-flags-enumeration.md) enumeration.  
  
 `rclsid`  
 [in] The `CLSID` of the coclass that implements either the [ICorRuntimeHost](icorruntimehost-interface.md) or the [ICLRRuntimeHost](iclrruntimehost-interface.md) interface. Supported values are CLSID_CorRuntimeHost or CLSID_CLRRuntimeHost.  
  
 `riid`  
 [in] The `IID` of the requested interface from `rclsid`. Supported values are IID_ICorRuntimeHost or IID_ICLRRuntimeHost.  
  
 `ppv`  
 [out] The returned interface pointer to `riid`.  
  
## Remarks  

 If `pwszVersion` specifies a runtime version that does not exist, `CorBindToRuntimeEx` returns an HRESULT value of CLR_E_SHIM_RUNTIMELOAD.  
  
## Execution Context and Flow of Windows Identity  

 In version 1 of the CLR, the <xref:System.Security.Principal.WindowsIdentity> object does not flow across asynchronous points such as new threads, thread pools, or timer callbacks. In version 2.0 of the CLR, an <xref:System.Threading.ExecutionContext> object wraps some information about the currently executing thread and flows it across any asynchronous point, but not across application domain boundaries. Similarly, the <xref:System.Security.Principal.WindowsIdentity> object also flows across any asynchronous point. Therefore, the current impersonation on the thread, if any, flows too.  
  
 You can alter the flow in two ways:  
  
1. By modifying the <xref:System.Threading.ExecutionContext> settings to suppress the flow on a per-thread basis (see the <xref:System.Threading.ExecutionContext.SuppressFlow%2A>, <xref:System.Security.SecurityContext.SuppressFlow%2A>, and <xref:System.Security.SecurityContext.SuppressFlowWindowsIdentity%2A> methods).  
  
2. By changing the process default mode to the version 1 compatibility mode, where the <xref:System.Security.Principal.WindowsIdentity> object does not flow across any asynchronous point, regardless of the <xref:System.Threading.ExecutionContext> settings on the current thread. How you change the default mode depends on whether you use a managed executable or an unmanaged hosting interface to load the CLR:  
  
    1. For managed executables, you must set the `enabled` attribute of the [\<legacyImpersonationPolicy>](../../configure-apps/file-schema/runtime/legacyimpersonationpolicy-element.md) element to `true`.  
  
    2. For unmanaged hosting interfaces, set the `STARTUP_LEGACY_IMPERSONATION` flag in the `startupFlags` parameter when calling the `CorBindToRuntimeEx` function.  
  
     The version 1 compatibility mode applies to the entire process and to all the application domains in the process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [CorBindToCurrentRuntime Function](corbindtocurrentruntime-function.md)
- [CorBindToRuntime Function](corbindtoruntime-function.md)
- [CorBindToRuntimeByCfg Function](corbindtoruntimebycfg-function.md)
- [CorBindToRuntimeHost Function](corbindtoruntimehost-function.md)
- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
