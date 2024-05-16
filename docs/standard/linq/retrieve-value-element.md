---
title: How to retrieve the value of an element - LINQ to XML
description: "Learn the two main ways to get the value of an element or attribute: cast  to the desired type, or use the XElement.Value and XAttribute.Value properties."
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to retrieve the value of an element (LINQ to XML)

This article shows how to get the value of elements. There are two main ways to get the value:

- Cast an <xref:System.Xml.Linq.XElement> or an <xref:System.Xml.Linq.XAttribute> to the desired type. The explicit conversion operator then converts the contents of the element or attribute to the specified type and assigns it to your variable.

- Use the <xref:System.Xml.Linq.XElement.Value%2A?displayProperty=nameWithType> or <xref:System.Xml.Linq.XAttribute.Value%2A?displayProperty=nameWithType> properties. You can also set the value using these properties.

With C#, casting is generally the better approach. If you cast the element or attribute to a nullable value type, the code is simpler to write when retrieving the value of an element (or attribute) that may not exist. The last example in this article demonstrates this. However, you can't set the contents of an element through casting, as you can through <xref:System.Xml.Linq.XElement.Value%2A?displayProperty=nameWithType> property.

With Visual Basic, the better approach is to use the <xref:System.Xml.Linq.XElement.Value%2A?displayProperty=nameWithType> property.

## String cast example  

To retrieve the value of an element, cast the <xref:System.Xml.Linq.XElement> object to your desired type. You can cast an element to a string, as follows:

```csharp
XElement e = new XElement("StringElement", "abcde");
Console.WriteLine(e);
Console.WriteLine("Value of e:" + (string)e);
```

```vb
Dim e As XElement = <StringElement>abcde</StringElement>
Console.WriteLine(e)
Console.WriteLine("Value of e:" & e.Value)
```

This example produces the following output:

```output
<StringElement>abcde</StringElement>
Value of e:abcde
```

## Integer cast example  

You can also cast elements to types other than string. For example, if you have an element that contains an integer, you can cast it to `int`, as shown in the following code:  

```csharp
XElement e = new XElement("Age", "44");
Console.WriteLine(e);
Console.WriteLine("Value of e:" + (int)e);
```

```vb
Dim e As XElement = <Age>44</Age>
Console.WriteLine(e)
Console.WriteLine("Value of e:" & CInt(e))
```

This example produces the following output:

```output
<Age>44</Age>
Value of e:44
```

LINQ to XML provides explicit cast operators for the following data types: `string`, `bool`, `bool?`, `int`, `int?`, `uint`, `uint?`, `long`, `long?`, `ulong`, `ulong?`, `float`, `float?`, `double`, `double?`, `decimal`, `decimal?`, `DateTime`, `DateTime?`, `TimeSpan`, `TimeSpan?`, `GUID`, and `GUID?`.

LINQ to XML provides the same cast operators for <xref:System.Xml.Linq.XAttribute> objects.

## Value property example

You can use the <xref:System.Xml.Linq.XElement.Value%2A> property to retrieve the contents of an element:

```csharp
XElement e = new XElement("StringElement", "abcde");
Console.WriteLine(e);
Console.WriteLine("Value of e:" + e.Value);
```

```vb
Dim e As XElement = <StringElement>abcde</StringElement>
Console.WriteLine(e)
Console.WriteLine("Value of e:" & e.Value)
```

This example produces the following output:

```output
<StringElement>abcde</StringElement>
Value of e:abcde
```

## Element might not exist example

