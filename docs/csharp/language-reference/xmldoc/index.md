---
title: "XML documentation comments - document APIs using /// comments"
description: Learn about XML documentation comments. You can create documentation for your code by including XML elements in special comment fields. You can use other tools to build documentation layouts from comments.
ms.date: 06/17/2021
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
# XML documentation comments

C# source files can have structured comments that produce API documentation for the types defined in those files. The C# compiler produces an *XML* file that contains structured data representing the comments and the API signatures. Other tools can process that XML output to create human-readable documentation in the form of web pages or PDF files, for example.

This process provides many advantages for you to add API documentation in your code:

- The C# compiler combines the structure of the C# code with the text of the comments into a single XML document.
- The C# compiler verifies that the comments match the API signatures for relevant tags.
- Tools that process the XML documentation files can define XML elements and attributes specific to those tools.

Tools like Visual Studio provide IntelliSense for many common XML elements used in documentation comments.

This article covers these topics:

- Documentation comments and XML file generation
- Tags validated by the C# compiler and Visual Studio
- Format of the generated XML file

## Create XML documentation output

You create documentation for your code by writing special comment fields indicated by triple slashes. The comment fields include XML elements that describe the code block that follows the comments. For example:

```csharp
/// <summary>
///  This class performs an important function.
/// </summary>
public class MyClass {}
```

