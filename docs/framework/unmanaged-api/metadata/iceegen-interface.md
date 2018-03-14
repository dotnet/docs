---
title: "ICeeGen Interface"
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
  - "ICeeGen"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICeeGen"
helpviewer_keywords: 
  - "ICeeGen interface [.NET Framework metadata]"
ms.assetid: 383d20b0-efe9-4e71-8fb8-1186b2e7d0c0
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICeeGen Interface
Provides methods for dynamic code compilation.  
  
 This interface is obsolete and should not be used.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[AddSectionReloc Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-addsectionreloc-method.md)|Obsolete. Adds a .reloc instruction to the code base.|  
|[AllocateMethodBuffer Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-allocatemethodbuffer-method.md)|Obsolete. Creates a buffer of the specified size for a method, and gets the relative virtual address of the method.|  
|[ComputePointer Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-computepointer-method.md)|Obsolete. Determines the buffer for the specified code section.|  
|[EmitString Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-emitstring-method.md)|Obsolete. Emits the specified string into the code base.|  
|[GenerateCeeFile Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-generateceefile-method.md)|Obsolete. Generates a code-base file that contains the code base currently loaded into this `ICeeGen`.|  
|[GenerateCeeMemoryImage Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-generateceememoryimage-method.md)|Obsolete. Generates an image in memory for the code base.|  
|[GetIlSection Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getilsection-method.md)|Obsolete. Gets the section of the intermediate language code base referenced by the specified handle.|  
|[GetIMapTokenIface Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getimaptokeniface-method.md)|Obsolete. Gets the interface referenced by the specified token.|  
|[GetMethodBuffer Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getmethodbuffer-method.md)|Obsolete. Gets a buffer of the appropriate size for the method at the specified relative virtual address.|  
|[GetSectionBlock Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getsectionblock-method.md)|Obsolete. Gets a section block of the code base.|  
|[GetSectionCreate Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getsectioncreate-method.md)|Obsolete. Generates and gets a code section using the specified name and flag values.|  
|[GetSectionDataLen Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getsectiondatalen-method.md)|Obsolete. Gets the length of the specified section.|  
|[GetString Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getstring-method.md)|Obsolete. Gets the string stored at the specified relative virtual address.|  
|[GetStringSection Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-getstringsection-method.md)|Obsolete. Gets a string representation of the code section referenced by the specified handle.|  
|[TruncateSection Method](../../../../docs/framework/unmanaged-api/metadata/iceegen-truncatesection-method.md)|Obsolete. Truncates the specified code section by the specified length.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Interfaces](../../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md)
