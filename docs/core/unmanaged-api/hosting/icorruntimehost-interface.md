---
description: "Learn more about: ICorRuntimeHost Interface"
title: "ICorRuntimeHost Interface"
ms.date: "03/30/2017"
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
---
# ICorRuntimeHost Interface

Provides methods that enable the host to start and stop the common language runtime (CLR) explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.  
  
 In .NET Framework version 2.0, this interface is superseded by [ICLRRuntimeHost](iclrruntimehost-interface.md).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CloseEnum Method](icorruntimehost-closeenum-method.md)|Resets a domain enumerator back to the beginning of the domain list.|  
|[CreateDomain Method](icorruntimehost-createdomain-method.md)|Creates an application domain. The caller receives an interface pointer of type <xref:System._AppDomain> to an instance of type <xref:System.AppDomain?displayProperty=nameWithType>.|  
|[CreateDomainEx Method](icorruntimehost-createdomainex-method.md)|Creates an application domain. This method allows the caller to pass an IAppDomainSetup instance to configure additional features of the returned <xref:System._AppDomain> instance.|  
|[CreateDomainSetup Method](icorruntimehost-createdomainsetup-method.md)|Gets an interface pointer of type `IAppDomainSetup` to an <xref:System.AppDomainSetup> instance. `IAppDomainSetup` provides methods to configure aspects of an application domain before it is created.|  
|[CreateEvidence Method](icorruntimehost-createevidence-method.md)|Gets an interface pointer of type <xref:System.Security.Principal.IIdentity>, which allows the host to create security evidence to pass to [CreateDomain](icorruntimehost-createdomain-method.md) or [CreateDomainEx](icorruntimehost-createdomainex-method.md).|  
|[CreateLogicalThreadState Method](icorruntimehost-createlogicalthreadstate-method.md)|Do not use.|  
|[CurrentDomain Method](icorruntimehost-currentdomain-method.md)|Gets an interface pointer of type <xref:System._AppDomain> that represents the domain loaded on the current thread.|  
|[DeleteLogicalThreadState Method](icorruntimehost-deletelogicalthreadstate-method.md)|Do not use.|  
|[EnumDomains Method](icorruntimehost-enumdomains-method.md)|Gets an enumerator for the domains in the current process.|  
|[GetConfiguration Method](icorruntimehost-getconfiguration-method.md)|Gets an object that allows the host to specify the callback configuration of the CLR.|  
|[GetDefaultDomain Method](icorruntimehost-getdefaultdomain-method.md)|Gets an interface pointer of type <xref:System._AppDomain> that represents the default domain for the current process.|  
|[LocksHeldByLogicalThread Method](icorruntimehost-locksheldbylogicalthread-method.md)|Do not use.|  
|[MapFile Method](icorruntimehost-mapfile-method.md)|Maps the specified file into memory. This method is obsolete.|  
|[NextDomain Method](icorruntimehost-nextdomain-method.md)|Gets an interface pointer to the next domain in the enumeration.|  
|[Start Method](icorruntimehost-start-method.md)|Starts the CLR.|  
|[Stop Method](icorruntimehost-stop-method.md)|Stops the execution of code in the runtime for the current process.|  
|[SwitchInLogicalThreadState Method](icorruntimehost-switchinlogicalthreadstate-method.md)|Do not use.|  
|[SwitchOutLogicalThreadState Method](icorruntimehost-switchoutlogicalthreadstate-method.md)|Do not use.|  
|[UnloadDomain Method](icorruntimehost-unloaddomain-method.md)|Unloads the specified application domain from the current process.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also

- <xref:System.AppDomain>
- [Hosting](index.md)
- [ICLRRuntimeHost Interface](iclrruntimehost-interface.md)
- [Runtime Hosts](/previous-versions/dotnet/netframework-4.0/a51xd4ze(v=vs.100))
- [Hosting Interfaces](hosting-interfaces.md)
- [CorRuntimeHost Coclass](corruntimehost-coclass.md)
