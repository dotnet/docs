using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

//Create a Class that inherits from System.Windows.Forms.Form. 
class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        //InitializeStatefulTreeView();
        //InitializeTreeViewWithToolTips();
        InitializeTreeView1();
        treeView1.MouseDown += new MouseEventHandler(treeView1_MouseDown);
        treeView1.NodeMouseClick +=  
          new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
         treeView1.NodeMouseDoubleClick += 
            new TreeNodeMouseClickEventHandler(treeView1_NodeMouseDoubleClick);
        treeView1.NodeMouseHover += new TreeNodeMouseHoverEventHandler(treeView1_NodeMouseHover);
        //InitializeLineTreeView();
    }

    
    // <snippet1>
    // Declare the TreeView.
    private TreeView treeView1;
    private TextBox textBox1;
    private Button button1;

    private void InitializeTreeView1()
    {
        // Create the TreeView
        treeView1 = new TreeView();
        treeView1.Size = new Size(200, 200);

        // Create the button and set some basic properties. 
        button1 = new Button();
        button1.Location = new Point(205, 138);
        button1.Text = "Set Sorter";

        // Handle the click event for the button.
        button1.Click += new EventHandler(button1_Click);

        // Create the root nodes.
        TreeNode docNode = new TreeNode("Documents");
        TreeNode spreadSheetNode = new TreeNode("Spreadsheets");

        // Add some additional nodes.
        spreadSheetNode.Nodes.Add("payroll.xls");
        spreadSheetNode.Nodes.Add("checking.xls");
        spreadSheetNode.Nodes.Add("tracking.xls");
        docNode.Nodes.Add("phoneList.doc");
        docNode.Nodes.Add("resume.doc");

        // Add the root nodes to the TreeView.
        treeView1.Nodes.Add(spreadSheetNode);
        treeView1.Nodes.Add(docNode);

        // Add the TreeView to the form.
        Controls.Add(treeView1);
        Controls.Add(button1);
    }

    // Set the TreeViewNodeSorter property to a new instance
    // of the custom sorter.
    private void button1_Click(object sender, EventArgs e)
    {
        treeView1.TreeViewNodeSorter = new NodeSorter();
    }

    // Create a node sorter that implements the IComparer interface.
    public class NodeSorter : IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            // Compare the length of the strings, returning the difference.
            if (tx.Text.Length != ty.Text.Length)
                return tx.Text.Length - ty.Text.Length;

            // If they are the same length, call Compare.
            return string.Compare(tx.Text, ty.Text);
        }
    }
    // </snippet1>

    // The following code example demonstrates setting the TreeNode line color.
    // To run this example, paste the code into a Windows Form. Call 
    // InitializeLineTreeView from the form's constructor or Load
    // event handling method.
    // <snippet2>
    private TreeView lineTreeView;
    public void InitializeLineTreeView()
    {
        lineTreeView = new TreeView();
        lineTreeView.Size = new Size(200, 200);

        lineTreeView.LineColor = Color.Red;

        // Create the root nodes.
        TreeNode docNode = new TreeNode("Documents");
       
        // Add some additional nodes.
        docNode.Nodes.Add("phoneList.doc");
        docNode.Nodes.Add("resume.doc");
        
        lineTreeView.Nodes.Add(docNode);
        Controls.Add(lineTreeView);
    }
    // </snippet2>

    [STAThreadAttribute]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    private void InitializeComponent()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
// 
// textBox1
// 
        this.textBox1.Location = new System.Drawing.Point(180, 93);
        this.textBox1.Name = "textBox1";
        this.textBox1.TabIndex = 0;
// 
// Form1
// 
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.Add(this.textBox1);
        this.Name = "Form1";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

   

    // The following example code demonstrates how to use the TreeNode.Level, 
    // TreeViewHitTestInfo.Node and TreeView.HitTest members.
    // To run this example create a Windows Form that contains a TreeView 
    // named treeView1 and populate it with several levels of nodes.
    // Paste the following code into the form and associate the MouseDown
    // event of treeView1 with the treeView1_MouseDown method in this example. 
//<snippet3>
    void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        TreeViewHitTestInfo info = treeView1.HitTest(e.X, e.Y);
        TreeNode hitNode;
        if (info.Node != null) {
            hitNode = info.Node;
            MessageBox.Show(hitNode.Level.ToString());
        }
    }
//</snippet3>




// The following example demonstrates how to handle the NodeMouseClick event.

//<snippet4>
    void treeView1_NodeMouseClick(object sender,  
        TreeNodeMouseClickEventArgs e)
    {
        textBox1.Text = e.Node.Text;
    }
    
//</snippet4>

    // The following example demonstrates how to handle the NodeMouseDoubleClick 
    // event and how to use the TreeNodeMouseClickEventArgs.
    // To run this example, paste the code into a Windows Form that contains a 
    // TreeView named treeView1. Populate the treeView1 with the names of files 
    // located in the c:\ directly of the system the sample is running on, and associate
    // the NodeMouseDoubleClick event of treeView1 with the treeView1_NodeMouseDoubleClick
    // method in this example.
    
    //<snippet5>
    // If a node is double-clicked, open the file indicated by the TreeNode.
    void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        try
        {
            // Look for a file extension.
            if (e.Node.Text.Contains("."))
                System.Diagnostics.Process.Start(@"c:\" + e.Node.Text);
        }
            // If the file is not found, handle the exception and inform the user.
        catch (System.ComponentModel.Win32Exception)
        {
            MessageBox.Show("File not found.");
        }
    }
    //</snippet5>

    // The following example demonstrates how to handle the
    // NodeMouseHover event.
    // <snippet6>
    void treeView1_NodeMouseHover(object sender,  
        TreeNodeMouseHoverEventArgs e)
    {
        e.Node.Toggle();
    }

    // </snippet6>

    // The following code example demonstrates how to use the ToolTipText
    // and ShowNodeToolTips members.  To run this example, paste
    // the following code into a Windows Form and call 
    // InitializeTreeViewWithToolTips from the form's constructor
    // or Load event-handling method.
    // <snippet7>
    TreeView treeViewWithToolTips;
    private void InitializeTreeViewWithToolTips()
    {
        treeViewWithToolTips = new TreeView();
        TreeNode node1 = new TreeNode("Node1");
        node1.ToolTipText = "Help for Node1";
        TreeNode node2 = new TreeNode("Node2");
        node2.ToolTipText = "A Tip for Node2";
        treeViewWithToolTips.Nodes.AddRange(new TreeNode[] { node1, node2 });
        treeViewWithToolTips.ShowNodeToolTips = true;
        this.Controls.Add(treeViewWithToolTips);

    }
    // </snippet7>

    // The following code example demonstrates the StateImageList 
    // property. To run this example, paste the code into a Windows
    // Form and call InitializeCheckTreeView from the form's 
    // constructor or Load event-handling method.
    // <snippet8>
    TreeView checkTreeView;
    private void InitializeCheckTreeView()
    {
        checkTreeView = new TreeView();
        
        // Show check boxes for the TreeView. This
        // will cause the StateImageList to be used.
        checkTreeView.CheckBoxes = true;

        // Create the StateImageList and add two images.
        checkTreeView.StateImageList = new ImageList();
        checkTreeView.StateImageList.Images.Add(SystemIcons.Question);
        checkTreeView.StateImageList.Images.Add(SystemIcons.Exclamation);
        
        // Add some nodes to the TreeView and the TreeView to the form.
        checkTreeView.Nodes.Add("Node1");
        checkTreeView.Nodes.Add("Node2");
        this.Controls.Add(checkTreeView);
    }
    //</snippet8>
}
