---
title: "Collections and Collection Types for XAML"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 58f8e7c6-9a41-4f25-8551-c042f1315baa
caps.latest.revision: 2
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Collections and Collection Types for XAML
This topic describes how to define properties of types that are intended to support a collection, and to support the XAML syntax for instantiating collection items as element children of a parent object element or property element.  
  
## XAML Collection Concepts  
 Conceptually, any relationship in XAML where there are multiple child items within the scope of a XAML object element or XAML property element must be implemented as a collection. That collection must be associated with a particular XAML property of the XAML type that is the parent in that relationship. The property must be a collection because a XAML processor expects to assign each item in markup to be a newly added item of the backing collection property.  
  
 At the XAML language level, the exact requirements of collection support are not fully defined. The concept that a collection can be either a list or a dictionary(but not both) is defined at the XAML language level, but which backing types represent either lists or dictionaries is not defined by the XAML language.  
  
 In .NET Framework XAML Services, the concept of XAML collection support is more clearly defined in terms of .NET Framework backing types. Specifically, the XAML support for collections is based on several .NET Framework concepts and APIs that are used for lists and dictionaries in general .NET Framework programming.  
  
1.  The <xref:System.Collections.IList> interface indicates a list collection.  
  
2.  The <xref:System.Collections.IDictionary> interface indicates a dicionary collection.  
  
3.  <xref:System.Array> represents an array, and an array supports <xref:System.Collections.IList> methods.  
  
 In each of these collection concepts, a .NET Framework XAML Services XAML processor expects to call the `Add` method on a specific instance of the collection property's type. Or, in a serialization scenario, a XAML processor produces discrete XAML-type instances for each item found in the list, dictionary or array based on each collection's specific concept of "Items". These are : <xref:System.Collections.IList.Item%2A>; <xref:System.Collections.IDictionary.Item%2A>; the explicit <xref:System.Array.System%23Collections%23IList%23Item%2A> for <xref:System.Array>.  
  
## Generic Collections  
 Generic collections can be useful for general .NET Framework programming, and can also be used for XAML collection properties. However, the generic interfaces <xref:System.Collections.Generic.IList%601> and <xref:System.Collections.Generic.IDictionary%602> are not identified by .NET Framework XAML Services XAML processors as being equivalent to the non-generic <xref:System.Collections.IList> or <xref:System.Collections.IDictionary>. Rather than implementing the interfaces, a recommended approach for generic collection property types is to derive from the classes <xref:System.Collections.Generic.List%601> or <xref:System.Collections.Generic.Dictionary%602>. These classes implement the non-generic interfaces and thus include the expected support for XAML collections in the base implementation.  
  
## Read-Only Collections and Initialization Logic  
 In .NET Framework programming, it is a common design pattern to make any property that holds a value of a collection as a read-only collection. This pattern permits the instance that owns the collection property to better control what happens to the collection.. Specifically, the pattern prevents accidental replacement of the entire pre-existing collection by setting the property. In this pattern, any access to the collection by callers should instead be made by calling methods or properties as supported by the collection type and/or the relevant collection interfaces such as <xref:System.Collections.IList>.  
  
 Using this pattern implies that any class that exposes a read-only collection property must first initialize that property to hold an empty collection. Typically the initialization is performed as part of the construction behavior for the class. To be useful for XAML, it is important that such logic is always referenced by the default constructor, because XAML generally calls the default constructor prior to processing the properties (collection properties or otherwise).  
  
## XAML Type System Support and Collections  
 Beyond the basic mechanics of parsing XAML and populating or serializing collection properties, the XAML type system as implemented in .NET Framework XAML Services includes several design features that pertain to collections in XAML.  
  
1.  <xref:System.Xaml.XamlType.IsCollection%2A> returns true if the XAML type is backed by a type that provides XAML collection support.  
  
2.  <xref:System.Xaml.XamlType.IsDictionary%2A> and <xref:System.Xaml.XamlType.IsArray%2A> can further identify which collection mode the XAML type supports. For custom XAML processors that are based on .NET Framework XAML Services and the XAML type system but not based on existing <xref:System.Xaml.XamlWriter> implementations, knowing which collection mode is used might be necessary in order to know which method to invoke for collection processing.  
  
3.  Each of the previous property values are potentially influenced by overrides of <xref:System.Xaml.XamlType.LookupCollectionKind%2A> on a XAML type.
