<%@ Page language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server" id="Script1">

   Sub submitButton_Click(sender As Object, e As EventArgs)
      message.Visible = True
' <Snippet1>
      ' Get 'Validators' of the page to myCollection.
      Dim myCollection As ValidatorCollection = Page.Validators
      Dim myObjArray() As Object = New Object(4){0, 0, 0, 0, 0}
      ' Copy the 'Collection' to 'Array'. 
      myCollection.CopyTo(myObjArray, 0)
      ' Print the values in the Array.
      Dim myStr As String = " "
      Dim i As Integer
      For i = 0 To myCollection.Count - 1
         myStr += myObjArray(i).ToString()
         myStr += " "
      Next i
      msgLabel.Text = myStr
' </Snippet1>
   End Sub 'submitButton_Click 

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
<!--
' System.Web.UI.ValidatorCollection.CopyTo
-->
      <!-- 
     The following program demonstrates the 'CopyTo' method of
     the 'ValidatorCollection' class of 'System.Web.UI'. The 
     Validators of the page are assigned to a variable of 
     'ValidatorCollection' class and then copied to an 'Array'.
-->
   </head>
   <body>
      <form id="Form1" method="post" runat="server">
         <asp:Label id="Label4" runat="server" Height="19px" Width="438px" Font-Size="Medium" Font-Bold="True" 
           style="LEFT: 5px; POSITION: absolute; TOP: 8px">ValidatorCollection Example  </asp:Label>
         <asp:Label id="infoLabel" runat="server" Width="226px" Height="19px" Font-Size="Small" 
           style="LEFT: 15px; POSITION: absolute; TOP: 50px">Enter Personal Information </asp:Label>
         <asp:Label id="Label3" runat="server" ForeColor="Red" style="LEFT: 260px; POSITION: absolute; TOP: 81px">*
         </asp:Label>
         <asp:Label id="nameLabel" runat="server" style="LEFT: 15px; POSITION: absolute; TOP: 82px" 
           AssociatedControlID="userName">Name </asp:Label>
         <asp:TextBox id="userName" runat="server" Width="177px" Height="24px" style="LEFT: 75px; POSITION:
           absolute; TOP: 85px"> </asp:TextBox>
         <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" 
           ControlToValidate="userName" style="LEFT: 287px; POSITION: absolute; TOP: 88px"> Required.
         </asp:RequiredFieldValidator>
         <asp:Label id="Label2"  runat="server" ForeColor="Red" style="LEFT: 265px; POSITION: absolute;
           TOP: 120px">* </asp:Label>
         <asp:Label id="addressLabel" runat="server" style="LEFT: 17px; POSITION: absolute; TOP: 123px"
           AssociatedControlID="addressTextBox">Address</asp:Label>
         <asp:TextBox id="addressTextBox" runat="server" TextMode="MultiLine" style="LEFT: 75px;
           POSITION: absolute;TOP: 123px"> </asp:TextBox>
         <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator"
           ControlToValidate="addressTextBox" style="LEFT: 285px; POSITION: absolute; TOP: 132px"> Required.
         </asp:RequiredFieldValidator>
         <asp:Label id="Label1" runat="server" ForeColor="Red" style="LEFT: 262px; POSITION: absolute; 
           TOP: 175px">* </asp:Label>
         <asp:RequiredFieldValidator  id="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator"
           ControlToValidate="ageTextBox" style="LEFT: 286px; POSITION: absolute; TOP: 175px"> Required.
         </asp:RequiredFieldValidator>
         <asp:TextBox id="ageTextBox" runat="server" Width="181px" Height="24px" style="LEFT: 77px; 
           POSITION: absolute;TOP: 176px"> </asp:TextBox>
         <asp:Label id="ageLabel" runat="server" style="LEFT: 20px; POSITION: absolute; TOP: 178px"
           AssociatedControlID="ageTextBox">Age</asp:Label>
         <asp:RangeValidator id="RangeValidator1" runat="server" ErrorMessage="RangeValidator" 
           ControlToValidate="ageTextBox" MinimumValue="18" MaximumValue="100" Type="Integer" Height="19px"
           Width="181px" style="LEFT: 286px;POSITION: absolute; TOP: 195px"> Valid age(18-100).</asp:RangeValidator>
         <asp:Button id="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" style="LEFT: 121px;
           POSITION: absolute; TOP: 225px"> </asp:Button>
         <asp:Label id="message" style="LEFT: 46px; POSITION: absolute; TOP: 281px" runat="server" Height="19px"
           Width="520px" Visible="False">Validators on this page: </asp:Label>
         <asp:Label  id="msgLabel" runat="server" Height="124px" Width="571px" style="LEFT: 49px; POSITION: absolute;
         TOP: 324px">  </asp:Label>
      </form>
   </body>
</html>
