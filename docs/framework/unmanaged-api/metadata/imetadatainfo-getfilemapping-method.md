---
title: "IMetaDataInfo::GetFileMapping Method"
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
  - "IMetaDataInfo.GetFileMapping"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataInfo::GetFileMapping"
helpviewer_keywords: 
  - "IMetaDataInfo::GetFileMapping method [.NET Framework metadata]"
  - "GetFileMapping method [.NET Framework metadata]"
ms.assetid: 2868dfec-c992-4606-88bb-a8e0b6b18271
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataInfo::GetFileMapping Method
Gets the memory region of the mapped file, and the type of mapping.  
  
## Syntax  
  
```  
HRESULT GetFileMapping (  
    [out] const void           **ppvData,   
    [out] ULONGLONG            *pcbData,   
    [out] DWORD                *pdwMappingType  
);  
```  
  
#### Parameters  
 `ppvData`  
 [out] A pointer to the start of the mapped file.  
  
 `pcbData`  
 [out] The size of the mapped region. If `pdwMappingType` is `fmFlat`, this is the size of the file.  
  
 `pdwMappingType`  
 [out] A [CorFileMapping](../../../../docs/framework/unmanaged-api/metadata/corfilemapping-enumeration.md) value that indicates the type of mapping. The current implementation of the common language runtime (CLR) always returns `fmFlat`. Other values are reserved for future use. However, you should always verify the returned value, because other values may be enabled in future versions or service releases.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|All outputs are filled.|  
|`E_INVALIDARG`|NULL was passed as an argument value.|  
|`COR_E_NOTSUPPORTED`|The CLR implementation cannot provide information about the memory region. This can happen for the following reasons:<br /><br /> -   The metadata scope was opened with the `ofWrite` or `ofCopyMemory` flag.<br />-   The metadata scope was opened without the `ofReadOnly` flag.<br />-   The [IMetaDataDispenser::OpenScopeOnMemory](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-openscopeonmemory-method.md) method was used to open only the metadata portion of the file.<br />-   The file is not a portable executable (PE) file. **Note:**  These conditions depend on the CLR implementation, and are likely to be weakened in future versions of the CLR.|  
  
## Remarks  
 The memory that `ppvData` points to is valid only as long as the underlying metadata scope is open.  
  
 In order for this method to work, when you map the metadata of an on-disk file into memory by calling the [IMetaDataDispenser::OpenScope](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-openscope-method.md) method, you must specify the `ofReadOnly` flag and you must not specify the `ofWrite` or `ofCopyMemory` flag.  
  
 The choice of file mapping type for each scope is specific to a given implementation of the CLR. It cannot be set by the user. The current implementation of the CLR always returns `fmFlat` in `pdwMappingType`, but this can change in future versions of the CLR or in future service releases of a given version. You should always check the returned value in `pdwMappingType`, because different types will have different layouts and offsets.  
  
 Passing NULL for any of the three parameters is not supported. The method returns `E_INVALIDARG`, and none of the outputs are filled. Ignoring the mapping type or the size of the region can result in abnormal program termination.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [IMetaDataInfo Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatainfo-interface.md)  
 [CorFileMapping Enumeration](../../../../docs/framework/unmanaged-api/metadata/corfilemapping-enumeration.md)
