---
title: "Recommended XML documentation tags for a class and its members"
description: This article provides the syntax and definitions for recommended tags for XML documentation.
ms.date: 07/12/2021
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
---
# Recommended XML tags for C# documentation comments

C# documentation comments use XML elements to define the structure of the output documentation. One consequence of this feature is that you can add any valid XML in your documentation comments. The C# compiler copies these elements into the output XML file. While you can use any valid XML in your comments (including any valid HTML element), documenting code is recommended for many reasons.

What follows are some recommendations, general use case scenarios, and things that you should know when using XML documentation tags in your C# code. While you can put any tags into your documentation comments, this article describes the recommended tags for the most common language constructs. In all cases, you should adhere to these recommendations:

- For the sake of consistency, all publicly visible types and their public members should be documented.
- Private members can also be documented using XML comments. However, it exposes the inner (potentially confidential) workings of your library.
- At a bare minimum, types and their members should have a `<summary>` tag because its content is needed for IntelliSense.
- Documentation text should be written using complete sentences ending with full stops.
- Partial classes are fully supported, and documentation information will be concatenated into a single entry for each type.

XML documentation starts with `///`. When you create a new project, the templates put some starter `///` lines in for you. The processing of these comments has some restrictions:

- The documentation must be well-formed XML. If the XML isn't well formed, the compiler generates a warning. The documentation file will contain a comment that says that an error was encountered.
- Some of the recommended tags have special meanings:
  - The `<param>` tag is used to describe parameters. If used, the compiler verifies that the parameter exists and that all parameters are described in the documentation. If the verification fails, the compiler issues a warning.
  - The `cref` attribute can be attached to any tag to reference a code element. The compiler verifies that this code element exists. If the verification fails, the compiler issues a warning. The compiler respects any `using` statements when it looks for a type described in the `cref` attribute.
  - The `<summary>` tag is used by IntelliSense inside Visual Studio to display additional information about a type or member.
    > [!NOTE]
    > The XML file does not provide full information about the type and members (for example, it does not contain any type information). To get full information about a type or member, use the documentation file together with reflection on the actual type or member.
- Developers are free to create their own set of tags. The compiler will copy these to the output file.

Some of the recommended tags can be used on any language element. Others have more specialized usage. Finally, some of the tags are used to format text in your documentation. This article describes the recommended tags organized by their use.

The compiler verifies the syntax of the elements followed by a single \* in the following list. Visual Studio provides IntelliSense for the tags verified by the compiler and all tags followed by \*\* in the following list. In addition to the tags listed here, the compiler and Visual Studio validate the `<b>`, `<i>`, `<u>`, `<br/>`, and `<a>` tags. The compiler also validates `<tt>`, which is deprecated HTML.

