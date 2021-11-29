---
title: XML Documentation
description: Learn about support in F# for generating documentation from comments.
ms.date: 09/15/2020
---

# Document your code with XML comments

You can produce documentation from triple-slash (///) code comments in F#. XML comments can precede declarations in code files (.fs) or signature (.fsi) files.

XML documentation comments are a special kind of comment, added above the definition of any user-defined type or member.
They are special because they can be processed by the compiler to generate an XML documentation file at compile time.
The compiler-generated XML file can be distributed alongside your .NET assembly so that IDEs can use tooltips to
show quick information about types or members. Additionally, the XML file can be run through tools
like [fsdocs](http://fsprojects.github.io/FSharp.Formatting/) to generate API reference websites.

XML documentation comments, like all other comments, are ignored by the compiler, unless the options described below are enabled to check the validity and
completeness of comments at compile time.

You can generate the XML file at compile time by doing one of the following:

- You can add a `GenerateDocumentationFile` element to the `<PropertyGroup>` section of your `.fsproj` project file,
  which generates an XML file in the project directory with the same root filename as the assembly. For example:

   ```xml
   <GenerateDocumentationFile>true</GenerateDocumentationFile>
   ```

  For more information, see [GenerateDocumentationFile property](../../core/project-sdk/msbuild-props.md#generatedocumentationfile).

- If you are developing an application using Visual Studio, right-click on the project and select **Properties**. In the properties dialog, select the **Build** tab, and check **XML documentation file**. You can also change the location to which the compiler writes the file.

There are two ways to write XML documentation comments: with and without XML tags. Both use triple-slash comments.

## Comments without XML tags

If a `///` comment does not start with a `<`, then the entire comment text is taken as the summary documentation for the code construct
that immediately follows. Use this method when you want to write only a brief summary for each construct.

The comment is encoded to XML during documentation preparation, so characters such as `<`, `>`, and `&` need not be escaped. If you don't specify a summary tag
explicitly, you should not specify other tags, such as **param** or **returns** tags.

The following example shows the alternative method, without XML tags. In this example, the entire text in the comment is considered a summary.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet7102.fs)]

## Comments with XML tags

If a comment body begins with `<` (normally `<summary>`), then it is treated as an XML formatted comment
body using XML tags. This second enables you to specify separate notes
for a short summary, additional remarks, documentation for each parameter and type parameter and exceptions thrown, and a description of the return value.

The following is a typical XML documentation comment in a signature file:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet7101.fs)]

## Recommended Tags

If you are using XML tags, the following table describes the outer tags recognized in F# XML code comments.

| Tag syntax                                  | Description |
|---------------------------------------------|-----------|
| `<summary>`**_text_**`</summary>`           | Specifies that *text* is a brief description of the program element. The description is usually one or two sentences.|
| `<remarks>`**_text_**`</remarks>`           | Specifies that *text* contains supplementary information about the program element.|
| `<param name="`**_name_**`">`**_description_**`</param>` | Specifies the name and description for a function or method parameter.|
| `<typeparam name="`**_name_**`">`**_description_**`</typeparam>` | Specifies the name and description for a type parameter.|
| `<returns>`**_text_**`</returns>`           | Specifies that *text* describes the return value of a function or method.|
| `<exception cref="`**_type_**`">`**_description_**`</exception>` |Specifies the type of exception that can be generated and the circumstances under which it is thrown.|
| `<seealso cref="`**_reference_**`"/>`      | Specifies a See Also link to the documentation for another type. The *reference* is the name as it appears in the XML documentation file. See Also links usually appear at the bottom of a documentation page.|

The following table describes the tags for use inside description sections:

| Tag syntax                                | Description |
|-------------------------------------------|-------------|
| `<para>`**_text_**`</para>`               | Specifies a paragraph of text. This is used to separate text inside the **remarks** tag.|
| `<code>`**_text_**`</code>`               | Specifies that *text* is multiple lines of code. This tag can be used by documentation generators to display text in a font that is appropriate for code.|
| `<paramref name="`**_name_**`"/>`         | Specifies a reference to a parameter in the same documentation comment.|
| `<typeparamref name="`**_name_**`"/>`     | Specifies a reference to a type parameter in the same documentation comment.|
| `<c>`**_text_**`</c>`                     | Specifies that *text* is inline code. This tag can be used by documentation generators to display text in a font that is appropriate for code.|
| `<see cref="`**_reference_**`">`**_text_**`</see>` | Specifies an inline link to another program element. The *reference* is the name as it appears in the XML documentation file. The *text* is the text shown in the link.|

### User-defined tags

The previous tags represent those that are recognized by the F# compiler and typical F# editor tooling. However, a user is free to define their own tags.
Tools like fsdocs bring support for extra tags like [\<namespacedoc>](https://github.com/fsharp/fslang-design/blob/main/tooling/FST-1031-xmldoc-extensions.md).
Custom or in-house documentation generation tools can also be used with the standard tags and multiple output formats from HTML to PDF can be supported.

## Compile-time checking

When `--warnon:3390` is enabled, the compiler verifies the syntax of the XML and the parameters referred to in `<param>` and `<paramref>` tags.

## Documenting F# Constructs

F# constructs such as modules, members, union cases, and record fields are documented by a `///` comment immediately prior to their declaration.
If needed, implicit constructors of classes are documented by giving a `///` comment prior to the argument list. For example:

```fsharp
/// This is the type
type SomeType
      /// This is the implicit constructor
      (a: int, b: int) =

    /// This is the member
    member _.Sum() = a + b
```

## Limitations

Some features of XML documentation in C# and other .NET languages are not supported in F#.

- In F#, cross-references must use the full XML signature of the corresponding symbol, for example `cref="T:System.Console"`.
  Simple C#-style cross-references such as `cref="Console"` are not elaborated to full XML signatures
  and these elements are not checked by the F# compiler. Some documentation tooling
  may allow the use of these cross-references by subsequent processing, but the full signatures should be used.

- The tags `<include>`, `<inheritdoc>` are not supported by the F# compiler. No error is given if they are used, but
  they are simply copied to the generated documentation file without otherwise affecting the documentation generated.

- Cross-references are not checked by the F# compiler, even when `-warnon:3390` is used.

- The names used in the tags `<typeparam>` and `<typeparamref>` are not checked by the F# compiler, even when `--warnon:3390` is used.

- No warnings are given if documentation is missing, even when `--warnon:3390` is used.

## Recommendations

Documenting code is recommended for many reasons. What follows are some best practices, general use case scenarios, and things that you should know when using XML documentation tags in your F# code.

- Enable the option `--warnon:3390` in your code to help ensure your XML documentation is valid XML.

- Consider adding signature files to separate long XML documentation comments from your implementation.

- For the sake of consistency, all publicly visible types and their members should be documented. If you must do it, do it all.

- At a bare minimum, modules, types, and their members should have a plain `///` comment or `<summary>` tag. This will show in an autocompletion tooltip window in F# editing tools.

- Documentation text should be written using complete sentences ending with full stops.

## See also

- [C# XML Documentation Comments &#40;C&#35; Programming Guide&#41;](../../csharp/language-reference/xmldoc/index.md).
- [F# Language Reference](index.md)
- [Compiler Options](compiler-options.md)
