<!-- <Snippet3> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.MobileControls.Label lab;

        for (int i = 1; i < 16; i++)
        {
            lab = new System.Web.UI.MobileControls.Label();
            lab.Text = i.ToString() + 
                " - This sentence repeats over and over.";
            Panel1.Controls.Add(lab);
        }
        Form1.Paginate = true;
        Panel1.Paginate = true;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="Form1" runat="server">
        <mobile:Panel ID="Panel1" Runat="server">
        </mobile:Panel>
    </mobile:form>
</body>
</html>
<!-- </Snippet3> -->