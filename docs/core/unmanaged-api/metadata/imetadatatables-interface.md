---
description: "Learn more about: IMetaDataTables Interface"
title: "IMetaDataTables Interface"
ms.date: "03/30/2017"
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
topic_type:
  - "apiref"
---
# IMetaDataTables Interface

Provides methods for the storage and retrieval of metadata information in tables.

## Methods

|Method|Description|
|------------|-----------------|
|[GetBlob Method](imetadatatables-getblob-method.md)|Gets a pointer to the binary large object (BLOB) at the specified column index.|
|[GetBlobHeapSize Method](imetadatatables-getblobheapsize-method.md)|Gets the size, in bytes, of the BLOB heap.|
|[GetCodedTokenInfo Method](imetadatatables-getcodedtokeninfo-method.md)|Gets a pointer to an array of tokens associated with the specified row index.|
|[GetColumn Method](imetadatatables-getcolumn-method.md)|Gets a pointer to the values contained in the column at the specified column index, in the table at the specified table index.|
|[GetColumnInfo Method](imetadatatables-getcolumninfo-method.md)|Gets data about the specified column in the specified table.|
|[GetGuid Method](imetadatatables-getguid-method.md)|Gets a GUID from the row at the specified index.|
|[GetGuidHeapSize Method](imetadatatables-getguidheapsize-method.md)|Gets the size, in bytes, of the GUID heap.|
|[GetNextBlob Method](imetadatatables-getnextblob-method.md)|Gets the index of the next BLOB in the table.|
|[GetNextGuid Method](imetadatatables-getnextguid-method.md)|Gets the index of the next GUID value in the current table column.|
|[GetNextString Method](imetadatatables-getnextstring-method.md)|Gets the index of the next string in the current table column.|
|[GetNextUserString Method](imetadatatables-getnextuserstring-method.md)|Gets the index of the row that contains the next hard-coded string in the current table column.|
|[GetNumTables Method](imetadatatables-getnumtables-method.md)|Gets the number of tables in the scope of the current `IMetaDataTables` instance.|
|[GetRow Method](imetadatatables-getrow-method.md)|Gets the row at the specified row index, in the table at the specified table index.|
|[GetString Method](imetadatatables-getstring-method.md)|Gets the string at the specified index from the table column in the current reference scope.|
|[GetStringHeapSize Method](imetadatatables-getstringheapsize-method.md)|Gets the size, in bytes, of the string heap.|
|[GetTableIndex Method](imetadatatables-gettableindex-method.md)|Gets the index for the table referenced by the specified token.|
|[GetTableInfo Method](imetadatatables-gettableinfo-method.md)|Gets the name, row size, number of rows, number of columns, and key column index of the table at the specified table index.|
|[GetUserString Method](imetadatatables-getuserstring-method.md)|Gets the hard-coded string at the specified index in the string column in the current scope.|
|[GetUserStringHeapSize Method](imetadatatables-getuserstringheapsize-method.md)|Gets the size, in bytes, of the user string heap.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Interfaces](metadata-interfaces.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
