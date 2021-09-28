---
description: "Learn more about: IMethodMalloc::Alloc Method"
title: "IMethodMalloc::Alloc Method"
ms.date: "03/30/2017"
api_name:
  - "IMethodMalloc.Alloc"
api_location:
  - "mscorwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMethodMalloc::Alloc"
helpviewer_keywords:
  - "IMethodMalloc::Alloc method [.NET Framework profiling]"
  - "Alloc method, IMethodMalloc interface [.NET Framework profiling]"
ms.assetid: 8653bd4c-2290-43d2-a3e1-cbbd50033f4f
topic_type:
  - "apiref"
---

# IMethodMalloc::Alloc Method

Attempts to allocate a specified amount of memory for a new Microsoft intermediate language (MSIL) function body.

## Syntax

```cpp
PVOID Alloc (
    [in] ULONG   cb
);
```

## Parameters

`cb`\
[in] The number of bytes to allocate for the method body.

## Remarks

 The allocated memory will begin at an address greater than the base address of the module that is associated with this allocator. In other words, each allocator is created for a particular module, and will attempt to allocate memory at a positive offset from its base address. If `Alloc` fails to allocate the requested number of bytes at an address greater than the base address of the module, it returns NULL.

 The `Alloc` method should be used in conjunction with the [ICorProfilerInfo::SetILFunctionBody](icorprofilerinfo-setilfunctionbody-method.md) method.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorProf.idl, CorProf.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [IMethodMalloc Interface](imethodmalloc-interface.md)
