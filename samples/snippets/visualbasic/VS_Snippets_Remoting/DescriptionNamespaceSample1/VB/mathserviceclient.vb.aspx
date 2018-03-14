<html>
   <script language="Vb" runat="server">

         Dim myOperand1 As Integer = 0
         Dim myOperand2 As Integer = 0

         Public Sub Submit_Click(sender As Object, E As EventArgs)
            Try
               myOperand1 = Int32.Parse(Operand1.Text)
               myOperand2 = Int32.Parse(Operand2.Text)
            Catch e1 as Exception 
            End Try 
            Dim service As New MyMath.Math()
            
            
            Select Case CType(sender, Control).ID
               Case "Add"
                  Result.Text = "<b>Result</b> = " + service.Add(myOperand1, myOperand2).ToString()
               Case "Subtract"
                  Result.Text = "<b>Result</b> = " + service.Subtract(myOperand1, myOperand2).ToString()
               Case "Divide"
                  Result.Text = "<b>Result</b> = " + service.Divide(myOperand1, myOperand2).ToString()
            End Select
         End Sub 'Submit_Click
   </script>
   <body style="font: 10pt verdana">
      <h4>
         Using a Simple Math Service
      </h4>
      <form runat="server">
         <div style="padding:15,15,15,15;background-color:beige;width:300;border-color:black;
                                                         border-width:1;border-style:solid">
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
