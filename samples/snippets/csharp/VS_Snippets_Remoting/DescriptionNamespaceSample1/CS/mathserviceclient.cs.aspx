<html>
   <script language="C#" runat="server">

  int myOperand1 = 0;
  int myOperand2 = 0;

  public void Submit_Click(Object sender, EventArgs E)
  {
      try 
      {
        myOperand1 = Int32.Parse(Operand1.Text);
        myOperand2 = Int32.Parse(Operand2.Text);
      }
      catch (Exception) { /* ignored */ }

         MyMath.Math service = new MyMath.Math();

        switch (((Control)sender).ID)
        {
          case "Add"      : Result.Text = "<b>Result</b> = " + service.Add(myOperand1, myOperand2).ToString(); break;
          case "Subtract" : Result.Text = "<b>Result</b> = " + service.Subtract(myOperand1, myOperand2).ToString(); break;
          case "Divide"   : Result.Text = "<b>Result</b> = " + service.Divide(myOperand1, myOperand2).ToString(); break;
        }
  }


   </script>
   <body style="font: 10pt verdana">
      <h4>
         Using a Simple Math Service
      </h4>
      <form runat="server">
         <div style="padding:15,15,15,15;background-color:beige;width:300;border-color:black;border-width:1;border-style:solid">
            Operand 1:
            <br>
            <asp:TextBox id="Operand1" Text="15" runat="server" />
            <br>
            Operand 2:
            <br>
            <asp:TextBox id="Operand2" Text="5" runat="server" />
            <p>
               <input type="submit" id="Add" value="Add" OnServerClick="Submit_Click" runat="server">
               <input type="submit" id="Subtract" value="Subtract" OnServerClick="Submit_Click" runat="server">
               <input type="submit" id="Divide" value="Divide" OnServerClick="Submit_Click" runat="server">
            <p>
               <asp:Label id="Result" runat="server" />
         </div>
      </form>
   </body>
</html>
