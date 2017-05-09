

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following code example demonstrates how setting the 
// Label.Autosize property to True will causes the width of 
// the label to adjust.
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeLabel();
      
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
      this->SuspendLayout();
      this->ClientSize = System::Drawing::Size( 266, 300 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // Declare a label.
internal:
   System::Windows::Forms::Label ^ Label1;

private:

   // Initialize the label.
   void InitializeLabel()
   {
      this->Label1 = gcnew Label;
      this->Label1->Location = System::Drawing::Point( 10, 10 );
      this->Label1->Name = "Label1";
      this->Label1->TabIndex = 0;
      
      // Set the label to a small size, but set the AutoSize property 
      // to true. The label will adjust its length so all the text
      // is visible, however if the label is wider than the form,
      // the entire label will not be visible.
      this->Label1->Size = System::Drawing::Size( 10, 10 );
      this->Controls->Add( this->Label1 );
      this->Label1->AutoSize = true;
      this->Label1->Text = "The text in this label is longer"
      " than the set size.";
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
