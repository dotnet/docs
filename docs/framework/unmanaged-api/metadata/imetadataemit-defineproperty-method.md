---
title: "IMetaDataEmit::DefineProperty Method"
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
  - "IMetaDataEmit.DefineProperty"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineProperty"
helpviewer_keywords: 
  - "IMetaDataEmit::DefineProperty method [.NET Framework metadata]"
  - "DefineProperty method [.NET Framework metadata]"
ms.assetid: 5c4c1dc2-d40d-4173-bbe6-7058fb21c98f
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefineProperty Method
Creates a property definition for the specified type, with the specified `get` and `set` method accessors, and gets a token to that property definition.  
  
## Syntax  
  
```  
HRESULT DefineProperty (   
    [in]  mdTypeDef          td,   
    [in]  LPCWSTR            szProperty,   
    [in]  DWORD              dwPropFlags,   
    [in]  PCCOR_SIGNATURE    pvSig,   
    [in]  ULONG              cbSig,   
    [in]  DWORD              dwCPlusTypeFlag,   
    [in]  void const         *pValue,   
    [in]  ULONG              cchValue,   
    [in]  mdMethodDef        mdSetter,   
    [in]  mdMethodDef        mdGetter,   
    [in]  mdMethodDef        rmdOtherMethods[],   
    [out] mdProperty         *pmdProp   
);  
```  
  
#### Parameters  
 `td`  
 [in] The token for class or interface on which the property is being defined.  
  
 `szProperty`  
 [in] The name of the property.  
  
 `dwPropFlags`  
 [in] The property flags.  
  
 `pvSig`  
 [in] The property signature.  
  
 `cbSig`  
 [in] The count of bytes in `pvSig`.  
  
 `dwCPlusTypeFlag`  
 [in] The type of the property's default value.  
  
 `pValue`  
 [in] The default value for the property.  
  
 `cchValue`  
 [in] The count of (Unicode) characters in `pValue`.  
  
 `mdSetter`  
 [in] The method that sets the property value.  
  
 `mdGetter`  
 [in] The method that gets the property value.  
  
 `rmdOtherMethods[]`  
 [in] An array of other methods associated with the property. Terminate the array with an `mdTokenNil`.  
  
 `pmdProp`  
 [out] The `mdProperty` token assigned.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
