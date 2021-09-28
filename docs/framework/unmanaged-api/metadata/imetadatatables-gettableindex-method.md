---
description: "Learn more about: IMetaDataTables::GetTableIndex Method"
title: "IMetaDataTables::GetTableIndex Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetTableIndex"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetTableIndex"
helpviewer_keywords: 
  - "GetTableIndex method [.NET Framework metadata]"
  - "IMetaDataTables::GetTableIndex method [.NET Framework metadata]"
ms.assetid: c6ec3800-e0d9-4387-afb8-ddc0b818114c
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetTableIndex Method

Gets the index for the table referenced by the specified token.  
  
## Syntax  
  
```cpp  
HRESULT GetTableIndex (  
    [in]  ULONG   token,  
    [out] ULONG   *pixTbl  
);  
```  
  
## Parameters  

 `token`  
 [in] The token that references the table.  
  
 `pixTbl`  
 [out] A pointer to the returned index for the referenced table.  
  
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
