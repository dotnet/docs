---
title: PutInstanceWmi function (Unmanaged API Reference)
description: The PutInstanceWmi function creates or updates an instance of an existing class.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "PutInstanceWmi"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "PutInstanceWmi"
helpviewer_keywords: 
  - "PutInstanceWmi function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# PutInstanceWmi function
Creates or updates an instance of an existing class. The instance is written to the WMI repository. 

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT PutInstanceWmi (
   [in] IWbemClassObject*    pInst,
   [in] long                 lFlags,
   [in] IWbemContext*        pCtx,
   [out] IWbemCallResult**   ppCallResult
); 
```  

## Parameters

`pInst`    
[in] A pointer to the instance to be writen.

`lFlags`   
[in] A combination of flags that affect the behavior of this function. The following values are defined in the *WbemCli.h* header file, or you can define them as constants in your code: 

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_USE_AMENDED_QUALIFIERS` | 0x20000 | If set, WMI does not store any qualifiers with the **Amended** flavor. </br> If not set, it is assumed that this object is not localized, and all qualifiers are storedwith this instance. |
| `WBEM_FLAG_CREATE_OR_UPDATE` | 0 | Create the instance if it does not exist, or overwrite it if it exists already. |
| `WBEM_FLAG_UPDATE_ONLY` | 1 | Update the instance. The instance must exist for the call to be successful. |
| `WBEM_FLAG_CREATE_ONLY` | 2 | Create the instance. The call fails if the instance already exists. |
| `WBEM_FLAG_RETURN_IMMEDIATELY` | 0x10 | The flag causes a semisynchronous call. |

`pCtx`  
[in] Typically, this value is `null`. Otherwise, it is a pointer to an [IWbemContext](https://msdn.microsoft.com/library/aa391465(v=vs.85).aspx) instance that can be used by the provider that is providing the requested classes. 

`ppCallResult`  
[out] If `null`, this parameter is unused. If `lFlags` contains `WBEM_FLAG_RETURN_IMMEDIATELY`, the function returns immediately with `WBEM_S_NO_ERROR`. The `ppCallResult` parameter receives a pointer to a new [IWbemCallResult](https://msdn.microsoft.com/library/aa391425(v=vs.85).aspx) object.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_ACCESS_DENIED` | 0x80041003 | The user does not have permission to update an instance of the specified class. |
| `WBEM_E_FAILED` | 0x80041001 | An unspecified error has occurred. |
| `WBEM_E_INVALID_CLASS` | 0x80041010 | The class supporting this instance is not valid. |
| `WBEM_E_ILLEGAL_NULL` | 0x80041028 | a `null` was specified for a property that cannot be `null`, such as one that is marked by an **Indexed** or **Not_Null** qualifier. |
| `WBEM_E_INVALID_OBJECT` | 0x8004100f | The specified instance is not valid. (For example, calling `PutInstanceWmi` with a class returns this value.) |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
| `WBEM_E_ALREADY_EXISTS` | 0x80041019 | The `WBEM_FLAG_CREATE_ONLY` flag was specified, but the instance already exists. |
| `WBEM_E_NOT_FOUND` | 0x80041002 | `WBEM_FLAG_UPDATE_ONLY` was specified in `lFlags`, but the instance does not exist. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_E_SHUTTING_DOWN` | 0x80041033 | WMI was probably stopped and restarting. Call [ConnectServerWmi](connectserverwmi.md) again. |
| `WBEM_E_TRANSPORT_FAILURE` | 0x80041015 | The remote procedure call (RPC) link between the current process and WMI has failed. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful. |
  
## Remarks

This function wraps a call to the [IWbemServices::PutInstance](https://msdn.microsoft.com/library/aa392115(v=vs.85).aspx) method.

The `PutInstanceWmi` function supports creating instances and updating instances of existing classes only.  Depending on how the `pCtx` parameter is set, either some or all of the properties of the instance are updated. 

When the instance pointed to by `pInst` belongs to a subclass, Windows Management calls all the providers responsible for the classes from which the subclass derives. All of these providers must succeed for the original `PutInstanceWmi` request to succeed. The provider supporting the topmost class in the hierarchy is called first. The calling order continues with the subclass of the topmost class and proceeds from top to bottom until Windows Management reaches the provider for the class owning the instance pointed to by `pInst`.
Windows Management does not call the providers for any of the child classes of an instance. 

When an application must update an instance that belongs to a class hierarchy, the `pInst` parameter must point to the instance containing the properties to be modified. That is, consider a target instance that belongs to **ClassB**. The **ClassB** instance derives from **ClassA**, and **ClassA** defines the property **PropA**. If an application wants to make a change to the value of **PropA** in the **ClassB** instance, it must set `pInst` to that instance rather than an instance of **ClassA**.

Calling `PutInstanceWmi` on an instance of an abstract class is not allowed.

If the function call fails, you can obtain additional error information by calling the [GetErrorInfo](geterrorinfo.md) function.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
