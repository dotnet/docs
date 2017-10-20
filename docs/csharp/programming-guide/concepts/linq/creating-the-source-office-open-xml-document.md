---
title: "Creating the Source Office Open XML Document (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 653c8cdb-73be-4dc2-927f-924cfb4ed9ed
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# Creating the Source Office Open XML Document (C#)
This topic shows how to create the Office Open XML WordprocessingML document that the other examples in this tutorial use. If you follow these instructions, your output will match the output provided in each example.  
  
 However, the examples in this tutorial will work with any valid WordprocessingML document.  
  
 To create the document that this tutorial uses, you must either have Microsoft Office 2007 or later installed, or you must have Microsoft Office 2003 with the Microsoft Office Compatibility Pack for Word, Excel, and PowerPoint 2007 File Formats.  
  
## Creating the WordprocessingML Document  
  
#### To create the WordprocessingML document  
  
1.  Create a new Microsoft Word document.  
  
2.  Paste the following text into the new document:  
  
    ```  
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
  
3.  Format the first line with the style "Heading 1".  
  
4.  Select the lines that contain the C# code. The first line starts with the `using` keyword. The last line is the last closing brace. Format the lines with the courier font. Format them with a new style, and name the new style "Code".  
  
5.  Finally, select the entire line that contains the output, and format it with the `Code` style.  
  
6.  Save the document, and name it SampleDoc.docx.  
  
    > [!NOTE]
    >  If you are using Microsoft Word 2003, select **Word 2007 Document** in the **Save as Type** drop-down list.  
  
## See Also  
 [Tutorial: Manipulating Content in a WordprocessingML Document (C#)](../../../../csharp/programming-guide/concepts/linq/tutorial-manipulating-content-in-a-wordprocessingml-document.md)
