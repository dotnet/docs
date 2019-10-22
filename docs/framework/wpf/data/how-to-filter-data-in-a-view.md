---
title: "How to: Filter Data in a View"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "views [WPF], filtering data"
  - "filtering data in views [WPF]"
  - "data binding [WPF], filtering data in views"
ms.assetid: c76e8606-4cc4-45a8-9110-e2ec66dc6afd
---
# How to: Filter Data in a View
This example shows how to filter data in a view.

## Example
 To create a filter, define a method that provides the filtering logic. The method is used as a callback and accepts a parameter of type `object`. The following method returns all the `Order` objects with the `filled` property set to "No", filtering out the rest of the objects.

 [!code-csharp[SortFilter#2](~/samples/snippets/csharp/VS_Snippets_Wpf/SortFilter/CSharp/Page1.xaml.cs#2)]
 [!code-vb[SortFilter#2](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SortFilter/VisualBasic/Page1.xaml.vb#2)]

 You can then apply the filter, as shown in the following example. In this example, `myCollectionView` is a <xref:System.Windows.Data.ListCollectionView> object.

 [!code-csharp[SortFilter#Filter](~/samples/snippets/csharp/VS_Snippets_Wpf/SortFilter/CSharp/Page1.xaml.cs#filter)]
 [!code-vb[SortFilter#Filter](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SortFilter/VisualBasic/Page1.xaml.vb#filter)]

 To undo filtering, you can set the <xref:System.Windows.Data.CollectionView.Filter%2A> property to `null`:

 [!code-csharp[SortFilter#Unfilter](~/samples/snippets/csharp/VS_Snippets_Wpf/SortFilter/CSharp/Page1.xaml.cs#unfilter)]
 [!code-vb[SortFilter#Unfilter](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SortFilter/VisualBasic/Page1.xaml.vb#unfilter)]

 For information about how to create or obtain a view, see [Get the Default View of a Data Collection](how-to-get-the-default-view-of-a-data-collection.md). For the complete example, see [Sorting and Filtering Items in a View Sample](https://go.microsoft.com/fwlink/?LinkID=160040).

 If your view object comes from a <xref:System.Windows.Data.CollectionViewSource> object, you apply filtering logic by setting an event handler for the <xref:System.Windows.Data.CollectionViewSource.Filter> event. In the following example, `listingDataView` is an instance of <xref:System.Windows.Data.CollectionViewSource>.

 [!code-csharp[DataBindingLab#10](~/samples/snippets/csharp/VS_Snippets_Wpf/DataBindingLab/CSharp/MainWindow.xaml.cs#10)]
 [!code-vb[DataBindingLab#10](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DataBindingLab/VisualBasic/MainWindow.xaml.vb#10)]

 The following shows the implementation of the example `ShowOnlyBargainsFilter` filter event handler. This event handler uses the <xref:System.Windows.Data.FilterEventArgs.Accepted%2A> property to filter out `AuctionItem` objects that have a `CurrentPrice` of $25 or greater.

 [!code-csharp[DataBindingLab#5](~/samples/snippets/csharp/VS_Snippets_Wpf/DataBindingLab/CSharp/MainWindow.xaml.cs#5)]
 [!code-vb[DataBindingLab#5](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DataBindingLab/VisualBasic/MainWindow.xaml.vb#5)]

## See also

- <xref:System.Windows.Data.CollectionView.CanFilter%2A>
- <xref:System.Windows.Data.BindingListCollectionView.CustomFilter%2A>
- [Data Binding Overview](../../../desktop-wpf/data/data-binding-overview.md)
- [Sort Data in a View](how-to-sort-data-in-a-view.md)
- [How-to Topics](data-binding-how-to-topics.md)
