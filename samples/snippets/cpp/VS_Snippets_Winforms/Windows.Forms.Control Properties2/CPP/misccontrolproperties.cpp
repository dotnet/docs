

#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::IO;

public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::TreeView^ treeView1;
   System::Windows::Forms::ComboBox^ comboBox1;
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      InitializeComponent();
      array<MenuItem^>^temp0 = {gcnew MenuItem( "Edit" )};
      this->treeView1->ContextMenu = gcnew System::Windows::Forms::ContextMenu( temp0 );
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

   /// <summary>
   /// Required method for Designer support; do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->treeView1 = gcnew System::Windows::Forms::TreeView;
      this->comboBox1 = gcnew System::Windows::Forms::ComboBox;
      this->SuspendLayout();

      //
      // treeView1
      //
      this->treeView1->Anchor = static_cast<AnchorStyles>(AnchorStyles::Top | AnchorStyles::Bottom | AnchorStyles::Left | AnchorStyles::Right);
      this->treeView1->ImageIndex = -1;
      this->treeView1->Name = "treeView1";
      this->treeView1->SelectedImageIndex = -1;
      this->treeView1->Size = System::Drawing::Size( 232, 224 );
      this->treeView1->TabIndex = 0;
      this->treeView1->MouseUp += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::treeView1_MouseUp );
      this->treeView1->BeforeExpand += gcnew System::Windows::Forms::TreeViewCancelEventHandler( this, &Form1::treeView1_BeforeExpand );

      //
      // comboBox1
      //
      this->comboBox1->Dock = System::Windows::Forms::DockStyle::Bottom;
      this->comboBox1->Location = System::Drawing::Point( 0, 224 );
      this->comboBox1->Name = "comboBox1";
      this->comboBox1->Size = System::Drawing::Size( 232, 21 );
      this->comboBox1->TabIndex = 1;
      this->comboBox1->SelectedIndexChanged += gcnew System::EventHandler( this, &Form1::comboBox1_SelectedIndexChanged );

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 232, 245 );
      array<System::Windows::Forms::Control^>^temp1 = {this->comboBox1,this->treeView1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   // <snippet1>
private:
   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Display the hand cursor when the mouse pointer
      // is over the combo box drop-down button.
      comboBox1->Cursor = Cursors::Hand;
      
      // Fill the combo box with all the logical
      // drives available to the user.
      try
      {
         IEnumerator^ myEnum = Environment::GetLogicalDrives()->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            String^ logicalDrive = safe_cast<String^>(myEnum->Current);
            comboBox1->Items->Add( logicalDrive );
         }
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }
   }
   // </snippet1>

   // <snippet4>
protected:
   property System::Windows::Forms::ImeMode DefaultImeMode 
   {
      virtual System::Windows::Forms::ImeMode get() override
      {
         // Disable the IME mode for the control.
         return ::ImeMode::Off;
      }

   }
   // </snippet4>

   // <snippet3>
protected:
   property System::Drawing::Size DefaultSize 
   {
      virtual System::Drawing::Size get() override
      {
         // Set the default size of
         // the form to 500 pixels square.
         return System::Drawing::Size( 500, 500 );
      }
   }
   // </snippet3>

   // <snippet5>
private:
   void treeView1_MouseUp( Object^ /*sender*/, MouseEventArgs^ e )
   {
      // If the right mouse button was clicked and released,
      // display the shortcut menu assigned to the TreeView.
      if ( e->Button == ::MouseButtons::Right )
      {
         treeView1->ContextMenu->Show( treeView1, Point(e->X,e->Y) );
      }
   }
   // </snippet5>

   void comboBox1_SelectedIndexChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         DirectoryInfo^ dirInfo = gcnew DirectoryInfo( dynamic_cast<String^>(comboBox1->SelectedItem) );
         this->treeView1->Nodes->Clear();
         
         // Do not display or attempt to access System, Temporary, or Hidden directories.
         if ( dirInfo->Exists && ((dirInfo->Attributes & (FileAttributes::Hidden | FileAttributes::System | FileAttributes::Temporary)) != (FileAttributes)0) )
         {
            TreeNode^ rootNode = gcnew TreeNode( dynamic_cast<String^>(comboBox1->SelectedItem) );
            treeView1->Nodes->Add( rootNode );
            CreateChildNodes( dirInfo, rootNode );
         }
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }
   }

   void CreateChildNodes( DirectoryInfo^ dirInfo, TreeNode^ parentNode )
   {
      try
      {
         IEnumerator^ myEnum = dirInfo->GetDirectories()->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            DirectoryInfo^ d = safe_cast<DirectoryInfo^>(myEnum->Current);

            // Do not display or attempt to access System, Temporary, or System directories.
            if ( (d->Attributes & (FileAttributes::Hidden | FileAttributes::System | FileAttributes::Temporary))== (FileAttributes)0 )
            {
               parentNode->Nodes->Add( gcnew TreeNode( d->Name ) );
               Application::DoEvents();
            }
         }
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }
   }

   void treeView1_BeforeExpand( Object^ /*sender*/, TreeViewCancelEventArgs^ e )
   {
      IEnumerator^ myEnum = e->Node->Nodes->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         TreeNode^ node = safe_cast<TreeNode^>(myEnum->Current);

         // Create a DirectoryInfo Object* from the node path.
         CreateChildNodes( gcnew DirectoryInfo( node->FullPath ), node );
      }
   }
};

[STAThread]
void main()
{
   Application::Run( gcnew Form1 );
}
