---
title: How to find descendants of a child element - LINQ to XML
description: "Learn how to find descendants of a child element or a sequence of child elements. Two methods are shown: one uses XPathEvaluate, the other uses LINQ to XML query."
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to find descendants of a child element (LINQ to XML)

This article shows how to use <xref:System.Xml.XPath.Extensions.XPathEvaluate%2A> to find the descendant elements of a sequence of child elements, and how to use LINQ to XML query to find the same elements.

## Example: Find all the `Text` descendant elements of all the `Paragraph` elements

This example extracts text from an XML representation of a simple word processing document. It first selects all `Paragraph` elements, ignoring the `Comment` element, and then it selects all the `Text` descendant elements of each `Paragraph` element. It does this task in two ways: with <xref:System.Xml.XPath.Extensions.XPathEvaluate%2A> and with LINQ to XML query. It then compares the results and finds them identical.

The XPath expression is  `./Paragraph//Text/text()`.

```csharp
XElement root = XElement.Parse(
@"<Root>
  <Paragraph>
    <Text>This is the start of</Text>
  </Paragraph>
  <Comment>
    <Text>This comment isn't part of the paragraph text.</Text>
  </Comment>
  <Paragraph>
    <Annotation Emphasis='true'>
      <Text> a sentence.</Text>
    </Annotation>
  </Paragraph>
  <Paragraph>
    <Text>  This is the second sentence.</Text>
  </Paragraph>
</Root>");

// LINQ to XML query
string str1 =
    root
    .Elements("Paragraph")
    .Descendants("Text")
    .Select(s => s.Value)
    .Aggregate(
        new StringBuilder(),
        (s, i) => s.Append(i),
        s => s.ToString()
    );

// XPath expression
string str2 =
    ((IEnumerable)root.XPathEvaluate("./Paragraph//Text/text()"))
    .Cast<XText>()
    .Select(s => s.Value)
    .Aggregate(
        new StringBuilder(),
        (s, i) => s.Append(i),
        s => s.ToString()
    );

if (str1 == str2)
    Console.WriteLine("Results are identical");
else
    Console.WriteLine("Results differ");
Console.WriteLine(str2);
```

```vb
Dim root As XElement = _
    <Root>
        <Paragraph>
            <Text>This is the start of</Text>
        </Paragraph>
        <Comment>
            <Text>This comment isn't part of the paragraph text.</Text>
        </Comment>
        <Paragraph>
            <Annotation Emphasis='true'>
                <Text> a sentence.</Text>
            </Annotation>
        </Paragraph>
        <Paragraph>
            <Text>This is the second sentence.</Text>
        </Paragraph>
    </Root>

' LINQ to XML query
Dim str1 As String = _
    root.<Paragraph>...<Text>.Select(Function(ByVal s) s.Value). _
    Aggregate( _
        New StringBuilder(), _
        Function(ByVal s, ByVal i) s.Append(i), _
        Function(ByVal s) s.ToString())

' XPath expression
Dim str2 As String = DirectCast(root.XPathEvaluate("./Paragraph//Text/text()"), IEnumerable) _
    .Cast(Of XText)().Select(Function(ByVal s) s.Value) _
    .Aggregate( _
        New StringBuilder(), _
        Function(ByVal s, ByVal i) s.Append(i), _
        Function(ByVal s) s.ToString())

If str1 = str2 Then
    Console.WriteLine("Results are identical")
Else
    Console.WriteLine("Results differ")
End If
Console.WriteLine(str2)
```

This example produces the following output:

```output
Results are identical
This is the start of a sentence.  This is the second sentence.
```

## See also

- [LINQ to XML for XPath Users (Visual Basic)](./comparison-xpath-linq-xml.md)
