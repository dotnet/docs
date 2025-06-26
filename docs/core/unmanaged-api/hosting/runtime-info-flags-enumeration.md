---
description: "Learn more about: RUNTIME_INFO_FLAGS Enumeration"
title: "RUNTIME_INFO_FLAGS Enumeration"
ms.date: "03/30/2017"
api_name:
  - "RUNTIME_INFO_FLAGS"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "RUNTIME_INFO_FLAGS"
helpviewer_keywords:
  - "RUNTIME_INFO_FLAGS enumeration [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# RUNTIME_INFO_FLAGS Enumeration

Contains values that indicate what information about the common language runtime (CLR) should be returned.

## Syntax

```cpp
typedef enum {

    RUNTIME_INFO_UPGRADE_VERSION             = 0x01,
    RUNTIME_INFO_REQUEST_IA64                = 0x02,
    RUNTIME_INFO_REQUEST_AMD64               = 0x04,
    RUNTIME_INFO_REQUEST_X86                 = 0x08,
    RUNTIME_INFO_DONT_RETURN_DIRECTORY       = 0x10,
    RUNTIME_INFO_DONT_RETURN_VERSION         = 0x20,
    RUNTIME_INFO_DONT_SHOW_ERROR_DIALOG      = 0x40,
    RUNTIME_INFO_IGNORE_ERROR_MODE           = 0x1000

} RUNTIME_INFO_FLAGS;
```

## Members

|Member|Description|
|------------|-----------------|
|`RUNTIME_INFO_DONT_RETURN_DIRECTORY`|Indicates that directory information should not be included.|
|`RUNTIME_INFO_DONT_RETURN_VERSION`|Indicates that version information should not be included.|
|`RUNTIME_INFO_DONT_SHOW_ERROR_DIALOG`|Indicates that an error dialog box should not be shown upon failure.|
|`RUNTIME_INFO_IGNORE_ERROR_MODE`|Indicates that the effects of calling the [SetErrorMode](/windows/win32/api/errhandlingapi/nf-errhandlingapi-seterrormode) function with the SEM_FAILCRITICALERRORS flag should be overridden. That is, an installation dialog box should be shown upon failure, instead of being suppressed.|
|`RUNTIME_INFO_REQUEST_AMD64`|Indicates a request for information about an AMD-64-compatible version of the runtime.|
|`RUNTIME_INFO_REQUEST_IA64`|Indicates a request for information about an IA-64-compatible version of the runtime.|
|`RUNTIME_INFO_REQUEST_X86`|Indicates a request for information about an x86-compatible version of the runtime.|
|`RUNTIME_INFO_UPGRADE_VERSION`|Indicates that version upgrade information should be included.|

## Remarks

 The following platform architecture flags can be specified only one at a time and cannot be combined:

- RUNTIME_INFO_REQUEST_IA64

- RUNTIME_INFO_REQUEST_AMD64

- RUNTIME_INFO_REQUEST_X86

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Enumerations](hosting-enumerations.md)
