---
title: InheritsFrom function (Unmanaged API Reference)
description: The InheritsFrom function determines whether a class or instance derives from a particular parent class.
ms.date: "11/06/2017"
api_name: 
  - "InheritsFrom"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "InheritsFrom"
helpviewer_keywords: 
  - "InheritsFrom function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
---
# InheritsFrom function
Determines whether the current class or instance derives from a specified parent class.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```cpp
HRESULT InheritsFrom (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LPCWSTR           wszAncestor 
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemclassobject) instance.

`wszAncestor`  
[in] The name of the class. `wszAncestor` must point to a valid `LPCWSTR`.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_S_NO_ERROR` | 0 | The current object inherits from `wszAncestor`.  |
| `WBEM_S_FALSE` | 1 | The current object does not inherit from `wszAncestor`. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | `wszAncestor` is `null`. |
  
## Remarks

This function wraps a call to the [IWbemClassObject::InheritsFrom](/windows/desktop/api/wbemcli/nf-wbemcli-iwbemclassobject-inheritsfrom) method.

## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
