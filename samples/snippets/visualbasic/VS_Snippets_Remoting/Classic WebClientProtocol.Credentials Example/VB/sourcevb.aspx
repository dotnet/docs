<%@ Import Namespace="MyMath" %>
<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Net" %>

<html>
    <script language="VB" runat="server">
        Sub EnterBtn_Click(src As Object, e As EventArgs)
            Dim math As New MyMath.Math()

            ' Obtain password from a secure store.
            Dim SecurelyStoredPassword As String = String.Empty
            
            ' Set the client-side credentials using the Credentials property.
            Dim credentials = New NetworkCredential("Joe", SecurelyStoredPassword, "mydomain")
            math.Credentials = credentials
            
            Dim iTotal As Integer = math.Add(Convert.ToInt32(Num1.Text), Convert.ToInt32(Num2.Text))
            Total.Text = "Total: " + iTotal.ToString()
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
