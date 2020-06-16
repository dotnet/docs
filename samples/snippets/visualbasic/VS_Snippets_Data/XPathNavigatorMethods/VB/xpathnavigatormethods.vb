Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Collections

Class XPathNavigatorMethods

    Shared contosobooks As String = "C:\Documents and Settings\dylanm\My Documents\contosoBooks.xml"

    Shared Sub Main()

    End Sub

#Region "AppendChild/Element"
    Shared Sub XPathNavigatorMethods_AppendChild1()

        '<snippet1>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim pages As XmlWriter = navigator.AppendChild()
        pages.WriteElementString("pages", "100")
        pages.Close()

        Console.WriteLine(navigator.OuterXml)
        '</snippet1>

    End Sub

    Shared Sub XPathNavigatorMethods_AppendChild2()

        '<snippet2>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        navigator.AppendChild("<pages>100</pages>")

        Console.WriteLine(navigator.OuterXml)
        '</snippet2>

    End Sub


    Shared Sub XPathNavigatorMethods_AppendChild3()

        '<snippet3>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim pages As XmlReader = XmlReader.Create(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))

        navigator.AppendChild(pages)

        Console.WriteLine(navigator.OuterXml)
        '</snippet3>

    End Sub

    Shared Sub XPathNavigatorMethods_AppendChild4()

        '<snippet4>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim childNodes As XmlDocument = New XmlDocument()

        childNodes.Load(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))
        Dim childNodesNavigator As XPathNavigator = childNodes.CreateNavigator()

        If childNodesNavigator.MoveToChild("pages", "http://www.contoso.com/books") Then
            navigator.AppendChild(childNodesNavigator)
        End If

        Console.WriteLine(navigator.OuterXml)
        '</snippet4>

    End Sub

    Shared Sub XPathNavigatorMethods_AppendChildElement()

        '<snippet5>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        navigator.AppendChildElement(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100")

        Console.WriteLine(navigator.OuterXml)
        '</snippet5>

    End Sub
#End Region

#Region "Clone"
    Shared Sub XPathNavigatorMethods_Clone()

        '<snippet6>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Select all books authored by Melville.
        Dim nodes As XPathNodeIterator = navigator.Select("descendant::book[author/last-name='Melville']")

        While nodes.MoveNext()
            ' Clone the navigator returned by the Current property. 
            ' Use the cloned navigator to get the title element.
            Dim clone As XPathNavigator = nodes.Current.Clone()
            clone.MoveToFirstChild()
            Console.WriteLine("Book title: {0}", clone.Value)
        End While
        '</snippet6>

    End Sub
#End Region

#Region "CreateAttribute(s)"
    Shared Sub XPathNavigatorMethods_CreateAttribute()

        '<snippet7>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        navigator.CreateAttribute("", "discount", "", "1.00")

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)

        '</snippet7>
    End Sub

    Shared Sub XPathNavigatorMethods_CreateAttributes()

        '<snippet8>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim attributes As XmlWriter = navigator.CreateAttributes()

        attributes.WriteAttributeString("discount", "1.00")
        attributes.WriteAttributeString("currency", "USD")
        attributes.Close()

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet8>

    End Sub
#End Region

#Region "DeleteRange"

    Shared Sub XPathNavigatorMethods_DeleteRange()

        ' XPathNavigator.DeleteRange()

        '<snippet52>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(document.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim first As XPathNavigator = navigator.SelectSingleNode("/bk:bookstore/bk:book[1]", manager)
        Dim last As XPathNavigator = navigator.SelectSingleNode("/bk:bookstore/bk:book[2]", manager)

        navigator.MoveTo(first)
        navigator.DeleteRange(last)
        Console.WriteLine(navigator.OuterXml)
        '</snippet52>

    End Sub

#End Region

