<%@ Page Language="C#" debug=true%>
<%@ Import Namespace="System.Web.Services.Protocols" %>
<%@ Import Namespace="System.Security.Cryptography.X509Certificates" %>

<script runat="server">
  public void Page_Load() {

//<Snippet1>
    // Create a new instance of a proxy class for the Bank XML Web service.
    BankSession bank = new BankSession();

    // Load the client certificate from a file.
    X509Certificate x509 = X509Certificate.CreateFromCertFile(@"c:\user.cer");

    // Add the client certificate to the ClientCertificates property of the proxy class.
    bank.ClientCertificates.Add(x509);

    // Communicate with the Deposit XML Web service method,
    // which requires authentication using client certificates.
    bank.Deposit(500);
//</Snippet1>	
  }
</script>
<!-- The following code is used as a stand-in for compilation purposes.  Please
	 see the associated .asmx file for the real code. To run the code above in 
	 a full environment, comment out the code below. -->
<script language="C#" runat=server>
public class BankSession : HttpWebClientProtocol
{
  public void Deposit(int Amount) {
  }
}
</script>