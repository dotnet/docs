---
title: Members (F#)
description: Members (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e472f50a-4939-4e62-abbc-471f8f265790
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/members/index
---

# Members (F#)

This section describes members of F# object types.


## Remarks
*Members* are features that are part of a type definition and are declared with the `member` keyword. F# object types such as records, classes, discriminated unions, interfaces, and structures support members. For more information, see [Records &#40;F&#35;&#41;](Records-%5BFSharp%5D.md), [Classes &#40;F&#35;&#41;](Classes-%5BFSharp%5D.md), [Discriminated Unions &#40;F&#35;&#41;](Discriminated-Unions-%5BFSharp%5D.md), [Interfaces &#40;F&#35;&#41;](Interfaces-%5BFSharp%5D.md), and [Structures &#40;F&#35;&#41;](Structures-%5BFSharp%5D.md).

Members typically make up the public interface for a type, which is why they are public unless otherwise specified. Members can also be declared private or internal. For more information, see [Access Control &#40;F&#35;&#41;](Access-Control-%5BFSharp%5D.md). Signatures for types can also be used to expose or not expose certain members of a type. For more information, see [Signatures &#40;F&#35;&#41;](Signatures-%5BFSharp%5D.md).

Private fields and `do` bindings, which are used only with classes, are not true members, because they are never part of the public interface of a type and are not declared with the `member` keyword, but they are described in this section also.


## Related Topics


|Topic|Description|
|-----|-----------|
|[let Bindings in Classes &#40;F&#35;&#41;](let-Bindings-in-Classes-%5BFSharp%5D.md)|Describes the definition of private fields and functions in classes.|
|[do Bindings in Classes &#40;F&#35;&#41;](do-Bindings-in-Classes-%5BFSharp%5D.md)|Describes the specification of object initialization code.|
|[Properties &#40;F&#35;&#41;](Properties-%5BFSharp%5D.md)|Describes property members in classes and other types.|
|[Indexed Properties &#40;F&#35;&#41;](Indexed-Properties-%5BFSharp%5D.md)|Describes array-like properties in classes and other types.|
|[Methods &#40;F&#35;&#41;](Methods-%5BFSharp%5D.md)|Describes functions that are members of a type.|
|[Constructors &#40;F&#35;&#41;](Constructors-%5BFSharp%5D.md)|Describes special functions that initialize objects of a type.|
|[Operator Overloading &#40;F&#35;&#41;](Operator-Overloading-%5BFSharp%5D.md)|Describes the definition of customized operators for types.|
|[Events &#40;F&#35;&#41;](Events-%5BFSharp%5D.md)|Describes the definition of events and event handling support in F#.|
|[Explicit Fields: The val Keyword &#40;F&#35;&#41;](Explicit-Fields-The-val-Keyword-%5BFSharp%5D.md)|Describes the definition of uninitialized fields in a type.|
