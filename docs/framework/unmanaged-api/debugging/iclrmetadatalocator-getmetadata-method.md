---
title: "ICLRMetadataLocator::GetMetadata Method"
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
  - "ICLRMetadataLocator.GetMetadata"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetadataLocator::GetMetadata"
helpviewer_keywords: 
  - "GetMetadata method, ICLRMetadataLocator interface [.NET Framework debugging]"
  - "ICLRMetadataLocator::GetMetadata method [.NET Framework debugging]"
ms.assetid: 704a8893-ac56-43b4-90ea-715f38ccb40e
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRMetadataLocator::GetMetadata Method
Called by the common language runtime (CLR) data access services to retrieve the metadata of an image.  
  
## Syntax  
  
```  
HRESULT GetMetadata(  
    [in]  LPCWSTR         imagePath,  
    [in]  ULONG32         imageTimestamp,  
    [in]  ULONG32         imageSize,  
    [in]  GUID*           mvid,  
    [in]  ULONG32         mdRva,  
    [in]  ULONG32         flags,  
    [in]  ULONG32         bufferSize,  
    [out, size_is(bufferSize), length_is(*dataSize)]  
          BYTE*           buffer,  
    [out] ULONG32*        dataSize  
);  
```  
  
#### Parameters  
 `imagePath`  
 [in] A string that specifies the path of the image file.  
  
 `imageTimestamp`  
 [in] The time stamp of the image file.  
  
 `imageSize`  
 [in] The size of the image file.  
  
 `mvid`  
 [in] The globally unique identifier of the image.  
  
 `mdRva`  
 [in] The relative virtual address (RVA) of the metadata. The address is relative to the image base address.  
  
 `flags`  
 [in] Reserved for future use.  
  
 `bufferSize`  
 [in] The size of the buffer in which to place the metadata.  
  
 `buffer`  
 [out] The buffer in which to place the metadata.  
  
 `dataSize`  
 [out] The size of the metadata that is returned.  
  
## Remarks  
 This method is implemented by the writer of the debugging application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRMetadataLocator Interface](../../../../docs/framework/unmanaged-api/debugging/iclrmetadatalocator-interface.md)
