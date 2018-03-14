---
title: "How to: Make Data Available for Binding in XAML"
ms.custom: ""
ms.date: "01/29/2018"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data binding [WPF], making data available for binding"
  - "binding data [WPF], making data available for"
ms.assetid: 7103c2e8-0e31-4a13-bf12-ca382221a8d5
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Make Data Available for Binding in XAML
This topic discusses the different ways you can make data available for binding in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)], depending on the needs of your application.  
  
## Example  
 If you have a [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] object you would like to bind to from [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], one way you can make the object available for binding is to define it as a resource and give it an `x:Key`. In the following example, you have a `Person` object with a string property named `PersonName`. The `Person` object, which is shown by the highlighted line that contains the `<src>` element, is defined in the namespace called `SDKSample`.  
  
 [!code-xaml[SimpleBinding#Instantiation](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SimpleBinding/CSharp/Page1.xaml?highlight=9,37)]  
  
 You can then bind the <xref:System.Windows.Controls.TextBlock> control to the object in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], as the highlighted line that contains the `<TextBlock>` element shows. 
  
 Alternatively, you can use the <xref:System.Windows.Data.ObjectDataProvider> class, as in the following example:  
  
 [!code-xaml[ObjectDataProvider}](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleBinding/VisualBasic/Page1.xaml?highlight=10-14,42)]  
  
 You define the binding the same way, as the highlighted line that contains the `<TextBlock>` element shows.  
  
 In this particular example, the result is the same: you have a <xref:System.Windows.Controls.TextBlock> with the text content `Joe`. However, the <xref:System.Windows.Data.ObjectDataProvider> class provides functionality such as the ability to bind to the result of a method. You can choose to use the <xref:System.Windows.Data.ObjectDataProvider> class if you need the functionality it provides.  
  
 However, if you are binding to an object that has already been created, you need to set the `DataContext` in code, as in the following example.  
  
 [!code-csharp[ADODataSet#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ADODataSet/CSharp/Window1.xaml.cs#1)]
 [!code-vb[ADODataSet#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ADODataSet/VisualBasic/Window1.xaml.vb#1)]  
  
 To access [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data for binding using the <xref:System.Windows.Data.XmlDataProvider> class, see [Bind to XML Data Using an XMLDataProvider and XPath Queries](../../../../docs/framework/wpf/data/how-to-bind-to-xml-data-using-an-xmldataprovider-and-xpath-queries.md). To access [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data for binding using the <xref:System.Windows.Data.ObjectDataProvider> class, see [Bind to XDocument, XElement, or LINQ for XML Query Results](../../../../docs/framework/wpf/data/how-to-bind-to-xdocument-xelement-or-linq-for-xml-query-results.md).  
  
 For information about the different ways you can specify the data you are binding to, see [Specify the Binding Source](../../../../docs/framework/wpf/data/how-to-specify-the-binding-source.md). For information about what types of data you can bind to or how to implement your own [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] objects for binding, see [Binding Sources Overview](../../../../docs/framework/wpf/data/binding-sources-overview.md).  
  
## See Also  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
