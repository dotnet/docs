---
title: How to join two collections - LINQ to XML
description: An XSD file can establish relationships in an XML file, to enable joining of elements to create new types of elements. This article provides an example for C# and Visual Basic that joins elements and creates a new XML document.
ms.date: 07/20/2015
ms.topic: how-to
dev_langs:
  - "csharp"
  - "vb"
---

# How to join two collections (LINQ to XML)

An XSD file can establish relationships in an XML file, to enable joining of elements to create new types of elements. This article provides an example for C# and Visual Basic that joins elements and creates a new XML document.

An element or attribute in an XML document can sometimes refer to another element or attribute. For example, XML document [Sample XML file: Customers and orders](sample-xml-file-customers-orders.md) contains a list of customers and a list of orders. Every `Customer` element has a `CustomerID` attribute, and every `Order` element contains a `CustomerID` element. The `CustomerID` element value in an `Order` element refers to the `Customer` element that has a matching `CustomerID` attribute value.

The article [Sample XSD file: Customers and orders](sample-xsd-file-customers-orders.md) contains an XSD that can be used to validate the `Customers and orders` document. It uses the `xs:key` and `xs:keyref` features of XSD to establish that the `CustomerID` attribute of the `Customer` element is a key, and to establish a relationship between the key and the `CustomerID` element of the  `Order`elements.

With LINQ to XML, you can take advantage of this relationship by using the `join` clause to join customer information to order information.

For more detailed information about `join`, see [Join Operations (C#)](../../csharp/programming-guide/concepts/linq/join-operations.md) and [Join Operations (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/join-operations.md).
> [!NOTE]
> Joins are done using linear searches. There are no indexes to boost search performance.

## Example: Create a new XML document that has `Customer` and `Order` elements joined

The following example generates a new XML document that joins the `Customer` elements of [Sample XML file: Customers and orders](sample-xml-file-customers-orders.md) to the `Order` elements, and includes the `CompanyName` element in the orders.

Before executing the query, the example validates that the document complies with the schema in [Sample XSD file: Customers and orders](sample-xsd-file-customers-orders.md). This ensures that the join clause will work.

The query selects only the orders for customers with a `CustomerID` greater than "K". It projects  new `Order` elements that contains the customer information within each order.

```csharp
XmlSchemaSet schemas = new XmlSchemaSet();
schemas.Add("", "CustomersOrders.xsd");

Console.Write("Attempting to validate, ");
XDocument custOrdDoc = XDocument.Load("CustomersOrders.xml");

bool errors = false;
custOrdDoc.Validate(schemas, (o, e) =>
                     {
                         Console.WriteLine("{0}", e.Message);
                         errors = true;
                     });
Console.WriteLine("custOrdDoc {0}", errors ? "did not validate" : "validated");

if (!errors)
{
    // Join customers and orders, and create a new XML document with
    // a different shape.

    // The new document contains orders only for customers with a
    // CustomerID > 'K'
    XElement custOrd = custOrdDoc.Element("Root");
    XElement newCustOrd = new XElement("Root",
        from c in custOrd.Element("Customers").Elements("Customer")
        join o in custOrd.Element("Orders").Elements("Order")
                   on (string)c.Attribute("CustomerID") equals
                      (string)o.Element("CustomerID")
        where ((string)c.Attribute("CustomerID")).CompareTo("K") > 0
        select new XElement("Order",
            new XElement("CustomerID", (string)c.Attribute("CustomerID")),
            new XElement("CompanyName", (string)c.Element("CompanyName")),
            new XElement("ContactName", (string)c.Element("ContactName")),
            new XElement("EmployeeID", (string)o.Element("EmployeeID")),
            new XElement("OrderDate", (DateTime)o.Element("OrderDate"))
        )
    );
    Console.WriteLine(newCustOrd);
}
```

```vb
Public Class Program
    Public Shared errors As Boolean = False

    Public Shared Function LamValidEvent(ByVal o As Object, _
                 ByVal e As ValidationEventArgs) As Boolean
        Console.WriteLine("{0}", e.Message)
        errors = True
    End Function

    Shared Sub Main()
        Dim schemas As New XmlSchemaSet()
        schemas.Add("", "CustomersOrders.xsd")

        Console.Write("Attempting to validate, ")
        Dim custOrdDoc As XDocument = XDocument.Load("CustomersOrders.xml")

        custOrdDoc.Validate(schemas, Function(o, e) LamValidEvent(0, e))
        If errors Then
            Console.WriteLine("custOrdDoc did not validate")
        Else
            Console.WriteLine("custOrdDoc validated")
        End If

        If Not errors Then
            'Join customers and orders, and create a new XML document with
            ' a different shape.
            'The new document contains orders only for customers with a
            ' CustomerID > 'K'.
            Dim custOrd As XElement = custOrdDoc.<Root>.FirstOrDefault
            Dim newCustOrd As XElement = _
                <Root>
                    <%= From c In custOrd.<Customers>.<Customer> _
                        Join o In custOrd.<Orders>.<Order> _
                        On c.@CustomerID Equals o.<CustomerID>.Value _
                        Where c.@CustomerID.CompareTo("K") > 0 _
                        Select _
                        <Order>
                            <CustomerID><%= c.@CustomerID %></CustomerID>
                            <%= c.<CompanyName> %>
                            <%= c.<ContactName> %>
                            <%= o.<EmployeeID> %>
                            <%= o.<OrderDate> %>
                        </Order> _
                    %>
                </Root>
            Console.WriteLine(newCustOrd)
        End If
    End Sub
End Class
```

This example produces the following output:

```output
Attempting to validate, custOrdDoc validated
<Root>
  <Order>
    <CustomerID>LAZYK</CustomerID>
    <CompanyName>Lazy K Kountry Store</CompanyName>
    <ContactName>John Steel</ContactName>
    <EmployeeID>1</EmployeeID>
    <OrderDate>1997-03-21T00:00:00</OrderDate>
  </Order>
  <Order>
    <CustomerID>LAZYK</CustomerID>
    <CompanyName>Lazy K Kountry Store</CompanyName>
    <ContactName>John Steel</ContactName>
    <EmployeeID>8</EmployeeID>
    <OrderDate>1997-05-22T00:00:00</OrderDate>
  </Order>
  <Order>
    <CustomerID>LETSS</CustomerID>
    <CompanyName>Let's Stop N Shop</CompanyName>
    <ContactName>Jaime Yorres</ContactName>
    <EmployeeID>1</EmployeeID>
    <OrderDate>1997-06-25T00:00:00</OrderDate>
  </Order>
  <Order>
    <CustomerID>LETSS</CustomerID>
    <CompanyName>Let's Stop N Shop</CompanyName>
    <ContactName>Jaime Yorres</ContactName>
    <EmployeeID>8</EmployeeID>
    <OrderDate>1997-10-27T00:00:00</OrderDate>
  </Order>
  <Order>
    <CustomerID>LETSS</CustomerID>
    <CompanyName>Let's Stop N Shop</CompanyName>
    <ContactName>Jaime Yorres</ContactName>
    <EmployeeID>6</EmployeeID>
    <OrderDate>1997-11-10T00:00:00</OrderDate>
  </Order>
  <Order>
    <CustomerID>LETSS</CustomerID>
    <CompanyName>Let's Stop N Shop</CompanyName>
    <ContactName>Jaime Yorres</ContactName>
    <EmployeeID>4</EmployeeID>
    <OrderDate>1998-02-12T00:00:00</OrderDate>
  </Order>
</Root>
```
