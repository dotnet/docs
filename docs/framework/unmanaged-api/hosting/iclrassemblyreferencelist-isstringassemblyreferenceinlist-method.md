---
description: "Learn more about: ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList Method"
title: "ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRAssemblyReferenceList.IsStringAssemblyReferenceInList"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList"
helpviewer_keywords: 
  - "ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList method [.NET Framework hosting]"
  - "IsStringAssemblyReferenceInList method [.NET Framework hosting]"
ms.assetid: e6121cc3-2f11-42c7-bdae-47808581ff71
topic_type: 
  - "apiref"
---
# ICLRAssemblyReferenceList::IsStringAssemblyReferenceInList Method

Gets a value that indicates whether the supplied name matches the name of an assembly in the list.  
  
## Syntax  
  
```cpp  
HRESULT IsStringAssemblyReferenceInList (  
    [in] LPCWSTR pwzAssemblyName  
);  
```  
  
## Parameters  

 `pwzAssemblyName`  
 [in] The name of the assembly for which to search.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The string appears in the list.|  
|S_FALSE|The string does not appear in the list.|  
|E_FAIL|An unknown catastrophic failure occurred. After a method returns E_FAIL, the common language runtime is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRAssemblyIdentityManager Interface](iclrassemblyidentitymanager-interface.md)
- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [IHostAssemblyManager Interface](ihostassemblymanager-interface.md)
- [IHostAssemblyStore Interface](ihostassemblystore-interface.md)
