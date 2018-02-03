---
title: ConnectServerWmi function (Unmanaged API Reference)
description: The ConnectServerWmi function uses DCOM to create a connection to a WMI namespace.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "ConnectServerWmi"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "ConnectServerWmi"
helpviewer_keywords: 
  - "ConnectServerWmi function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ConnectServerWmi function
Creates a connection through DCOM to a WMI namespace on a specified computer.  
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT ConnectServerWmi (
   [in] BSTR               strNetworkResource,
   [in] BSTR               strUser,
   [in] BSTR               strPassword,
   [in] BSTR               strLocale,
   [in] long               lSecurityFlags,
   [in] BSTR               strAuthority,
   [in] IWbemContext*      pCtx,
   [out] IWbemServices**   ppNamespace,
   [in] DWORD              impLevel, 
   [in] DWORD              authLevel
);
```  
## Parameters

`strNetworkResource`
[in] Pointer to a valid `BSTR` that contains the object path of the correct WMI namespace. See the [Remarks](#remarks) section for more information.

`strUser`
[in] A pointer to a valid `BSTR` that contains the user name. A `null` value indicates the current security context. If the user is from a different domain than the current one, `strUser` can also contain the domain and user name separated by a backslash. `strUser` can also be in user principal name (UPN) format, suhc as *userName@domainName*. See the [Remarks](#remarks) section for more information.

`strPassword`
[in] A pointer to a valid `BSTR` that contains the password. A `null` indicates the current security context. An empty string ("") indicates a valid zero-length password.

`strLocale`
[in] A pointer to a valid `BSTR` that indicates the correct locale for information retrieval. For Microsoft locale identifiers, the format of the string is "MS\_*xxx*", where *xxx* is a string in hexadecimal form that indicates the locale identifier (LCID). If an invalid locale is specified, the method returns `WBEM_E_INVALID_PARAMETER` except on Windows 7, where the default locale of the server is used instead. If `null1, the current locale is used. 
 
`lSecurityFlags`
[in] Flags to pass to the `ConnectServerWmi` method. A value of zero (0) for this parameter results in the call to `ConnectServerWmi` returning only after a connection to the server is established. This could result in an application not responding indefinitely if the server is broken. The other valid values are:

| Constant  | Value  | Description  |
|---------|---------|---------|
| `CONNECT_REPOSITORY_ONLY` | 0x40 | Reserved for internal use. Do not use. |
| `WBEM_FLAG_CONNECT_USE_MAX_WAIT` | 0x80 | `ConnectServerWmi` returns in two minutes or less. |

`strAuthority`
[in] The domain name of the user. It can have the following values:

| Value | Description |
|---------|---------|
| blank | NTLM authentication is used, and the NTLM domain of the current user is used. If `strUser` specifies the domain (the recommended location), it must not be specified here. The function returns `WBEM_E_INVALID_PARAMETER` if you specify the domain in both parameters. |
| Kerberos:*principal name* | Kerberos authentication is used, and this parameter contains a Kerberos principal name. |
| NTLMDOMAIN:*domain name* | NT LAN Manager authentication is used, and this parameter contains an NTLM domain name. |

`pCtx`   
[in] Typically, this parameter is is `null`. Otherwise, it is a pointer to an [IWbemContext](https://msdn.microsoft.com/library/aa391465%28v=vs.85%29.aspx) object required by one or more dynamic class providers. 

`ppNamespace`  
[out] When the function returns, receives a pointer to an [IWbemServices](https://msdn.microsoft.com/library/aa392093(v=vs.85).aspx) object bound to the specified namespace. It is set to point to `null` when there is an error.

`impLevel`  
[in] The impersonation level.

`authLevel`  
[in] The authorization level.

## Return value

The following values returned by this function are defined in the *WbemCli.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `WBEM_E_FAILED` | 0x80041001 | There has been a general failure. |
| `WBEM_E_INVALID_PARAMETER` | 0x80041008 | A parameter is not valid. |
| `WBEM_E_OUT_OF_MEMORY` | 0x80041006 | Not enough memory is available to complete the operation. |
| `WBEM_S_NO_ERROR` | 0 | The function call was successful.  |
  
## Remarks

This function wraps a call to the [IWbemLocator::ConnectServer](https://msdn.microsoft.com/libraryaa391769%28v=vs.85%29.aspx) method.

 For local access to the default namespace, `strNetworkResource` can be a simple object path: "root\default" or "\\.\root\default". For access to the default namespace on a remote computer using COM or Microsoft-compatible networking, include the computer name: "\\myserver\root\default". The computer name also can be a DNS name or IP address. The `ConnectServerWmi` function can also connect with computers running IPv6 using an IPv6 address.

`strUser` cannot be an empty string. If the domain is specified in `strAuthority`, it must not also be included in `strUser`, or the function returns `WBEM_E_INVALID_PARAMETER`.


## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
