---
title: QualifierSet_GetNames function (Unmanaged API Reference)
description: The QualifierSet_GetNames function retrieves the names of qualifiers from an object or property.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "QualifierSet_GetNames"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "QualifierSet_GetNames"
helpviewer_keywords: 
  - "QualifierSet_GetNames function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# QualifierSet_GetNames function
Retrieves the names of all the qualifiers or of certain qualifiers that are available from the current object or property. 

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT QualifierSet_GetNames (
   [in] int                  vFunc, 
   [in] IWbemQualifierSet*   ptr, 
   [in] LONG                 lFlags,
   [out] SAFEARRAY (BSTR)**  pstrNames
); 
```  

## Parameters

`vFunc`   
[in] This parameter is unused.

`ptr`   
[in] A pointer to an [IWbemQualifierSet](https://msdn.microsoft.com/library/aa391860(v=vs.85).aspx) instance.

`lFlags`   
[in] One of the following flags or values that specifies which names to include in the enumeration.

|Constant  |Value  |Description  |
|---------|---------|---------|
|  | 0 | Return the names of all qualifiers. |
| `WBEM_FLAG_LOCAL_ONLY` | 0x10 | Return only the names of qualifiers specific to the current property or object. <br/> For a property: Return only the qualifiers specific to the property (including overrides), and not those qualifiers propagated from the class definition. <br/> For an instance: Return only instance-specific qualifier names. <br/> For a class: Return only qualifiers specific to the class beiong derived.
|`WBEM_FLAG_PROPAGATED_ONLY` | 0x20 | Return only the names of qualifiers propagated from another object. <br/> For a property: Return only the qualifiers propagated to this property from the class definition, and not those from the property itself. <br/> For an instance: Return only those qualifiers propagated from the class definition. <br/> For a class: Return only those qualifier names inherited from the parent classes. |

`pstrNames`
[out] A new `SAFEARRAY` that contains the requested names. The array can have 0 elements. If an error occurs, a new `SAFEARRAY` is not returned.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to begin a new enumeration. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemQualifierSet::GetNames](https://msdn.microsoft.com/library/aa391868(v=vs.85).aspx) method.

Once you've retrieved the qualifier names, you can access each qualifier by name by calling the [QualifierSet_Get](qualifierset-get.md) function. 

It is not an error for a given object to have zero qualifiers, so the number of strings in `pstrNames` on return can be 0, even though the function returns `WBEM_S_NO_ERROR`.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
