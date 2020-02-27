<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
// <Snippet1>
public class Sample : Control {
    private int currentIndex = 0;
   
    protected override void OnInit(EventArgs e) {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    protected override object SaveControlState() {
        return currentIndex != 0 ? (object)currentIndex : null;
    }

    protected override void LoadControlState(object state) {
        if (state != null) {
            currentIndex = (int)state;
        }
    }
}
// </Snippet1>
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <p>Here it is.</p>
    </form>
</body>
</html>
