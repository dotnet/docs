<!--<Snippet1>-->
<html>
    <script language="VB" runat="server">
        Sub EnterBtn_Click(Src As Object, E As EventArgs)
            Dim math As New MyMath.Math()
            
            ' Set the Content Type to UTF-8.
            math.RequestEncoding = System.Text.Encoding.UTF8
            
            Dim iTotal As Integer = math.Add(Convert.ToInt32(Num1.Text), Convert.ToInt32(Num2.Text))
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
