---
title: "IMetaDataAssemblyEmit Interface"
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
  - "IMetaDataAssemblyEmit"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyEmit"
helpviewer_keywords: 
  - "IMetaDataAssemblyEmit interface [.NET Framework metadata]"
ms.assetid: 34fb03cc-2285-4a45-ac48-ad993b7a921a
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataAssemblyEmit Interface
Provides methods that support the self-description model used by the common language runtime to resolve and consume resources.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DefineAssembly Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-defineassembly-method.md)|Creates an assembly data structure containing metadata for the specified assembly, and returns the associated metadata token.|  
|[DefineAssemblyRef Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-defineassemblyref-method.md)|Creates an `AssemblyRef` structure containing metadata for the assembly that this assembly references, and returns the associated metadata token.|  
|[DefineExportedType Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-defineexportedtype-method.md)|Creates an `ExportedType` structure containing metadata for the specified exported type, and returns the associated metadata token.|  
|[DefineFile Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-definefile-method.md)|Creates a `File` metadata structure containing metadata for assembly referenced by this assembly, and returns the associated metadata token.|  
|[DefineManifestResource Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-definemanifestresource-method.md)|Creates a `ManifestResource` structure containing metadata for the specified manifest resource, and returns the associated metadata token.|  
|[SetAssemblyProps Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-setassemblyprops-method.md)|Modifies the specified `Assembly` metadata structure.|  
|[SetAssemblyRefProps Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-setassemblyrefprops-method.md)|Modifies the specified `AssemblyRef` metadata structure.|  
|[SetExportedTypeProps Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-setexportedtypeprops-method.md)|Modifies the specified `ExportedType` metadata structure.|  
|[SetFileProps Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-setfileprops-method.md)|Modifies the specified `File` metadata structure.|  
|[SetManifestResourceProps Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-setmanifestresourceprops-method.md)|Modifies the specified `ManifestResource` metadata structure.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Interfaces](../../../../docs/framework/unmanaged-api/metadata/metadata-interfaces.md)  
 [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md)
