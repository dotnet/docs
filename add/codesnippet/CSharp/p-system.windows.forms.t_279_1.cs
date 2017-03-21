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