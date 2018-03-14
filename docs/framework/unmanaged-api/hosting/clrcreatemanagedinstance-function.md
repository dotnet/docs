---
title: "ClrCreateManagedInstance Function"
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
  - "ClrCreateManagedInstance"
api_location: 
  - "mscoree.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "ClrCreateManagedInstance"
helpviewer_keywords: 
  - "ClrCreateManagedInstance function [.NET Framework hosting]"
ms.assetid: 58ba42c0-4857-43bf-a039-73a4dc6544c2
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ClrCreateManagedInstance Function
Creates an instance of the specified managed type.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)]. Use COM activation to create an instance of the managed type, or use hosting (see [CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5](../../../../docs/framework/unmanaged-api/hosting/clr-hosting-interfaces-added-in-the-net-framework-4-and-4-5.md)).  
  
## Syntax  
  
```  
STDAPI ClrCreateManagedInstance (  
    [in]  LPCWSTR  pTypeName,   
    [in]  REFIID   riid,   
    [out] void     **ppObject  
);  
```  
  
#### Parameters  
 `pTypeName`  
 [in] A pointer to the name of the instance type being requested.  
  
 `riid`  
 [in] The `IID` of the instance type being requested.  
  
 `ppObject`  
 [out] A pointer to a pointer to an instance of the managed type that was requested by the caller.  
  
## Remarks  
 The common language runtime should already be loaded into a process. For example, it can be loaded by using a call to the [CorBindToRuntimeEx](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimeex-function.md) function before the `ClrCreateManagedInstance` function is called. If the runtime is not loaded, `ClrCreateManagedInstance` first tries to load v1.0.3705 of the runtime. If that fails, it attempts to load the latest version of the runtime.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
