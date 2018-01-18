---
title: "IMetaDataImport::GetNativeCallConvFromSig Method"
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
  - "IMetaDataImport.GetNativeCallConvFromSig"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetNativeCallConvFromSig"
helpviewer_keywords: 
  - "GetNativeCallConvFromSig method [.NET Framework metadata]"
  - "IMetaDataImport::GetNativeCallConvFromSig method [.NET Framework metadata]"
ms.assetid: 50e04026-4d4a-47d9-96c1-f4677d6d938b
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetNativeCallConvFromSig Method
Gets the native calling convention for the method that is represented by the specified signature pointer.  
  
## Syntax  
  
```  
HRESULT GetNativeCallConvFromSig (  
   [in]  void const  *pvSig,  
   [in]  ULONG       cbSig,  
   [out] ULONG       *pCallConv  
);  
```  
  
#### Parameters  
 `pvSig`  
 [in] A pointer to the metadata signature of the method to return the calling convention for.  
  
 `cbSig`  
 [in] The size in bytes of `pvSig`.  
  
 `pCallConv`  
 [out] A pointer to the native calling convention.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 <xref:System.Runtime.InteropServices.CallingConvention>  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
