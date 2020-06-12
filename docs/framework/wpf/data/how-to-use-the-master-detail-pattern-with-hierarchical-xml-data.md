---
title: "How to: Use the Master-Detail Pattern with Hierarchical XML Data"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data binding [WPF], Master-Detail data paradigm"
  - "Master-Detail data paradigm"
ms.assetid: eb8dbdd8-5871-42bb-a16b-04e655fea677
---
# How to: Use the Master-Detail Pattern with Hierarchical XML Data
This example shows how to implement the master-detail scenario with XML data.  
  
## Example  
 This example is the XML data version of the example discussed in [Use the Master-Detail Pattern with Hierarchical Data](how-to-use-the-master-detail-pattern-with-hierarchical-data.md). In this example, the data is from the file `League.xml`. Note how the third <xref:System.Windows.Controls.ListBox> control tracks selection changes in the second <xref:System.Windows.Controls.ListBox> by binding to its <xref:System.Windows.Controls.Primitives.Selector.SelectedValue%2A> property.  
  
 [!code-xaml[MasterDetailXml#HowTo1](~/samples/snippets/csharp/VS_Snippets_Wpf/MasterDetailXml/CS/Window1.xaml#howto1)]  
[!code-xaml[MasterDetailXml#HowTo2](~/samples/snippets/csharp/VS_Snippets_Wpf/MasterDetailXml/CS/Window1.xaml#howto2)]  
  
## See also

- <xref:System.Windows.HierarchicalDataTemplate>
- [How-to Topics](data-binding-how-to-topics.md)
