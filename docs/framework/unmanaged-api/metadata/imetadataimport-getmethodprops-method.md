---
title: "IMetaDataImport::GetMethodProps Method"
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
  - "IMetaDataImport.GetMethodProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetMethodProps"
helpviewer_keywords: 
  - "GetMethodProps method [.NET Framework metadata]"
  - "IMetaDataImport::GetMethodProps method [.NET Framework metadata]"
ms.assetid: e0667ef7-1d31-4c89-a2d3-d426f023f8d2
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetMethodProps Method
Gets the metadata associated with the method referenced by the specified MethodDef token.  
  
## Syntax  
  
```  
HRESULT GetMethodProps (  
    [in]  mdMethodDef         mb,  
    [out] mdTypeDef           *pClass,  
    [out] LPWSTR              szMethod,  
    [in]  ULONG               cchMethod,  
    [out] ULONG               *pchMethod,  
    [out] DWORD               *pdwAttr,  
    [out] PCCOR_SIGNATURE     *ppvSigBlob,  
    [out] ULONG               *pcbSigBlob,  
    [out] ULONG               *pulCodeRVA,  
    [out] DWORD               *pdwImplFlags  
);  
```  
  
#### Parameters  
 `mb`  
 [in] The MethodDef token that represents the method to return metadata for.  
  
 `pClass`  
 [out] A Pointer to a TypeDef token that represents the type that implements the method.  
  
 `szMethod`  
 [out] A Pointer to a buffer that has the method's name.  
  
 `cchMethod`  
 [in] The requested size of `szMethod`.  
  
 `pchMethod`  
 [out] A Pointer to the size in wide characters of `szMethod`, or in the case of truncation, the actual number of wide characters in the method name.  
  
 `pdwAttr`  
 [out] A pointer to any flags associated with the method.  
  
 `ppvSigBlob`  
 [out] A pointer to the binary metadata signature of the method.  
  
 `pcbSigBlob`  
 [out] A Pointer to the size in bytes of `ppvSigBlob`.  
  
 `pulCodeRVA`  
 [out] A pointer to the relative virtual address of the method.  
  
 `pdwImplFlags`  
 [out] A pointer to any implementation flags for the method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
