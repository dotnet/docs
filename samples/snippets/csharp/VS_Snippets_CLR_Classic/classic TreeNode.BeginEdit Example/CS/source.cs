using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected TreeView treeView1;
 protected TreeNode mySelectedNode;


// <Snippet1>
/* Get the tree node under the mouse pointer and 
   save it in the mySelectedNode variable. */
private void treeView1_MouseDown(object sender, 
  System.Windows.Forms.MouseEventArgs e)
{
   mySelectedNode = treeView1.GetNodeAt(e.X, e.Y);
}

private void menuItem1_Click(object sender, System.EventArgs e)
{
   if (mySelectedNode != null && mySelectedNode.Parent != null)
   {
      treeView1.SelectedNode = mySelectedNode;
      treeView1.LabelEdit = true;
      if(!mySelectedNode.IsEditing)
      {
         mySelectedNode.BeginEdit();
      }
   }
   else
   {
      MessageBox.Show("No tree node selected or selected node is a root node.\n" + 
         "Editing of root nodes is not allowed.", "Invalid selection");
   }
}

private void treeView1_AfterLabelEdit(object sender, 
         System.Windows.Forms.NodeLabelEditEventArgs e)
{
   if (e.Label != null)
   {
     if(e.Label.Length > 0)
     {
        if (e.Label.IndexOfAny(new char[]{'@', '.', ',', '!'}) == -1)
        {
           // Stop editing without canceling the label change.
           e.Node.EndEdit(false);
        }
        else
        {
           /* Cancel the label edit action, inform the user, and 
              place the node in edit mode again. */
           e.CancelEdit = true;
           MessageBox.Show("Invalid tree node label.\n" + 
              "The invalid characters are: '@','.', ',', '!'", 
              "Node Label Edit");
           e.Node.BeginEdit();
        }
     }
     else
     {
        /* Cancel the label edit action, inform the user, and 
           place the node in edit mode again. */
        e.CancelEdit = true;
        MessageBox.Show("Invalid tree node label.\nThe label cannot be blank", 
           "Node Label Edit");
        e.Node.BeginEdit();
     }
   }
}
// </Snippet1>


}
