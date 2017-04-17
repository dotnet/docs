Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.ServiceModel.Syndication
Imports Microsoft.Syndication.Samples
Imports System.Xml.Linq
Imports System.Xml.Serialization
Imports System.Xml

Class Snippets
    Public Shared Sub Snippet1()
        '  <Snippet1>
        Dim feed As New SyndicationFeed()

        ' Add several different types of element extensions.
        feed.ElementExtensions.Add("simpleString", "", "hello, world!")
        feed.ElementExtensions.Add("simpleString", "", "another simple string")

        '  DataContractExtension is a user-defined type marked with the DataContractAttribute
        feed.ElementExtensions.Add(New DataContractExtension With {.Key = "X", .Value = 4})

        '  XmlSerializerExtension is a user-defined type that defines a ToString() method
        feed.ElementExtensions.Add(New XmlSerializerExtension With {.Key = "Y", .Value = 8}, New XmlSerializer(GetType(XmlSerializerExtension)))

        feed.ElementExtensions.Add(New XElement("xElementExtension", _
                                    New XElement("Key", New XAttribute("attr1", "someValue"), "Z"), _
                                    New XElement("Value", New XAttribute("attr1", "someValue"), "15")).CreateReader())
        '  </Snippet1>
    End Sub

    Public Shared Sub Snippet2()
        '  <Snippet2>
        Dim item As New SyndicationItem()

        ' Add several different types of element extensions
        item.ElementExtensions.Add("simpleString", "", "hello, world!")
        item.ElementExtensions.Add("simpleString", "", "another simple string")

        ' DataContractExtension is a user-defined type marked with the DataContractAttribute
        item.ElementExtensions.Add(New DataContractExtension With {.Key = "X", .Value = 4})

        ' XmlSerializerExtension is a user-defined type that defines a ToString() method
        item.ElementExtensions.Add(New XmlSerializerExtension With {.Key = "Y", .Value = 8}, New XmlSerializer(GetType(XmlSerializerExtension)))

        item.ElementExtensions.Add(New XElement("xElementExtension", New XElement("Key", New XAttribute("attr1", "someValue"), "Z"), _
                New XElement("Value", New XAttribute("attr1", "someValue"), "15")).CreateReader())
        '  </Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        ' <Snippet3>
        Dim item As New SyndicationItem()
        item.AttributeExtensions.Add(New XmlQualifiedName("myAttribute", ""), "someValue")
        ' </Snippet3>
    End Sub

    Public Shared Sub Snippet4()
        '  <Snippet4>
        Dim link As New SyndicationLink(New Uri("http://server/link"))
        link.AttributeExtensions.Add(New XmlQualifiedName("myAttribute", ""), "someValue")
        ' </Snippet4>
    End Sub

    Public Shared Sub Snippet5()
        ' <Snippet5>
        Dim link As New SyndicationLink()
        link.ElementExtensions.Add("simpleString", "", "hello, world!")
        ' </Snippet5>
    End Sub
End Class
