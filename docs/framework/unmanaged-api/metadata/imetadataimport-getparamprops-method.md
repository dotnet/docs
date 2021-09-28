---
description: "Learn more about: IMetaDataImport::GetParamProps Method"
title: "IMetaDataImport::GetParamProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetParamProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetParamProps"
helpviewer_keywords: 
  - "IMetaDataImport::GetParamProps method [.NET Framework metadata]"
  - "GetParamProps method [.NET Framework metadata]"
ms.assetid: 4d5e5f00-bcab-4f41-b191-176511a186a7
topic_type: 
  - "apiref"
---
# IMetaDataImport::GetParamProps Method

Gets metadata values for the parameter referenced by the specified ParamDef token.  
  
## Syntax  
  
```cpp  
HRESULT GetParamProps (  
   [in]  mdParamDef      tk,  
   [out] mdMethodDef     *pmd,  
   [out] ULONG           *pulSequence,  
   [out] LPWSTR          szName,  
   [in]  ULONG           cchName,  
   [out] ULONG           *pchName,  
   [out] DWORD           *pdwAttr,  
   [out] DWORD           *pdwCPlusTypeFlag,  
   [out] UVCP_CONSTANT   *ppValue,  
   [out] ULONG           *pcchValue  
);  
```  
  
## Parameters  

 `tk`  
 [in] A ParamDef token that represents the parameter to return metadata for.  
  
 `pmd`  
 [out] A pointer to a MethodDef token representing the method that takes the parameter.  
  
 `pulSequence`  
 [out] The ordinal position of the parameter in the method argument list.  
  
 `szName`  
 [out] A buffer to hold the name of the parameter.  
  
 `cchName`  
 [in] The requested size in wide characters of `szName`.  
  
 `pchName`  
 [out] The returned size in wide characters of `szName`.  
  
 `pdwAttr`  
 [out] A pointer to any attribute flags associated with the parameter. This is a bitmask of `CorParamAttr` values.  
  
 `pdwCPlusTypeFlag`  
 [out] A pointer to a flag specifying that the parameter is a <xref:System.ValueType>.  
  
 `ppValue`  
 [out] A pointer to a constant string returned by the parameter.  
  
 `pcchValue`  
 [out] The size of `ppValue` in wide characters, or zero if `ppValue` does not hold a string.  
  
## Remarks

The sequence values in `pulSequence` begin with 1 for parameters. A return value has a sequence number of 0.

## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
