Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.Syndication
Imports System.Xml

Public Class Snippets
    Public Shared Sub Snippet2()
        '<Snippet2>
        Dim person As SyndicationPerson = New SyndicationPerson("lene@company.com")
        '</Snippet2>

        '<Snippet3>
        Dim person2 As SyndicationPerson = New SyndicationPerson("lene@company.com", "Lene Aalling", "http://lene/Aalling")
        '</Snippet3>
    End Sub

    Public Shared Sub Snippet8()
        '  <Snippet8>
        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)
        Dim sp As New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg")
        feed.Authors.Add(sp)
        '  </Snippet8>
    End Sub

    Public Shared Sub Snippet9()
        '  <Snippet9>
        Dim sp As New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg")
        sp.AttributeExtensions.Add(New XmlQualifiedName("myAttribute", ""), "someValue")
        '  </Snippet9>
    End Sub

    Public Shared Sub Snippet10()
        '  <Snippet10>
        Dim sp As New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg")
        sp.ElementExtensions.Add("simpleString", "", "hello, world!")
        '  </Snippet10>
    End Sub

    Public Shared Sub Snippet11()
        '  <Snippet11>
        Dim sp As New SyndicationPerson()
        sp.Email = "jesper@contoso.com"
        '  </Snippet11>
    End Sub

    Public Shared Sub Snippet12()
        '  <Snippet12>
        Dim sp As New SyndicationPerson()
        sp.Name = "Jesper Aaberg"
        '  </Snippet12>
    End Sub

    Public Shared Sub Snippet13()
        '  <Snippet13>
        Dim sp As New SyndicationPerson()
        sp.Uri = "http://Jesper/Aaberg"
        '  </Snippet13>
    End Sub

    Public Shared Sub Snippet14()
        '  <Snippet14>
        Dim sp As New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http:' Jesper/Aaberg")
        Dim copy As SyndicationPerson = sp.Clone()
        '  </Snippet14>
    End Sub

End Class
