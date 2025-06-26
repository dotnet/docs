---
description: "Learn more about: ICLRRuntimeInfo::SetDefaultStartupFlags Method"
title: "ICLRRuntimeInfo::SetDefaultStartupFlags Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRRuntimeInfo.SetDefaultStartupFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRRuntimeInfo::SetDefaultStartupFlags"
helpviewer_keywords:
  - "ICLRRuntimeInfo::SetDefaultStartupFlags method [.NET Framework hosting]"
  - "SetDefaultStartupFlags method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRRuntimeInfo::SetDefaultStartupFlags Method

Sets the startup flags and the host configuration file that will be used to start the runtime. This method supersedes the use of the `startupFlags` parameter in the [CorBindToRuntimeEx](corbindtoruntimeex-function.md) and [CorBindToRuntimeHost](corbindtoruntimehost-function.md) functions.

## Syntax

```cpp
HRESULT SetDefaultStartupFlags(
           [in]  DWORD dwStartupFlags,
           [in]  LPCWSTR pwzHostConfigFile);
```

## Parameters

 `dwStartupFlags`
 [in] The host startup flags to set. Use the same flags as with the [CorBindToRuntimeEx](corbindtoruntimeex-function.md) and [CorBindToRuntimeHost](corbindtoruntimehost-function.md) functions.

 `pwzHostConfigFile`
 [in] The directory path of the host configuration file to set.

## Return Value

 This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method completed successfully.|

## Remarks

 A multithreaded host should synchronize calls to this method. Otherwise, thread A might call the `SetStartupFlags` method after thread B completes a call to `SetStartupFlags` and before thread B starts the runtime.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [ICLRRuntimeInfo Interface](iclrruntimeinfo-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
