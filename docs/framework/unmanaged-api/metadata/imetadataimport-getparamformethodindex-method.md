---
title: "IMetaDataImport::GetParamForMethodIndex Method"
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
  - "IMetaDataImport.GetParamForMethodIndex"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetParamForMethodIndex"
helpviewer_keywords: 
  - "IMetaDataImport::GetParamForMethodIndex method [.NET Framework metadata]"
  - "GetParamForMethodIndex method [.NET Framework metadata]"
ms.assetid: ec3bfa95-1920-4511-932e-3ff23d76fcb8
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetParamForMethodIndex Method
Gets the token that represents a specified parameter of the method represented by the specified MethodDef token.  
  
## Syntax  
  
```  
HRESULT GetParamForMethodIndex (  
   [in]  mdMethodDef      md,  
   [in]  ULONG            ulParamSeq,  
   [out] mdParamDef       *ppd  
);  
```  
  
#### Parameters  
 `md`  
 [in] A token that represents the method to return the parameter token for.  
  
 `ulParamSeq`  
 [in] The ordinal position in the parameter list where the requested parameter occurs. Parameters are numbered starting from one, with the method's return value in position zero.  
  
 `ppd`  
 [out] A pointer to a ParamDef token that represents the requested parameter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
