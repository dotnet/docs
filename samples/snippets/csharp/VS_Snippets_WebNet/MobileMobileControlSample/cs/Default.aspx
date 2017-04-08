<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            // Create and bind an array of data
            ArrayList arr = new ArrayList();
            for (int i = 0; i < 5; i++)
                arr.Add(i + 1);
            ObjectList1.DataSource = arr;
            ObjectList1.DataBind();
        }

        // Create a Label and add it to the form
        System.Web.UI.MobileControls.Label lab = 
            new System.Web.UI.MobileControls.Label();
        lab.Text = "Form.ID is ThirdForm";
        lab.Alignment = Alignment.Center;
        ThirdForm.Form.Controls.Add(lab);

        // Check the NoWrap capability
        MobileCapabilities currentCapabilities
            = (MobileCapabilities)Request.Browser;
        if (currentCapabilities.SupportsDivNoWrap)
            FirstForm.Wrapping = Wrapping.NoWrap;
    }

    // The command click event handler
    private void OnCmdClick(object sender, EventArgs e)
    {
        // Make sure there is a templated UI available
        ObjectList1.EnsureTemplatedUI();

        // Find the label
        System.Web.UI.MobileControls.Label lab =
            (System.Web.UI.MobileControls.Label)
            ObjectList1.Details.FindControl("DetLabel");

        // Depending on the text in the Label, change view
        if (lab.Text == "New Tasks")
            ObjectList1.ViewMode = ObjectListViewMode.List;
        else if (lab.Text == "Task List" && 
            ObjectList1.ViewMode == ObjectListViewMode.Details)
            lab.Text = "New Tasks";
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <Mobile:Form id="FirstForm" runat="server">
        <mobile:Link ID="Link3" Runat="server" 
            NavigateUrl="#SecondForm">Second Form</mobile:Link>
        <mobile:Link ID="Link4" Runat="server" 
            NavigateUrl="#ThirdForm">Third Form</mobile:Link>
        <mobile:ObjectList id="ObjectList1" runat="server" 
            CommandStyle-StyleReference="subcommand" 
            LabelStyle-StyleReference="title" 
            DetailsCommandText="Details">
            <Command Name="Details" />
            <DeviceSpecific>
                <!-- No Filter, so chosen for all devices -->
                <Choice>
                    <ItemDetailsTemplate>
                        <mobile:Label id="DetLabel" runat="server" 
                            Text="Task List" Font-Bold="true" />
                        <mobile:Command id="Command1" runat="server"  
                            OnClick="OnCmdClick">Command
                        </mobile:Command>
                    </ItemDetailsTemplate>
                </Choice>
            </DeviceSpecific>
        </mobile:ObjectList>
    </mobile:Form>
    <mobile:Form ID="SecondForm" Runat="server">
        <mobile:Label ID="Label2" Runat="server">
            The Second Form</mobile:Label>
        <mobile:Link ID="Link1" Runat="server" 
            NavigateUrl="#WelcomeForm">Back</mobile:Link>
    </mobile:Form>
    <mobile:Form ID="ThirdForm" Runat="server">
        <mobile:Label ID="Label3" Runat="server">
            The Third Form</mobile:Label>
        <mobile:Link ID="Link2" Runat="server" 
            NavigateUrl="#WelcomeForm">Back</mobile:Link>
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
