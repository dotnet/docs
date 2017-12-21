---
title: GetNames function (Unmanaged API Reference)
description: The GetNames function retrieves the names of the properties of an object.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "GetNames"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetNames"
helpviewer_keywords: 
  - "GetNames function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetNames function
Retrieves either a subset or all of the names of the properties of an object. 

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
    
## Syntax  
  
```  
HRESULT GetNames (
   [in] int                 vFunc, 
   [in] IWbemClassObject*   ptr, 
   [in] LPCWSTR             wszQualifierName,
   [in] LONG                lFlags,
   [in] VARIANT*            pQualifierValue,
   [out] SAFEARRAY (BSTR)** pstrNames
); 
```  

## Parameters

`vFunc`  
[in] This parameter is unused.

`ptr`  
[in] A pointer to an [IWbemClassObject](https://msdn.microsoft.com/library/aa391433%28v=vs.85%29.aspx) instance.

`wszQualifierName`  
[in] A pointer to a valid `LPCWSTR` that specifies a qualifier name that operates as part of a filter. For more information, see the [Remarks](#remarks) section. This parameter can be `null`. 

`lFlags`  
[in] A combination of bit fields. For more information, see the [Remarks](#remarks) section.

`pQualifierValue`   
[in] A pointer to a valid `VARIANT` structure initialized to a filter value. This parameter can be `null`. 

`pstrNames`  
[out] A `SAFEARRAY` structure that contains property names. On entry, this parameter must always be a pointer to `null`. See the [Remarks](#remarks) section for more information. 

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
|`WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
|`WBEM_E_INVALID_PARAMETER` | 0x80041008 | One or more parameters are not valid, or an incorrect combination of flags and parameters was specified. |
|`WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
|`WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemClassObject::GetNames](https://msdn.microsoft.com/library/aa391447(v=vs.85).aspx) method.

The named returned are controlled by a combination of flags and parameters. For example, the function can return the names of all properties or only the names of the key properties.  The primary filter is specified in the `lFlags` parameter, and the other parameters vary depending on it.

The flag values in `lFlags` are bit fields


The flags that can be passed as the `lEnumFlags` argument are bit fields that are defined in the *WbemCli.h* header file, or you can define them as constants in your code.  You can combine one flag from each group with any flag from any other group. However, flags from the same group are mutually exclusive. 

| Group 1 flags |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_ALWAYS` | 0 | Return all property names. `strQualifierName` and `pQualifierVal` are unused. |
| `WBEM_FLAG_ONLY_IF_TRUE` | 1 | Return only properties that have a qualifier of the name specified by the `strQualifierName` parameter. If this flag is used, you must specify `strQualifierName`. |
|`WBEM_FLAG_ONLY_IF_FALSE` | 2 |  Return only properties that do not have a qualifier of the name specified by the `strQualifierName` parameter. If this flag is used, you must specify `strQualifierName`. |
|`WBEM_FLAG_ONLY_IF_IDENTICAL` | 3 | Return only properties that have a qualifier of the name specified by the `wszQualifierName` parameter and also have a value identical to that specified by the `pQualifierVal` structure. If this flag is used, you must specify both a `wszQualifierName` and a `pQualifierValue`. |

| Group 2 flags |Value  |Description  |
|---------|---------|---------|
|`WBEM_FLAG_KEYS_ONLY` | 0x4 | Return only the names of properties that define the keys. |
|`WBEM_FLAG_REFS_ONLY` | 0x8 | Return only property names that are object references. |

| Group 3 flags |Value  |Description  |
|---------|---------|---------|
| `WBEM_FLAG_LOCAL_ONLY` | 0x10 | Return only property names that belong to the most derived class. Exclude properties from the parent classes. |
| `WBEM_FLAG_PROPAGATED_ONLY` |  0x20 | Return only property names that belong to the parent classes. |
|`WBEM_FLAG_SYSTEM_ONLY` | 0x30 | Return only the names of system properties. |
|`WBEM_FLAG_NONSYSTEM_ONLY` | 0x40 | Return only the names of non-system properties. |

The function always allocates a new `SAFEARRAY` if it returns `WBEM_S_NO_ERROR`, and `pstrNames` is always set to point to it. The returned array can have 0 elements if no properties match the specified filters. If the function returns an value other than `WBM_S_NO_ERROR`, a new `SAFEARRAY` structure is not returned.
 
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
