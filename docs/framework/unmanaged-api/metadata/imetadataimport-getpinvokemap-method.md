---
title: "IMetaDataImport::GetPinvokeMap Method"
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
  - "IMetaDataImport.GetPinvokeMap"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetPinvokeMap"
helpviewer_keywords: 
  - "IMetaDataImport::GetPinvokeMap method [.NET Framework metadata]"
  - "GetPinvokeMap method [.NET Framework metadata]"
ms.assetid: b8685c1e-b80c-4198-8eb3-748d6f48a99e
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetPinvokeMap Method
Gets a ModuleRef token to represent the target assembly of a PInvoke call.  
  
## Syntax  
  
```  
HRESULT GetPinvokeMap (  
   [in]  mdToken       tk,  
   [out] DWORD         *pdwMappingFlags,  
   [out] LPWSTR        szImportName,  
   [in]  ULONG         cchImportName,  
   [out] ULONG         *pchImportName,  
   [out] mdModuleRef   *pmrImportDLL  
);  
```  
  
#### Parameters  
 `tk`  
 [in] A FieldDef or MethodDef token to get the PInvoke mapping metadata for.  
  
 `pdwMappingFlags`  
 [out] A pointer to flags used for mapping. This value is a bitmask from the [CorPinvokeMap](../../../../docs/framework/unmanaged-api/metadata/corpinvokemap-enumeration.md) enumeration.  
  
 `szImportName`  
 [out] The name of the unmanaged target DLL.  
  
 `cchImportName`  
 [in] The size in wide characters of `szImportName`.  
  
 `pchImportName`  
 [out] The number of wide characters returned in `szImportName`.  
  
 `pmrImportDLL`  
 [out] A pointer to a ModuleRef token that represents the unmanaged target object library.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
