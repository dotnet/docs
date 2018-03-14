---
title: "IMetaDataValidate::ValidatorInit Method"
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
  - "IMetaDataValidate.ValidatorInit"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataValidate::ValidatorInit"
helpviewer_keywords: 
  - "IMetaDataValidate::ValidatorInit method [.NET Framework metadata]"
  - "ValidatorInit method [.NET Framework metadata]"
ms.assetid: 6bafd75a-e2d0-4aea-aed1-074374d5dff6
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataValidate::ValidatorInit Method
Sets a flag that specifies the type of the module in the current metadata scope, and registers the specified callback method for validation errors.  
  
## Syntax  
  
```  
HRESULT ValidatorInit (  
   [in] DWORD       dwModuleType,  
   [in] IUnknown    *pUnk  
);  
```  
  
#### Parameters  
 `dwModule`  
 [in] A value of the [CorValidatorModuleType](../../../../docs/framework/unmanaged-api/metadata/corvalidatormoduletype-enumeration.md) enumeration that specifies the type of the module in the current metadata scope.  
  
 `pUnk`  
 [in] A pointer to an <<!--zzxref:IUnknown --> `IUnknown`> instance that serves as a function callback for validation errors.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataValidate Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatavalidate-interface.md)
