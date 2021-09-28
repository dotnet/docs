---
description: "Learn more about: How to: Create XML Documentation in Visual Basic"
title: "How to: Create XML Documentation"
ms.date: 07/20/2015
helpviewer_keywords:
  - "XML comments"
  - "XML documentation [Visual Basic], creating"
ms.assetid: 27b5b06c-09b9-496a-8245-f9542d846230
---
# How to: Create XML Documentation in Visual Basic

This example shows how to add XML documentation comments to your code.

[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]

## To create XML documentation for a type or member

1. In the **Code Editor**, position your cursor on the line above the type or member for which you want to create documentation.

2. Type `'''` (three single-quotation marks).

    An XML skeleton for the type or member is added in the **Code Editor**.

3. Add descriptive information between the appropriate tags.

    > [!NOTE]
    > If you add additional lines within the XML documentation block, each line must begin with `'''`.

4. Add additional code that uses the type or member with the new XML documentation comments.

    IntelliSense displays the text from the \<summary> tag for the type or member.

5. Compile the code to generate an XML file containing the documentation comments. For more information, see [-doc](../../reference/command-line-compiler/doc.md).

## See also

- [Documenting Your Code with XML](documenting-your-code-with-xml.md)
- [XML Comment Tags](../../language-reference/xmldoc/index.md)
- [-doc](../../reference/command-line-compiler/doc.md)
