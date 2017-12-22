---
title: Next function (Unmanaged API Reference)
description: The Next function retireves the next property in an enumeration.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "Next"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "Next"
helpviewer_keywords: 
  - "Next function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Next function
Retrieves the next property in an enumeration that begins with a call to [BeginEnumeration](beginenumeration.md).  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT Next (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LONG              lFlags,
   [out] BSTR*            pstrName,
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

`lFlags`  
[in] Reserved. This parameter must be 0.

`pstrName`  
[out] A new `BSTR` that contains the property name. You can set this parameter to `null` if the name is not required.

`pVal`  
[out] A `VARIANT` filled with the value of the property. You can set this parameter to `null` if the value is not required. If the function returns an error code, the `VARIANT` passed to `pVal` is left unmodified. 

`pvtType`  
[out] A pointer to a `CIMTYPE` variable (a `LONG` into which the type of the property is placed). The value of this property can be a `VT_NULL_VARIANT`, in which case it is necessary to determine the actual type of the property. This parameter can also be `null`. 

`plFlavor`  
[out] `null`, or a value that receives information on the origin of the property. See the [Remarks] section for possible values. 

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is invalid. |
| `WBEM_E_UNEXPECTED` | 0x8004101d | There was no call to the [`BeginEnumeration`](beginenumeration.md) function. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to begin a new enumeration. |
| `WBEM_E_TRANSPORT_FAILURE` | 0x80041015 | The remote procedure call betweeen the current process and Windows Management failed. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
| `WBEM_S_NO_MORE_DATA` | 0x40005 | There are no more properties in the enumeration. |
  
## Remarks

This function wraps a call to the [IWbemClassObject::Next](https://msdn.microsoft.com/library/aa391453(v=vs.85).aspx) method.

This method also returns system properties.

If the underlying type of the property is an object path, a date or time, or another special type, then the returned type does not contain enough information. The caller must examine the `CIMTYPE` for the specified property to determine if the property is an object reference, a date or time, or another special type.

If `plFlavor` is not `null`, the `LONG` value receives information about the origin of the property, as follows:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAVOR_ORIGIN_SYSTEM` | 0x40 | The property is a standard system property. |
| `WBEM_FLAVOR_ORIGIN_PROPAGATED` | 0x20 | For a class: The property is inherited from the parent class. </br> For an instance: The property, while inherited from the parent class, has not been modified by the instance.  |
| `WBEM_FLAVOR_ORIGIN_LOCAL` | 0 | For a class: The property belongs to the derived class. </br> For an instance: The property is modified by the instance; that is, a value was supplied, or a qualifier was added or modified. |

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
