---
title: "CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "hosting interfaces [.NET Framework], version 4"
  - ".NET Framework 4, hosting interfaces"
  - "interfaces [.NET Framework hosting], version 4"
ms.assetid: f6af6116-f5b0-4bda-a276-fffdba70893d
caps.latest.revision: 26
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5
This section describes interfaces that unmanaged hosts can use to integrate the common language runtime (CLR) in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)], [!INCLUDE[net_v45](../../../../includes/net-v45-md.md)], and later versions into their applications. These interfaces provide methods for a host to configure and load the runtime into a process.  
  
 Starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)], all hosting interfaces have the following characteristics:  
  
-   They use lifetime management (`AddRef` and `Release`), encapsulation (implicit context) and `QueryInterface` from COM.  
  
-   There do not use COM types such as `BSTR`, `SAFEARRAY`, or `VARIANT`.  
  
-   There are no apartment models, aggregation, or registry activation that use the [CoCreateInstance function](http://go.microsoft.com/fwlink/?LinkId=142894).  
  
## In This Section  
 [ICLRAppDomainResourceMonitor Interface](../../../../docs/framework/unmanaged-api/hosting/iclrappdomainresourcemonitor-interface.md)  
 Provides methods that inspect an application domain's memory and CPU usage.  
  
 [ICLRDomainManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrdomainmanager-interface.md)  
 Enables the host to specify the application domain manager that will be used to initialize the default application domain, and to specify initialization properties.  
  
 [ICLRGCManager2 Interface](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager2-interface.md)  
 Provides the [SetGCStartupLimitsEx](../../../../docs/framework/unmanaged-api/hosting/iclrgcmanager2-setgcstartuplimitsex-method.md) method, which enables a host to set the size of the garbage collection segment and the maximum size of the garbage collection system's generation 0 to values greater than `DWORD`.  
  
 [ICLRMetaHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrmetahost-interface.md)  
 Provides methods that return a specific version of the CLR, list all installed CLRs, list all in-process runtimes, return the activation interface, and discover the CLR version used to compile an assembly.  
  
 [ICLRMetaHostPolicy Interface](../../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-interface.md)  
 Provides the [GetRequestedRuntime](../../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-getrequestedruntime-method.md) method that provides a CLR interface based on policy criteria, managed assembly, version, and configuration file.  
  
 [ICLRRuntimeInfo Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md)  
 Provides methods that return information about a specific runtime, including version, directory, and load status.  
  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)  
 Provides basic global static functions for signing assemblies with strong names. All the [ICLRStrongName](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md) methods return standard COM HRESULTs.  
  
 [ICLRStrongName2 Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname2-interface.md)  
 Provides the ability to create strong names using the SHA-2 group of Secure Hash Algorithms (SHA-256, SHA-384, and SHA-512).  
  
 [ICLRTask2 Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask2-interface.md)  
 Provides all the functionality of the [ICLRTask Interface](../../../../docs/framework/unmanaged-api/hosting/iclrtask-interface.md); in addition, provides methods that allow thread aborts to be delayed on the current thread.  
  
## Related Sections  
 [Deprecated CLR Hosting Interfaces and Coclasses](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-interfaces-and-coclasses.md)  
 Describes the hosting interfaces provided with the .NET Framework versions 1.0 and 1.1.  
  
 [CLR Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/clr-hosting-interfaces.md)  
 Describes the hosting interfaces provided with the .NET Framework versions 2.0, 3.0, and 3.5.  
  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)  
 Introduces hosting in the .NET Framework.
