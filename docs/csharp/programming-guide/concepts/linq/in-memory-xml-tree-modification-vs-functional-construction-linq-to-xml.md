---
title: "In-Memory XML Tree Modification vs. Functional Construction (LINQ to XML) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: b5afc31d-a325-4ec6-bf17-0ff90a20ffca
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# In-Memory XML Tree Modification vs. Functional Construction (LINQ to XML) (C#)
Modifying an XML tree in place is a traditional approach to changing the shape of an XML document. A typical application loads a document into a data store such as DOM or [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)]; uses a programming interface to insert nodes, delete nodes, or change the content of nodes; and then saves the XML to a file or transmits it over a network.  
  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] enables another approach that is useful in many scenarios*: functional construction*. Functional construction treats modifying data as a problem of transformation, rather than as detailed manipulation of a data store. If you can take a representation of data and transform it efficiently from one form to another, the result is the same as if you took one data store and manipulated it in some way to take another shape. A key to the functional construction approach is to pass the results of queries to <xref:System.Xml.Linq.XDocument> and <xref:System.Xml.Linq.XElement> constructors.  
  
 In many cases you can write the transformational code in a fraction of the time that it would take to manipulate the data store, and that code is more robust and easier to maintain. In these cases, even though the transformational approach can take more processing power, it is a more effective way to modify data. If a developer is familiar with the functional approach, the resulting code in many cases is easier to understand. It is easy to find the code that modifies each part of the tree.  
  
 The approach where you modify an XML tree in-place is more familiar to many DOM programmers, whereas code written using the functional approach might look unfamiliar to a developer who doesn't yet understand that approach. If you have to only make a small modification to a large XML tree, the approach where you modify a tree in place in many cases will take less CPU time.  
  
 This topic provides an example that is implemented with both approaches.  
  
## Transforming Attributes into Elements  
 For this example, suppose you want to modify the following simple XML document so that the attributes become elements. This topic first presents the traditional in-place modification approach. It then shows the functional construction approach.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<Root Data1="123" Data2="456">  
  <Child1>Content</Child1>  
</Root>  
```  
  
### Modifying the XML Tree  
 You can write some procedural code to create elements from the attributes, and then delete the attributes, as follows:  
  
```csharp  
XElement root = XElement.Load("Data.xml");  
foreach (XAttribute att in root.Attributes()) {  
    root.Add(new XElement(att.Name, (string)att));  
}  
root.Attributes().Remove();  
Console.WriteLine(root);  
```  
  
 This code produces the following output:  
  
```xml  
<Root>  
  <Child1>Content</Child1>  
  <Data1>123</Data1>  
  <Data2>456</Data2>  
</Root>  
```  
  
### Functional Construction Approach  
 By contrast, a functional approach consists of code to form a new tree, picking and choosing elements and attributes from the source tree, and transforming them as appropriate as they are added to the new tree. The functional approach looks like the following:  
  
```csharp  
XElement root = XElement.Load("Data.xml");  
XElement newTree = new XElement("Root",  
    root.Element("Child1"),  
    from att in root.Attributes()  
    select new XElement(att.Name, (string)att)  
);  
Console.WriteLine(newTree);  
```  
  
 This example outputs the same XML as the first example. However, notice that you can actually see the resulting structure of the new XML in the functional approach. You can see the creation of the `Root` element, the code that pulls the `Child1` element from the source tree, and the code that transforms the attributes from the source tree to elements in the new tree.  
  
 The functional example in this case is not any shorter than the first example, and it is not really any simpler. However, if you have many changes to make to an XML tree, the non functional approach will become quite complex and somewhat obtuse. In contrast, when using the functional approach, you still just form the desired XML, embedding queries and expressions as appropriate, to pull in the desired content. The functional approach yields code that is easier to maintain.  
  
 Notice that in this case the functional approach probably would not perform quite as well as the tree manipulation approach. The main issue is that the functional approach creates more short lived objects. However, the tradeoff is an effective one if using the functional approach allows for greater programmer productivity.  
  
 This is a very simple example, but it serves to show the difference in philosophy between the two approaches. The functional approach yields greater productivity gains for transforming larger XML documents.  
  
## See Also  
 [Modifying XML Trees (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/modifying-xml-trees-linq-to-xml.md)
