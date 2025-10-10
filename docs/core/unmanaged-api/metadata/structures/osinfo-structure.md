---
description: "Learn more about: OSINFO Structure"
title: "OSINFO Structure"
ms.date: "03/30/2017"
api_name:
  - "OSINFO"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "OSINFO"
topic_type:
  - "apiref"
---
# OSINFO Structure

Contains details about the operating system for an assembly or module.

## Syntax

```cpp
typedef struct {
    DWORD   dwOSPlatformId;
    DWORD   dwOSMajorVersion;
    DWORD   dwOSMinorVersion;
} OSINFO;
```

## Members

| Member             | Description                                                                  |
|--------------------|------------------------------------------------------------------------------|
| `dwOSPlatformId`   | One of the identifier values defined by the Microsoft Windows platform function `GetVersionEx`. The following values are supported:<br /><br /> - VER_PLATFORM_WIN32s, or 0x0000, to specify Microsoft Windows 3.1.<br />- VER_PLATFORM_WIN32_WINDOWS, or 0x0001, to specify Windows 95, Windows 98, or operating systems descended from them.<br />- VER_PLATFORM_WIN32_NT, or 0x0002, to specify Windows NT or operating systems descended from it. |
| `dwOSMajorVersion` | The operating system major version, or a NULL value to indicate any version. |
| `dwOSMinorVersion` | The operating system minor version, or a NULL value to indicate any version. |

## Remarks

 `OSINFO` is based on the `OSVERSIONINFOEX` structure that is used in calls to the Microsoft Windows platform function `GetVersionEx`. This structure is used by the `ASSEMBLYMETADATA` structure to indicate its operating system support.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

## See also

- [IMetaDataAssemblyEmit Interface](../interfaces/imetadataassemblyemit-interface.md)
