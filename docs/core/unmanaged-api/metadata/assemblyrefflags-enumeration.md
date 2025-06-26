---
description: "Learn more about: AssemblyRefFlags Enumeration"
title: "AssemblyRefFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "AssemblyRefFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AssemblyRefFlags"
helpviewer_keywords: 
  - "AssemblyRefFlags enumeration [.NET Framework metadata]"
ms.assetid: decd4f46-f3b2-466f-9501-e74f2b86b846
topic_type: 
  - "apiref"
---
# AssemblyRefFlags Enumeration

Contains values that describe features of an assembly reference.  
  
## Syntax  
  
```cpp  
typedef enum {  
    arfFullOriginator = 0x0001  
} AssemblyRefFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`arfFullOriginator`|Specifies that the assembly reference contains full, unhashed information about the publisher of the assembly.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
- [DefineAssemblyRef Method](imetadataassemblyemit-defineassemblyref-method.md)
