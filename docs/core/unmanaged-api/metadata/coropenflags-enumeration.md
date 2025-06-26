---
description: "Learn more about: CorOpenFlags Enumeration"
title: "CorOpenFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorOpenFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorOpenFlags"
helpviewer_keywords: 
  - "CorOpenFlags enumeration [.NET Framework metadata]"
ms.assetid: e27a83b5-2698-4996-9032-1e0fed8b91ca
topic_type: 
  - "apiref"
---
# CorOpenFlags Enumeration

Contains flag values that control metadata behavior upon opening manifest files.  
  
## Syntax  
  
```cpp  
typedef enum CorOpenFlags  
{  
    ofRead              =   0x00000000,  
    ofWrite             =   0x00000001,  
    ofReadWriteMask     =   0x00000001,  
    ofCopyMemory        =   0x00000002,  
    ofCacheImage        =   0x00000004,  
    ofManifestMetadata  =   0x00000008,  
    ofReadOnly          =   0x00000010,  
    ofTakeOwnership     =   0x00000020,  
    ofCacheImage        =   0x00000004,  
    ofNoTypeLib         =   0x00000080,  
    ofNoTransform       =   0x00001000,  
    ofReserved1         =   0x00000100,  
    ofReserved2         =   0x00000200,  
    ofReserved          =   0xffffff40  
} CorOpenFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ofRead`|Indicates that the file should be opened for reading only.|  
|`ofWrite`|Indicates that the file should be opened for writing.<br /><br /> If you are using the `ofWrite` flag when opening a .winmd file, you should also pass the `ofNoTransform` flag.|  
|`ofReadWriteMask`|A mask for reading and writing.|  
|`ofCopyMemory`|Indicates that the file should be read into memory. Metadata should maintain its own copy.|  
|`ofCacheImage`|Obsolete. This flag is ignored.|  
|`ofManifestMetadata`|Obsolete. This flag is ignored.|  
|`ofReadOnly`|Indicates that the file should be opened for reading, and that a call to `QueryInterface` for an [IMetaDataEmit](imetadataemit-interface.md) cannot be made.|  
|`ofTakeOwnership`|Indicates that the memory was allocated using a call to [CoTaskMemAlloc](/windows/desktop/api/combaseapi/nf-combaseapi-cotaskmemalloc) and will be freed by the metadata.|  
|`ofNoTypeLib`|Obsolete. This flag is ignored.|  
|`ofNoTransform`|Indicates that automatic transforms of .winmd files should be disabled. In other words, the projection of a Windows Runtime type to a .NET Framework type should be disabled. For more information, see [Windows Runtime and the CLR - Underneath the Hood with .NET and the Windows Runtime](/archive/msdn-magazine/2012/windows-8-special-issue/windows-runtime-and-the-clr-underneath-the-hood-with-net-and-the-windows-runtime).|  
|`ofReserved1`|Reserved for internal use.|  
|`ofReserved2`|Reserved for internal use.|  
|`ofReserved`|Reserved for internal use.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
