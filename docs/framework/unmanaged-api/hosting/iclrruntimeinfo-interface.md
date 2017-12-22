---
title: "ICLRRuntimeInfo Interface"
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
caps.latest.revision: 27
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeInfo Interface
Provides methods that return information about a specific common language runtime (CLR), including version, directory, and load status. This interface also provides runtime-specific functionality without initializing the runtime. It includes the runtime-relative [LoadLibrary](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-loadlibrary-method.md) method, the runtime module-specific [GetProcAddress](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getprocaddress-method.md) method, and runtime-provided interfaces through the [GetInterface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getinterface-method.md) method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BindAsLegacyV2Runtime Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-bindaslegacyv2runtime-method.md)|Binds this runtime for all legacy CLR version 2 activation policy decisions.|  
|[GetDefaultStartupFlags Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getdefaultstartupflags-method.md)|Gets the CLR startup flags and host configuration file.|  
|[GetInterface Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getinterface-method.md)|Loads the CLR into the current process and returns runtime interface pointers, such as [ICLRRuntimeHost](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md), [ICLRStrongName](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md) and [IMetaDataDispenser](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-interface.md). This method supersedes all the `CorBindTo*` functions.|  
|[GetProcAddress Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getprocaddress-method.md)|Gets the address of a specified function that was exported from the CLR associated with this interface. This method supersedes the [GetRealProcAddress](../../../../docs/framework/unmanaged-api/hosting/getrealprocaddress-function.md) method.|  
|[GetRuntimeDirectory Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getruntimedirectory-method.md)|Gets the installation directory of the CLR associated with this interface. This method supersedes the [GetCORSystemDirectory](../../../../docs/framework/unmanaged-api/hosting/getcorsystemdirectory-function.md) method.|  
|[GetVersionString Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getversionstring-method.md)|Gets common language runtime (CLR) version information associated with a given [ICLRRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md) interface. This method supersedes the [GetRequestedRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeinfo-function.md) and [GetRequestedRuntimeVersion](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeversion-function.md) methods.|  
|[IsLoadable Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-isloadable-method.md)|Indicates whether the runtime associated with this interface can be loaded into the current process, taking into account other runtimes that might already be loaded into the process.|  
|[IsLoaded Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-isloaded-method.md)|Indicates whether the CLR associated with the [ICLRRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md) interface is loaded into a process.|  
|[IsStarted Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-isstarted-method.md)|Indicates whether the CLR that is associated with the [ICLRRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md) interface has been started.|  
|[LoadErrorString Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-loaderrorstring-method.md)|Translates an HRESULT value into an appropriate error message for the specified culture. This method supersedes the [LoadStringRC](../../../../docs/framework/unmanaged-api/hosting/loadstringrc-function.md) and [LoadStringRCEx](../../../../docs/framework/unmanaged-api/hosting/loadstringrcex-function.md) methods.|  
|[LoadLibrary Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-loadlibrary-method.md)|Loads a library from the framework directory of the CLR represented by an [ICLRRuntimeInfo](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md) interface. This method supersedes the [LoadLibraryShim](../../../../docs/framework/unmanaged-api/hosting/loadlibraryshim-function.md) method.|  
|[SetDefaultStartupFlags Method](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-setdefaultstartupflags-method.md)|Sets the CLR startup flags and host configuration file.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
