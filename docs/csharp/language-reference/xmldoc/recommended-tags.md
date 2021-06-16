---
title: "Recommended XML documentation tags for a class and its members"
description: This article provides the syntax and definitions for recommended tags for XML documentation.
ms.date: 06/16/2021
ms.topic: conceptual
f1_keywords:
  - "<summary>"
  - "summary"
  - "remarks"
  - "<remarks>"
  - "returns"
  - "<returns>"
  - "param"
  - "<param>"
  - "paramref"
  - "<paramref>"
  - "<value>"
  - "exception"
  - "<exception>"
  - "typeparam"
  - "typeparamref"
  - "inheritdoc"
  - "<inheritdoc>"
  - "include"
  - "<include>"
  - "c"
  - "<c>"
  - "code"
  - "<code>"
  - "<example>"
  - "example"
  - "list"
  - "<list>"
  - "<para>"
  - "para"
  - "<see>"
  - "see"
  - "<seealso>"
  - "seealso"
  - "permission"
  - "<permission>"
helpviewer_keywords:
  - "XML [C#], tags"
  - "XML documentation [C#], tags"
  - "C# language, XML documentation features"
  - "<summary> C# XML tag"
  - "summary C# XML tag"
  - "remarks C# XML tag"
  - "<remarks> C# XML tag"
  - "<returns> C# XML tag"
  - "returns C# XML tag"
  - "<param> C# XML tag"
  - "param C# XML tag"
  - "<paramref> C# XML tag"
  - "paramref C# XML tag"
  - "<value> C# XML tag"
  - "value C# XML tag"
  - "cref [C#]"
  - "<exception> C# XML tag"
  - "exception C# XML tag"
  - "<typeparam> C# XML tag"
  - "typeparam C# XML tag"
  - "typeparamref C# XML tag"
  - "<typeparamref> C# XML tag"
  - "<inheritdoc> C# XML tag"
  - "inheritdoc C# XML tag"
  - "<include> C# XML tag"
  - "include C# XML tag"
  - "text, marking as code [C#]"
  - "code, marking text as [C#]"
  - "c C# XML tag"
  - "<c> C# XML tag"
  - "code XML tag"
  - "<code> C# XML tag"
  - "<example> C# XML tag"
  - "example C# XML tag"
  - "list C# XML tag"
  - "listheader C# XML tag"
  - "<listheader> C# XML tag"
  - "item C# XML tag"
  - "<item> C# XML tag"
  - "<list> C# XML tag"
  - "<para> C# XML tag"
  - "para C# XML tag"
  - "cref [C#], <see> tag"
  - "<see> C# XML tag"
  - "cross-references [C#]"
  - "see C# XML tag"
  - "cref"
  - "cref [C#], see also"
  - "seealso C# XML tag"
  - "cref [C#]"
  - "cross-references [C#], tags"
  - "<seealso> C# XML tag"
  - "<permission> C# XML tag"
  - "permission C# XML tag"
---
# Recommend XML tags for documenting a non-generic class and its members

The compiler will process any tag that is valid XML. The tags described in this article provide generally used functionality in user documentation. The compiler verifies the syntax of the following XML elements in comments:

- `<exception>`
- `<include>`
- `<param>`
- `<permission>`
- `<see>`
- `<seealso>`
- `<typeparam>`

Visual Studio provides intellisense for the tags verified by the compiler and the following additional tags:

- `<example>`
- `<inheritdoc>`
- `<remarks>`

> [!NOTE]
> Documentation comments cannot be applied to a namespace.

If you want angle brackets to appear in the text of a documentation comment, use the HTML encoding of `<` and `>` which is `&lt;` and `&gt;` respectively. This encoding is shown in the following example.

```csharp
/// <summary>
/// This property always returns a value &lt; 1.
/// </summary>
```

## \<summary>

```xml
<summary>description</summary>
```

The `<summary>` tag should be used to describe a type or a type member. Use [\<remarks>](./remarks.md) to add supplemental information to a type description. Use the [cref Attribute](./cref-attribute.md) to enable documentation tools such as [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) to create internal hyperlinks to documentation pages for code elements.

The text for the `<summary>` tag is the only source of information about the type in IntelliSense, and is also displayed in the Object Browser Window.

