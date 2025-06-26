---
description: "Learn more about: IMetaDataEmit::DefineModuleRef Method"
title: "IMetaDataEmit::DefineModuleRef Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DefineModuleRef"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineModuleRef"
helpviewer_keywords: 
  - "DefineModuleRef method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineModuleRef method [.NET Framework metadata]"
ms.assetid: f2833594-d90b-4a71-9a53-34b12470c64a
topic_type: 
  - "apiref"
---
# IMetaDataEmit::DefineModuleRef Method

Creates the metadata signature for a module with the specified name.  
  
## Syntax  
  
```cpp  
HRESULT DefineModuleRef (
    [in]  LPCWSTR           szName,
    [out] mdModuleRef       *pmur
);  
```  
  
## Parameters  

 `szName`  
 [in] The name of the other metadata file, typically a DLL. This is the file name only. Do not use a full path name.  
  
 `pmur`  
 [out] The assigned `mdModuleRef` token.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
