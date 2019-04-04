---
title: "How to: Use the XML documentation features - C# Programming Guide"
ms.custom: seodec18
ms.date: 06/01/2018
helpviewer_keywords: 
  - "XML documentation [C#]"
  - "C# language, XML documentation features"
ms.assetid: 8f33917b-9577-4c9a-818a-640dbbb0b399
---
# How to: Use the XML documentation features

The following sample provides a basic overview of a type that has been documented.

## Example

[!code-csharp[csProgGuideDocComments#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#15)]

The example generates an .xml file with the following contents:

```xml
<?xml version="1.0"?>
<doc>
    <assembly>
        <name>xmlsample</name>
    </assembly>
    <members>
        <member name="T:TestClass">
            <summary>
            Class level summary documentation goes here.
            </summary>
            <remarks>
            Longer comments can be associated with a type or member through
            the remarks tag.
            </remarks>
        </member>
        <member name="F:TestClass._name">
            <summary>
            Store for the Name property.
            </summary>
        </member>
        <member name="M:TestClass.#ctor">
            <summary>
            The class constructor.
            </summary>
        </member>
        <member name="P:TestClass.Name">
            <summary>
            Name property.
            </summary>
            <value>
            A value tag is used to describe the property value.
            </value>
        </member>
        <member name="M:TestClass.SomeMethod(System.String)">
            <summary>
            Description for SomeMethod.
            </summary>
            <param name="s"> Parameter description for s goes here.</param>
            <seealso cref="T:System.String">
            You can use the cref attribute on any tag to reference a type or member 
            and the compiler will check that the reference exists.
            </seealso>
        </member>
        <member name="M:TestClass.SomeOtherMethod">
            <summary>
            Some other method.
            </summary>
            <returns>
            Return values are described through the returns tag.
            </returns>
            <seealso cref="M:TestClass.SomeMethod(System.String)">
            Notice the use of the cref attribute to reference a specific method.
            </seealso>
        </member>
        <member name="M:TestClass.Main(System.String[])">
            <summary>
            The entry point for the application.
            </summary>
            <param name="args"> A list of command line arguments.</param>
        </member>
        <member name="T:TestInterface">
            <summary>
            Documentation that describes the interface goes here.
            </summary>
            <remarks>
            Details about the interface go here.
            </remarks>
        </member>
        <member name="M:TestInterface.InterfaceMethod(System.Int32)">
            <summary>
            Documentation that describes the method goes here.
            </summary>
            <param name="n">
            Parameter n requires an integer argument.
            </param>
            <returns>
            The method returns an integer.
            </returns>
        </member>
    </members>
</doc>
```

## Compiling the code

To compile the example, type the following command line:

`csc XMLsample.cs /doc:XMLsample.xml`

This command creates the XML file *XMLsample.xml*, which you can view in your browser or by using the TYPE command.

## Robust programming

XML documentation starts with ///. When you create a new project, the wizards put some starter /// lines in for you. The processing of these comments has some restrictions:

- The documentation must be well-formed XML. If the XML is not well-formed, a warning is generated and the documentation file will contain a comment that says that an error was encountered.

- Developers are free to create their own set of tags. There is a recommended set of tags (see [Recommended tags for documentation comments](recommended-tags-for-documentation-comments.md)). Some of the recommended tags have special meanings:

  - The \<param> tag is used to describe parameters. If used, the compiler verifies that the parameter exists and that all parameters are described in the documentation. If the verification failed, the compiler issues a warning.

  - The `cref` attribute can be attached to any tag to provide a reference to a code element. The compiler verifies that this code element exists. If the verification failed, the compiler issues a warning. The compiler respects any `using` statements when it looks for a type described in the `cref` attribute.

  - The \<summary> tag is used by IntelliSense inside Visual Studio to display additional information about a type or member.

    > [!NOTE]
    > The XML file does not provide full information about the type and members (for example, it does not contain any type information). To get full information about a type or member, the documentation file must be used together with reflection on the actual type or member.

## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [/doc (C# Compiler Options)](../../../csharp/language-reference/compiler-options/doc-compiler-option.md)
- [XML Documentation Comments](../../../csharp/programming-guide/xmldoc/xml-documentation-comments.md)
