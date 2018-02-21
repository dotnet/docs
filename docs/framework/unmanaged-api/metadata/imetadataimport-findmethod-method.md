---
title: "IMetaDataImport::FindMethod Method"
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
  - "IMetaDataImport.FindMethod"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::FindMethod"
helpviewer_keywords: 
  - "FindMethod method [.NET Framework metadata]"
  - "IMetaDataImport::FindMethod method [.NET Framework metadata]"
ms.assetid: 0f9bde1d-e306-438d-941b-d0925b322304
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::FindMethod Method
Gets a pointer to the MethodDef token for the method that is enclosed by the specified <xref:System.Type> and that has the specified name and metadata signature.  
  
## Syntax  
  
```  
HRESULT FindMethod (  
   [in]  mdTypeDef          td,  
   [in]  LPCWSTR            szName,   
   [in]  PCCOR_SIGNATURE    pvSigBlob,   
   [in]  ULONG              cbSigBlob,   
   [out] mdMethodDef        *pmb  
);  
```  
  
#### Parameters  
 `td`  
 [in] The `mdTypeDef` token for the type (a class or interface) that encloses the member to search for. If this value is `mdTokenNil`, then the lookup is done for a global function.  
  
 `szName`  
 [in] The name of the method to search for.  
  
 `pvSigBlob`  
 [in] A pointer to the binary metadata signature of the method.  
  
 `cbSigBlob`  
 [in] The size in bytes of `pvSigBlob`.  
  
 `pmb`  
 [out] A pointer to the matching MethodDef token.  
  
## Remarks  
 You specify the method using its enclosing class or interface (`td`), its name (`szName`), and optionally its signature (`pvSigBlob`). There might be multiple methods with the same name in a class or interface. In that case, pass the method's signature to find the unique match.  
  
 The signature passed to `FindMethod` must have been generated in the current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time signature outside the context of the current scope and use that signature as input to input to `FindMethod`.  
  
 `FindMethod` finds only methods that were defined directly in the class or interface; it does not find inherited methods.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 <xref:System.Reflection.MethodInfo>  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
