---
title: "How to: Retrieve a Collection of Elements (LINQ to XML) (C#)"
ms.date: 07/20/2015
ms.assetid: b849668c-7976-4974-b8e1-1cd587d34258
---
# How to: Retrieve a Collection of Elements (LINQ to XML) (C#)
This topic demonstrates the <xref:System.Xml.Linq.XContainer.Elements%2A> method. This method retrieves a collection of the child elements of an element.  
  
## Example  
 This example iterates through the child elements of the `purchaseOrder` element.  
  
 This example uses the following XML document: [Sample XML File: Typical Purchase Order (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-typical-purchase-order-linq-to-xml-1.md).  
  
```csharp  
XElement po = XElement.Load("PurchaseOrder.xml");  
IEnumerable<XElement> childElements =  
    from el in po.Elements()  
    select el;  
foreach (XElement el in childElements)  
    Console.WriteLine("Name: " + el.Name);  
```  
  
 This example produces the following output.  
  
```  
Name: Address  
Name: Address  
Name: DeliveryNotes  
Name: Items  
```  
  
## See also

- [LINQ to XML Axes (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-axes.md)
