<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--<Snippet5>-->
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Using the FindControl Method to Search for a Control</title>
</head>

<script language="vb" runat="server">
    
    Dim list As String()
    
    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        list = New String() {"One", "Two", "Three"}
        MyRepeater.DataSource = list
        MyRepeater.DataBind()
    End Sub
    
    Private Sub ChangeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Control = MyRepeater.FindControl("_ctl0")
        If Not x Is Nothing Then
            list(0) = "This control was found with FindControl."
        End If
        MyRepeater.DataBind()
    End Sub
    
</script>

<body>
     <form id="form1" action="repeater.aspx" method="post" runat="server">
        
         <asp:repeater id="MyRepeater" runat="server">
            <ItemTemplate>
               <span id="span1" runat="server">
                  <%# Container.DataItem %><br/>
               </span>
            </ItemTemplate>
         </asp:repeater>
         <input id="changebtn" type="submit" onserverclick="changebtn_click" runat="server"/>
      
      </form>
</body>
</html>
<!--</Snippet5>-->