You set either the [**GenerateDocumentationFile**](../../../core/project-sdk/msbuild-props.md#generatedocumentationfile) or [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) option, and the compiler will find all comment fields with XML tags in the source code and create an XML documentation file from those comments. When this option is enabled, the compiler generates the [CS1591](../compiler-messages/cs1591.md) warning for any publicly visible member declared in your project without XML documentation comments.

## XML comment formats

The use of XML doc comments requires delimiters that indicate where a documentation comment begins and ends. You use the following delimiters with the XML documentation tags:

- `///` Single-line delimiter: The documentation examples and C# project templates use this form. If there's white space following the delimiter, it isn't included in the XML output.
  > [!NOTE]
  > Visual Studio automatically inserts the `<summary>` and `</summary>` tags and positions your cursor within these tags after you type the `///` delimiter in the code editor. You can turn this feature on or off in the [Options dialog box](/visualstudio/ide/reference/options-text-editor-csharp-advanced).
- `/** */` Multiline delimiters: The `/** */` delimiters have the following formatting rules:
  - On the line that contains the `/**` delimiter, if the rest of the line is white space, the line isn't processed for comments. If the first character after the `/**` delimiter is white space, that white-space character is ignored and the rest of the line is processed. Otherwise, the entire text of the line after the `/**` delimiter is processed as part of the comment.
  - On the line that contains the `*/` delimiter, if there's only white space up to the `*/` delimiter, that line is ignored. Otherwise, the text on the line up to the `*/` delimiter is processed as part of the comment.
  - For the lines after the one that begins with the `/**` delimiter, the compiler looks for a common pattern at the beginning of each line. The pattern can consist of optional white space and an asterisk (`*`), followed by more optional white space. If the compiler finds a common pattern at the beginning of each line that doesn't begin with the `/**` delimiter or end with the `*/` delimiter, it ignores that pattern for each line.
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

  - The compiler identifies a common pattern of " \* " at the beginning of the second and third lines. The pattern isn't included in the output.

    ```csharp
    /**
     * <summary>
     * text </summary>*/
    ```

  - The compiler finds no common pattern in the following comment because the second character on the third line isn't an asterisk. All text on the second and third lines is processed as part of the comment.

    ```csharp
    /**
     * <summary>
       text </summary>
    */
    ```

  - The compiler finds no pattern in the following comment for two reasons. First, the number of spaces before the asterisk isn't consistent. Second, the fifth line begins with a tab, which doesn't match spaces. All text from lines two through five is processed as part of the comment.

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

To refer to XML elements (for example, your function processes specific XML elements that you want to describe in an XML documentation comment), you can use the standard quoting mechanism (`&lt;` and `&gt;`).  To refer to generic identifiers in code reference (`cref`) elements, you can use either the escape characters (for example, `cref="List&lt;T&gt;"`) or braces (`cref="List{T}"`).  As a special case, the compiler parses the braces as angle brackets to make the documentation comment less cumbersome to author when referring to generic identifiers.

> [!NOTE]
> The XML documentation comments are not metadata; they are not included in the compiled assembly and therefore they are not accessible through reflection.

## Tools that accept XML documentation input

The following tools create output from XML comments:

- [DocFX](https://dotnet.github.io/docfx/): *DocFX* is an API documentation generator for .NET, which currently supports C#, Visual Basic, and F#. It also allows you to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files. Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. You can also create custom templates.
- [Sandcastle](https://github.com/EWSoftware/SHFB): The *Sandcastle tools* create help files for managed class libraries containing both conceptual and API reference pages. The Sandcastle tools are command-line based and have no GUI front-end, project management features, or automated build process. The Sandcastle Help File Builder provides standalone GUI and command-line based tools to build a help file in an automated fashion. A Visual Studio integration package is also available for it so that help projects can be created and managed entirely from within Visual Studio.
- [Doxygen](https://github.com/doxygen/doxygen): *Doxygen* generates an on-line documentation browser (in HTML) or an off-line reference manual (in LaTeX) from a set of documented source files. There's also support for generating output in RTF (MS Word), PostScript, hyperlinked PDF, compressed HTML, DocBook, and Unix man pages. You can configure Doxygen to extract the code structure from undocumented source files.

### ID strings

Each type or member is stored in an element in the output XML file. Each of those elements has a unique ID string that identifies the type or member. The ID string must account for operators, parameters, return values, generic type parameters, `ref`, `in`, and `out` parameters. To encode all those potential elements, the compiler follows clearly defined rules for generating the ID strings. Programs that process the XML file use the ID string to identify the corresponding .NET metadata or reflection item that the documentation applies to.

The compiler observes the following rules when it generates the ID strings:

- No white space is in the string.
- The first part of the string identifies the kind of member using a single character followed by a colon. The following member types are used:

  |Character|Member type|Notes|
  |---------------|-----------------|-|
  |N|namespace|You can't add documentation comments to a namespace, but you can make cref references to them, where supported.|
  |T|type|A type is a class, interface, struct, enum, or delegate.|
  |F|field|
  |P|property|Includes indexers or other indexed properties.|
  |M|method|Includes special methods, such as constructors and operators.|
  |E|event|
  |!|error string|The rest of the string provides information about the error. The C# compiler generates error information for links that cannot be resolved.|

- The second part of the string is the fully qualified name of the item, starting at the root of the namespace. The name of the item, its enclosing type(s), and namespace are separated by periods. If the name of the item itself has periods, they're replaced by the hash-sign ('#'). It's assumed that no item has a hash-sign directly in its name. For example, the fully qualified name of the String constructor is "System.String.#ctor".
- For properties and methods, the parameter list enclosed in parentheses follows. If there are no parameters, no parentheses are present. The parameters are separated by commas. The encoding of each parameter follows directly how it's encoded in a .NET signature (See <xref:Microsoft.VisualStudio.CorDebugInterop.CorElementType?displayProperty=fullName> for definitions of the all caps elements in the following list):
  - Base types. Regular types (`ELEMENT_TYPE_CLASS` or `ELEMENT_TYPE_VALUETYPE`) are represented as the fully qualified name of the type.
  - Intrinsic types (for example, `ELEMENT_TYPE_I4`, `ELEMENT_TYPE_OBJECT`, `ELEMENT_TYPE_STRING`, `ELEMENT_TYPE_TYPEDBYREF`, and `ELEMENT_TYPE_VOID`) are represented as the fully qualified name of the corresponding full type. For example, `System.Int32` or `System.TypedReference`.
  - `ELEMENT_TYPE_PTR` is represented as a '\*' following the modified type.
  - `ELEMENT_TYPE_BYREF` is represented as a '\@' following the modified type.
  - `ELEMENT_TYPE_CMOD_OPT` is represented as a '!' and the fully qualified name of the modifier class, following the modified type.
  - `ELEMENT_TYPE_SZARRAY` is represented as "[]" following the element type of the array.
  - `ELEMENT_TYPE_ARRAY` is represented as [*lowerbound*:`size`,*lowerbound*:`size`] where the number of commas is the rank - 1, and the lower bounds and size of each dimension, if known, are represented in decimal. If a lower bound or size isn't specified, it's omitted. If the lower bound and size for a particular dimension are omitted, the ':' is omitted as well. For example, a two-dimensional array with 1 as the lower bounds and unspecified sizes is [1:,1:].
- For conversion operators only (`op_Implicit` and `op_Explicit`), the return value of the method is encoded as a `~` followed by the return type. For example:
     `<member name="M:System.Decimal.op_Explicit(System.Decimal arg)~System.Int32">` is the tag for the cast operator `public static explicit operator int (decimal value);` declared in the `System.Decimal` class.
- For generic types, the name of the type is followed by a backtick and then a number that indicates the number of generic type parameters. For example:
     `<member name="T:SampleClass``2">` is the tag for a type that is defined as `public class SampleClass<T, U>`.
     For methods that take generic types as parameters, the generic type parameters are specified as numbers prefaced with backticks (for example \`0,\`1). Each number represents a zero-based array notation for the type's generic parameters.
  - `ELEMENT_TYPE_PINNED` is represented as a '^' following the modified type. The C# compiler never generates this encoding.
  - `ELEMENT_TYPE_CMOD_REQ` is represented as a '&#124;' and the fully qualified name of the modifier class, following the modified type. The C# compiler never generates this encoding.
  - `ELEMENT_TYPE_GENERICARRAY` is represented as "[?]" following the element type of the array. The C# compiler never generates this encoding.
  - `ELEMENT_TYPE_FNPTR` is represented as "=FUNC:`type`(*signature*)", where `type` is the return type, and *signature* is the arguments of the method. If there are no arguments, the parentheses are omitted. The C# compiler never generates this encoding.
  - The following signature components aren't represented because they aren't used to differentiate overloaded methods:
    - calling convention
    - return type
    - `ELEMENT_TYPE_SENTINEL`

The following examples show how the ID strings for a class and its members are generated:

:::code language="csharp" source="./snippets/xmldoc/idstrings.cs":::

## C# language specification

For more information, see the [C# Language Specification](~/_csharplang/spec/documentation-comments.md) annex on documentation comments.
