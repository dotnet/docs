---
title: "XElement Class Overview (C#)"
ms.date: 07/20/2015
ms.assetid: 2b9f0cd8-a1d1-4037-accf-0f38a410fa11
---
# XElement Class Overview (C#)
The <xref:System.Xml.Linq.XElement> class is one of the fundamental classes in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)]. It represents an XML element. You can use this class to create elements; change the content of the element; add, change, or delete child elements; add attributes to an element; or serialize the contents of an element in text form. You can also interoperate with other classes in <xref:System.Xml?displayProperty=nameWithType>, such as <xref:System.Xml.XmlReader>, <xref:System.Xml.XmlWriter>, and <xref:System.Xml.Xsl.XslCompiledTransform>.  
  
This topic describes the functionality provided by the <xref:System.Xml.Linq.XElement> class.  
  
## Constructing XML Trees  
 You can construct XML trees in a variety of ways, including the following:  
  
- You can construct an XML tree in code. For more information, see [Creating XML Trees (C#)](./linq-to-xml-overview.md).  
  
- You can parse XML from various sources, including a <xref:System.IO.TextReader>, text files, or a Web address (URL). For more information, see [Parsing XML (C#)](./how-to-parse-a-string.md).  
  
- You can use an <xref:System.Xml.XmlReader> to populate the tree. For more information, see <xref:System.Xml.Linq.XNode.ReadFrom%2A>.  
  
- If you have a module that can write content to an <xref:System.Xml.XmlWriter>, you can use the <xref:System.Xml.Linq.XContainer.CreateWriter%2A> method to create a writer, pass the writer to the module, and then use the content that is written to the <xref:System.Xml.XmlWriter> to populate the XML tree.  
  
 However, the most common way to create an XML tree is as follows:  
  
```csharp  
XElement contacts =  
    new XElement("Contacts",  
        new XElement("Contact",  
            new XElement("Name", "Patrick Hines"),   
            new XElement("Phone", "206-555-0144"),  
            new XElement("Address",  
                new XElement("Street1", "123 Main St"),  
                new XElement("City", "Mercer Island"),  
                new XElement("State", "WA"),  
                new XElement("Postal", "68042")  
            )  
        )  
    );  
```  
  
 Another very common technique for creating an XML tree involves using the results of a LINQ query to populate an XML tree, as shown in the following example:  
  
```csharp  
XElement srcTree = new XElement("Root",  
    new XElement("Element", 1),  
    new XElement("Element", 2),  
    new XElement("Element", 3),  
    new XElement("Element", 4),  
    new XElement("Element", 5)  
);  
XElement xmlTree = new XElement("Root",  
    new XElement("Child", 1),  
    new XElement("Child", 2),  
    from el in srcTree.Elements()  
    where (int)el > 2  
    select el  
);  
Console.WriteLine(xmlTree);  
```  
  
 This example produces the following output:  
  
```xml  
<Root>  
  <Child>1</Child>  
  <Child>2</Child>  
  <Element>3</Element>  
  <Element>4</Element>  
  <Element>5</Element>  
</Root>  
```  
  
## Serializing XML Trees  
 You can serialize the XML tree to a <xref:System.IO.File>, a <xref:System.IO.TextWriter>, or an <xref:System.Xml.XmlWriter>.  
  
 For more information, see [Serializing XML Trees (C#)](./preserving-white-space-while-serializing.md).  
  
## Retrieving XML Data via Axis Methods  
 You can use axis methods to retrieve attributes, child elements, descendant elements, and ancestor elements. LINQ queries operate on axis methods, and provide several flexible and powerful ways to navigate through and process an XML tree.  
  
 For more information, see [LINQ to XML Axes (C#)](./linq-to-xml-axes-overview.md).  
  
## Querying XML Trees  
 You can write LINQ queries that extract data from an XML tree.  
  
 For more information, see [Querying XML Trees (C#)](./how-to-find-an-element-with-a-specific-attribute.md).  
  
## Modifying XML Trees  
 You can modify an element in a variety of ways, including changing its content or attributes. You can also remove an element from its parent.  
  
 For more information, see [Modifying XML Trees (LINQ to XML) (C#)](./in-memory-xml-tree-modification-vs-functional-construction-linq-to-xml.md).  
  
## See also

- [LINQ to XML Programming Overview (C#)](serializing-to-files-textwriters-and-xmlwriters.md)
