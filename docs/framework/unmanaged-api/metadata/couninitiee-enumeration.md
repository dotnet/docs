---
description: "Learn more about: COUNINITIEE Enumeration"
title: "COUNINITIEE Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COUNINITIEE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COUNINITIEE"
helpviewer_keywords: 
  - "COUNINITIEE enumeration [.NET Framework metadata]"
ms.assetid: c42baa79-f469-4330-95a2-baf7f021c2fc
topic_type: 
  - "apiref"
---
# COUNINITIEE Enumeration

Specifies constants used by [CoUninitializeEE](../hosting/couninitializeee-function.md) when initializing the common language runtime.  
  
## Syntax  
  
```cpp  
typedef enum tagCOUNINITEE  
{  
    COUNINITEE_DEFAULT  = 0x0,
    COUNINITEE_DLL      = 0x1  
} COUNINITIEE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COUNINITEE_DEFAULT`|Indicates default uninitialization mode.|  
|`COUNINITEE_DLL`|Indicates uninitialization mode for unloading an assembly.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
