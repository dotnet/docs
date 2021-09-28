---
description: "Learn more about: IMetaDataDispenser::DefineScope Method"
title: "IMetaDataDispenser::DefineScope Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataDispenser.DefineScope"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenser::DefineScope"
helpviewer_keywords: 
  - "DefineScope method [.NET Framework metadata]"
  - "IMetaDataDispenser::DefineScope method [.NET Framework metadata]"
ms.assetid: af28db02-29af-45ac-aec6-8d6c6123c2ff
topic_type: 
  - "apiref"
---
# IMetaDataDispenser::DefineScope Method

Creates a new area in memory in which you can create new metadata.  
  
## Syntax  
  
```cpp  
HRESULT DefineScope (  
    [in]  REFCLSID    rclsid,  
    [in]  DWORD       dwCreateFlags,  
    [in]  REFIID      riid,
    [out] IUnknown    **ppIUnk  
);  
```  
  
## Parameters  

 `rclsid`  
 [in] The CLSID of the version of metadata structures to be created. This value must be CLSID_CorMetaDataRuntime for the .NET Framework version 2.0.  
  
 `dwCreateFlags`  
 [in] Flags that specify options. This value must be zero for the .NET Framework 2.0.  
  
 `riid`  
 [in] The IID of the desired metadata interface to be returned; the caller will use the interface to create the new metadata.  
  
 The value of `riid` must specify one of the "emit" interfaces. Valid values are IID_IMetaDataEmit, IID_IMetaDataAssemblyEmit, or IID_IMetaDataEmit2.  
  
 `ppIUnk`  
 [out] The pointer to the returned interface.  
  
## Remarks  

 `DefineScope` creates a set of in-memory metadata tables, generates a unique GUID (module version identifier, or MVID) for the metadata, and creates an entry in the module table for the compilation unit being emitted.  
  
 You can attach attributes to the metadata scope as a whole by using the [IMetaDataEmit::SetModuleProps](imetadataemit-setmoduleprops-method.md) or [IMetaDataEmit::DefineCustomAttribute](imetadataemit-definecustomattribute-method.md) method, as appropriate.  
  
## Requirements  

 **Platform:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
