---
description: "Learn more about: IMetaDataTables::GetRow Method"
title: "IMetaDataTables::GetRow Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetRow"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetRow"
helpviewer_keywords: 
  - "IMetaDataTables::GetRow method [.NET Framework metadata]"
  - "GetRow method [.NET Framework metadata]"
ms.assetid: a7408d51-0bce-45a2-b58f-da4660bbc039
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetRow Method

Gets the row at the specified row index, in the table at the specified table index.  
  
## Syntax  
  
```cpp  
HRESULT GetRow (
    [in]  ULONG   ixTbl,  
    [in]  ULONG   rid,  
    [out] void    **ppRow  
);  
```  
  
## Parameters  

 `ixTbl`  
 [in] The index of the table from which the row will be retrieved.  
  
 `rid`  
 [in] The index of the row to get.  
  
 `ppRow`  
 [out] A pointer to a pointer to the row.  
  
## Remarks  

  We do not recommend the use of this method, because it does not return consistent results. For information about the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](../../../standard/components.md#applicable-standards) and [Standard ECMA-335 - Common Language Infrastructure (CLI)](http://www.ecma-international.org/publications/standards/Ecma-335.htm).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions**  [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
