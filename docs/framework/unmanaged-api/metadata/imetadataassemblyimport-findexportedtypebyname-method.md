---
title: "IMetaDataAssemblyImport::FindExportedTypeByName Method"
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
  - "IMetaDataAssemblyImport.FindExportedTypeByName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport::FindExportedTypeByName"
helpviewer_keywords: 
  - "FindExportedTypeByName method [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::FindExportedTypeByName method [.NET Framework metadata]"
ms.assetid: 46264b2c-574d-4dde-aafc-77187a104fdd
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyImport::FindExportedTypeByName Method
Gets a pointer to an exported type, given its name and enclosing type.  
  
## Syntax  
  
```  
HRESULT FindExportedTypeByName (  
    [in]  LPCWSTR           szName,   
    [in]  mdToken           mdtExportedType,   
    [out] mdExportedType    *ptkExportedType  
);  
```  
  
#### Parameters  
 `szName`  
 [in] The name of the exported type.  
  
 `mdtExportedType`  
 [in] The metadata token for the enclosing class of the exported type. This value is `mdExportedTypeNil` if the requested exported type is not a nested type.  
  
 `ptkExportedType`  
 [out] A pointer to the `mdExportedType` token that represents the exported type.  
  
## Remarks  
 The `FindExportedTypeByName` method uses the standard rules employed by the common language runtime for resolving references.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)  
 [How the Runtime Locates Assemblies](../../../../docs/framework/deployment/how-the-runtime-locates-assemblies.md)
