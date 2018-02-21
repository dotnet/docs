---
title: "How to: Bind to XML Data Using an XMLDataProvider and XPath Queries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "XmlDataProvider [WPF], binding to XML data"
  - "data binding [WPF], binding to XML data using XmlDataProvider queries"
  - "binding [WPF], to XML data using XmlDataProvider queries"
ms.assetid: 7dcd018f-16aa-4870-8e47-c1b4ea31e574
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind to XML Data Using an XMLDataProvider and XPath Queries
This example shows how to bind to [!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)] data using an <xref:System.Windows.Data.XmlDataProvider>.  
  
 With an <xref:System.Windows.Data.XmlDataProvider>, the underlying data that can be accessed through data binding in your application can be any tree of [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] nodes. In other words, an <xref:System.Windows.Data.XmlDataProvider> provides a convenient way to use any tree of [!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)] nodes as a binding source.  
  
## Example  
 In the following example, the data is embedded directly as an [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] *data island* within the <xref:System.Windows.FrameworkElement.Resources%2A> section. An [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data island must be wrapped in `<x:XData>` tags and always have a single root node, which is *Inventory* in this example.  
  
> [!NOTE]
>  The root node of the [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data has an **xmlns** attribute that sets the [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] namespace to an empty string. This is a requirement for applying XPath queries to a data island that is inline within the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] page. In this inline case, the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], and thus the data island, inherits the <xref:System.Windows> namespace. Because of this, you need to set the namespace blank to keep XPath queries from being qualified by the <xref:System.Windows> namespace, which would misdirect the queries.  
  
 [!code-xaml[XMLDataSource#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XmlDataSource/CS/Window1.xaml#1)]  
  
 As shown in this example, to create the same binding declaration in attribute syntax you must escape the special characters properly. For more information, see [XML Character Entities and XAML](../../../../docs/framework/xaml-services/xml-character-entities-and-xaml.md).  
  
 The <xref:System.Windows.Controls.ListBox> will show the following items when this example is run. These are the *Title*s of all of the elements under *Books* with either a *Stock* value of "*out*" or a *Number* value of 3 or greater than or equals to 8. Notice that no *CD* items are returned because the <xref:System.Windows.Data.XmlDataProvider.XPath%2A> value set on the <xref:System.Windows.Data.XmlDataProvider> indicates that only the *Books* elements should be exposed (essentially setting a filter).  
  
 ![XPath Example](../../../../docs/framework/wpf/data/media/xpathexample.PNG "XPathExample")  
  
 In this example, the book titles are displayed because the <xref:System.Windows.Data.Binding.XPath%2A> of the <xref:System.Windows.Controls.TextBlock> binding in the <xref:System.Windows.DataTemplate> is set to "*Title*". If you want to display the value of an attribute, such as the *ISBN*, you would set that <xref:System.Windows.Data.Binding.XPath%2A> value to "`@ISBN`".  
  
 The **XPath** properties in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] are handled by the XmlNode.SelectNodes method. You can modify the **XPath** queries to get different results. Here are some examples for the <xref:System.Windows.Data.Binding.XPath%2A> query on the bound <xref:System.Windows.Controls.ListBox> from the previous example:  
  
-   `XPath="Book[1]"` will return the first book element ("XML in Action"). Note that **XPath** indexes are based on 1, not 0.  
  
-   `XPath="Book[@*]"` will return all book elements with any attributes.  
  
-   `XPath="Book[last()-1]"` will return the second to last book element ("Introducing Microsoft .NET").  
  
-   `XPath="*[position()>3]"` will return all of the book elements except for the first 3.  
  
 When you run an **XPath** query, it returns an <xref:System.Xml.XmlNode> or a list of XmlNodes. <xref:System.Xml.XmlNode> is a [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] object, which means you can use the <xref:System.Windows.Data.Binding.Path%2A> property to bind to the [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] properties. Consider the previous example again. If the rest of the example stays the same and you change the <xref:System.Windows.Controls.TextBlock> binding to the following, you will see the names of the returned XmlNodes in the <xref:System.Windows.Controls.ListBox>. In this case, the name of all the returned nodes is "*Book*".  
  
 [!code-xaml[XmlDataSourceVariation#XmlNodePath](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XmlDataSourceVariation/CS/Page1.xaml#xmlnodepath)]  
  
 In some applications, embedding the [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] as a data island within the source of the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] page can be inconvenient because the exact content of the data must be known at compile time. Therefore, obtaining the data from an external [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] file is also supported, as in the following example:  
  
 [!code-xaml[XMLDataSource2#XmlFileExample](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XmlDataSource2/CS/Window1.xaml#xmlfileexample)]  
  
 If the [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data resides in a remote [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] file, you would define access to the data by assigning an appropriate [!INCLUDE[TLA2#tla_url](../../../../includes/tla2sharptla-url-md.md)] to the <xref:System.Windows.Data.XmlDataProvider.Source%2A> attribute as follows:  
  
```xml  
<XmlDataProvider x:Key="BookData" Source="http://MyUrl" XPath="Books"/>  
```  
  
## See Also  
 <xref:System.Windows.Data.ObjectDataProvider>  
 [Bind to XDocument, XElement, or LINQ for XML Query Results](../../../../docs/framework/wpf/data/how-to-bind-to-xdocument-xelement-or-linq-for-xml-query-results.md)  
 [Use the Master-Detail Pattern with Hierarchical XML Data](../../../../docs/framework/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-xml-data.md)  
 [Binding Sources Overview](../../../../docs/framework/wpf/data/binding-sources-overview.md)  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/data/data-binding-how-to-topics.md)
