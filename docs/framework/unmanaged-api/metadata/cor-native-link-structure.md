---
title: "COR_NATIVE_LINK Structure"
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
  - "COR_NATIVE_LINK"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_NATIVE_LINK"
helpviewer_keywords: 
  - "COR_NATIVE_LINK structure [.NET Framework metadata]"
ms.assetid: 6ef78d3c-1c69-4141-b687-dcb065b7a74d
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_NATIVE_LINK Structure
Contains information that is used to link native code.  
  
## Syntax  
  
```  
typedef struct   
{  
    BYTE        m_linkType;  
    BYTE        m_flags;  
    mdMemberRef m_entryPoint;  
} COR_NATIVE_LINK;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`m_linkType`|The type to be linked in native code. This value is one of the [CorNativeLinkType](../../../../docs/framework/unmanaged-api/metadata/cornativelinktype-enumeration.md) values.|  
|`m_flags`|Flags used by the linker when linking native code. This value is one of the [CorNativeLinkFlags](../../../../docs/framework/unmanaged-api/metadata/cornativelinkflags-enumeration.md) values.|  
|`m_entryPoint`|The MemberRef metadata token that represents the entry point. The format is `lib:entrypoint`.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Structures](../../../../docs/framework/unmanaged-api/metadata/metadata-structures.md)  
 [CorNativeLinkType Enumeration](../../../../docs/framework/unmanaged-api/metadata/cornativelinktype-enumeration.md)  
 [CorNativeLinkFlags Enumeration](../../../../docs/framework/unmanaged-api/metadata/cornativelinkflags-enumeration.md)
