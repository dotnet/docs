<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    void cmd_OnItemCommand(object sender, CommandEventArgs e)
    {
        // Create variables for data
        string txt1 = "Today's quote of {0} is {1}";
        string txt2 = "Yesterday's quote of {0} was {1}";
        int val = (Convert.ToInt32(e.CommandArgument) - 5);
        
        // Set the text values of the labels
        message1.Text = String.Format(txt1, e.CommandName, 
            e.CommandArgument);
        message2.Text = String.Format(txt2, e.CommandName, val);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <p>
            <mobile:label id="message1" runat="server">
                Click the button for quotes
            </mobile:label>
            <mobile:label id="message2" runat="server" />
        </p>
        <mobile:command id="CmdA" Format="Link" 
            onItemCommand ="cmd_OnItemCommand" 
            CommandArgument="70" CommandName="ca" 
            runat="server" Text="Company A" />
        <mobile:command id="CmdB" Format="Link" 
            onItemCommand ="cmd_OnItemCommand" 
            CommandArgument="25" CommandName="cb" 
            runat="server" Text="Company B" />
        <mobile:command id="CmdC" Format="Button" 
            OnItemCommand ="cmd_OnItemCommand" 
            CommandArgument="110" CommandName="cc" 
            runat="server" Text= "Company C" />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
