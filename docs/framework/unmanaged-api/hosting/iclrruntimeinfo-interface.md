---
description: "Learn more about: ICLRRuntimeInfo Interface"
title: "ICLRRuntimeInfo Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo"
helpviewer_keywords: 
  - "ICLRRuntimeInfo interface [.NET Framework hosting]"
ms.assetid: 287e5ede-b3a7-4ef8-a756-4fca3f285a82
topic_type: 
  - "apiref"
---
# ICLRRuntimeInfo Interface

Provides methods that return information about a specific common language runtime (CLR), including version, directory, and load status. This interface also provides runtime-specific functionality without initializing the runtime. It includes the runtime-relative [LoadLibrary](iclrruntimeinfo-loadlibrary-method.md) method, the runtime module-specific [GetProcAddress](iclrruntimeinfo-getprocaddress-method.md) method, and runtime-provided interfaces through the [GetInterface](iclrruntimeinfo-getinterface-method.md) method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BindAsLegacyV2Runtime Method](iclrruntimeinfo-bindaslegacyv2runtime-method.md)|Binds this runtime for all legacy CLR version 2 activation policy decisions.|  
|[GetDefaultStartupFlags Method](iclrruntimeinfo-getdefaultstartupflags-method.md)|Gets the CLR startup flags and host configuration file.|  
|[GetInterface Method](iclrruntimeinfo-getinterface-method.md)|Loads the CLR into the current process and returns runtime interface pointers, such as [ICLRRuntimeHost](iclrruntimehost-interface.md), [ICLRStrongName](iclrstrongname-interface.md) and [IMetaDataDispenser](../metadata/imetadatadispenser-interface.md). This method supersedes all the `CorBindTo*` functions.|  
|[GetProcAddress Method](iclrruntimeinfo-getprocaddress-method.md)|Gets the address of a specified function that was exported from the CLR associated with this interface. This method supersedes the [GetRealProcAddress](getrealprocaddress-function.md) method.|  
|[GetRuntimeDirectory Method](iclrruntimeinfo-getruntimedirectory-method.md)|Gets the installation directory of the CLR associated with this interface. This method supersedes the [GetCORSystemDirectory](getcorsystemdirectory-function.md) method.|  
|[GetVersionString Method](iclrruntimeinfo-getversionstring-method.md)|Gets common language runtime (CLR) version information associated with a given [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface. This method supersedes the [GetRequestedRuntimeInfo](getrequestedruntimeinfo-function.md) and [GetRequestedRuntimeVersion](getrequestedruntimeversion-function.md) methods.|  
|[IsLoadable Method](iclrruntimeinfo-isloadable-method.md)|Indicates whether the runtime associated with this interface can be loaded into the current process, taking into account other runtimes that might already be loaded into the process.|  
|[IsLoaded Method](iclrruntimeinfo-isloaded-method.md)|Indicates whether the CLR associated with the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface is loaded into a process.|  
|[IsStarted Method](iclrruntimeinfo-isstarted-method.md)|Indicates whether the CLR that is associated with the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface has been started.|  
|[LoadErrorString Method](iclrruntimeinfo-loaderrorstring-method.md)|Translates an HRESULT value into an appropriate error message for the specified culture. This method supersedes the [LoadStringRC](loadstringrc-function.md) and [LoadStringRCEx](loadstringrcex-function.md) methods.|  
|[LoadLibrary Method](iclrruntimeinfo-loadlibrary-method.md)|Loads a library from the framework directory of the CLR represented by an [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface. This method supersedes the [LoadLibraryShim](loadlibraryshim-function.md) method.|  
|[SetDefaultStartupFlags Method](iclrruntimeinfo-setdefaultstartupflags-method.md)|Sets the CLR startup flags and host configuration file.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
