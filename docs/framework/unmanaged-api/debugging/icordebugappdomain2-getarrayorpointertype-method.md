---
title: "ICorDebugAppDomain2::GetArrayOrPointerType Method"
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
  - "ICorDebugAppDomain2.GetArrayOrPointerType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain2::GetArrayOrPointerType"
helpviewer_keywords: 
  - "GetArrayOrPointerType method [.NET Framework debugging]"
  - "ICorDebugAppDomain2::GetArrayOrPointerType method [.NET Framework debugging]"
ms.assetid: 97e493f5-3a62-4ec7-b42f-4af57bf71f57
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAppDomain2::GetArrayOrPointerType Method
Gets an array of the specified type, or a pointer or reference to the specified type.  
  
## Syntax  
  
```  
HRESULT GetArrayOrPointerType (  
    [in]  CorElementType    elementType,  
    [in]  ULONG32           nRank,  
    [in]  ICorDebugType     *pTypeArg,  
    [out] ICorDebugType     **ppType  
);  
```  
  
#### Parameters  
 `elementType`  
 [in] A value of the CorElementType enumeration that specifies the underlying native type (an array, pointer, or reference) to be created.  
  
 `nRank`  
 [in] The rank (that is, number of dimensions) of the array. This value must be 0 if `elementType` specifies a pointer or reference type.  
  
 `pTypeArg`  
 [in] A pointer to an ICorDebugType object that represents the type of array, pointer, or reference to be created.  
  
 `ppType`  
 [out] A pointer to the address of an `ICorDebugType` object that represents the constructed array, pointer type, or reference type.  
  
## Remarks  
 The value of *elementType* must be one of the following:  
  
-   ELEMENT_TYPE_PTR  
  
-   ELEMENT_TYPE_BYREF  
  
-   ELEMENT_TYPE_ARRAY or ELEMENT_TYPE_SZARRAY  
  
 If the value of *elementType* is ELEMENT_TYPE_PTR or ELEMENT_TYPE_BYREF, *nRank* must be zero.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
