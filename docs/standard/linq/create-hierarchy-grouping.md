---
title: How to create hierarchy using grouping - LINQ to XML
description: See an example on how data can be grouped based on related values in different elements, then reordered to place related elements together under an element that reflects the relationship.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to create hierarchy using grouping (LINQ to XML)

Data can be grouped based on related values in different elements, then reordered to place related elements together under an element that reflects the relationship. This article provides an example for C# and Visual Basic.

## Example: Create a new XML document in which data is grouped by category

The following example shows how to group data, and generate XML based on the grouping. It first groups data by equality of value of the `<Category>` elements, then generates a new XML file in which the XML hierarchy reflects the grouping.

This example uses XML document [Sample XML file: Numerical data](sample-xml-file-numerical-data.md).

```csharp
XElement doc = XElement.Load("Data.xml");
var newData =
    new XElement("Root",
        from data in doc.Elements("Data")
        group data by (string)data.Element("Category") into groupedData
        select new XElement("Group",
            new XAttribute("ID", groupedData.Key),
            from g in groupedData
            select new XElement("Data",
                g.Element("Quantity"),
                g.Element("Price")
            )
        )
    );
Console.WriteLine(newData);
```

```vb
Dim doc As XElement = XElement.Load("Data.xml")
Dim newData As XElement = _
    <Root>
        <%= _
            From data In doc.<Data> _
            Group By category = data.<Category>(0).Value _
            Into groupedData = Group _
            Select <Group ID=<%= category %>>
                       <%= _
                           From g In groupedData _
                           Select _
                           <Data>
                               <%= g.<Quantity>(0) %>
                               <%= g.<Price>(0) %>
                           </Data> _
                       %>
                   </Group> _
        %>
    </Root>
Console.WriteLine(newData)
```

This example produces the following output:

```xml
<Root>
  <Group ID="A">
    <Data>
      <Quantity>3</Quantity>
      <Price>24.50</Price>
    </Data>
    <Data>
      <Quantity>5</Quantity>
      <Price>4.95</Price>
    </Data>
    <Data>
      <Quantity>3</Quantity>
      <Price>66.00</Price>
    </Data>
    <Data>
      <Quantity>15</Quantity>
      <Price>29.00</Price>
    </Data>
  </Group>
  <Group ID="B">
    <Data>
      <Quantity>1</Quantity>
      <Price>89.99</Price>
    </Data>
    <Data>
      <Quantity>10</Quantity>
      <Price>.99</Price>
    </Data>
    <Data>
      <Quantity>8</Quantity>
      <Price>6.99</Price>
    </Data>
  </Group>
</Root>
```
