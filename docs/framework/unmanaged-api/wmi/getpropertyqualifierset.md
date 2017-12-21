---
title: GetPropertyQualifierSet function (Unmanaged API Reference)
description: The GetPropertyQualifierSet function retrieves the qualifier set for a property.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "GetPropertyQualifierSet"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetPropertyQualifierSet"
helpviewer_keywords: 
  - "GetPropertyQualifierSet function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetPropertyQualifierSet function
Retrieves the qualifier set for a particular property.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```  
HRESULT GetPropertyQualifierSet (
   [in] int                 vFunc, 
   [in] IWbemClassObject*   ptr, 
   [in] LPCWSTR             wszProperty,
   [out] IWbemQualifierSet  **ppQualSet
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`wszMethod`  
[in] The property  name. `wszProperty` must point to a valid `LPCWSTR`. 

`ppQualSet`  
[out] Receives the interface pointer that allows access to the qualifiers of the property. `ppQualSet` cannot be `null`. If an error occurs, a new object is not returned, and the pointer is set to point to `null`. 

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
| `WBEM_E_NOT_FOUND` | 0x80041002 | The specified method does not exist. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is `null`. |
| `WBEM_E_SYSTEM_PROPERTY` | 0x80041030 | The function attempts to get qualifiers of a system property. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::GetPropertyQualifierSet](https://msdn.microsoft.com/library/aa391450(v=vs.85).aspx) method. 

A call to this function is supported only if the current object is a CIM class definition. Method manipulation is not available for [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) ponters that point to CIM instances.

Because each method may have its own qualifiers, the [IWbemQualifierSet pointer](https://msdn.microsoft.com/library/aa391860(v=vs.85).aspx) lets the caller add, edit, or delete these qualifiers.

Because system properties have no qualifiers, the function returns `WBEM_E_SYSTEM_PROPERTY` if you attempt to obtain a [IWbemQualifierSet](https://msdn.microsoft.com/library/aa391860(v=vs.85).aspx) pointer for a system property.

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
