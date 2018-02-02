---
title: "ICorRuntimeHost Interface"
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
  - "ICorRuntimeHost"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost"
helpviewer_keywords: 
  - "ICorRuntimeHost interface [.NET Framework hosting]"
ms.assetid: 4369533d-7834-4497-bc37-bfea0ad737b1
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorRuntimeHost Interface
Provides methods that enable the host to start and stop the common language runtime (CLR) explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.  
  
 In the .NET Framework version 2.0, this interface is superceded by [ICLRRuntimeHost](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CloseEnum Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-closeenum-method.md)|Resets a domain enumerator back to the beginning of the domain list.|  
|[CreateDomain Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createdomain-method.md)|Creates an application domain. The caller receives an interface pointer of type <xref:System._AppDomain> to an instance of type <xref:System.AppDomain?displayProperty=nameWithType>.|  
|[CreateDomainEx Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createdomainex-method.md)|Creates an application domain. This method allows the caller to pass an IAppDomainSetup instance to configure additional features of the returned <xref:System._AppDomain> instance.|  
|[CreateDomainSetup Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createdomainsetup-method.md)|Gets an interface pointer of type `IAppDomainSetup` to an <xref:System.AppDomainSetup> instance. `IAppDomainSetup` provides methods to configure aspects of an application domain before it is created.|  
|[CreateEvidence Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createevidence-method.md)|Gets an interface pointer of type <xref:System.Security.Principal.IIdentity>, which allows the host to create security evidence to pass to [CreateDomain](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createdomain-method.md) or [CreateDomainEx](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createdomainex-method.md).|  
|[CreateLogicalThreadState Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-createlogicalthreadstate-method.md)|Do not use.|  
|[CurrentDomain Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-currentdomain-method.md)|Gets an interface pointer of type <xref:System._AppDomain> that represents the domain loaded on the current thread.|  
|[DeleteLogicalThreadState Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-deletelogicalthreadstate-method.md)|Do not use.|  
|[EnumDomains Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-enumdomains-method.md)|Gets an enumerator for the domains in the current process.|  
|[GetConfiguration Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-getconfiguration-method.md)|Gets an object that allows the host to specify the callback configuration of the CLR.|  
|[GetDefaultDomain Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-getdefaultdomain-method.md)|Gets an interface pointer of type <xref:System._AppDomain> that represents the default domain for the current process.|  
|[LocksHeldByLogicalThread Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-locksheldbylogicalthread-method.md)|Do not use.|  
|[MapFile Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-mapfile-method.md)|Maps the specified file into memory. This method is obsolete.|  
|[NextDomain Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-nextdomain-method.md)|Gets an interface pointer to the next domain in the enumeration.|  
|[Start Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-start-method.md)|Starts the CLR.|  
|[Stop Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-stop-method.md)|Stops the execution of code in the runtime for the current process.|  
|[SwitchInLogicalThreadState Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-switchinlogicalthreadstate-method.md)|Do not use.|  
|[SwitchOutLogicalThreadState Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-switchoutlogicalthreadstate-method.md)|Do not use.|  
|[UnloadDomain Method](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-unloaddomain-method.md)|Unloads the specified application domain from the current process.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See Also  
 <xref:System.AppDomain>  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)  
 [ICLRRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md)  
 [Runtime Hosts](http://msdn.microsoft.com/library/99d9246a-b994-4fe5-985c-8588d1d59998)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [CorRuntimeHost Coclass](../../../../docs/framework/unmanaged-api/hosting/corruntimehost-coclass.md)
