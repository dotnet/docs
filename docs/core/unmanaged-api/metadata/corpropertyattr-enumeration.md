---
description: "Learn more about: CorPropertyAttr Enumeration"
title: "CorPropertyAttr Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorPropertyAttr"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorPropertyAttr"
helpviewer_keywords: 
  - "CorPropertyAttr enumeration [.NET Framework metadata]"
ms.assetid: 58ac8202-854d-4efd-acfb-d2da8b446e12
topic_type: 
  - "apiref"
---
# CorPropertyAttr Enumeration

Contains values that describe the metadata of a property.  
  
## Syntax  
  
```cpp  
typedef enum CorPropertyAttr {  
  
    prSpecialName           =   0x0200,
    prReservedMask          =   0xf400,  
    prRTSpecialName         =   0x0400,  
    prHasDefault            =   0x1000,  
    prUnused                =   0xe9ff  
  
} CorPropertyAttr;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`prSpecialName`|Specifies that the property is special, and that its name describes how.|  
|`prReservedMask`|Reserved for internal use by the common language runtime.|  
|`prRTSpecialName`|Specifies that the common language runtime metadata internal APIs should check the encoding of the property name.|  
|`prHasDefault`|Specifies that the property has a default value.|  
|`prUnused`|Unused.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
