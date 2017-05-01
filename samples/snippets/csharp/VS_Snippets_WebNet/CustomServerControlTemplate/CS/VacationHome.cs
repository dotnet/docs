// <Snippet1>
// VacationHome.cs
using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;

namespace Samples.AspNet.CS.Controls
{
    [
    AspNetHostingPermission(SecurityAction.InheritanceDemand, 
        Level=AspNetHostingPermissionLevel.Minimal),
    AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal),
	Designer(typeof(VacationHomeDesigner)),
    DefaultProperty("Title"),
    ToolboxData(
        "<{0}:VacationHome runat=\"server\"> </{0}:VacationHome>"),
    ]
    public class VacationHome : CompositeControl
    {
        private ITemplate templateValue;
        private TemplateOwner ownerValue;

        [
        Bindable(true),
        Category("Data"),
        DefaultValue(""),
        Description("Caption")
        ]
        public virtual string Caption
        {
            get
            {
                string s = (string)ViewState["Caption"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["Caption"] = value;
            }
        }

        [
        Browsable(false),
        DesignerSerializationVisibility(
            DesignerSerializationVisibility.Hidden)
        ]
        public TemplateOwner Owner
        {
            get
            {
                return ownerValue;
            }
        }

        [
        Browsable(false),
        PersistenceMode(PersistenceMode.InnerProperty),
        DefaultValue(typeof(ITemplate), ""),
        Description("Control template"),
        TemplateContainer(typeof(VacationHome))
        ]
        public virtual ITemplate Template
        {
            get
            {
                return templateValue;
            }
            set
            {
                templateValue = value;
            }
        }

        [
        Bindable(true),
        Category("Data"),
        DefaultValue(""),
        Description("Title"),
        Localizable(true)
        ]
        public virtual string Title
        {
            get
            {
                string s = (string)ViewState["Title"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            ownerValue = new TemplateOwner();

            ITemplate temp = templateValue;
            if (temp == null)
            {
                temp = new DefaultTemplate();
            }

            temp.InstantiateIn(ownerValue);
            this.Controls.Add(ownerValue);
        }

        public override void DataBind()
        {
            CreateChildControls();
            ChildControlsCreated = true;
            base.DataBind();
        }

    }

    [
    ToolboxItem(false)
    ]
    public class TemplateOwner : WebControl
    {
    }

    #region DefaultTemplate
    sealed class DefaultTemplate : ITemplate
    {
        void ITemplate.InstantiateIn(Control owner)
        {
            Label title = new Label();
            title.DataBinding += new EventHandler(title_DataBinding);

            LiteralControl linebreak = new LiteralControl("<br/>");

            Label caption = new Label();
            caption.DataBinding 
                += new EventHandler(caption_DataBinding);

            owner.Controls.Add(title);
            owner.Controls.Add(linebreak);
            owner.Controls.Add(caption);

        }

        void caption_DataBinding(object sender, EventArgs e)
        {
            Label source = (Label)sender;
            VacationHome container = 
                (VacationHome)(source.NamingContainer);
            source.Text = container.Caption;
        }

        void title_DataBinding(object sender, EventArgs e)
        {
            Label source = (Label)sender;
            VacationHome container = 
                (VacationHome)(source.NamingContainer);
            source.Text = container.Title;
        }
    }
    #endregion


   public class VacationHomeDesigner : ControlDesigner
   {

        public override void Initialize(IComponent Component)
		{
            base.Initialize(Component);
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }

        public override string GetDesignTimeHtml()
		{
            return "<span>This is design-time HTML</span>";
        }

        public override TemplateGroupCollection TemplateGroups
		{
            get {
				TemplateGroupCollection collection = new TemplateGroupCollection();
				TemplateGroup group;
				TemplateDefinition template;
				VacationHome control;

                control = (VacationHome)Component;
                group = new TemplateGroup("Item");
                template = new TemplateDefinition(this, "Template", control, "Template", true);
                group.AddTemplateDefinition(template);
                collection.Add(group);
				return collection;
            }
        }
	}

}
// </Snippet1>
