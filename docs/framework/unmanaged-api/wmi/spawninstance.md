---
title: SpawnInstance function (Unmanaged API Reference)
description: The SpawnInstance function creates a new instance of a class.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "SpawnInstance"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "SpawnInstance"
helpviewer_keywords: 
  - "SpawnInstance function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SpawnInstance function
Creates a new instance of a class.    
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT SpawnInstance (
   [in] int                  vFunc, 
   [in] IWbemClassObject*    ptr, 
   [in] LONG                 lFlags,
   [out] IWbemClassObject**  ppNewInstance); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`lFlags`  
[in] Reserved. This parameter must be 0.

`ppNewInstance`  
[out] Receives the pointer to the new instance of the class. If an error occurs, a new object is not returned, and `ppNewInstance` is left unmodified.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_INCOMPLETE_CLASS` | 0x80041020 | `ptr` is not a valid class definition and cannot spawn new instances. Either it is incomplete or it has not been registered with Windows Management by calling [PutClassWmi](putclasswmi.md). |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | `ppNewClass` is `null`. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::SpawnInstance](https://msdn.microsoft.com/library/aa391458(v=vs.85).aspx) method.

`ptr` must be a class definition obtained from Windows Management. (Note that spawning an instance from an instance is supported but the returned instance is empty.) You then use this class definition to create new instances. A call to the [PutInstanceWmi](putinstancewmi.md) function is required if you intend to write the instance to Windows Management.




The new object returned in `ppNewClass` automatically becomes a subclass of the current object. This behavior cannot be overridden. There is no other method by which subclasses (derived classes) can be created.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
