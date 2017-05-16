<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.Mobile" %>

<script runat="server">
    public void Page_Load(Object sender, EventArgs e)
    {
        int count = this.Panel1.DeviceSpecific.Choices.Count;

        // Cycle through the DeviceSpecificChoiceCollection.
        for (int i = 0; i < count; i++)
        {
            string txt1 = "Choice {0} has {1} Templates. ";
            string txt2 = "Filter name is '{0}'. ";

            Label1.Text += String.Format(txt1, i,
                Panel1.DeviceSpecific.Choices[i].Templates.Count);
            Label2.Text += String.Format(txt2,
                Panel1.DeviceSpecific.Choices[i].Filter);
        }
    }

    //<Snippet3>
    // Add a DeviceSpecificChoice section programatically
    protected void form1_Init(object sender, EventArgs e)
    {
        DeviceSpecific devSpecific = Panel1.DeviceSpecific;
        DeviceSpecificChoice devChoiceHtml = new DeviceSpecificChoice();
        devChoiceHtml.Filter = "isCHTML10";
        devSpecific.Choices.Add(devChoiceHtml);
        ((IParserAccessor)form1).AddParsedSubObject(devSpecific);
    }
    //</Snippet3>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form ID="form1" Runat="server" OnInit="form1_Init">
        <mobile:Panel id="Panel1" Runat="server">
            <mobile:DeviceSpecific Runat="server">
                <Choice Filter="isHTML32">
                    <ContentTemplate>
                        <!-- For HTML Browsers -->
                        <br />
                        <mobile:Label ID="Label3" Runat="server" 
                            Text="Visible in an HTML Browser" />
                        <br />
                    </ContentTemplate>
                </Choice>
                <Choice Filter="isWML11">
                    <ContentTemplate>
                        <!-- For WML Browsers -->
                        <br />
                        <mobile:Label ID="Label4" Runat="server" 
                            Text="Viewable in a WML browser" />
                        <br />
                    </ContentTemplate>
                </Choice>
            </mobile:DeviceSpecific>
        </mobile:Panel>
        <mobile:Label id="Label1" Runat="server" Font-Bold="true" />
        <mobile:Label ID="Label2" Runat="server" Font-Bold="true" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
