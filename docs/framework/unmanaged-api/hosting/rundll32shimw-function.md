---
title: "RunDll32ShimW Function"
ms.date: "03/30/2017"
api_name: 
  - "RunDll32ShimW"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "RunDll32ShimW"
helpviewer_keywords: 
  - "RunDll32ShimW function [.NET Framework hosting]"
ms.assetid: 9ea07b57-96e2-44df-8711-8fe6c119087f
topic_type: 
  - "apiref"
---
# RunDll32ShimW Function
Executes the specified command.  
  
 This function has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
HRESULT RunDll32ShimW (  
    [in] HWND        hwnd,  
    [in] HINSTANCE   hinst,  
    [in] LPCWSTR     lpszCmdLine,  
    [in] int         nCmdShow  
);  
```  
  
## Parameters  
 `hwnd`  
 [in] A handle to a window in which the command output will be displayed.  
  
 `hinst`  
 [in] A handle to the library that contains the command.  
  
 `lpszCmdLine`  
 [in] A string that specifies the command to be executed.  
  
 `nCmdShow`  
 [in] An integer that specifies the display mode for the output window.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
