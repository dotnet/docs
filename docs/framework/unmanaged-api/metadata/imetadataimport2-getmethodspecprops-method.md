---
title: "IMetaDataImport2::GetMethodSpecProps Method"
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
  - "IMetaDataImport2.GetMethodSpecProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport2::GetMethodSpecProps"
helpviewer_keywords: 
  - "GetMethodSpecProps method [.NET Framework metadata]"
  - "IMetaDataImport2::GetMethodSpecProps method [.NET Framework metadata]"
ms.assetid: 9544b711-e669-4eaf-8630-ee862e5e4489
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport2::GetMethodSpecProps Method
Gets the metadata signature of the method referenced by the specified MethodSpec token.  
  
## Syntax  
  
```  
HRESULT GetMethodSpecProps (  
   [in]  mdMethodSpec     mi,  
   [out] mdToken          *tkParent,  
   [out] PCCOR_SIGNATURE  *ppvSigBlob,   
   [out] ULONG            *pcbSigBlob  
);   
```  
  
#### Parameters  
 `mi`  
 [in] A MethodSpec token that represents the instantiation of the method.  
  
 `tkParent`  
 [out] A pointer to the MethodDef or MethodRef token that represents the method definition.  
  
 `ppvSigBlob`  
 [out] A pointer to the binary metadata signature of the method.  
  
 `pcbSigBlob`  
 [out] The size, in bytes, of `ppvSigBlob`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
