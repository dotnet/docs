---
title: "Delimiters for Documentation Tags (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "XML [C#], delimiters"
  - "/** */ delimiters for C# documentation tags"
  - "/// delimiter for C# documentation"
ms.assetid: 9b2bdd18-4f5c-4c0b-988e-fb992e0d233e
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
---
# Delimiters for Documentation Tags (C# Programming Guide)
The use of XML doc comments requires delimiters, which indicate to the compiler where a documentation comment begins and ends. You can use the following kinds of delimiters with the XML documentation tags:  
  
 `///`  
 Single-line delimiter. This is the form that is shown in documentation examples and used by the Visual C# project templates. If there is a white space character following the delimiter, that character is not included in the XML output.  
  
> [!NOTE]
>  The Visual Studio IDE has a feature called Smart Comment Editing that automatically inserts the \<summary> and \</summary> tags and moves your cursor within these tags after you type the `///` delimiter in the Code Editor. You can turn this feature on or off in the [Options dialog box](/visualstudio/ide/reference/options-text-editor-csharp-advanced).  
  
 `/** */`  
 Multiline delimiters.  
  
 There are some formatting rules to follow when you use the `/** */` delimiters.  
  
-   On the line that contains the `/**` delimiter, if the remainder of the line is white space, the line is not processed for comments. If the first character after the `/**` delimiter is white space, that white space character is ignored and the rest of the line is processed. Otherwise, the entire text of the line after the `/**` delimiter is processed as part of the comment.  
  
-   On the line that contains the `*/` delimiter, if there is only white space up to the `*/` delimiter, that line is ignored. Otherwise, the text on the line up to the `*/` delimiter is processed as part of the comment, subject to the pattern-matching rules described in the following bullet.  
  
-   For the lines after the one that begins with the `/**` delimiter, the compiler looks for a common pattern at the beginning of each line. The pattern can consist of optional white space and an asterisk (`*`), followed by more optional white space. If the compiler finds a common pattern at the beginning of each line that does not begin with the `/**` delimiter or the `*/` delimiter, it ignores that pattern for each line.  
  
 The following examples illustrate these rules.  
  
-   The only part of the following comment that will be processed is the line that begins with `<summary>`. The three tag formats produce the same comments.  
  
    ```  
    /** <summary>text</summary> */   
  
    /**   
    <summary>text</summary>   
    */   
  
    /**   
     * <summary>text</summary>   
    */  
    ```  
  
-   The compiler identifies a common pattern of " * " at the beginning of the second and third lines. The pattern is not included in the output.  
  
    ```  
    /**   
     * <summary>   
     * text </summary>*/   
    ```  
  
-   The compiler finds no common pattern in the following comment because the second character on the third line is not an asterisk. Therefore, all text on the second and third lines is processed as part of the comment.  
  
    ```  
    /**   
     * <summary>   
       text </summary>  
    */   
    ```  
  
-   The compiler finds no pattern in the following comment for two reasons. First, the number of spaces before the asterisk is not consistent. Second, the fifth line begins with a tab, which does not match spaces. Therefore, all text from lines two through five is processed as part of the comment.  
  
    ```  
    /**   
      * <summary>   
      * text   
     *  text2   
        *  </summary>   
    */   
    ```  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [XML Documentation Comments](../../../csharp/programming-guide/xmldoc/xml-documentation-comments.md)  
 [/doc (C# Compiler Options)](../../../csharp/language-reference/compiler-options/doc-compiler-option.md)  
 [XML Documentation Comments](../../../csharp/programming-guide/xmldoc/xml-documentation-comments.md)
