---
title: CompareTo function (Unmanaged API Reference)
description: The CompareTo function compares an object to another WMI object.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "CompareTo"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CompareTo"
helpviewer_keywords: 
  - "CompareTo function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CompareTo function
Compares an object to another Windows management object.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```
HRESULT CompareTo (
   [in] int               vFunc, 
   [in] IWbemClassObject* ptr, 
   [in] LONG              flags,
   [in] IWbemClassObject* pCompareTo 
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`flags`  
[in] A bitwise combination of the flags that specify the object characteristics to consider for the comparison. See the [Remarks](#remarks) section for more information.

`pCompareTo`  

[in] The object for comparison. `pcompareTo` must be a valid [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance; it cannot be `null`.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_FAILED` | 0x80041001 | An unspecified error has occurred. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is invalid. |
| `WBEM_E_UNEXPECTED` | 0x8004101d | A second call to `BeginEnumeration` was made without an intervening call to [`EndEnumeration`](endenumeration.md). |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
| `WBEM_S_DIFFERENT` | 0x40003 | The objects are different. |
| `WBEM_S_SAME` | 0 | The objects are the same based on the comparison flags. |
  
## Remarks

This function wraps a call to the [IWbemClassObject::CompareTo](https://msdn.microsoft.com/library/aa391437(v=vs.85).aspx) method.

The flags that can be passed as the `lEnumFlags` argument are defined in the *WbemCli.h* header file, or you can define them as constants in your code. You can specify the individual characteristics involved in the comparison by specifying a bitwise combination of the following flags:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_IGNORE_OBJECT_SOURCE` | 2 | Ignore the source (the server and the namespace they came from). |
| `WBEM_FLAG_IGNORE_QUALIFIERS` | 1 | Ignore all qualifiers (including **Key** and **Dynamic**) |
| `WBEM_FLAG_IGNORE_DEFAULT_VALUES` | 4 | Ignore default values of properties. This flag only applies to comparison of classes. |
| `WBEM_FLAG_IGNORE_FLAVOR` | 0x20 | Ignore qualifier flavors. This flag still takes qualifiers into account, but ignores flavor distinctions such as propagation rules and override restrictions. |
| `WBEM_FLAG_IGNORE_CASE` | 0x10 | Ignore case in comparing string values. This applies both to strings and qualifier values. The comparison of property and qualifier names is always case-sensitive regardless of whether this flag is set. |
| `WBEM_FLAG_IGNORE_CLASS` | 0x8 | Assume that the objects being compared are instanes of the same class. Consequently, this flag compares instance-related information only. Use this flags to optimize performance. If the objects are not of the same class, the results are undefined. |

Or you can specify a single composite flag as follows:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_COMPARISON_INCLUDE_ALL` | 0 | Consider all features in the comparison. |

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
