#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TreeView^ treeView1;
   TreeNode^ mySelectedNode;

   // <Snippet1>
   /* Get the tree node under the mouse pointer and 
      save it in the mySelectedNode variable. */
private:
   void treeView1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      mySelectedNode = treeView1->GetNodeAt( e->X, e->Y );
   }

   void menuItem1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( mySelectedNode != nullptr && mySelectedNode->Parent != nullptr )
      {
         treeView1->SelectedNode = mySelectedNode;
         treeView1->LabelEdit = true;
         if (  !mySelectedNode->IsEditing )
         {
            mySelectedNode->BeginEdit();
         }
      }
      else
      {
         MessageBox::Show( String::Concat( "No tree node selected or selected node is a root node.\n",
            "Editing of root nodes is not allowed." ), "Invalid selection" );
      }
   }

   void treeView1_AfterLabelEdit( Object^ /*sender*/,
      System::Windows::Forms::NodeLabelEditEventArgs^ e )
   {
      if ( e->Label != nullptr )
      {
         if ( e->Label->Length > 0 )
         {
            array<Char>^ temp0 = {'@','.',',','!'};
            if ( e->Label->IndexOfAny( temp0 ) == -1 )
            {
               
               // Stop editing without canceling the label change.
               e->Node->EndEdit( false );
            }
            else
            {
               /* Cancel the label edit action, inform the user, and 
                  place the node in edit mode again. */
               e->CancelEdit = true;
               MessageBox::Show( String::Concat( "Invalid tree node label.\n",
                  "The invalid characters are: '@','.', ',', '!'" ),
                  "Node Label Edit" );
               e->Node->BeginEdit();
            }
         }
         else
         {
            /* Cancel the label edit action, inform the user, and 
               place the node in edit mode again. */
            e->CancelEdit = true;
            MessageBox::Show( "Invalid tree node label.\nThe label cannot be blank",
               "Node Label Edit" );
            e->Node->BeginEdit();
         }
      }
   }
   // </Snippet1>
};
