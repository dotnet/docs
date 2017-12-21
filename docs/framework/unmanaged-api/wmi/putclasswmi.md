---
title: PutClassWmi function (Unmanaged API Reference)
description: The PutClassWmi function creates a new class or updates an existing one.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "PutClassWmi"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "PutClassWmi"
helpviewer_keywords: 
  - "PutClassWmi function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# PutClassWmi function
Creates a new class or updates an existing one.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT PutClassWmi (
   [in] IWbemClassObject*    pObject,
   [in] long                 lFlags,
   [in] IWbemContext*        pCtx,
   [out] IWbemCallResult**   ppCallResult
); 
```  

## Parameters

`pObject`    
[in] A pointer to a valid class definition. It must be correctly initialized with all the required property values.

`lFlags`   
[in] A combination of flags that affect the behavior of this function. The following values are defined in the *WbemCli.h* header file, or you can define them as constants in your code: 

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_USE_AMENDED_QUALIFIERS` | 0x20000 | If set, WMI does not store any qualifiers with the amended flavor. </br> If not set, it is assumed that this object is not localized, and all qualifiers are storedwith this instance. |
| `WBEM_FLAG_CREATE_OR_UPDATE` | 0 | Create the class if it does not exist, or overwrite it if it exists already. |
| `WBEM_FLAG_UPDATE_ONLY` | 1 | Update the class. The class must exist for the call to be successful. |
| `WBEM_FLAG_CREATE_ONLY` | 2 | Create the class. The call fails if the class already exists. |
| `WBEM_FLAG_RETURN_IMMEDIATELY` | 0x10 | The flag causes a semisynchronous call. |
| `WBEM_FLAG_OWNER_UPDATE` | 0x10000 | Push providers must specify this flag when calling `PutClassWmi` to indicate that this class has changed. |
| `WBEM_FLAG_UPDATE_COMPATIBLE` | 0 | Allows a class to be updated if there are no derived classes and no instances of that class. It also allows updates in all cases if the change is just to unimportant qualifiers, such as the Description qualifier. If the class has instances or changes are to important qualifiers, the update fails. |
| `WBEM_FLAG_UPDATE_SAFE_MODE` | 0x20 | Allows updates of classes even if there are child classes as long as the change does not cause any conflicts with child classes. For example, this flag allows a new property to be added to the base class that was not previously mentioned in any of the child classes. If the class has instances, the update fails. |
| `WBEM_FLAG_UPDATE_FORCE_MODE` | 0x40 | forces updates of classes when conflicting child classes exist. For example, this flag forces an update if a class qualifier is defined in a child class, and the base class tries to add the same qualifier which conflicts with thte existing one. In force mode, tis conflict is resolved by deleting the conflicting qualifier in the child class. |

`pCtx`  
[in] Typically, this value is `null`. Otherwise, it is a pointer to an [IWbemContext](https://msdn.microsoft.com/library/aa391465(v=vs.85).aspx) instance that can be used by the provider that is providing the requested classes. 

`ppCallResult`  
[out] If `null`, this parameter is unused. If `lFlags` contains `WBEM_FLAG_RETURN_IMMEDIATELY`, the function returns immediately with `WBEM_S_NO_ERROR`. The `ppCallResult` parameter receives a pointer to a new [IWbemCallResult](https://msdn.microsoft.com/library/aa391425(v=vs.85).aspx) object.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_ACCESS_DENIED` | 0x80041003 | The user does not have permission to create or modify classes. |
| `WBEM_E_FAILED` | 0x80041001 | An unspecified error has occurred. |
| `WBEM_E_INVALID_CLASS` | 0x80041010 | The specified class is not valid. Typically, this indicates that `pObject` specifies an instance object. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
| `WBEM_E_INVALID OPERATION` | 0x80041016 | The specified class name is not valid. |
| `WBEM_E_CLASS_HAS_CHILDREN` | 0x80041025 | An attempt was made to make a change that would invalidate a subclass. |
| `WBEM_E_ALREADY_EXISTS` | 0x80041019 | The `WBEM_FLAG_CREATE_ONLY` flag was specified, but the class already exists. |
| `WBEM_E_NOT_FOUND` | 0x80041002 | `WBEM_FLAG_UPDATE_ONLY` was specified in `lFlags`, and the class was not found. |
| `WBEM_E_INCOMPLETE_CLASS` | 0x80041020 | The required properties for classes have not all been set. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_E_SHUTTING_DOWN` | 0x80041033 | WMI was probably stopped and restarting. Call [ConnectServerWmi](connectserverwmi.md) again. |
| `WBEM_E_TRANSPORT_FAILURE` | 0x80041015 | The remote procedure call (RPC) link between the current process and WMI has failed. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemServices::PutClass](https://msdn.microsoft.com/library/aa392113(v=vs.85).aspx) method.

The user may not create classes with names that begin or end with an underscore chacater

If the function call fails, you can obtain additional error information by calling the [GetErrorInfo](geterrorinfo.md) function.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
