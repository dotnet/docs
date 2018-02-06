---
title: "How to: Sort Elements on Multiple Keys (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 3b2760b6-d607-4ac7-b784-5c6524e2a0e0
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Sort Elements on Multiple Keys (C#)
This topic shows how to sort on multiple keys.  
  
## Example  
 In this example, the results are ordered first by the shipping postal code, then by the order date.  
  
 This example uses the following XML document: [Sample XML File: Customers and Orders (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-customers-and-orders-linq-to-xml-2.md).  
  
```csharp  
XElement co = XElement.Load("CustomersOrders.xml");  
var sortedElements =  
    from c in co.Element("Orders").Elements("Order")  
    orderby (string)c.Element("ShipInfo").Element("ShipPostalCode"),  
            (DateTime)c.Element("OrderDate")  
    select new {  
        CustomerID = (string)c.Element("CustomerID"),  
        EmployeeID = (string)c.Element("EmployeeID"),  
        ShipPostalCode = (string)c.Element("ShipInfo").Element("ShipPostalCode"),  
        OrderDate = (DateTime)c.Element("OrderDate")  
    };  
foreach (var r in sortedElements)  
    Console.WriteLine("CustomerID:{0} EmployeeID:{1} ShipPostalCode:{2} OrderDate:{3:d}",  
        r.CustomerID, r.EmployeeID, r.ShipPostalCode, r.OrderDate);  
```  
  
 This code produces the following output:  
  
```  
CustomerID:LETSS EmployeeID:1 ShipPostalCode:94117 OrderDate:6/25/1997  
CustomerID:LETSS EmployeeID:8 ShipPostalCode:94117 OrderDate:10/27/1997  
CustomerID:LETSS EmployeeID:6 ShipPostalCode:94117 OrderDate:11/10/1997  
CustomerID:LETSS EmployeeID:4 ShipPostalCode:94117 OrderDate:2/12/1998  
CustomerID:GREAL EmployeeID:6 ShipPostalCode:97403 OrderDate:5/6/1997  
CustomerID:GREAL EmployeeID:8 ShipPostalCode:97403 OrderDate:7/4/1997  
CustomerID:GREAL EmployeeID:1 ShipPostalCode:97403 OrderDate:7/31/1997  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:7/31/1997  
CustomerID:GREAL EmployeeID:6 ShipPostalCode:97403 OrderDate:9/4/1997  
CustomerID:GREAL EmployeeID:3 ShipPostalCode:97403 OrderDate:9/25/1997  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:1/6/1998  
CustomerID:GREAL EmployeeID:3 ShipPostalCode:97403 OrderDate:3/9/1998  
CustomerID:GREAL EmployeeID:3 ShipPostalCode:97403 OrderDate:4/7/1998  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:4/22/1998  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:4/30/1998  
CustomerID:HUNGC EmployeeID:3 ShipPostalCode:97827 OrderDate:12/6/1996  
CustomerID:HUNGC EmployeeID:1 ShipPostalCode:97827 OrderDate:12/25/1996  
CustomerID:HUNGC EmployeeID:3 ShipPostalCode:97827 OrderDate:1/15/1997  
CustomerID:HUNGC EmployeeID:4 ShipPostalCode:97827 OrderDate:7/16/1997  
CustomerID:HUNGC EmployeeID:8 ShipPostalCode:97827 OrderDate:9/8/1997  
CustomerID:LAZYK EmployeeID:1 ShipPostalCode:99362 OrderDate:3/21/1997  
CustomerID:LAZYK EmployeeID:8 ShipPostalCode:99362 OrderDate:5/22/1997  
```  
  
## Example  
 The following example shows the same query for XML that is in a namespace. For more information, see [Working with XML Namespaces (C#)](../../../../csharp/programming-guide/concepts/linq/working-with-xml-namespaces.md).  
  
 This example uses the following XML document: [Sample XML File: Customers and Orders in a Namespace](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-customers-and-orders-in-a-namespace.md).  
  
```csharp  
XElement co = XElement.Load("CustomersOrdersInNamespace.xml");  
XNamespace aw = "http://www.adventure-works.com";  
var sortedElements =  
    from c in co.Element(aw + "Orders").Elements(aw + "Order")  
    orderby (string)c.Element(aw + "ShipInfo").Element(aw + "ShipPostalCode"),  
            (DateTime)c.Element(aw + "OrderDate")  
    select new  
    {  
        CustomerID = (string)c.Element(aw + "CustomerID"),  
        EmployeeID = (string)c.Element(aw + "EmployeeID"),  
        ShipPostalCode = (string)c.Element(aw + "ShipInfo").Element(aw + "ShipPostalCode"),  
        OrderDate = (DateTime)c.Element(aw + "OrderDate")  
    };  
foreach (var r in sortedElements)  
    Console.WriteLine("CustomerID:{0} EmployeeID:{1} ShipPostalCode:{2} OrderDate:{3:d}",  
        r.CustomerID, r.EmployeeID, r.ShipPostalCode, r.OrderDate);  
```  
  
 This code produces the following output:  
  
```  
CustomerID:LETSS EmployeeID:1 ShipPostalCode:94117 OrderDate:6/25/1997  
CustomerID:LETSS EmployeeID:8 ShipPostalCode:94117 OrderDate:10/27/1997  
CustomerID:LETSS EmployeeID:6 ShipPostalCode:94117 OrderDate:11/10/1997  
CustomerID:LETSS EmployeeID:4 ShipPostalCode:94117 OrderDate:2/12/1998  
CustomerID:GREAL EmployeeID:6 ShipPostalCode:97403 OrderDate:5/6/1997  
CustomerID:GREAL EmployeeID:8 ShipPostalCode:97403 OrderDate:7/4/1997  
CustomerID:GREAL EmployeeID:1 ShipPostalCode:97403 OrderDate:7/31/1997  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:7/31/1997  
CustomerID:GREAL EmployeeID:6 ShipPostalCode:97403 OrderDate:9/4/1997  
CustomerID:GREAL EmployeeID:3 ShipPostalCode:97403 OrderDate:9/25/1997  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:1/6/1998  
CustomerID:GREAL EmployeeID:3 ShipPostalCode:97403 OrderDate:3/9/1998  
CustomerID:GREAL EmployeeID:3 ShipPostalCode:97403 OrderDate:4/7/1998  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:4/22/1998  
CustomerID:GREAL EmployeeID:4 ShipPostalCode:97403 OrderDate:4/30/1998  
CustomerID:HUNGC EmployeeID:3 ShipPostalCode:97827 OrderDate:12/6/1996  
CustomerID:HUNGC EmployeeID:1 ShipPostalCode:97827 OrderDate:12/25/1996  
CustomerID:HUNGC EmployeeID:3 ShipPostalCode:97827 OrderDate:1/15/1997  
CustomerID:HUNGC EmployeeID:4 ShipPostalCode:97827 OrderDate:7/16/1997  
CustomerID:HUNGC EmployeeID:8 ShipPostalCode:97827 OrderDate:9/8/1997  
CustomerID:LAZYK EmployeeID:1 ShipPostalCode:99362 OrderDate:3/21/1997  
CustomerID:LAZYK EmployeeID:8 ShipPostalCode:99362 OrderDate:5/22/1997  
```  
  
## See Also  
 [Basic Queries (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/basic-queries-linq-to-xml.md)
