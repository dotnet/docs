---
title: "How to find a union of two location paths (XPath-LINQ to XML) (C#)"
ms.date: 07/20/2015
ms.assetid: 069622d3-2b58-4919-8903-710a564c0788
---
# How to find a union of two location paths (XPath-LINQ to XML) (C#)
XPath allows you to find the union of the results of two XPath location paths.  
  
 The XPath expression is:  
  
 `//Category|//Price`  
  
 You can achieve the same results by using the <xref:System.Linq.Enumerable.Concat%2A> standard query operator.  
  
## Example  
 This example finds all of the `Category` elements and all of the `Price` elements, and concatenates them into a single collection. Note that the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] query calls <xref:System.Xml.Linq.Extensions.InDocumentOrder%2A> to order the results. The results of the XPath expression evaluation are also in document order.  
  
 This example uses the following XML document: [Sample XML File: Numerical Data (LINQ to XML)](./sample-xml-file-numerical-data-linq-to-xml.md).  
  
```csharp  
XDocument data = XDocument.Load("Data.xml");  
  
// LINQ to XML query  
IEnumerable<XElement> list1 =  
    data  
    .Descendants("Category")  
    .Concat(  
        data  
        .Descendants("Price")  
    )  
    .InDocumentOrder();  
  
// XPath expression  
IEnumerable<XElement> list2 = data.XPathSelectElements("//Category|//Price");  
  
if (list1.Count() == list2.Count() &&  
        list1.Intersect(list2).Count() == list1.Count())  
    Console.WriteLine("Results are identical");  
else  
    Console.WriteLine("Results differ");  
foreach (XElement el in list1)  
    Console.WriteLine(el);  
```  
  
 This example produces the following output:  
  
```output  
Results are identical  
<Category>A</Category>  
<Price>24.50</Price>  
<Category>B</Category>  
<Price>89.99</Price>  
<Category>A</Category>  
<Price>4.95</Price>  
<Category>A</Category>  
<Price>66.00</Price>  
<Category>B</Category>  
<Price>.99</Price>  
<Category>A</Category>  
<Price>29.00</Price>  
<Category>B</Category>  
<Price>6.99</Price>  
```  
  