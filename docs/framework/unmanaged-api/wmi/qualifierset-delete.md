---
title: QualifierSet_Delete function (Unmanaged API Reference)
description: The QualifierSet_Delete function deletes a qualifier by name.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "QualifierSet_Delete"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "QualifierSet_Delete"
helpviewer_keywords: 
  - "QualifierSet_Delete function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# QualifierSet_Delete function
Deletes a specified qualifier by name.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT QualifierSet_Delete (
   [in] int                  vFunc, 
   [in] IWbemQualifierSet*   ptr, 
   [in] LPCWSTR              wszName
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`   
[in] A pointer to an [IWbemQualifierSet](https://msdn.microsoft.com/library/aa391860(v=vs.85).aspx) instance.

`wszName`   
[in] The name of the qualifier to delete.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | The `wszName` parameter is not valid. |
|`WBEM_E_INVALID_OPERATION` | 0x80041016 | Deleting this qualifier is illegal. |
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified qualifier was not found. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
| `WBEM_S_RESET_TO_DEFAULT` | 0x40002 | The local override was deleted and the original qualifier from the parent object has resumed scope. |

## Remarks

This function wraps a call to the [IWbemQualifierSet::Delete](https://msdn.microsoft.com/library/aa391864(v=vs.85).aspx) method.

Due to qualifier propagation rules, a particular qualifier may have been inherited from another object and merely overridden in the current class or instance. In this case, the `QualifierSet_Delete` method resets the qualifier to its original inherited value. The function in this case returns the status code `WBEM_S_RESET_TO_DEFAULT`.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
