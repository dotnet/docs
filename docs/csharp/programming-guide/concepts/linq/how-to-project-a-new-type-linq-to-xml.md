---
title: "How to: Project a New Type (LINQ to XML) (C#)"
ms.date: 07/20/2015
ms.assetid: 48145cf9-1e0b-4e73-bbfd-28fc04800dc4
---
# How to: Project a New Type (LINQ to XML) (C#)

Other examples in this section have shown queries that return results as <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement>, <xref:System.Collections.Generic.IEnumerable%601> of `string`, and <xref:System.Collections.Generic.IEnumerable%601> of `int`. These are common result types, but they are not appropriate for every scenario. In many cases you will want your queries to return an <xref:System.Collections.Generic.IEnumerable%601> of some other type.

## Example

This example shows how to instantiate objects in the `select` clause. The code first defines a new class with a constructor, and then modifies the `select` statement so that the expression is a new instance of the new class.

This example uses the following XML document: [Sample XML File: Typical Purchase Order (LINQ to XML)](../../../../csharp/programming-guide/concepts/linq/sample-xml-file-typical-purchase-order-linq-to-xml-1.md).

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

This example uses the <xref:System.Xml.Linq.XContainer.Element%2A> method that was introduced in the topic [How to: Retrieve a Single Child Element (LINQ to XML) (C#)](how-to-retrieve-a-single-child-element-linq-to-xml.md). It also uses casts to retrieve the values of the elements that are returned by the <xref:System.Xml.Linq.XContainer.Element%2A> method.  

This example produces the following output:

```console
Lawnmower:1
Baby Monitor:2
```