#Region "DeleteSelf"
    Shared Sub XPathNavigatorMethods_DeleteSelf()

        '<snippet9>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        navigator.DeleteSelf()

        Console.WriteLine("Position after delete: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
        '</snippet9>

    End Sub
#End Region

#Region "Evaluate"
    Shared Sub XPathNavigatorMethods_Evaluate1()

        '<snippet10>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim total As Double = CType(navigator.Evaluate("sum(descendant::book/price)"), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())

        '</snippet10>
    End Sub

    Shared Sub XPathNavigatorMethods_Evaluate2()

        '<snippet11>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim query As XPathExpression = navigator.Compile("sum(descendant::book/price)")

        Dim total As Double = CType(navigator.Evaluate(query), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())

        '</snippet11>
    End Sub

    Shared Sub XPathNavigatorMethods_Evaluate3()

        '<snippet12>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim total As Double = CType(navigator.Evaluate("sum(descendant::bk:book/bk:price)", manager), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())

        '</snippet12>
    End Sub

    Shared Sub XPathNavigatorMethods_Evaluate4()

        '<snippet13>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim nodes As XPathNodeIterator = navigator.Select("//book")
        Dim query As XPathExpression = nodes.Current.Compile("sum(descendant::price)")

        Dim total As Double = CType(navigator.Evaluate(query, nodes), Double)
        Console.WriteLine("Total price for all books: {0}", total.ToString())
        '</snippet13>

    End Sub
#End Region

#Region "InsertAfter"
    Shared Sub XPathNavigatorMethods_InsertAfter1()

        '<snippet14>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim pages As XmlWriter = navigator.InsertAfter()
        pages.WriteElementString("pages", "100")
        pages.Close()

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet14>

    End Sub

    Shared Sub XPathNavigatorMethods_InsertAfter2()

        '<snippet15>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        navigator.InsertAfter("<pages>100</pages>")

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet15>

    End Sub

    Shared Sub XPathNavigatorMethods_InsertAfter3()
        ' XPathNavigator.InsertAfter(XmlReader)

        '<snippet16>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim pages As XmlReader = XmlReader.Create(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))

        navigator.InsertAfter(pages)

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet16>

    End Sub

    Shared Sub XPathNavigatorMethods_InsertAfter4()
        ' XPathNavigator.InsertAfter(XPathNavigator)

        '<snippet17>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim childNodes As XmlDocument = New XmlDocument()
        childNodes.Load(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))
        Dim childNodesNavigator As XPathNavigator = childNodes.CreateNavigator()

        navigator.InsertAfter(childNodesNavigator)

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet17>

    End Sub
#End Region

#Region "InsertBefore"
    Shared Sub XPathNavigatorMethods_InsertBefore1()
        ' XPathNavigator.InsertBefore()

        '<snippet18>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim pages As XmlWriter = navigator.InsertBefore()
        pages.WriteElementString("pages", "100")
        pages.Close()

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet18>

    End Sub

    Shared Sub XPathNavigatorMethods_InsertBefore2()
        ' XPathNavigator.InsertBefore(string)

        '<snippet19>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        navigator.InsertBefore("<pages>100</pages>")

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet19>

    End Sub

    Shared Sub XPathNavigatorMethods_InsertBefore3()
        ' XPathNavigator.InsertBefore(XmlReader)

        '<snippet20>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim pages As XmlReader = XmlReader.Create(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))

        navigator.InsertBefore(pages)

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet20>

    End Sub

    Shared Sub XPathNavigatorMethods_InsertBefore4()
        ' XPathNavigator.InsertBefore(XPathNavigator)

        '<snippet21>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim childNodes As XmlDocument = New XmlDocument()
        childNodes.Load(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))
        Dim childNodesNavigator As XPathNavigator = childNodes.CreateNavigator()

        navigator.InsertBefore(childNodesNavigator)

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet21>

    End Sub
#End Region

#Region "InsertElementAfter/Before"
    Shared Sub XPathNavigatorMethods_InsertElementAfter()
        ' XPathNavigator.InsertElementAfter(string, string, string, string)

        '<snippet22>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        navigator.InsertElementAfter(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100")

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet22>

    End Sub

    Shared Sub XPathNavigatorMethods_InsertElementBefore()
        ' XPathNavigator.InsertElementBefore(string, string, string, string)

        '<snippet23>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        navigator.InsertElementBefore(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100")

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet23>

    End Sub
#End Region

#Region "Matches"
    Shared Sub XPathNavigatorMethods_Matches()

        '<snippet24>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Select all book nodes.
        Dim nodes As XPathNodeIterator = navigator.SelectDescendants("book", "", False)

        ' Select all book nodes that have the matching attribute value.
        Dim expr As XPathExpression = navigator.Compile("book[@genre='novel']")
        While nodes.MoveNext()
            Dim navigator2 As XPathNavigator = nodes.Current.Clone()
            If navigator2.Matches(expr) Then
                navigator2.MoveToFirstChild()
                Console.WriteLine("Book title:  {0}", navigator2.Value)
            End If
        End While
        '</snippet24>

    End Sub
#End Region

