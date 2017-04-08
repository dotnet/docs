<!-- <snippet1> -->
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WizardClass.vb" Inherits="WizardClassvb_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">    
      <asp:Wizard id="Wizard1" 
        runat="server" 
        onfinishbuttonclick="OnFinishButtonClick" 
        backcolor="#EFF3FB" 
        font-names="Verdana" 
        font-size="0.8em"
        borderwidth="1px" 
        bordercolor="#B5C7DE" 
        style="font-size: medium; font-family: Verdana;" 
        onactivestepchanged="OnActiveStepChanged">       
      <StepStyle forecolor="#333333" 
        font-size="0.8em" />
        <WizardSteps>        
          <asp:WizardStep id="Step1" 
            title="One"
            allowreturn="false" 
            runat="server" >
            Welcome to the Wizard example.  This step's AllowReturn property is set 
            to false, so after you leave this step you will not be able to return to it.
          </asp:WizardStep>          
          <asp:WizardStep id="Step2"
            title="Two" 
            runat="server" >
            <!-- ... Put UI elements here ... -->
            Please enter your billing information.
            <br />
            Name:<br />
            <asp:TextBox runat="server" 
              id="BillingName" 
              width="226px" 
              height="17px" /> 
            <br />
            Email Address:<br />
            <asp:TextBox runat="server" 
              id="EmailAddress" 
              width="224px" 
              height="17px" />
            <br />
            Address Line 1: <br />
            <asp:TextBox runat="server" 
              id="BillingAddressLine1" 
              width="314px" 
              height="17px" />
            <br />
            Address Line 2: <br />
            <asp:TextBox runat="server" 
              id="BillingAddressLine2" 
              width="314px" 
              height="17px" />
            <br />
            City: <br />
            <asp:TextBox runat="server" 
              id="BillingCity" 
              width="155px" 
              height="17px" /> 
            <br />
            State: <br />
            <asp:TextBox runat="server" 
              id="BillingState" 
              width="75px" 
              height="17px" /> 
            <br />
            ZIP Code: <br />
            <asp:TextBox runat="server" 
              id="BillingZip" 
              height="17px" />
            <br /><br />
            <asp:CheckBox runat="server" 
              id="SeparateShippingCheckBox" 
              text="Please check here if you would like to add a separate shipping address." />
          </asp:WizardStep>          
          <asp:WizardStep id="Step3" 
            title="Three"
            runat="server" >
            <!-- Gather the shipping address in this step if CheckBox1 was selected. -->
            Please enter your shipping information.
            <br />
                Name:<br />
                <asp:TextBox runat="server" 
                  id="ShippingName" 
                  height="17px" /> 
                <br />
                Address Line 1: <br />
                <asp:TextBox runat="server" 
                  id="ShippingAddress1" 
                  width="370px" 
                  height="17px" />
                <br />
                Address Line 2: <br />
                <asp:TextBox runat="server" 
                  id="ShippingAddress2" 
                  width="370px" 
                  height="17px" />
                <br />
                City: <br />
                <asp:TextBox runat="server" 
                  id="ShippingCity" 
                  height="17px" /> 
                <br />
                State: <br />
                <asp:TextBox runat="server" 
                  id="ShippingState" 
                  width="65px" 
                  height="17px" />
                <br /> 
                ZIP Code: <br />
                <asp:TextBox runat="server" 
                  id="ShippingZip" 
                  height="17px" />
          </asp:WizardStep>
          <asp:WizardStep id="Finish" 
            title="Finish"
            runat="server" >
            <!-- Put UI elements here for the Finish step. -->
            <asp:Button runat="server" 
              id="GoBackButton" 
              text="Go Back to Step 2" 
              forecolor="#284E98" 
              font-names="Verdana"
              font-size="1.0em" 
              borderstyle="Solid" 
              borderwidth="1px" 
              bordercolor="#507CD1" 
              backcolor="White" /> 
          </asp:WizardStep>          
          <asp:WizardStep runat="server" 
            steptype="Complete" 
            title="Complete" 
            id="Complete">
            <asp:Label runat="server" 
              id="CompleteMessageLabel" 
              width="408px" 
              height="24px">
            </asp:Label>
          </asp:WizardStep>
        </WizardSteps> 
        <NavigationButtonStyle forecolor="#284E98" 
          font-names="Verdana"
          font-size="1.0em" 
          borderstyle="Solid" 
          borderwidth="1px" 
          bordercolor="#507CD1" 
          backcolor="White" />
        <HeaderStyle forecolor="White" 
          horizontalalign="Center" 
          font-size="0.9em" 
          font-bold="True"
          backcolor="#284E98" 
          borderstyle="Solid" 
          bordercolor="#EFF3FB" 
          borderwidth="2px" />
        <SideBarStyle verticalalign="Top" 
          horizontalalign="Center"
          font-size="0.8em" 
          forecolor="#000099"
          backcolor="#EFF3FB"
          width="45px" />
        <HeaderTemplate>
          <b>Wizard Example</b>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->


