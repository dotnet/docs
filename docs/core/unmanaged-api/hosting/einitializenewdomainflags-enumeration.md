---
description: "Learn more about: EInitializeNewDomainFlags Enumeration"
title: "EInitializeNewDomainFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "EInitializeNewDomainFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EInitializeNewDomainFlags"
helpviewer_keywords: 
  - "EInitializeNewDomainFlags enumeration [.NET Framework hosting]"
ms.assetid: 3a120ab2-f5ef-4c9b-8595-d3ed7247c342
---
# EInitializeNewDomainFlags Enumeration

Enables the host to provide the runtime with information about the initialization of an application domain.  
  
## Syntax  
  
```cpp  
typedef enum {  
    eInitializeNewDomainFlags_None              = 0x0000,  
    eInitializeNewDomainFlags_NoSecurityChanges = 0x0002  
} EInitializeNewDomainFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eInitializeNewDomainFlags_None`|No flags.|  
|`eInitializeNewDomainFlags_NoSecurityChanges`|Informs the common language runtime (CLR) that the host will not make changes to the security state of the application domain in the <xref:System.AppDomainManager.InitializeNewDomain%2A> method.|  
  
## Remarks  

 The [ICLRDomainManager::SetAppDomainManagerType](iclrdomainmanager-setappdomainmanagertype-method.md) method takes a parameter of type `EInitializeNewDomainFlags`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Hosting Enumerations](hosting-enumerations.md)
- [SetAppDomainManagerType Method](iclrdomainmanager-setappdomainmanagertype-method.md)
