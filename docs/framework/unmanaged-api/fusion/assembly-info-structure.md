---
title: "ASSEMBLY_INFO Structure"
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
  - "ASSEMBLY_INFO"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ASSEMBLY_INFO"
helpviewer_keywords: 
  - "ASSEMBLY_INFO structure [.NET Framework fusion]"
ms.assetid: b3cbb47c-457f-4083-8895-49562ca99ab8
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ASSEMBLY_INFO Structure
Contains information about an assembly that is registered in the global assembly cache.  
  
## Syntax  
  
```  
typedef struct _ASSEMBLY_INFO {  
    ULONG           cbAssemblyInfo;  
    DWORD           dwAssemblyFlags;  
    ULARGE_INTEGER  uliAssemblySizeInKB;  
    LPWSTR          pszCurrentAssemblyPathBuf;  
    ULONG           cchBuf;  
} ASSEMBLY_INFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`cbAssemblyInfo`|The size, in bytes, of the structure. This field is reserved for future extensibility.|  
|`dwAssemblyFlags`|Flags that indicate installation details about the assembly. The following values are supported:<br /><br /> -   The ASSEMBLYINFO_FLAG_INSTALLED value, which indicates that the assembly is installed. The current version of the .NET Framework always sets `dwAssemblyFlags` to this value.<br />-   The ASSEMBLYINFO_FLAG_PAYLOADRESIDENT value, which indicates that the assembly is a payload resident. The current version of the .NET Framework never sets `dwAssemblyFlags` to this value.|  
|`uliAssemblySizeInKB`|The total size, in kilobytes, of the files that the assembly contains.|  
|`pszCurrentAssemblyPathBuf`|A pointer to a string buffer that holds the current path to the manifest file. The path must end with a null character.|  
|`cchBuf`|The number of wide characters, including the null terminator, that `pszCurrentAssemblyPathBuf` contains.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Fusion Structures](../../../../docs/framework/unmanaged-api/fusion/fusion-structures.md)  
 [Global Assembly Cache](../../../../docs/framework/app-domains/gac.md)
