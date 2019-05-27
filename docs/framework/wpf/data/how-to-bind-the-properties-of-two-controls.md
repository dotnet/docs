---
title: "How to: Bind the Properties of Two Controls"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data binding [WPF], binding properties of two controls"
  - "binding properties of two controls [WPF]"
  - "controls [WPF], binding properties of"
ms.assetid: 06318fac-6afd-4c7d-a277-6d7ef50f47bc
---
# How to: Bind the Properties of Two Controls
This example shows how to bind the property of one instantiated control to that of another using the <xref:System.Windows.Data.Binding.ElementName%2A> property.  
  
## Example  
 The following example shows how to bind the <xref:System.Windows.Controls.Panel.Background%2A> property of a <xref:System.Windows.Controls.Canvas> to the <xref:System.Windows.Controls.Primitives.Selector.SelectedItem%2A>.<xref:System.Windows.Controls.ContentControl.Content%2A> property of a <xref:System.Windows.Controls.ComboBox>:  
  
 [!code-xaml[BindDptoDp#1](~/samples/snippets/csharp/VS_Snippets_Wpf/BindDPtoDP/CS/Window1.xaml#1)]  
  
 When this example is rendered it looks like the following:  
  
![Screenshot showing a combo box with the value green selected and a green square.](./media/how-to-bind-the-properties-of-two-controls/data-binding-bind-background-canvas.png)

> [!NOTE]
> The binding target property (in this example, the <xref:System.Windows.Controls.Panel.Background%2A> property) must be a dependency property. For more information, see [Data Binding Overview](data-binding-overview.md).  
  
## See also

- [Specify the Binding Source](how-to-specify-the-binding-source.md)
- [How-to Topics](data-binding-how-to-topics.md)
