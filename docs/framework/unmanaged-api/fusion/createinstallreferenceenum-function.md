---
title: "CreateInstallReferenceEnum Function"
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
  - "CreateInstallReferenceEnum"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateInstallReference"
helpviewer_keywords: 
  - "CreateInstallReference function [.NET Framework fusion]"
ms.assetid: 80dbbbf8-54fc-4894-b74a-0179d3201083
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateInstallReferenceEnum Function
Gets a pointer to an [IInstallReferenceEnum](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceenum-interface.md) instance that represents a list of an application's references to the specified assembly.  
  
## Syntax  
  
```  
HRESULT CreateInstallReferenceEnum (  
    [out] IInstallReferenceEnum **ppRefEnum,  
    [in]  IAssemblyName         *pName,  
    [in]  DWORD                 dwFlags,  
    [in]  LPVOID                pvReserved  
 );  
```  
  
#### Parameters  
 `ppRefEnum`  
 [out] The returned `IInstallReferenceEnum` pointer.  
  
 `pName`  
 [in] The [IAssemblyName](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md) that identifies the assembly for which to enumerate references.  
  
 `dwFlags`  
 [in] Flags that influence the enumerator's behavior.  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Fusion.dll and Mscorwks.dll. Use Fusion.dll instead of Mscorwks.dll to ensure that you target the correct version of the .NET Framework.  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IInstallReferenceEnum Interface](../../../../docs/framework/unmanaged-api/fusion/iinstallreferenceenum-interface.md)  
 [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)
