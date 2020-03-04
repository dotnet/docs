<!-- <Snippet2> -->
<%@ Page Language="VB" %>
<%@ Register TagPrefix="Samples" Namespace="TemplateControlSamplesVB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        
        Dim a As New ArrayList()
        a.Add("data item 1")
        a.Add("data item 2")
        Repeater1.DataSource = a
        Page.DataBind()

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ChildControlsCreated Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Samples:CustomRepeaterVB ID="Repeater1" runat="server">
        <ItemTemplate><%# Container.DataItem %> <br /></ItemTemplate>
        </Samples:CustomRepeaterVB>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
