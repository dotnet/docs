---
title: PutMethod function (Unmanaged API Reference)
description: The PutMethod function creates a method.
ms.date: "11/06/2017"
api_name: 
  - "PutMethod"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "PutMethod"
helpviewer_keywords: 
  - "PutMethod function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
---
# PutMethod function
Creates a method.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```cpp  
HRESULT PutMethod (
   [in] int                vFunc, 
   [in] IWbemClassObject*  ptr, 
   [in] LPCWSTR            wszName,
   [in] LONG               lFlags,
   [in] IWbemClassObject*  pInSignature,
   [in] IWbemClassObject*  pOutSignature
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`wszName`  
[in] The name of the method to create. 

`lFlags`  
[in] Reserved. This parameter must be 0.

`pSignatureIn`  
[in] A pointer to a copy of the [__Parameters system class](/windows/desktop/WmiSdk/--parameters) that contains the `in` parameters for the method. This parameter is ignored if set to `null`.  

`pSignatureOut`  
[in]  A pointer to a copy of the [__Parameters system class](/windows/desktop/WmiSdk/--parameters) that contains the `out` parameters for the method. This parameter is ignored if set to `null`.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | One or more parameters are not valid. |
| `WBEM_E_INVALID_DUPLICATE_PARAMETER` | 0x80041043 | The `[in, out]` method parameter specified in both the *pInSignature* and *pOutSignature* objects have different qualifiers.
| `WBEM_E_MISSING_PARAMETER_ID` | 0x80041036 | A method parameter is missing the specification of the **ID** qualifier. |
| `WBEM_E_NONCONSECUTIVE_PARAMETER_IDS` | 0x80041038 | The ID series that is assigned to the method parameters is not consecutive or does not start at 0. |
| `WBEM_E_PARAMETER_ID_ON_RETVAL` | 0x80041039 | The return value for a method has an **ID** qualifier. |
| `WBEM_E_PROPAGATED_METHOD` | 0x80041034 | An attempt was made to reuse an existing method name from a parent class, and the signatures did not match. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful. |
  
## Remarks

This function wraps a call to the [IWbemClassObject::PutMethod](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-putmethod) method.

This method call is only supported if `ptr` is a CIM class definition. Method manipulation is not available from [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) pointers that point to CIM instances.

Users cannot create methods with names that begin or end with an underscore. This is reserved for system classes and properties.

For a method, the `in` and `out` parameters are described as properties in [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) objects.

An `[in/out]` parameter can be defined by adding the same property to both objects pointed to by the `pInSignature` and `pOutSignature` parameters. In this case, the properties share the same **ID** qualifier value.

Each property in a [__Parameters](/windows/desktop/WmiSdk/--parameters) class object other than `ReturnValue` must have an **ID** qualifier, a zero-based numeric value that identifies the order in which the parameters appear. No two parameters can have the same **ID** value, and no **ID** value can be skipped. If either condition occurs, the `PutMethod` function returns `WBEM_E_NONCONSECUTIVE_PARAMETER_IDS`.

## Example

For an example, see the [IWbemClassObject::PutMethod](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-putmethod) method.

## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
