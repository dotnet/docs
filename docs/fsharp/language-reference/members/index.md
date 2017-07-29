---
title: Members (F#)
description: Learn about object members in the F# programming language.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: e472f50a-4939-4e62-abbc-471f8f265790
---

# Members

This section describes members of F# object types.


## Remarks
*Members* are features that are part of a type definition and are declared with the `member` keyword. F# object types such as records, classes, discriminated unions, interfaces, and structures support members. For more information, see [Records](../records.md), [Classes](../classes.md), [Discriminated Unions](../discriminated-Unions.md), [Interfaces](../interfaces.md), and [Structures](../structures.md).

Members typically make up the public interface for a type, which is why they are public unless otherwise specified. Members can also be declared private or internal. For more information, see [Access Control](../access-Control.md). Signatures for types can also be used to expose or not expose certain members of a type. For more information, see [Signatures](../signatures.md).

Private fields and `do` bindings, which are used only with classes, are not true members, because they are never part of the public interface of a type and are not declared with the `member` keyword, but they are described in this section also.


## Related Topics


|Topic|Description|
|-----|-----------|
|[`let` Bindings in Classes](let-bindings-in-classes.md)|Describes the definition of private fields and functions in classes.|
|[`do` Bindings in Classes](do-bindings-in-classes.md)|Describes the specification of object initialization code.|
|[Properties](properties.md)|Describes property members in classes and other types.|
|[Indexed Properties](indexed-properties.md)|Describes array-like properties in classes and other types.|
|[Methods](methods.md)|Describes functions that are members of a type.|
|[Constructors](constructors.md)|Describes special functions that initialize objects of a type.|
|[Operator Overloading](../operator-overloading.md)|Describes the definition of customized operators for types.|
|[Events](events.md)|Describes the definition of events and event handling support in F#.|
|[Explicit Fields: The `val` Keyword](explicit-fields-the-val-keyword.md)|Describes the definition of uninitialized fields in a type.|
