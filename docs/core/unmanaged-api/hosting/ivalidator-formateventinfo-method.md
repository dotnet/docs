---
description: "Learn more about: IValidator::FormatEventInfo Method"
title: "IValidator::FormatEventInfo Method"
ms.date: "03/30/2017"
api_name:
  - "IValidator.FormatEventInfo"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "FormatEventInfo"
helpviewer_keywords:
  - "IValidator::FormatEventInfo method [.NET Framework hosting]"
  - "FormatEventInfo method, IValidator interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IValidator::FormatEventInfo Method

Gets the error message corresponding to the specified validation error.

## Syntax

```cpp
HRESULT FormatEventInfo(
    [in] HRESULT            hVECode,
    [in] VEContext          Context,
    [in, out] LPWSTR        msg,
    [in] unsigned long      ulMaxLength,
    [in] SAFEARRAY(VARIANT) psa
);
```

## Parameters

 `hVECode`
 [in] The HRESULT value that was passed to the validation error handler.

 `Context`
 [in] A `VEContext` instance that contains context information about the validation error.

 `msg`
 [in, out] A string that contains the returned error message.

 `ulMaxLength`
 [in] The maximum length of the error message.

 `psa`
 [in] A safe array that contains additional parameters describing the error.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** IValidator.idl, IValidator.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0
