---
title: "Managing Namespaces in an XML Document"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 682643fc-b848-4e42-8c0d-50deeaeb5f2a
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Managing Namespaces in an XML Document
XML namespaces associate element and attribute names in an XML document with custom and predefined URIs. To create these associations, you define prefixes for namespace URIs, and use those prefixes to qualify element and attribute names in XML data. Namespaces prevent element and attribute name collisions, and enable elements and attributes of the same name to be handled and validated differently.  
  
<a name="declare"></a>   
## Declaring namespaces  
 To declare a namespace on an element, you use the `xmlns:` attribute:  
  
 `xmlns:<name>=<"uri">`  
  
 where `<name>` is the namespace prefix and `<"uri">` is the URI that identifies the namespace. After you declare the prefix, you can use it to qualify elements and attributes in an XML document and associate them with the namespace URI. Because the namespace prefix is used throughout a document, it should be short in length.  
  
 This example defines two `BOOK` elements. The first element element is qualified by the prefix, `mybook`, and the second element is qualified by the prefix, `bb`. Each prefix is associated with a different namespace URI:  
  
```xml  
<mybook:BOOK xmlns:mybook="http://www.contoso.com/books.dtd">  
<bb:BOOK xmlns:bb="urn:blueyonderairlines">  
```  
  
 To signify that an element is a part of a particular namespace, add the namespace prefix to it. For example, if a `Author` element belongs to the `mybook` namespace, it is declared as `<mybook:Author>`.  
  
<a name="scope"></a>   
## Declaration scope  
 A namespace is effective from its point of declaration until the end of the element it was declared in. In this example, the namespace defined in the `BOOK` element doesn't apply to elements outside the `BOOK` element, such as the `Publisher` element:  
  
```xml  
<Author>Joe Smith</Author>  
<BOOK xmlns:book="http://www.contoso.com">  
    <title>My Wonderful Day</title>  
      <price>$3.95</price>  
</BOOK>  
<Publisher>  
    <Name>MSPress</Name>  
</Publisher>  
```  
  
 A namespace must be declared before it can be used, but it doesn't have to appear at the top of the XML document.  
  
 When you use multiple namespaces in an XML document, you can define one namespace as the default namespace to create a cleaner looking document. The default namespace is declared in the root element and applies to all unqualified elements in the document. Default namespaces apply to elements only, not to attributes.  
  
 To use the default namespace, omit the prefix and the colon from the declaration on the element:  
  
```xml  
<BOOK xmlns="http://www.contoso.com/books.dtd">  
```  
  
## Managing namespaces  
 The <xref:System.Xml.XmlNamespaceManager> class stores a collection of namespace URIs and their prefixes, and lets you look up, add, and remove namespaces from this collection. In certain contexts, this class is required for better XML processing performance. For example, the <xref:System.Xml.Xsl.XsltContext> class uses <xref:System.Xml.XmlNamespaceManager> for XPath support.  
  
 The namespace manager doesn't perform any validation on the namespaces, but assumes that prefixes and namespaces have already been verified and conform to the [W3C Namespaces](https://www.w3.org/TR/REC-xml-names/) specification.  
  
> [!NOTE]
>  [LINQ to XML](https://msdn.microsoft.com/library/f0fe21e9-ee43-4a55-b91a-0800e5782c13) doesn't use <xref:System.Xml.XmlNamespaceManager> to manage namespaces. See [Working with XML Namespaces](https://msdn.microsoft.com/library/e3003209-3234-45be-a832-47feb7927430) in the LINQ documentation for information about managing namespaces when using LINQ to XML.  
  
 Here are some of the management and lookup tasks you can perform with the <xref:System.Xml.XmlNamespaceManager> class. For more information and examples, follow the links to the reference page for each method or property.  
  
|To|Use|  
|--------|---------|  
|Add a namespace|<xref:System.Xml.XmlNamespaceManager.AddNamespace%2A> method|  
|Remove a namespace|<xref:System.Xml.XmlNamespaceManager.RemoveNamespace%2A> method|  
|Find the URI for the default namespace|<xref:System.Xml.XmlNamespaceManager.DefaultNamespace%2A> property|  
|Find the URI for a namespace prefix|<xref:System.Xml.XmlNamespaceManager.LookupNamespace%2A> method|  
|Find the prefix for a namespace URI|<xref:System.Xml.XmlNamespaceManager.LookupPrefix%2A> method|  
|Get a list of namespaces in the current node|<xref:System.Xml.XmlNamespaceManager.GetNamespacesInScope%2A> method|  
|Scope a namespace|<xref:System.Xml.XmlNamespaceManager.PushScope%2A> and <xref:System.Xml.XmlNamespaceManager.PopScope%2A> methods|  
|Check whether a prefix is defined in the current scope|<xref:System.Xml.XmlNamespaceManager.HasNamespace%2A> method|  
|Get the name table used to look up prefixes and URIs|<xref:System.Xml.XmlNamespaceManager.NameTable%2A> property|  
  
## See Also  
 <xref:System.Xml.XmlNamespaceManager>  
 [XML Documents and Data](../../../../docs/standard/data/xml/index.md)
