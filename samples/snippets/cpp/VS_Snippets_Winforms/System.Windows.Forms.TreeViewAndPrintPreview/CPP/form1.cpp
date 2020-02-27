

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing::Printing;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      document = gcnew System::Drawing::Printing::PrintDocument;
      InitializeComponent();
      InitializeTreeView();
      InitializePrintPreviewDialog();
   }


protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::TreeView^ TreeView1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      this->Button1->Location = System::Drawing::Point( 192, 104 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 72, 32 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Print Preview";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
private:
   void InitializeTreeView()
   {
      
      // Construct the TreeView object.
      this->TreeView1 = gcnew System::Windows::Forms::TreeView;
      
      // Set dock, location, size name, and tab order
      // values for the TreeView object.
      TreeView1->Dock = System::Windows::Forms::DockStyle::Left;
      TreeView1->Location = System::Drawing::Point( 0, 0 );
      TreeView1->Name = "TreeView1";
      TreeView1->Size = System::Drawing::Size( 152, 266 );
      TreeView1->TabIndex = 1;
      
      // Associate the event-handling methods with the
      // BeforeLabeEdit and the AfterSelect events.
      TreeView1->BeforeLabelEdit += gcnew NodeLabelEditEventHandler( this, &Form1::TreeView1_BeforeLabelEdit );
      TreeView1->AfterSelect += gcnew TreeViewEventHandler( this, &Form1::TreeView1_AfterSelect );
      
      // Set the LabelEdit property to true to allow the 
      // user to edit the TreeNode text.
      this->TreeView1->LabelEdit = true;
      
      // Declare and create objects needed to populate 
      // the TreeView.
      array<String^>^files = {"bigPresentation.ppt","myFinances.xls","myResume.doc"};
      ;
      String^ filePath = "c:\\myFiles";
      System::Collections::ArrayList^ nodes = gcnew System::Collections::ArrayList;
      
      // Create a node for each file, setting the Text property to the 
      // file's name and the Tag property to file's fully-qualified name.
      System::Collections::IEnumerator^ myEnum = files->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         String^ file = safe_cast<String^>(myEnum->Current);
         TreeNode^ node = gcnew TreeNode( file );
         node->Tag = String::Concat( filePath, "\\", file );
         nodes->Add( node );
      }

      array<TreeNode^>^treeNodes = gcnew array<TreeNode^>(nodes->Count);
      nodes->CopyTo( treeNodes );
      
      // Create a new node named topNode and add the ArrayList of 
      // nodes to topNode.
      TreeNode^ topNode = gcnew TreeNode( "myFiles",treeNodes );
      topNode->Tag = filePath;
      
      // Add topNode to the TreeView.
      TreeView1->Nodes->Add( topNode );
      
      // Add the TreeView to the form.
      this->Controls->Add( TreeView1 );
   }

   void TreeView1_BeforeLabelEdit( Object^ /*sender*/, NodeLabelEditEventArgs^ e )
   {
      
      // Determine whether the user has selected the top node. If so,
      // change the CancelEdit property to true to cancel the edit.
      if ( e->Node == TreeView1->TopNode )
      {
         e->CancelEdit = true;
         MessageBox::Show( "You are not allowed to edit the top node" );
      }

   }
   //</snippet1>

   //<snippet2>
private:
   // Handle the After_Select event.
   void TreeView1_AfterSelect( System::Object^ /*sender*/, System::Windows::Forms::TreeViewEventArgs^ e )
   {
      
      // Vary the response depending on which TreeViewAction
      // triggered the event. 
      switch ( (e->Action) )
      {
         case TreeViewAction::ByKeyboard:
            MessageBox::Show( "You like the keyboard!" );
            break;

         case TreeViewAction::ByMouse:
            MessageBox::Show( "You like the mouse!" );
            break;
      }
   }
   //</snippet2>

   // The following code example assumes the form contains a TreeView
   // object named TreeView1 that contains TreeNode objects. Each 
   // TreeNode objects Tag property must be set to a fully-qualified
   // document name that can be accessed by the machine running the 
   // example.  Set each Text property to a string that identifies 
   // the file specified by the Tag property. For example, you could set 
   // TreeNode1.Tag to  c:\myDocuments\recipe.doc and 
   // TreeNode1.Text to recipe.doc.
   // It also assumes the form contains a PrintPreviewDialog object 
   // named PrintPreviewDialog1 and a button named Button1. To run this 
   // example call the InitializePrintPreviewDialog method in the form's 
   // constructor.

   //<snippet3>
   // Declare the dialog.
internal:
   PrintPreviewDialog^ PrintPreviewDialog1;

private:

   // Declare a PrintDocument object named document.
   System::Drawing::Printing::PrintDocument^ document;

   // Initalize the dialog.
   void InitializePrintPreviewDialog()
   {
      
      // Create a new PrintPreviewDialog using constructor.
      this->PrintPreviewDialog1 = gcnew PrintPreviewDialog;
      
      //Set the size, location, and name.
      this->PrintPreviewDialog1->ClientSize = System::Drawing::Size( 400, 300 );
      this->PrintPreviewDialog1->Location = System::Drawing::Point( 29, 29 );
      this->PrintPreviewDialog1->Name = "PrintPreviewDialog1";
      
      // Associate the event-handling method with the 
      // document's PrintPage event.
      this->document->PrintPage += gcnew System::Drawing::Printing::PrintPageEventHandler( this, &Form1::document_PrintPage );
      
      // Set the minimum size the dialog can be resized to.
      this->PrintPreviewDialog1->MinimumSize = System::Drawing::Size( 375, 250 );
      
      // Set the UseAntiAlias property to true, which will allow the 
      // operating system to smooth fonts.
      this->PrintPreviewDialog1->UseAntiAlias = true;
   }

   void Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( TreeView1->SelectedNode != nullptr )
      {
         document->DocumentName = TreeView1->SelectedNode->Tag->ToString();
      }

      // Set the PrintPreviewDialog.Document property to
      // the PrintDocument object selected by the user.
      PrintPreviewDialog1->Document = document;
      
      // Call the ShowDialog method. This will trigger the document's
      //  PrintPage event.
      PrintPreviewDialog1->ShowDialog();
   }

   void document_PrintPage( Object^ /*sender*/, System::Drawing::Printing::PrintPageEventArgs^ e )
   {
      
      // Insert code to render the page here.
      // This code will be called when the PrintPreviewDialog.Show 
      // method is called.
      // The following code will render a simple
      // message on the document in the dialog.
      String^ text = "In document_PrintPage method.";
      System::Drawing::Font^ printFont = gcnew System::Drawing::Font( "Arial",35,System::Drawing::FontStyle::Regular );
      e->Graphics->DrawString( text, printFont, System::Drawing::Brushes::Black, 0, 0 );
   }
   //</snippet3>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