- [General Tags](#general-tags) used for multiple elements - These tags are the minimum set for any API.
  - [`<summary>`](#summary): The value of this element is displayed in IntelliSense in Visual Studio.
  - [`<remarks>`](#remarks) \*\*
- [Tags used for members](#document-members) - These tags are used when documenting methods and properties.
  - [`<returns>`](#returns): The value of this element is displayed in IntelliSense in Visual Studio.
  - [`<param>`](#param) \*: The value of this element is displayed in IntelliSense in Visual Studio.
  - [`<paramref>`](#paramref)
  - [`<exception>`](#exception) \*
  - [`<value>`](#value): The value of this element is displayed in IntelliSense in Visual Studio.
- [Format documentation output](#format-documentation-output) - These tags provide formatting directions for tools that generate documentation.
  - [`<para>`](#para)
  - [`<list>`](#list)
  - [`<c>`](#c)
  - [`<code>`](#code)
  - [`<example>`](#example) \*\*
- [Reuse documentation text](#reuse-documentation-text) - These tags provide tools that make it easier to reuse XML comments.
  - [`<inheritdoc>`](#inheritdoc) \*\*
  - [`<include>`](#include) \*
- [Generate links and references](#generate-links-and-references) - These tags generate links to other documentation.
  - [`<see>`](#see) \*
  - [`<seealso>`](#seealso) \*
  - [`<cref>`](#cref-attribute)
  - [`<href>`](#href-attribute)
- [Tags for generic types and methods](#generic-types-and-methods) - These tags are used only on generic types and methods
  - [`<typeparam>`](#typeparam) \*: The value of this element is displayed in IntelliSense in Visual Studio.
  - [`<typeparamref>`](#typeparamref)

> [!NOTE]
> Documentation comments cannot be applied to a namespace.

If you want angle brackets to appear in the text of a documentation comment, use the HTML encoding of `<` and `>`, which is `&lt;` and `&gt;` respectively. This encoding is shown in the following example.

```csharp
/// <summary>
/// This property always returns a value &lt; 1.
/// </summary>
```

## General tags

### \<summary>

```xml
<summary>description</summary>
```

The `<summary>` tag should be used to describe a type or a type member. Use [\<remarks>](#remarks) to add supplemental information to a type description. Use the [cref attribute](#cref-attribute) to enable documentation tools such as [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) to create internal hyperlinks to documentation pages for code elements. The text for the `<summary>` tag is the only source of information about the type in IntelliSense, and is also displayed in the Object Browser window.

### \<remarks>

```xml
<remarks>
description
</remarks>
```

The `<remarks>` tag is used to add information about a type or a type member, supplementing the information specified with [\<summary>](#summary). This information is displayed in the Object Browser window. This tag may include more lengthy explanations. You may find that using `CDATA` sections for markdown make writing it more convenient. Tools such as [docfx](https://dotnet.github.io/docfx/) process the markdown text in `CDATA` sections.

## Document members

### \<returns>

```xml
<returns>description</returns>
```

The `<returns>` tag should be used in the comment for a method declaration to describe the return value.

### \<param>

```xml
<param name="name">description</param>
```

- `name`: The name of a method parameter. Enclose the name in double quotation marks (" "). The names for parameters must match the API signature. If one or more parameter aren't covered, the compiler issues a warning. The compiler also issues a warning if the value of `name` doesn't match a formal parameter in the method declaration.

The `<param>` tag should be used in the comment for a method declaration to describe one of the parameters for the method. To document multiple parameters, use multiple `<param>` tags. The text for the `<param>` tag is displayed in IntelliSense, the Object Browser, and the Code Comment Web Report.

### \<paramref>

```xml
<paramref name="name"/>
```

- `name`: The name of the parameter to refer to. Enclose the name in double quotation marks (" ").

The `<paramref>` tag gives you a way to indicate that a word in the code comments, for example in a `<summary>` or `<remarks>` block refers to a parameter. The XML file can be processed to format this word in some distinct way, such as with a bold or italic font.

### \<exception>

```xml
<exception cref="member">description</exception>
```

- cref = "`member`": A reference to an exception that is available from the current compilation environment. The compiler checks that the given exception exists and translates `member` to the canonical element name in the output XML. `member` must appear within double quotation marks (" ").

The `<exception>` tag lets you specify which exceptions can be thrown. This tag can be applied to definitions for methods, properties, events, and indexers.

### \<value>

```xml
<value>property-description</value>
```

The `<value>` tag lets you describe the value that a property represents. When you add a property via code wizard in the Visual Studio .NET development environment, it adds a [\<summary>](#summary) tag for the new property. You manually add a `<value>` tag to describe the value that the property represents.

## Format documentation output

### \<para>

```xml
<remarks>
    <para>
        This is an introductory paragraph.
    </para>
    <para>
        This paragraph contains more details.
    </para>
</remarks>
```

The `<para>` tag is for use inside a tag, such as [\<summary>](#summary), [\<remarks>](#remarks), or [\<returns>](#returns), and lets you add structure to the text. The `<para>` tag creates a double spaced paragraph. Use the `<br/>` tag if you want a single spaced paragraph.

### \<list>

```xml
<list type="bullet|number|table">
    <listheader>
        <term>term</term>
        <description>description</description>
    </listheader>
    <item>
        <term>Assembly</term>
        <description>The library or executable built from a compilation.</description>
    </item>
</list>
```

The `<listheader>` block is used to define the heading row of either a table or definition list. When defining a table, you only need to supply an entry for `term` in the heading. Each item in the list is specified with an `<item>` block. When creating a definition list, you'll need to specify both `term` and `description`. However, for a table, bulleted list, or numbered list, you only need to supply an entry for `description`. A list or table can have as many `<item>` blocks as needed.

### \<c>

```xml
<c>text</c>
```

The `<c>` tag gives you a way to indicate that text within a description should be marked as code. Use [\<code>](#code) to indicate multiple lines as code.

### \<code>

```xml
<code>
    var index = 5;
    index++;
</code>
```

The `<code>` tag is used to indicate multiple lines of code. Use [\<c>](#c) to indicate that single-line text within a description should be marked as code.

### \<example>

```xml
<example>
This shows how to increment an integer.
<code>
    var index = 5;
    index++;
</code>
</example>
```

The `<example>` tag lets you specify an example of how to use a method or other library member. An example commonly involves using the [\<code>](#code) tag.

## Reuse documentation text

### \<inheritdoc>

```xml  
<inheritdoc [cref=""] [path=""]/>
```  

Inherit XML comments from base classes, interfaces, and similar methods. Using `inheritdoc` eliminates unwanted copying and pasting of duplicate XML comments and automatically keeps XML comments synchronized. Note that when you add the `<inheritdoc>` tag to a type, all members will inherit the comments as well.

- `cref`:  Specify the member to inherit documentation from. Already defined tags on the current member are not overridden by the inherited ones.
- `path`: The XPath expression query that will result in a node set to show. You can use this attribute to filter the tags to include or exclude from the inherited documentation.
  
Add your XML comments in base classes or interfaces and let inheritdoc copy the comments to implementing classes. Add your XML comments to your synchronous methods and let inheritdoc copy the comments to your asynchronous versions of the same methods. If you want to copy the comments from a specific member, you use the `cref` attribute to specify the member.

### \<include>

```xml
<include file='filename' path='tagpath[@name="id"]' />
```

- `filename`: The name of the XML file containing the documentation. The file name can be qualified with a path relative to the source code file. Enclose `filename` in single quotation marks (' ').
- `tagpath`: The path of the tags in `filename` that leads to the tag `name`. Enclose the path in single quotation marks (' ').
- `name`: The name specifier in the tag that precedes the comments; `name` will have an `id`.
- `id`: The ID for the tag that precedes the comments. Enclose the ID in double quotation marks (" ").

The `<include>` tag lets you refer to comments in another file that describe the types and members in your source code. Including an external file is an alternative to placing documentation comments directly in your source code file. By putting the documentation in a separate file, you can apply source control to the documentation separately from the source code. One person can have the source code file checked out and someone else can have the documentation file checked out. The `<include>` tag uses the XML XPath syntax. Refer to XPath documentation for ways to customize your `<include>` use.

## Generate links and references

### \<see>

```csharp
/// <see cref="member"/>
// or
/// <see cref="member">Link text</see>
// or
/// <see href="link">Link Text</see>
// or
/// <see langword="keyword"/>
```

- `cref="member"`: A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. Place *member* within double quotation marks (" "). You can provide different link text for a "cref", by using a separate closing tag.
- `href="link"`: A clickable link to a given URL. For example, `<see href="https://github.com">GitHub</see>` produces a clickable link with text :::no-loc text="GitHub"::: that links to `https://github.com`.
- `langword="keyword"`: A language keyword, such as `true`.

The `<see>` tag lets you specify a link from within text. Use [\<seealso>](#seealso) to indicate that text should be placed in a See Also section. Use the [cref attribute](#cref-attribute) to create internal hyperlinks to documentation pages for code elements. You include the type parameters to specify a reference to a generic type or method, such as `cref="IDictionary{T, U}"`. Also, ``href`` is a valid attribute that will function as a hyperlink.

### \<seealso>

```csharp
/// <seealso cref="member"/>
// or
/// <seealso href="link">Link Text</seealso>
```

- `cref="member"`: A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. `member` must appear within double quotation marks (" ").
- `href="link"`: A clickable link to a given URL. For example, `<seealso href="https://github.com">GitHub</seealso>` produces a clickable link with text :::no-loc text="GitHub"::: that links to `https://github.com`.

The `<seealso>` tag lets you specify the text that you might want to appear in a **See Also** section. Use [\<see>](#see) to specify a link from within text. You cannot nest the `seealso` tag inside the `summary` tag.

### cref attribute

The `cref` attribute in an XML documentation tag means "code reference." It specifies that the inner text of the tag is a code element, such as a type, method, or property. Documentation tools like [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) use the `cref` attributes to automatically generate hyperlinks to the page where the type or member is documented.

### href attribute

The `href` attribute means a reference to a web page. You can use it to directly reference online documentation about your API or library.

## Generic types and methods

### \<typeparam>

```xml
<typeparam name="TResult">The type returned from this method</typeparam>
```

- `TResult`: The name of the type parameter. Enclose the name in double quotation marks (" ").

The `<typeparam>` tag should be used in the comment for a generic type or method declaration to describe a type parameter. Add a tag for each type parameter of the generic type or method. The text for the `<typeparam>` tag will be displayed in IntelliSense.

### \<typeparamref>

```xml
<typeparamref name="TKey"/>
```

- `TKey`: The name of the type parameter. Enclose the name in double quotation marks (" ").

Use this tag to enable consumers of the documentation file to format the word in some distinct way, for example in italics.

### User-defined tags

All the tags outlined above represent those tags that are recognized by the C# compiler. However, a user is free to define their own tags.
Tools like Sandcastle bring support for extra tags like [\<event>](https://ewsoftware.github.io/XMLCommentsGuide/html/81bf7ad3-45dc-452f-90d5-87ce2494a182.htm) and [\<note>](https://ewsoftware.github.io/XMLCommentsGuide/html/4302a60f-e4f4-4b8d-a451-5f453c4ebd46.htm),
and even support [documenting namespaces](https://ewsoftware.github.io/XMLCommentsGuide/html/BD91FAD4-188D-4697-A654-7C07FD47EF31.htm).
Custom or in-house documentation generation tools can also be used with the standard tags, and multiple output formats from HTML to PDF can be supported.
