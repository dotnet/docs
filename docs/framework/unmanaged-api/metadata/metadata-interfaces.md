---
title: "Metadata Interfaces"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "unmanaged interfaces [.NET Framework], metadata"
  - "metadata interfaces [.NET Framework]"
  - "interfaces (.NET Framework metadata]"
ms.assetid: f5cdac93-a28c-48ef-8a19-5773376e9e7c
caps.latest.revision: 15
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Metadata Interfaces
This section describes the unmanaged interfaces that provide access to the metadata exposed by the .NET Framework types, methods, fields, and so on.  
  
## In This Section  
 [ICeeGen Interface](../../../../docs/framework/unmanaged-api/metadata/iceegen-interface.md)  
 Provides methods for dynamic code compilation.  
  
 [IHostFilter Interface](../../../../docs/framework/unmanaged-api/metadata/ihostfilter-interface.md)  
 Provides a method for the run-time host to mark metadata tokens for processing.  
  
 [IMapToken Interface](../../../../docs/framework/unmanaged-api/metadata/imaptoken-interface.md)  
 Provides mapping capabilities between imported and emitted metadata signatures.  
  
 [IMetaDataAssemblyEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-interface.md)  
 Provides methods that support the self-description model used by the common language runtime (CLR) to resolve and consume resources.  
  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)  
 Provides methods to access and examine the contents of an assembly manifest.  
  
 [IMetaDataConverter Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataconverter-interface.md)  
 Provides methods to map type libraries to their metadata signatures, and to convert from one to the other.  
  
 [IMetaDataDispenser Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-interface.md)  
 `IMetaDataDispenser` is obsolete. Use `IMetaDataDispenserEx` instead.  
  
 [IMetaDataDispenserEx Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenserex-interface.md)  
 Provides methods that map areas of memory for creating or modifying metadata.  
  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 Provides methods to create, modify and store metadata about the assembly in the currently defined scope.  
  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)  
 Provides methods for defining and modifying the metadata signatures of methods and constructors with parameters of type <xref:System.Type?displayProperty=nameWithType>.  
  
 [IMetaDataError Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataerror-interface.md)  
 Provides a callback mechanism for reporting errors during the resolution of the metadata signature for an assembly.  
  
 [IMetaDataFilter Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatafilter-interface.md)  
 Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.  
  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 Provides methods for importing and manipulating types from other assemblies.  
  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)  
 Extends `IMetaDataImport` to provide the capability of working with generic types.  
  
 [IMetaDataInfo Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatainfo-interface.md)  
 Provides a method that gets information about the mapping of metadata from an on-disk file into memory.  
  
 [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)  
 Provides methods for the storage and retrieval of metadata information in tables.  
  
 [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)  
 Extends `IMetaDataTables` to include methods for working with metadata streams.  
  
 [IMetaDataValidate Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatavalidate-interface.md)  
 Provides methods to use for validation of metadata signatures.  
  
## Related Sections  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)  
  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)  
  
 [Metadata Structures](../../../../docs/framework/unmanaged-api/metadata/metadata-structures.md)  
  
 [Metadata Unions](../../../../docs/framework/unmanaged-api/metadata/metadata-unions.md)
