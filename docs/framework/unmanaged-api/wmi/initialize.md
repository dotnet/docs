---
title: Initialize function (Unmanaged API Reference)
description: The Initialize function performs WMI initialization.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "Initialize"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "Initialize"
helpviewer_keywords: 
  - "Initialize function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Initialize function
Performs WMI initialization.  
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax 
```  
HRESULT Initialize(
   [in] boolean bAllowIManagementObjectQI
); 
```  
## Parameters

`bAllowIManagementObjectQI`   
[in] `true` to indicate that calls to QueryInterface on WMI objects are allowed; `false` otherwise.

## Return value

The function always returns `S_OK` (0).
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.def  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
