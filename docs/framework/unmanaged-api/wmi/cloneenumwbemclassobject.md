---
title: CloneEnumWbemClassObject function (Unmanaged API Reference)
description: The CloneEnumWbemClassObject function makes a logical copy of an enumerator.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "CloneEnumWbemClassObject"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CloneEnumWbemClassObject"
helpviewer_keywords: 
  - "CloneEnumWbemClassObject function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CloneEnumWbemClassObject function
Makes a logical copy of an enumerator, retaining its current position in an enumeration.  
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT CloneEnumWbemClassObject (
   [out] IEnumWbemClassObject**  ppEnum, 
   [in] DWORD                    authLevel,
   [in] DWORD                    impLevel,
   [in] IEnumWbemClassObject*    pCurrentEnumWbemClassObject, 
   [in] BSTR                     strUser,
   [in] BSTR                     strPassword,
   [in BSTR]                     strAuthority 
); 
```  

## Parameters

`ppEnum`  
[out] Receives a pointer to a new [IEnumWbemClassObject](https://msdn.microsoft.com/library/aa390857(v=vs.85).aspx).

`authLevel`  
[in] The authorization level.

`impLevel`
[in] The impersonation level.

`pCurrentEnumWbemClassObject`  
[out] A pointer to the [IEnumWbemClassObject](https://msdn.microsoft.com/library/aa390857(v=vs.85).aspx) instance to be cloned.

`strUser`   
[in] The user name. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

`strPassword`   
[in] The password. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

`strAuthority`   
[in] The domain name of the user. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is invalid. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available complete the operation. |
| `WBEM_E_TRANSPORT_FAILURE` | 0x80041015 | The remote procedure call (RPC) link between the current process and WMI has failed. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IEnumWbemClassObject::Clone](https://msdn.microsoft.com/library/aa390859(v=vs.85).aspx) method.

This method makes only a "best effort" copy. Due to the dynamic nature of many CIM objects, it is possible that the new enumerator does not enumerate the same set of objects as the source enumerator.  

If the function call fails, you can obtain additional error information by calling the [GetErrorInfo](geterrorinfo.md) function.

## Example

For an example, see the [IEnumWbemClassObject::Clone](https://msdn.microsoft.com/library/aa390859(v=vs.85).aspx) method.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
