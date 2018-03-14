<%@ Page Language="VB" debug=true%>
<%@ Import Namespace="System.Web.Services.Protocols" %>
<%@ Import Namespace="System.Security.Cryptography.X509Certificates" %>

<script runat="server">
  Public Sub Page_Load() 

'<Snippet1>
    ' Create a new instance of a proxy class for the Bank XML Web service.
    Dim bank As BankSession = new BankSession()

    ' Load the client certificate from a file.
    Dim x509 As X509Certificate = X509Certificate.CreateFromCertFile("c:\user.cer")

    ' Add the client certificate to the ClientCertificates property of the proxy class.
    bank.ClientCertificates.Add(x509)

    ' Communicate with the Deposit XML Web service method,
    ' which requires authentication using client certificates.
    bank.Deposit(500)
'</Snippet1>	
  End Sub
</script>

<!-- The following code is used as a stand-in for compilation purposes.  Please
	 see the associated .asmx file for the real code. To run the code above in 
	 a full environment, comment out the code below. -->
<script language="VB" runat=server>
Public Class BankSession
  Inherits HttpWebClientProtocol
  
  Public Sub Deposit(Amount As Integer) 
  End Sub 

End Class
</script>