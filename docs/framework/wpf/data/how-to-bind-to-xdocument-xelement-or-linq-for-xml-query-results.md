---
title: "How to: Bind to XDocument, XElement, or LINQ for XML Query Results"
ms.custom: ""
ms.date: "03/30/2017"
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
  - "data binding [WPF], binding to XDocument"
  - "data binding [WPF], binding to XElement"
ms.assetid: 6a629a49-fe1c-465d-b76a-3dcbf4307b64
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind to XDocument, XElement, or LINQ for XML Query Results
This example demonstrates how to bind XML data to an <xref:System.Windows.Controls.ItemsControl> using <xref:System.Xml.Linq.XDocument>.  
  
## Example  
 The following XAML code defines an <xref:System.Windows.Controls.ItemsControl> and includes a data template for data of type `Planet` in the `http://planetsNS` XML namespace. An XML data type that occupies a namespace must include the namespace in braces, and if it appears where a XAML markup extension could appear, it must precede the namespace with a brace escape sequence. This code binds to dynamic properties that correspond to the <xref:System.Xml.Linq.XContainer.Element%2A> and <xref:System.Xml.Linq.XElement.Attribute%2A> methods of the <xref:System.Xml.Linq.XElement> class. Dynamic properties enable XAML to bind to dynamic properties that share the names of methods. To learn more, see [LINQ to XML Dynamic Properties](/visualstudio/designers/linq-to-xml-dynamic-properties). Notice how the default namespace declaration for the XML does not apply to attribute names.  
  
 [!code-xaml[XLinqExample#StackPanelResources](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XLinqExample/CSharp/Window1.xaml#stackpanelresources)]  
[!code-xaml[XLinqExample#ItemsControl](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XLinqExample/CSharp/Window1.xaml#itemscontrol)]  
  
 The following C# code calls <xref:System.Xml.Linq.XDocument.Load%2A> and sets the stack panel data context to all subelements of the element named `SolarSystemPlanets` in the `http://planetsNS` XML namespace.  
  
 [!code-csharp[XLinqExample#LoadDCFromFile](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XLinqExample/CSharp/Window1.xaml.cs#loaddcfromfile)]
 [!code-vb[XLinqExample#LoadDCFromFile](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XLinqExample/visualbasic/window1.xaml.vb#loaddcfromfile)]  
  
 XML data can be stored as a XAML resource using <xref:System.Windows.Data.ObjectDataProvider>. For a complete example, see  [L2DBForm.xaml Source Code](http://msdn.microsoft.com/library/624e96d4-6d27-4195-8ac2-2f3835f6c57e). The following sample shows how code can set the data context to an object resource.  
  
 [!code-csharp[XLinqExample#LoadDCFromXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XLinqExample/CSharp/Window1.xaml.cs#loaddcfromxaml)]
 [!code-vb[XLinqExample#LoadDCFromXAML](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XLinqExample/visualbasic/window1.xaml.vb#loaddcfromxaml)]  
  
 The dynamic properties that map to <xref:System.Xml.Linq.XContainer.Element%2A> and <xref:System.Xml.Linq.XElement.Attribute%2A> provide flexibility within XAML. Your code can also bind to the results of a LINQ for XML query. This example binds to query results ordered by an element value.  
  
 [!code-csharp[XLinqExample#BindToResults](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XLinqExample/CSharp/Window1.xaml.cs#bindtoresults)]
 [!code-vb[XLinqExample#BindToResults](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XLinqExample/visualbasic/window1.xaml.vb#bindtoresults)]  
  
## See Also  
 [Binding Sources Overview](../../../../docs/framework/wpf/data/binding-sources-overview.md)  
 [WPF Data Binding with LINQ to XML Overview](/visualstudio/designers/wpf-data-binding-with-linq-to-xml-overview)  
 [WPF Data Binding Using LINQ to XML Example](/visualstudio/designers/wpf-data-binding-using-linq-to-xml-example)  
 [LINQ to XML Dynamic Properties](/visualstudio/designers/linq-to-xml-dynamic-properties)
