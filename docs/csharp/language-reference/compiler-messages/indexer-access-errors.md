---
title: "Resolve errors and warnings related to indexer and element access"
description: "This article helps you diagnose and correct compiler errors and warnings related to indexer and element access"
f1_keywords:
  - "CS0021"
  - "CS0154"
  - "CS0271"
  - "CS0272"
  - "CS0856"
  - "CS0857"
  - "CS1545"
  - "CS1546"
  - "CS8428"
  - "CS8429"
helpviewer_keywords:
  - "CS0021"
  - "CS0154"
  - "CS0271"
  - "CS0272"
  - "CS0856"
  - "CS0857"
  - "CS1545"
  - "CS1546"
  - "CS8428"
  - "CS8429"
ms.date: 07/16/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings related to indexer and element access

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0021**](#indexing-non-indexable-types): *Cannot apply indexing with [] to an expression of type 'type'*
- [**CS0154**](#accessor-availability-and-accessibility): *The property or indexer 'indexer' cannot be used in this context because it lacks the get accessor*
- [**CS0271**](#accessor-availability-and-accessibility): *The property or indexer 'indexer' cannot be used in this context because the get accessor is inaccessible*
- [**CS0272**](#accessor-availability-and-accessibility): *The property or indexer 'indexer' cannot be used in this context because the set accessor is inaccessible*
- [**CS0856**](#indexed-properties-from-com-and-interop): *Indexed property 'indexer' has non-optional arguments which must be provided*
- [**CS0857**](#indexed-properties-from-com-and-interop): *Indexed property 'indexer' must have all arguments optional*
- [**CS1545**](#indexed-properties-from-com-and-interop): *Property, indexer, or event 'member' is not supported by the language; try directly calling accessor methods 'method' or 'method'*
- [**CS1546**](#indexed-properties-from-com-and-interop): *Property, indexer, or event 'member' is not supported by the language; try directly calling accessor method 'method'*
- [**CS8428**](#implicit-index-and-range-indexers): *Invocation of implicit Index Indexer cannot name the argument.*
- [**CS8429**](#implicit-index-and-range-indexers): *Invocation of implicit Range Indexer cannot name the argument.*

These diagnostics cover element access expressions such as `value[index]`, explicit indexers, indexed properties imported from metadata or COM interop, and the implicit `Index` and `Range` indexers used by the `^` and `..` operators.

## Indexing non-indexable types

- **CS0021**: *Cannot apply indexing with [] to an expression of type 'type'*

Use `[]` only with arrays, pointer types, or types that define an applicable indexer. If the type should support element access, add an indexer declaration to the type. Otherwise, call the member that retrieves the element, or convert the value to a type that supports indexing before using `[]`.

## Accessor availability and accessibility

- **CS0154**: *The property or indexer 'indexer' cannot be used in this context because it lacks the get accessor*
- **CS0271**: *The property or indexer 'indexer' cannot be used in this context because the get accessor is inaccessible*
- **CS0272**: *The property or indexer 'indexer' cannot be used in this context because the set accessor is inaccessible*

Reading an indexer requires an accessible `get` accessor. Writing an indexer requires an accessible `set` or `init` accessor. Add the missing accessor, change the accessor accessibility, or use the indexer only in contexts where the required accessor is available.

## Indexed properties from COM and interop

- **CS0856**: *Indexed property 'indexer' has non-optional arguments which must be provided*
- **CS0857**: *Indexed property 'indexer' must have all arguments optional*
- **CS1545**: *Property, indexer, or event 'member' is not supported by the language; try directly calling accessor methods 'method' or 'method'*
- **CS1546**: *Property, indexer, or event 'member' is not supported by the language; try directly calling accessor method 'method'*

Some metadata patterns, especially from COM or other .NET languages, expose indexed properties that C# can't bind with ordinary property or indexer syntax. Supply all required indexed property arguments when the metadata requires them (**CS0856**). When C# requires indexed property arguments to be optional, change the imported member or wrapper so all arguments are optional (**CS0857**).

For unsupported imported properties, indexers, or events, call the generated accessor method directly (**CS1545**, **CS1546**). For example, call `get_Prop(arguments)` or `set_Prop(arguments, value)` instead of using property syntax when the member can't be represented directly in C#.

## Implicit index and range indexers

- **CS8428**: *Invocation of implicit Index Indexer cannot name the argument.*
- **CS8429**: *Invocation of implicit Range Indexer cannot name the argument.*

The compiler can synthesize an indexer for the [index from end (`^`) and range (`..`) operators](../operators/member-access-operators.md#index-from-end-operator-) when a type has the required `Length` or `Count` member, an `int` indexer, or a compatible `Slice` method. Calls to those implicit `Index` or `Range` indexers must use positional arguments. Remove the argument name from the invocation and pass the `Index` or `Range` value positionally (**CS8428**, **CS8429**).

## Related diagnostics

For more information about array indexing and rank, see [Resolve errors and warnings related to array and collection declarations and initializations](array-declaration-errors.md) in C# compiler messages. For more information about argument lists, see [Errors and warnings for parameter / argument mismatches](parameter-argument-mismatch.md) in C# compiler messages. For more information about overload resolution for indexers and element access, see [Fix errors that involve overload resolution](overload-resolution.md) in C# compiler messages. For more information about read-only and init-only properties, see [Compiler Errors on property declarations](property-declaration-errors.md) in C# compiler messages. For more information about dynamic binding, see [Resolve errors related to dynamic binding and the dynamic type](dynamic-type-and-binding-errors.md) in C# compiler messages. For more information about indexer access in expression trees, see [Some expressions are prohibited in expression trees](expression-tree-restrictions.md) in C# compiler messages. For more information about inline array element access, see [Resolve errors related to inline arrays](inline-array-errors.md) in C# compiler messages.
