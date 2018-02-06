---
title: "How to: Change Styles on an Element in the Managed HTML Document Object Model"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "managed HTML DOM [Windows Forms], changing styles on elements"
ms.assetid: 154e8d9f-3e2d-4e8b-a6f3-c85a070e9cc1
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change Styles on an Element in the Managed HTML Document Object Model
You can use styles in HTML to control the appearance of a document and its elements. <xref:System.Windows.Forms.HtmlDocument> and <xref:System.Windows.Forms.HtmlElement> support <xref:System.Windows.Forms.HtmlElement.Style%2A> properties that take style strings of the following format:  
  
 `name1:value1;...;nameN:valueN;`  
  
 Here is a `DIV` with a style string that sets the font to Arial and all text to bold:  
  
 `<DIV style="font-face:arial;font-weight:bold;">`  
  
 `Hello, world!`  
  
 `</DIV>`  
  
 The problem with manipulating styles using the <xref:System.Windows.Forms.HtmlElement.Style%2A> property is that it can prove cumbersome to add to and remove individual style settings from the string. For example, it would become a complex procedure for you to render the previous text in italics whenever the user positions the cursor over the `DIV`, and take italics off when the cursor leaves the `DIV`. Time would become an issue if you need to manipulate a large number of styles in this manner.  
  
 The following procedure contains code that you can use to easily manipulate styles on HTML documents and elements. The procedure requires that you know how to perform basic tasks in Windows Forms, such as creating a new project and adding a control to a form.  
  
### To process style changes in a Windows Forms application  
  
1.  Create a new Windows Forms project.  
  
2.  Create a new class file ending in the extension appropriate for your programming language.  
  
3.  Copy the `StyleGenerator` class code in the Example section of this topic into the class file, and save the code.  
  
4.  Save the following HTML to a file named Test.htm.  
  
    ```  
    <HTML>  
        <BODY>  
  
            <DIV style="font-face:arial;font-weight:bold;">  
                Hello, world!  
            </DIV><P>  
  
            <DIV>  
                Hello again, world!  
            </DIV><P>  
  
        </BODY>  
    </HTML>  
    ```  
  
5.  Add a <xref:System.Windows.Forms.WebBrowser> control named `webBrowser1` to the main form of your project.  
  
6.  Add the following code to your project's code file.  
  
    > [!IMPORTANT]
    >  Ensure that the `webBrowser1_DocumentCompleted` event hander is configured as a listener for the <xref:System.Windows.Forms.WebBrowser.DocumentCompleted> event. In [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)], double-click on the <xref:System.Windows.Forms.WebBrowser> control; in a text editor, configure the listener programmatically.  
  
     [!code-csharp[ManagedDOMStyles#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ManagedDOMStyles/CS/Form1.cs#2)]
     [!code-vb[ManagedDOMStyles#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ManagedDOMStyles/VB/Form1.vb#2)]  
  
7.  Run the project. Run your cursor over the first `DIV` to observe the effects of the code.  
  
## Example  
 The following code example shows the full code for the `StyleGenerator` class, which parses an existing style value, supports adding, changing, and removing styles, and returns a new style value with the requested changes.  
  
 [!code-csharp[ManagedDOMStyles#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ManagedDOMStyles/CS/StyleGenerator.cs#1)]
 [!code-vb[ManagedDOMStyles#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ManagedDOMStyles/VB/StyleGenerator.vb#1)]  
  
## See Also  
 <xref:System.Windows.Forms.HtmlElement>
