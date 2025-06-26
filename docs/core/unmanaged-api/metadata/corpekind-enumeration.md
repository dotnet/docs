---
description: "Learn more about: CorPEKind Enumeration"
title: "CorPEKind Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorPEKind"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorPEKind"
helpviewer_keywords: 
  - "CorPEKind enumeration [.NET Framework metadata]"
ms.assetid: 22dc6dea-b1b9-4982-a730-a022d586b117
topic_type: 
  - "apiref"
---
# CorPEKind Enumeration

Contains values that describe a portable executable (PE) file, as returned from a call to [IMetaDataImport2::GetPEKind](imetadataimport2-getpekind-method.md).  
  
## Syntax  
  
```cpp  
typedef enum CorPEKind {  
  
    peNot           = 0x00000000,  
    peILonly        = 0x00000001,  
    pe32BitRequired = 0x00000002,  
    pe32Plus        = 0x00000004,  
    pe32Unmanaged   = 0x00000008,  
    pe32BitPreferred= 0x00000010  
  
} CorPEKind;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`peNot`|Indicates that this is not a PE file.|  
|`peILOnly`|Indicates that this PE file contains only managed code.|  
|`pe32BitRequired`|Indicates that this PE file makes Win32 calls.|  
|`pe32Plus`|Indicates that this PE file runs on a 64-bit platform.|  
|`pe32Unmanaged`|Indicates that this PE file is native code.|  
|pe32BitPreferred|Indicates that this PE file is platform-neutral and prefers to be loaded in a 32-bit environment.|  
  
## Remarks  

 These values can be used in bitwise combinations.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
