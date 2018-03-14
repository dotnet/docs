Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

' <Snippet1>
Public Class MyUser
    Inherits System.Web.Services.Protocols.HttpGetClientProtocol
    
    Public Sub New()
        Me.Url = "http://www.contoso.com/username.asmx"
    End Sub 'New
    
    <HttpMethodAttribute(GetType(XmlReturnReader), GetType(UrlParameterWriter))> _
    Public Function GetUserName() As UserName
        Return CType(Me.Invoke("GetUserName", Me.Url + "/GetUserName", New Object(0) {}), UserName)
    End Function 'GetUserName
    
    Public Function BeginGetUserName(callback As System.AsyncCallback, asyncState As Object) As System.IAsyncResult
        Return Me.BeginInvoke("GetUserName", Me.Url + "/GetUserName", New Object(0) {}, callback, asyncState)
    End Function 'BeginGetUserName
    
    Public Function EndGetUserName(asyncResult As System.IAsyncResult) As UserName
        Return CType(Me.EndInvoke(asyncResult), UserName)
    End Function 'EndGetUserName
End Class 'MyUser

<XmlRootAttribute(Namespace := "http://tempuri.org/", IsNullable := True)> _
Public Class UserName
    Public Name As String
    Public Domain As String

End Class 'UserName
' </Snippet1>
