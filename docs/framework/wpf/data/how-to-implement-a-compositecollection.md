---
title: "How to: Implement a CompositeCollection"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data binding [WPF], CompositeCollection class"
ms.assetid: 0d8fc84c-7920-427f-8ad7-d55ca656c170
---
# How to: Implement a CompositeCollection
## Example  
 The following example shows how to display multiple collections and items as one list using the <xref:System.Windows.Data.CompositeCollection> class. In this example, `GreekGods` is an <xref:System.Collections.ObjectModel.ObservableCollection%601> of `GreekGod` custom objects. Data templates are defined so that `GreekGod` objects and `GreekHero` objects appear with a gold and a cyan foreground color respectively.  
  
 [!code-xaml[CompositeCollections#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CompositeCollections/CS/Window1.xaml#1)]  
  
## See also
 <xref:System.Windows.Data.CollectionContainer>  
 <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A>  
 <xref:System.Windows.Data.XmlDataProvider>  
 <xref:System.Windows.DataTemplate>  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
