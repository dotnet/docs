---
title: Weak references
description: Weak references
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/19/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 22319f2f-0008-4ace-815e-545892a0512a
---

# Weak references

The garbage collector cannot collect an object in use by an application while the application's code can reach that object. The application is said to have a strong reference to the object. 

A weak reference permits the garbage collector to collect the object while still allowing the application to access the object. A weak reference is valid only during the indeterminate amount of time until the object is collected when no strong references exist. When you use a weak reference, the application can still obtain a strong reference to the object, which prevents it from being collected. However, there is always the risk that the garbage collector will get to the object first before a strong reference is reestablished.

Weak references are useful for objects that use a lot of memory, but can be recreated easily if they are reclaimed by garbage collection. 

Suppose a tree view displays a complex hierarchical choice of options to the user. If the underlying data is large, keeping the tree in memory is inefficient when the user is involved with something else in the application. 

When the user switches away to another part of the application, you can use the [WeakReference](xref:System.WeakReference) or [WeakReference&lt;T&gt;](xref:System.WeakReference%601) class to create a weak reference to the tree and destroy all strong references. When the user switches back to the tree, the application attempts to obtain a strong reference to the tree and, if successful, avoids reconstructing the tree.

To establish a weak reference with an object, you create a [WeakReference](xref:System.WeakReference) using the instance of the object to be tracked. You then set the [Target](xref:System.WeakReference.Target) property to that object and set the original reference to the object to null. 

## Short and Long Weak References

You can create a short weak reference or a long weak reference: 

* Short

  The target of a short weak reference becomes `null` when the object is reclaimed by garbage collection. The weak reference is itself a managed object, and is subject to garbage collection just like any other managed object. A short weak reference is the default constructor for [WeakReference](xref:System.WeakReference). 

* Long

  A long weak reference is retained after the object's [Finalize](xref:System.Object.Finalize) method has been called. This allows the object to be recreated, but the state of the object remains unpredictable. To use a long reference, specify `true` in the [WeakReference](xref:System.WeakReference) constructor. 

  If the object's type does not have a [Finalize](xref:System.Object.Finalize) method, the short weak reference functionality applies and the weak reference is valid only until the target is collected, which can occur anytime after the finalizer is run.

To establish a strong reference and use the object again, cast the [Target](xref:System.WeakReference.Target) property of a [WeakReference](xref:System.WeakReference) to the type of the object. If the [Target](xref:System.WeakReference.Target) property returns `null`, the object was collected; otherwise, you can continue to use the object because the application has regained a strong reference to it.

## Guidelines for Using Weak References

Use long weak references only when necessary as the state of the object is unpredictable after finalization. 

Avoid using weak references to small objects because the pointer itself may be as large or larger. 

Avoid using weak references as an automatic solution to memory management problems. Instead, develop an effective caching policy for handling your application's objects. 

## See Also

[Garbage collection in .NET](index.md)
