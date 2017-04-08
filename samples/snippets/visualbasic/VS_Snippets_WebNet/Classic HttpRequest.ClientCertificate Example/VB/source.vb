Imports System
Imports System.Web
Imports System.Web.UI

Public Class Page1: Inherits Page

  Protected Sub Page_Load(sender As Object, e As EventArgs)

    ' <Snippet1>
    Dim cs As HttpClientCertificate = Request.ClientCertificate
 
    Response.Write("<p>Client Certificate settings:</p>")
    Response.Write("Certificate = " & cs.Certificate.ToString() & "<br>")
    Response.Write("Cookie = " & cs.Cookie & "<br>")
    Response.Write("Flags = " & cs.Flags & "<br>")
    Response.Write("IsPresent = " & cs.IsPresent & "<br>")
    Response.Write("Issuer = " & cs.Issuer & "<br>")
    Response.Write("IsValid = " & cs.IsValid & "<br>")
    Response.Write("KeySize = " & cs.KeySize & "<br>")
    Response.Write("SecretKeySize = " & cs.SecretKeySize & "<br>")
    Response.Write("SerialNumber = " & cs.SerialNumber & "<br>")
    Response.Write("ServerIssuer = " & cs.ServerIssuer & "<br>")
    Response.Write("ServerSubject = " & cs.ServerSubject & "<br>")
    Response.Write("Subject = " & cs.Subject & "<br>")
    Response.Write("ValidFrom = " & cs.ValidFrom & "<br>")
    Response.Write("ValidUntil = " & cs.ValidUntil & "<br>")
    Response.Write("What's this = " & cs.ToString() & "<br>")
    
    ' </Snippet1>

 End Sub
End Class
