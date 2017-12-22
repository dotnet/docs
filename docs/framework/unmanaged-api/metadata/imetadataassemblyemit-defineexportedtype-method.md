---
title: "IMetaDataAssemblyEmit::DefineExportedType Method"
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
  - "IMetaDataAssemblyEmit.DefineExportedType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::DefineExportedType"
helpviewer_keywords: 
  - "IMetaDataAssemblyEmit::DefineExportedType method [.NET Framework metadata]"
  - "DefineExportedType method [.NET Framework metadata]"
ms.assetid: fad01d7a-3178-4c8c-9f0a-4641e3701c9b
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyEmit::DefineExportedType Method
Creates an `ExportedType` structure containing metadata for the specified exported type, and returns the associated metadata token.  
  
## Syntax  
  
```  
HRESULT DefineExportedType (  
    [in]  LPCWSTR             szName,  
    [in]  mdToken             tkImplementation,   
    [in]  mdTypeDef           tkTypeDef,  
    [in]  DWORD               dwExportedTypeFlags,  
    [out] mdExportedType      *pmdct  
);  
```  
  
#### Parameters  
 `szName`  
 [in] The name of type to be exported. For version 1.1 of the common language runtime, the name of the exported type must exactly match the name given in the `TypeDef` for the type.  
  
 `tkImplementation`  
 [in] A token specifying where the exported type is implemented. The valid values and their associated meanings are:  
  
-   `mdFile` The type is implemented in a different file within this assembly.  
  
-   `mdAssemblyRef` The type is implemented in a different assembly.  
  
-   `mdExportedTYpe` The type is nested within some other type.  
  
-   `mdFileNil` The type is in the same file as the manifest and is not a nested type.  
  
 `tkTypeDef`  
 [in] A token to the metadata that specifies the type to be exported. This value is entered in the `TypeDef` table in the file that implements the type and is relevant only if that file is in this assembly.  
  
 `dwExportedTypeFlags`  
 [in] A bitwise combination of [CorTypeAttr](../../../../docs/framework/unmanaged-api/metadata/cortypeattr-enumeration.md) enumeration values that define the property settings for the exported type.  
  
 `pmdct`  
 [out] A pointer to the returned metadata token that indicates the exported type.  
  
## Remarks  
 An `ExportedType` metadata structure must be defined for each type that is exposed by this assembly and that is implemented in a module other than the one containing the manifest.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)
