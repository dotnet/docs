---
title: "CorLocalRefPreservation Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorLocalRefPreservation"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorLocalRefPreservation"
helpviewer_keywords: 
  - "CorLocalRefPreservation enumeration [.NET Framework metadata]"
ms.assetid: 44757163-1228-4213-a4c4-d4de503cc75d
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CorLocalRefPreservation Enumeration
Contains flag values for the treatment of local references.  
  
## Syntax  
  
```  
typedef enum CorLocalRefPreservation  
{  
    MDPreserveLocalRefsNone     =   0x00000000,  
    MDPreserveLocalTypeRef      =   0x00000001,  
    MDPreserveLocalMemberRef    =   0x00000002  
} CorLocalRefPreservation;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MDPreserveLocalRefsNone`|Preserve no local references.|  
|`MDPreserveLocalTypeRef`|Preserve local type references.|  
|`MDPreserveLocalMemberRef`|Preserve local member references.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also
- [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
