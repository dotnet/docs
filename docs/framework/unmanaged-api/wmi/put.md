---
title: Put function (Unmanaged API Reference)
description: The Put function assigns a new value to a named property.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "Put"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "Put"
helpviewer_keywords: 
  - "Put function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Put function
Sets a named property to a new value.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```  
HRESULT Put (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LPCWSTR           wszName,
   [in] LONG              lFlags,
   [in] VARIANT*          pVal,
   [in] CIMTYPE           vtType
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`wszName`  
[in] The name of the property. This parameter cannot be `null`.

`lFlags`  
[in] Reserved. This parameter must be 0.

`pVal`   
[in] A pointer to a valid `VARIANT` that becomes the new property value. If `pVal` is `null` or points to a `VARIANT` of type `VT_NULL`, the property is set to `null`. 

`vtType`  
[in] The type of `VARIANT` pointed to by `pVal`. See the [Remarks](#remarks) section for more information.
 

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | One or more parameters are not valid. |
|`WBEM_E_INVALID_PROPERTY_TYPE` | 0x8004102a | The property type is not recognized. This value is returned when creating class instances if the class already exists. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_E_TYPE_MISMATCH` | 0x80041005 | For instances: Indicates that `pVal` points to a `VARIANT` of an incorrect type for the property. <br/> For class definitions: The property already exists in the parent class, and the new COM type is different from the old COM type. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful. |
  
## Remarks

This function wraps a call to the [IWbemClassObject::Put](https://msdn.microsoft.com/library/aa391455(v=vs.85).aspx) method.

This function always overwrites the current property value with a new one. If the [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) points to a class definition, `Put` creates or updates the property value. When [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) points to a CIM instance, `Put` updates the property value only; `Put` cannot create a property value.

The `__CLASS` system property is only writable during class creation, when it may not be left blank. All other system properties are read-only.

A user cannot create properties with names that begin or end with an underscore ("_"). This is reserved for system classes and properties.

If the property set by the `Put` function exists in the parent class, the default value of the property is changed unless the property type does not match the parent class type. If the property does not exist and it is not a type mismatch, the property is ceated.

Use the `vtType` parameter only when creating new properties in a CIM class definition and `pVal` is `null` or points to a `VARIANT` of type `VT_NULL`. In this case, the `vType` parameter specifies the CIM type of the property. In every other case, `vtType` must be 0. `vtType` must also be 0 if the underlying object is an instance (even if `Val` is `null`) because the type of the property is fixed and cannot be changed.   

## Example

For an example, see the [IWbemClassObject::Put](https://msdn.microsoft.com/library/aa391455(v=vs.85).aspx) method.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
