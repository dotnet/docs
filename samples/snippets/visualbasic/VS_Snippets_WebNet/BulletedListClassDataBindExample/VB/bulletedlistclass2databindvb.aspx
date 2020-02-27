<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>BulletedList Class Data Binding Example</title>
  <script runat="server">

    Sub ProductsBulletedList_Click(ByVal sender As Object, _
                                   ByVal e As System.Web.UI.WebControls.BulletedListEventArgs)
      
      ' Change the message displayed in the label based on the index
      ' of the list item that was clicked.
      Select Case (e.Index)
        Case 0
          Message.Text = "Product 1 was clicked"
        Case 1
          Message.Text = "Product 2 was clicked"
        Case 2
          Message.Text = "Product 3 was clicked"
        Case 3
          Message.Text = "Product 4 was clicked"
        Case Else
          Throw New Exception("You must click a valid list item.")
      End Select

    End Sub

  </script>
    
</head>
<body>

  <h3>BulletedList Class Data Binding Example</h3>

  <form id="form1" runat="server">
            
    <p>Click on an item in the list.</p>

    <asp:BulletedList id="ProductsBulletedList" 
      BulletStyle="Disc"
      DisplayMode="LinkButton"
      DataTextField="ProductName"
      DataSourceID="SqlDataSource1"
      OnClick="ProductsBulletedList_Click"
      runat="server">                    
    </asp:BulletedList>
        
    <asp:SqlDataSource id="SqlDataSource1"          
      ConnectionString="<%$ ConnectionStrings:NorthWindConnection%>"
      runat="server"
      SelectCommand="SELECT * FROM [Products] Where ProductID < 5">
    </asp:SqlDataSource>

    <asp:Label id="Message" 
      Font-Size="12"
      Width="168px" 
      Font-Bold="True" 
      runat="server"/>

   </form>

</body>
</html>
<!--</Snippet1>-->