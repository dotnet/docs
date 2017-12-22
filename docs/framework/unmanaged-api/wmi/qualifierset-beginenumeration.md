---
title: QualifierSet_BeginEnumeration function (Unmanaged API Reference)
description: The QualifierSet_BeginEnumeration function resets an enumerator of the qualifiers of an object.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "QualifierSet_BeginEnumeration"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "QualifierSet_BeginEnumeration"
helpviewer_keywords: 
  - "QualifierSet_BeginEnumeration function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# QualifierSet_BeginEnumeration function
Resets an enumerator of the qualifiers of an object to the beginning of the enumeration.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT QualifierSet_BeginEnumeration (
   [in] int                  vFunc, 
   [in] IWbemQualifierSet*   ptr, 
   [in] LONG                 lFlags
); 
```  

## Parameters

`vFunc`   
[in] This parameter is unused.

`ptr`   
[in] A pointer to an [IWbemQualifierSet](https://msdn.microsoft.com/library/aa391860(v=vs.85).aspx) instance.

`lFlags`   
[in] A bitwise combination of the flags or values described in the [Remarks](#remarks) section that specifies the qualifiers to include in the enumeration.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | The `lFlags` parameter is not valid. |
|`WBEM_E_UNEXPECTED` | 0x8004101d | A second call to `QualifierSet_BeginEnumeration` was made without an intervening call to [`QualifierSet_EndEnumeration`](qualifierset-endenumeration.md). |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to begin a new enumeration. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemQualifierSet::BeginEnumeration](https://msdn.microsoft.com/library/aa391861(v=vs.85).aspx) method.

To enumerate all of the qualifiers on an object, this method must be called before the first call to [QualifierSet_Next](qualifierset-next.md). The order in which qualifiers are enumerated is guaranteed to be invariant for a given enumeration.

The flags that can be passed as the `lEnumFlags` argument are defined in the *WbemCli.h* header file, or you can define them as constants in your code.   

|Constant  |Value  |Description  |
|---------|---------|---------|
|  | 0 | Return the names of all qualifiers. |
| `WBEM_FLAG_LOCAL_ONLY` | 0x10 | Return only the names of qualifiers specific to the current property or object. <br/> For a property: Return only the qualifiers specific to the property (including overrides), and not those qualifiers propagated from the class definition. <br/> For an instance: Return only instance-specific qualifier names. <br/> For a class: Return only qualifiers specific to the class beiong derived.
|`WBEM_FLAG_PROPAGATED_ONLY` | 0x20 | Return only the names of qualifiers propagated from another object. <br/> For a property: Return only the qualifiers propagated to this property from the class definition, and not those from the property itself. <br/> For an instance: Return only those qualifiers propagated from the class definition. <br/> For a class: Return only those qualifier names inherited from the parent classes. |

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
