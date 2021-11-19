---
title: How to write a LINQ to XML axis method - LINQ to XML
description: Learn how to write your own axis methods to retrieve collections from an XML tree in C# or Visual Basic.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---
# How to write a LINQ to XML axis method (LINQ to XML)

An XML [axis method](linq-xml-axes-overview.md) retrieves a collection of XML elements from an XML document or ancestor element. You can write your own axis methods to retrieve collections from an XML tree. One of the best ways to do this is to write an extension method that returns a collection of elements or attributes. You can write your extension method to return specific subsets of elements or attributes, based on the requirements of your application. This article provides an example for C# and Visual Basic.

## Example

The following example uses two extension methods. The first extension method, `GetXPath`, operates on <xref:System.Xml.Linq.XObject>, and returns an XPath expression that when evaluated will return the node or attribute. The second extension method, `Find`, operates on <xref:System.Xml.Linq.XElement>. It returns a collection of <xref:System.Xml.Linq.XAttribute> objects and <xref:System.Xml.Linq.XElement> objects that contain some specified text.

This example uses XML document [Sample XML file: Multiple purchase orders](sample-xml-file-multiple-purchase-orders.md).

```csharp
public static class MyExtensions
{
    private static string GetQName(XElement xe)
    {
        string prefix = xe.GetPrefixOfNamespace(xe.Name.Namespace);
        if (xe.Name.Namespace == XNamespace.None || prefix == null)
            return xe.Name.LocalName.ToString();
        else
            return prefix + ":" + xe.Name.LocalName.ToString();
    }

    private static string GetQName(XAttribute xa)
    {
        string prefix =
            xa.Parent.GetPrefixOfNamespace(xa.Name.Namespace);
        if (xa.Name.Namespace == XNamespace.None || prefix == null)
            return xa.Name.ToString();
        else
            return prefix + ":" + xa.Name.LocalName;
    }

    private static string NameWithPredicate(XElement el)
    {
        if (el.Parent != null && el.Parent.Elements(el.Name).Count() != 1)
            return GetQName(el) + "[" +
                (el.ElementsBeforeSelf(el.Name).Count() + 1) + "]";
        else
            return GetQName(el);
    }

    public static string StrCat<T>(this IEnumerable<T> source,
        string separator)
    {
        return source.Aggregate(new StringBuilder(),
                   (sb, i) => sb
                       .Append(i.ToString())
                       .Append(separator),
                   s => s.ToString());
    }

    public static string GetXPath(this XObject xobj)
    {
        if (xobj.Parent == null)
        {
            XDocument doc = xobj as XDocument;
            if (doc != null)
                return ".";
            XElement el = xobj as XElement;
            if (el != null)
                return "/" + NameWithPredicate(el);
            // The XPath data model doesn't include white space text nodes
            // that are children of a document, so this method returns null.
            XText xt = xobj as XText;
            if (xt != null)
                return null;
            XComment com = xobj as XComment;
            if (com != null)
                return
                    "/" +
                    (
                        com
                        .Document
                        .Nodes()
                        .OfType<XComment>()
                        .Count() != 1 ?
                        "comment()[" +
                        (com
                        .NodesBeforeSelf()
                        .OfType<XComment>()
                        .Count() + 1) +
                        "]" :
                        "comment()"
                    );
            XProcessingInstruction pi = xobj as XProcessingInstruction;
            if (pi != null)
                return
                    "/" +
                    (
                        pi.Document.Nodes()
                        .OfType<XProcessingInstruction>()
                        .Count() != 1 ?
                        "processing-instruction()[" +
                        (pi
                        .NodesBeforeSelf()
                        .OfType<XProcessingInstruction>()
                        .Count() + 1) +
                        "]" :
                        "processing-instruction()"
                    );
            return null;
        }
        else
        {
            XElement el = xobj as XElement;
            if (el != null)
            {
                return
                    "/" +
                    el
                    .Ancestors()
                    .InDocumentOrder()
                    .Select(e => NameWithPredicate(e))
                    .StrCat("/") +
                    NameWithPredicate(el);
            }
            XAttribute at = xobj as XAttribute;
            if (at != null)
                return
                    "/" +
                    at
                    .Parent
                    .AncestorsAndSelf()
                    .InDocumentOrder()
                    .Select(e => NameWithPredicate(e))
                    .StrCat("/") +
                    "@" + GetQName(at);
            XComment com = xobj as XComment;
            if (com != null)
                return
                    "/" +
                    com
                    .Parent
                    .AncestorsAndSelf()
                    .InDocumentOrder()
                    .Select(e => NameWithPredicate(e))
                    .StrCat("/") +
                    (
                        com
                        .Parent
                        .Nodes()
                        .OfType<XComment>()
                        .Count() != 1 ?
                        "comment()[" +
                        (com
                        .NodesBeforeSelf()
                        .OfType<XComment>()
                        .Count() + 1) + "]" :
                        "comment()"
                    );
            XCData cd = xobj as XCData;
            if (cd != null)
                return
                    "/" +
                    cd
                    .Parent
                    .AncestorsAndSelf()
                    .InDocumentOrder()
                    .Select(e => NameWithPredicate(e))
                    .StrCat("/") +
                    (
                        cd
                        .Parent
                        .Nodes()
                        .OfType<XText>()
                        .Count() != 1 ?
                        "text()[" +
                        (cd
                        .NodesBeforeSelf()
                        .OfType<XText>()
                        .Count() + 1) + "]" :
                        "text()"
                    );
            XText tx = xobj as XText;
            if (tx != null)
                return
                    "/" +
                    tx
                    .Parent
                    .AncestorsAndSelf()
                    .InDocumentOrder()
                    .Select(e => NameWithPredicate(e))
                    .StrCat("/") +
                    (
                        tx
                        .Parent
                        .Nodes()
                        .OfType<XText>()
                        .Count() != 1 ?
                        "text()[" +
                        (tx
                        .NodesBeforeSelf()
                        .OfType<XText>()
                        .Count() + 1) + "]" :
                        "text()"
                    );
            XProcessingInstruction pi = xobj as XProcessingInstruction;
            if (pi != null)
                return
                    "/" +
                    pi
                    .Parent
                    .AncestorsAndSelf()
                    .InDocumentOrder()
                    .Select(e => NameWithPredicate(e))
                    .StrCat("/") +
                    (
                        pi
                        .Parent
                        .Nodes()
                        .OfType<XProcessingInstruction>()
                        .Count() != 1 ?
                        "processing-instruction()[" +
                        (pi
                        .NodesBeforeSelf()
                        .OfType<XProcessingInstruction>()
                        .Count() + 1) + "]" :
                        "processing-instruction()"
                    );
            return null;
        }
    }

    public static IEnumerable<XObject> Find(this XElement source, string value)
    {
        if (source.Attributes().Any())
        {
            foreach (XAttribute att in source.Attributes())
            {
                string contents = (string)att;
                if (contents.Contains(value))
                    yield return att;
            }
        }
        if (source.Elements().Any())
        {
            foreach (XElement child in source.Elements())
                foreach (XObject s in child.Find(value))
                    yield return s;
        }
        else
        {
            string contents = (string)source;
            if (contents.Contains(value))
                yield return source;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        XElement purchaseOrders = XElement.Load("PurchaseOrders.xml");

        IEnumerable<XObject> subset =
            from xobj in purchaseOrders.Find("1999")
            select xobj;

        foreach (XObject obj in subset)
        {
            Console.WriteLine(obj.GetXPath());
            if (obj.GetType() == typeof(XElement))
                Console.WriteLine(((XElement)obj).Value);
            else if (obj.GetType() == typeof(XAttribute))
                Console.WriteLine(((XAttribute)obj).Value);
        }
    }
}
```

