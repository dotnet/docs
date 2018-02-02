---
title: Delete function (Unmanaged API Reference)
description: The Delete function deletes the specified property and all of its qualifiers from a CIM class definition.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "Delete"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "Delete"
helpviewer_keywords: 
  - "Delete function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Delete function
Deletes the specified property and all of its qualifiers from a CIM class definition.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```  
HRESULT Delete (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LPCWSTR           wszName 
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`wszName`  
[in] The name of the property to delete. `wszName` must be a pointer to a valid `LPCWSTR`.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_FAILED` | 0x80041001 | An unspecified error has occurred. |
| `WBEM_E_INVALID_OPERATION` | 0x80041016 | The property cannot be deleted. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | `wszzName` is invalid. |
| `WBEM_E_NOT_FOUND` | 0x80041002 | The specified property does not exist. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | There is not enough memory to complete the operation. |
| `WBEM_E_PROPAGATED_PROPERTY` | 0x8004101c | The property is inherited from a base class. |
| `WBEM_E_SYSTEM_PROPERTY` | | The property is a system property. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
| `WBEM_E_RESET_TO_DEFAULT` | 0x80041030 | The function deleted an override default value for the current class. The default value for this property in the parent class has been reactiviated. | 

## Remarks

This function wraps a call to the [IWbemClassObject::Delete](https://msdn.microsoft.com/library/aa391438(v=vs.85).aspx) method.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
