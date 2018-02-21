---
title: "IMetaDataTables Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "IMetaDataTables"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables"
helpviewer_keywords: 
  - "IMetaDataTables interface [.NET Framework metadata]"
ms.assetid: 31272cce-506a-4f18-bcbf-01ee45e36356
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataTables Interface
Provides methods for the storage and retrieval of metadata information in tables.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetBlob Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getblob-method.md)|Gets a pointer to the binary large object (BLOB) at the specified column index.|  
|[GetBlobHeapSize Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getblobheapsize-method.md)|Gets the size, in bytes, of the BLOB heap.|  
|[GetCodedTokenInfo Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getcodedtokeninfo-method.md)|Gets a pointer to an array of tokens associated with the specified row index.|  
|[GetColumn Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getcolumn-method.md)|Gets a pointer to the values contained in the column at the specified column index, in the table at the specified table index.|  
|[GetColumnInfo Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getcolumninfo-method.md)|Gets data about the specified column in the specified table.|  
|[GetGuid Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getguid-method.md)|Gets a GUID from the row at the specified index.|  
|[GetGuidHeapSize Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getguidheapsize-method.md)|Gets the size, in bytes, of the GUID heap.|  
|[GetNextBlob Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getnextblob-method.md)|Gets the index of the next BLOB in the table.|  
|[GetNextGuid Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getnextguid-method.md)|Gets the index of the next GUID value in the current table column.|  
|[GetNextString Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getnextstring-method.md)|Gets the index of the next string in the current table column.|  
|[GetNextUserString Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getnextuserstring-method.md)|Gets the index of the row that contains the next hard-coded string in the current table column.|  
|[GetNumTables Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getnumtables-method.md)|Gets the number of tables in the scope of the current `IMetaDataTables` instance.|  
|[GetRow Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getrow-method.md)|Gets the row at the specified row index, in the table at the specified table index.|  
|[GetString Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getstring-method.md)|Gets the string at the specified index from the table column in the current reference scope.|  
|[GetStringHeapSize Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getstringheapsize-method.md)|Gets the size, in bytes, of the string heap.|  
|[GetTableIndex Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-gettableindex-method.md)|Gets the index for the table referenced by the specified token.|  
|[GetTableInfo Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-gettableinfo-method.md)|Gets the name, row size, number of rows, number of columns, and key column index of the table at the specified table index.|  
|[GetUserString Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getuserstring-method.md)|Gets the hard-coded string at the specified index in the string column in the current scope.|  
|[GetUserStringHeapSize Method](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-getuserstringheapsize-method.md)|Gets the size, in bytes, of the user string heap.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Interfaces](../../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md)  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
