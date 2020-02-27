<!-- <Snippet2> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    private static readonly string stepKey = "s";

    protected void OnNavigateHistory(object sender, HistoryEventArgs args)
    {
        string stateString = args.State[stepKey];
        int step = (stateString != null) ? int.Parse(stateString) : 0;
        MachineConfiguratorWizard.ActiveStepIndex = step;
    }

    protected void OnActiveStepChanged(object sender, EventArgs e)
    {
        if (!ScriptManager1.IsNavigating && IsPostBack) {
            int index = MachineConfiguratorWizard.ActiveStepIndex;
            ScriptManager1.AddHistoryPoint(stepKey, index.ToString(), "Step " + (index+1).ToString());
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Microsoft ASP.NET 3.5 Extensions: Managing History</title>
    <link href="../../include/qsstyle.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <div>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="ScriptManager1" OnNavigate="OnNavigateHistory" 
                EnableHistory="true" EnableSecureHistoryState="false" />
            <h2>
                Microsoft ASP.NET 3.5 Extensions: Adding Server-side Browser History Points</h2>
            <p/>

            <div id="Div1" class="new">
                <p>This sample shows:</p>
                <ol>
                    <li>How to use the <code>ScriptManager</code> control to set a history point.</li>
                    <li>The <code>ScriptManager</code> control, the <code>EnableHistory</code> and 
                    <code>EnableSecureHistoryState</code> properties and 
                    the <code>OnNavigate</code> property to handle the <code>navigate</code> event.
                    </li>
                    <li>Protecting the history code with <code>IsNavigating</code>
                    </li>
                </ol>
            </div>
        <p>
        In this example, the <code>Wizard</code> server control provides it's own navigation, but 
        as each step is selected a history point is added. In order to do this, a history point is only added if the page is not being refreshed beacuse of a history point.</p>
            <asp:UpdatePanel runat="server" ID="WizardPanel">
                <ContentTemplate>
                    <asp:Wizard ID="MachineConfiguratorWizard" runat="server" ActiveStepIndex="0" BackColor="#dddddd"
                        BorderWidth="10" CellPadding="10" CellSpacing="10" Height="200px" Width="700px"
                        FinishPreviousButtonText="<" StartNextButtonText=">" StepNextButtonText=">" StepPreviousButtonText="<"
                        FinishCompleteButtonText="<|>" OnActiveStepChanged="OnActiveStepChanged">
                        <WizardSteps>
                            <asp:WizardStep ID="Step1" runat="server" Title="Step 1">
                                <h2>
                                    STEP 1</h2>
                                <br />
                            </asp:WizardStep>
                            <asp:WizardStep ID="Step2" runat="server" Title="Step 2">
                                <h2>
                                    STEP 2</h2>
                                <br />
                            </asp:WizardStep>
                            <asp:WizardStep ID="Step3" runat="server" Title="Step 3">
                                <h2>
                                    STEP 3</h2>
                                <br />
                            </asp:WizardStep>
                        </WizardSteps>
                        <StepStyle Font-Names="tahoma" Font-Size="Smaller" VerticalAlign="Top" />
                        <SideBarStyle Font-Size="Small" VerticalAlign="Top" BackColor="#FFFFC0" Font-Names="tahoma" />
                        <FinishPreviousButtonStyle BackColor="White" BorderColor="Black" BorderWidth="3px"
                            Font-Names="Tahoma" Font-Size="Medium" />
                        <NavigationButtonStyle BackColor="White" BorderColor="Black" BorderStyle="Solid"
                            BorderWidth="3px" Font-Names="Tahoma" Font-Size="Medium" />
                        <FinishCompleteButtonStyle Font-Names="Tahoma" Font-Size="Medium" />
                    </asp:Wizard>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->