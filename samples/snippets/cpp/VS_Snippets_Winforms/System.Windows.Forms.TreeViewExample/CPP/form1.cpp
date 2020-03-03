

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// This snippet shows the use of some TreeView properties.
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeTreeView();
      
      //Add any initialization after the InitializeComponent() call
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

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
   }

   //<snippet1>
   // Declare the TreeView control.
internal:
   System::Windows::Forms::TreeView^ TreeView1;

private:
   // Initialize the TreeView to blend with the form, giving it the 
   // same color as the form and no border.
   void InitializeTreeView()
   {
      // Create a new TreeView control and set the location and size.
      this->TreeView1 = gcnew System::Windows::Forms::TreeView;
      this->TreeView1->Location = System::Drawing::Point( 72, 48 );
      this->TreeView1->Size = System::Drawing::Size( 200, 200 );

      // Set the BorderStyle property to none, the BackColor property to  
      // the form's backcolor, and the Scrollable property to false.  
      // This allows the TreeView to blend in form.
      this->TreeView1->BorderStyle = BorderStyle::None;
      this->TreeView1->BackColor = this->BackColor;
      this->TreeView1->Scrollable = false;

      // Set the HideSelection property to false to keep the 
      // selection highlighted when the user leaves the control. 
      // This helps it blend with form.
      this->TreeView1->HideSelection = false;

      // Set the ShowRootLines and ShowLines properties to false to 
      // give the TreeView a list-like appearance.
      this->TreeView1->ShowRootLines = false;
      this->TreeView1->ShowLines = false;

      // Add the nodes.
      array<TreeNode^>^temp0 = {gcnew TreeNode( "Full Color" ),gcnew TreeNode( "Project Wizards" ),gcnew TreeNode( "Visual C# and Visual Basic Support" )};
      array<TreeNode^>^temp1 = {gcnew TreeNode( "Pentium 133 MHz or faster processor " ),gcnew TreeNode( "Windows 98 or later" ),gcnew TreeNode( "100 MB Disk space" )};
      array<TreeNode^>^temp2 = {gcnew TreeNode( "Features",temp0 ),gcnew TreeNode( "System Requirements",temp1 )};
      this->TreeView1->Nodes->AddRange( temp2 );

      // Set the tab index and add the TreeView to the form.
      this->TreeView1->TabIndex = 0;
      this->Controls->Add( this->TreeView1 );
   }
   //</snippet1>

   //<snippet2>
   System::Windows::Forms::TreeView^ TreeView2;

   // Initialize the TreeView to blend with the form, giving it the 
   // same color as the form and no border.
   void InitializeSelectedTreeView()
   {
      
      // Create a new TreeView control and set the location and size.
      this->TreeView2 = gcnew System::Windows::Forms::TreeView;
      this->TreeView2->Location = System::Drawing::Point( 72, 48 );
      this->TreeView2->Size = System::Drawing::Size( 200, 200 );
      this->TreeView2->BorderStyle = BorderStyle::Fixed3D;
      
      // Set the HideSelection property to false to keep the 
      // selection highlighted when the user leaves the control. 
      this->TreeView1->HideSelection = false;
      
      // Add the nodes.
      array<TreeNode^>^temp0 = {gcnew TreeNode( "Full Color" ),gcnew TreeNode( "Project Wizards" ),gcnew TreeNode( "Visual C# and Visual Basic Support" )};
      array<TreeNode^>^temp1 = {gcnew TreeNode( "Pentium 133 MHz or faster processor " ),gcnew TreeNode( "Windows 98 or later" ),gcnew TreeNode( "100 MB Disk space" )};
      array<TreeNode^>^temp2 = {gcnew TreeNode( "Features",temp0 ),gcnew TreeNode( "System Requirements",temp1 )};
      this->TreeView1->Nodes->AddRange( temp2 );
      
      // Set the tab index and add the TreeView to the form.
      this->TreeView1->TabIndex = 0;
      this->Controls->Add( this->TreeView1 );
   }

   //</snippet2>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
