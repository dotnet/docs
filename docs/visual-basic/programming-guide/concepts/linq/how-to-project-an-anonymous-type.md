---
title: "How to: Project an Anonymous Type (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 30b42987-0e0e-4b2b-adb1-5255ddfbcd7b
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent

---
# How to: Project an Anonymous Type (Visual Basic)
In some cases you might want to project a query to a new type, even though you know you will only use this type for a short while. It is a lot of extra work to create a new type just to use in the projection. A more efficient approach in this case is to project to an anonymous type. Anonymous types allow you to define a class, then declare and initialize an object of that class, without giving the class a name.  
  
 Anonymous types are the C# implementation of the mathematical concept of a *tuple*. The mathematical term tuple originated from the sequence single, double, triple, quadruple, quintuple, n-tuple. It refers to a finite sequence of objects, each of a specific type. Sometimes this is called a list of name/value pairs. For example, the contents of an address in the [Sample XML File: Typical Purchase Order (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/sample-xml-file-typical-purchase-order-linq-to-xml.md) XML document could be expressed as follows:  
  
```  
Name: Ellen Adams  
Street: 123 Maple Street  
City: Mill Valley  
State: CA  
Zip: 90952  
Country: USA  
```  
  
 When you create an instance of an anonymous type, it is convenient to think of it as creating a tuple of order n. If you write a query that creates a tuple in the `Select` clause, the query returns an `IEnumerable` of the tuple.  
  
## Example  
 In this example, the `Select` clause projects an anonymous type. The example then uses `Dim` to create the `IEnumerable` object. Within the `For Each` loop, the iteration variable becomes an instance of the anonymous type created in the query expression.  
  
 This example uses the following XML document: [Sample XML File: Customers and Orders (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/sample-xml-file-customers-and-orders-linq-to-xml.md).  
  
```vb  
Dim custOrd As XElement = XElement.Load("CustomersOrders.xml")  
Dim custList = _  
    From el In custOrd.<Customers>.<Customer> _  
    Select New With { _  
        .CustomerID = el.@<CustomerID>, _  
        .CompanyName = el.<CompanyName>.Value, _  
        .ContactName = el.<ContactName>.Value _  
    }  
For Each cust In custList  
    Console.WriteLine("{0}:{1}:{2}", cust.CustomerID, cust.CompanyName, cust.ContactName)  
Next  
```  
  
 This code produces the following output:  
  
```  
GREAL:Great Lakes Food Market:Howard Snyder  
HUNGC:Hungry Coyote Import Store:Yoshi Latimer  
LAZYK:Lazy K Kountry Store:John Steel  
LETSS:Let's Stop N Shop:Jaime Yorres  
```  
  
## See Also  
 [Projections and Transformations (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/projections-and-transformations-linq-to-xml.md)
