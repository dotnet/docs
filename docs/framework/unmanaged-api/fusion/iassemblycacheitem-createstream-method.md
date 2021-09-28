---
description: "Learn more about: IAssemblyCacheItem::CreateStream Method"
title: "IAssemblyCacheItem::CreateStream Method"
ms.date: "03/30/2017"
api_name:
  - "IAssemblyCacheItem.CreateStream"
api_location:
  - "fusion.dll"
api_type:
  - "COM"
f1_keywords:
  - "IAssemblyCacheItem::CreateStream"
helpviewer_keywords:
  - "CreateStream method [.NET Framework fusion]"
  - "IAssemblyCacheItem::CreateStream method [.NET Framework fusion]"
ms.assetid: 697ab0f4-470c-4baa-a415-4a975c42d0d5
topic_type:
  - "apiref"
---

# IAssemblyCacheItem::CreateStream Method

Creates a stream with the specified name and format.

## Syntax

```cpp
HRESULT CreateStream (
    [in]  DWORD dwFlags,
    [in]  LPCWSTR pszStreamName,
    [in]  DWORD dwFormat,
    [in]  DWORD dwFormatFlags,
    [out] IStream **ppIStream,
    [in, optional] ULARGE_INTEGER *puliMaxSize
);
```

## Parameters

`dwFlags`\
[in] Flags defined in Fusion.idl.

`pszStreamName`\
[in] The name of the stream to be created.

`dwFormat`\
[in] The format of the file to be streamed.

`dwFormatFlags`\
[in] Format-specific flags defined in Fusion.idl.

`ppIStream`\
[out] A pointer to the address of the returned [IStream](/windows/desktop/api/objidl/nn-objidl-istream) instance.

`puliMaxSize`\
[in, optional] The maximum size of the stream referenced by `ppIStream`.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** Fusion.h

**.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [IAssemblyCacheItem Interface](iassemblycacheitem-interface.md)
