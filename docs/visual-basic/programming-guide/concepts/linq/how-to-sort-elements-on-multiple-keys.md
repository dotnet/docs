---
title: "How to: Sort Elements on Multiple Keys (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0c4c1462-3047-4766-b9e2-7e0e9cc7f421
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# How to: Sort Elements on Multiple Keys (Visual Basic)
This topic shows how to sort on multiple keys.  
  
## Example  
 In this example, the results are ordered first by the shipping postal code, then by the order date.  
  
 This example uses the following XML document: [Sample XML File: Customers and Orders (LINQ to XML)](../../../../visual-basic/programming-guide/concepts/linq/sample-xml-file-customers-and-orders-linq-to-xml.md).  
  
```vb  
Dim co As XElement = XElement.Load("CustomersOrders.xml")  
Dim result = _  
    From c In co.<Orders>.<Order> _  
    Order By c.<ShipInfo>.<ShipPostalCode>.Value, Convert.ToDateTime(c.<OrderDate>.Value) _  
    Select New With { _  
        .CustomerID = c.<CustomerID>.Value, _  
        .EmployeeID = c.<EmployeeID>.Value, _  
        .ShipPostalCode = c.<ShipInfo>.<ShipPostalCode>.Value, _  
        .OrderDate = Convert.ToDateTime(c.<OrderDate>.Value) _  
    }  
For Each r In result  
    Console.WriteLine("CustomerID:{0} EmployeeID:{1} ShipPostalCode:{2} OrderDate:{3:d}", _  
                r.CustomerID, r.EmployeeID, r.ShipPostalCode, r.OrderDate)  
Next  
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
 The following example shows the same query for XML that is in a namespace. For more information, see [Working with XML Namespaces (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/working-with-xml-namespaces.md).  
  
 This example uses the following XML document: [Sample XML File: Customers and Orders in a Namespace](../../../../visual-basic/programming-guide/concepts/linq/sample-xml-file-customers-and-orders-in-a-namespace.md).  
  
```vb  
Imports <xmlns='http://www.adventure-works.com'>  
  
Module Module1  
    Sub Main()  
        Dim co As XElement = XElement.Load("CustomersOrdersInNamespace.xml")  
        Dim result = _  
            From c In co.<Orders>.<Order> _  
            Order By c.<ShipInfo>.<ShipPostalCode>.Value, Convert.ToDateTime(c.<OrderDate>.Value) _  
            Select New With { _  
                .CustomerID = c.<CustomerID>.Value, _  
                .EmployeeID = c.<EmployeeID>.Value, _  
                .ShipPostalCode = c.<ShipInfo>.<ShipPostalCode>.Value, _  
                .OrderDate = Convert.ToDateTime(c.<OrderDate>.Value) _  
            }  
        For Each r In result  
            Console.WriteLine("CustomerID:{0} EmployeeID:{1} ShipPostalCode:{2} OrderDate:{3:d}", _  
                        r.CustomerID, r.EmployeeID, r.ShipPostalCode, r.OrderDate)  
        Next  
    End Sub  
End Module  
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
 [Basic Queries (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/basic-queries-linq-to-xml.md)
