---
description: "Learn more about: IMetaDataDispenser::OpenScopeOnMemory Method"
title: "IMetaDataDispenser::OpenScopeOnMemory Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataDispenser.OpenScopeOnMemory"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenser::OpenScopeOnMemory"
helpviewer_keywords: 
  - "OpenScopeOnMemory method [.NET Framework metadata]"
  - "IMetaDataDispenser::OpenScopeOnMemory method [.NET Framework metadata]"
ms.assetid: 14218249-bdec-48ae-b5fc-9f57f7ca8501
topic_type: 
  - "apiref"
---
# IMetaDataDispenser::OpenScopeOnMemory Method

Opens an area of memory that contains existing metadata. That is, this method opens a specified area of memory in which the existing data is treated as metadata.  
  
## Syntax  
  
```cpp  
HRESULT OpenScopeOnMemory (  
    [in]  LPCVOID     pData,
    [in]  ULONG       cbData,
    [in]  DWORD       dwOpenFlags,
    [in]  REFIID      riid,
    [out] IUnknown    **ppIUnk  
);  
```  
  
## Parameters  

 `pData`  
 [in] A pointer that specifies the starting address of the memory area.  
  
 `cbData`  
 [in] The size of the memory area, in bytes.  
  
 `dwOpenFlags`  
 [in] A value of the [CorOpenFlags](coropenflags-enumeration.md) enumeration to specify the mode (read, write, and so on) for opening.  
  
 `riid`  
 [in] The IID of the desired metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.  
  
 The value of `riid` must specify one of the "import" or "emit" interfaces. Valid values are IID_IMetaDataEmit, IID_IMetaDataImport, IID_IMetaDataAssemblyEmit, IID_IMetaDataAssemblyImport, IID_IMetaDataEmit2, or IID_IMetaDataImport2.  
  
 `ppIUnk`  
 [out] The pointer to the returned interface.  
  
## Remarks  

 The in-memory copy of the metadata can be queried using methods from one of the "import" interfaces, or added to using methods from the one of the "emit" interfaces.  
  
 The `OpenScopeOnMemory` method is similar to the [IMetaDataDispenser::OpenScope](imetadatadispenser-openscope-method.md) method, except that the metadata of interest already exists in memory, rather than in a file on disk.  
  
 If the target area of memory does not contain common language runtime (CLR) metadata, the `OpenScopeOnMemory` method will fail.  
  
## Requirements  

 **Platform:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
