---
title: Create the source Office Open XML document - LINQ to XML
description: Learn how to create the Office Open XML WordprocessingML document used by the other examples in this tutorial.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# Create the source Office Open XML document (LINQ to XML)

This article shows how to create the Office Open XML WordprocessingML document used by the other examples in this tutorial. If you follow these instructions, your output will match the output provided in each example.

However, the examples in this tutorial will work with any valid WordprocessingML document.

To create the document that this tutorial uses, you must either have Microsoft Office 2007 or later installed, or you must have Microsoft Office 2003 with the Microsoft Office Compatibility Pack for Word, Excel, and PowerPoint 2007 File Formats.

## Create the WordprocessingML document

Use the following steps to create the WordprocessingML document:

1. Create a new Microsoft Word document.
1. Paste the following text into the new document.
   1. For C#, use this text:

         ```text
         Parsing WordprocessingML with LINQ to XML

         The following example prints to the console.

         using System;

            class Program {
               public static void Main(string[] args) {
               Console.WriteLine("Hello World");
            }
         }

         This example produces the following output:

         Hello World
         ```

   1. For Visual Basic, use this text:

      ```text
      Parsing WordprocessingML with LINQ to XML

      The following example prints to the console.

      Imports System

      Class Program
         Public Shared  Sub Main(ByVal args() As String)
            Console.WriteLine("Hello World")
         End Sub
      End Class

      This example produces the following output:

      Hello World
      ```

1. Format the first line with the style "Heading 1".
1. For C#, select the lines that contain the C# code. The first line starts with the `using` keyword. The last line is the last closing brace. Format the lines with the courier font. Format them with a new style, and name the new style "Code".
1. For Visual Basic, select the lines that contain the Visual Basic code. The first line starts with the `Imports` keyword. The last line is "End Class". Format the lines with the courier font. Format them with a new style, and name the new style "Code".
1. Finally, select the entire line that contains the output, and format it with the `Code` style.
1. Save the document, and name it SampleDoc.docx.

> [!NOTE]
> If you're using Microsoft Word 2003, select **Word 2007 Document** in the **Save as Type** drop-down list.

## See also

- [Tutorial: Manipulate content in a WordprocessingML document](xml-shape-wordprocessingml-documents.md)
