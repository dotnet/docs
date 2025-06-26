---
description: "Learn more about: ICLRDomainManager Interface"
title: "ICLRDomainManager Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDomainManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDomainManager"
helpviewer_keywords: 
  - "ICLRDomainManager interface [.NET Framework hosting]"
ms.assetid: f08b2390-d872-4521-a815-e9c237c4c45d
---
# ICLRDomainManager Interface

Enables the host to specify the application domain manager that will be used to initialize the default application domain, and to specify initialization properties.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetAppDomainManagerType Method](iclrdomainmanager-setappdomainmanagertype-method.md)|Specifies the type, derived from the <xref:System.AppDomainManager?displayProperty=nameWithType> class, of the application domain manager that will be used to initialize the default application domain.|  
|[SetPropertiesForDefaultAppDomain Method](iclrdomainmanager-setpropertiesfordefaultappdomain-method.md)|Sets properties that will be used to initialize the default application domain.|  
  
## Remarks  

 To get an instance of this interface, call the [ICLRControl::GetCLRManager](iclrcontrol-getclrmanager-method.md) method with the manager type IID `IID_ICLRDomainManager`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
