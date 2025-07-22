---
description: "Learn more about: COR_FIELD_OFFSET Structure"
title: "COR_FIELD_OFFSET Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_FIELD_OFFSET"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_FIELD_OFFSET"
helpviewer_keywords: 
  - "COR_FIELD_OFFSET structure [.NET Framework metadata]"
ms.assetid: cced5298-277f-4a5a-8ecf-a0050c1096ea
topic_type: 
  - "apiref"
---
# COR_FIELD_OFFSET Structure

Stores the offset, within a class, of the specified field.  
  
## Syntax  
  
```cpp  
typedef struct COR_FIELD_OFFSET {  
    mdFieldDef  ridOfField;  
    ULONG       ulOffset;  
} COR_FIELD_OFFSET;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ridOfField`|An `mdFieldDef` metadata token that represents the field.|  
|`ulOffset`|The field's offset within its class.|  
  
## Remarks  

 [IMetaDataImport::GetClassLayout](imetadataimport-getclasslayout-method.md) and [IMetaDataEmit::SetClassLayout](imetadataemit-setclasslayout-method.md) methods take a parameter of type `COR_FIELD_OFFSET`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h, CorProf.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Structures](metadata-structures.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
