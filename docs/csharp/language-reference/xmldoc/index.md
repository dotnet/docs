---
title: "XML documentation comments - C# programming guide"
description: Learn about XML documentation comments. You can create documentation for your code by including XML elements in special comment fields.
ms.date: 07/20/2015
ms.topic: conceptual
f1_keywords:
  - "cs.xml"
helpviewer_keywords:
  - "XML [C#], code comments"
  - "comments [C#], XML"
  - "documentation comments [C#]"
  - "C# source code files"
  - "C# language, XML code comments"
  - "XML documentation comments [C#]"
ms.assetid: 803b7f7b-7428-4725-b5db-9a6cff273199
---
# XML documentation comments (C# programming guide)

In C#, you can create documentation for your code by including XML elements in special comment fields (indicated by triple slashes) in the source code directly before the code block to which the comments refer, for example.

```csharp
/// <summary>
///  This class performs an important function.
/// </summary>
public class MyClass {}
```

When you compile with the [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) option, the compiler will search for all XML tags in the source code and create an XML documentation file. To create the final documentation based on the compiler-generated file, you can create a custom tool or use a tool such as [DocFX](https://dotnet.github.io/docfx/) or [Sandcastle](https://github.com/EWSoftware/SHFB).

To refer to XML elements (for example, your function processes specific XML elements that you want to describe in an XML documentation comment), you can use the standard quoting mechanism (`<` and `>`).  To refer to generic identifiers in code reference (`cref`) elements, you can use either the escape characters (for example, `cref="List&lt;T&gt;"`) or braces (`cref="List{T}"`).  As a special case, the compiler parses the braces as angle brackets to make the documentation comment less cumbersome to author when referring to generic identifiers.

> [!NOTE]
> The XML documentation comments are not metadata; they are not included in the compiled assembly and therefore they are not accessible through reflection.

## In this section

- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)

- [Processing the XML file](./processing-the-xml-file.md)

- [Delimiters for documentation tags](./delimiters-for-documentation-tags.md)

- [How to use the XML documentation features](./how-to-use-the-xml-documentation-features.md)

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
- [**DocumentationFile** (C# compiler options)](../../language-reference/compiler-options/output.md#documentationfile)
- [XML documentation comments](./index.md)

# Delimiters for documentation tags (C# programming guide)

The use of XML doc comments requires delimiters, which indicate to the compiler where a documentation comment begins and ends. You can use the following kinds of delimiters with the XML documentation tags:

- `///`

  Single-line delimiter. This is the form that is shown in documentation examples and used by the C# project templates. If there is a white space character following the delimiter, that character is not included in the XML output.

  > [!NOTE]
  > The Visual Studio integrated development environment (IDE) automatically inserts the `<summary>` and `</summary>` tags and moves your cursor within these tags after you type the `///` delimiter in the code editor. You can turn this feature on or off in the [Options dialog box](/visualstudio/ide/reference/options-text-editor-csharp-advanced).
  
- `/** */`

  Multiline delimiters.

  There are some formatting rules to follow when you use the `/** */` delimiters:
  
  - On the line that contains the `/**` delimiter, if the remainder of the line is white space, the line is not processed for comments. If the first character after the `/**` delimiter is white space, that white space character is ignored and the rest of the line is processed. Otherwise, the entire text of the line after the `/**` delimiter is processed as part of the comment.

  - On the line that contains the `*/` delimiter, if there is only white space up to the `*/` delimiter, that line is ignored. Otherwise, the text on the line up to the `*/` delimiter is processed as part of the comment.
  
  - For the lines after the one that begins with the `/**` delimiter, the compiler looks for a common pattern at the beginning of each line. The pattern can consist of optional white space and an asterisk (`*`), followed by more optional white space. If the compiler finds a common pattern at the beginning of each line that does not begin with the `/**` delimiter or the `*/` delimiter, it ignores that pattern for each line.

  The following examples illustrate these rules.

  - The only part of the following comment that's processed is the line that begins with `<summary>`. The three tag formats produce the same comments.

    ```csharp
    /** <summary>text</summary> */

    /**
    <summary>text</summary>
    */

    /**
     * <summary>text</summary>
    */
    ```

  - The compiler identifies a common pattern of " \* " at the beginning of the second and third lines. The pattern is not included in the output.

    ```csharp
    /**
     * <summary>
     * text </summary>*/
    ```

  - The compiler finds no common pattern in the following comment because the second character on the third line is not an asterisk. Therefore, all text on the second and third lines is processed as part of the comment.

    ```csharp
    /**
     * <summary>
       text </summary>
    */
    ```

  - The compiler finds no pattern in the following comment for two reasons. First, the number of spaces before the asterisk is not consistent. Second, the fifth line begins with a tab, which does not match spaces. Therefore, all text from lines two through five is processed as part of the comment.

    <!-- markdownlint-disable MD010 -->
    ```csharp
    /**
      * <summary>
      * text
     *  text2
     	*  </summary>
    */
    ```
    <!-- markdownlint-enable MD010 -->

## See also

- [C# programming guide](../index.md)
- [XML documentation comments](./index.md)
- [**DocumentationFile** (C# compiler options)](../../language-reference/compiler-options/output.md#documentationfile)


## Related sections

For more information, see:

- [**DocumentationFile** (Process Documentation Comments)](../../language-reference/compiler-options/output.md#documentationfile)

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Programming Guide](../index.md)
