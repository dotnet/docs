<!--<Snippet1>-->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Image Example</title>
<script language="VB" runat="server">

      Sub Button_Click(sender As Object, e As EventArgs)
         Select Case DropList1.SelectedIndex
            Case 0:
               Image1.ImageAlign = ImageAlign.NotSet
         
            Case 1:
               Image1.ImageAlign = ImageAlign.Left

            Case 2:
               Image1.ImageAlign = ImageAlign.Right

            Case 3:
               Image1.ImageAlign = ImageAlign.Baseline

            Case 4:
               Image1.ImageAlign = ImageAlign.Top

            Case 5:
               Image1.ImageAlign = ImageAlign.Middle

            Case 6:
               Image1.ImageAlign = ImageAlign.Bottom
         
            Case 7:
               Image1.ImageAlign = ImageAlign.AbsBottom

            Case 8:
               Image1.ImageAlign = ImageAlign.AbsMiddle

            Case 9:
               Image1.ImageAlign = ImageAlign.TextTop

            Case Else:
               Image1.ImageAlign = ImageAlign.NotSet

         End Select
      End Sub

   </script>

</head>
 
<body>

   <form id="form1" runat="server">

      <h3>Image Example</h3>

      <div style="font-size:large">

         Text Text Text Text Text Text Text Text Text Text Text Text 
         Text Text Text Text Text Text Text Text Text Text Text Text 
         Text Text Text Text Text Text Text Text Text Text Text Text

      </div> 
 
      <asp:Image id="Image1" runat="server"
           AlternateText="Image text"
           ImageAlign="left"
           ImageUrl="images/image1.jpg"/>

      <hr />
    
      Select Image Align: <br />

      <asp:DropDownList id="DropList1"
           runat="server">

         <asp:ListItem>NotSet</asp:ListItem>
         <asp:ListItem>Left</asp:ListItem>
         <asp:ListItem>Right</asp:ListItem>
         <asp:ListItem>BaseLine</asp:ListItem>
         <asp:ListItem>Top</asp:ListItem>
         <asp:ListItem>Middle</asp:ListItem>
         <asp:ListItem>Bottom</asp:ListItem>
         <asp:ListItem>AbsBottom</asp:ListItem>
         <asp:ListItem>AbsMiddle</asp:ListItem>
         <asp:ListItem>TextTop</asp:ListItem>     

      </asp:DropDownList>

      <br /><br />

      <asp:Button id="Button1"
           Text="Apply Image Alignment"
           OnClick="Button_Click" 
           runat="server"/>
  
   </form>

</body>
</html>
   
<!--</Snippet1>-->
