---
title: "STARTUP_FLAGS Enumeration"
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
  - "STARTUP_FLAGS"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "STARTUP_FLAGS"
helpviewer_keywords: 
  - "STARTUP_FLAGS enumeration [.NET Framework hosting]"
ms.assetid: 4f043594-0c45-4bc6-988e-a6793f0d8d06
topic_type: 
  - "apiref"
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# STARTUP_FLAGS Enumeration
Contains values that indicate the startup behavior of the common language runtime (CLR). By default, garbage collection is non-concurrent, and only the base class library is loaded into the domain-neutral area.  
  
## Syntax  
  
```  
typedef enum {  
    STARTUP_CONCURRENT_GC                         = 0x1,  
    STARTUP_LOADER_OPTIMIZATION_MASK              = 0x3<<1,  
    STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN     = 0x1<<1,  
    STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN      = 0x2<<1,  
    STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN_HOST = 0x3<<1,  
  
    STARTUP_LOADER_SAFEMODE                       = 0x10,  
    STARTUP_LOADER_SETPREFERENCE                  = 0x100,  
  
    STARTUP_SERVER_GC                             = 0x1000,  
    STARTUP_HOARD_GC_VM                           = 0x2000,  
  
    STARTUP_SINGLE_VERSION_HOSTING_INTERFACE      = 0x4000,  
    STARTUP_LEGACY_IMPERSONATION                  = 0x10000,  
    STARTUP_DISABLE_COMMITTHREADSTACK             = 0x20000,  
    STARTUP_ALWAYSFLOW_IMPERSONATION              = 0x40000,  
    STARTUP_TRIM_GC_COMMIT                        = 0x80000,  
  
    STARTUP_ETW                                   = 0x100000,  
    STARTUP_ARM                                   = 0x400000  
} STARTUP_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`STARTUP_CONCURRENT_GC`|Specifies that concurrent garbage collection should be used. If the caller asks for the server build and concurrent garbage collection on a single-processor machine, the workstation build and non-concurrent garbage collection are run instead. **Note:**  Concurrent garbage collection is not supported in applications that are running the WOW64 x86 emulator on 64-bit systems that implement the Intel Itanium architecture (formerly called IA-64). For more information about using WOW64 on 64-bit Windows systems, see [Running 32-bit Applications](http://msdn.microsoft.com/library/windows/desktop/aa384249.aspx).|  
|`STARTUP_LOADER_OPTIMIZATION_MASK`|Specifies that loader optimization shall occur.|  
|`STARTUP_LOADER_OPTIMIZATION_SINGLE_DOMAIN`|Specifies that no assemblies are loaded as domain-neutral.|  
|`STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN`|Specifies that all assemblies are loaded as domain-neutral.|  
|`STARTUP_LOADER_OPTIMIZATION_MULTI_DOMAIN_HOST`|Specifies that all strong-named assemblies are loaded as domain-neutral.|  
|`STARTUP_LOADER_SAFEMODE`|Specifies that CLR version policy will not be applied to the version passed in. The exact version specified of the CLR will be loaded. The shim does not evaluate policy to determine the latest compatible version.|  
|`STARTUP_LOADER_SETPREFERENCE`|Specifies that the preferred runtime will be set, but not actually started.|  
|`STARTUP_SERVER_GC`|Specifies that the server garbage collection will be used.|  
|`STARTUP_HOARD_GC_VM`|Specifies that garbage collection will keep the virtual address used.|  
|`STARTUP_SINGLE_VERSION_HOSTING_INTERFACE`|Specifies that mixing a hosting interface will not be allowed.|  
|`STARTUP_LEGACY_IMPERSONATION`|Specifies that impersonation should not flow across asynchronous points by default.|  
|`STARTUP_DISABLE_COMMITTHREADSTACK`|Specifies that the full thread stack should not be committed when the thread starts running.|  
|`STARTUP_ALWAYSFLOW_IMPERSONATION`|Specifies that managed impersonations and impersonations achieved through platform invoke will flow across asynchronous points. By default, only managed impersonations will flow across asynchronous points.|  
|`STARTUP_TRIM_GC_COMMIT`|Specifies that garbage collection will use less committed space when system memory is low. See `gcTrimCommitOnLowMemory` in [Optimization for Shared Web Hosting](../../../../docs/standard/garbage-collection/optimization-for-shared-web-hosting.md).|  
|`STARTUP_ETW`|Specifies that event tracing for Windows (ETW) is enabled for common language runtime events. Beginning with Windows Vista, event tracing is always enabled, so this flag has no effect. See [Controlling .NET Framework Logging](../../../../docs/framework/performance/controlling-logging.md).|  
|`STARTUP_ARM`|Specifies that application domain resource monitoring is enabled. See the <xref:System.AppDomain.MonitoringIsEnabled%2A?displayProperty=nameWithType> property and [\<appDomainResourceMonitoring> Element](../../../../docs/framework/configure-apps/file-schema/runtime/appdomainresourcemonitoring-element.md).|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
