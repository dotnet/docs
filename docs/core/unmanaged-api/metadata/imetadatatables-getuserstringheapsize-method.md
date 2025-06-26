---
description: "Learn more about: IMetaDataTables::GetUserStringHeapSize Method"
title: "IMetaDataTables::GetUserStringHeapSize Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetUserStringHeapSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetUserStringHeapSize"
helpviewer_keywords: 
  - "IMetaDataTables::GetUserStringHeapSize method [.NET Framework metadata]"
  - "GetUserStringHeapSize method [.NET Framework metadata]"
ms.assetid: cba9e4d6-9461-4420-9614-96ff7039ec9c
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetUserStringHeapSize Method

Gets the size, in bytes, of the user string heap.  
  
## Syntax  
  
```cpp  
HRESULT GetUserStringHeapSize (  
    [out] ULONG   *pcbBlobs  
);  
```  
  
## Parameters  

 `pcbBlobs`  
 [out] A pointer to the size, in bytes, of the user string heap.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
