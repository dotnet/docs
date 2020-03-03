<!--<Snippet1>-->
<%@ Page Language="VB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>BulletedList Constructor Example</title>
  <script runat="server">

    Sub Button1_Click(ByVal Sender As Object, ByVal e As EventArgs)
      ' Create a BulletedList control.
      Dim CompaniesBulletedList As New BulletedList

      ' Add the list items to the BulletedList control.
      CompaniesBulletedList.Items.Add("Coho Winery")
      CompaniesBulletedList.Items.Add("Contoso, Ltd.")
      CompaniesBulletedList.Items.Add("Tailspin Toys")

      ' Add the BulletedList control to the Controls collection
      ' of the PlaceHolder control.
      Place.Controls.Add(CompaniesBulletedList)

    End Sub

 </script>
 
</head>
<body>

  <form id="form1" runat="server">

    <h3>BulletedList Constructor Example</h3>
        
    <asp:PlaceHolder id="Place" 
        runat="server">
    </asp:PlaceHolder>
 
    <hr />

    <asp:Button id="Button1" 
        Text="Create and Show a BulletedList" 
        OnClick="Button1_Click" 
        runat="server"/>  
 
  </form>
   
</body>
</html>
<!--</Snippet1>-->