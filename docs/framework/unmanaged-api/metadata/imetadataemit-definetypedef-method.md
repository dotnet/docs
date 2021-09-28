---
description: "Learn more about: IMetaDataEmit::DefineTypeDef Method"
title: "IMetaDataEmit::DefineTypeDef Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DefineTypeDef"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineTypeDef"
helpviewer_keywords: 
  - "IMetaDataEmit::DefineTypeDef method [.NET Framework metadata]"
  - "DefineTypeDef method [.NET Framework metadata]"
ms.assetid: dd11c485-be95-4b97-9cd8-68679a4fb432
topic_type: 
  - "apiref"
---
# IMetaDataEmit::DefineTypeDef Method

Creates a type definition for a common language runtime type, and gets a metadata token for that type definition.  
  
## Syntax  
  
```cpp  
HRESULT DefineTypeDef (
    [in]  LPCWSTR     szTypeDef,
    [in]  DWORD       dwTypeDefFlags,
    [in]  mdToken     tkExtends,
    [in]  mdToken     rtkImplements[],
    [out] mdTypeDef   *ptd  
);  
```  
  
## Parameters  

 `szTypeDef`  
 [in] The name of the type in Unicode.  
  
 `dwTypeDefFlags`  
 [in] `TypeDef` attributes. This is a bitmask of `CoreTypeAttr` values.  
  
 `tkExtends`  
 [in] The token of the base class. It must be either an `mdTypeDef` or an `mdTypeRef` token.  
  
 `rtkImplements`  
 [in] An array of tokens specifying the interfaces that this class or interface implements.  
  
 `ptd`  
 [out] The `mdTypeDef` token assigned.  
  
## Remarks  

 A flag in `dwTypeDefFlags` specifies whether the type being created is a common type system reference type (class or interface) or a common type system value type.  
  
 Depending on the parameters supplied, this method, as a side effect, may also create an `mdInterfaceImpl` record for each interface that is inherited or implemented by this type. However, this method does not return any of these `mdInterfaceImpl` tokens. If a client wants to later add or modify an `mdInterfaceImpl` token, it must use the `IMetaDataImport` interface to enumerate them. If you want to use COM semantics of the `[default]` interface, you should supply the default interface as the first element in `rtkImplements`; a custom attribute set on the class will indicate that the class has a default interface (which is always assumed to be the first `mdInterfaceImpl` token declared for the class).  
  
 Each element of the `rtkImplements` array holds an `mdTypeDef` or `mdTypeRef` token. The last element in the array must be `mdTokenNil`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
