---
title: How to find descendants with a specific element name - LINQ to XML
description: To find all descendants that have a specific name, it's easier to use XContainer.Descendants than to iterate through all the descendants.
ms.date: 07/20/2015
ms.topic: how-to
---

# How to find descendants with a specific element name (LINQ to XML)

Sometimes you want to find all descendants with a specific name. You could write code to iterate through all of the descendants, but it's easier to use the <xref:System.Xml.Linq.XContainer.Descendants%2A> axis.

## Example: Find descendants with a specific element name

The following example shows how to find descendants with a specific element name.

```csharp
XElement root = XElement.Parse(@"<root>
  <para>
    <r>
      <t>Some text </t>
    </r>
    <n>
      <r>
        <t>that's broken up into </t>
      </r>
    </n>
    <n>
      <r>
        <t>multiple segments.</t>
      </r>
    </n>
  </para>
</root>");
IEnumerable<string> textSegs =
    from seg in root.Descendants("t")
    select (string)seg;

string str = textSegs.Aggregate(new StringBuilder(),
    (sb, i) => sb.Append(i),
    sp => sp.ToString()
);

Console.WriteLine(str);
```

```vb
Dim root As XElement = _
    <root>
        <para>
            <r>
                <t>Some text </t>
            </r>
            <n>
                <r>
                    <t>that's broken up into </t>
                </r>
            </n>
            <n>
                <r>
                    <t>multiple segments.</t>
                </r>
            </n>
        </para>
    </root>

Dim textSegs As IEnumerable(Of String) = _
    From seg In root...<t> _
    Select seg.Value

Dim str As String = textSegs.Aggregate( _
    New StringBuilder, _
    Function(sb, i) sb.Append(i), _
    Function(sb) sb.ToString)

Console.WriteLine(str)
```

This example produces the following output:

```output
Some text that's broken up into multiple segments.

## Example: Find when the XML is in a namespace

The following example shows the same query for XML that's in a namespace. For more information, see [Namespaces overview](namespaces-overview.md).

```csharp
XElement root = XElement.Parse(@"<root xmlns='http://www.adatum.com'>
  <para>
    <r>
      <t>Some text </t>
    </r>
    <n>
      <r>
        <t>that's broken up into </t>
      </r>
    </n>
    <n>
      <r>
        <t>multiple segments.</t>
      </r>
    </n>
  </para>
</root>");
XNamespace ad = "http://www.adatum.com";
IEnumerable<string> textSegs =
    from seg in root.Descendants(ad + "t")
    select (string)seg;

string str = textSegs.Aggregate(new StringBuilder(),
    (sb, i) => sb.Append(i),
    sp => sp.ToString()
);

Console.WriteLine(str);
```

```vb
Imports <xmlns='http://www.adatum.com'>

Module Module1
    Sub Main()
        Dim root As XElement = _
            <root>
                <para>
                    <r>
                        <t>Some text </t>
                    </r>
                    <n>
                        <r>
                            <t>that's broken up into </t>
                        </r>
                    </n>
                    <n>
                        <r>
                            <t>multiple segments.</t>
                        </r>
                    </n>
                </para>
            </root>

        Dim textSegs As IEnumerable(Of String) = _
            From seg In root...<t> _
            Select seg.Value

        Dim str As String = textSegs.Aggregate( _
            New StringBuilder, _
            Function(sb, i) sb.Append(i), _
            Function(sb) sb.ToString)

        Console.WriteLine(str)
    End Sub
End Module
```

This example produces the following output:

```output
Some text that's broken up into multiple segments.
```

## See also

- <xref:System.Xml.Linq.XContainer.Descendants%2A>
