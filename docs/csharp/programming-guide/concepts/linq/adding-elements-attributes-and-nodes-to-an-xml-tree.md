---
title: "Adding Elements, Attributes, and Nodes to an XML Tree (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: db911e4f-40aa-499a-9500-a9763bb6df56
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# Adding Elements, Attributes, and Nodes to an XML Tree (C#)
You can add content (elements, attributes, comments, processing instructions, text, and CDATA) to an existing XML tree.  
  
## Methods for Adding Content  
 The following methods add child content to an <xref:System.Xml.Linq.XElement> or an <xref:System.Xml.Linq.XDocument>:  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Xml.Linq.XContainer.Add%2A>|Adds content at the end of the child content of the <xref:System.Xml.Linq.XContainer>.|  
|<xref:System.Xml.Linq.XContainer.AddFirst%2A>|Adds content at the beginning of the child content of the <xref:System.Xml.Linq.XContainer>.|  
  
 The following methods add content as sibling nodes of an <xref:System.Xml.Linq.XNode>. The most common node to which you add sibling content is <xref:System.Xml.Linq.XElement>, although you can add valid sibling content to other types of nodes such as <xref:System.Xml.Linq.XText> or <xref:System.Xml.Linq.XComment>.  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Xml.Linq.XNode.AddAfterSelf%2A>|Adds content after the <xref:System.Xml.Linq.XNode>.|  
|<xref:System.Xml.Linq.XNode.AddBeforeSelf%2A>|Adds content before the <xref:System.Xml.Linq.XNode>.|  
  
## Example  
  
### Description  
 The following example creates two XML trees, and then modifies one of the trees.  
  
### Code  
  
```csharp  
XElement srcTree = new XElement("Root",   
    new XElement("Element1", 1),  
    new XElement("Element2", 2),  
    new XElement("Element3", 3),  
    new XElement("Element4", 4),  
    new XElement("Element5", 5)  
);  
XElement xmlTree = new XElement("Root",  
    new XElement("Child1", 1),  
    new XElement("Child2", 2),  
    new XElement("Child3", 3),  
    new XElement("Child4", 4),  
    new XElement("Child5", 5)  
);  
xmlTree.Add(new XElement("NewChild", "new content"));  
xmlTree.Add(  
    from el in srcTree.Elements()  
    where (int)el > 3  
    select el  
);  
// Even though Child9 does not exist in srcTree, the following statement will not  
// throw an exception, and nothing will be added to xmlTree.  
xmlTree.Add(srcTree.Element("Child9"));  
Console.WriteLine(xmlTree);  
```  
  
### Comments  
 This code produces the following output:  
  
```xml  
<Root>  
  <Child1>1</Child1>  
  <Child2>2</Child2>  
  <Child3>3</Child3>  
  <Child4>4</Child4>  
  <Child5>5</Child5>  
  <NewChild>new content</NewChild>  
  <Element4>4</Element4>  
  <Element5>5</Element5>  
</Root>  
```  
  
## See Also  
 [Modifying XML Trees (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/modifying-xml-trees-linq-to-xml.md)
