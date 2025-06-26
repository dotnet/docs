---
description: "Learn more about: CeeSectionAttr Enumeration"
title: "CeeSectionAttr Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CeeSectionAttr"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CeeSectionAttr"
helpviewer_keywords: 
  - "CeeSectionAttr enumeration [.NET Framework metadata]"
ms.assetid: 0db51881-b869-4677-a715-1726a9216489
topic_type: 
  - "apiref"
---
# CeeSectionAttr Enumeration

Provides values that specify attributes of a section for use by the [ICeeGen](iceegen-interface.md) interface.  
  
## Syntax  
  
```cpp  
typedef enum  {  
    sdNone      = 0,  
    sdReadOnly  = IMAGE_SCN_CNT_INITIALIZED_DATA |  
                  IMAGE_SCN_MEM_READ,  
    sdReadWrite = sdReadOnly | IMAGE_SCN_MEM_WRITE,  
    sdExecute   = IMAGE_SCN_MEM_READ | IMAGE_SCN_CNT_CODE |  
                  IMAGE_SCN_MEM_EXECUTE  
} CeeSectionAttr;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`sdNone`|Section has no attributes.|  
|`sdReadOnly`|Section contains initialized data that can be only read, not updated.|  
|`sdReadWrite`|Section contains initialized data that can be read or updated.|  
|`sdExecute`|Section contains executable code that is allowed to be read and executed.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
