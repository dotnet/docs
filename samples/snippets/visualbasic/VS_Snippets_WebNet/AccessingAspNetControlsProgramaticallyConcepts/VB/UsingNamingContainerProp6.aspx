<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!--<Snippet6>-->
<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="head1" runat="server">
    <title>NamingContainer Example</title>
</head>

<script language="vb" runat="server">

    Dim list As ArrayList

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        
        list = New ArrayList
        
        list.Add("One")
        list.Add("Two")
        list.Add("Three")
        MyRepeater.DataSource = list
        MyRepeater.DataBind()
    End Sub
        
    Private Sub ChangeBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
        
        Dim x As Control = MyRepeater.Items(0).FindControl("Message")
        
        If Not x Is Nothing Then
            list = WalkContainers(x)
        End If
        MyRepeater.DataSource = list
        MyRepeater.DataBind()
    End Sub
        
    Private Function WalkContainers(ByVal ctl As Control) As ArrayList
        
        Dim ret As New ArrayList
        Dim parent As Control = ctl.NamingContainer
        
        If Not parent Is Nothing Then
            Dim sublist As ArrayList = WalkContainers(parent)
            Dim j As Integer
            For j = 0 To sublist.Count - 1
                ret.Add(sublist(j))
            Next
        End If
        ret.Add(ctl.GetType.Name)
        Return ret
    End Function
    
</script>
<body>
<form id="repeaterform" runat="server">
  <h3>Using the NamingContainer Property to Determine a 
      Control's Naming Container
  </h3>
  <table id="mytable" width="80%">
      <asp:repeater id="MyRepeater" runat="server">
      <ItemTemplate>
        <tr>
          <td align="center" style="width:100%;">
           <span id="message" runat="server">
           <%#Container.DataItem%>
           </span>
          </td>
        </tr>
      </ItemTemplate>
      </asp:repeater>
    <tr>
      <td align="center" style="width:100%;">
      <input id="changebtn" 
             type="submit" 
             onserverclick="changebtn_click "
             runat="server" />
       </td>
    </tr>
  </table>
</form>
</body>
</html>
<!--</Snippet6>-->