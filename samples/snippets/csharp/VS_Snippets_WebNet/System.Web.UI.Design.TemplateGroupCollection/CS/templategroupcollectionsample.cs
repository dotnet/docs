//<Snippet1>
using System;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Examples.AspNet
{
    // Define a simple control designer that adds a
    // template group to the template group collection.
    class DerivedControlDesigner : System.Web.UI.Design.ControlDesigner
    {
        private DerivedControl internalControl = null;

        private const String templateGroupName = "My template group";
        private const String templateDefinitionName1 = "First";
        private const String templateDefinitionName2 = "Second";
        private TemplateGroup internalGroup = null;

        // Override the read-only TemplateGroups property.
        // Get the base group collection, and add a group 
        // with two template definitions for the derived
        // control designer.
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                // Start with the groups defined by the base designer class.
                TemplateGroupCollection groups = base.TemplateGroups;

                if (internalGroup == null) 
                {
                    // Define a new group with two template definitions.
                    internalGroup = new TemplateGroup(templateGroupName, 
                                                internalControl.ControlStyle);

                    TemplateDefinition templateDef1 = new TemplateDefinition(this, 
                        templateDefinitionName1, internalControl, 
                        templateDefinitionName1, internalControl.ControlStyle);

                    TemplateDefinition templateDef2 = new TemplateDefinition(this, 
                        templateDefinitionName2, internalControl, 
                        templateDefinitionName2, internalControl.ControlStyle);

                    internalGroup.AddTemplateDefinition(templateDef1);
                    internalGroup.AddTemplateDefinition(templateDef2);
                }


                // Add the new template group to the collection.
                groups.Add(internalGroup);

                return groups;
            }
        }

    }

    // Define a simple web control, and associate it with the designer.
    [DesignerAttribute(typeof(DerivedControlDesigner),
                       typeof(IDesigner))]
    public class DerivedControl : WebControl
    {
        // Define derived control behavior here.
    }

}
//</Snippet1>

namespace Examples.AspNet
{
    public class TestClass
    {
        public static void Main()
        {
        }
    }
}
