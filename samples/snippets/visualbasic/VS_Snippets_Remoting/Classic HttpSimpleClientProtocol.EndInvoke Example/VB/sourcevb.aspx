<!-- <Snippet1> -->
<%@ Page Language="VB" %>
<html>
    <script language="VB" runat="server">
    Sub EnterBtn_Click(Src As Object, E As EventArgs)
        Dim math As New MyMath.Math()
        
        ' Call to Add XML Web service method asynchronously.
        Dim result As IAsyncResult = math.BeginAdd(Convert.ToInt32(Num1.Text), Convert.ToInt32(Num2.Text), Nothing, Nothing)
        
        ' Wait for the asynchronous call to complete.
        result.AsyncWaitHandle.WaitOne()
        
        ' Complete the asynchronous call to the Add XML Web service method.
        Dim iTotal As Integer = math.EndAdd(result)
        
        Total.Text = "Total: " & iTotal.ToString()
    End Sub 'EnterBtn_Click
 
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
<!-- </Snippet1> -->

