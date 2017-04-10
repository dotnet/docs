<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    '<Snippet6>
    Protected Sub CreateUserWizard1_CreatedUser(ByVal sender As Object, ByVal e As EventArgs)
        ' Determine the checkbox values.
        Dim subscribeCheckBox As CheckBox = _
          CType(CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("SubscribeCheckBox"), CheckBox)
        Dim shareInfoCheckBox As CheckBox = _
          CType(CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("ShareInfoCheckBox"), CheckBox)
        Dim userNameTextBox As TextBox = _
          CType(CreateUserWizardStep1.ContentTemplateContainer.FindControl("UserName"), TextBox)
        

        Dim user As MembershipUser = Membership.GetUser(userNameTextBox.Text)
        User.Comment = "Subscribe=" & subscribeCheckBox.Checked.ToString() & "&" & _
                       "ShareInfo=" & shareInfoCheckBox.Checked.ToString()
        Membership.UpdateUser(user)

        ' Show or hide the labels based on the checkbox values.
        Dim subscribeLabel As Label = _
          CType(CreateUserWizard1.CompleteStep.ContentTemplateContainer.FindControl("SubscribeLabel"), Label)
        Dim shareInfoLabel As Label = _
          CType(CreateUserWizard1.CompleteStep.ContentTemplateContainer.FindControl("ShareInfoLabel"), Label)

        subscribeLabel.Visible = subscribeCheckBox.Checked
        shareInfoLabel.Visible = shareInfoCheckBox.Checked
    End Sub
    '</Snippet6>
    
    '<Snippet7>
    Private Function UserExists(ByVal username As String) As Boolean
        If Membership.GetUser(username) IsNot Nothing Then Return True
                
        Return False
    End Function

    Protected Sub CreateUserWizard1_NextButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
        If e.CurrentStepIndex = 0 Then
            If SearchAccount.Text.Trim() = "" OrElse UserExists(SearchAccount.Text) Then
                SearchAccountMessage.Text = "That account already exists. Please select an different account name."
                e.Cancel = True
            Else
                Dim userName As TextBox = _
                  CType(CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName"), TextBox)
                userName.Text = SearchAccount.Text
                SearchAccountMessage.Text = ""
                e.Cancel = False
            End If
        End If
    End Sub
    '</Snippet7>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
            BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
            OnNextButtonClick="CreateUserWizard1_NextButtonClick"
            OnCreatedUser="CreateUserWizard1_CreatedUser" ContinueDestinationPageUrl="~/Default.aspx">
            <WizardSteps>
               <%-- <Snippet5> --%>
               <asp:WizardStep ID="CreateUserWizardStep0" runat="server">
                    <table border="0" style="font-size: 100%; font-family: Verdana" id="TABLE1" >
                         <tr>
                             <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d">
                                 Select an Account Name</td>
                         </tr>
                         <tr>
                             <td>
                               <asp:Label ID="AccountNameLabel" runat="server" AssociatedControlID="SearchAccount" > 
                                 Account Name:</asp:Label>
                               <asp:TextBox ID="SearchAccount" runat="server"></asp:TextBox><br />
                               <asp:Label ID="SearchAccountMessage" runat="server" ForeColor="red" />                                          
                             </td>
                         </tr>
                     </table>
                </asp:WizardStep>
                <%-- </Snippet5> --%>
                <%-- <Snippet3> --%>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0" style="font-size: 100%; font-family: Verdana">
                            <tr>
                                <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d">
                                    Sign Up for Your New Account</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">
                                        User Name:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">
                                        Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">
                                        Confirm Password:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                        ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">
                                        E-mail:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                        ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">
                                        Security Question:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                        ErrorMessage="Security question is required." ToolTip="Security question is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">
                                        Security Answer:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                        ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                        ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: red">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                        <asp:CheckBox ID="SubscribeCheckBox" runat="server" Checked="True" Text="Send me a monthly newsletter." />
                        <br />
                        <asp:CheckBox ID="ShareInfoCheckBox" runat="server" Checked="True" Text="Share my information with partner sites." />
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <%-- </Snippet3> --%>
                <%-- <Snippet4> --%>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    <ContentTemplate>
                        <table border="0" style="font-size: 100%; font-family: Verdana" id="TABLE1" >
                            <tr>
                                <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d; height: 18px;">
                                    Complete</td>
                            </tr>
                            <tr>
                                <td>
                                    Your account has been successfully created.<br />
                                    <br />
                                    <asp:Label ID="SubscribeLabel" runat="server" Text="You have elected to receive our monthly newsletter."></asp:Label><br />
                                    <br />
                                    <asp:Label ID="ShareInfoLabel" runat="server" Text="You have elected to share your information with partner sites."></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    &nbsp;<asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                        BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                                        Font-Names="Verdana" ForeColor="#284775" Text="Continue" ValidationGroup="CreateUserWizard1" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
                <%-- </Snippet4> --%>
            </WizardSteps>
            <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
                ForeColor="White" HorizontalAlign="Center" />
            <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <StepStyle BorderWidth="0px" />
        </asp:CreateUserWizard>
        &nbsp;</div>
    </form>
</body>
</html>
<!--</Snippet1>-->