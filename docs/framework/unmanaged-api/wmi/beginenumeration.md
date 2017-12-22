---
title: BeginEnumeration function (Unmanaged API Reference)
description: The BeginEnumeration function resets an enumerator to the beginning of the enumeration
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "BeginEnumeration"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "BeginEnumeration"
helpviewer_keywords: 
  - "BeginEnumeration function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# BeginEnumeration function
Resets an enumerator back to the beginning of the enumeration.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT BeginEnumeration (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LONG              lEnumFlags
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`lEnumFlags`  
[in] A bitwise combination of the flags or values described in the [Remarks](#remarks) section that controls the properties included in the enumeration.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | The combination of flags in `lEnumFlags` is invalid, or an invalid argument was specified. |
|`WBEM_E_UNEXPECTED` | 0x8004101d | A second call to `BeginEnumeration` was made without an intervening call to [`EndEnumeration`](endenumeration.md). |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to begin a new enumeration. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::BeginEnumeration](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) method.

The flags that can be passed as the `lEnumFlags` argument are defined in the *WbemCli.h* header file, or you can define them as constants in your code.  You can combine one flag from each group with any flag from any other group. However, flags from the same group are mutually exclusive. 

**Group 1**

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_FLAG_KEYS_ONLY` | 0x4 | Include properties that constitute the key only. |
|`WBEM_FLAG_REFS_ONLY` | 0x8 | Include properties that are object references only. |

**Group 2**

Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_FLAG_SYSTEM_ONLY` | 0x30 | Limit the enumeration to system properties only. |
|`WBEM_FLAG_NONSYSTEM_ONLY` | 0x40 | Include local and propagated properties but exclude system properties from the enumeration. |

For classes:

Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_FLAG_CLASS_OVERRIDES_ONLY` | 0x100 | Limit the enumeration to properties overridden in the class definition. |
|`WBEM_FLAG_CLASS_LOCAL_AND_OVERRIDES` | 0x100 | Limit the enumeration to properties overridden in the current class definition and to new properties defined in the class. |
| `WBEM_MASK_CLASS_CONDITION` | 0x300 | A mask (rather than a flag) to apply against a `lEnumFlags` value to check if either `WBEM_FLAG_CLASS_OVERRIDES_ONLY` or `WBEM_FLAG_CLASS_LOCAL_AND_OVERRIDES` is set. |
| `WBEM_FLAG_LOCAL_ONLY` | 0x10 | Limit the enumeration to properties that are defined or modified in the class itself. |
| `WBEM_FLAG_PROPAGATED_ONLY` |  0x20 | Limit the enumeration to properties that are inherited from base classes. |

For instances:

Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_LOCAL_ONLY` | 0x10 | Limit the enumeration to properties that are defined or modified in the class itself. |
| `WBEM_FLAG_PROPAGATED_ONLY` |  0x20 | Limit the enumeration to properties that are inherited from base classes. |


## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
