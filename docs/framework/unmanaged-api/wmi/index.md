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

The .NET Framework WMI and Performance Counters unmanaged API consists of a set of functions that wrap calls to the [native Windows Management Instrumentation API](https://msdn.microsoft.com/library/aa389276(v=vs.85).aspx). It allows you to develop tools and libraries that manage and monitor remote computer systems.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
The API includes the following functions:

| Function | Description |
|---------|---------|
| [BeginEnumeration function](beginenumeration.md) | Resets the enumerator to the beginning of an enumeration of WMI object properties. |
| [BeginMethodEnumeration function](beginmethodenumeration.md) |  Begins an enumeration of the methods available for an object. |
| [Clone function](clone.md) | Returns a new object that is a complete clone of the current object. |
| [CompareTo function](compareto.md) | Compares an object to another Windows management object. |
| [Delete function](delete.md) | Deletes a specified property from a class definition and all of its qualifiers. |
| [DeleteMethod function](deletemethod.md) | Deletes a specified method from a CIM class definition. |
| [EndEnumeration function](endenumeration.md) | Terminates an enumeration sequence. | 
| [EndMethodEnumeration function](endmethodenumeration.md) | Terminates an enumeration sequence started with a call to the  [BeginMethodEnumeration function](beginmethodenumeration.md). |
| [BeginMethodEnumeration function](beginmethodenumeration.md). |
| [Get function](get.md) | Retrieves a specified property value if it exists. |
| [GetMethod function](getmethod.md) | Retrieves information about the specified method. | 
| [GetMethodOrigin function](getmethodorigin.md) | Determines the class in which a method is declared. |
| [GetMethodQualifierSet function](getmethodqualifierset.md) | Retrieves the qualifier set for a particular method. |
| [GetNames function](getnames.md) | Retrieves either a subset or all of the names of the properties of an object. |
| [GetObjectText function](getobjecttext.md) | Returns a textual rendering of an object in the MOF syntax. | 
| [GetPropertyOrigin function](getpropertyorigin.md) | Determines the class in which a property is declared. |
| [GetPropertyQualifierSet function](getpropertyqualifierset.md) | Retrieves the qualifier set for a particular property.  |
| [GetQualifierSet function](getqualifierset.md) | Retrieves the qualifier set for a class instance or a class definition. |
| [InheritsFrom function](inheritsfrom.md) | Determines whether the current class or instance derives from a specified parent class. |
| [Next function](next.md) | Retrieves the next property in an enumeration. | 
| [NextMethod function](nextmethod.md) | Retrieves the next method in an enumeration. |
| [Put function](put.md) | Sets a named property to a new value. |
| [PutMethod function](putmethod.md) | Creates a method. |
| [SpawnDerivedClass function](spawnderivedclass.md) | Creates a newly derived class object from a specified object. | 
| [SpawnInstance function](spawninstance.md) | Creates a new instance of a class. |   


 ## See also
[Unmanaged API reference](../index.md) 