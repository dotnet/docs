---
title: "How to: Bind to XML Data Using an XMLDataProvider and XPath Queries"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XmlDataProvider [WPF], binding to XML data"
  - "data binding [WPF], binding to XML data using XmlDataProvider queries"
  - "binding [WPF], to XML data using XmlDataProvider queries"
ms.assetid: 7dcd018f-16aa-4870-8e47-c1b4ea31e574
---
# How to: Bind to XML Data Using an XMLDataProvider and XPath Queries
This example shows how to bind to XML data using an <xref:System.Windows.Data.XmlDataProvider>.  
  
 With an <xref:System.Windows.Data.XmlDataProvider>, the underlying data that can be accessed through data binding in your application can be any tree of XML nodes. In other words, an <xref:System.Windows.Data.XmlDataProvider> provides a convenient way to use any tree of XML nodes as a binding source.  
  
## Example  
 In the following example, the data is embedded directly as an XML *data island* within the <xref:System.Windows.FrameworkElement.Resources%2A> section. An XML data island must be wrapped in `<x:XData>` tags and always have a single root node, which is *Inventory* in this example.  
  
> [!NOTE]
> The root node of the XML data has an **xmlns** attribute that sets the XML namespace to an empty string. This is a requirement for applying XPath queries to a data island that is inline within the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] page. In this inline case, the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], and thus the data island, inherits the <xref:System.Windows> namespace. Because of this, you need to set the namespace blank to keep XPath queries from being qualified by the <xref:System.Windows> namespace, which would misdirect the queries.  
  
 [!code-xaml[XMLDataSource#1](~/samples/snippets/csharp/VS_Snippets_Wpf/XmlDataSource/CS/Window1.xaml#1)]  
  
 As shown in this example, to create the same binding declaration in attribute syntax you must escape the special characters properly. For more information, see [XML Character Entities and XAML](../../../desktop-wpf/xaml-services/xml-character-entities.md).  
  
 The <xref:System.Windows.Controls.ListBox> will show the following items when this example is run. These are the *Title*s of all of the elements under *Books* with either a *Stock* value of "*out*" or a *Number* value of 3 or greater than or equals to 8. Notice that no *CD* items are returned because the <xref:System.Windows.Data.XmlDataProvider.XPath%2A> value set on the <xref:System.Windows.Data.XmlDataProvider> indicates that only the *Books* elements should be exposed (essentially setting a filter).  
  
 ![Screenshot of the XPath example showing the title of four books.](./media/how-to-bind-to-xml-data-using-an-xmldataprovider-and-xpath-queries/xpath-example-listbox-details.png)  
  
 In this example, the book titles are displayed because the <xref:System.Windows.Data.Binding.XPath%2A> of the <xref:System.Windows.Controls.TextBlock> binding in the <xref:System.Windows.DataTemplate> is set to "*Title*". If you want to display the value of an attribute, such as the *ISBN*, you would set that <xref:System.Windows.Data.Binding.XPath%2A> value to "`@ISBN`".  
  
 The **XPath** properties in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] are handled by the XmlNode.SelectNodes method. You can modify the **XPath** queries to get different results. Here are some examples for the <xref:System.Windows.Data.Binding.XPath%2A> query on the bound <xref:System.Windows.Controls.ListBox> from the previous example:  
  
- `XPath="Book[1]"` will return the first book element ("XML in Action"). Note that **XPath** indexes are based on 1, not 0.  
  
- `XPath="Book[@*]"` will return all book elements with any attributes.  
  
- `XPath="Book[last()-1]"` will return the second to last book element ("Introducing Microsoft .NET").  
  
- `XPath="*[position()>3]"` will return all of the book elements except for the first 3.  
  
 When you run an **XPath** query, it returns an <xref:System.Xml.XmlNode> or a list of XmlNodes. <xref:System.Xml.XmlNode> is a common language runtime (CLR) object, which means you can use the <xref:System.Windows.Data.Binding.Path%2A> property to bind to the common language runtime (CLR) properties. Consider the previous example again. If the rest of the example stays the same and you change the <xref:System.Windows.Controls.TextBlock> binding to the following, you will see the names of the returned XmlNodes in the <xref:System.Windows.Controls.ListBox>. In this case, the name of all the returned nodes is "*Book*".  
  
 [!code-xaml[XmlDataSourceVariation#XmlNodePath](~/samples/snippets/csharp/VS_Snippets_Wpf/XmlDataSourceVariation/CS/Page1.xaml#xmlnodepath)]  
  
 In some applications, embedding the XML as a data island within the source of the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] page can be inconvenient because the exact content of the data must be known at compile time. Therefore, obtaining the data from an external XML file is also supported, as in the following example:  
  
 [!code-xaml[XMLDataSource2#XmlFileExample](~/samples/snippets/csharp/VS_Snippets_Wpf/XmlDataSource2/CS/Window1.xaml#xmlfileexample)]  
  
 If the XML data resides in a remote XML file, you would define access to the data by assigning an appropriate URL to the <xref:System.Windows.Data.XmlDataProvider.Source%2A> attribute as follows:  
  
```xml  
<XmlDataProvider x:Key="BookData" Source="http://MyUrl" XPath="Books"/>  
```  
  
## See also

- <xref:System.Windows.Data.ObjectDataProvider>
- [Bind to XDocument, XElement, or LINQ for XML Query Results](how-to-bind-to-xdocument-xelement-or-linq-for-xml-query-results.md)
- [Use the Master-Detail Pattern with Hierarchical XML Data](how-to-use-the-master-detail-pattern-with-hierarchical-xml-data.md)
- [Binding Sources Overview](binding-sources-overview.md)
- [Data Binding Overview](../../../desktop-wpf/data/data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
