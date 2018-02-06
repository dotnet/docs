---
title: "How to: Project an Anonymous Type (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 5cb9be13-5ac4-4373-a034-b3520a5b2dec
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Project an Anonymous Type (C#)
In some cases you might want to project a query to a new type, even though you know you will only use this type for a short while. It is a lot of extra work to create a new type just to use in the projection. A more efficient approach in this case is to project to an anonymous type. Anonymous types allow you to define a class, then declare and initialize an object of that class, without giving the class a name.  
  
 Anonymous types are the C# implementation of the mathematical concept of a *tuple*. The mathematical term tuple originated from the sequence single, double, triple, quadruple, quintuple, n-tuple. It refers to a finite sequence of objects, each of a specific type. Sometimes this is called a list of name/value pairs. For example, the contents of an address in the [Sample XML File: Typical Purchase Order (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-typical-purchase-order-linq-to-xml-1.md) XML document could be expressed as follows:  
  
```  
Name: Ellen Adams  
Street: 123 Maple Street  
City: Mill Valley  
State: CA  
Zip: 90952  
Country: USA  
```  
  
 When you create an instance of an anonymous type, it is convenient to think of it as creating a tuple of order n. If you write a query that creates a tuple in the `select` clause, the query returns an `IEnumerable` of the tuple.  
  
## Example  
 In this example, the `select` clause projects an anonymous type. The example then uses `var` to create the `IEnumerable` object. Within the `foreach` loop, the iteration variable becomes an instance of the anonymous type created in the query expression.  
  
 This example uses the following XML document: [Sample XML File: Customers and Orders (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-customers-and-orders-linq-to-xml-2.md).  
  
```csharp  
XElement custOrd = XElement.Load("CustomersOrders.xml");  
var custList =  
    from el in custOrd.Element("Customers").Elements("Customer")  
    select new {  
        CustomerID = (string)el.Attribute("CustomerID"),  
        CompanyName = (string)el.Element("CompanyName"),  
        ContactName = (string)el.Element("ContactName")  
    };  
foreach (var cust in custList)  
    Console.WriteLine("{0}:{1}:{2}", cust.CustomerID, cust.CompanyName, cust.ContactName);  
```  
  
 This code produces the following output:  
  
```  
GREAL:Great Lakes Food Market:Howard Snyder  
HUNGC:Hungry Coyote Import Store:Yoshi Latimer  
LAZYK:Lazy K Kountry Store:John Steel  
LETSS:Let's Stop N Shop:Jaime Yorres  
```  
  
## See Also  
 [Projections and Transformations (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/projections-and-transformations-linq-to-xml.md)
