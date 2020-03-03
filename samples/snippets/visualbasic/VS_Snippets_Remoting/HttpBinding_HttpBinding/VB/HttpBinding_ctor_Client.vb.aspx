<html>
   <script language="VB" runat="server">

Public Sub Submit_Click(sender As Object, E As EventArgs)
   Try
    Dim myService As New MyHttpBindingService()
    Response.Write _
     ("<b>The output is :" + myService.AddNumbers(Operand1.Text, Operand2.Text).ToString() + "</b>")
   Catch ex As Exception
      Response.Write("The error message is :" + ex.Message)
   End Try
End Sub 'Submit_Click
   </script>
   <body>
      <form runat="server" ID="Form1">
         <b>Adding Two Numbers
            <br>
         </b>Enter the First Integer
         <asp:TextBox id="Operand1" runat="server" />
         <br>
         Enter the Second Integer
         <asp:TextBox id="Operand2" runat="server" />
         <br>
         <input type="submit" id="Add" value="Add" OnServerClick="Submit_Click" runat="server" NAME="Add">
      </form>
   </body>
</html>
