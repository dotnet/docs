---
title: BeginMethodEnumeration function (Unmanaged API Reference)
description: The BeginMethodEnumeration function begins an enumeration of the object's methods
ms.date: "11/06/2017"
api_name: 
  - "BeginMethodEnumeration"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "BeginMethodEnumeration"
helpviewer_keywords: 
  - "BeginMethodEnumeration function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
---
# BeginEnumeration function
Begins an enumeration of the methods available for the object.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
``` 
HRESULT BeginMethodEnumeration (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LONG              lEnumFlags
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`lEnumFlags`  
[in] Zero (0) for all methods, or a flag that specifies the scope of the enumeration. The following flags are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_LOCAL_ONLY` | 0x10 | Limit the enumeration to methods that are defined in the class itself. |
| `WBEM_FLAG_PROPAGATED_ONLY` |  0x20 | Limit the enumeration to properties that are inherited from base classes. |

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | `lEnnumFlags` is non-zero and is not one of the specified flags. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::BeginMethodEnumeration](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-beginmethodenumeration) method.

This method call is only supported if the current object is a class definition. Method manipulation is not available from [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) pointers that point to instances. The order in which methods are enumerated is guaranteed to be invariant for a given instance of [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject).

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
