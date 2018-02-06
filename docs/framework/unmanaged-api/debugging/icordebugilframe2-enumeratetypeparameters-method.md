---
title: "ICorDebugILFrame2::EnumerateTypeParameters Method"
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
  - "ICorDebugILFrame2.EnumerateTypeParameters"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame2::EnumerateTypeParameters"
helpviewer_keywords: 
  - "EnumerateTypeParameters method, ICorDebugILFrame2 interface [.NET Framework debugging]"
  - "ICorDebugILFrame2::EnumerateTypeParameters method [.NET Framework debugging]"
ms.assetid: 722d0d74-e0df-491f-98c4-62d501dfaf6f
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame2::EnumerateTypeParameters Method
Gets an ICorDebugTypeEnum object that contains the <xref:System.Type> parameters in this frame.  
  
## Syntax  
  
```  
HRESULT EnumerateTypeParameters (  
    [out] ICorDebugTypeEnum    **ppTyParEnum  
);  
```  
  
#### Parameters  
 `ppTyParEnum`  
 A pointer to the address of a ICorDebugTypeEnum interface object that allows enumeration of type parameters.  
  
 The list of type parameters include the class type parameters (if any) followed by the method type parameters (if any).  
  
## Remarks  
 Use the [IMetaDataImport2::EnumGenericParams](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-enumgenericparams-method.md) method to determine how many class type parameters and method type parameters this list contains.  
  
 The type parameters are not always available.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
