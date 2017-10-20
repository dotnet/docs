---
title: "Comparison of XPath and LINQ to XML2"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 87d361b1-daa9-4fd4-a53a-cbfa40111ad3
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# Comparison of XPath and LINQ to XML
XPath and [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] offer some similar functionality. Both can be used to query an XML tree, returning such results as a collection of elements, a collection of attributes, a collection of nodes, or the value of an element or attribute. However, there are also some differences.  
  
## Differences Between XPath and LINQ to XML  
 XPath does not allow projection of new types. It can only return collections of nodes from the tree, whereas [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] can execute a query and project an object graph or an XML tree in a new shape. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] queries encompass much more functionality and are much more powerful than XPath expressions.  
  
 XPath expressions exist in isolation within a string. The C# compiler cannot help parse the XPath expression at compile time. By contrast, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] queries are parsed and compiled by the C# compiler. The compiler is able to catch many query errors.  
  
 XPath results are not strongly typed. In a number of circumstances, the result of evaluating an XPath expression is an object, and it is up to the developer to determine the proper type and cast the result as necessary. By contrast, the projections from a [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] query are strongly typed.  
  
## Result Ordering  
 The XPath 1.0 Recommendation states that a collection that is the result of evaluating an XPath expression is unordered.  
  
 However, when iterating through a collection returned by a [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] XPath axis method, the nodes in the collection are returned in document order. This is the case even when accessing the XPath axes where predicates are expressed in terms of reverse document order, such as `preceding` and `preceding-sibling`.  
  
 By contrast, most of the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] axes return collections in document order, but two of them, <xref:System.Xml.Linq.XNode.Ancestors%2A> and <xref:System.Xml.Linq.XElement.AncestorsAndSelf%2A>, return collections in reverse document order. The following table enumerates the axes, and indicates collection order for each:  
  
|LINQ to XML axis|Ordering|  
|----------------------|--------------|  
|XContainer.DescendantNodes|Document order|  
|XContainer.Descendants|Document order|  
|XContainer.Elements|Document order|  
|XContainer.Nodes|Document order|  
|XContainer.NodesAfterSelf|Document order|  
|XContainer.NodesBeforeSelf|Document order|  
|XElement.AncestorsAndSelf|Reverse document order|  
|XElement.Attributes|Document order|  
|XElement.DescendantNodesAndSelf|Document order|  
|XElement.DescendantsAndSelf|Document order|  
|XNode.Ancestors|Reverse document order|  
|XNode.ElementsAfterSelf|Document order|  
|XNode.ElementsBeforeSelf|Document order|  
|XNode.NodesAfterSelf|Document order|  
|XNode.NodesBeforeSelf|Document order|  
  
## Positional Predicates  
 Within an XPath expression, positional predicates are expressed in terms of document order for many axes, but are expressed in reverse document order for reverse axes, which are `preceding`, `preceding-sibling`, `ancestor`, and `ancestor-or-self`. For example, the XPath expression `preceding-sibling::*[1]` returns the immediately preceding sibling. This is the case even though the final result set is presented in document order.  
  
 By contrast, all positional predicates in LINQ to XML are always expressed in terms of the order of the axis. For example, `anElement.ElementsBeforeSelf().ToList()[0]` returns the first child element of the parent of the queried element, not the immediate preceding sibling. Another example: `anElement.Ancestors().ToList()[0]` returns the parent element.  
  
 Note that the above approach materializes the entire collection. This is not the most efficient way to write that query. It was written in that way to demonstrate the behavior of positional predicates. A more appropriate way to write the same query is to use the <xref:System.Linq.Enumerable.First%2A> method, as follows: `anElement.ElementsBeforeSelf().First()`.  
  
 If you wanted to find the immediately preceding element in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], you would write the following expression:  
  
 `ElementsBeforeSelf().Last()`  
  
## Performance Differences  
 XPath queries that use the XPath functionality in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] will not perform as well as [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] queries.  
  
## Comparison of Composition  
 Composition of a [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] query is somewhat parallel to composition of an XPath expression, although very different in syntax.  
  
 For example, if you have an element in a variable named `customers`, and you want to find a grandchild element named `CompanyName` under all child elements named `Customer`, you would write an XPath expression as follows:  
  
```csharp  
customers.XPathSelectElements("./Customer/CompanyName");  
```  
  
 The equivalent [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] query is:  
  
```csharp  
customers.Element("Customer").Elements("CompanyName");  
```  
  
 There are similar parallels for each of the XPath axes.  
  
|XPath axis|LINQ to XML axis|  
|----------------|----------------------|  
|child (the default axis)|<xref:System.Xml.Linq.XContainer.Elements%2A?displayProperty=nameWithType>|  
|Parent (..)|<xref:System.Xml.Linq.XObject.Parent%2A?displayProperty=nameWithType>|  
|attribute axis (@)|<xref:System.Xml.Linq.XElement.Attribute%2A?displayProperty=nameWithType><br /><br /> or<br /><br /> <xref:System.Xml.Linq.XElement.Attributes%2A?displayProperty=nameWithType>|  
|ancestor axis|<xref:System.Xml.Linq.XNode.Ancestors%2A?displayProperty=nameWithType>|  
|ancestor-or-self axis|<xref:System.Xml.Linq.XElement.AncestorsAndSelf%2A?displayProperty=nameWithType>|  
|descendant axis (//)|<xref:System.Xml.Linq.XContainer.Descendants%2A?displayProperty=nameWithType><br /><br /> or<br /><br /> <xref:System.Xml.Linq.XContainer.DescendantNodes%2A?displayProperty=nameWithType>|  
|descendant-or-self|<xref:System.Xml.Linq.XElement.DescendantsAndSelf%2A?displayProperty=nameWithType><br /><br /> or<br /><br /> <xref:System.Xml.Linq.XElement.DescendantNodesAndSelf%2A?displayProperty=nameWithType>|  
|following-sibling|<xref:System.Xml.Linq.XNode.ElementsAfterSelf%2A?displayProperty=nameWithType><br /><br /> or<br /><br /> <xref:System.Xml.Linq.XNode.NodesAfterSelf%2A?displayProperty=nameWithType>|  
|preceding-sibling|<xref:System.Xml.Linq.XNode.ElementsBeforeSelf%2A?displayProperty=nameWithType><br /><br /> or<br /><br /> <xref:System.Xml.Linq.XNode.NodesBeforeSelf%2A?displayProperty=nameWithType>|  
|following|No direct equivalent.|  
|preceding|No direct equivalent.|  
  
## See Also  
 [LINQ to XML for XPath Users (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-for-xpath-users.md)
