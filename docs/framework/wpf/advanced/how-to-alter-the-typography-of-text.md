---
title: "How-to: Alter the Typography of Text"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "setting Typography attributes [WPF]"
  - "Typography attribute [WPF], setting"
ms.assetid: 19a3b49b-60a2-4c11-a786-e26b4c965588
---
# How-to: Alter the Typography of Text
The following example shows how to set the <xref:System.Windows.Documents.TextElement.Typography%2A> attribute, using <xref:System.Windows.Documents.Paragraph> as the example element.  
  
## Example  
 [!code-xaml[TextElementSnippets#_TextElement_TypogXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextElementSnippets/CSharp/Window1.xaml#_textelement_typogxaml)]  
  
 The following figure shows how this example renders.  
  
 ![Screenshot: Text with altered typography](./media/textelement-typog.png "TextElement_Typog")  
  
 In contrast, the following figure shows how a similar example with default typographic properties renders.  
  
 ![Screenshot: Text with altered typography](./media/textelement-typog-default.png "TextElement_Typog_Default")  
  
## Example  
 The following example shows how to set the <xref:System.Windows.Controls.TextBox.Typography%2A> property programmatically.  
  
 [!code-csharp[TextElementSnippets#_TextElement_Typog](~/samples/snippets/csharp/VS_Snippets_Wpf/TextElementSnippets/CSharp/Window1.xaml.cs#_textelement_typog)]
 [!code-vb[TextElementSnippets#_TextElement_Typog](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextElementSnippets/visualbasic/window1.xaml.vb#_textelement_typog)]  
  
## See also

- [Flow Document Overview](flow-document-overview.md)
