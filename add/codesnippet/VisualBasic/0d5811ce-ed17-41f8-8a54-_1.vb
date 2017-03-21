   
   ' Set the declarative security for the URI.
   <WebPermission(SecurityAction.Deny, Connect := "http://www.contoso.com/")> _
   Public Sub Connect()
      ' Throw an exception.	 
      Try
         Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
      Catch e As Exception
         Console.WriteLine(("Exception : " + e.ToString()))
      End Try
   End Sub 'Connect
 