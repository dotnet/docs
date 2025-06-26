---
description: "Learn more about: ComCallUnmarshal Coclass"
title: "ComCallUnmarshal Coclass"
ms.date: "03/30/2017"
api_name:
  - "ComCallUnmarshal Coclass"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ComCallUnmarshal"
helpviewer_keywords:
  - "ComCallUnmarshal coclass [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ComCallUnmarshal Coclass

Provides interfaces for managing the marshalling of interface pointers.

## Syntax

```cpp
coclass ComCallUnmarshal {
    [default] interface IMarshal;
};
```

## Interfaces

|Interface|Description|
|---------------|-----------------|
|`IMarshal`|Provides methods for creating, initializing, and managing a proxy in a client process.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.idl

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Hosting Coclasses](hosting-coclasses.md)
