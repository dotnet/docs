---
description: "Learn more about: Document your code with XML (Visual Basic)"
title: "Documenting Your Code with XML"
ms.date: 11/22/2021
helpviewer_keywords:
  - "XML [Visual Basic], documenting code"
  - "XML comments, Visual Basic"
  - "Visual Basic code, documenting with XML"
ms.assetid: a0d35dc7-c5f9-4d74-92ff-a1c6f28d5235
---
# Document your code with XML (Visual Basic)

In Visual Basic, you can document your code using XML.

## XML documentation comments

Visual Basic provides an easy way to automatically create XML documentation for projects. You can automatically generate an XML skeleton for your types and members, and then provide summaries, descriptive documentation for each parameter, and other remarks. With the appropriate setup, the XML documentation is automatically emitted into an XML file with the same root file name as your project. For information about configuring the generation of the XML documentation file, see [-doc compiler option](../../reference/command-line-compiler/doc.md) and [GenerateDocumentationFile MSBuild property](../../../core/project-sdk/msbuild-props.md#generatedocumentationfile).

The XML file can be consumed or otherwise manipulated as XML. This file is located in the same directory as the output .exe or .dll file of your project.

XML documentation starts with `'''`. The processing of these comments has some restrictions:

- The documentation must be well-formed XML. If the XML is not well formed, a warning is generated and the documentation file contains a comment saying that an error was encountered.

- Developers are free to create their own set of tags. There is a recommended set of tags (see [XML Comment Tags](../../language-reference/xmldoc/index.md)). Some of the recommended tags have special meanings:

  - The \<param> tag is used to describe parameters. If used, the compiler will verify that the parameter exists and that all parameters are described in the documentation. If the verification fails, the compiler issues a warning.

  - The `cref` attribute can be attached to any tag to provide a reference to a code element. The compiler verifies that this code element exists. If the verification fails, the compiler issues a warning. The compiler also respects any `Imports` statements when looking for a type described in the `cref` attribute.

  - The \<summary> tag is used by IntelliSense in Visual Studio to display additional information about a type or member.

## Related sections

For details on creating an XML file with documentation comments, see the following topics:

- [-doc](../../reference/command-line-compiler/doc.md)

- [XML Comment Tags](../../language-reference/xmldoc/index.md)

- [Processing the XML File](processing-the-xml-file.md)

- [How to: Create XML Documentation](how-to-create-xml-documentation.md)

- [XML Tools in Visual Studio](/visualstudio/xml-tools/xml-tools-in-visual-studio)

## See also

- [Developing Applications with Visual Basic](../../developing-apps/index.md)
- [Visual Basic Programming Guide](../index.md)
