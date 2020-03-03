<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TemplatedWizardStep Example</title>
    
    <script runat="server">
        Sub OnPreviousButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
            'Display feedback
            FeedbackID.Text = "Previous button clicked"
 
        End Sub

        Sub OnNextButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)

            ' Display feedback.
            FeedbackID.Text = "Next button clicked"

        End Sub
    
    </script>

</head>

<body>
    <form id="form1" runat="server">
    
        <asp:Wizard ID="Wizard1" runat="server" 
            OnPreviousButtonClick="OnPreviousButtonClick" 
            OnNextButtonClick="OnNextButtonClick">
        <WizardSteps>
            <asp:TemplatedWizardStep StepType="Auto">
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server" 
                        BackColor="blue"  Font-Bold="true" ForeColor="yellow">
                      Simple TemplatedWizardStep Example</asp:Label>
                </ContentTemplate>
                <CustomNavigationTemplate>
                    <div style="margin: 1em 1em;">
                        <asp:Button ID="PreviousButtonID" runat="server" Font-Bold="true"  
                            BackColor="Red" Text="Previous" CommandName="MovePrevious"/>
                        <asp:Button ID="NextButtonID" runat="server"   Font-Bold="true" 
                            BackColor="Aqua" Text="Next" CommandName="MoveNext"/>
                    </div>
                </CustomNavigationTemplate>
            </asp:TemplatedWizardStep>
        </WizardSteps>
  
        </asp:Wizard>
    
        <asp:Label ID="FeedbackID" runat="server" BackColor="yellow" ForeColor="red"/>
    </form>

</body>
</html>

<!-- </Snippet1> -->
