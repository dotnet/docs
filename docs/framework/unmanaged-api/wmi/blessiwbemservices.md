---
title: BlessIWbemServices function (Unmanaged API Reference)
description: The BlessIWbemServices function indicates whether user credentials permit access to an IWbemServices class.
ms.date: "11/06/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "reference"
api_name: 
  - "BlessIWbemServices"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "BlessIWbemServices"
helpviewer_keywords: 
  - "BlessIWbemServices function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# BlessIWbemServices function
Indicates whether the user credentials permit access to the specified [IWbemServices](https://msdn.microsoft.com/library/aa392093(v=vs.85).aspx) class.   
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```  
HRESULT BlessIWbemServices (
   [in] IWbemServices* pIWbemServices,
   [in] BSTR strUser, 
   [in] BSTR strPassword, 
   [in] BSTR strAuthority, 
   [in] DWORD impLevel, 
   [in] DWORD authnLevel
);
```  

## Parameters

`pIWbemServices`  
[in] A pointer to the [IWbemServices](https://msdn.microsoft.com/library/aa392093(v=vs.85).aspx) object for which permissions are required.

`strUser`  
[in] The user name.

`strPassword`  
[in] The password associated with `strUser`.

`strAuthority`
[in] The domain name of the user. See the [ConnectServerWmi](connectserverwmi.md) function for more information.

`impLevel`
[in] The impersonation level.

`authnLevel`
[in] The authorization level.

## Return value

The following values returned by this function are defined in the *WinError.h* header file, or you can define them as constants in your code:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `E_INVALIDARG` | 0x80070057 | One or more arguments are invalid. |
| `E_POINTER` | 0x80004003 | `pIWbemServices` is `null`. | 
| `E_FAIL` | 0x80000008 | An unspecified error has occurred. |
| `E_OUTOFMEMORY` | 0x80000002 | Insufficient memory is available to perform the operation. | 
| `S_OK` | 0 | The function call was successful. | 

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also  
[WMI and Performance Counters (Unmanaged API Reference)](index.md)
