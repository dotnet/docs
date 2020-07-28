---
title: "Processing the XML file - C# programming guide"
description: Learn about processing the XML file in C# programming. See code examples and view additional available resources.
ms.date: 07/20/2015
helpviewer_keywords:
  - "XML processing [C#]"
  - "XML [C#], processing"
ms.assetid: 60c71193-9dac-4cd3-98c5-100bd0edcc42
---
# Process the XML file (C# programming guide)

The compiler generates an ID string for each construct in your code that's tagged to generate documentation. (For information about how to tag your code, see [Recommended Tags for Documentation Comments](./recommended-tags-for-documentation-comments.md).) The ID string uniquely identifies the construct. Programs that process the XML file can use the ID string to identify the corresponding .NET metadata or reflection item that the documentation applies to.

## ID strings

The XML file is not a hierarchical representation of your code. It's a flat list that has a generated ID for each element.

The compiler observes the following rules when it generates the ID strings:

- No white space is in the string.

- The first part of the string identifies the kind of member using a single character followed by a colon. The following member types are used:

    |Character|Member type|Notes|
    |---------------|-----------------|-|
    |N|namespace|You cannot add documentation comments to a namespace, but you can make cref references to them, where supported.|
    |T|type|A type can be a class, interface, struct, enum, or delegate.|
    |F|field|
    |P|property|Includes indexers or other indexed properties.|
    |M|method|Includes special methods, such as constructors and operators.|
    |E|event|
    |!|error string|The rest of the string provides information about the error. The C# compiler generates error information for links that cannot be resolved.|

- The second part of the string is the fully qualified name of the item, starting at the root of the namespace. The name of the item, its enclosing type(s), and namespace are separated by periods. If the name of the item itself has periods, they are replaced by the hash-sign ('#'). It's assumed that no item has a hash-sign directly in its name. For example, the fully qualified name of the String constructor is "System.String.#ctor".

- For properties and methods, the parameter list enclosed in parentheses follows. If there are no parameters, no parentheses are present. The parameters are separated by commas. The encoding of each parameter follows directly how it's encoded in a .NET signature:

  - Base types. Regular types (ELEMENT_TYPE_CLASS or ELEMENT_TYPE_VALUETYPE) are represented as the fully qualified name of the type.

  - Intrinsic types (for example, ELEMENT_TYPE_I4, ELEMENT_TYPE_OBJECT, ELEMENT_TYPE_STRING, ELEMENT_TYPE_TYPEDBYREF, and ELEMENT_TYPE_VOID) are represented as the fully qualified name of the corresponding full type. For example, System.Int32 or System.TypedReference.

  - ELEMENT_TYPE_PTR is represented as a '\*' following the modified type.

  - ELEMENT_TYPE_BYREF is represented as a '\@' following the modified type.

  - ELEMENT_TYPE_PINNED is represented as a '^' following the modified type. The C# compiler never generates this.

  - ELEMENT_TYPE_CMOD_REQ is represented as a '&#124;' and the fully qualified name of the modifier class, following the modified type. The C# compiler never generates this.

  - ELEMENT_TYPE_CMOD_OPT is represented as a '!' and the fully qualified name of the modifier class, following the modified type.

  - ELEMENT_TYPE_SZARRAY is represented as "[]" following the element type of the array.

  - ELEMENT_TYPE_GENERICARRAY is represented as "[?]" following the element type of the array. The C# compiler never generates this.

  - ELEMENT_TYPE_ARRAY is represented as [*lowerbound*:`size`,*lowerbound*:`size`] where the number of commas is the rank - 1, and the lower bounds and size of each dimension, if known, are represented in decimal. If a lower bound or size is not specified, it's omitted. If the lower bound and size for a particular dimension are omitted, the ':' is omitted as well. For example, a 2-dimensional array with 1 as the lower bounds and unspecified sizes is [1:,1:].

  - ELEMENT_TYPE_FNPTR is represented as "=FUNC:`type`(*signature*)", where `type` is the return type, and *signature* is the arguments of the method. If there are no arguments, the parentheses are omitted. The C# compiler never generates this.

  The following signature components aren't represented because they aren't used to differentiate overloaded methods:

  - calling convention

  - return type

  - ELEMENT_TYPE_SENTINEL

- For conversion operators only (`op_Implicit` and `op_Explicit`), the return value of the method is encoded as a '~' followed by the return type.

- For generic types, the name of the type is followed by a backtick and then a number that indicates the number of generic type parameters. For example:

     ``<member name="T:SampleClass`2">`` is the tag for a type that is defined as `public class SampleClass<T, U>`.

     For methods that take generic types as parameters, the generic type parameters are specified as numbers prefaced with backticks (for example \`0,\`1). Each number represents a zero-based array notation for the type's generic parameters.

## Examples

The following examples show how the ID strings for a class and its members are generated:

[!code-csharp[csProgGuidePointers#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers.cs#21)]

## See also

- [C# programming guide](../index.md)
- [-doc (C# compiler options)](../../language-reference/compiler-options/doc-compiler-option.md)
- [XML documentation comments](./index.md)
