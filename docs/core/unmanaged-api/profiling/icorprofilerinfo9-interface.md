---
description: "Learn more about: ICorProfilerInfo9 Interface"
title: "ICorProfilerInfo9 Interface"
ms.date: "08/06/2019"
author: "davmason"
ms.author: "davmason"
---
# ICorProfilerInfo9 interface

A subclass of [ICorProfilerInfo8](icorprofilerinfo8-interface.md) that provides methods to query information about functions with multiple native code versions.

## Methods

| Method|Description|
| ------------|-----------------|
|[GetNativeCodeStartAddresses Method](icorprofilerinfo9-getnativecodestartaddresses-method.md)| Given a `functionId` and `rejitId`, enumerates the native code start address of all jitted versions of this code that currently exist. |
|[GetILToNativeMapping3 Method](icorprofilerinfo9-getiltonativemapping3-method.md)| Given the native code start address, returns the native to IL mapping information for this jitted version of the code. |
|[GetCodeInfo4 Method](icorprofilerinfo9-getcodeinfo4-method.md)| Given the native code start address, returns the blocks of virtual memory that store this code. |

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md)
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** Available since .NET Core 2.1
