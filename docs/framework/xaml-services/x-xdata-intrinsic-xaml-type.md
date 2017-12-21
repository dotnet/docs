---
title: "x:XData Intrinsic XAML Type"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "x:XData"
  - "XData"
  - "xXData"
helpviewer_keywords: 
  - "XAML [XAML Services], x:XData directive element"
  - "XData in XAML [XAML Services]"
  - "x:XData XAML directive element [XAML Services]"
ms.assetid: 7ce209c2-621b-4977-b643-565f7e663534
caps.latest.revision: 17
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:XData Intrinsic XAML Type
Enables placement of XML data islands within a XAML production. XML elements within `x:XData` should not be treated by XAML processors as if they are a part of the acting default XAML namespace or any other XAML namespace. `x:XData` can contain arbitrary well-formed XML.  
  
## XAML Object Element Usage  
  
```  
<x:XData>  
  <elementDataRoot>  
    [elementData]  
  </elementDataRoot>  
</x:XData>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`elementDataRoot`|The single root element of the enclosed data island. For most eventual consumers, XML that does not have a single root is considered invalid. In particular, a single root is required if the `x:XData` is intended as an XML data source for WPF or many other technologies that use XML sources for data binding.|  
|`[elementData]`|Optional. XML that represents the XML data. Any number of elements can be contained as element data and nested elements can be contained in other elements; however, the general rules of XML apply.|  
  
## Remarks  
 The XML elements within an `x:XData` object can re-declare all possible namespaces and prefixes of the containing XMLDOM within the data.  
  
 Programmatic access to XML data and the `x:XData` intrinsic XAML type is possible in .NET Framework XAML Services through the <xref:System.Windows.Markup.XData> class.  
  
## WPF Usage Notes  
 The `x:XData` object is primarily used as a child object of an <xref:System.Windows.Data.XmlDataProvider>, or alternatively, as the child object of the <xref:System.Windows.Data.XmlDataProvider.XmlSerializer%2A?displayProperty=nameWithType> property (in XAML, this is typically expressed in property element syntax).  
  
 The data should typically redefine the base XML namespace within the data island to be a new default XML namespace (set to an empty string). This is easiest for simple data islands because the <xref:System.Windows.Data.Binding.XPath%2A> expressions that are used to reference and bind to the data can avoid inclusion of prefixes. More complex data islands might define multiple prefixes for the data and use a specific prefix for the XML namespace at the root. In this case, all <xref:System.Windows.Data.Binding.XPath%2A> expression references should include the appropriate namespace-mapped prefix. For more information, see [Data Binding Overview](../../../docs/framework/wpf/data/data-binding-overview.md).  
  
 Technically, `x:XData` can be used as the content of any property of type <xref:System.Xml.Serialization.IXmlSerializable>. However, <xref:System.Windows.Data.XmlDataProvider.XmlSerializer%2A?displayProperty=nameWithType> is the only prominent implementation.  
  
## See Also  
 <xref:System.Windows.Data.XmlDataProvider>  
 [Data Binding Overview](../../../docs/framework/wpf/data/data-binding-overview.md)  
 [Binding Markup Extension](../../../docs/framework/wpf/advanced/binding-markup-extension.md)
