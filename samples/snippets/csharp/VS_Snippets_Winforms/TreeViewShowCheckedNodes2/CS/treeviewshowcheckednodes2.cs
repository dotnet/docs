//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    private TreeView treeView1;
    private Button showCheckedNodesButton;
    private TreeViewCancelEventHandler checkForCheckedChildren;

    public Form1()
    {
        treeView1 = new TreeView();
        showCheckedNodesButton = new Button();
        checkForCheckedChildren = 
            new TreeViewCancelEventHandler(CheckForCheckedChildrenHandler);

        this.SuspendLayout();

        // Initialize treeView1.
        treeView1.Location = new Point(0, 25);
        treeView1.Size = new Size(292, 248);
        treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | 
            AnchorStyles.Bottom | AnchorStyles.Right;
        treeView1.CheckBoxes = true;

        // Add nodes to treeView1.
        TreeNode node;
        for (int x = 0; x < 3; ++x)
        {
            // Add a root node.
            node = treeView1.Nodes.Add(String.Format("Node{0}", x*4));
            for (int y = 1; y < 4; ++y)
            {
                // Add a node as a child of the previously added node.
                node = node.Nodes.Add(String.Format("Node{0}", x*4 + y));
            }
        }

        // Set the checked state of one of the nodes to
        // demonstrate the showCheckedNodesButton button behavior.
        treeView1.Nodes[1].Nodes[0].Nodes[0].Checked = true;

        // Initialize showCheckedNodesButton.
        showCheckedNodesButton.Size = new Size(144, 24);
        showCheckedNodesButton.Text = "Show Checked Nodes";
        showCheckedNodesButton.Click += 
            new EventHandler(showCheckedNodesButton_Click);

        // Initialize the form.
        this.ClientSize = new Size(292, 273);
        this.Controls.AddRange(new Control[] 
            { showCheckedNodesButton, treeView1 } );

        this.ResumeLayout(false);
    }

    [STAThreadAttribute()]
    static void Main() 
    {
        Application.Run(new Form1());
    }

    //<Snippet2>
    private void showCheckedNodesButton_Click(object sender, EventArgs e)
    {
        // Disable redrawing of treeView1 to prevent flickering 
        // while changes are made.
        treeView1.BeginUpdate();

        // Collapse all nodes of treeView1.
        treeView1.ExpandAll();

        // Add the checkForCheckedChildren event handler to the BeforeExpand event.
        treeView1.BeforeCollapse += checkForCheckedChildren;

        // Expand all nodes of treeView1. Nodes without checked children are 
        // prevented from expanding by the checkForCheckedChildren event handler.
        treeView1.CollapseAll();

        // Remove the checkForCheckedChildren event handler from the BeforeExpand 
        // event so manual node expansion will work correctly.
        treeView1.BeforeCollapse -= checkForCheckedChildren;

        // Enable redrawing of treeView1.
        treeView1.EndUpdate();
    }

    // Prevent collapse of a node that has checked child nodes.
    private void CheckForCheckedChildrenHandler(object sender, 
        TreeViewCancelEventArgs e)
    {
        if (HasCheckedChildNodes(e.Node)) e.Cancel = true;
    }

    // Returns a value indicating whether the specified 
    // TreeNode has checked child nodes.
    private bool HasCheckedChildNodes(TreeNode node)
    {
        if (node.Nodes.Count == 0) return false;
        foreach (TreeNode childNode in node.Nodes)
        {
            if (childNode.Checked) return true;
            // Recursively check the children of the current child node.
            if (HasCheckedChildNodes(childNode)) return true;
        }
        return false;
    }
    //</Snippet2>

}
//</Snippet1>