<!-- <Snippet2> -->
<%@ Page Language="C#" %>
<%@ Register TagPrefix="Samples" Namespace="TemplateControlSamples" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">


    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList a = new ArrayList();
        a.Add("data item 1");
        a.Add("data item 2");
        Repeater1.DataSource = a;
        Page.DataBind();
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ChildControlsCreated Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <Samples:CustomRepeater ID="Repeater1" runat="server">
        <ItemTemplate><%# Container.DataItem %> <br /></ItemTemplate>
        </Samples:CustomRepeater>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
