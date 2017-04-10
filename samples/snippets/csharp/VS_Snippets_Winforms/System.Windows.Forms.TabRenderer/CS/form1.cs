// This entire sample can go in the TabRenderer overview. 
//  - Snippet2 can be excerpted in DrawTabPage, DrawTabItem, and IsSupported.
//  - Snippet2 could also be excerpted in the VisualStyles.TabItemState enum,
//    if necessary.

// The sample defines a simple custom Control that uses TabRenderer to
// simulate a basic (and essentially useless) TabControl. Might want
// to add a bit more unique functionality, although the basic painting 
// functionality of the class is demonstrated.

// For simplicity, this sample doesn't handle runtime switching of visual styles.


//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TabRendererSample
{
    class Form1 : Form
    {
        public Form1()
            : base()
        {
            CustomTabControl Tab1 = new CustomTabControl();
            Controls.Add(Tab1);
            this.Size = new Size(500, 500);
        }

        [STAThread]
        static void Main()
        {
            // The call to EnableVisualStyles below does not affect whether 
            // TabRenderer.IsSupported is true; as long as visual styles 
            // are enabled by the operating system, IsSupported is true.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class CustomTabControl : Control
    {
        private Rectangle tabPageRectangle;
        private Rectangle tabItemRectangle1;
        private Rectangle tabItemRectangle2;
        private int tabHeight = 30;
        private int tabWidth = 100;
        private TabItemState tab1State = TabItemState.Selected;
        private TabItemState tab2State = TabItemState.Normal;
        private string tab1Text = "Tab 1";
        private string tab2Text = "Tab 2";
        private bool tab1Focused = true;
        private bool tab2Focused = false;

        public CustomTabControl()
            : base()
        {
            this.Size = new Size(300, 300);
            this.Location = new Point(10, 10);
            this.Font = SystemFonts.IconTitleFont;
            this.Text = "TabRenderer";
            this.DoubleBuffered = true;

            tabPageRectangle = new Rectangle(ClientRectangle.X,
                ClientRectangle.Y + tabHeight,
                ClientRectangle.Width,
                ClientRectangle.Height - tabHeight);

            // Extend the first tab rectangle down by 2 pixels, 
            // because it is selected by default.
            tabItemRectangle1 = new Rectangle(ClientRectangle.X,
                ClientRectangle.Y, tabWidth, tabHeight + 2);

            tabItemRectangle2 = new Rectangle(ClientRectangle.Location.X +
                tabWidth, ClientRectangle.Location.Y, tabWidth, tabHeight);
        }

        //<Snippet2>
        // Draw the tab page and the tab items.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!TabRenderer.IsSupported)
            {
                this.Parent.Text = "CustomTabControl Disabled";
                return;
            }

            TabRenderer.DrawTabPage(e.Graphics, tabPageRectangle);
            TabRenderer.DrawTabItem(e.Graphics, tabItemRectangle1,
                tab1Text, this.Font, tab1Focused, tab1State);
            TabRenderer.DrawTabItem(e.Graphics, tabItemRectangle2,
                tab2Text, this.Font, tab2Focused, tab2State);

            this.Parent.Text = "CustomTabControl Enabled";
        }
        //</Snippet2>

        // Draw the selected tab item.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!TabRenderer.IsSupported)
                return;

            // The first tab is clicked. Note that the height of the 
            // selected tab rectangle is raised by 2, so that it draws 
            // over the border of the tab page.
            if (tabItemRectangle1.Contains(e.Location))
            {
                tab1State = TabItemState.Selected;
                tab2State = TabItemState.Normal;
                tabItemRectangle1.Height += 2;
                tabItemRectangle2.Height -= 2;
                tab1Focused = true;
                tab2Focused = false;
            }

            // The second tab is clicked.
            if (tabItemRectangle2.Contains(e.Location))
            {
                tab2State = TabItemState.Selected;
                tab1State = TabItemState.Normal;
                tabItemRectangle2.Height += 2;
                tabItemRectangle1.Height -= 2;
                tab2Focused = true;
                tab1Focused = false;
            }

            Invalidate();
        }
    }
}
//</Snippet0>
