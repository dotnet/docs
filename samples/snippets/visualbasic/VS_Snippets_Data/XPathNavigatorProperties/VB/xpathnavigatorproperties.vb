Imports System
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Collections
 
Class XPathNavigatorProperties
    Shared Sub Main()

        Console.ReadLine()

    End Sub
 
#Region "CanEdit"
    Shared Sub XPathNavigatorProperties_CanEdit()

        '<snippet1>
        Dim readOnlyDocument As XPathDocument = New XPathDocument("books.xml")
        Dim readOnlyNavigator As XPathNavigator = readOnlyDocument.CreateNavigator()

        Dim editableDocument As XmlDocument = New XmlDocument()
        editableDocument.Load("books.xml")
        Dim editableNavigator As XPathNavigator = editableDocument.CreateNavigator()

        Console.WriteLine("XPathNavigator.CanEdit from XPathDocument: {0}", readOnlyNavigator.CanEdit)
        Console.WriteLine("XPathNavigator.CanEdit from XmlDocument: {0}", editableNavigator.CanEdit)

        '</snippet1>
    End Sub
#End Region
 
#Region "InnerXml"
    Shared Sub XPathNavigatorProperties_InnerXml()

        '<snippet2>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Console.WriteLine(navigator.InnerXml)
        '</snippet2>

    End Sub
#End Region
 
#Region "NavigatorComparer"
    Shared Sub XPathNavigatorProperties_NavigatorComparer()

        '<snippet3>
        Dim document As XPathDocument = New XPathDocument("books.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()
        Dim table As Hashtable = New Hashtable(XPathNavigator.NavigatorComparer)

        ' Add nodes to the Hashtable.
        For Each navigator2 As XPathNavigator In navigator.Select("//book")
            Dim value As Object = navigator2.Evaluate("string(./title)")
            table.Add(navigator2.Clone(), value)
            Console.WriteLine("Added book with title {0}", value)
        Next

        Console.WriteLine(table.Count)
        Console.WriteLine("Does the Hashtable have the book 'The Confidence Man'?")
        Console.WriteLine(table.Contains(navigator.SelectSingleNode("//book[title='The Confidence Man']")))
        '</snippet3>

    End Sub
#End Region
 
#Region "OuterXml"
    Shared Sub XPathNavigatorProperties_OuterXml()

        '<snippet4>
        Dim document As XPathDocument = New XPathDocument("contosoBooks.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")

        Console.WriteLine(navigator.OuterXml)
        '</snippet4>

    End Sub
#End Region
 
#Region "ValueAs"
    Shared Sub XPathNavigatorProperties_ValueAs()

        '<snippet5>
        Dim document As XPathDocument = New XPathDocument("valueas.xml")
        Dim navigator As XPathNavigator = document.CreateNavigator()

        ' ValueAsBoolean
        navigator.MoveToChild("root", "")
        navigator.MoveToChild("booleanElement", "")
        Dim booleanValue As Boolean = navigator.ValueAsBoolean
        Console.WriteLine(navigator.LocalName + ": " + booleanValue)

        ' ValueAsDateTime
        navigator.MoveToNext("dateTimeElement", "")
        Dim dateTimeValue As DateTime = navigator.ValueAsDateTime
        Console.WriteLine(navigator.LocalName + ": " + dateTimeValue)

        ' ValueAsDouble, ValueAsInt32, ValueAsInt64, ValueAsSingle
        navigator.MoveToNext("numberElement", "")
        Dim doubleValue As Double = navigator.ValueAsDouble
        Dim int32Value As Int32 = navigator.ValueAsInt
        Dim int64Value As Int64 = navigator.ValueAsLong
        Console.WriteLine(navigator.LocalName + ": " + doubleValue)
        Console.WriteLine(navigator.LocalName + ": " + int32Value)
        Console.WriteLine(navigator.LocalName + ": " + int64Value)
        '</snippet5>

    End Sub
#End Region
 
#Region "ValueType"
    Shared Sub XPathNavigatorProperties_ValueType()

        '<snippet6>
        ' Create an XmlReaderSettings object with the contosoBooks.xsd schema.
        Dim settings As XmlReaderSettings = New XmlReaderSettings()
        settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd")
        settings.ValidationType = ValidationType.Schema

        ' Create an XmlReader object with the contosoBooks.xml file and its schema.
        Dim reader As XmlReader = XmlReader.Create("contosoBooks.xml", settings)

        Dim document As XPathDocument = New XPathDocument(reader)
        Dim navigator As XPathNavigator = document.CreateNavigator()

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books")
        navigator.MoveToChild("book", "http://www.contoso.com/books")
        navigator.MoveToChild("price", "http://www.contoso.com/books")

        ' Display the current type of the price element.
        Console.WriteLine(navigator.ValueType)

        ' Get the value of the price element as a string and display it.
        Dim price As String = navigator.ValueAs(GetType(String))
        Console.WriteLine(price)
        '</snippet6>

    End Sub
#End Region

End Class

