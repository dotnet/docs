---
title: ExecQueryWmi function (Unmanaged API Reference)
description: The ExecQueryWmi function executes a query to retrieve objects.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "ExecQueryWmi"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "ExecQueryWmi"
helpviewer_keywords: 
  - "ExecQueryWmi function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ExecQueryWmi function
Executes a query to retrieve objects.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT ExecQueryWmi (
   [in] BSTR                    strQueryLanguage,
   [in] BSTR                    strQuery,
   [in] long                    lFlags,
   [in] IWbemContext*           pCtx,
   [out] IEnumWbemClassObject** ppEnum,
   [in] DWORD                   authLevel,
   [in] DWORD                   impLevel,
   [in] IWbemServices*          pCurrentNamespace,
   [in] BSTR                    strUser,
   [in] BSTR                    strPassword,
   [in] BSTR                    strAuthority
); 
```  

## Parameters

`strQueryLanguage`    
[in] A string with the valid query language supported by Windows Management. It must be "WQL", the acronym for WMI Query Language.

`strQuery`  
[in] The text of the query. This parameter cannot be `null`.

`lFlags`   
[in] A combination of flags that affect the behavior of this function. The following values are defined in the *WbemCli.h* header file, or you can define them as constants in your code: 

| Constant | Value  | Description  |
|---------|---------|---------|
| `WBEM_FLAG_USE_AMENDED_QUALIFIERS` | 0x20000 | If set, the function retrieves the amended qualifiers stored in the localized namespace of the current connection's locale. <br/> If not set, the function retrieves only the qualifiers stored in the immediate namespace. |
| `WBEM_FLAG_RETURN_IMMEDIATELY` | 0x10 | The flag causes a semisynchronous call. |
| `WBEM_FLAG_FORWARD_ONLY` | 0x20 | The function returns a forward-only enumerator. Typically, forward-only enumerators are faster and use less memory than conventional enumerators, but they do not allow calls to [Clone](clone.md). |
| `WBEM_FLAG_BIDIRECTIONAL` | 0 | WMI retains pointers to objects in the enumration until they are released. | 
| `WBEM_FLAG_ENSURE_LOCATABLE` | 0x100 | Ensures that any returned objects have enough information in them so that system properties, such as **__PATH**, **__RELPATH**, and **__SERVER**, are not `null`. |
| `WBEM_FLAG_PROTOTYPE` | 2 | This flag is used for prototyping. It does not execute the query and instead returns an object that looks like a typical result object. |
| `WBEM_FLAG_DIRECT_READ` | 0x200 | Causes direct access to the provider for the class specified without regard to its parent class or any subclasses. |

The recommended flags are `WBEM_FLAG_RETURN_IMMEDIATELY` and `WBEM_FLAG_FORWARD_ONLY` for best performance.

`pCtx`  
[in] Typically, this value is `null`. Otherwise, it is a pointer to an [IWbemContext](https://msdn.microsoft.com/library/aa391465(v=vs.85).aspx) instance that can be used by the provider that is providing the requested classes. 

`ppEnum`  
[out] If no error occurs, receives the pointer to the enumerator that allows the caller to retrieve the instances in the query's result set. The query can have a result set with zero instances. See the [Remarks](#remarks) section for more information.

`authLevel`  
[in] The authorization level.

`impLevel`
[in] The impersonation level.

`pCurrentNamespace`   
[in] A pointer to an [IWbemServices](https://msdn.microsoft.com/library/aa392093(v=vs.85).aspx) object that represents the current namespace.

`strUser`   
[in] The user name. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

`strPassword`   
[in] The password. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

`strAuthority`   
[in] The domain name of the user. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_ACCESS_DENIED` | 0x80041003 | The user does not have permission to view one or more of the classes that the function can return. |
| `WBEM_E_FAILED` | 0x80041001 | An unspecified error has occurred. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
| `WBEM_E_INVALID_QUERY` | 0x80041017 | The query had a syntax error. |
| `WBEM_E_INVALID_QUERY_TYPE` | 0x80041018 | The requested query language is not supported. |
| `WBEM_E_QUOTA_VIOLATION` | 0x8004106c | The query is too complex. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_E_SHUTTING_DOWN` | 0x80041033 | WMI was probably stopped and restarting. Call [ConnectServerWmi](connectserverwmi.md) again. |
| `WBEM_E_TRANSPORT_FAILURE` | 0x80041015 | The remote procedure call (RPC) link between the current process and WMI has failed. |
| `WBEM_E_NOT_FOUND` | 0x80041002 | The query specifies a class that does not exist. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemServices::ExecQuery](https://msdn.microsoft.com/library/aa392107(v=vs.85).aspx) method.

This function processes the query specified in the `strQuery` parameter and creates an enumerator through which the caller can access the query results. The enumerator is a pointer to an [IEnumWbemClassObject](https://msdn.microsoft.com/library/aa390857(v=vs.85).aspx) interface; the query results are instances of class objects made available through the [IWbemClassObject](https://msdn.microsoft.com/library/aa391433(v=vs.85).aspx) interface.

There are limits to the number of `AND` and `OR` keywords that can be used in WQL queries. Large numbers of WQL keywords used in a complex query can cause WMI to return the `WBEM_E_QUOTA_VIOLATION` (or 0x8004106c) error code as an `HRESULT` value. The limit of WQL keywords depends on how complex the query is.

If the function call fails, you can obtain additional error information by calling the [GetErrorInfo](geterrorinfo.md) function.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
