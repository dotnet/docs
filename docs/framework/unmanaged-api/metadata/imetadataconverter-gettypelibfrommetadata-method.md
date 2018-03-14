---
title: "IMetaDataConverter::GetTypeLibFromMetaData Method"
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
  - "IMetaDataConverter.GetTypeLibFromMetaData"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataConverter::GetTypeLibFromMetaData"
helpviewer_keywords: 
  - "GetTypeLibFromMetaData method [.NET Framework metadata]"
  - "IMetaDataConverter::GetTypeLibFromMetaData method [.NET Framework metadata]"
ms.assetid: 90eab7b3-1fae-4af4-8bce-f7bc0e188a99
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataConverter::GetTypeLibFromMetaData Method
Gets a pointer to an `ITypeLib` instance that represents the type library that has the specified library and module names.  
  
## Syntax  
  
```  
HRESULT GetTypeLibFromMetaData (  
    [in]  BSTR     strModule,   
    [in]  BSTR     strTlbName,   
    [out] ITypeLib **ppITL  
);  
```  
  
#### Parameters  
 `strModule`  
 [in] The name of the type library's module.  
  
 `strTlbName`  
 [in] The name of the type library.  
  
 `ppITL`  
 [out] A pointer to a location that receives the address of the `ITypeLib` instance that represents the type library.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataConverter Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataconverter-interface.md)
