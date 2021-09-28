---
description: "Learn more about: ECustomDumpFlavor Enumeration"
title: "ECustomDumpFlavor Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "ECustomDumpFlavor"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ECustomDumpFlavor"
helpviewer_keywords: 
  - "ECustomDumpFlavor enumeration [.NET Framework hosting]"
ms.assetid: b39b3320-fac7-41f1-9a03-ab6fb0cd89c7
topic_type: 
  - "apiref"
---
# ECustomDumpFlavor Enumeration

Contains values that indicate which items to include in a custom subset of a heap dump when reporting errors.  
  
## Syntax  
  
```cpp  
typedef enum {  
    DUMP_FLAVOR_Mini            = 1,  
    DUMP_FLAVOR_NonHeapCLRState = 2  
} ECustomDumpFlavor;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`DUMP_FLAVOR_Mini`|Specifies that the custom heap dump should start as a minidump and include extra data specified by any [CustomDumpItem](customdumpitem-structure.md) instances passed to the same method.|  
|`DUMP_FLAVOR_NonHeapCLRState`|Specifies that the custom heap dump should gather all run-time state data that was not dynamically allocated.|  
  
## Remarks  

 A parameter of type `ECustomDumpFlavor` is passed to the [ICLRErrorReportingManager::BeginCustomDump](iclrerrorreportingmanager-begincustomdump-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ECustomDumpItemKind Enumeration](ecustomdumpitemkind-enumeration.md)
- [ICLRErrorReportingManager Interface](iclrerrorreportingmanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
