---
title: "IMetaDataEmit::TranslateSigWithScope Method"
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
  - "IMetaDataEmit.TranslateSigWithScope"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::TranslateSigWithScope"
helpviewer_keywords: 
  - "TranslateSigWithScope method [.NET Framework metadata]"
  - "IMetaDataEmit::TranslateSigWithScope method [.NET Framework metadata]"
ms.assetid: 47915d33-b7bf-409e-b484-4ee1df15de22
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::TranslateSigWithScope Method
Imports an assembly into the current scope and gets a new metadata signature for the merged scope.  
  
## Syntax  
  
```  
HRESULT TranslateSigWithScope (   
    [in]  IMetaDataAssemblyImport   *pAssemImport,   
    [in]  const void                *pbHashValue,   
    [in]  ULONG                     cbHashValue,   
    [in]  IMetaDataImport           *import,   
    [in]  PCCOR_SIGNATURE           pbSigBlob,   
    [in]  ULONG                     cbSigBlob,  
    [in]  IMetaDataAssemblyEmit     *pAssemEmit,   
    [in]  IMetaDataEmit             *emit,   
    [out] PCOR_SIGNATURE            pvTranslatedSig,   
    [in]  ULONG                     cbTranslatedSigMax,   
    [out] ULONG                     *pcbTranslatedSig   
);  
```  
  
#### Parameters  
 `pAssemImport`  
 [in] The interface for import assembly (where the signature is defined).  
  
 `pbHashValue`  
 [in] The hash blob for the assembly.  
  
 `cbHashValue`  
 [in] The count of bytes in `pbHashValue`.  
  
 `import`  
 [in] The interface for import metadata scope.  
  
 `pbSigBlob`  
 [in] The signature to be imported.  
  
 `cbSigBlob`  
 [in] The size, in bytes, of `pbSigBlob`.  
  
 `pAssemEmit`  
 [in] The interface for export assembly.  
  
 `emit`  
 [in] The interface for export metadata scope.  
  
 `pvTranslatedSig`  
 [out] The buffer to hold the translated signature blob.  
  
 `cbTranslatedSigMax`  
 [in] The capacity, in bytes, of `pvTranslatedSig`.  
  
 `pcbTranslatedSig`  
 [out] The number of actual bytes in the translated signature.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
