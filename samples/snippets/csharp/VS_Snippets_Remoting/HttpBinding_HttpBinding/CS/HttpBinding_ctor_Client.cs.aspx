<html>
   <script language="C#" runat="server">

  public void Submit_Click(Object sender, EventArgs E)
  {
  try
  {
     MyHttpBindingService myService = new MyHttpBindingService();
     Response.Write("<b>The output is :"+myService.AddNumbers(Int32.Parse(Operand1.Text),Int32.Parse(Operand2.Text))+"</b>");
  }
  catch (Exception ex)
  {
     Response.Write("The error message is :" + ex.Message);
  }
  }

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
