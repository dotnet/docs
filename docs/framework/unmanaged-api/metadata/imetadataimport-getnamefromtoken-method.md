---
title: "IMetaDataImport::GetNameFromToken Method"
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
  - "IMetaDataImport.GetNameFromToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetNameFromToken"
helpviewer_keywords: 
  - "GetNameFromToken method [.NET Framework metadata]"
  - "IMetaDataImport::GetNameFromToken method [.NET Framework metadata]"
ms.assetid: 32114ecf-8916-4ab2-a201-179c017344f1
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetNameFromToken Method
Gets the UTF-8 name of the object referenced by the specified metadata token. This method is obsolete.  
  
## Syntax  
  
```  
HRESULT GetNameFromToken (  
   [in] mdToken      tk,  
   [out] MDUTF8CSTR  *pszUtf8NamePtr  
);  
```  
  
#### Parameters  
 `tk`  
 [in] The token representing the object to return the name for.  
  
 `pszUtf8NamePtr`  
 [out] A pointer to the UTF-8 object name in the heap.  
  
## Remarks  
 `GetNameFromToken` is obsolete. As an alternative, call a method to get the properties of the particular type of token required, such as `GetFieldProps` for a field or `GetMethodProps` for a method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** 1.0  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
