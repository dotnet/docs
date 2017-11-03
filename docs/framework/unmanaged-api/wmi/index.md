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

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
The API includes the following functions:

| Function | Description |
|---------|---------|
| [BeginEnumeration function](beginenumeration.md) | Resets the enumerator to the beginning of an enumeration of WMI object properties. |
| [BeginMethodEnumeration function](beginmethopenumeration.md) |  Begins an enumeration of the methods available for an object. |
| [Clone function](clone.md) | Returns a new object that is a complete clone of the current object. |
| [CompareTo function](compareto.md) | Compares an object to another Windows management object. |
| [Delete function](delete.md) | Deletes a specified property from a class definition and all of its qualifiers. |
| [DeleteMethod function](deletemethod.md) | Deletes a specified method from a CIM class definition. |
| [EndEnumeration function](endenumeration.md) | Terminates an enumeration sequence. | 
| [EndMethodEnumeration function](endmethodenumeration.md) | Terminates an enumeration sequence started with a call to the  [BeginMethodEnumeration function](beginmethodenumeration.md). |
| [BeginMethodEnumeration function](beginmethodenumeration.md). |
| [Get function](get.md) | Retrieves a specified property value if it exists. |
| [GetMethod function](getmethod.md) | Retrieves information about the specified method. | 
| [GetMethodOrigin function](getmethodorigin.md) | Determines the class in which a method was declared. |
| [GetMethodQualifierSet function](getmethodqualifierset.md) | Retrieves the qualifier set for a particular method. |
| [GetNames function](getnames.md) | Retrieves either a subset or all of the names of the properties of an object. |
| [GetObjectText function](getobjecttext.md) | Returns a textual rendering of an object in the MOF syntax. | 

 ## See also
[Unmanaged API reference](../index.md) 