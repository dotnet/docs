---
description: "Learn more about: IMetaDataAssemblyImport Interface"
title: "IMetaDataAssemblyImport Interface"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataAssemblyImport"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataAssemblyImport"
helpviewer_keywords: 
  - "IMetaDataAssemblyImport interface [.NET Framework metadata]"
ms.assetid: 29c6fba5-4cea-417d-b484-7ed22ebff1c9
topic_type: 
  - "apiref"
---
# IMetaDataAssemblyImport Interface

Provides methods to access and examine the contents of an assembly manifest.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CloseEnum Method](imetadataassemblyimport-closeenum-method.md)|Releases the handle to the specified enumerator.|  
|[EnumAssemblyRefs Method](imetadataassemblyimport-enumassemblyrefs-method.md)|Gets an interface pointer to an enumerator that contains the `mdAssemblyRef` tokens of the assemblies referenced by the assembly in the current metadata scope.|  
|[EnumExportedTypes Method](imetadataassemblyimport-enumexportedtypes-method.md)|Gets an interface pointer to an enumerator that contains the `mdExportedType` tokens of the COM types referenced by the assembly in the current metadata scope.|  
|[EnumFiles Method](imetadataassemblyimport-enumfiles-method.md)|Gets an interface pointer to an enumerator that contains the `mdFile` tokens of the files referenced by the assembly in the current metadata scope.|  
|[EnumManifestResources Method](imetadataassemblyimport-enummanifestresources-method.md)|Gets an interface pointer to an enumerator that contains the `mdManifestResource` tokens of the resources referenced by the assembly in the current metadata scope.|  
|[FindAssembliesByName Method](imetadataassemblyimport-findassembliesbyname-method.md)|Gets an array of `IMetaDataAssemblyImport` interface pointers for the assemblies with the specified name.|  
|[FindExportedTypeByName Method](imetadataassemblyimport-findexportedtypebyname-method.md)|Gets an `mdExportedType` token for the COM type with the specified name.|  
|[FindManifestResourceByName Method](imetadataassemblyimport-findmanifestresourcebyname-method.md)|Gets an `mdManifestResource` token for the resource with the specified name.|  
|[GetAssemblyFromScope Method](imetadataassemblyimport-getassemblyfromscope-method.md)|Gets the token for the assembly in the current metadata scope.|  
|[GetAssemblyProps Method](imetadataassemblyimport-getassemblyprops-method.md)|Gets the property settings of the specified assembly.|  
|[GetAssemblyRefProps Method](imetadataassemblyimport-getassemblyrefprops-method.md)|Gets the property settings of the specified `mdAssemblyRef` token.|  
|[GetExportedTypeProps Method](imetadataassemblyimport-getexportedtypeprops-method.md)|Gets the property settings of the specified COM type.|  
|[GetFileProps Method](imetadataassemblyimport-getfileprops-method.md)|Gets the property settings of the specified file.|  
|[GetManifestResourceProps Method](imetadataassemblyimport-getmanifestresourceprops-method.md)|Gets the property settings of the specified manifest resource.|  
  
## Requirements  

 **Platform:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Interfaces](metadata-interfaces.md)
- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
