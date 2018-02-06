---
title: "FUSION_INSTALL_REFERENCE Structure"
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
  - "FUSION_INSTALL_REFERENCE"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FUSION_INSTALL_REFERENCE"
helpviewer_keywords: 
  - "FUSION_INSTALL_REFERENCE structure [.NET Framework fusion]"
ms.assetid: ae181ec8-36bf-4ed1-9a02-ca27d417c80b
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FUSION_INSTALL_REFERENCE Structure
Represents a reference that an application makes to an assembly that the application has installed in the global assembly cache.  
  
## Syntax  
  
```  
typedef struct _FUSION_INSTALL_REFERENCE_ {  
    DWORD    cbSize,  
    DWORD    dwFlags,  
    GUID     guidScheme,  
    LPCWSTR  szIdentifier,  
    LPCWSTR  szNonCanonicalData  
} FUSION_INSTALL_REFERENCE, *LPFUSION_INSTALL_REFERENCE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`cbSize`|The size of the structure in bytes.|  
|`dwFlags`|Reserved for future extensibility. This value must be 0 (zero).|  
|`guidScheme`|The entity that adds the reference. This field can have one of the following values:<br /><br /> -   FUSION_REFCOUNT_MSI_GUID: The assembly is referenced by an application that was installed using the Microsoft Windows Installer. The `szIdentifier` field is set to `MSI`, and the `szNonCanonicalData` field is set to `Windows Installer`. This scheme is used for Windows side-by-side assemblies.<br />-   FUSION_REFCOUNT_UNINSTALL_SUBKEY_GUID: The assembly is referenced by an application that appears in the **Add/Remove Programs** interface. The `szIdentifier` field provides the token that registers the application with the **Add/Remove Programs** interface.<br />-   FUSION_REFCOUNT_FILEPATH_GUID: The assembly is referenced by an application that is represented by a file in the file system. The `szIdentifier` field provides the path to this file.<br />-   FUSION_REFCOUNT_OPAQUE_STRING_GUID: The assembly is referenced by an application that is represented only by an opaque string. The `szIdentifier` field provides this opaque string. The global assembly cache does not check for the existence of opaque references when you remove this value.<br />-   FUSION_REFCOUNT_OSINSTALL_GUID: This value is reserved.|  
|`szIdentifier`|A unique string that identifies the application that installed the assembly in the global assembly cache. Its value depends upon the value of the `guidScheme` field.|  
|`szNonCanonicalData`|A string that is understood only by the entity that adds the reference. The global assembly cache stores this string, but does not use it.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Fusion Structures](../../../../docs/framework/unmanaged-api/fusion/fusion-structures.md)  
 [Global Assembly Cache](../../../../docs/framework/app-domains/gac.md)
