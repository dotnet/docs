Imports System
Imports System.Xml.Serialization
Imports System.Web.Services.Protocols

' <Snippet2>
Namespace MyMath
    <XmlRootAttribute("int", Namespace := "http://MyMath/", IsNullable := False)> _
    Public Class Math
        Inherits HttpGetClientProtocol
        
        Public Sub New()
            Me.Url = "http://www.contoso.com/math.asmx"
        End Sub 'New
        
        <HttpMethodAttribute(GetType(XmlReturnReader), GetType(UrlParameterWriter))> _
        Public Function Add(num1 As String, num2 As String) As Integer
            Return CInt(Me.Invoke("Add", Me.Url + "/Add", New Object() {num1, num2}))
        End Function 'Add
        
        
        Public Function BeginAdd(num1 As String, num2 As String, callback As AsyncCallback, asyncState As Object) As IAsyncResult
            Return Me.BeginInvoke("Add", Me.Url + "/Add", New Object() {num1, num2}, callback, asyncState)
        End Function 'BeginAdd
        
        
        Public Function EndAdd(asyncResult As IAsyncResult) As Integer
            Return CInt(Me.EndInvoke(asyncResult))
        End Function 'EndAdd
    End Class 'Math 
End Namespace 'MyMath
' </Snippet2>
