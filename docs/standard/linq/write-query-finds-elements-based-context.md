---
title: How to write a query that finds elements based on context - LINQ to XML
description: Write a query that selects elements based on context; for example, filter results based on preceding or following sibling elements.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to write a query that finds elements based on context (LINQ to XML)

Sometimes you might have to write a query that selects elements based on their context. For example, you might want to filter based on preceding or following sibling elements, or on child or ancestor elements.

You can do this by writing a query and using the results of the query in the `where` clause. If you have to first test against null, and then test the value, it's more convenient to do the query in a `let` clause, and then use the results in the `where` clause.

## Example: Select `p` elements that are immediately followed by a `ul` element

The following example selects all `p` elements that are immediately followed by a `ul` element.

```csharp
XElement doc = XElement.Parse(@"<Root>
    <p id=""1""/>
    <ul>abc</ul>
    <Child>
        <p id=""2""/>
        <notul/>
        <p id=""3""/>
        <ul>def</ul>
        <p id=""4""/>
    </Child>
    <Child>
        <p id=""5""/>
        <notul/>
        <p id=""6""/>
        <ul>abc</ul>
        <p id=""7""/>
    </Child>
</Root>");

IEnumerable<XElement> items =
    from e in doc.Descendants("p")
    let z = e.ElementsAfterSelf().FirstOrDefault()
    where z != null && z.Name.LocalName == "ul"
    select e;

foreach (XElement e in items)
    Console.WriteLine("id = {0}", (string)e.Attribute("id"));
```

```vb
Dim doc As XElement = _
    <Root>
        <p id='1'/>
        <ul>abc</ul>
        <Child>
            <p id='2'/>
            <notul/>
            <p id='3'/>
            <ul>def</ul>
            <p id='4'/>
        </Child>
        <Child>
            <p id='5'/>
            <notul/>
            <p id='6'/>
            <ul>abc</ul>
            <p id='7'/>
        </Child>
    </Root>

Dim items As IEnumerable(Of XElement) = _
    From e In doc...<p> _
    Let z = e.ElementsAfterSelf().FirstOrDefault() _
    Where z IsNot Nothing AndAlso z.Name.LocalName = "ul" _
    Select e

For Each e As XElement In items
    Console.WriteLine("id = {0}", e.@<id>)
Next
```

This example produces the following output:

```output
id = 1
id = 3
id = 6
```

## Example: In a namespace select `p` elements that are immediately followed by a `ul` element

The following example shows the same query as above, but for XML that's in a namespace. For more information, see [Namespaces overview](namespaces-overview.md).

```csharp
XElement doc = XElement.Parse(@"<Root xmlns='http://www.adatum.com'>
    <p id=""1""/>
    <ul>abc</ul>
    <Child>
        <p id=""2""/>
        <notul/>
        <p id=""3""/>
        <ul>def</ul>
        <p id=""4""/>
    </Child>
    <Child>
        <p id=""5""/>
        <notul/>
        <p id=""6""/>
        <ul>abc</ul>
        <p id=""7""/>
    </Child>
</Root>");

XNamespace ad = "http://www.adatum.com";

IEnumerable<XElement> items =
    from e in doc.Descendants(ad + "p")
    let z = e.ElementsAfterSelf().FirstOrDefault()
    where z != null && z.Name == ad.GetName("ul")
    select e;

foreach (XElement e in items)
    Console.WriteLine("id = {0}", (string)e.Attribute("id"));
```

```vb
Imports <xmlns='http://www.adatum.com'>

Module Module1
    Sub Main()
        Dim doc As XElement = _
            <Root>
                <p id='1'/>
                <ul>abc</ul>
                <Child>
                    <p id='2'/>
                    <notul/>
                    <p id='3'/>
                    <ul>def</ul>
                    <p id='4'/>
                </Child>
                <Child>
                    <p id='5'/>
                    <notul/>
                    <p id='6'/>
                    <ul>abc</ul>
                    <p id='7'/>
                </Child>
            </Root>

        Dim items As IEnumerable(Of XElement) = _
            From e In doc...<p> _
            Let z = e.ElementsAfterSelf().FirstOrDefault() _
            Where z IsNot Nothing AndAlso z.Name = GetXmlNamespace().GetName("ul") _
            Select e

        For Each e As XElement In items
            Console.WriteLine("id = {0}", e.@<id>)
        Next
    End Sub
End Module
```

This example produces the following output:

```output
id = 1
id = 3
id = 6
```

## See also

- <xref:System.Xml.Linq.XElement.Parse%2A>
- <xref:System.Xml.Linq.XContainer.Descendants%2A>
- <xref:System.Xml.Linq.XNode.ElementsAfterSelf%2A>
- <xref:System.Linq.Enumerable.FirstOrDefault%2A>
- [Basic Queries (LINQ to XML) (Visual Basic)](./find-element-specific-attribute.md)
