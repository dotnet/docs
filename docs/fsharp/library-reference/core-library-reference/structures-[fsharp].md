---
title: Structures (F#)
description: Structures (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 50819506-3210-418f-9602-0ee1c9a52177
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/structures 
---

# Structures (F#)

A *structure* is a compact object type that can be more efficient than a class for types that have a small amount of data and simple behavior.


## Syntax

```fsharp
[ attributes ]
type [accessibility-modifier] type-name =
struct
type-definition-elements
end
// or
[ attributes ]
[<StructAttribute>]
type [accessibility-modifier] type-name =
type-definition-elements
```

## Remarks
Structures are *value types*, which means that they are stored directly on the stack or, when they are used as fields or array elements, inline in the parent type. Unlike classes and records, structures have pass-by-value semantics. This means that they are useful primarily for small aggregates of data that are accessed and copied frequently.

In the previous syntax, two forms are shown. The first is not the lightweight syntax, but it is nevertheless frequently used because, when you use the `struct` and `end` keywords, you can omit the `StructAttribute` attribute, which appears in the second form. You can abbreviate `StructAttribute` to just `Struct`.

The *type-definition-elements* in the previous syntax represents member declarations and definitions. Structures can have constructors and mutable and immutable fields, and they can declare members and interface implementations. For more information, see [Members &#40;F&#35;&#41;](Members-%5BFSharp%5D.md).

Structures cannot participate in inheritance, cannot contain `let` or `do` bindings, and cannot recursively contain fields of their own type (although they can contain reference cells that reference their own type).

Because structures do not allow `let` bindings, you must declare fields in structures by using the `val` keyword. The `val` keyword defines a field and its type but does not allow initialization. Instead, `val` declarations are initialized to zero or null. For this reason, structures that have an implicit constructor (that is, parameters that are given immediately after the structure name in the declaration) require that `val` declarations be annotated with the `DefaultValue` attribute. Structures that have a defined constructor still support zero-initialization. Therefore, the `DefaultValue` attribute is a declaration that such a zero value is valid for the field. Implicit constructors for structures do not perform any actions because `let` and `do` bindings aren’t allowed on the type, but the implicit constructor parameter values passed in are available as private fields.

Explicit constructors might involve initialization of field values. When you have a structure that has an explicit constructor, it still supports zero-initialization; however, you do not use the `DefaultValue` attribute on the `val` declarations because it conflicts with the explicit constructor. For more information about `val` declarations, see [Explicit Fields: The val Keyword &#40;F&#35;&#41;](Explicit-Fields-The-val-Keyword-%5BFSharp%5D.md).

Attributes and accessibility modifiers are allowed on structures, and follow the same rules as those for other types. For more information, see [Attributes &#40;F&#35;&#41;](Attributes-%5BFSharp%5D.md) and [Access Control &#40;F&#35;&#41;](Access-Control-%5BFSharp%5D.md).

The following code examples illustrate structure definitions.

[!code-fsharp[Main](snippets/fslangref1/snippet2501.fs)]
    
## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Classes &#40;F&#35;&#41;](Classes-%5BFSharp%5D.md)

[Records &#40;F&#35;&#41;](Records-%5BFSharp%5D.md)

[Members &#40;F&#35;&#41;](Members-%5BFSharp%5D.md)