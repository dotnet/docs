---
title: "ClrCreateManagedInstance Function"
ms.date: "03/30/2017"
api_name: 
  - "ClrCreateManagedInstance"
api_location: 
  - "mscoree.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
  - "mscorsvr.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "ClrCreateManagedInstance"
helpviewer_keywords: 
  - "ClrCreateManagedInstance function [.NET Framework hosting]"
ms.assetid: 58ba42c0-4857-43bf-a039-73a4dc6544c2
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ClrCreateManagedInstance Function
Creates an instance of the specified managed type.  
  
 This function has been deprecated in the .NET Framework 4. Use COM activation to create an instance of the managed type, or use hosting (see [CLR Hosting Interfaces Added in the .NET Framework 4 and 4.5](../../../../docs/framework/unmanaged-api/hosting/clr-hosting-interfaces-added-in-the-net-framework-4-and-4-5.md)).  
  
## Syntax  
  
```cpp  
STDAPI ClrCreateManagedInstance (  
    [in]  LPCWSTR  pTypeName,   
    [in]  REFIID   riid,   
    [out] void     **ppObject  
);  
```  
  
## Parameters  
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
  
## See also

- [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
- [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
