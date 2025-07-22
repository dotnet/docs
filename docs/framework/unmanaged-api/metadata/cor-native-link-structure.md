---
description: "Learn more about: COR_NATIVE_LINK Structure"
title: "COR_NATIVE_LINK Structure"
ms.date: "03/30/2017"
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
---
# COR_NATIVE_LINK Structure

Contains information that is used to link native code.  
  
## Syntax  
  
```cpp  
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
|`m_linkType`|The type to be linked in native code. This value is one of the [CorNativeLinkType](cornativelinktype-enumeration.md) values.|  
|`m_flags`|Flags used by the linker when linking native code. This value is one of the [CorNativeLinkFlags](cornativelinkflags-enumeration.md) values.|  
|`m_entryPoint`|The MemberRef metadata token that represents the entry point. The format is `lib:entrypoint`.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Structures](metadata-structures.md)
- [CorNativeLinkType Enumeration](cornativelinktype-enumeration.md)
- [CorNativeLinkFlags Enumeration](cornativelinkflags-enumeration.md)
