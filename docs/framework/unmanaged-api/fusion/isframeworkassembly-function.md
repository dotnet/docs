---
title: "IsFrameworkAssembly Function"
ms.date: "03/30/2017"
api_name: 
  - "IsFrameworkAssembly"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IsFrameworkAssembly"
helpviewer_keywords: 
  - "IsFrameworkAssembly function [.NET Framework fusion]"
ms.assetid: b0c6f19b-d4fd-4971-88f0-12ffb5793da3
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IsFrameworkAssembly Function
Gets a value that indicates whether the specified assembly is managed.  
  
## Syntax  
  
```  
HRESULT IsFrameworkAssembly (  
    [in]  LPCWSTR pwzAssemblyReference,  
    [out] LPBOOL  pbIsFrameworkAssembly,  
    [in]  LPWSTR  pwzFrameworkAssemblyIdentity,  
    [in]  LPDWORD pccSize  
 );  
```  
  
## Parameters  
 `pwzAssemblyReference`  
 [in] The name of the assembly to check.  
  
 `pbIsFrameworkAssembly`  
 [out] A Boolean value that indicates whether the assembly is managed.  
  
 `pwzFrameworkAssemblyIdentity`  
 [in] An uncanonicalized string that contains the unique identity of the assembly.  
  
 `pccSize`  
 [in] The size of `pwzFrameworkAssemblyIdentity`.  
  
## Remarks  
 The `pwzAssemblyReference` parameter is a pointer to a character string that contains the name of an assembly.  
  
 If this assembly is part of the .NET Framework, the `pbIsFrameworkAssembly` parameter will contain a Boolean value of `true`.  
  
 If the named assembly is not part of the .NET Framework, or if the `pwzAssemblyReference` parameter does not name an assembly, `pbIsFrameworkAssembly` will contain a Boolean value of `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
## See also

- [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)
