Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Web

Public Class Snippets
    Public Shared Function GetObject() As Object
        Return New Object()
    End Function

    Public Shared Sub Snippet1()
        '<Snippet1>
        Dim baseAddresses() As Uri = {New Uri("http://localhost/one"), New Uri("http://localhost/two")}
        Dim mySingleton As Object = GetObject()
        Dim host As WebServiceHost = New WebServiceHost(mySingleton, baseAddresses)
        '</Snippet1>
    End Sub

    Public Shared Sub Snippet2()
        '<Snippet2>
        Dim baseAddresses() As Uri = {New Uri("http://localhost/one"), New Uri("http://localhost/two")}
        Dim host As WebServiceHost = New WebServiceHost(GetType(CalcService), baseAddresses)
        '</Snippet2>
    End Sub
End Class
