---
title: WMI and Performance Counters (Unmanaged API Reference) 
description: Summarizes the .NET Framework unmanaged API for WMI and performance counter information.
author: rpetrusha
ms.author: ronpet
manager: wpickett
ms.date: 11/06/2017
ms.topic: article-type-from-white-list
ms.prod: .net-framework
ms.devlang: cpp
---
# Windows Management Instrumentation (WMI) and Performance Counters (Unmanaged API Reference)

The .NET Framework WMI and Performance Counters unmanaged API consists of a set of functions that wrap calls to the [native Windows Management Instrumentation API](https://msdn.microsoft.com/en-us/library/aa389276(v=vs.85).aspx). It allows you to develop tools and libraries that manage and monitor remote computer systems.

The API includes the following functions:



|Function  | Description  |
|---------|---------|
|[BeginEnumeration](beginernumeration.md) | Resets the enumerator to the beginnining of an enumeration of WMI object properties. |
|[BeginMethodEnumeration](beginmethopdenumeration.md) |  Begins an enumeration of the methods available for an object. |
|[Clone](clone.md) | Returns a new object that is a complete clone of the current object. |


 ## See also
[Unmanaged API reference](../index.md) 