---
title: "CorParamAttr Enumeration"
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
  - "CorParamAttr"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorParamAttr"
helpviewer_keywords: 
  - "CorParamAttr enumeration [.NET Framework metadata]"
ms.assetid: a7ff90ad-dad8-48e8-917d-4aa9a118cbc8
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorParamAttr Enumeration
Contains values that describe the metadata of a method parameter.  
  
## Syntax  
  
```  
typedef enum CorParamAttr {  
  
    pdIn                        =   0x0001,  
    pdOut                       =   0x0002,  
    pdOptional                  =   0x0010,  
  
    pdReservedMask              =   0xf000,  
    pdHasDefault                =   0x1000,  
    pdHasFieldMarshal           =   0x2000,  
  
    pdUnused                    =   0xcfe0  
  
} CorParamAttr;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pdIn`|Specifies that the parameter is passed into the method call.|  
|`pdOut`|Specifies that the parameter is passed from the method return.|  
|`pdOptional`|Specifies that the parameter is optional.|  
|`pdReservedMask`|Reserved for internal use by the common language runtime.|  
|`pdHasDefault`|Specifies that the parameter has a default value.|  
|`pdHasFieldMarshal`|Specifies that the parameter has marshaling information.|  
|`pdUnused`|Unused.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
