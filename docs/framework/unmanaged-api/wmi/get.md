---
title: Get function (Unmanaged API Reference)
description: The Get function retrieves the specified property value.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "Get"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "Get"
helpviewer_keywords: 
  - "Get function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Get function
Retrieves the specified property value if it exists.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```  
HRESULT Get (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LPCWSTR           wszName,
   [in] LONG              lFlags,
   [out] VARIANT*         pVal,
   [out] CIMTYPE*         pvtType,
   [out] LONG*            plFlavor
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`wszName`  
[in] The name of the property.

`lFlags`
[in] Reserved. This parameter must be 0.

`pVal` 
[out] If the function returns successfully, contains the value of the `wszName` property. The `pval` argument is assigned the correct type and value for the qualifier.

`pvtType`
[out] If the function returns successfully, contains a [CIM-type constant](https://msdn.microsoft.com/library/aa386309(v=vs.85).aspx) that indicates the property type. Its value can also be `null`. 

`plFlavor`
[out] If the function returns successfully, receives information about the origin of the property. Its value can be `null`, or one of the following WBEM_FLAVOR_TYPE constants defined in the *WbemCli.h* header file: 

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAVOR_ORIGIN_SYSTEM` | 0x40 | The property is a standard system property. |
| `WBEM_FLAVOR_ORIGIN_PROPAGATED` | 0x20 | For a class: The property is inherited from the parent class. </br> For an instance: The property, while inherited from the parent class, has not been modified by the instance.  |
| `WBEM_FLAVOR_ORIGIN_LOCAL` | 0 | For a class: The property belongs to the derived class. </br> For an instance: The property is modified by the instance; that is, a value was supplied, or a qualifier was added or modified. |

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | One or more parameters are not valid. |
|`WBEM_E_NOT_FOUND` | 0x80041002 | The specified property was not found. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::Get](https://msdn.microsoft.com/library/aa391442(v=vs.85).aspx) method.

The `Get` function can also return system properties.

The `pVal` argument is assigned the correct type and value for the qualifier and the COM [VariantInit](https://msdn.microsoft.com/library/ms221402(v=vs.85).aspx) function

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
