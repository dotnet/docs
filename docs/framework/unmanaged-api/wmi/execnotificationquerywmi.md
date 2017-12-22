---
title: ExecNotificationQueryWmi function (Unmanaged API Reference)
description: The ExecNotificationQueryWmi function executes a query to receive events.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "ExecNotificationQueryWmi"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "ExecNotificationQueryWmi"
helpviewer_keywords: 
  - "ExecNotificationQueryWmi function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ExecNotificationQueryWmi function
Executes a query to receive events. The call returns immediately, and the caller can poll the returned enumerator for events as they arrive. Releasing the returned enumerator cancels the query.  

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT ExecNotificationQueryWmi (
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
[in] A combination of the following two flags that affect the behavior of this function. These values are defined in the *WbemCli.h* header file, or you can define them as constants in your code. 

| Constant | Value  | Description  |
|---------|---------|---------|
| `WBEM_FLAG_RETURN_IMMEDIATELY` | 0x10 | The flag causes a semisynchronous call. If this flag is not set, the call fails. This is because events are received continuously, which means the user must poll the returned enumerator. Blocking this call indefinitely makes that impossible. |
| `WBEM_FLAG_FORWARD_ONLY` | 0x20 | The function returns a forward-only enumerator. Typically, forward-only enumerators are faster and use less memory than conventional enumerators, but they do not allow calls to [Clone](clone.md). |

`pCtx`  
[in] Typically, this value is `null`. Otherwise, it is a pointer to an [IWbemContext](https://msdn.microsoft.com/library/aa391465(v=vs.85).aspx) instance that can be used by the provider that is providing the requested events. 

`ppEnum`  
[out] If no error occurs, receives the pointer to the enumerator that allows the caller to retrieve the instances in the query's result set. See the [Remarks](#remarks) section for more information.

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
| `WBEM_E_INVALID_CLASS` | 0x80041010 | The query specifies a class that does not exist. |
| `WBEMESS_E_REGISTRATION_TOO_PRECISE` | 0x80042002 | Too much precision in delivery of events has been requested. A larger polling tolerance must be specified. |
| `WBEMESS_E_REGISTRATION_TOO_BROAD` | 0x80042001 | The query requess more information than Windows Management can provide. This `HRESULT` is returned when an event query results in a request to poll all objects in a namespace. |
| `WBEM_E_INVALID_QUERY` | 0x80041017 | The query had a syntax error. |
| `WBEM_E_INVALID_QUERY_TYPE` | 0x80041018 | The requested query language is not supported. |
| `WBEM_E_QUOTA_VIOLATION` | 0x8004106c | The query is too complex. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_E_SHUTTING_DOWN` | 0x80041033 | WMI was probably stopped and restarting. Call [ConnectServerWmi](connectserverwmi.md) again. |
| `WBEM_E_TRANSPORT_FAILURE` | 0x80041015 | The remote procedure call (RPC) link between the current process and WMI has failed. |
| `WBEM_E_UNPARSABLE_QUERY` | 0x80041058 | The query cannot be parsed. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemServices::ExecNotificationQuery](https://msdn.microsoft.com/library/aa392105(v=vs.85).aspx) method.

After the function returns, the caller periodically passes the returned `ppEnum` object to the [Next](next.md) function to see if any events are available.

There are limits to the number of `AND` and `OR` keywords that can be used in WQL queries. Large numbers of WQL keywords used in a complex query can cause WMI to return the `WBEM_E_QUOTA_VIOLATION` (or 0x8004106c) error code as an `HRESULT` value. The limit of WQL keywords depends on how complex the query is.

If the function call fails, you can obtain additional error information by calling the [GetErrorInfo](geterrorinfo.md) function.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
