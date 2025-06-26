---
description: "Learn more about: _CorExeMain Function"
title: "_CorExeMain Function"
ms.date: "03/30/2017"
api_name:
  - "_CorExeMain"
api_location:
  - "mscoree.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "_CorExeMain"
helpviewer_keywords:
  - "_CorExeMain function [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# _CorExeMain Function

Initializes the common language runtime (CLR), locates the managed entry point in the executable assembly's CLR header, and begins execution.

## Syntax

```cpp
__int32 STDMETHODCALLTYPE _CorExeMain ();
```

## Remarks

 This function is called by the loader in processes created from managed executable assemblies. For DLL assemblies, the loader calls the [_CorDllMain](cordllmain-function.md) function instead.

 The operating system loader calls this method regardless of the entry point specified in the image file.

 For additional information, see the Remarks section in the [_CorValidateImage](corvalidateimage-function.md) article.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Global Static Functions](../metadata/metadata-global-static-functions.md)
