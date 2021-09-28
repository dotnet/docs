---
description: "Learn more about: IMetaDataTables::GetNextGuid Method"
title: "IMetaDataTables::GetNextGuid Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetNextGuid"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetNextGuid"
helpviewer_keywords: 
  - "GetNextGuid method [.NET Framework metadata]"
  - "IMetaDataTables::GetNextGuid method [.NET Framework metadata]"
ms.assetid: 68f6ea4d-9112-4d6b-93d9-e34f1e2f2496
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetNextGuid Method

Gets the index of the next GUID value in the current table column.  
  
## Syntax  
  
```cpp  
HRESULT GetNextGuid (  
    [in]  ULONG   ixGuid,  
    [out] ULONG   *pNext  
);  
```  
  
## Parameters  

 `ixGuid`  
 [in] The index value from a GUID table column.  
  
 `pNext`  
 [out] A pointer to the index of the next GUID value.  
  
## Remarks  

  We do not recommend the use of this method, because it does not return consistent results. For information about the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](../../../standard/components.md#applicable-standards) and [Standard ECMA-335 - Common Language Infrastructure (CLI)](http://www.ecma-international.org/publications/standards/Ecma-335.htm).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
