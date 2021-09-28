---
description: "Learn more about: CreateDebuggingInterfaceFromVersion Function"
title: "CreateDebuggingInterfaceFromVersion Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateDebuggingInterfaceFromVersion"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateDebuggingInterfaceFromVersion"
helpviewer_keywords: 
  - "CreateDebuggingInterfaceFromVersion function [.NET Framework hosting]"
ms.assetid: a746a849-463c-44f5-a2f0-9e812ed8bcc3
topic_type: 
  - "apiref"
---
# CreateDebuggingInterfaceFromVersion Function

Creates an [ICorDebug](../debugging/icordebug-interface.md) object based on the specified version information.  
  
 This function is obsolete in the .NET Framework 4. Instead, to get an interface for the common language runtime (CLR) 2.0, use the [ICLRRuntimeInfo::GetInterface](iclrruntimeinfo-getinterface-method.md) method and specify the class identifier CLSID_CLRDebuggingLegacy and the interface identifier IID_ICorDebug. To get an interface for CLR 4 or later, call the [CLRCreateInstance](clrcreateinstance-function.md) function and specify the class identifier CLSID_CLRDebugging and the interface identifier IID_ICLRDebugging.  
  
## Syntax  
  
```cpp  
HRESULT CreateDebuggingInterfaceFromVersion (  
    [in]  int      iDebuggerVersion,
    [in]  LPCWSTR  szDebuggeeVersion,
    [out] IUnknown **ppCordb  
);  
```  
  
## Parameters  

 `iDebuggerVersion`  
 [in] The version of `ICorDebug` that is expected by the debugger. See the [CorDebugInterfaceVersion](../debugging/cordebuginterfaceversion-enumeration.md) enumeration for valid values.  
  
 `szDebuggeeVersion`  
 [in] The common language runtime version associated with the application or process to be debugged. See the [GetVersionFromProcess](getversionfromprocess-function.md) or [GetRequestedRuntimeVersion](getrequestedruntimeversion-function.md) method for information on retrieving this value.  
  
 `ppCordb`  
 [out] The location that receives a pointer to the `ICorDebug` object.  
  
## Return Value  

 This method returns standard COM error codes as defined in the WinError.h file in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_INVALIDARG|`szDebuggeeVersion` or `ppCordb` is null, or the version string is incorrect.|  
  
## Remarks  

 The `szDebuggeeVersion` parameter maps to the corresponding version of MSCorDbi.dll.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
