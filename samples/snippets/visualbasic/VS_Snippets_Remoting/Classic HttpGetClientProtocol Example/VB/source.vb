'<Snippet1>
Option Strict On
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization


Public Class MyMath
    Inherits System.Web.Services.Protocols.HttpGetClientProtocol
    
    <System.Diagnostics.DebuggerStepThroughAttribute()>  _
    Public Sub New()
        MyBase.New
        Me.Url = "http://www.contoso.com/math.asmx"
    End Sub
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.Web.Services.Protocols.HttpMethodAttribute(GetType(System.Web.Services.Protocols.XmlReturnReader), GetType(System.Web.Services.Protocols.UrlParameterWriter))>  _
    Public Function Add(ByVal num1 As String, ByVal num2 As String) As <System.Xml.Serialization.XmlRootAttribute("int", [Namespace]:="http://www.contoso.com/", IsNullable:=false)> Integer
        Return CType(Me.Invoke("Add", (Me.Url + "/Add"), New Object() {num1, num2}),Integer)
    End Function
    
    <System.Diagnostics.DebuggerStepThroughAttribute()>  _
    Public Function BeginAdd(ByVal num1 As String, ByVal num2 As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
        Return Me.BeginInvoke("Add", (Me.Url + "/Add"), New Object() {num1, num2}, callback, asyncState)
    End Function
    
    <System.Diagnostics.DebuggerStepThroughAttribute()>  _
    Public Function EndAdd(ByVal asyncResult As System.IAsyncResult) As Integer
        Return CType(Me.EndInvoke(asyncResult),Integer)
    End Function
End Class
'</Snippet1>