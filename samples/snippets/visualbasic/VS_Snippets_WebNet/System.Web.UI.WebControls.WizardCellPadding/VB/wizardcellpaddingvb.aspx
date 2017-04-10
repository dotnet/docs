<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  
      <form id="form1" runat="server">

        <asp:Wizard ID="Wizard1" 
                    CellSpacing="20" 
                    CellPadding="20" 
                    BorderColor="Blue" 
                    BorderWidth="2" 
                    Runat="server">
          
          <WizardSteps>
          
            <asp:WizardStep ID="WizardStep1" 
                            Title="Step 1" 
                            Runat="server">
                            You are currently on step 1.
            </asp:WizardStep>
            
            <asp:WizardStep ID="WizardStep2" 
                            Title="Step 2" 
                            Runat="server">
                            You are currently on step 2.
            </asp:WizardStep>
            
            <asp:WizardStep ID="WizardStep3" 
                            Runat="server" 
                            Title="Step 3">
                            You are currently on step 3.
            </asp:WizardStep>
            
          </WizardSteps>
          
          <HeaderTemplate>
          
            <b>Wizard CellPadding and CellSpacing Example</b>
            
          </HeaderTemplate>
          
        </asp:Wizard>
        
      </form>
      
  </body>
  
</html>
<!-- </snippet1> -->
