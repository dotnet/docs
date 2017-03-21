<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Web.Services.Protocols" %>

<html>

    <script runat="server">

        void EnterBtn_Click(Object Src, EventArgs E) 
	{
	  // Create a new instance of a proxy class for your XML Web service.
	  ServerUsage su = new ServerUsage();
            
          // Specifies that SOAP 1.2 is used communicate with the XML Web service.
         su.SoapVersion = SoapProtocolVersion.Soap12;

	  // Invoke an XML Web service method that uses session state and thus cookies.
	  int count = su.PerSessionServiceUsage();         
       }
         
    </script>
    <body>
       <form runat=server ID="Form1">
           
             Click to bump up the Session Counter.
             <p>
             <asp:button text="Bump Up Counter" Onclick="EnterBtn_Click" runat=server ID="Button1" NAME="Button1"/>
             <p>
             <asp:label id="SessionCount"  runat=server/>
          
       </form>
    </body>
</html>