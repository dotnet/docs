using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class Form1 : System.Windows.Forms.Form
{
    // use MySplitContainer to replicate 3.5 behavior
    //private MySplitContainer splitContainer2;
    private SplitContainer splitContainer2;

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.ListView listView2;
    private System.Windows.Forms.ListView listView1;

    public Form1()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        splitContainer1 = new System.Windows.Forms.SplitContainer();
        treeView1 = new System.Windows.Forms.TreeView();
        splitContainer2 = new MySplitContainer();
        listView1 = new System.Windows.Forms.ListView();
        listView2 = new System.Windows.Forms.ListView();
        splitContainer1.SuspendLayout();
        splitContainer2.SuspendLayout();
        SuspendLayout();

        // Basic SplitContainer properties.
        // This is a vertical splitter that moves in 10-pixel increments.
        // This splitter needs no explicit Orientation property because Vertical is the default.
        splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        splitContainer1.ForeColor = System.Drawing.SystemColors.Control;
        splitContainer1.Location = new System.Drawing.Point(0, 0);
        splitContainer1.Name = "splitContainer1";

        // You can drag the splitter no nearer than 30 pixels from the left edge of the container.
        splitContainer1.Panel1MinSize = 30;

        // You can drag the splitter no nearer than 20 pixels from the right edge of the container.
        splitContainer1.Panel2MinSize = 20;
        splitContainer1.Size = new System.Drawing.Size(292, 273);
        splitContainer1.SplitterDistance = 79;

        // This splitter moves in 10-pixel increments.
        splitContainer1.SplitterIncrement = 10;
        splitContainer1.SplitterWidth = 6;

        // splitContainer1 is the first control in the tab order.
        splitContainer1.TabIndex = 0;
        splitContainer1.Text = "splitContainer1";

        // When the splitter moves, the cursor changes shape.
        splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(splitContainer1_SplitterMoved);
        splitContainer1.SplitterMoving += new System.Windows.Forms.SplitterCancelEventHandler(splitContainer1_SplitterMoving);

        // Add a TreeView control to the left panel.
        splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;

        // Add a TreeView control to Panel1.
        splitContainer1.Panel1.Controls.Add(treeView1);
        splitContainer1.Panel1.Name = "splitterPanel1";

        // Controls placed on Panel1 support right-to-left fonts.
        splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;


        // Add a SplitContainer to the right panel.
        splitContainer1.Panel2.Controls.Add(splitContainer2);
        splitContainer1.Panel2.Name = "splitterPanel2";

        // This TreeView control is in Panel1 of splitContainer1.
        treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
        treeView1.ForeColor = System.Drawing.SystemColors.InfoText;
        treeView1.ImageIndex = -1;
        treeView1.Location = new System.Drawing.Point(0, 0);
        treeView1.Name = "treeView1";
        treeView1.SelectedImageIndex = -1;
        treeView1.Size = new System.Drawing.Size(79, 273);

        treeView1.BeginUpdate();
        treeView1.Nodes.Add("Parent");
        treeView1.Nodes[0].Nodes.Add("Child 1");
        treeView1.Nodes[0].Nodes.Add("Child 2");
        treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
        treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
        treeView1.EndUpdate();

        // treeView1 is the second control in the tab order.
        treeView1.TabIndex = 1;

        // Basic SplitContainer properties.
        // This is a horizontal splitter whose top and bottom panels are ListView controls. The top panel is fixed.
        splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;

        // The top panel remains the same size when the form is resized.
        splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        splitContainer2.Location = new System.Drawing.Point(0, 0);
        splitContainer2.Name = "splitContainer2";

        // Create the horizontal splitter.
        splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
        splitContainer2.Size = new System.Drawing.Size(207, 273);
        splitContainer2.SplitterDistance = 125;
        splitContainer2.SplitterWidth = 6;

        // splitContainer2 is the third control in the tab order.
        //splitContainer2.TabIndex = 2;
        splitContainer2.TabStop = false;
        splitContainer2.Text = "splitContainer2";

        // This splitter panel contains the top ListView control.
        splitContainer2.Panel1.Controls.Add(listView1);
        splitContainer2.Panel1.Name = "splitterPanel3";

        // This splitter panel contains the bottom ListView control.
        splitContainer2.Panel2.Controls.Add(listView2);
        splitContainer2.Panel2.Name = "splitterPanel4";

        // This ListView control is in the top panel of splitContainer2.
        listView1.Dock = System.Windows.Forms.DockStyle.Fill;
        listView1.Location = new System.Drawing.Point(0, 0);
        listView1.Name = "listView1";
        listView1.Size = new System.Drawing.Size(207, 125);
        listView1.View = View.Details;

        // Display grid lines.
        listView1.GridLines = true;


        // Create three items and three sets of subitems for each item.
        ListViewItem item1 = new ListViewItem("item1", 0);
        // Place a check mark next to the item.
        item1.Checked = true;
        item1.SubItems.Add("1");
        item1.SubItems.Add("2");
        item1.SubItems.Add("3");
        ListViewItem item2 = new ListViewItem("item2", 1);
        item2.SubItems.Add("4");
        item2.SubItems.Add("5");
        item2.SubItems.Add("6");
        ListViewItem item3 = new ListViewItem("item3", 0);
        // Place a check mark next to the item.
        item3.Checked = true;
        item3.SubItems.Add("7");
        item3.SubItems.Add("8");
        item3.SubItems.Add("9");

        // Create columns for the items and subitems.
        // Width of -2 indicates auto-size.
        listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
        listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
        listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
        listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

        //Add the items to the ListView.
        listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

        // listView1 is the fourth control in the tab order.
        listView1.TabIndex = 3;

        // This ListView control is in the bottom panel of splitContainer2.
        listView2.Dock = System.Windows.Forms.DockStyle.Fill;
        listView2.Location = new System.Drawing.Point(0, 0);
        listView2.Name = "listView2";
        listView2.Size = new System.Drawing.Size(207, 142);
        listView2.View = View.Details;

        // Display grid lines.
        listView2.GridLines = true;


        // Create three items and three sets of subitems for each item.
        item1 = new ListViewItem("item1", 0);
        // Place a check mark next to the item.
        item1.Checked = true;
        item1.SubItems.Add("1");
        item1.SubItems.Add("2");
        item1.SubItems.Add("3");
        item2 = new ListViewItem("item2", 1);
        item2.SubItems.Add("4");
        item2.SubItems.Add("5");
        item2.SubItems.Add("6");

        item3 = new ListViewItem("item3", 0);
        // Place a check mark next to the item.
        item3.Checked = true;
        item3.SubItems.Add("7");
        item3.SubItems.Add("8");
        item3.SubItems.Add("9");

        // Create columns for the items and subitems.
        // Width of -2 indicates auto-size.
        listView2.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
        listView2.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
        listView2.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
        listView2.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

        //Add the items to the ListView.
        listView2.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

        // listView2 is the fifth control in the tab order.
        listView2.TabIndex = 4;

        // These are basic properties of the form.
        //ClientSize = new System.Drawing.Size(292, 273);
        this.WindowState = FormWindowState.Maximized;
        Controls.Add(splitContainer1);
        Name = "Form1";
        Text = "Form1";
        splitContainer1.ResumeLayout(false);
        splitContainer2.ResumeLayout(false);
        ResumeLayout(false);
    }

    [STAThread]
    static void Main()
    {
        Application.Run(new Form1());
    }
    private void splitContainer1_SplitterMoving(System.Object sender, System.Windows.Forms.SplitterCancelEventArgs e)
    {
        // As the splitter moves, change the cursor type.
        Cursor.Current = System.Windows.Forms.Cursors.NoMoveVert;
    }
    private void splitContainer1_SplitterMoved(System.Object sender, System.Windows.Forms.SplitterEventArgs e)
    {
        // When the splitter stops moving, change the cursor back to the default.
        Cursor.Current = System.Windows.Forms.Cursors.Default;
    }
}

//<Snippet1>
public class MySplitContainer : SplitContainer
{
    private bool tabStop = true;
    public new bool TabStop
    {
        get
        {
            return tabStop;
        }
        set
        {
            if (TabStop != value)
            {
                tabStop = value;
                OnTabStopChanged(EventArgs.Empty);
            }
        }
    }

    protected override bool ProcessTabKey(bool forward)
    {
        if (!tabStop)
        {
            if (SelectNextControl(ActiveControl, forward, true, true, false)) return true;
        }
        return base.ProcessTabKey(forward);
    }
}
//</Snippet1>
