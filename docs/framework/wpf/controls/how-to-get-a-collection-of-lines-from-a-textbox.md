---
title: "How to: Get a Collection of Lines from a TextBox"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "lines [WPF], getting collection of"
  - "TextBox control [WPF], getting collection of lines"
ms.assetid: a12f529d-b926-47f6-92bf-cad5f17b532a
---
# How to: Get a Collection of Lines from a TextBox
This example shows how to get a collection of lines of text from a <xref:System.Windows.Controls.TextBox>.  
  
## Example  
 The following example shows a simple method that takes a <xref:System.Windows.Controls.TextBox> as the argument, and returns a <xref:System.Collections.Specialized.StringCollection> containing the lines of text in the **TextBox**.  The <xref:System.Windows.Controls.TextBox.LineCount%2A> property is used to determine how many lines are currently in the **TextBox**, and the <xref:System.Windows.Controls.TextBox.GetLineText%2A> method is then used to extract each line and add it to the collection of lines.  
  
 [!code-csharp[TextBox_MiscCode#_TextBox_GetLines](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml.cs#_textbox_getlines)]  
  
## See also

- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
