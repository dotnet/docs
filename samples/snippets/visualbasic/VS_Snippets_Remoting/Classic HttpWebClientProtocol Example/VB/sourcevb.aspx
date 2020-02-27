<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Net" %>

<html>
    <script language="VB" runat="server">

    Sub EnterBtn_Click(Src As Object, E As EventArgs)
        Dim math As New MyMath.Math()
        
        ' Allow the server to redirect the request.
        math.AllowAutoRedirect = True
        
        ' Set the client-side credentials using the Credentials property.
        Dim credentials = New NetworkCredential("Joe", "password", "mydomain")
        math.Credentials = credentials
        
        ' Set the proxy server to proxyserver, set the port to 80 and specify to bypass
        ' the proxy server for local addresses.
        Dim proxyObject = New WebProxy("http://proxyserver:80", True)
        math.Proxy = proxyObject
        
        ' Set the encoding to utf-8.
        math.RequestEncoding = System.Text.Encoding.UTF8
        
        ' Set the time out to 15 seconds.
        math.Timeout = 15000
        
        Dim iTotal As Integer = math.Add(Convert.ToInt32(Num1.Text), _
           Convert.ToInt32(Num2.Text))
        Total.Text = "Total: " & iTotal.ToString()
    End Sub
 
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
