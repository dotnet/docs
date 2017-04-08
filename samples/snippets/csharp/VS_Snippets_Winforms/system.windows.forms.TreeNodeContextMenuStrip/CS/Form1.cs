using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

//Create a Class that inherits from System.Windows.Forms.Form. 
class myForm : Form
{
    public myForm()
    {
        InitializeComponent();
        InitializeMenuTreeView();
        
    }

    // <snippet1>
    // Declare the TreeView and ContextMenuStrip
    private TreeView menuTreeView;
    private ContextMenuStrip docMenu;

    public void InitializeMenuTreeView()
    {
        // Create the TreeView.
        menuTreeView = new TreeView();
        menuTreeView.Size = new Size(200, 200);

        // Create the root node.
        TreeNode docNode = new TreeNode("Documents");
        
        // Add some additional nodes.
        docNode.Nodes.Add("phoneList.doc");
        docNode.Nodes.Add("resume.doc");

        // Add the root nodes to the TreeView.
        menuTreeView.Nodes.Add(docNode);

        // Create the ContextMenuStrip.
        docMenu = new ContextMenuStrip();

        //Create some menu items.
        ToolStripMenuItem openLabel = new ToolStripMenuItem();
        openLabel.Text = "Open";
        ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
        deleteLabel.Text = "Delete";
        ToolStripMenuItem renameLabel = new ToolStripMenuItem();
        renameLabel.Text = "Rename";

        //Add the menu items to the menu.
        docMenu.Items.AddRange(new ToolStripMenuItem[]{openLabel, 
            deleteLabel, renameLabel});

        // Set the ContextMenuStrip property to the ContextMenuStrip.
        docNode.ContextMenuStrip = docMenu;
         
        // Add the TreeView to the form.
        this.Controls.Add(menuTreeView);
    }

    // </snippet1>
    [STAThreadAttribute]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new myForm());
    }

    private void InitializeComponent()
    {
       
        this.SuspendLayout();

// 
// myForm
// 
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Name = "myForm";
        this.ResumeLayout(false);

    }

}     