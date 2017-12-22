---
title: ResetSecurity function (Unmanaged API Reference)
description: The ResetSecurity function assigns an impersonation token to the current thread.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "ResetSecurity"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "ResetSecurity"
helpviewer_keywords: 
  - "ResetSecurity function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ResetSecurity function
Assigns the supplied impersonation token to the current thread.   
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT ResetSecurity (
   [in] HANDLE token
); 
```  

## Parameters

`token`  
[in] The impersonation token to associate with the current thread. Its value can be `null`. 

## Return value

If the function succeeds, the return value is `S_OK` (0).

If the function fails, the return value is a non-zero error code. To get extended error information, call the [GetErrorInfo](geterrorinfo.md) function.
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
