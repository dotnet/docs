---
description: "Learn more about: IMetaDataTables::GetGuid Method"
title: "IMetaDataTables::GetGuid Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetGuid"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetGuid"
helpviewer_keywords: 
  - "GetGuid method [.NET Framework metadata]"
  - "IMetaDataTables::GetGuid method [.NET Framework metadata]"
ms.assetid: a3546316-e24d-417f-9909-e45d42c9d471
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetGuid Method

Gets a GUID from the row at the specified index.  
  
## Syntax  
  
```cpp  
HRESULT GetGuid (
    [in]  ULONG       ixGuid,  
    [out] const GUID  **ppGUID  
);  
```  
  
## Parameters  

 `ixGuid`  
 [in] The index of the row from which to get the GUID.  
  
 `ppGuid`  
 [out] A pointer to a pointer to the GUID.  
  
## Remarks  

  We do not recommend the use of this method, because it does not return consistent results. For information about the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](../../../standard/components.md#applicable-standards) and [Standard ECMA-335 - Common Language Infrastructure (CLI)](http://www.ecma-international.org/publications/standards/Ecma-335.htm).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
