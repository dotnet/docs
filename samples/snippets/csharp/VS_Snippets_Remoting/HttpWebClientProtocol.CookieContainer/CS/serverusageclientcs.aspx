<!-- The following import statements support the standin below -->
<%@ Import Namespace="System.Web.Services" %>
<%@ Import Namespace="System.Web.Services.Protocols" %>
<!--<Snippet1> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Net" %>

<html>

    <script runat="server">

        void EnterBtn_Click(Object Src, EventArgs E) 
	{
	  // Create a new instance of a proxy class for your XML Web service.
	  ServerUsage su = new ServerUsage();
          CookieContainer cookieJar;

	  // Check to see if the cookies have already been saved for this session.
	  if (Session["CookieJar"] == null) 
	    cookieJar= new CookieContainer();
          else
	   cookieJar = (CookieContainer) Session["CookieJar"];

		// Assign the CookieContainer to the proxy class.
		su.CookieContainer = cookieJar;

	  // Invoke an XML Web service method that uses session state and thus cookies.
	  int count = su.PerSessionServiceUsage();         

	  // Store the cookies received in the session state for future retrieval by this session.
	  Session["CookieJar"] = cookieJar;

          // Populate the text box with the results from the call to the XML Web service method.
          SessionCount.Text = count.ToString();  
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
<!--</Snippet1> -->

<!-- The following code is used as a stand-in for compilation purposes.  Please
	 see the associated .asmx file for the real code. To run the code above in 
	 a full environment, comment out the code below. -->
<script language="C#" runat=server>
public class ServerUsage : HttpWebClientProtocol
{
     public int ServiceUsage() {
	  return  1;
     }

     public int PerSessionServiceUsage() {
	  return  1;
     }
   
}
</script>