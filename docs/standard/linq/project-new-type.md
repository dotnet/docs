---
title: How to project a new type - LINQ to XML
description: Your query can return an IEnumerable of a type other than the common ones. This article shows how in an example.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to project a new type (LINQ to XML)

Other examples in this section have shown queries that return results as <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement>, <xref:System.Collections.Generic.IEnumerable%601> of `string`, and <xref:System.Collections.Generic.IEnumerable%601> of `int`. These are common result types, but they're not appropriate for every scenario. In many cases, you'll want your queries to return an <xref:System.Collections.Generic.IEnumerable%601> of some other type.

## Example: Define a new type and have the `select` statement create an instance of the type

This example shows how to instantiate objects in the `select` clause. The code first invokes a constructor to define a new class, and then modifies the `select` statement so that the expression is a new instance of the new class. The example uses XML document [Sample XML file: Typical purchase order](sample-xml-file-typical-purchase-order.md).

```csharp
class NameQty
{
    public string name;
    public int qty;
    public NameQty(string n, int q)
    {
        name = n;
        qty = q;
    }
};

class Program {
    public static void Main()
    {
        XElement po = XElement.Load("PurchaseOrder.xml");

        IEnumerable<NameQty> nqList =
            from n in po.Descendants("Item")
            select new NameQty(
                    (string)n.Element("ProductName"),
                    (int)n.Element("Quantity")
                );

        foreach (NameQty n in nqList)
            Console.WriteLine(n.name + ":" + n.qty);
    }
}
```

```vb
Public Class NameQty
    Public name As String
    Public qty As Integer
    Public Sub New(ByVal n As String, ByVal q As Integer)
        name = n
        qty = q
    End Sub
End Class

Public Class Program
    Shared Sub Main()
        Dim po As XElement = XElement.Load("PurchaseOrder.xml")

        Dim nqList As IEnumerable(Of NameQty) = _
            From n In po...<Item> _
            Select New NameQty( _
                n.<ProductName>.Value, CInt(n.<Quantity>.Value))

        For Each n As NameQty In nqList
            Console.WriteLine(n.name & ":" & n.qty)
        Next
    End Sub
End Class
```

This example uses the <xref:System.Xml.Linq.XContainer.Element%2A> method that was introduced in the [How to retrieve a single child element](retrieve-single-child-element.md) article. It also uses casts to retrieve the values of the elements that are returned by the <xref:System.Xml.Linq.XContainer.Element%2A> method.

This example produces the following output:

```output
Lawnmower:1
Baby Monitor:2
```

## See also

- [Projections and Transformations (LINQ to XML) (Visual Basic)](./work-dictionaries-linq-xml.md)
