---
title: "How to: Create a Simple Binding"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "simple binding [WPF], creating"
  - "data binding [WPF], creating simple bindings"
  - "binding data [WPF], creating"
ms.assetid: 69b80f72-6259-44cb-8294-5bdcebca1e08
---
# How to: Create a Simple Binding
This example shows you how to create a simple <xref:System.Windows.Data.Binding>.  
  
## Example  
 In this example, you have a `Person` object with a string property named `PersonName`. The `Person` object is defined in the namespace called `SDKSample`.  
  
 The highlighted line that contains the `<src>` element in the following example instantiates the `Person` object with a `PersonName` property value of `Joe`. This is done in the `Resources` section and assigned an `x:Key`.  
  
 [!code-xaml[SimpleBinding](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleBinding/CSharp/Page1.xaml?highlight=9,37)]  
  
 The highlighted line that contains the `<TextBlock>` element then binds the <xref:System.Windows.Controls.TextBlock> control to the `PersonName` property. As a result, the <xref:System.Windows.Controls.TextBlock> appears with the value "Joe".  
  
## See also

- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
