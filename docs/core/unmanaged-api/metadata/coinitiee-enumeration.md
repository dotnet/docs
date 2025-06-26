---
description: "Learn more about: COINITIEE Enumeration"
title: "COINITIEE Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COINITIEE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COINITIEE"
helpviewer_keywords: 
  - "COINITIEE enumeration [.NET Framework metadata]"
ms.assetid: 64264238-3b68-4bac-a887-36b552426a6c
topic_type: 
  - "apiref"
---
# COINITIEE Enumeration

Specifies constants used by [CoInitializeEE](../hosting/coinitializeee-function.md) when initializing the common language runtime.  
  
## Syntax  
  
```cpp  
typedef enum tagCOINITEE {  
   COINITEE_DEFAULT = 0x0,  
   COINITEE_DLL     = 0x1,  
   COINITEE_MAIN    = 0x2  
} COINITIEE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COINITEE_DEFAULT`|Default initialization mode. This initializes the runtime and creates the default <xref:System.AppDomain>.|  
|`COINITEE_DLL`|Initializes to run a managed DLL.|  
|`COINITEE_MAIN`|Initializes to run a managed EXE. This initializes the runtime but does not create the default <xref:System.AppDomain>, which is created after entering the main routine of the EXE.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
