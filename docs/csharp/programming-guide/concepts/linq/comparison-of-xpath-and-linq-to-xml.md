---
title: "Comparison of XPath and LINQ to XML"
ms.date: 07/20/2015
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 87d361b1-daa9-4fd4-a53a-cbfa40111ad3
---
# Comparison of XPath and LINQ to XML
XPath and LINQ to XML offer some similar functionality. Both can be used to query an XML tree, returning such results as a collection of elements, a collection of attributes, a collection of nodes, or the value of an element or attribute. However, there are also some differences.  
  
## Differences Between XPath and LINQ to XML  
 XPath does not allow projection of new types. It can only return collections of nodes from the tree, whereas LINQ to XML can execute a query and project an object graph or an XML tree in a new shape. LINQ to XML queries encompass much more functionality and are much more powerful than XPath expressions.  
  
 XPath expressions exist in isolation within a string. The C# compiler cannot help parse the XPath expression at compile time. By contrast, LINQ to XML queries are parsed and compiled by the C# compiler. The compiler is able to catch many query errors.  
  
 XPath results are not strongly typed. In a number of circumstances, the result of evaluating an XPath expression is an object, and it is up to the developer to determine the proper type and cast the result as necessary. By contrast, the projections from a LINQ to XML query are strongly typed.  
  
## Result Ordering  
 The XPath 1.0 Recommendation states that a collection that is the result of evaluating an XPath expression is unordered.  
  
 However, when iterating through a collection returned by a LINQ to XML XPath axis method, the nodes in the collection are returned in document order. This is the case even when accessing the XPath axes where predicates are expressed in terms of reverse document order, such as `preceding` and `preceding-sibling`.  
  
 By contrast, most of the LINQ to XML axes return collections in document order, but two of them, <xref:System.Xml.Linq.XNode.Ancestors%2A> and <xref:System.Xml.Linq.XElement.AncestorsAndSelf%2A>, return collections in reverse document order. The following table enumerates the axes, and indicates collection order for each:  
  
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
  
 By contrast, all positional predicates in LINQ to XML are always expressed in terms of the order of the axis. For example, `anElement.ElementsBeforeSelf().ElementAt(0)` returns the first child element of the parent of the queried element, not the immediate preceding sibling. Another example: `anElement.Ancestors().ElementAt(0)` returns the parent element.  
  
 If you wanted to find the immediately preceding element in LINQ to XML, you would write the following expression:  
  
```csharp
ElementsBeforeSelf().Last()
```
  
```vb
ElementsBeforeSelf().Last()
```
  
## Performance Differences  
 XPath queries that use the XPath functionality in LINQ to XML will not perform as well as LINQ to XML queries.  
  
## Comparison of Composition  
 Composition of a LINQ to XML query is somewhat parallel to composition of an XPath expression, although very different in syntax.  
  
 For example, if you have an element in a variable named `customers`, and you want to find a grandchild element named `CompanyName` under all child elements named `Customer`, you would write an XPath expression as follows:  
  
```csharp  
customers.XPathSelectElements("./Customer/CompanyName")
```  
  
```vb
customers.XPathSelectElements("./Customer/CompanyName")
```

 The equivalent LINQ to XML query is:  
  
```csharp  
customers.Elements("Customer").Elements("CompanyName")
```  
  
```vb
customers.Elements("Customer").Elements("CompanyName")
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
  
## See also

- [LINQ to XML for XPath Users (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-for-xpath-users.md)
