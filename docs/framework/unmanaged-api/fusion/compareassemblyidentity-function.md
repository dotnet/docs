---
title: "CompareAssemblyIdentity Function"
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
  - "CompareAssemblyIdentity"
api_location: 
  - "fusion.dll"
  - "clr.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CompareAssemblyIdentity"
helpviewer_keywords: 
  - "CompareAssemblyIdentity function [.NET Framework fusion]"
ms.assetid: 8b364ae1-8efa-4744-a7da-81fd093d84d6
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CompareAssemblyIdentity Function
Compares two assembly identities to determine whether they are equivalent.  
  
## Syntax  
  
```  
STDAPI CompareAssemblyIdentity (  
    [in]  LPCWSTR                  pwzAssemblyIdentity1,  
    [in]  BOOL                     fUnified1,  
    [in]  LPCWSTR                  pwzAssemblyIdentity2,  
    [in]  BOOL                     fUnified2,  
    [out] BOOL                     *pfEquivalent,  
    [out] AssemblyComparisonResult *pResult  
 );  
```  
  
#### Parameters  
 `pwzAssemblyIdentity1`  
 [in] The textual identity of the first assembly in the comparison.  
  
 `fUnified1`  
 [in] A Boolean flag that indicates user-specified unification for `pwzAssemblyIdentity1`.  
  
 `pwzAssemblyIdentity2`  
 [in] The textual identity of the second assembly in the comparison.  
  
 `fUnified2`  
 [in] A Boolean flag that indicates user-specified unification for `pwzAssemblyIdentity2`.  
  
 `pfEquivalent`  
 [out] A Boolean flag that indicates whether the two assemblies are equivalent.  
  
 `pResult`  
 [out] An [AssemblyComparisonResult](../../../../docs/framework/unmanaged-api/fusion/assemblycomparisonresult-enumeration.md) enumeration that contains detailed information about the comparison.  
  
## Return Value  
 `pfEquivalent` returns a Boolean value that indicates whether the two assemblies are equivalent. `pResult` returns one of the `AssemblyComparisonResult` values, to give a more detailed reason for the value of `pfEquivalent`.  
  
## Remarks  
 `CompareAssemblyIdentity` checks whether `pwzAssemblyIdentity1` and `pwzAssemblyIdentity2` are equivalent. `pfEquivalent` is set to `true` under one or more of the following conditions:  
  
-   The two assembly identities are equivalent. For strongly named assemblies, equivalency requires the assembly name, version, public key token, and culture to be identical. For simply named assemblies, equivalency requires a match on the assembly name and culture.  
  
-   Both assembly identities refer to assemblies that run on the .NET Framework. This condition returns `true` even if the assembly version numbers do not match.  
  
-   The two assemblies are not managed assemblies, but `fUnified1` or `fUnified2` was set to `true`.  
  
 The `fUnified` flag indicates that all version numbers up to the version number of the strongly named assembly are considered equivalent to the strongly named assembly. For example, if the value of `pwzAssemblyIndentity1` is "MyAssembly, version=3.0.0.0, culture=neutral, publicKeyToken=....", and the value of `fUnified1` is `true`, this indicates that all versions of MyAssembly from version 0.0.0.0 to 3.0.0.0 should be treated as equivalent. In such a case, if `pwzAssemblyIndentity2` refers to the same assembly as `pwzAssemblyIndentity1`, except that it has a lower version number, `pfEquivalent` is set to `true`. If `pwzAssemblyIdentity2` refers to a higher version number, `pfEquivalent` is set to `true` only if the value of `fUnified2` is `true`.  
  
 The `pResult` parameter includes specific information about why the two assemblies are considered equivalent or not equivalent. For more information, see [AssemblyComparisonResult Enumeration](../../../../docs/framework/unmanaged-api/fusion/assemblycomparisonresult-enumeration.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)  
 [AssemblyComparisonResult Enumeration](../../../../docs/framework/unmanaged-api/fusion/assemblycomparisonresult-enumeration.md)
