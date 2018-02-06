---
title: "IMetaDataDispenserEx::OpenScopeOnITypeInfo Method"
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
  - "IMetaDataDispenserEx.OpenScopeOnITypeInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataDispenserEx::OpenScopeOnITypeInfo"
helpviewer_keywords: 
  - "OpenScopeOnITypeInfo method [.NET Framework metadata]"
  - "IMetaDataDispenserEx::OpenScopeOnITypeInfo method [.NET Framework metadata]"
ms.assetid: 3480bbdb-c442-44a0-b7c6-333354503c52
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataDispenserEx::OpenScopeOnITypeInfo Method
This method is not implemented. If called, it returns E_NOTIMPL.  
  
## Syntax  
  
```  
HRESULT OpenScopeOnITypeInfo (  
    [in]  ITypeInfo   *pITI,  
    [in]  DWORD       dwOpenFlags,  
    [in]  REFIID      riid,  
    [out] IUnknown    **ppIUnk  
);  
```  
  
#### Parameters  
 `pITI`  
 [in] Pointer to an [ITypeInfo](http://msdn.microsoft.com/library/f3356463-3373-4279-bae1-953378aa2680) interface that provides the type information on which to open the scope.  
  
 `dwOpenFlags`  
 [in] The open mode flags.  
  
 `riid`  
 [in] The desired interface.  
  
 `ppIUnk`  
 [out] Pointer to a pointer to the returned interface.  
  
## Requirements  
 **Platform:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataDispenserEx Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenserex-interface.md)  
 [IMetaDataDispenser Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-interface.md)
