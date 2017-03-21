<%@ Page Language="VB" %>
<html>
    <script language="VB" runat="server">
    Sub EnterBtn_Click(Src As Object, E As EventArgs)
        Dim math As New Math()
        Dim result As Integer 

        ' If the user types in a URL, attempt to dynamically bind to it.
        If DiscoURL.Text <> String.Empty Then
           math.Url = DiscoURL.Text

           Try
	     math.Discover()
           Catch except As Exception
	      DiscoURL.Text = "Could not bind to MathSoap bindng at given URL."
           End Try       

        End If 


        ' Call to Add XML Web service method.
        result = math.Add(Convert.ToInt32(Num1.Text),Convert.ToInt32(Num2.Text))
        
        Total.Text = "Total: " & result.ToString()
    End Sub 'EnterBtn_Click
 
  </script>
 
    <body>
       <form action="MathClient.aspx" runat=server>
          
          Enter the URL of a disdovery document describing the MathSoap binding.
          <p> 
          <asp:textbox id="DiscoURL" runat=server Columns=80/>
          <p><p>
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