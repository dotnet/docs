---
title: "CorAttributeTargets Enumeration"
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
  - "CorAttributeTargets"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorAttributeTargets"
helpviewer_keywords: 
  - "CorAttributeTargets enumeration [.NET Framework metadata]"
ms.assetid: 694c0fa0-7011-41a9-9dfd-f0e16ea574b5
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorAttributeTargets Enumeration
Specifies the application elements on which it is valid to apply an attribute.  
  
## Syntax  
  
```  
typedef enum CorAttributeTargets  
{  
    catAssembly            = 0x0001,  
    catModule              = 0x0002,  
    catClass               = 0x0004,  
    catStruct              = 0x0008,  
    catEnum                = 0x0010,  
    catConstructor         = 0x0020,  
    catMethod              = 0x0040,  
    catProperty            = 0x0080,  
    catField               = 0x0100,  
    catEvent               = 0x0200,  
    catInterface           = 0x0400,  
    catParameter           = 0x0800,  
    catDelegate            = 0x1000,  
    catGenericParameter    = 0x4000,  
  
    catAll                 =   
        catAssembly | catModule | catClass | catStruct |   
        catEnum | catConstructor | catMethod | catProperty |   
        catField | catEvent | catInterface | catParameter |   
        catDelegate | catGenericParameter,  
  
    catClassMembers        =   
        catClass | catStruct | catEnum | catConstructor |   
        catMethod | catProperty | catField | catEvent |   
        catDelegate | catInterface  
  
} CorAttributeTargets;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`catAssembly`|Attribute can be applied to an assembly.|  
|`catModule`|Attribute can be applied to a portable executable (.dll or .exe) module.|  
|`catClass`|Attribute can be applied to a class.|  
|`catStruct`|Attribute can be applied to a structure; that is, a value type.|  
|`catEnum`|Attribute can be applied to an enumeration.|  
|`catConstructor`|Attribute can be applied to a constructor.|  
|`catMethod`|Attribute can be applied to a method.|  
|`catProperty`|Attribute can be applied to a property.|  
|`catField`|Attribute can be applied to a field.|  
|`catEvent`|Attribute can be applied to an event.|  
|`catInterface`|Attribute can be applied to an interface.|  
|`catParameter`|Attribute can be applied to a parameter.|  
|`catDelegate`|Attribute can be applied to a delegate.|  
|`catGenericParameter`|Attribute can be applied to a generic parameter.|  
|`catAll`|Attribute can be applied to any application element.|  
|`catClassMembers`|Attribute can be applied to a member of a class.|  
  
## Remarks  
 The `CorAttributeTargets` enumeration values can be combined with a bitwise OR operation to get the preferred combination.  
  
 The `CorAttributeTargets` parallels the managed <xref:System.AttributeTargets?displayProperty=nameWithType> enumeration.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
