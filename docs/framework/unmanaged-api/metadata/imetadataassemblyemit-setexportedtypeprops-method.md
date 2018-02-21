---
title: "IMetaDataAssemblyEmit::SetExportedTypeProps Method"
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
  - "IMetaDataAssemblyEmit.SetExportedTypeProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit::SetExportedTypeProps"
helpviewer_keywords: 
  - "SetExportedTypeProps method [.NET Framework metadata]"
  - "IMetaDataAssemblyEmit::SetExportedTypeProps method [.NET Framework metadata]"
ms.assetid: 1c090153-fd5f-46c7-9cff-39a78d992c8f
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyEmit::SetExportedTypeProps Method
Modifies the specified `ExportedType` metadata structure.  
  
## Syntax  
  
```  
HRESULT SetExportedTypeProps (  
    [in] mdExportedType   ct,   
    [in] mdToken          tkImplementation,  
    [in] mdTypeDef        tkTypeDef,  
    [in] DWORD            dwExportedTypeFlags  
);  
```  
  
#### Parameters  
 `ct`  
 [in] The metadata token that specifies the `ExportedType` metadata structure to be modified.  
  
 `tkImplementation`  
 [in] The token, of type `File`, `AssemblyRef`, or `ExportedType`, that specifies how this type is implemented.  
  
 `tkTypeDef`  
 [in] The `TypeDef` token referenced in the code file.  
  
 `dwExportedTypeFlags`  
 [in] A bitwise combination of values that specify attributes of the type.  
  
## Remarks  
 To create an `ExportedType` metadata structure, use the [IMetaDataAssemblyEmit::DefineExportedType](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-defineexportedtype-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)
