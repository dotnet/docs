---
title: WritePropertyValue function (Unmanaged API Reference)
description: The WritePropertyValue function writes bytes to a property.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "WritePropertyValue"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "WritePropertyValue"
helpviewer_keywords: 
  - "WritePropertyValue function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WritePropertyValue function
Writes a specified number of bytes to a property identified by a property handle.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```  
HRESULT WritePropertyValue (
   [in] int                  vFunc, 
   [in] IWbemObjectAccess*   ptr, 
   [in] long                 lHandle,
   [in] long                 lNumBytes,
   [in] byte*                aData
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemObjectAccess](https://msdn.microsoft.com/library/aa391770(v=vs.85).aspx) instance.

`lHandle`  
[in] An integer that contains the handle that identifies this property. The handle can be retrieved by calling the [GetPropertyHandle](getpropertyhandle.md) function.   

`lNumBytes`  
[in] The number of bytes being written to the property. See the [Remarks](#remarks) section for more information.

`pHandle`   
[out] A pointer to the byte array that contains the data.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
|`WBEM_E_TYPE_MISMATCH` | 0x80041005 | A type mismatch occurred. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::WritePropertyValue](https://msdn.microsoft.com/library/aa391783(v=vs.85).aspx) method.

Use this function to set string and all other non-`DWORD` or non-`QWORD` data.

For nonstring property values, `lNumBytes` must be the correct data size of the property type specified. For string property values, `lNumBytes` must be the length of the specified string in bytes, and the string itself must be of an even length in bytes and be followed with a null-termination character.

## Requirements  
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
