---
title: QualifierSet_Get function (Unmanaged API Reference)
description: The QualifierSet_Get function gets a named qualifier.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "QualifierSet_Get"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "QualifierSet_Get"
helpviewer_keywords: 
  - "QualifierSet_Get function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# QualifierSet_Get function
Gets the specified named qualifier.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT QualifierSet_Get (
   [in] int                  vFunc, 
   [in] IWbemQualifierSet*   ptr, 
   [in] LPCWSTR              wszName,
   [in] LONG                 lFlags,
   [out] VARIANT*            pVal,
   [out] LONG*               plFlavor                 
); 
```  

## Parameters

`vFunc`   
[in] This parameter is unused.

`ptr`   
[in] A pointer to an [IWbemQualifierSet](https://msdn.microsoft.com/library/aa391860(v=vs.85).aspx) instance.

`wszName`   
[in] The name of the qualifier whose value is requested.

`lFlags`   
[in] Reserved. This parameter must be 0.

`pVal`   
[out] When successful, the correct type and value for the qualifier. If the function fails, the `VARIANT` pointed to by `pVal` is not modified. If this parameter is `null`, the parameter is ignored.

`plFlavor`   
[out] A pointer to a LONG that receives the qualifier flavor bits for the requested qualifier. If flavor information is not desired, this parameter can be `null`. 

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified qualifier does not exist. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemQualifierSet::Get](https://msdn.microsoft.com/library/aa391867(v=vs.85).aspx) method.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