```vb
Imports System.Runtime.CompilerServices
Imports System.Text

Module Module1
    Sub Main()
        Dim purchaseOrders = XElement.Load("..\..\PurchaseOrders.xml")

        Dim subset = From xobj In purchaseOrders.Find("1999")

        For Each obj In subset
            Console.WriteLine(obj.GetXPath())
            If obj.GetType() = GetType(XElement) Then
                Console.WriteLine(CType(obj, XElement).Value)
            ElseIf obj.GetType() = GetType(XAttribute) Then
                Console.WriteLine(CType(obj, XAttribute).Value)
            End If
        Next
    End Sub
End Module

Public Module MyExtensions

    Private Function GetQName(ByVal xe As XElement) As String
        Dim prefix = xe.GetPrefixOfNamespace(xe.Name.Namespace)
        If xe.Name.Namespace = XNamespace.None OrElse prefix Is Nothing Then
            Return xe.Name.LocalName
        Else
            Return prefix & ":" & xe.Name.LocalName
        End If
    End Function

    Private Function GetQName(ByVal xa As XAttribute) As String
        Dim prefix = xa.Parent.GetPrefixOfNamespace(xa.Name.Namespace)
        If xa.Name.Namespace = XNamespace.None OrElse prefix Is Nothing Then
            Return xa.Name.LocalName
        Else
            Return prefix & ":" & xa.Name.LocalName
        End If
    End Function

    Private Function NameWithPredicate(ByVal el As XElement) As String
        If el.Parent IsNot Nothing AndAlso
           el.Parent.Elements(el.Name).Count() <> 1 Then
            Return GetQName(el) & "[" &
                (el.ElementsBeforeSelf(el.Name).Count() + 1) & "]"
        Else
            Return GetQName(el)
        End If
    End Function

    <Extension()>
    Public Function StrCat(Of T)(ByVal source As IEnumerable(Of T),
                                 ByVal separator As String) As String
        Return source.Aggregate(New StringBuilder,
                                Function(sb, i) sb.
                                    Append(i.ToString()).
                                    Append(separator),
                                    Function(s) s.ToString())
    End Function

    <Extension()>
    Public Function GetXPath(ByVal xobj As XObject) As String

        If xobj.Parent Is Nothing Then
            Dim doc = TryCast(xobj, XDocument)
            If doc IsNot Nothing Then Return "."

            Dim el = TryCast(xobj, XElement)
            If el IsNot Nothing Then Return "/" + NameWithPredicate(el)

            ' The XPath data model doesn't include white space text nodes
            ' that are children of a document, so this method returns null.

            Dim xt = TryCast(xobj, XText)
            If xt IsNot Nothing Then Return Nothing

            Dim com = TryCast(xobj, XComment)
            If com IsNot Nothing Then
                Return "/" &
                    If(com.Document.Nodes().OfType(Of XComment)().Count() <> 1,
                       "comment()[" & (com.NodesBeforeSelf().OfType(Of XComment)().Count() + 1) & "]",
                       "comment()")
            End If

            Dim pi = TryCast(xobj, XProcessingInstruction)
            If pi IsNot Nothing Then
                Return "/" &
                    If(pi.Document.Nodes().OfType(Of XProcessingInstruction)().Count() <> 1,
                       "processing-instruction()[" &
                           (pi.NodesBeforeSelf().OfType(Of XProcessingInstruction)().Count() + 1) & "]",
                       "processing-instruction()")
            End If
            Return Nothing
        Else
            Dim el = TryCast(xobj, XElement)
            If el IsNot Nothing Then
                Return "/" &
                    el.Ancestors().
                    InDocumentOrder().
                    Select(Function(e) NameWithPredicate(e)).StrCat("/") & NameWithPredicate(el)
            End If
            Dim at = TryCast(xobj, XAttribute)
            If at IsNot Nothing Then
                Return "/" &
                    at.Parent.
                    AncestorsAndSelf().
                    InDocumentOrder().
                    Select(Function(e) NameWithPredicate(e)).StrCat("/") & "@" & GetQName(at)
            End If
            Dim com = TryCast(xobj, XComment)
            If com IsNot Nothing Then
                Return "/" &
                    com.Parent.
                    AncestorsAndSelf().
                    InDocumentOrder().
                    Select(Function(e) NameWithPredicate(e)).StrCat("/") &
                        If(com.Parent.Nodes().OfType(Of XComment)().Count() <> 1,
                           "comment()[" & (com.NodesBeforeSelf().OfType(Of XComment)().Count() + 1) & "]",
                           "comment()")
            End If

            Dim cd = TryCast(xobj, XCData)
            If cd IsNot Nothing Then
                Return "/" &
                    cd.Parent.
                    AncestorsAndSelf().
                    InDocumentOrder().
                    Select(Function(e) NameWithPredicate(e)).StrCat("/") &
                        If(cd.Parent.Nodes().OfType(Of XText)().Count() <> 1,
                           "text()[" & (cd.NodesBeforeSelf().OfType(Of XText)().Count() + 1) & "]",
                           "text()")
            End If
            Dim tx = TryCast(xobj, XText)
            If tx IsNot Nothing Then
                Return "/" &
                    tx.Parent.
                    AncestorsAndSelf().
                    InDocumentOrder().
                    Select(Function(e) NameWithPredicate(e)).StrCat("/") &
                        If(tx.Parent.Nodes().OfType(Of XText)().Count() <> 1,
                           "text()[" & (tx.NodesBeforeSelf().OfType(Of XText)().Count() + 1) & "]",
                           "text()")
            End If
            Dim pi As XProcessingInstruction = TryCast(xobj, XProcessingInstruction)
            If pi IsNot Nothing Then
                Return "/" &
                    pi.Parent.
                    AncestorsAndSelf().
                    InDocumentOrder().
                    Select(Function(e) NameWithPredicate(e)).StrCat("/") &
                        If(pi.Parent.Nodes().OfType(Of XProcessingInstruction)().Count() <> 1,
                           "processing-instruction()[" &
                               (pi.NodesBeforeSelf().OfType(Of XProcessingInstruction)().Count() + 1) & "]",
                           "processing-instruction()")
            End If
            Return Nothing
        End If
    End Function

    <Extension()>
    Public Function Find(ByVal source As XElement, ByVal value As String) As IEnumerable(Of XObject)
        Dim results = From att In source.Attributes()
                      Where att.Value.Contains(value)
                      Let a As XObject = att
                      Select a

        If source.Elements().Any Then
            For Each result In From child In source.Elements() Select Find(child, value)
                results = If(results Is Nothing, result, results.Union(result))
            Next
        Else
            If source.Value.Contains(value) Then
                results = If(results Is Nothing,
                             New List(Of XObject) From {source},
                             results.Union(New List(Of XObject) From {source}))
            End If
        End If

        Return results
    End Function

End Module
```

This example produces the following output:

```output
/PurchaseOrders/PurchaseOrder[1]/@OrderDate
1999-10-20
/PurchaseOrders/PurchaseOrder[1]/Items/Item[2]/ShipDate
1999-05-21
/PurchaseOrders/PurchaseOrder[2]/@OrderDate
1999-10-22
/PurchaseOrders/PurchaseOrder[3]/@OrderDate
1999-10-22
```
