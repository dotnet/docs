<!--<Snippet3>-->
<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="head1" runat="server">

    <title>Using the Controls Collection in a Web Form</title>
    
    <script language="vb" runat="server">
        
        Private Sub ChangeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
            
            Dim c As Control
            Dim c2 As Control
            
            For Each c In Page.Controls
                If c.Controls.Count > 0 Then
                    For Each c2 In c.Controls
                        If c2.GetType.ToString = "System.Web.UI.WebControls.TextBox" Then
                            MySpan.InnerHtml = CType(c2, TextBox).Text
                            CType(c2, TextBox).Text = ""
                        End If
                    Next
                End If
            Next
        End Sub

</script>
   
</head>

<body>
  <form id="form1" runat="server">
    <table width="80%"
           border="1" 
           cellpadding="1" 
           cellspacing="1">
      <tr>
        <td align="center" style="width:50%;">
        <asp:TextBox id="MyTextBox" 
                     text="Type something here" 
                     runat="server"/>
        </td>
        <td align="center" style="width:50%;">
        <span id="myspan" runat="server">&nbsp;</span>
        </td>
      </tr>
      
      <tr>
        <td colspan="2" align="center">
        <input id="changebtn"
               type="submit"  
               onserverclick="changebtn_click" 
               value="move your text"
               runat="server" />
        </td>
      </tr>
    </table>
  </form>
</body>
</html>
<!--</Snippet3>-->