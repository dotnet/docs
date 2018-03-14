---
title: "ICLRDebugging::OpenVirtualProcess Method"
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
  - "ICLRDebugging.OpenVirtualProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebugging::OpenVirtualProcess"
helpviewer_keywords: 
  - "OpenVirtualProcess method [.NET Framework debugging]"
  - "ICLRDebugging::OpenVirtualProcess method [.NET Framework debugging]"
ms.assetid: e8ab7c41-d508-4ed9-8a31-ead072b5a314
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDebugging::OpenVirtualProcess Method
Gets the ICorDebugProcess interface that corresponds to a common language runtime (CLR) module loaded in the process.  
  
## Syntax  
  
```  
HRESULT OpenVirtualProcess(  
    [in] ULONG64 moduleBaseAddress,  
    [in] IUnknown * pDataTarget,  
    [in] ICLRDebuggingLibraryProvider * pLibraryProvider,  
    [in] CLR_DEBUGGING_VERSION * pMaxDebuggerSupportedVersion,  
    [in] REFIID riidProcess,  
    [out, iid_is(riidProcess)] IUnknown ** ppProcess,  
    [in, out] CLR_DEBUGGING_VERSION * pVersion,  
    [out] CLR_DEBUGGING_PROCESS_FLAGS * pdwFlags);  
```  
  
#### Parameters  
 `moduleBaseAddress`  
 [in] The base address of a module in the target process. COR_E_NOT_CLR will be returned if the specified module is not a CLR module.  
  
 `pDataTarget`  
 [in] A data target abstraction that allows the managed debugger to inspect process state. The debugger must implement the [ICorDebugDataTarget](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md) interface. You should implement the [ICLRDebuggingLibraryProvider](../../../../docs/framework/unmanaged-api/debugging/iclrdebugginglibraryprovider-interface.md) interface to support scenarios where the CLR that is being debugged is not installed locally on the computer.  
  
 `pLibraryProvider`  
 [in] A library provider callback interface that allows version-specific debugging libraries to be located and loaded on demand. This parameter is required only if `ppProcess` or `pFlags` is not `null`.  
  
 `pMaxDebuggerSupportedVersion`  
 [in] The highest version of the CLR that this debugger can debug. You should specify the major, minor, and build versions from the latest CLR version this debugger supports, and set the revision number to 65535 to accommodate future in-place CLR servicing releases.  
  
 `riidProcess`  
 [in] The ID of the ICorDebugProcess interface to retrieve. Currently, the only accepted values are IID_CORDEBUGPROCESS3, IID_CORDEBUGPROCESS2, and IID_CORDEBUGPROCESS.  
  
 `ppProcess`  
 [out] A pointer to the COM interface that is identified by `riidProcess`.  
  
 `pVersion`  
 [in, out] The version of the CLR. On input, this value can be `null`. It can also point to a [CLR_DEBUGGING_VERSION](../../../../docs/framework/unmanaged-api/debugging/clr-debugging-version-structure.md) structure, in which case the structure's `wStructVersion` field must be initialized to 0 (zero).  
  
 On output, the returned `CLR_DEBUGGING_VERSION` structure will be filled in with the version information for the CLR.  
  
 `pdwFlags`  
 [out] Informational flags about the specified runtime. See the [CLR_DEBUGGING_PROCESS_FLAGS](../../../../docs/framework/unmanaged-api/debugging/clr-debugging-process-flags-enumeration.md) topic for a description of the flags.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pDataTarget` is `null`.|  
|CORDBG_E_LIBRARY_PROVIDER_ERROR|The [ICLRDebuggingLibraryProvider](../../../../docs/framework/unmanaged-api/debugging/iclrdebugginglibraryprovider-interface.md) callback returns an error or does not provide a valid handle.|  
|CORDBG_E_MISSING_DATA_TARGET_INTERFACE|`pDataTarget` does not implement the required data target interfaces for this version of the runtime.|  
|CORDBG_E_NOT_CLR|The indicated module is not a CLR module. This HRESULT is also returned when a CLR module cannot be detected because memory has been corrupted, the module is not available, or the CLR version is later than the shim version.|  
|CORDBG_E_UNSUPPORTED_DEBUGGING_MODEL|This runtime version does not support this debugging model. Currently, the debugging model is not supported by CLR versions before the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)]. The `pwszVersion` output parameter is still set to the correct value after this error.|  
|CORDBG_E_UNSUPPORTED_FORWARD_COMPAT|The version of the CLR is greater than the version this debugger claims to support. The `pwszVersion` output parameter is still set to the correct value after this error.|  
|E_NO_INTERFACE|The `riidProcess` interface is not available.|  
|CORDBG_E_UNSUPPORTED_VERSION_STRUCT|The `CLR_DEBUGGING_VERSION` structure does not have a recognized value for `wStructVersion`. The only accepted value at this time is 0.|  
  
## Exceptions  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
