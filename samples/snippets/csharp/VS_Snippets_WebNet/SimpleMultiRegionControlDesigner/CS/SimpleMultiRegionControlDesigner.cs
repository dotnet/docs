//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.WebControls;

namespace Samples.ASPNet.ControlDesigners_CS 
{
    [
        Designer(typeof(MyMultiRegionControlDesigner)), 
        ToolboxData("<{0}:MyMultiRegionControl runat=\"server\" width=\"200\"></{0}:MyMultiRegionControl>")
    ]
    public class MyMultiRegionControl : CompositeControl
    {
        // Define the templates that represent 2 views on the control
        private ITemplate _view1;
        private ITemplate _view2;

        // Create persistable inner properties 
        // for the two editable views
        [PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(null)]
        public virtual ITemplate View1
        {
            get { return _view1; }
            set { _view1 = value; }
        }
        [PersistenceMode(PersistenceMode.InnerProperty), DefaultValue(null)]
        public virtual ITemplate View2
        {
            get { return _view2; }
            set { _view2 = value; }
        }

        // The current view on the control; 0 = view1, 1 = view2
        private int _currentView = 0;
        public int CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; }
        }

        // Create a simple table with a row of two clickable, 
        // readonly headers and a row with a single column, which 
        // is the 'container' to which we'll be adding controls.
        protected override void CreateChildControls()
        {
            // Always start with a clean form
            Controls.Clear();

            // Create a table using the control's declarative properties
            Table t = new Table();
            t.CellSpacing = 1;
            t.BorderStyle = BorderStyle;
            t.Width = this.Width;
            t.Height = this.Height;

            // Create the header row
            TableRow tr = new TableRow();
            tr.HorizontalAlign = HorizontalAlign.Center;
            tr.BackColor = Color.LightBlue;

            // Create the first cell in the header row
            TableCell tc = new TableCell();
            tc.Text = "View 1";
            tc.Width = new Unit("50%");
            tr.Cells.Add(tc);

            // Create the second cell in the header row
            tc = new TableCell();
            tc.Text = "View 2";
            tc.Width = new Unit("50%");
            tr.Cells.Add(tc);

            t.Rows.Add(tr);

            // Create the second row for content
            tr = new TableRow();
            tr.HorizontalAlign = HorizontalAlign.Center;

            // This cell represents our content 'container'
            tc = new TableCell();
            tc.ColumnSpan = 2;

            // Add the current view content to the cell
            // at run-time
            if (!DesignMode)
            {
                Control containerControl = new Control();
                switch (CurrentView)
                {
                    case 0:
                        if (View1 != null)
                            View1.InstantiateIn(containerControl);
                        break;
                    case 1:
                        if (View2 != null)
                            View2.InstantiateIn(containerControl);
                        break;
                }

                tc.Controls.Add(containerControl);
            }

            tr.Cells.Add(tc);

            t.Rows.Add(tr);

            // Add the finished table to the Controls collection
            Controls.Add(t);
        }
    }

    //---------------------------------------------------------
    // Region-based control designer for the above web control, 
    // derived from CompositeControlDesigner.
    public class MyMultiRegionControlDesigner : CompositeControlDesigner 
    {
        private MyMultiRegionControl myControl;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            myControl = (MyMultiRegionControl)component;
        }

        //<Snippet2>
        // Make this control resizeable on the design surface
        public override bool AllowResize
        {
            get
            {
                return true;
            }
        }
        //</Snippet2>

        //<Snippet3>
        // Use the base to create child controls, then add region markers
        protected override void CreateChildControls() {
            base.CreateChildControls();

            // Get a reference to the table, which is the first child control
            Table t = (Table)myControl.Controls[0];

            // Add design time markers for each of the three regions
            if (t != null)
            {
                // View1
                t.Rows[0].Cells[0].Attributes[DesignerRegion.DesignerRegionAttributeName] = "0";
                // View2
                t.Rows[0].Cells[1].Attributes[DesignerRegion.DesignerRegionAttributeName] = "1";
                // Editable region
                t.Rows[1].Cells[0].Attributes[DesignerRegion.DesignerRegionAttributeName] = "2";
            }
        }
        //</Snippet3>

        //<Snippet4>
        // Handler for the Click event, which provides the region in the arguments.
        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            if (e.Region == null)
                return;

            // If the clicked region is not a header, return
            if (e.Region.Name.IndexOf("Header") != 0)
                return;

            // Switch the current view if required
            if (e.Region.Name.Substring(6, 1) != myControl.CurrentView.ToString())
            {
                myControl.CurrentView = int.Parse(e.Region.Name.Substring(6, 1));
                base.UpdateDesignTimeHtml();
            }
        }
        //</Snippet4>

        //<Snippet5>
        // Create the regions and design-time markup. Called by the designer host.
        public override String GetDesignTimeHtml(DesignerRegionCollection regions) {
            // Create 3 regions: 2 clickable headers and an editable row
            regions.Add(new DesignerRegion(this, "Header0"));
            regions.Add(new DesignerRegion(this, "Header1"));

            // Create an editable region and add it to the regions
            EditableDesignerRegion editableRegion = 
                new EditableDesignerRegion(this, 
                    "Content" + myControl.CurrentView, false);
            regions.Add(editableRegion);

            // Set the highlight for the selected region
            regions[myControl.CurrentView].Highlight = true;

            // Use the base class to render the markup
            return base.GetDesignTimeHtml();
        }
        //</Snippet5>

        //<Snippet6>
        // Get the content string for the selected region. Called by the designer host?
        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region) 
        {
            // Get a reference to the designer host
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                ITemplate template = myControl.View1;
                if (region.Name == "Content1")
                    template = myControl.View2;

                // Persist the template in the design host
                if (template != null)
                    return ControlPersister.PersistTemplate(template, host);
            }

            return String.Empty;
        }
        //</Snippet6>

        //<Snippet7>
        // Create a template from the content string and  
        // put it in the selected view.
        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            if (content == null)
                return;

            // Get a reference to the designer host
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                // Create a template from the content string
                ITemplate template = ControlParser.ParseTemplate(host, content);

                // Determine which region should get the template
                // Either 'Content0' or 'Content1'
                if (region.Name.EndsWith("0"))
                    myControl.View1 = template;
                else if (region.Name.EndsWith("1"))
                    myControl.View2 = template;
            }
        }
        //</Snippet7>
    }
}
//</Snippet1>