---
description: "Learn more about: CorErrorIfEmitOutOfOrder Enumeration"
title: "CorErrorIfEmitOutOfOrder Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorErrorIfEmitOutOfOrder"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorErrorIfEmitOutOfOrder"
helpviewer_keywords: 
  - "CorErrorIfEmitOutOfOrder enumeration [.NET Framework metadata]"
ms.assetid: 6d758aad-29a7-44fe-9481-bbff5b799a32
topic_type: 
  - "apiref"
---
# CorErrorIfEmitOutOfOrder Enumeration

Contains flag values that indicate the conditions under which an error message should be generated when metadata is emitted out of order.  
  
## Syntax  
  
```cpp  
typedef enum CorErrorIfEmitOutOfOrder {  
  
    MDErrorOutOfOrderDefault    = 0x00000000,  
    MDErrorOutOfOrderNone       = 0x00000000,  
    MDErrorOutOfOrderAll        = 0xffffffff,  
    MDMethodOutOfOrder          = 0x00000001,  
    MDFieldOutOfOrder           = 0x00000002,  
    MDParamOutOfOrder           = 0x00000004,  
    MDPropertyOutOfOrder        = 0x00000008,  
    MDEventOutOfOrder           = 0x00000010  
  
} CorErrorIfEmitOutOfOrder;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MDErrorOutOfOrderDefault`|Indicates the default behavior, which does not generate error messages.|  
|`MDErrorOutOfOrderNone`|Indicates that the compiler should not generate error messages.|  
|`MDErrorOutOfOrderAll`|Indicates that the compiler should generate an error message when a field, property, event, method, or parameter is emitted out of order.|  
|`MDMethodOutOfOrder`|Indicates that the compiler should generate an error message when a method is emitted out of order.|  
|`MDFieldOutOfOrder`|Indicates that the compiler should generate an error message when a field is emitted out of order.|  
|`MDParamOutOfOrder`|Indicates that the compiler should generate an error message when a parameter is emitted out of order.|  
|`MDPropertyOutOfOrder`|Indicates that the compiler should generate an error message when a property is emitted out of order.|  
|`MDEventOutOfOrder`|Indicates that the compiler should generate an error message when an event is emitted out of order.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
