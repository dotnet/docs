---
title: "CorDebugPlatform Enumeration"
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
  - "CorDebugPlatformEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugPlatformEnum"
helpviewer_keywords: 
  - "CorDebugPlatformEnum enumeration [.NET Framework debugging]"
ms.assetid: c5444816-7378-4521-afd3-bf5e4b5303d5
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugPlatform Enumeration
Provides target platform values that are used by the [ICorDebugDataTarget::GetPlatform](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-getplatform-method.md) method.  
  
## Syntax  
  
```  
typedef enum CorDebugPlatform  
{  
    CORDB_PLATFORM_WINDOWS_X86,    // Windows on Intel x86  
    CORDB_PLATFORM_WINDOWS_AMD64,  // Windows x64 (AMD64, Intel EM64T)  
    CORDB_PLATFORM_WINDOWS_IA64,   // Windows on Intel IA-64  
    CORDB_PLATFORM_MAC_PPC,        // Macintosh OS on PowerPC  
    CORDB_PLATFORM_MAC_X86,        // Macintosh OS on Intel x86  
    CORDB_PLATFORM_WINDOWS_ARM,    // Windows on ARM  
    CORDB_PLATFORM_MAC_AMD64       // MacOS on Intel x64  
} CorDebugPlatform;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|CORDB_PLATFORM_WINDOWS_X86|The target platform is Windows running on Intel x86 hardware.|  
|CORDB_PLATFORM_WINDOWS_AMD64|The target platform is 64 bit Windows running on AMD64 or Intel EM64T hardware.|  
|CORDB_PLATFORM_WINDOWS_IA64|The target platform is 32 bit Windows running on Intel IA-64 hardware.|  
|CORDB_PLATFORM_MAC_PPC|The target platform is the Macintosh operating system running on PowerPC hardware.|  
|CORDB_PLATFORM_MAC_X86|The target platform is the Macintosh operating system running on Intel x86 hardware.|  
|CORDB_PLATFORM_WINDOWS_ARM|The target platform is the Macintosh operating system running on Windows ARM hardware.|  
|CORDB_PLATFORM_MAC_AMD64|The target platform is the Macintosh operating system running on AMD64 hardware.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
 The `CORDB_PLATFORM_WINDOWS_ARM` and `CORDB_PLATFORM_MAC_AMD64` members are available in the .NET Framework 4.5.2 and later versions.  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
