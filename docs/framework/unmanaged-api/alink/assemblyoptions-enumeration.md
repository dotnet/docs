---
description: "Learn more about: AssemblyOptions Enumeration"
title: "AssemblyOptions Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "AssemblyOptions"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AssemblyOptions"
helpviewer_keywords: 
  - "Alink API, AssemblyOptions enumeration"
  - "AssemblyOptions enumeration"
ms.assetid: 84f83921-64cb-49e3-ac8b-22a0b77b18a8
topic_type: 
  - "apiref"
---
# AssemblyOptions Enumeration

Enumerates the assembly options.  
  
## Syntax  
  
```cpp  
typedef enum _AssemblyOptions {  
    optAssemTitle = 0,  
    optAssemDescription,  
    optAssemConfig,  
    optAssemOS,  
    optAssemProcessor,  
    optAssemLocale,  
    optAssemVersion,  
    optAssemCompany,  
    optAssemProduct,  
    optAssemProductVersion,  
    optAssemCopyright,  
    optAssemTrademark,  
    optAssemKeyFile,  
    optAssemKeyName,  
    optAssemAlgID,  
    optAssemFlags,  
    optAssemHalfSign,  
    optAssemFileVersion,  
    optAssemSatelliteVer,  
    optLastAssemOption  
}   AssemblyOptions;  
```  
  
## Fields  
  
|Field|Description|  
|-----------|-----------------|  
|optAssemTitle|String - Represents the assembly title.|  
|optAssemDescription|String - Contains the assembly description.|  
|optAssemConfig|String - Contains the assembly configuration.|  
|optAssemOS|String - Encoded as: "dwOSPlatformId.dwOSMajorVersion.dwOSMinorVersion".|  
|optAssemProcessor|ULONG|  
|optAssemLocale|String - Contains the assembly locale.|  
|optAssemVersion|String - Encoded as: "Major.Minor.Build.Revision".|  
|optAssemCompany|String - Contains the company.|  
|optAssemProduct|String - Contains the product name.|  
|optAssemProductVersion|String (also known as InformationalVersion).|  
|optAssemCopyright|String - Contains the copyright information.|  
|optAssemTrademark|String - Contains the trademark information.|  
|optAssemKeyFile|String (file name).|  
|optAssemKeyName|String (The key name).|  
|optAssemAlgID|ULONG|  
|optAssemFlags|ULONG|  
|optAssemHalfSign|Bool (Also known as DelaySign).|  
|optAssemFileVersion|String - Encoded as "Major.Minor.Build.Revision"--same as ProductVersion.|  
|optAssemSatelliteVer|String - Encoded as "Major.Minor.Build.Revision".|  
|optLastAssemOption|A counter of the number of elements.|  
  
## Requirements  

 **Header:** alink.h  
  
 **Library**: alink.dll  
  
## See also

- [Al.exe (Assembly Linker)](../../tools/al-exe-assembly-linker.md)