Sometimes you try to retrieve the value of an element even though you're not sure if it exists. In this case, when you assign the casted element to a nullable reference type or nullable value type, if the element doesn't exist, the assigned variable is set to `null` (C#) or `nothing` (Visual Basic). The following code shows that when the element may not exist, it's easier to use casting than to use the <xref:System.Xml.Linq.XElement.Value%2A> property.

```csharp
XElement root = new XElement("Root",
    new XElement("Child1", "child 1 content"),
    new XElement("Child2", "2")
);

// The following assignments show why it's easier to use
// casting when the element might or might not exist.

string c1 = (string)root.Element("Child1");
Console.WriteLine("c1:{0}", c1 == null ? "element doesn't exist" : c1);

int? c2 = (int?)root.Element("Child2");
Console.WriteLine("c2:{0}", c2 == null ? "element doesn't exist" : c2.ToString());

string c3 = (string)root.Element("Child3");
Console.WriteLine("c3:{0}", c3 == null ? "element doesn't exist" : c3);

int? c4 = (int?)root.Element("Child4");
Console.WriteLine("c4:{0}", c4 == null ? "element doesn't exist" : c4.ToString());

Console.WriteLine();

// The following assignments show the required code when using
// the Value property when the element might or might not exist.
// Notice that this is more difficult than the casting approach.

XElement e1 = root.Element("Child1");
string v1;
if (e1 == null)
    v1 = null;
else
    v1 = e1.Value;
Console.WriteLine("v1:{0}", v1 == null ? "element doesn't exist" : v1);

XElement e2 = root.Element("Child2");
int? v2;
if (e2 == null)
    v2 = null;
else
    v2 = Int32.Parse(e2.Value);
Console.WriteLine("v2:{0}", v2 == null ? "element doesn't exist" : v2.ToString());

XElement e3 = root.Element("Child3");
string v3;
if (e3 == null)
    v3 = null;
else
    v3 = e3.Value;
Console.WriteLine("v3:{0}", v3 == null ? "element doesn't exist" : v3);

XElement e4 = root.Element("Child4");
int? v4;
if (e4 == null)
    v4 = null;
else
    v4 = Int32.Parse(e4.Value);
Console.WriteLine("v4:{0}", v4 == null ? "element doesn't exist" : v4.ToString());
```

```vb
Dim root As XElement = <Root>
                           <Child1>child 1 content</Child1>
                           <Child2>2</Child2>
                       </Root>

' The following assignments show why it's easier to use
' casting when the element might or might not exist.

Dim c1 As String = CStr(root.Element("Child1"))
Console.WriteLine("c1:{0}", IIf(c1 Is Nothing, "element doesn't exist", c1))

Dim c2 As Nullable(Of Integer) = CType(root.Element("Child2"), Nullable(Of Integer))
Console.WriteLine("c2:{0}", IIf(Not (c2.HasValue), "element doesn't exist", c2.ToString()))

Dim c3 As String = CStr(root.Element("Child3"))
Console.WriteLine("c3:{0}", IIf(c3 Is Nothing, "element doesn't exist", c3))

Dim c4 As Nullable(Of Integer) = CType(root.Element("Child4"), Nullable(Of Integer))
Console.WriteLine("c4:{0}", IIf(Not (c4.HasValue), "element doesn't exist", c4.ToString()))

Console.WriteLine()

' The following assignments show the required code when using
' the Value property when the attribute might or might not exist.
' Notice that this is more difficult than the casting approach.

Dim e1 As XElement = root.Element("Child1")
Dim v1 As String
If (e1 Is Nothing) Then
    v1 = Nothing
Else
    v1 = e1.Value
End If
Console.WriteLine("v1:{0}", IIf(v1 Is Nothing, "element doesn't exist", v1))

Dim e2 As XElement = root.Element("Child2")
Dim v2 As Nullable(Of Integer)
If (e2 Is Nothing) Then
    v2 = Nothing
Else
    v2 = e2.Value
End If
Console.WriteLine("v2:{0}", IIf(Not (v2.HasValue), "element doesn't exist", v2))

Dim e3 As XElement = root.Element("Child3")
Dim v3 As String
If (e3 Is Nothing) Then
    v3 = Nothing
Else
    v3 = e3.Value
End If
Console.WriteLine("v3:{0}", IIf(v3 Is Nothing, "element doesn't exist", v3))

Dim e4 As XElement = root.Element("Child4")
Dim v4 As Nullable(Of Integer)
If (e4 Is Nothing) Then
    v4 = Nothing
Else
    v4 = e4.Value
End If
Console.WriteLine("v4:{0}", IIf(Not (v4.HasValue), "element doesn't exist", v4))
```

This example produces the following output:

```output
c1:child 1 content
c2:2
c3:element doesn't exist
c4:element doesn't exist

v1:child 1 content
v2:2
v3:element doesn't exist
v4:element doesn't exist
```

In general, you can write simpler code by casting to retrieve the contents of elements and attributes.

## See also

- [LINQ to XML axes overview](linq-xml-axes-overview.md)
