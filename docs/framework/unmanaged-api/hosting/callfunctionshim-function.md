---
title: "CallFunctionShim Function"
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
  - "CallFunctionShim"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CallFunctionShim"
helpviewer_keywords: 
  - "CallfunctionShim function [.NET Framework hosting]"
ms.assetid: 37118465-ddf3-41f0-bf27-335b72777e63
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CallFunctionShim Function
Makes a call to the function that has the specified name and parameters in the specified library.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT CallFunctionShim (  
    [in] LPCWSTR     szDllName,  
    [in] LPCSTR      szFunctionName,  
    [in] LPVOID      lpvArgument1,  
    [in] LPVOID      lpvArgument2,  
    [in] LPCWSTR     szVersion,  
    [in] LPVOID      pvReserved  
);  
```  
  
#### Parameters  
 `szDllName`  
 [in] The name of the library containing the function.  
  
 `szFunctionName`  
 [in] The name of the function.  
  
 `lpvArgument1`  
 [in] The first argument to pass to the function.  
  
 `lpvArgument2`  
 [in] The second argument to pass to the function.  
  
 `szVersion`  
 [in] The version of the library that contains the function.  
  
 `pvReserved`  
 [in] Reserved for future use. Pass zero in this parameter.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
