<!--<Snippet1>-->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Net" %>

<html>
    <script language="C#" runat="server">
       void EnterBtn_Click(Object Src, EventArgs E) 
          {
             MyMath.Math math = new MyMath.Math();

             // Allow the server to redirect the request.
             math.AllowAutoRedirect = true;

             // Set the client-side credentials using the Credentials property.
             ICredentials credentials =
                new NetworkCredential("Joe","password","mydomain");
             math.Credentials = credentials;

             // Set the proxy server to proxyserver, set the port to 80, and specify to bypass
             // the proxy server for local addresses.
             IWebProxy proxyObject = new WebProxy("http://proxyserver:80",true);
             math.Proxy = proxyObject;

             // Set the encoding to utf-8.
             math.RequestEncoding = System.Text.Encoding.UTF8;

             // Set the time out to 15 seconds
             math.Timeout = 15000;

             int total = math.Add(Convert.ToInt32(Num1.Text),
                Convert.ToInt32(Num2.Text));
             Total.Text = "Total: " + total.ToString();
         }
 
    </script>
 
    <body>
       <form action="MathClient.aspx" runat=server>
           
          Enter the two numbers you want to add and then press the Total button.
          <p>
          Number 1: <asp:textbox id="Num1" runat=server/>  +
          Number 2: <asp:textbox id="Num2" runat=server/> =
          <asp:button text="Total" Onclick="EnterBtn_Click" runat=server/>
          <p>
          <asp:label id="Total"  runat=server/>
          
       </form>
    </body>
 </html>
   
<!--</Snippet1>-->
