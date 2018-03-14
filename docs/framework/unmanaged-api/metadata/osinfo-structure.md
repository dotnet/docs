---
title: "OSINFO Structure"
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
  - "OSINFO"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "OSINFO"
helpviewer_keywords: 
  - "OSINFO structure [.NET Framework metadata]"
ms.assetid: fac7b480-7adb-4450-a5e9-690fed81ffae
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# OSINFO Structure
Contains details about the operating system for an assembly or module.  
  
## Syntax  
  
```  
typedef struct {  
    DWORD   dwOSPlatformId;  
    DWORD   dwOSMajorVersion;   
    DWORD   dwOSMinorVersion;   
} OSINFO;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`dwOSPlatformId`|One of the identifier values defined by the Microsoft Windows platform function `GetVersionEx`. The following values are supported:<br /><br /> -   VER_PLATFORM_WIN32s, or 0x0000, to specify Microsoft Windows 3.1.<br />-   VER_PLATFORM_WIN32_WINDOWS, or 0x0001, to specify Windows 95, Windows 98, or operating systems descended from them.<br />-   VER_PLATFORM_WIN32_NT, or 0x0010, to specify Windows NT or operating systems descended from it.|  
|`dwOSMajorVersion`|The operating system major version, or a NULL value to indicate any version.|  
|`dwOSMinorVersion`|The operating system minor version, or a NULL value to indicate any version.|  
  
## Remarks  
 `OSINFO` is based on the `OSVERSIONINFOEX` structure that is used in calls to the Microsoft Windows platform function `GetVersionEx`. This structure is used by the ASSEMBLYMETADATA structure to indicate its operating system support.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Structures](../../../../docs/framework/unmanaged-api/metadata/metadata-structures.md)  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)