Compile with [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) to process documentation comments to a file. To create the final documentation based on the compiler-generated file, you can create a custom tool, or use a tool such as [DocFX](https://dotnet.github.io/docfx/) or [Sandcastle](https://github.com/EWSoftware/SHFB).

[!code-csharp[csProgGuideDocComments#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#12)]

The previous example produces the following XML file.

```xml
<?xml version="1.0"?>
<doc>
    <assembly>
        <name>YourNamespace</name>
    </assembly>
    <members>
        <member name="T:TestClass">
            text for class TestClass
        </member>
        <member name="M:TestClass.DoWork(System.Int32)">
            <summary>DoWork is a method in the TestClass class.
            <para>Here's how you could make a second paragraph in a description. <see cref="M:System.Console.WriteLine(System.String)"/> for information about output statements.</para>
            </summary>
            <seealso cref="M:TestClass.Main"/>
        </member>
        <member name="M:TestClass.Main">
            text for Main
        </member>
    </members>
</doc>
```

### cref

The following example shows how to make a `cref` reference to a generic type.

[!code-csharp[csProgGuideDocComments#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#11)]

The previous example produces the following XML file.

```xml
<?xml version="1.0"?>
<doc>
    <assembly>
        <name>CRefTest</name>
    </assembly>
    <members>
        <member name="T:A">
            <summary cref="T:C`1">
            </summary>
        </member>
        <member name="T:B">
            <summary cref="T:C`1">
            </summary>
        </member>
        <member name="T:C`1">
            <summary cref="T:A">
            </summary>
            <typeparam name="T"></typeparam>
        </member>
    </members>
</doc>
```

## \<remarks>

```xml
<remarks>description</remarks>
```

The `<remarks>` tag is used to add information about a type, supplementing the information specified with [\<summary>](./summary.md). This information is displayed in the Object Browser window.

[!code-csharp[csProgGuideDocComments#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#9)]

## \<returns> (C# programming guide)

```xml
<returns>description</returns>
```

The `<returns>` tag should be used in the comment for a method declaration to describe the return value.

[!code-csharp[csProgGuideDocComments#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#10)]

## \<param> (C# programming guide)

```xml
<param name="name">description</param>
```

- `name`: The name of a method parameter. Enclose the name in double quotation marks (" ").

The `<param>` tag should be used in the comment for a method declaration to describe one of the parameters for the method. To document multiple parameters, use multiple `<param>` tags.

The text for the `<param>` tag is displayed in IntelliSense, the Object Browser, and the Code Comment Web Report.

[!code-csharp[csProgGuideDocComments#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#1)]

## \<paramref> (C# programming guide)

```xml
<paramref name="name"/>
```

- `name`: The name of the parameter to refer to. Enclose the name in double quotation marks (" ").

The `<paramref>` tag gives you a way to indicate that a word in the code comments, for example in a `<summary>` or `<remarks>` block refers to a parameter. The XML file can be processed to format this word in some distinct way, such as with a bold or italic font.

[!code-csharp[csProgGuideDocComments#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#7)]

## \<value> (C# programming guide)

```xml
<value>property-description</value>
```

The `<value>` tag lets you describe the value that a property represents. When you add a property via code wizard in the Visual Studio .NET development environment, it adds a [\<summary>](./summary.md) tag for the new property. You should then manually add a `<value>` tag to describe the value that the property represents.

[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#14)]

## cref attribute (C# programming guide)

The `cref` attribute in an XML documentation tag means "code reference." It specifies that the inner text of the tag is a code element, such as a type, method, or property. Documentation tools like [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) use the `cref` attributes to automatically generate hyperlinks to the page where the type or member is documented.

The following example shows `cref` attributes used in [\<see>](./see.md) tags.

[!code-csharp[csProgGuideDocComments#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#3)]

When compiled, the program produces the following XML file. Notice that the `cref` attribute for the `GetZero` method, for example, has been transformed by the compiler to `"M:TestNamespace.TestClass.GetZero"`. The "M:" prefix means "method" and is a convention that is recognized by documentation tools such as DocFX and Sandcastle. For a complete list of prefixes, see [Processing the XML File](./processing-the-xml-file.md).

```xml  
<?xml version="1.0"?>
<doc>
    <assembly>
        <name>CRefTest</name>
    </assembly>
    <members>
        <member name="T:TestNamespace.TestClass">
            <summary>
            TestClass contains several cref examples.
            </summary>
        </member>
        <member name="M:TestNamespace.TestClass.#ctor">
            <summary>
            This sample shows how to specify the <see cref="T:TestNamespace.TestClass"/> constructor as a cref attribute.
            </summary>
        </member>
        <member name="M:TestNamespace.TestClass.#ctor(System.Int32)">
            <summary>
            This sample shows how to specify the <see cref="M:TestNamespace.TestClass.#ctor(System.Int32)"/> constructor as a cref attribute.
            </summary>
        </member>
        <member name="M:TestNamespace.TestClass.GetZero">
            <summary>
            The GetZero method.
            </summary>
            <example>
            This sample shows how to call the <see cref="M:TestNamespace.TestClass.GetZero"/> method.
            <code>
            class TestClass
            {
                static int Main()
                {
                    return GetZero();
                }
            }
            </code>
            </example>
        </member>
        <member name="M:TestNamespace.TestClass.GetGenericValue``1(``0)">
            <summary>
            The GetGenericValue method.
            </summary>
            <remarks>
            This sample shows how to specify the <see cref="M:TestNamespace.TestClass.GetGenericValue``1(``0)"/> method as a cref attribute.
            </remarks>
        </member>
        <member name="T:TestNamespace.GenericClass`1">
            <summary>
            GenericClass.
            </summary>
            <remarks>
            This example shows how to specify the <see cref="T:TestNamespace.GenericClass`1"/> type as a cref attribute.
            </remarks>
        </member>
    </members>
</doc>
```

## \<exception> (C# programming guide)

```xml
<exception cref="member">description</exception>
```

- cref = " `member`": A reference to an exception that is available from the current compilation environment. The compiler checks that the given exception exists and translates `member` to the canonical element name in the output XML. `member` must appear within double quotation marks (" ").

The `<exception>` tag lets you specify which exceptions can be thrown. This tag can be applied to definitions for methods, properties, events, and indexers.

[!code-csharp[csProgGuideDocComments#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#4)]

## \<typeparam> (C# programming guide)

```xml
<typeparam name="name">description</typeparam>
```

- `name`: The name of the type parameter. Enclose the name in double quotation marks (" ").

The `<typeparam>` tag should be used in the comment for a generic type or method declaration to describe a type parameter. Add a tag for each type parameter of the generic type or method. The text for the `<typeparam>` tag will be displayed in IntelliSense, the [Object Browser Window](/visualstudio/ide/viewing-the-structure-of-code#BKMK_ObjectBrowser) code comment web report.

[!code-csharp[csProgGuideDocComments#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#13)]

## \<typeparamref> (C# programming guide)

```xml
<typeparamref name="name"/>
```

- `name`: The name of the type parameter. Enclose the name in double quotation marks (" ").

Use this tag to enable consumers of the documentation file to format the word in some distinct way, for example in italics.

[!code-csharp[csProgGuideDocComments#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#13)]

## \<inheritdoc> (C# Programming Guide)

```xml  
<inheritdoc [cref=""] [path=""]/>
```  

Inherit XML comments from base classes, interfaces, and similar methods. This eliminates unwanted copying and pasting of duplicate XML comments and automatically keeps XML comments synchronized.

- `cref`:  Specify the member to inherit documentation from. Already defined tags on the current member are not overridden by the inherited ones.
- `path`: The XPath expression query that will result in a node set to show. You can use this attribute to filter which tags to include or exclude from the inherited documentation.
  
Add your XML comments in base classes or interfaces and let InheritDoc copy the comments to implementing classes. Add your XML comments to your synchronous methods and let InheritDoc copy the comments to your asynchronous versions of the same methods. If you want to copy the comments from a specific member you can use the `cref` attribute to specify the member.

[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#16)]  

[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#17)]  
[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#18)]  
[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#19)]  

## \<include> (C# programming guide)

```xml
<include file='filename' path='tagpath[@name="id"]' />
```

- `filename`: The name of the XML file containing the documentation. The file name can be qualified with a path relative to the source code file. Enclose `filename` in single quotation marks (' ').
- `tagpath`: The path of the tags in `filename` that leads to the tag `name`. Enclose the path in single quotation marks (' ').
- `name`: The name specifier in the tag that precedes the comments; `name` will have an `id`.
- `id`: The ID for the tag that precedes the comments. Enclose the ID in double quotation marks (" ").

The `<include>` tag lets you refer to comments in another file that describe the types and members in your source code. This is an alternative to placing documentation comments directly in your source code file. By putting the documentation in a separate file, you can apply source control to the documentation separately from the source code. One person can have the source code file checked out and someone else can have the documentation file checked out. The `<include>` tag uses the XML XPath syntax. Refer to XPath documentation for ways to customize your `<include>` use.

This is a multifile example. The following is the first file, which uses `<include>`.

[!code-csharp[csProgGuideDocComments#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#5)]

The second file, *xml_include_tag.doc*, contains the following documentation comments.

```xml
<MyDocs>

<MyMembers name="test">
<summary>
The summary for this type.
</summary>
</MyMembers>

<MyMembers name="test2">
<summary>
The summary for this other type.
</summary>
</MyMembers>

</MyDocs>
```

The following output is generated when you compile the Test and Test2 classes with the following command line: `-doc:DocFileName.xml.` In Visual Studio, you specify the XML doc comments option in the Build pane of the Project Designer. When the C# compiler sees the `<include>` tag, it searches for documentation comments in *xml_include_tag.doc* instead of the current source file. The compiler then generates *DocFileName.xml*, and this is the file that is consumed by documentation tools such as [Sandcastle](https://github.com/EWSoftware/SHFB) to produce the final documentation.

```xml
<?xml version="1.0"?>
<doc>
    <assembly>
        <name>xml_include_tag</name>
    </assembly>
    <members>
        <member name="T:Test">
            <summary>
                The summary for this type.
            </summary>
        </member>
        <member name="T:Test2">
            <summary>
                The summary for this other type.
            </summary>
        </member>
    </members>
</doc>
```

## \<c> (C# programming guide)

```xml
<c>text</c>
```

The `<c>` tag gives you a way to indicate that text within a description should be marked as code. Use [\<code>](./code.md) to indicate multiple lines as code.

[!code-csharp[csProgGuideDocComments#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#2)]
  
## \<code> (C# programming guide)

```xml
<code>content</code>
```

The `<code>` tag is used to indicate multiple lines of code. Use [\<c>](./code-inline.md) to indicate that single-line text within a description should be marked as code.

## \<example> (C# programming guide)

```xml
<example>description</example>
```

The `<example>` tag lets you specify an example of how to use a method or other library member. This commonly involves using the [\<code>](./code.md) tag.

Compile with [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) to process documentation comments to a file.

[!code-csharp[csProgGuideDocComments#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#3)]

# \<list> (C# programming guide)

```xml
<list type="bullet|number|table">
    <listheader>
        <term>term</term>
        <description>description</description>
    </listheader>
    <item>
        <term>term</term>
        <description>description</description>
    </item>
</list>
```

The `<listheader>` block is used to define the heading row of either a table or definition list. When defining a table, you only need to supply an entry for term in the heading. Each item in the list is specified with an `<item>` block. When creating a definition list, you will need to specify both `term` and `description`. However, for a table, bulleted list, or numbered list, you only need to supply an entry for `description`. A list or table can have as many `<item>` blocks as needed.

[!code-csharp[csProgGuideDocComments#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#6)]

## \<para> (C# programming guide)

```xml
<para>content</para>
```

The `<para>` tag is for use inside a tag, such as [\<summary>](./summary.md), [\<remarks>](./remarks.md), or [\<returns>](./returns.md), and lets you add structure to the text.

## \<see> (C# programming guide)

```csharp
/// <see cref="member"/>
// or
/// <see href="link">Link Text</see>
// or
/// <see langword="keyword"/>
```

- `cref="member"`: A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. Place *member* within double quotation marks (" ").
- `href="link"`: A clickable link to a given URL. For example, `<see href="https://github.com">GitHub</see>` produces a clickable link with text :::no-loc text="GitHub"::: that links to `https://github.com`.
- `langword="keyword"`: A language keyword, such as `true`.

The `<see>` tag lets you specify a link from within text. Use [\<seealso>](./seealso.md) to indicate that text should be placed in a See Also section. Use the [cref Attribute](./cref-attribute.md) to create internal hyperlinks to documentation pages for code elements. Also, ``href`` is a valid Attribute that will function as a hyperlink. The following example shows a `<see>` tag within a summary section.

[!code-csharp[csProgGuideDocComments#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#12)]

## \<seealso> (C# programming guide)

```csharp
/// <seealso cref="member"/>
// or
/// <seealso href="link">Link Text</seealso>
```

- `cref="member"`: A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML.`member` must appear within double quotation marks (" ").
- `href="link"`: A clickable link to a given URL. For example, `<seealso href="https://github.com">GitHub</seealso>` produces a clickable link with text :::no-loc text="GitHub"::: that links to `https://github.com`.

The `<seealso>` tag lets you specify the text that you might want to appear in a See Also section. Use [\<see>](./see.md) to specify a link from within text.

## \<permission> (C# programming guide)

```xml
<permission cref="member">description</permission>
```

- cref = " `member`": A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and translates `member` to the canonical element name in the output XML. *member* must appear within double quotation marks (" ").
- `description`: A description of the access to the member.

The `<permission>` tag lets you document the access of a member. The <xref:System.Security.PermissionSet> class lets you specify access to a member.

[!code-csharp[csProgGuideDocComments#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#8)]
