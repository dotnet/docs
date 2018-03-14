<!-- <Snippet4> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.UI.MobileControls" %>
<%@ Import Namespace="System.Drawing" %>

<script Runat="server">
    //<Snippet7>
    void Form_Activate(object sender, EventArgs e)
    {
        Form1.Wrapping = Wrapping.NoWrap;
        string a = "This is a very long string <br />";
        string b = "START ";
        
        // Create a long string to force pagination
        for (int i = 0; i < 100; i++)
            b += a;
        
        txtView.Text = b + " END";
        Form1.ControlToPaginate = txtView;
    }
    //</Snippet7>

    //<Snippet5>
    void Form_Paginated(object sender, EventArgs e)
    {
        // Set the background color based on 
        // the number of pages
        if (ActiveForm.PageCount > 1)
            ActiveForm.BackColor = Color.LightBlue;
        else
            ActiveForm.BackColor = Color.LightGray;

        // Check to see if the Footer template has been chosen
        if (DevSpec.HasTemplates)
        {   
            System.Web.UI.MobileControls.Label lbl = null;
            
            // Get the Footer panel
            System.Web.UI.MobileControls.Panel pan = Form1.Footer;

            // Get the Label from the panel
            lbl = (System.Web.UI.MobileControls.Label)pan.FindControl("lblCount");
            // Set the text in the Label
            lbl.Text = "Page #" + Form1.CurrentPage.ToString();
        }
    }
    //</Snippet5>

    //<Snippet6>
    void Page_Load(object sender, EventArgs e)
    {
        // Set the pager text properties
        if (!IsPostBack)
            Form1.PagerStyle.NextPageText = "Go Next >";
        else
        {
            // For postback, set different text
            Form1.PagerStyle.NextPageText = "Go More >";
            Form1.PagerStyle.PreviousPageText = "< Go Prev";
        }
    }
    //</Snippet6>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<!-- The first Form -->
    <mobile:Form ID="Form1" Runat="server" 
        Paginate="true" OnActivate="Form_Activate" 
        OnPaginated="Form_Paginated">
        <mobile:link ID="Link1" Runat="server" 
            NavigateUrl="#Form2">
            Go To Other Form
        </mobile:link>
        <mobile:Label ID="Label1" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        <mobile:textview ID="txtView" Runat="server" />

        <mobile:DeviceSpecific ID="DevSpec" Runat="server">
            <Choice>
                <FooterTemplate>
                    <mobile:Label runat="server" id="lblCount" />
                </FooterTemplate>
            </Choice>
        </mobile:DeviceSpecific>
    </mobile:Form>
    
    <!-- The second Form -->
    <mobile:Form ID="Form2" Runat="server" 
        Paginate="true" OnPaginated="Form_Paginated">
        <mobile:Label ID="message2" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        <mobile:link ID="Link2" Runat="server" 
            NavigateUrl="#Form1">Back</mobile:link>
    </mobile:Form>
</body>
</html>
<!-- </Snippet4> -->
