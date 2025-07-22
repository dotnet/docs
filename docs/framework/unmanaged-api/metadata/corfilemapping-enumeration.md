---
description: "Learn more about: CorFileMapping Enumeration"
title: "CorFileMapping Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorFileMapping"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorFileMapping"
helpviewer_keywords: 
  - "CorFileMapping enumeration [.NET Framework metadata]"
ms.assetid: 3ca41592-b8da-475a-8032-a15627730003
topic_type: 
  - "apiref"
---
# CorFileMapping Enumeration

Contains values that describe the type of file mapping that is returned from a call to the [IMetaDataInfo::GetFileMapping](imetadatainfo-getfilemapping-method.md) method.  
  
## Syntax  
  
```cpp  
typedef enum CorFileMapping {  
  
    fmFlat                  =   0x0000,  
    fmExecutableImage       =   0x0001  
  
} CorFileMapping;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`fmFlat`|The file is mapped as a data file. That is, the `SEC_IMAGE` flag was not passed to the Microsoft Win32 `CreateFileMapping` function.|  
|`fmExecutableImage`|The file is mapped for execution, by using either the `LoadLibrary` function or the `CreateFileMapping` function with the `SEC_IMAGE` flag.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
- [GetFileMapping Method](imetadatainfo-getfilemapping-method.md)
