---
description: "Learn more about: ICLRRuntimeInfo::LoadErrorString Method"
title: "ICLRRuntimeInfo::LoadErrorString Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRRuntimeInfo.LoadErrorString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRRuntimeInfo::LoadErrorString"
helpviewer_keywords:
  - "ICLRRuntimeInfo::LoadErrorString method [.NET Framework hosting]"
  - "LoadErrorString method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRRuntimeInfo::LoadErrorString Method

Translates an HRESULT value into an appropriate error message for the specified culture.

 This method supersedes the following functions:

- [LoadStringRC](loadstringrc-function.md)

- [LoadStringRCEx](loadstringrcex-function.md)

## Syntax

```cpp
HRESULT LoadErrorString(
     [in] UINT iResourceID,
     [out, size_is(*pcchBuffer)] LPWSTR pwzBuffer,
     [in, out]  DWORD *pcchBuffer,
     [in, lcid] LONG iLocaleID);
```

## Parameters

 `iResourceID`
 [in] The HRESULT to translate.

 `pwzBuffer`
 [out] The message string associated with the given HRESULT.

 `pcchBuffer`
 [in, out] The size of `pwzbuffer` to avoid buffer overruns. If `pwzbuffer` is null, `pcchBuffer` provides the expected size of `pwzbuffer` to allow preallocation.

 `iLocaleID`
 [in] The culture identifier. To use the default culture, you must specify -1.

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The method completed successfully.|
|E_POINTER|`pcchBuffer` is null.|
|E_INVALIDARG|`pwzBuffer` is null.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [ICLRRuntimeInfo Interface](iclrruntimeinfo-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
