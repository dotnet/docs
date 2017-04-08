Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.Syndication


Public Class MySyndicationFeed
    Inherits SyndicationFeed
    Public Sub New()
    End Sub

    Public Sub New(ByVal title As String, ByVal description As String, ByVal feedAltLink As Uri, ByVal id As String, ByVal lastUpdateTime As DateTime)
        MyBase.New(title, description, feedAltLink, id, lastUpdateTime)
    End Sub
End Class
Public Class MySyndicationItem
    Inherits SyndicationItem

    Public Sub New()
    End Sub

    Public Sub New(ByVal title As String, ByVal description As String, ByVal feedAltLink As Uri, ByVal id As String, ByVal lastUpdateTime As DateTime)
        MyBase.New(title, description, feedAltLink, id, lastUpdateTime)
    End Sub

End Class
