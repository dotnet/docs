//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChartControl
{
    public class Form1 : System.Windows.Forms.Form
    {
        // Test out the Chart Control.
        private ChartControl chart1;

        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        public Form1() {
            // Create a chart control and add it to the form.
            this.chart1 = new ChartControl();
            this.ClientSize = new System.Drawing.Size(920, 566);

            this.chart1.Location = new System.Drawing.Point(47, 16);
            this.chart1.Size = new System.Drawing.Size(600, 400);

            this.Controls.Add(this.chart1);
        }
    }

    // Declare a chart control that demonstrates accessibility in Windows Forms.
    public class ChartControl : System.Windows.Forms.UserControl
    {
        private CurveLegend legend1;
        private CurveLegend legend2; 

        public ChartControl()
        {
            // The ChartControl draws the chart in the OnPaint override.
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            this.BackColor = System.Drawing.Color.White;
            this.Name = "ChartControl";

            this.Click += new System.EventHandler(this.ChartControl_Click);
            this.QueryAccessibilityHelp += 
                new System.Windows.Forms.QueryAccessibilityHelpEventHandler(
                                        this.ChartControl_QueryAccessibilityHelp);

            // The CurveLengend is not Control-based, it just
            // represents the parts of the legend.
            legend1 = new CurveLegend(this, "A");
            legend1.Location = new Point(20, 30);
            legend2 = new CurveLegend(this, "B");        
            legend2.Location = new Point(20, 50);
        }

        //<Snippet2>
        // Overridden to return the custom AccessibleObject 
        // for the entire chart.
        protected override AccessibleObject CreateAccessibilityInstance() 
        {            
            return new ChartControlAccessibleObject(this);
        }
        //</Snippet2>

        protected override void OnPaint(PaintEventArgs e) 
        {
            // The ChartControl draws the chart in the OnPaint override.
            base.OnPaint(e);

            Rectangle bounds = this.ClientRectangle;
            int border = 5;

            // Draws the legends first.
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            
            if (legend1 != null) {
                if (legend1.Selected) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Blue), legend1.Bounds);
                } else {
                    e.Graphics.DrawRectangle(Pens.Blue, legend1.Bounds);
                }

                e.Graphics.DrawString(legend1.Name, this.Font, Brushes.Black, legend1.Bounds, format);                
            }
            if (legend2 != null) {
                if (legend2.Selected) {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), legend2.Bounds);
                } else {
                    e.Graphics.DrawRectangle(Pens.Red, legend2.Bounds);
                }
                e.Graphics.DrawString(legend2.Name, this.Font, Brushes.Black, legend2.Bounds, format);
            }            

            // Charts out the actual curves that represent data in the Chart.
            bounds.Inflate(-border, -border);
            Point[] curve1 = new Point[] {new Point(bounds.Left, bounds.Bottom),
                            new Point(bounds.Left + bounds.Width / 3, bounds.Top + bounds.Height / 5),
                            new Point(bounds.Right - bounds.Width / 3, (bounds.Top + bounds.Bottom) / 2),
                            new Point(bounds.Right, bounds.Top)};

            Point[] curve2 = new Point[] {new Point(bounds.Left, bounds.Bottom - bounds.Height / 3),
                            new Point(bounds.Left + bounds.Width / 3, bounds.Top + bounds.Height / 5),
                            new Point(bounds.Right - bounds.Width / 3, (bounds.Top + bounds.Bottom) / 2),
                            new Point(bounds.Right, bounds.Top + bounds.Height / 2)};

            // Draws the actual curve only if it is selected.
            if (legend1.Selected) e.Graphics.DrawCurve(Pens.Blue, curve1);
            if (legend2.Selected) e.Graphics.DrawCurve(Pens.Red, curve2);

            e.Graphics.DrawRectangle(Pens.Blue, bounds);            
        }

        //<Snippet3>
        // Handles the QueryAccessibilityHelp event.
        private void ChartControl_QueryAccessibilityHelp(object sender, 
                                    System.Windows.Forms.QueryAccessibilityHelpEventArgs e)
        {            
            e.HelpString = "Displays chart data";
        }          
        //</Snippet3>

        // Handles the Click event for the chart. 
        // Toggles the selection of whatever legend was clicked on
        private void ChartControl_Click(object sender, System.EventArgs e)
        {
            Point pt = this.PointToClient(Control.MousePosition);
            if (legend1.Bounds.Contains(pt)) {
                legend1.Selected = !legend1.Selected;

            } else if (legend2.Bounds.Contains(pt)) {
                legend2.Selected = !legend2.Selected;
            }
        }

        // Gets an array of CurveLengends used in the Chart.
        public CurveLegend[] Legends
        {   
            get {                
                return new CurveLegend[] { legend1, legend2 };
            }            
        }                

        //<Snippet4>
        // Inner class ChartControlAccessibleObject represents accessible information associated with the ChartControl.
        // The ChartControlAccessibleObject is returned in the ChartControl.CreateAccessibilityInstance override.
        public class ChartControlAccessibleObject : ControlAccessibleObject
        {
            ChartControl chartControl;

            public ChartControlAccessibleObject(ChartControl ctrl) : base(ctrl) 
            {
                chartControl = ctrl;
            }

            // Gets the role for the Chart. This is used by accessibility programs.
            public override AccessibleRole Role
            {  
                get {
                    return AccessibleRole.Chart;
                }
            }

            // Gets the state for the Chart. This is used by accessibility programs.
            public override AccessibleStates State
            {  
                get {                    
                    return AccessibleStates.ReadOnly;
                }
            }

            // The CurveLegend objects are "child" controls in terms of accessibility so 
            // return the number of ChartLengend objects.
            public override int GetChildCount()
            {  
                return chartControl.Legends.Length;
            }

            // Gets the Accessibility object of the child CurveLegend idetified by index.
            public override AccessibleObject GetChild(int index)
            {  
                if (index >= 0 && index < chartControl.Legends.Length) {
                    return chartControl.Legends[index].AccessibilityObject;
                }                
                return null;
            }

            // Helper function that is used by the CurveLegend's accessibility object
            // to navigate between sibiling controls. Specifically, this function is used in
            // the CurveLegend.CurveLegendAccessibleObject.Navigate function.
            internal AccessibleObject NavigateFromChild(CurveLegend.CurveLegendAccessibleObject child, 
                                                        AccessibleNavigation navdir) 
            {  
                switch(navdir) {
                    case AccessibleNavigation.Down:
                    case AccessibleNavigation.Next:
                        return GetChild(child.ID + 1);
                        
                    case AccessibleNavigation.Up:
                    case AccessibleNavigation.Previous:
                        return GetChild(child.ID - 1);                        
                }
                return null;
            }

            // Helper function that is used by the CurveLegend's accessibility object
            // to select a specific CurveLegend control. Specifically, this function is used
            // in the CurveLegend.CurveLegendAccessibleObject.Select function.
            internal void SelectChild(CurveLegend.CurveLegendAccessibleObject child, AccessibleSelection selection) 
            {   
                int childID = child.ID;

                // Determine which selection action should occur, based on the
                // AccessibleSelection value.
                if ((selection & AccessibleSelection.TakeSelection) != 0) {
                    for(int i = 0; i < chartControl.Legends.Length; i++) {
                        if (i == childID) {
                            chartControl.Legends[i].Selected = true;                        
                        } else {
                            chartControl.Legends[i].Selected = false;
                        }
                    }

                    // AccessibleSelection.AddSelection means that the CurveLegend will be selected.
                    if ((selection & AccessibleSelection.AddSelection) != 0) {
                        chartControl.Legends[childID].Selected = true;                        
                    }

                    // AccessibleSelection.AddSelection means that the CurveLegend will be unselected.
                    if ((selection & AccessibleSelection.RemoveSelection) != 0) {
                        chartControl.Legends[childID].Selected = false;                        
                    }
                }            
            }
        }
        //</Snippet4>

        // Inner Class that represents a legend for a curve in the chart.
        public class CurveLegend 
        {
            private string name;
            private ChartControl chart;
            private CurveLegendAccessibleObject accObj;
            private bool selected = true;
            private Point location;

            public CurveLegend(ChartControl chart, string name) 
            {
                this.chart = chart;
                this.name = name;
            }

            // Gets the accessibility object for the curve legend.
            public AccessibleObject AccessibilityObject
            {
                get {
                    if (accObj == null) {
                        accObj = new CurveLegendAccessibleObject(this);
                    }
                    return accObj;
                }
            }
            
            // Gets the bounds for the curve legend.
            public Rectangle Bounds
            {   
                get {
                    return new Rectangle(Location, Size);
                }
            }

            //<Snippet5>
            // Gets or sets the location for the curve legend.
            public Point Location
            {   
                get {
                    return location;
                }
                set {
                    location = value;
                    chart.Invalidate();

                    // Notifies the chart of the location change. This is used for
                    // the accessibility information. AccessibleEvents.LocationChange
                    // tells the chart the reason for the notification.

                    chart.AccessibilityNotifyClients(AccessibleEvents.LocationChange, 
                        ((CurveLegendAccessibleObject)AccessibilityObject).ID);
                }
            }            
        
            // Gets or sets the Name for the curve legend.
            public string Name
            {   
                get {
                    return name;
                }
                set {
                    if (name != value) 
                    {
                        name = value;
                        chart.Invalidate();

                        // Notifies the chart of the name change. This is used for
                        // the accessibility information. AccessibleEvents.NameChange
                        // tells the chart the reason for the notification.

                        chart.AccessibilityNotifyClients(AccessibleEvents.NameChange, 
                            ((CurveLegendAccessibleObject)AccessibilityObject).ID);
                    }
                }
            }

            // Gets or sets the Selected state for the curve legend.
            public bool Selected
            {   
                get {
                    return selected;
                }
                set {
                    if (selected != value) 
                    {
                        selected = value;
                        chart.Invalidate();

                        // Notifies the chart of the selection value change. This is used for
                        // the accessibility information. The AccessibleEvents value depends upon
                        // if the selection is true (AccessibleEvents.SelectionAdd) or 
                        // false (AccessibleEvents.SelectionRemove).
                        chart.AccessibilityNotifyClients(
                            selected ? AccessibleEvents.SelectionAdd : AccessibleEvents.SelectionRemove, 
                            ((CurveLegendAccessibleObject)AccessibilityObject).ID);
                    }
                }
            }
            //</Snippet5>

            // Gets the Size for the curve legend.
            public Size Size
            {   
                get {                    
                    int legendHeight = chart.Font.Height + 4;
                    Graphics g = chart.CreateGraphics();
                    int legendWidth = (int)g.MeasureString(Name, chart.Font).Width + 4;            

                    return new Size(legendWidth, legendHeight);
                }
            }
    
            //<Snippet6>
            // Inner class CurveLegendAccessibleObject represents accessible information 
            // associated with the CurveLegend object.
            public class CurveLegendAccessibleObject : AccessibleObject
            {
                private CurveLegend curveLegend;

                public CurveLegendAccessibleObject(CurveLegend curveLegend) : base() 
                {
                    this.curveLegend = curveLegend;                    
                }                

                // Private property that helps get the reference to the parent ChartControl.
                private ChartControlAccessibleObject ChartControl
                {   
                    get {
                        return Parent as ChartControlAccessibleObject;
                    }
                }

                // Internal helper function that returns the ID for this CurveLegend.
                internal int ID
                {
                    get {
                        for(int i = 0; i < ChartControl.GetChildCount(); i++) {
                            if (ChartControl.GetChild(i) == this) {
                                return i;
                            }
                        }
                        return -1;
                    }
                }

                // Gets the Bounds for the CurveLegend. This is used by accessibility programs.
                public override Rectangle Bounds
                {
                    get {                        
                        // The bounds is in screen coordinates.
                        Point loc = curveLegend.Location;
                        return new Rectangle(curveLegend.chart.PointToScreen(loc), curveLegend.Size);
                    }
                }

                // Gets or sets the Name for the CurveLegend. This is used by accessibility programs.
                public override string Name
                {
                    get {
                        return curveLegend.Name;
                    }
                    set {
                        curveLegend.Name = value;                        
                    }
                }

                // Gets the Curve Legend Parent's Accessible object.
                // This is used by accessibility programs.
                public override AccessibleObject Parent
                {
                    get {
                        return curveLegend.chart.AccessibilityObject;
                    }
                }

                // Gets the role for the CurveLegend. This is used by accessibility programs.
                public override AccessibleRole Role 
                {
                    get {
                        return AccessibleRole.StaticText;
                    }
                }

                // Gets the state based on the selection for the CurveLegend. 
                // This is used by accessibility programs.
                public override AccessibleStates State 
                {
                    get {
                        AccessibleStates state = AccessibleStates.Selectable;
                        if (curveLegend.Selected) 
                        {
                            state |= AccessibleStates.Selected;
                        }
                        return state;
                    }
                }

                // Navigates through siblings of this CurveLegend. This is used by accessibility programs.
                public override AccessibleObject Navigate(AccessibleNavigation navdir) 
                {
                    // Uses the internal NavigateFromChild helper function that exists
                    // on ChartControlAccessibleObject.
                    return ChartControl.NavigateFromChild(this, navdir);
                }

                // Selects or unselects this CurveLegend. This is used by accessibility programs.
                public override void Select(AccessibleSelection selection) 
                {
                    // Uses the internal SelectChild helper function that exists
                    // on ChartControlAccessibleObject.
                    ChartControl.SelectChild(this, selection);
                }
            }
            //</Snippet6>
        }
    }
}
//</Snippet1>