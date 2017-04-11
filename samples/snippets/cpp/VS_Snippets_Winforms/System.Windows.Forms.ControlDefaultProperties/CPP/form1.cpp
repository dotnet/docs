

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System;

//<snippet2>
// To use this example create a new form and paste this class 
// forming the same file, after the form class in the same file.  
// Add a button of type FunButton to the form. 
public ref class FunButton: public Button
{
protected:
   virtual void OnMouseHover( System::EventArgs^ e ) override
   {
      
      // Get the font size in Points, add one to the
      // size, and reset the button's font to the larger
      // size.
      float fontSize = Font->SizeInPoints;
      fontSize += 1;
      System::Drawing::Size buttonSize = Size;
      this->Font = gcnew System::Drawing::Font( Font->FontFamily,fontSize,Font->Style );
      
      // Increase the size width and height of the button 
      // by 5 points each.
      Size = System::Drawing::Size( Size.Width + 5, Size.Height + 5 );
      
      // Call myBase.OnMouseHover to activate the delegate.
      Button::OnMouseHover( e );
   }

   virtual void OnMouseMove( MouseEventArgs^ e ) override
   {
      
      // Make the cursor the Hand cursor when the mouse moves 
      // over the button.
      Cursor = Cursors::Hand;
      
      // Call MyBase.OnMouseMove to activate the delegate.
      Button::OnMouseMove( e );
   }
   //</snippet2>
};

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      Populate_ListBox();
      
      //Add any initialization after the InitializeComponent() call
   }


public:

   //Form calls destructor to clean up the component list.
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
   FunButton^ Button1;
   System::Windows::Forms::ListBox^ ListBox1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      Button1 = gcnew FunButton;
      Button1->Text = "CLICK";
      this->ListBox1 = gcnew System::Windows::Forms::ListBox;
      this->SuspendLayout();
      
      //
      //ListBox1
      this->Button1->Location = System::Drawing::Point( 40, 40 );
      
      //
      this->ListBox1->Location = System::Drawing::Point( 88, 112 );
      this->ListBox1->Name = "ListBox1";
      this->ListBox1->Size = System::Drawing::Size( 120, 95 );
      this->ListBox1->TabIndex = 1;
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->ListBox1 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }


   //
   // Add this method to a form containing a ListBox control named ListBox1.
   // Call the method in the constructor or Load method of the form.
   //<snippet1>
   // The following method displays the default font, 
   // background color and foreground color values for the ListBox  
   // control. The values are displayed in the ListBox, itself.
   void Populate_ListBox()
   {
      ListBox1->Dock = DockStyle::Bottom;
      
      // Display the values in the read-only properties 
      // DefaultBackColor, DefaultFont, DefaultForecolor.
      ListBox1->Items->Add( String::Format( "Default BackColor: {0}", ListBox::DefaultBackColor ) );
      ListBox1->Items->Add( String::Format( "Default Font: {0}", ListBox::DefaultFont ) );
      ListBox1->Items->Add( String::Format( "Default ForeColor:{0}", ListBox::DefaultForeColor ) );
   }
   //</snippet1>
};


[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
