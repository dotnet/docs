---
title: Common Type System & Common Language Specification
description: Learn how the Common Type System (CTS) and Common Language Specification (CLS) make it possible for .NET to support multiple languages.
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 3b1f5725-ac94-4f17-8e5f-244442438a4d
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Common Type System & Common Language Specification

Again, two terms that are freely used in the .NET world, they actually are crucial to understand how a .NET implementation enables multi-language development and to understand how it works.

## Common Type System

To start from the beginning, remember that a .NET implementation is _language agnostic_. This doesn’t just mean that a programmer can write her code in any language that can be compiled to IL. It also means that she needs to be able to interact with code written in other languages that are able to be used on a .NET implementation.

In order to do this transparently, there has to be a common way to describe all supported types. This is what the Common Type System (CTS) is in charge of doing. It was made to do several things:

*   Establish a framework for cross-language execution.
*   Provide an object-oriented model to support implementing various languages on a .NET implementation.
*   Define a set of rules that all languages must follow when it comes to working with types.
*   Provide a library that contains the basic primitive types that are used in application development (such as, `Boolean`, `Byte`, `Char` etc.)

CTS defines two main kinds of types that should be supported: reference and value types. Their names point to their definitions.

Reference types’ objects are represented by a reference to the object’s actual value; a reference here is similar to a pointer in C/C++. It simply refers to a memory location where the objects’ values are. This has a profound impact on how these types are used. If you assign a reference type to a variable and then pass that variable into a method, for instance, any changes to the object will be reflected on the main object; there is no copying.

Value types are the opposite, where the objects are represented by their values. If you assign a value type to a variable, you are essentially copying a value of the object.

CTS defines several categories of types, each with their specific semantics and usage:

*   Classes
*   Structures
*   Enums
*   Interfaces
*   Delegates

CTS also defines all other properties of the types, such as access modifiers, what are valid type members, how inheritance and overloading works and so on. Unfortunately, going deep into any of those is beyond the scope of an introductory article such as this, but you can consult [More resources](#more-resources) section at the end for links to more in-depth content that covers these topics.

## Common Language Specification

To enable full interoperability scenarios, all objects that are created in code must rely on some commonality in the languages that are consuming them (are their _callers_). Since there are numerous different languages, .NET has specified those commonalities in something called the **Common Language Specification** (CLS). CLS defines a set of features that are needed by many common applications. It also provides a sort of recipe for any language that is implemented on top of .NET on what it needs to support.

CLS is a subset of the CTS. This means that all of the rules in the CTS also apply to the CLS, unless the CLS rules are more strict. If a component is built using only the rules in the CLS, that is, it exposes only the CLS features in its API, it is said to be **CLS-compliant**. For instance, the `<framework-librares>` are CLS-compliant precisely because they need to work across all of the languages that are supported on .NET.

You can consult the documents in the [More Resources](#more-resources) section below to get an overview of all the features in the CLS.

## More resources

*   [Common Type System](./base-types/common-type-system.md)
*   [Common Language Specification](language-independence-and-language-independent-components.md)
