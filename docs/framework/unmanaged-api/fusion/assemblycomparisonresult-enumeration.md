---
title: "AssemblyComparisonResult Enumeration"
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
  - "AssemblyComparisonResult"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AssemblyComparisonResult"
helpviewer_keywords: 
  - "AssemblyComparisonResult enumeration [.NET Framework fusion]"
ms.assetid: bd042f89-10b1-40ca-946e-46da082f5263
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# AssemblyComparisonResult Enumeration
Indicates the equivalence of two assembly identities, as determined by the [CompareAssemblyIdentity](../../../../docs/framework/unmanaged-api/fusion/compareassemblyidentity-function.md) function.  
  
## Syntax  
  
```  
typedef enum _tagAssemblyComparisonResult {  
    ACR_Unknown,   
    ACR_EquivalentFullMatch,  
    ACR_EquivalentWeakNamed,  
    ACR_EquivalentFXUnified,  
    ACR_EquivalentUnified,    
    ACR_NonEquivalentVersion,  
    ACR_NonEquivalent,      
    ACR_EquivalentPartialMatch,  
    ACR_EquivalentPartialWeakNamed,    
    ACR_EquivalentPartialUnified,  
    ACR_EquivalentPartialFXUnified,  
    ACR_NonEquivalentPartialVersion    
} AssemblyComparisonResult;  
```  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`ACR_EquivalentFullMatch`|Indicates that all assembly fields in the comparison match.|  
|`ACR_EquivalentFXUnified`|Indicates that assemblies are considered equivalent based on the common language runtime version (CLR) unification of assembly version numbers in the .NET Framework version 2.0.|  
|`ACR_EquivalentPartialFXUnified`|Indicates a partial match of the assemblies based on the CLR unification of assembly version numbers in the .NET Framework 2.0.|  
|`ACR_EquivalentPartialMatch`|Indicates a partial match of the assemblies.|  
|`ACR_EquivalentPartialUnified`|Indicates a partial match of the assemblies based on legacy unification of version numbers.|  
|`ACR_EquivalentPartialWeakNamed`|Indicates a partial match of simply named assemblies.|  
|`ACR_EquivalentUnified`|Indicates that assemblies are considered equivalent based on the CLR unification of version numbers in legacy versions of the .NET Framework.|  
|`ACR_EquivalentWeakNamed`|Indicates a match between two simply named assemblies whose version numbers were ignored.|  
|`ACR_NonEquivalent`|Indicates that no match occurred between the two assemblies.|  
|`ACR_NonEquivalentPartialVersion`|Indicates that the two assemblies match except for their version numbers, which match only partially.|  
|`ACR_NonEquivalentVersion`|Indicates that the two assemblies match except for their version numbers, which do not match.|  
|`ACR_Unknown`|Indicates that the reason for non-equivalency is not known.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [CompareAssemblyIdentity Function](../../../../docs/framework/unmanaged-api/fusion/compareassemblyidentity-function.md)  
 [Fusion Enumerations](../../../../docs/framework/unmanaged-api/fusion/fusion-enumerations.md)
