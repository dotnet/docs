---
title: "IMetaDataConverter::GetMetaDataFromTypeInfo Method"
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
  - "IMetaDataConverter.GetMetaDataFromTypeInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataConverter::GetMetaDataFromTypeInfo"
helpviewer_keywords: 
  - "GetMetaDataFromTypeInfo method [.NET Framework metadata]"
  - "IMetaDataConverter::GetMetaDataFromTypeInfo method [.NET Framework metadata]"
ms.assetid: d44484bb-23a3-49c3-9e46-69d0d9ab4f0f
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataConverter::GetMetaDataFromTypeInfo Method
Gets a pointer to an [IMetaDataImport](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md) instance that represents the metadata signature of the type library referenced by the specified `ITypeInfo` instance.  
  
## Syntax  
  
```  
HRESULT GetMetaDataFromTypeInfo (  
    [in]  ITypeInfo         *pITI,  
    [out] IMetaDataImport   **ppMDI  
);  
```  
  
#### Parameters  
 `pITI`  
 [in] A pointer to an `ITypeInfo` object that refers to the type library.  
  
 `ppMDI`  
 [out] A pointer to a location that receives the address of the `IMetaDataImport` instance that represents the metadata signature.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
