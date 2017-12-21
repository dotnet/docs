---
title: "CorPinvokeMap Enumeration"
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
  - "CorPinvokeMap"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorPinvokeMap"
helpviewer_keywords: 
  - "CorPinvokeMap enumeration [.NET Framework metadata]"
ms.assetid: f14f986e-f6ce-42bc-aa23-18150c46d28c
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorPinvokeMap Enumeration
Specifies options for a PInvoke call.  
  
## Syntax  
  
```  
typedef enum  CorPinvokeMap {  
  
    pmNoMangle          = 0x0001,  
  
    pmCharSetMask       = 0x0006,  
    pmCharSetNotSpec    = 0x0000,  
    pmCharSetAnsi       = 0x0002,  
    pmCharSetUnicode    = 0x0004,  
    pmCharSetAuto       = 0x0006,  
  
    pmBestFitUseAssem   = 0x0000,  
    pmBestFitEnabled    = 0x0010,  
    pmBestFitDisabled   = 0x0020,  
    pmBestFitMask       = 0x0030,  
  
    pmThrowOnUnmappableCharUseAssem   = 0x0000,  
    pmThrowOnUnmappableCharEnabled    = 0x1000,  
    pmThrowOnUnmappableCharDisabled   = 0x2000,  
    pmThrowOnUnmappableCharMask       = 0x3000,  
  
    pmSupportsLastError = 0x0040,   
  
    pmCallConvMask      = 0x0700,  
    pmCallConvWinapi    = 0x0100,  
    pmCallConvCdecl     = 0x0200,  
    pmCallConvStdcall   = 0x0300,  
    pmCallConvThiscall  = 0x0400,  
    pmCallConvFastcall  = 0x0500,  
  
    pmMaxValue          = 0xFFFF  
  
} CorPinvokeMap;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pmNoMangle`|Use each member name as specified.|  
|`pmCharSetMask`|Reserved.|  
|`pmCharSetNotSpec`|Reserved.|  
|`pmCharSetAnsi`|Marshal strings as multiple-byte character strings.|  
|`pmCharSetUnicode`|Marshal strings as Unicode 2-byte characters.|  
|`pmCharSetAuto`|Automatically marshal strings appropriately for the target operating system. The default is Unicode on Windows NT, Windows 2000, Windows XP, and the Windows Server 2003 family; the default is ANSI on Windows 98 and Windows Me.|  
|`pmBestFitUseAssem`|Reserved.|  
|`pmBestFitEnabled`|Perform best-fit mapping of Unicode characters that lack an exact match in the ANSI character set.|  
|`pmBestFitDisabled`|Do not perform best-fit mapping of Unicode characters. In this case, all unmappable characters will be replaced by a ‘?’.|  
|`pmBestFitMask`|Reserved.|  
|`pmThrowOnUnmappableCharUseAssem`|Reserved.|  
|`pmThrowOnUnmappableCharEnabled`|Throw an exception when the interop marshaler encounters an unmappable character.|  
|`pmThrowOnUnmappableCharDisabled`|Do not throw an exception when the interop marshaler encounters an unmappable character.|  
|`pmThrowOnUnmappableCharMask`|Reserved|  
|`pmSupportsLastError`|Allow the callee to call the Win32 `SetLastError` function before returning from the attributed method.|  
|`pmCallConvMask`|Reserved|  
|`pmCallConvWinapi`|Use the default platform calling convention. For example, on Windows the default is `StdCall` and on Windows CE .NET it is `Cdecl`.|  
|`pmCallConvCdecl`|Use the `Cdecl` calling convention. In this case, the caller cleans the stack. This enables calling functions with `varargs` (that is, functions that accept a variable number of parameters).|  
|`pmCallConvStdcall`|Use the `StdCall` calling convention. In this case, the callee cleans the stack. This is the default convention for calling unmanaged functions with platform invoke.|  
|`pmCallConvThiscall`|Use the `ThisCall` calling convention. In this case, the first parameter is the `this` pointer and is stored in register ECX. Other parameters are pushed on the stack. The `ThisCall` calling convention is used to call methods on classes exported from an unmanaged DLL.|  
|`pmCallConvFastcall`|Reserved.|  
|`pmMaxValue`|Reserved.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
