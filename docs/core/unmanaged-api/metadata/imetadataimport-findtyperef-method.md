---
description: "Learn more about: IMetaDataImport::FindTypeRef Method"
title: "IMetaDataImport::FindTypeRef Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.FindTypeRef"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::FindTypeRef"
helpviewer_keywords: 
  - "IMetaDataImport::FindTypeRef method [.NET Framework metadata]"
  - "FindTypeRef method [.NET Framework metadata]"
ms.assetid: 1b2bbf3f-943e-412e-b66c-e802431b055c
topic_type: 
  - "apiref"
---
# IMetaDataImport::FindTypeRef Method

Gets a pointer to the TypeRef token for the <xref:System.Type> reference that is in the specified scope and that has the specified name.  
  
## Syntax  
  
```cpp  
HRESULT FindTypeRef (  
   [in] mdToken        tkResolutionScope,  
   [in]  LPCWSTR       szName,  
   [out] mdTypeRef     *ptr  
);  
```  
  
## Parameters  

 `tkResolutionScope`  
 [in] A ModuleRef, AssemblyRef, or TypeRef token that specifies the module, assembly, or type, respectively, in which the type reference is defined.  
  
 `szName`  
 [in] The name of the type reference to search for.  
  
 `ptr`  
 [out] A pointer to the matching TypeRef token.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
