---
title: LINQ to XML events - LINQ to XML
description: Learn how to use XML events to monitor changes to an XML tree.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: reference
---

# LINQ to XML Events (LINQ to XML)

LINQ to XML events enable you to be notified when an XML tree is altered.

You can add events to any instance of any <xref:System.Xml.Linq.XObject>. The event handler will then receive events for modifications to that <xref:System.Xml.Linq.XObject> and any of its descendants. For example, you can add an event handler to the root of the tree, and handle all modifications to the tree from that event handler.

For examples of LINQ to XML events, see <xref:System.Xml.Linq.XObject.Changing> and <xref:System.Xml.Linq.XObject.Changed>.

## Types and events

You use the following types when working with events:

|Type|Description|
|----------|-----------------|
|<xref:System.Xml.Linq.XObjectChange>|Specifies the event type when an event is raised for an <xref:System.Xml.Linq.XObject>.|
|<xref:System.Xml.Linq.XObjectChangeEventArgs>|Provides data for the <xref:System.Xml.Linq.XObject.Changing> and <xref:System.Xml.Linq.XObject.Changed> events.|

The following events are raised when you modify an XML tree:

|Event|Description|
|-----------|-----------------|
|<xref:System.Xml.Linq.XObject.Changing>|Occurs just before this <xref:System.Xml.Linq.XObject> or any of its descendants is going to change.|
|<xref:System.Xml.Linq.XObject.Changed>|Occurs when an <xref:System.Xml.Linq.XObject> has changed or any of its descendants have changed.|

## Example: Use events to maintain a proper total when items are changed

Events are useful when you want to maintain some aggregate information in an XML tree. For example, you may want to maintain an invoice total that's the sum of the line items of the invoice. This example uses events to maintain the total of all of the child elements under the complex element `Items`.

```csharp
XElement root = new XElement("Root",
    new XElement("Total", "0"),
    new XElement("Items")
);
XElement total = root.Element("Total");
XElement items = root.Element("Items");
items.Changed += (object sender, XObjectChangeEventArgs cea) =>
{
    switch (cea.ObjectChange)
    {
        case XObjectChange.Add:
            if (sender is XElement)
                total.Value = ((int)total + (int)(XElement)sender).ToString();
            if (sender is XText)
                total.Value = ((int)total + (int)((XText)sender).Parent).ToString();
            break;
        case XObjectChange.Remove:
            if (sender is XElement)
                total.Value = ((int)total - (int)(XElement)sender).ToString();
            if (sender is XText)
                total.Value = ((int)total - Int32.Parse(((XText)sender).Value)).ToString();
            break;
    }
    Console.WriteLine("Changed {0} {1}",
      sender.GetType().ToString(), cea.ObjectChange.ToString());
};
items.SetElementValue("Item1", 25);
items.SetElementValue("Item2", 50);
items.SetElementValue("Item2", 75);
items.SetElementValue("Item3", 133);
items.SetElementValue("Item1", null);
items.SetElementValue("Item4", 100);
Console.WriteLine("Total:{0}", (int)total);
Console.WriteLine(root);
```

```vb
Module Module1
    Dim WithEvents items As XElement = Nothing
    Dim total As XElement = Nothing
    Dim root As XElement = _
            <Root>
                <Total>0</Total>
                <Items></Items>
            </Root>

    Private Sub XObjectChanged( _
            ByVal sender As Object, _
            ByVal cea As XObjectChangeEventArgs) _
            Handles items.Changed
        Select Case cea.ObjectChange
            Case XObjectChange.Add
                If sender.GetType() Is GetType(XElement) Then
                    total.Value = CStr(CInt(total.Value) + _
                            CInt((DirectCast(sender, XElement)).Value))
                End If
                If sender.GetType() Is GetType(XText) Then
                    total.Value = CStr(CInt(total.Value) + _
                            CInt((DirectCast(sender, XText)).Value))
                End If
            Case XObjectChange.Remove
                If sender.GetType() Is GetType(XElement) Then
                    total.Value = CStr(CInt(total.Value) - _
                            CInt((DirectCast(sender, XElement)).Value))
                End If
                If sender.GetType() Is GetType(XText) Then
                    total.Value = CStr(CInt(total.Value) - _
                            CInt((DirectCast(sender, XText)).Value))
                End If
        End Select
        Console.WriteLine("Changed {0} {1}", _
                            sender.GetType().ToString(), _
                            cea.ObjectChange.ToString())
    End Sub

    Sub Main()
        total = root.<Total>(0)
        items = root.<Items>(0)
        items.SetElementValue("Item1", 25)
        items.SetElementValue("Item2", 50)
        items.SetElementValue("Item2", 75)
        items.SetElementValue("Item3", 133)
        items.SetElementValue("Item1", Nothing)
        items.SetElementValue("Item4", 100)
        Console.WriteLine("Total:{0}", CInt(total))
        Console.WriteLine(root)
    End Sub
End Module
```

This example produces the following output:

```output
Changed System.Xml.Linq.XElement Add
Changed System.Xml.Linq.XElement Add
Changed System.Xml.Linq.XText Remove
Changed System.Xml.Linq.XText Add
Changed System.Xml.Linq.XElement Add
Changed System.Xml.Linq.XElement Remove
Changed System.Xml.Linq.XElement Add
Total:308
<Root>
  <Total>308</Total>
  <Items>
    <Item2>75</Item2>
    <Item3>133</Item3>
    <Item4>100</Item4>
  </Items>
</Root>
```
