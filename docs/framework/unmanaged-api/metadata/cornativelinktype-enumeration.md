---
title: "CorNativeLinkType Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorNativeLinkType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorNativeLinkType"
helpviewer_keywords: 
  - "CorNativeLinkType enumeration [.NET Framework metadata]"
ms.assetid: 4f86ff37-2dab-4e64-819a-76b3bfe828ff
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CorNativeLinkType Enumeration
Provides values that indicate the type linked in native code.  
  
## Syntax  
  
```  
typedef enum   
{  
    nltNone       = 1,  
    nltAnsi       = 2,  
    nltUnicode    = 3,  
    nltAuto       = 4,  
    nltOle        = 5,  
    nltMaxValue   = 7  
} CorNativeLinkType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`nltNone`|Indicates that none of the keywords are specified.|  
|`nltAnsi`|Indicates that an ANSI keyword is specified.|  
|`nltUnicode`|Indicates that a Unicode keyword is specified|  
|`nltAuto`|Indicates that an auto keyword is specified.|  
|`nltOle`|Indicates that an OLE keyword is specified.|  
|`nltMaxValue`|Not used.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
