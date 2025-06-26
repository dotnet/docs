---
description: "Learn more about: IMetaDataEmit::DeleteToken Method"
title: "IMetaDataEmit::DeleteToken Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DeleteToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DeleteToken"
helpviewer_keywords: 
  - "DeleteToken method [.NET Framework metadata]"
  - "IMetaDataEmit::DeleteToken method [.NET Framework metadata]"
ms.assetid: a4926d0a-261b-46b1-9994-82633661a64b
topic_type: 
  - "apiref"
---
# IMetaDataEmit::DeleteToken Method

Deletes the specified token from the current metadata scope.  
  
## Syntax  
  
```cpp  
HRESULT DeleteToken (
    [in]  mdToken     tkObj
);  
```  
  
## Parameters  

 `tkObj`  
 [in] The token to be deleted.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
