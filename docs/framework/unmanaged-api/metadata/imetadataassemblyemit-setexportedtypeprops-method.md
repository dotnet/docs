---
description: "Learn more about: IMetaDataAssemblyEmit::SetExportedTypeProps Method"
title: "IMetaDataAssemblyEmit::SetExportedTypeProps Method"
ms.date: "03/30/2017"
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
---
# IMetaDataAssemblyEmit::SetExportedTypeProps Method

Modifies the specified `ExportedType` metadata structure.  
  
## Syntax  
  
```cpp  
HRESULT SetExportedTypeProps (  
    [in] mdExportedType   ct,
    [in] mdToken          tkImplementation,  
    [in] mdTypeDef        tkTypeDef,  
    [in] DWORD            dwExportedTypeFlags  
);  
```  
  
## Parameters  

 `ct`  
 [in] The metadata token that specifies the `ExportedType` metadata structure to be modified.  
  
 `tkImplementation`  
 [in] The token, of type `File`, `AssemblyRef`, or `ExportedType`, that specifies how this type is implemented.  
  
 `tkTypeDef`  
 [in] The `TypeDef` token referenced in the code file.  
  
 `dwExportedTypeFlags`  
 [in] A bitwise combination of values that specify attributes of the type.  
  
## Remarks  

 To create an `ExportedType` metadata structure, use the [IMetaDataAssemblyEmit::DefineExportedType](imetadataassemblyemit-defineexportedtype-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
