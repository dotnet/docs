---
description: "Learn more about: Metadata interfaces (.NET)"
title: "Metadata interfaces (.NET)"
ms.date: 07/22/2025
---
# Metadata interfaces

This section describes the unmanaged metadata interfaces that provide access to the metadata exposed by .NET types, methods, fields, and other APIs. For unmanaged API metadata interfaces that are specific to .NET Framework, see [Metadata interfaces](../../../../framework/unmanaged-api/metadata/metadata-interfaces.md).

## In this section

[IMapToken interface](imaptoken-interface.md)\
Provides mapping capabilities between imported and emitted metadata signatures.

[IMetaDataAssemblyEmit interface](imetadataassemblyemit-interface.md)\
Provides methods that support the self-description model used by the common language runtime (CLR) to resolve and consume resources.

[IMetaDataAssemblyImport interface](imetadataassemblyimport-interface.md)\
Provides methods to access and examine the contents of an assembly manifest.

[IMetaDataDispenser interface](imetadatadispenser-interface.md)\
`IMetaDataDispenser` is obsolete. Use `IMetaDataDispenserEx` instead.

[IMetaDataDispenserEx interface](imetadatadispenserex-interface.md)\
Provides methods that map areas of memory for creating or modifying metadata.

[IMetaDataEmit interface](imetadataemit-interface.md)\
Provides methods to create, modify and store metadata about the assembly in the currently defined scope.

[IMetaDataEmit2 interface](imetadataemit2-interface.md)\
Provides methods for defining and modifying the metadata signatures of methods and constructors with parameters of type <xref:System.Type?displayProperty=nameWithType>.

[IMetaDataError interface](imetadataerror-interface.md)\
Provides a callback mechanism for reporting errors during the resolution of the metadata signature for an assembly.

[IMetaDataFilter interface](imetadatafilter-interface.md)\
Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.

[IMetaDataImport interface](imetadataimport-interface.md)\
Provides methods for importing and manipulating types from other assemblies.

[IMetaDataImport2 interface](imetadataimport2-interface.md)\
Extends `IMetaDataImport` to provide the capability of working with generic types.

[IMetaDataInfo interface](imetadatainfo-interface.md)\
Provides a method that gets information about the mapping of metadata from an on-disk file into memory.

[IMetaDataTables interface](imetadatatables-interface.md)\
Provides methods for the storage and retrieval of metadata information in tables.

[IMetaDataTables2 interface](imetadatatables2-interface.md)\
Extends `IMetaDataTables` to include methods for working with metadata streams.

[IMetaDataValidate interface](imetadatavalidate-interface.md)\
Provides methods to use for validation of metadata signatures.

## See also

- [Metadata interfaces (.NET Framework)](../../../../framework/unmanaged-api/metadata/metadata-interfaces.md)
