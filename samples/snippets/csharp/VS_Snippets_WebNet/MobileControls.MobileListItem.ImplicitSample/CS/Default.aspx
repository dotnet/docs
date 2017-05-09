<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        MobileListItem mi;
        
        // Use implicit conversion to create 
        // new MobileListItem objects from strings
        mi = "One";
        List1.Items.Add(mi);
        mi = "Two";
        List1.Items.Add(mi);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:List ID="List1" Runat="server">
        </mobile:List>
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
