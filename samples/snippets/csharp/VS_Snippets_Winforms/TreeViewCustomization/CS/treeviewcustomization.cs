//<Snippet1>
using System;
using System.Windows.Forms;

namespace TreeViewCustomization
{
    public class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            // Initialize myTreeView.
            CustomizedTreeView myTreeView = new CustomizedTreeView();
            myTreeView.Dock = DockStyle.Fill;

            // Add nodes to myTreeView.
            TreeNode node;
            for (int x = 0; x < 3; ++x)
            {
                // Add a root node.
                node = myTreeView.Nodes.Add(String.Format("Node{0}", x*4));
                for (int y = 1; y < 4; ++y)
                {
                    // Add a node as a child of the previously added node.
                    node = node.Nodes.Add(String.Format("Node{0}", x*4 + y));
                }
            }
            
            // Add myTreeView to the form.
            this.Controls.Add(myTreeView);
        }

        [STAThreadAttribute()]
        static void Main() 
        {
            Application.Run(new Form1());
        }
    }

    //<Snippet2>
    public class CustomizedTreeView : TreeView
    {
        public CustomizedTreeView()
        {
            // Customize the TreeView control by setting various properties.
            BackColor = System.Drawing.Color.CadetBlue;
            FullRowSelect = true;
            HotTracking = true;
            Indent = 34;
            ShowPlusMinus = false;

            // The ShowLines property must be false for the FullRowSelect 
            // property to work.
            ShowLines = false;
        }

        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            // Confirm that the user initiated the selection.
            // This prevents the first node from expanding when it is
            // automatically selected during the initialization of 
            // the TreeView control.
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.IsExpanded) 
                {
                    e.Node.Collapse();
                }
                else 
                {
                    e.Node.Expand();
                }
            }

            // Remove the selection. This allows the same node to be
            // clicked twice in succession to toggle the expansion state.
            SelectedNode = null;
        }

    }
    //</Snippet2>

}
//</Snippet1>