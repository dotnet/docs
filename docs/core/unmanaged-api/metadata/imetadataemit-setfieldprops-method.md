---
description: "Learn more about: IMetaDataEmit::SetFieldProps Method"
title: "IMetaDataEmit::SetFieldProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetFieldProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetFieldProps"
helpviewer_keywords: 
  - "IMetaDataEmit::SetFieldProps method [.NET Framework metadata]"
  - "SetFieldProps method [.NET Framework metadata]"
ms.assetid: 47132dda-fa92-4bd1-ae4b-24cd9a60665a
topic_type: 
  - "apiref"
---
# IMetaDataEmit::SetFieldProps Method

Sets or updates the default value for the field referenced by the specified field token.  
  
## Syntax  
  
```cpp  
HRESULT SetFieldProps (  
    [in]  mdFieldDef  fd,
    [in]  DWORD       dwFieldFlags,
    [in]  DWORD       dwCPlusTypeFlag,
    [in]  void const  *pValue,
    [in]  ULONG       cchValue
);  
```  
  
## Parameters  

 `fd`  
 [in] The token for the target field.  
  
 `dwFieldFlags`  
 [in] Field attributes. This is a bitmask of `CorFieldAttr` values.  
  
 `dwCPlusTypeFlag`  
 [in] The `ELEMENT_TYPE_`*\** for the constant value. This is a `CorElementType` value. If a constant is not being defined, set this value to `ELEMENT_TYPE_END`.  
  
 `pValue`  
 [in] The constant value for the field.  
  
 `cchValue`  
 [in] The size, in Unicode characters, of `pValue`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
