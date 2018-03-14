//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class TreeViewOwnerDraw : Form
{
    private TreeView myTreeView;

    // Create a Font object for the node tags.
    Font tagFont = new Font("Helvetica", 8, FontStyle.Bold);

    //<Snippet2>
    public TreeViewOwnerDraw()
    {
        // Create and initialize the TreeView control.
        myTreeView = new TreeView();
        myTreeView.Dock = DockStyle.Fill;
        myTreeView.BackColor = Color.Tan;
        myTreeView.CheckBoxes = true;

        // Add nodes to the TreeView control.
        TreeNode node;
        for (int x = 1; x < 4; ++x)
        {
            // Add a root node to the TreeView control.
            node = myTreeView.Nodes.Add(String.Format("Task {0}", x));
            for (int y = 1; y < 4; ++y)
            {
                // Add a child node to the root node.
                node.Nodes.Add(String.Format("Subtask {0}", y));
            }
        }
        myTreeView.ExpandAll();

        // Add tags containing alert messages to a few nodes 
        // and set the node background color to highlight them.
        myTreeView.Nodes[1].Nodes[0].Tag = "urgent!";
        myTreeView.Nodes[1].Nodes[0].BackColor = Color.Yellow;
        myTreeView.SelectedNode = myTreeView.Nodes[1].Nodes[0];
        myTreeView.Nodes[2].Nodes[1].Tag = "urgent!";
        myTreeView.Nodes[2].Nodes[1].BackColor = Color.Yellow;

        // Configure the TreeView control for owner-draw and add
        // a handler for the DrawNode event.
        myTreeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
        myTreeView.DrawNode += 
            new DrawTreeNodeEventHandler(myTreeView_DrawNode);

        // Add a handler for the MouseDown event so that a node can be 
        // selected by clicking the tag text as well as the node text.
        myTreeView.MouseDown += new MouseEventHandler(myTreeView_MouseDown);

        // Initialize the form and add the TreeView control to it.
        this.ClientSize = new Size(292, 273);
        this.Controls.Add(myTreeView);
    }
    //</Snippet2>

    // Clean up any resources being used.        
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            tagFont.Dispose();
        }
        base.Dispose(disposing);
    }

    [STAThreadAttribute()]
    static void Main() 
    {
        Application.Run(new TreeViewOwnerDraw());
    }

    //<Snippet3>
    // Draws a node.
    private void myTreeView_DrawNode(
        object sender, DrawTreeNodeEventArgs e)
    {
        // Draw the background and node text for a selected node.
        if ((e.State & TreeNodeStates.Selected) != 0)
        {
            // Draw the background of the selected node. The NodeBounds
            // method makes the highlight rectangle large enough to
            // include the text of a node tag, if one is present.
            e.Graphics.FillRectangle(Brushes.Green, NodeBounds(e.Node));

            // Retrieve the node font. If the node font has not been set,
            // use the TreeView font.
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

            // Draw the node text.
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White,
                Rectangle.Inflate(e.Bounds, 2, 0));
        }

        // Use the default background and node text.
        else 
        {
            e.DrawDefault = true;
        }

        // If a node tag is present, draw its string representation 
        // to the right of the label text.
        if (e.Node.Tag != null)
        {
            e.Graphics.DrawString(e.Node.Tag.ToString(), tagFont,
                Brushes.Yellow, e.Bounds.Right + 2, e.Bounds.Top);
        }

        // If the node has focus, draw the focus rectangle large, making
        // it large enough to include the text of the node tag, if present.
        if ((e.State & TreeNodeStates.Focused) != 0)
        {
            using (Pen focusPen = new Pen(Color.Black))
            {
                focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                Rectangle focusBounds = NodeBounds(e.Node);
                focusBounds.Size = new Size(focusBounds.Width - 1, 
                focusBounds.Height - 1);
                e.Graphics.DrawRectangle(focusPen, focusBounds);
            }
        }
    }
    //</Snippet3>

    // Selects a node that is clicked on its label or tag text.
    private void myTreeView_MouseDown(object sender, MouseEventArgs e)
    {
        TreeNode clickedNode = myTreeView.GetNodeAt(e.X, e.Y);
        if (NodeBounds(clickedNode).Contains(e.X, e.Y))
        {
            myTreeView.SelectedNode = clickedNode;
        }
    }

    // Returns the bounds of the specified node, including the region 
    // occupied by the node label and any node tag displayed.
    private Rectangle NodeBounds(TreeNode node)
    {
        // Set the return value to the normal node bounds.
        Rectangle bounds = node.Bounds;
        if (node.Tag != null)
        {
            // Retrieve a Graphics object from the TreeView handle
            // and use it to calculate the display width of the tag.
            Graphics g = myTreeView.CreateGraphics(); 
            int tagWidth = (int)g.MeasureString
                (node.Tag.ToString(), tagFont).Width + 6;

            // Adjust the node bounds using the calculated value.
            bounds.Offset(tagWidth/2, 0);
            bounds = Rectangle.Inflate(bounds, tagWidth/2, 0);
            g.Dispose();
         }
        
        return bounds;
        
    }

}
//</Snippet1>