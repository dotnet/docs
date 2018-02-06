---
title: VerifyClientKey function (Unmanaged API Reference)
description: The VerifyClientKey function ensures the client key has the correct security.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "VerifyClientKey"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "VerifyClientKey"
helpviewer_keywords: 
  - "VerifyClientKey function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# VerifyClientKey function
Ensures that the client key has the correct security.  
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
LONG VerifyClientKey(); 
```  

## Return value

If the function succeeds, the return value is `ERROR_SUCCESS` (0).

If the function fails, the return value is a non-zero error code defined in *WinError.h*.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.def  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
