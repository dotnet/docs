---
description: "Learn more about: ICLRMetaHostPolicy Interface"
title: "ICLRMetaHostPolicy Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMetaHostPolicy"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHostPolicy"
helpviewer_keywords: 
  - "ICLRMetaHostPolicy interface [.NET Framework hosting]"
ms.assetid: 1bdeccb6-0698-4c97-ad69-eae2b69e59f1
topic_type: 
  - "apiref"
---
# ICLRMetaHostPolicy Interface

Provides the [GetRequestedRuntime](iclrmetahostpolicy-getrequestedruntime-method.md) method, which returns a pointer to a common language runtime (CLR) interface based on a policy criteria, managed assembly, version and configuration file.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetRequestedRuntime Method](iclrmetahostpolicy-getrequestedruntime-method.md)|Provides a preferred CLR interface based on a policy criteria, managed assembly, version, and configuration file.|  
  
## Remarks  

 You can get a reference to this interface by calling the [CLRCreateInstance](clrcreateinstance-function.md) function as shown in the following code:  
  
```cpp  
ICLRMetaHostPolicy *pMetaHostPolicy = NULL;  
HRESULT hr = CLRCreateInstance(CLSID_CLRMetaHostPolicy,  
                   IID_ICLRMetaHostPolicy, (LPVOID*)&pMetaHostPolicy);  
```  
  
> [!NOTE]
> This interface does not actually load or activate the CLR, but simply returns the preferred CLR version based on the available versions that are installed or loaded.  
  
 The .NET Framework 4 hosting API consolidates policies so that hosts with specific needs may use basic functionality without incurring unintended penalties. For example, many of the MSCorEE.dll exports will bind to a specific CLR, although a method might not logically require it. The [METAHOST_POLICY_FLAGS](metahost-policy-flags-enumeration.md) enumeration provides binding policies that are common to the majority of hosts.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5](clr-hosting-interfaces-added-in-the-net-framework-4-and-4-5.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
