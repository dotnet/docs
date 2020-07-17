---
title: "How to: Make a TextBox Control Read-Only"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "read-only TextBox controls [WPF]"
  - "TextBox control read-only"
ms.assetid: e707ec59-8b22-473e-b77c-3060a237517a
---
# How to: Make a TextBox Control Read-Only
This example shows how to configure a <xref:System.Windows.Controls.TextBox> control to not allow user input or modification.  
  
## Example  
 To prevent users from modifying the contents of a <xref:System.Windows.Controls.TextBox> control, set the <xref:System.Windows.Controls.Primitives.TextBoxBase.IsReadOnly%2A> attribute to **true**.  
  
 [!code-xaml[TextBox_MiscCode#_ReadOnlyTextBoxXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml#_readonlytextboxxaml)]  
  
 The <xref:System.Windows.Controls.Primitives.TextBoxBase.IsReadOnly%2A> attribute affects user input only; it does not affect text set in the [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] description of a <xref:System.Windows.Controls.TextBox> control, or text set programmatically through the <xref:System.Windows.Controls.TextBox.Text%2A> property.  
  
 The default value of <xref:System.Windows.Controls.Primitives.TextBoxBase.IsReadOnly%2A> is **false**.  
  
## See also

- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