#Region "MoveToFollowing"
    Shared Sub XPathNavigatorMethods_MoveToFollowing1()

        '<snippet25>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing(XPathNodeType.Element)

        Console.WriteLine("Position: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
        '</snippet25>

    End Sub

    Shared Sub XPathNavigatorMethods_MoveToFollowing2()

        '<snippet26>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing("price", "http://www.contoso.com/books")

        Console.WriteLine("Position: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
        '</snippet26>

    End Sub

    Shared Sub XPathNavigatorMethods_MoveToFollowing3()

        '<snippet27>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing("price", "http://www.contoso.com/books")
        Dim boundary As XPathNavigator = navigator.Clone()

        navigator.MoveToRoot()

        While navigator.MoveToFollowing(XPathNodeType.Text, boundary)
            Console.WriteLine(navigator.OuterXml)
        End While
        '</snippet27>

    End Sub

    Shared Sub XPathNavigatorMethods_MoveToFollowing4()

        '<snippet28>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToFollowing("book", "http://www.contoso.com/books")
        Dim boundary As XPathNavigator = navigator.Clone()
        boundary.MoveToFollowing("first-name", "http://www.contoso.com/books")

        navigator.MoveToFollowing("price", "http://www.contoso.com/books", boundary)

        Console.WriteLine("Position (after boundary): {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)

        navigator.MoveToFollowing("title", "http://www.contoso.com/books", boundary)

        Console.WriteLine("Position (before boundary): {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
        '</snippet28>

    End Sub
#End Region

#Region "MoveToNext"


    '<snippet29>
    Shared Sub XPathNavigatorMethods_MoveToNext()

        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()
        Dim nodeset As XPathNodeIterator = navigator.Select("descendant::book[author/last-name='Melville']")

        While nodeset.MoveNext()
            ' Clone iterator here when working with it.
            RecursiveWalk(nodeset.Current.Clone())
        End While

    End Sub

    Shared Sub RecursiveWalk(ByVal navigator As XPathNavigator)

        Select Case navigator.NodeType
            Case XPathNodeType.Element
                If navigator.Prefix = String.Empty Then
                    Console.WriteLine("<{0}>", navigator.LocalName)
                Else
                    Console.Write("<{0}:{1}>", navigator.Prefix, navigator.LocalName)
                    Console.WriteLine(vbTab + navigator.NamespaceURI)
                End If
            Case XPathNodeType.Text
                Console.WriteLine(vbTab + navigator.Value)
        End Select

        If navigator.MoveToFirstChild() Then
            Do
                RecursiveWalk(navigator)
            Loop While (navigator.MoveToNext())

            navigator.MoveToParent()
            If (navigator.NodeType = XPathNodeType.Element) Then
                Console.WriteLine("</{0}>", navigator.Name)
            End If
        Else
            If navigator.NodeType = XPathNodeType.Element Then
                Console.WriteLine("</{0}>", navigator.Name)
            End If
        End If

    End Sub
    '</snippet29>

#End Region

#Region "PrependChild"

    Shared Sub PrependChild1()

        '<snippet30>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim pages As XmlWriter = navigator.PrependChild()
        pages.WriteElementString("pages", "100")
        pages.Close()

        Console.WriteLine(navigator.OuterXml)
        '</snippet30>

    End Sub

    Shared Sub PrependChild2()

        '<snippet31>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        navigator.PrependChild("<pages>100</pages>")

        Console.WriteLine(navigator.OuterXml)
        '</snippet31>

    End Sub

    Shared Sub PrependChild3()

        '<snippet32>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim pages As XmlReader = XmlReader.Create(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))

        navigator.PrependChild(pages)

        Console.WriteLine(navigator.OuterXml)
        '</snippet32>

    End Sub

    Shared Sub PrependChild4()

        '<snippet33>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim childNodes As XmlDocument = New XmlDocument()
        childNodes.Load(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))
        Dim childNodesNavigator As XPathNavigator = childNodes.CreateNavigator()

        navigator.PrependChild(childNodesNavigator)

        Console.WriteLine(navigator.OuterXml)
        '</snippet33>

    End Sub

    Shared Sub XPathNavigatorMethods_PrependChildElement()

        '<snippet34>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        navigator.PrependChildElement(navigator.Prefix, "pages", navigator.LookupNamespace(navigator.Prefix), "100")

        Console.WriteLine(navigator.OuterXml)
        '</snippet34>

    End Sub

#End Region

#Region "ReadSubTree"
    Shared Sub XPathNavigatorMethods_ReadSubtree()

        '<snippet35>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim reader As XmlReader = navigator.ReadSubtree()

        While reader.Read()
            Console.WriteLine(reader.ReadInnerXml())
        End While

        reader.Close()
        '</snippet35>

    End Sub
#End Region

#Region "ReplaceRange"
    Shared Sub XPathNavigatorMethods_ReplaceRange()
        ' XPathNavigator.ReplaceRange()

        '<snippet53>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(document.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim first As XPathNavigator = navigator.SelectSingleNode("/bk:bookstore/bk:book[1]", manager)
        Dim last As XPathNavigator = navigator.SelectSingleNode("/bk:bookstore/bk:book[2]", manager)

        navigator.MoveTo(first)
        Dim newRange As XmlWriter = navigator.ReplaceRange(last)
        newRange.WriteStartElement("book")
        newRange.WriteAttributeString("genre", "")
        newRange.WriteAttributeString("publicationdate", "2005-04-07")
        newRange.WriteAttributeString("ISBN", "0")
        newRange.WriteStartElement("title")
        newRange.WriteString("New Book")
        newRange.WriteEndElement()
        newRange.WriteStartElement("author")
        newRange.WriteStartElement("first-name")
        newRange.WriteString("First Name")
        newRange.WriteEndElement()
        newRange.WriteStartElement("last-name")
        newRange.WriteString("Last Name")
        newRange.WriteEndElement()
        newRange.WriteEndElement()
        newRange.WriteElementString("price", "$0.00")
        newRange.WriteEndElement()
        newRange.Close()
        Console.WriteLine(navigator.OuterXml)
        '</snippet53>
    End Sub
#End Region

#Region "ReplaceSelf"
    Shared Sub XPathNavigatorMethods_ReplaceSelf1()

        '<snippet36>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        navigator.ReplaceSelf("<pages>100</pages>")

        Console.WriteLine("Position after delete: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
        '</snippet36>

    End Sub

    Shared Sub XPathNavigatorMethods_ReplaceSelf2()

        '<snippet37>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim pages As XmlReader = XmlReader.Create(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))

        navigator.ReplaceSelf(pages)

        Console.WriteLine("Position after delete: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
        '</snippet37>

    End Sub

    Shared Sub XPathNavigatorMethods_ReplaceSelf3()

        '<snippet38>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim childNodes As XmlDocument = New XmlDocument()
        childNodes.Load(New StringReader("<pages xmlns='http://www.contoso.com/books'>100</pages>"))
        Dim childNodesNavigator As XPathNavigator = childNodes.CreateNavigator()

        navigator.ReplaceSelf(childNodesNavigator)

        Console.WriteLine("Position after delete: {0}", navigator.Name)
        Console.WriteLine(navigator.OuterXml)
        '</snippet38>

    End Sub
#End Region

#Region "Select"
    Shared Sub XPathNavigatorMethods_Select1()

        '<snippet39>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim nodes As XPathNodeIterator = navigator.Select("/bookstore/book")
        nodes.MoveNext()
        Dim nodesNavigator As XPathNavigator = nodes.Current

        Dim nodesText As XPathNodeIterator = nodesNavigator.SelectDescendants(XPathNodeType.Text, False)

        While nodesText.MoveNext()
            Console.WriteLine(nodesText.Current.Value)
        End While
        '</snippet39>

    End Sub

    Shared Sub Select2()

        '<snippet40>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim query As XPathExpression = navigator.Compile("/bookstore/book")
        Dim nodes As XPathNodeIterator = navigator.Select(query)
        Dim nodesNavigator As XPathNavigator = nodes.Current

        Dim nodesText As XPathNodeIterator = nodesNavigator.SelectDescendants(XPathNodeType.Text, False)

        While nodesText.MoveNext()
            Console.WriteLine(nodesText.Current.Value)
        End While
        '</snippet40>

    End Sub

    Shared Sub Select3()

        '<snippet41>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim nodes As XPathNodeIterator = navigator.Select("/bk:bookstore/bk:book/bk:price", manager)
        ' Move to the first node bk:price node.
        If (nodes.MoveNext()) Then
            ' Now nodes.Current points to the first selected node.
            Dim nodesNavigator As XPathNavigator = nodes.Current

            ' Select all the descendants of the current price node.
            Dim nodesText As XPathNodeIterator = nodesNavigator.SelectDescendants(XPathNodeType.Text, False)

            While nodesText.MoveNext()
                Console.WriteLine(nodesText.Current.Value)
            End While
        End If
        '</snippet41>

    End Sub
#End Region

#Region "SelectAncestors/Children/Descendants"
    Shared Sub XPathNavigatorMethods_SelectAncestorsChildrenDescendants()

        '<snippet42>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        ' Select all the descendant nodes of the book node.
        Dim bookDescendants As XPathNodeIterator = navigator.SelectDescendants("", "http://www.contoso.com/books", False)

        ' Display the LocalName of each descendant node.
        Console.WriteLine("Descendant nodes of the book node:")
        While bookDescendants.MoveNext()
            Console.WriteLine(bookDescendants.Current.Name)
        End While

        ' Select all the child nodes of the book node.
        Dim bookChildren As XPathNodeIterator = navigator.SelectChildren("", "http://www.contoso.com/books")

        ' Display the LocalName of each child node.
        Console.WriteLine(vbCrLf & "Child nodes of the book node:")
        While bookChildren.MoveNext()
            Console.WriteLine(bookChildren.Current.Name)
        End While

        ' Select all the ancestor nodes of the title node.
        navigator.MoveToChild("title", "http://www.contoso.com/books")

        Dim bookAncestors As XPathNodeIterator = navigator.SelectAncestors("", "http://www.contoso.com/books", False)

        ' Display the LocalName of each ancestor node.
        Console.WriteLine(vbCrLf & "Ancestor nodes of the title node:")

        While bookAncestors.MoveNext()
            Console.WriteLine(bookAncestors.Current.Name)
        End While
        '</snippet42>

    End Sub
#End Region

#Region "SelectSingleNode"
    Shared Sub XPathNavigatorMethods_SelectSingleNode1()

        '<snippet43>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim node As XPathNavigator = navigator.SelectSingleNode("//title")
        Console.WriteLine(node.InnerXml)
        '</snippet43>

    End Sub

    Shared Sub XPathNavigatorMethods_SelectSingleNode2()

        '<snippet44>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim query As XPathExpression = navigator.Compile("//title")

        Dim node As XPathNavigator = navigator.SelectSingleNode(query)
        Console.WriteLine(node.InnerXml)
        '</snippet44>

    End Sub

    Shared Sub XPathNavigatorMethods_SelectSingleNode3()

        '<snippet45>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        Dim node As XPathNavigator = navigator.SelectSingleNode("//bk:title", manager)
        Console.WriteLine(node.InnerXml)
        '</snippet45>

    End Sub
#End Region

#Region "SetTyped/Value"
    Shared Sub XPathNavigatorMethods_SetTypedValue()

        '<snippet46>
        Dim settings As XmlReaderSettings = New XmlReaderSettings()
        settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd")
        settings.ValidationType = ValidationType.Schema

        Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml", settings)
        Dim document As XmlDocument = New XmlDocument()
        document.Load(reader)

        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        Dim price As New Decimal(19.99)
        navigator.SetTypedValue(price)

        navigator.MoveToParent()
        Console.WriteLine(navigator.OuterXml)
        '</snippet46>

    End Sub

    Shared Sub XPathNavigatorMethods_SetValue()

        '<snippet47>
        Dim document As XmlDocument = New XmlDocument()
        document.Load("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        Dim manager As XmlNamespaceManager = New XmlNamespaceManager(navigator.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        For Each nav As XPathNavigator In navigator.Select("//bk:price", manager)
            If nav.Value = "11.99" Then
                nav.SetValue("12.99")
            End If
        Next

        Console.WriteLine(navigator.OuterXml)
        '</snippet47>

    End Sub
#End Region

#Region "WriteSubtree"
    Shared Sub XPathNavigatorMethods_WriteSubtree()

        '<snippet48>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Dim writer As XmlWriter = XmlWriter.Create("contosoBook.xml")
        navigator.WriteSubtree(writer)

        writer.Close()
        '</snippet48>

    End Sub
#End Region

#Region "MoveToNextAttribute"
    Shared Sub XPathNavigatorMethods_MoveToNextAttribute()

        '<snippet49>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Select all book nodes and display all attributes on each book.
        Dim nodes As XPathNodeIterator = navigator.SelectDescendants("book", "", False)
        While nodes.MoveNext()
            Dim navigator2 As XPathNavigator = nodes.Current.Clone()
            navigator2.MoveToFirstAttribute()
            Console.WriteLine("{0} = {1}", navigator2.Name, navigator2.Value)

            While navigator2.MoveToNextAttribute()
                Console.WriteLine("{0} = {1}", navigator2.Name, navigator2.Value)
            End While

            Console.WriteLine()
        End While
        '</snippet49>

    End Sub
#End Region

#Region "MoveToFirst"

    Shared Sub XPathNavigatorMethods_MoveToFirst()

        '<snippet50>
        ' Create an XmlDocument instance and load
        ' the XML document.
        Dim document As New XmlDocument()
        document.Load("contosoBooks.xml")

        ' Create the XPathNavigator instance used to 
        ' navigate the XML document.
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Create an XmlNamespaceManager instance used to 
        ' handle namespaces in the XML document.
        Dim manager As New XmlNamespaceManager(document.NameTable)
        manager.AddNamespace("books", "http://www.contoso.com/books")

        ' Use the SelectSingleNode method and the XPath expression
        ' specified to select the last book node in the XML document.
        navigator = navigator.SelectSingleNode("//books:book[last()]", manager)
        Console.WriteLine("Last node: " & vbCrLf & "{0}", navigator.OuterXml)

        ' Use the MoveToFirst method to position the
        ' XPathNavigator on the first sibling book 
        ' node in the XML document.
        navigator.MoveToFirst()
        Console.WriteLine(vbCrLf & "First node: " & vbCrLf & "{0}", navigator.OuterXml)
        '</snippet50>
    End Sub

#End Region

#Region "BasicMoveTos"
    Shared Sub XPathNavigatorMethods_BasicMoveTos()

        '<snippet54>
        ' Load the XML document.
        Dim document As New XmlDocument()
        document.Load("contosoBooks.xml")

        ' Create the XPathNavigator.
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' Create an XmlNamespaceManager used to handle namespaces
        ' found in the XML document.
        Dim manager As New XmlNamespaceManager(document.NameTable)
        manager.AddNamespace("bk", "http://www.contoso.com/books")

        ' Move to the last book node using the SelectSingleNode method.
        navigator = navigator.SelectSingleNode("//bk:book[last()]", manager)
        Console.WriteLine("Last book node: " & vbCrLf & "===============" _
            & vbCrLf & "{0}", navigator.OuterXml)

        ' Move to the previous book node and write it to the console 
        ' if the move was successful.
        If navigator.MoveToPrevious() Then
            Console.WriteLine(vbCrLf & "Second book node: " & vbCrLf & _
                "=================" & vbCrLf & "{0}", navigator.OuterXml)
        End If

        ' Move to the first book node and write it to the console 
        ' if the move was successful.
        If navigator.MoveToFirst() Then
            Console.WriteLine(vbCrLf & "First book node: " & vbCrLf & _
                "================" & vbCrLf & "{0}", navigator.OuterXml)
        End If

        ' Move to the parent bookstore node and write it to the console 
        ' if the move was successful.
        If navigator.MoveToParent() Then
            Console.WriteLine(vbCrLf & "Parent bookstore node: " & vbCrLf & _
                "======================" & vbCrLf & "{0}", navigator.OuterXml)
        End If

        ' Move to the first child node of the bookstore node and write
        ' it to the console if the move was successful.
        If navigator.MoveToFirstChild() Then
            Console.WriteLine(vbCrLf & "First book node: " & vbCrLf & "================" _
                & vbCrLf & "{0}", navigator.OuterXml)
        End If

        ' Move to the root node and write it to the console.
        navigator.MoveToRoot()
        Console.WriteLine(vbCrLf & "Root node: " & vbCrLf & "==========" & vbCrLf & "{0}", _
                navigator.OuterXml)
        '</snippet54>
        Console.ReadLine()
    End Sub
#End Region

#Region "TwoWaysToIterateOverXPathNavigator"
    Shared Sub XPathNavigatorMethods_TwoWaysToIterateOverXPathNavigator()
        Dim doc As XPathDocument = New XPathDocument(New StringReader("<A><B/></A>"))
        Dim nav As XPathNavigator = doc.CreateNavigator()
        Dim nodeIterator As XPathNodeIterator = nav.SelectDescendants("", "", False)

        '<snippet55>
        While nodeIterator.MoveNext()
            Dim n As XPathNavigator = nodeIterator.Current
            Console.WriteLine(n.LocalName)
        End While
        '</snippet55>

        '<snippet56>
        For Each n As XPathNavigator In nodeIterator
            Console.WriteLine(nav.LocalName)
        Next
        '</snippet56>
    End Sub
#End Region

End Class

