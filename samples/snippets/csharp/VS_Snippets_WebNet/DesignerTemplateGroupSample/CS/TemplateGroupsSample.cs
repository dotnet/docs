//<Snippet1>
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;

namespace ASPNet.Design.Samples
{
    // Set an attribute reference to the designer, and define 
    // the HTML markup that the toolbox will write into the source.
    [Designer(typeof(TemplateGroupsSampleDesigner)),
        ToolboxData("<{0}:TemplateGroupsSample runat=server></{0}:TemplateGroupsSample>")]
    public sealed class TemplateGroupsSample : WebControl, INamingContainer
    {
        // Field for the templates
        private ITemplate[] _templates;

        // Constructor
        public TemplateGroupsSample()
        {
            _templates = new ITemplate[4];
        }

        // For each template property, set the designer attributes 
        // so the property does not appear in the property grid, but 
        // changes to the template are persisted in the control.
        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template1
        {
            get { return _templates[0]; }
            set { _templates[0] = value; }
        }
        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template2
        {
            get { return _templates[1]; }
            set { _templates[1] = value; }
        }
        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template3
        {
            get { return _templates[2]; }
            set { _templates[2] = value; }
        }
        [Browsable(false),
            PersistenceMode(PersistenceMode.InnerProperty)]
        public ITemplate Template4
        {
            get { return _templates[3]; }
            set { _templates[3] = value; }
        }

        protected override void CreateChildControls()
        {
            // Instantiate each template inside a panel
            // then add the panel to the Controls collection
            for (int i = 0; i < 4; i++)
            {
                Panel pan = new Panel();
                _templates[i].InstantiateIn(pan);
                this.Controls.Add(pan);
            }
        }
    }

    // Designer for the TemplateGroupsSample control
    public class TemplateGroupsSampleDesigner : ControlDesigner
    {
        TemplateGroupCollection col = null;

        //<Snippet5>
        public override void Initialize(IComponent component)
        {
            // Initialize the base
            base.Initialize(component);
            // Turn on template editing
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }
        //</Snippet5>

        //<Snippet4>
        // Add instructions to the placeholder view of the control
        public override string GetDesignTimeHtml()
        {
            return CreatePlaceHolderDesignTimeHtml("Click here and use " +
                "the task menu to edit the templates.");
        }
        //</Snippet4>

        public override TemplateGroupCollection TemplateGroups
        {
            get
            {

                if (col == null)
                {
                    // Get the base collection
                    col = base.TemplateGroups;

                    // Create variables
                    TemplateGroup tempGroup;
                    TemplateDefinition tempDef;
                    TemplateGroupsSample ctl;

                    // Get reference to the component as TemplateGroupsSample
                    ctl = (TemplateGroupsSample)Component;

                    // Create a TemplateGroup
                    tempGroup = new TemplateGroup("Template Set A");

                    // Create a TemplateDefinition
                    tempDef = new TemplateDefinition(this, "Template A1", 
                        ctl, "Template1", true);

                    // Add the TemplateDefinition to the TemplateGroup
                    tempGroup.AddTemplateDefinition(tempDef);

                    // Create another TemplateDefinition
                    tempDef = new TemplateDefinition(this, "Template A2", 
                        ctl, "Template2", true);

                    // Add the TemplateDefinition to the TemplateGroup
                    tempGroup.AddTemplateDefinition(tempDef);

                    // Add the TemplateGroup to the TemplateGroupCollection
                    col.Add(tempGroup);

                    // Create another TemplateGroup and populate it
                    tempGroup = new TemplateGroup("Template Set B");
                    tempDef = new TemplateDefinition(this, "Template B1", 
                        ctl, "Template3", true);
                    tempGroup.AddTemplateDefinition(tempDef);
                    tempDef = new TemplateDefinition(this, "Template B2", 
                        ctl, "Template4", true);
                    tempGroup.AddTemplateDefinition(tempDef);

                    // Add the TemplateGroup to the TemplateGroupCollection
                    col.Add(tempGroup);
                }

                return col;
            }
        }

        //<Snippet3>
        // Do not allow direct resizing unless in TemplateMode
        public override bool AllowResize
        {
            get
            {
                if (this.InTemplateMode)
                    return true;
                else
                    return false;
            }
        }
        //</Snippet3>
    }
}
//</Snippet1>