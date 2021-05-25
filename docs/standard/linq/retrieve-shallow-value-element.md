---
title: How to retrieve the shallow value of an element - LINQ to XML
description: Use the `ShallowValue` extension method to retrieve the shallow value of an element. The shallow value is the value of that element only; that is, it doesn't include the values of descendant elements.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---
# How to retrieve the shallow value of an element (LINQ to XML)

This article shows how to retrieve the shallow value of an element, which is the value of that element only, not including values of descendent elements. Retrieving the shallow value is useful when you want to select elements based on their content.

When you use casting or the <xref:System.Xml.Linq.XElement.Value%2A?displayProperty=nameWithType> property to retrieve an element value, the value includes the descendants. To retrieve the shallow value you can use the `ShallowValue` extension method, as shown in the following example. The example declares an extension method that retrieves the shallow value of an element. It then uses the extension method in a query to list all elements that contain a calculated value.

## Example: Use the `ShallowValue` extension method to retrieve the shallow value of an element

The examples uses the text file Report.xml that contains the following:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<Report>
  <Section>
    <Heading>
      <Column Name="CustomerId">=Customer.CustomerId.Heading</Column>
      <Column Name="Name">=Customer.Name.Heading</Column>
    </Heading>
    <Detail>
      <Column Name="CustomerId">=Customer.CustomerId</Column>
      <Column Name="Name">=Customer.Name</Column>
    </Detail>
  </Section>
</Report>
```

Here is the code for the example:

```csharp
public static class MyExtensions
{
    public static string ShallowValue(this XElement xe)
    {
        return xe
               .Nodes()
               .OfType<XText>()
               .Aggregate(new StringBuilder(),
                          (s, c) => s.Append(c),
                          s => s.ToString());
    }
}

class Program
{
    static void Main(string[] args)
    {
        XElement root = XElement.Load("Report.xml");

        IEnumerable<XElement> query = from el in root.Descendants()
                                      where el.ShallowValue().StartsWith("=")
                                      select el;

        foreach (var q in query)
        {
            Console.WriteLine("{0}{1}{2}",
                q.Name.ToString().PadRight(8),
                q.Attribute("Name").ToString().PadRight(20),
                q.ShallowValue());
        }
    }
}
```

```vb
Module Module1
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ShallowValue(ByVal xe As XElement)
        Return xe _
               .Nodes() _
               .OfType(Of XText)() _
               .Aggregate(New StringBuilder(), _
                              Function(s, c) s.Append(c), _
                              Function(s) s.ToString())
    End Function

    Sub Main()
        Dim root As XElement = XElement.Load("Report.xml")

        Dim query As IEnumerable(Of XElement) = _
            From el In root.Descendants() _
            Where (el.ShallowValue().StartsWith("=")) _
            Select el

        For Each q As XElement In query
            Console.WriteLine("{0}{1}{2}", _
                q.Name.ToString().PadRight(8), _
                q.Attribute("Name").ToString().PadRight(20), _
                q.ShallowValue())
        Next
    End Sub
End Module
```

This example produces the following output:

```output
Column  Name="CustomerId"   =Customer.CustomerId.Heading
Column  Name="Name"         =Customer.Name.Heading
Column  Name="CustomerId"   =Customer.CustomerId
Column  Name="Name"         =Customer.Name
```

## See also

- [LINQ to XML axes overview](linq-xml-axes-overview.md)
