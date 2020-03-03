<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    private void Form_Init(object sender, System.EventArgs e)
    {
        // Create a DeviceSpecific group for Choice elements
        DeviceSpecific devSpecific = new DeviceSpecific();

        // Create two Choice objects, one with a filter
        for (int i = 0; i < 2; i++)
        {
            DeviceSpecificChoice devChoice;
            ITemplate custTemplate;

            // Create a Choice object 
            devChoice = new DeviceSpecificChoice();
            // Only the first Choice has a filter (must be in Web.config)
            if (i == 0)
                devChoice.Filter = "isHTML32";

            // Create the header template.
            custTemplate = new CustomTemplate("HeaderTemplate");
            // Put header template in a new container
            custTemplate.InstantiateIn(new TemplateContainer());
            // Add the header template to the Choice
            devChoice.Templates.Add("HeaderTemplate", custTemplate);

            // Create the footer template
            custTemplate = new CustomTemplate("FooterTemplate");
            // Put footer template in a new container
            custTemplate.InstantiateIn(new TemplateContainer());
            // Add the footer template to the Choice
            devChoice.Templates.Add("FooterTemplate", custTemplate);

            // Add the Choice to the DeviceSpecific
            ((IParserAccessor)devSpecific).AddParsedSubObject(devChoice);
        }

        // Add the DeviceSpecific object to the form
        ((IParserAccessor)Form1).AddParsedSubObject(devSpecific);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.MobileControls.Label lab;
        lab = (System.Web.UI.MobileControls.Label)Form1.Header.FindControl("Label1");
        if (lab == null)
            return;

        // Get the selected choice's filter name
        string filterName = 
            Form1.DeviceSpecific.SelectedChoice.Filter;
        if (filterName == "isHTML32")
            lab.Text += " - HTML32";
        else
            lab.Text += " - Default";
    }

    public class CustomTemplate : ITemplate
    {
        String templateName;

        // Constructor
        public CustomTemplate(string TemplateName)
        {
            templateName = TemplateName;
        }

        public void InstantiateIn(Control container)
        {
            if (templateName == "HeaderTemplate")
            {
                // Create a label
                System.Web.UI.MobileControls.Label lab;
                lab = new System.Web.UI.MobileControls.Label();
                lab.Text = "Header Template";
                lab.ID = "Label1";

                // Create a command
                Command cmd = new Command();
                cmd.Text = "Submit";

                // Add controls to the container
                container.Controls.Add(lab);
                container.Controls.Add(cmd);
            }
            else if (templateName == "FooterTemplate")
            {
                // Create a label
                System.Web.UI.MobileControls.Label lab;
                lab = new System.Web.UI.MobileControls.Label();
                lab.ID = "Label2";
                lab.Text = "Footer Template";

                // Add label to the container
                container.Controls.Add(lab);
            }
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="Form1" runat="server" OnInit="Form_Init">
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
