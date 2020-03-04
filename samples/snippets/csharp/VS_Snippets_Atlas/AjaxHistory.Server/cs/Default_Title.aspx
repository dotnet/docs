<!-- <Snippet3> -->
<%@ Page Language="C#" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    private static String key = "s";
    
    // Handle the Navigate event
    public void OnNavigateHistory(object sender, HistoryEventArgs e) {
        LabelHistoryData.Text = Server.HtmlEncode(e.State[key]);
    }

    // On button click, handle the event and set a history point. 
    public void ButtonClick(object sender, EventArgs e) {
        LabelHistoryData.Text = ((Button)sender).Text;
        ScriptManager.GetCurrent(this).AddHistoryPoint(key, LabelHistoryData.Text, "Entry: " + LabelHistoryData.Text);
    }
</script>
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Microsoft ASP.NET 3.5 Extensions: Managing History</title>
    <link href="../../include/qsstyle.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="ScriptManager1" OnNavigate="OnNavigateHistory" 
                EnableHistory="true" EnableSecureHistoryState="false" />
            <h2>
                Microsoft ASP.NET 3.5 Extensions: Adding Server-side Browser History Points and Title Entries</h2>
            <p/>

            <div id="Div1" class="new">
                <p>This sample shows:</p>
                <ol>
                    <li>How to use the <code>ScriptManager</code> control to set a history point and add titles.</li>
                    <li>The <code>ScriptManager</code> control, the <code>EnableHistory</code> and 
                    <code>EnableSecureHistoryState</code> properties and 
                    the <code>OnNavigate</code> property to handle the <code>navigate</code>event.<br />
                    </li>
                </ol>
            </div>

            <p>
                In this example, three buttons outside the <code>UpdatePanel</code> control can
                trigger an asynchronous postback. You can see the results of the update through
                the date and time that renders in the Web page along with a value indicating the 
                button that triggered the partial refresh.</p>
            <p>
                When you press a button, the server-side <code>Click</code> event handler for the button 
                stores data and uses the data as a history point. If you click the browser's Back button, 
                you will see the state Web page return to a previous button value, representing the previous 
                button you pressed. However, you will see that the time within the Web page continues to be 
                incremented.
            </p>
            <p>To see the effect of this logic, do the following.</p>

            <ol>
                <li>Press <b>1</b>. See the panel refresh.</li>
                <li>Press <b>3</b>. See the panel refresh.</li>
                <li>Press <b>2</b>. See the panel refresh.</li>
                <li>Press the browser's Back button. Note that the panel is refreshed with previous
                    data, but the date and time are updated to current values.</li>
                <li>Press the browser's "Recent Pages" drop down menu and review the history entries and their titles.</li>
            </ol>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="Button3" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                    <asp:Panel runat="server" CssClass="box" ID="Content" Height="40px">
                        Date and Time:
                        <%= DateTime.Now.ToLongTimeString() %>
                        <br />
                        Page's refresh state:
                        <asp:Label runat="server" ID="LabelHistoryData" />
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <p />
            <asp:Button runat="server" ID="Button1" Text="Key 1" OnClick="ButtonClick" />
            <asp:Button runat="server" ID="Button2" Text="Key 2" OnClick="ButtonClick" />
            <asp:Button runat="server" ID="Button3" Text="Key 3" OnClick="ButtonClick" />
        </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->
