---
title: QualifierSet_Put function (Unmanaged API Reference)
description: The QualifierSet_Put function writes the named qualifier and its value.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "QualifierSet_Put"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "QualifierSet_Put"
helpviewer_keywords: 
  - "QualifierSet_Put function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# QualifierSet_Put function
Writes the named qualifier and value. The new qualifier overwrites the previous value of the same name. If the qualifier does not exist, it is created. 

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT QualifierSet_Put (
   [in] int                  vFunc, 
   [in] IWbemQualifierSet*   ptr, 
   [in] LPCWSTR              wszName,
   [in] VARIANT*             pVal,
   [in] LONG                 lFlavor
); 
```  

## Parameters

`vFunc`   
[in] This parameter is unused.

`ptr`   
[in] A pointer to an [IWbemQualifierSet](https://msdn.microsoft.com/library/aa391860(v=vs.85).aspx) instance.

`wszName`   
[in] The name of the qualifier to write.

`pVal`
[in] A pointer to a valid `VARIANT` that contains the qualifier to write. This parameter cannot be `null`.

`lFlavor`
[in] One of the following constants that defines the desired qualifier flavors for this qualifier. The default value is `WBEM_FLAVOR_OVERRIDABLE` (0).

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAVOR_OVERRIDABLE` | 0 | The qualifier can be overridden in a derived class or instance. **This is the default value.** |
| `WBEM_FLAVOR_FLAG_PROPAGATE_TO_INSTANCE` | 1 | The qualifier is propagated to instances. |
| `WBEM_FLAVOR_GLAG_PROPAGATE_TO_DERIVED_CLASS` | 2 | The qualifier is propagated to derived classes. |
| `WBEM_FLAVOR_NOT_OVERRIDABLE | 0x10 | The qualifier cannot be overridden in a derived class or instance. |
| `WBEM_FLAVOR_AMENDED | 0x80 | The qualifier is localized. |

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_CANNOT_BE_KEY` | 0x8004101f | There was an illegal attempt to specify the **Key** qualifier on a property that cannot be a key. The keys are specified om tje c;ass definition for an object and cannot be altered on a per-instance basis. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
| `WBEM_E_INVALID_QUALIFIER_TYPE` | 0x80041029 | The `pVal` parameter is not of a legal qualifier type. |
| `WBEM_E_OVERRIDE_NOT_ALLOWED` | 0x8004101a | It is not possible to call the `QualifierSet_Put` method on the qualifier because the owning object does not permit overrides. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemQualifierSet::Put](https://msdn.microsoft.com/library/aa391871(v=vs.85).aspx) method.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
