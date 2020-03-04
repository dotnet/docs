

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Drawing;
using namespace System;
using namespace System::Windows::Forms;

// The following code example demonstrates how to override the  
// OnClosed method on a class derived from Form. 
//<snippet6>
public ref class myForm: public Form
{
protected:
   virtual void OnClosed( EventArgs^ e ) override
   {
      MessageBox::Show( "The form is now closing.", "Close Warning", MessageBoxButtons::OK, MessageBoxIcon::Warning );
      Form::OnClosed( e );
   }

public:
   myForm()
      : Form()
   {}

};
//</snippet6>

public ref class Form1: public myForm
{
public:
   Form1()
      : myForm()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      this->Paint += gcnew PaintEventHandler( this, &Form1::Form1_Paint );
      addButton->Click += gcnew EventHandler( this, &Form1::addButton_Click );
      subtractButton->Click += gcnew EventHandler( this, &Form1::subtractButton_Click );
      TruncateAndRoundSizes();
      
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

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::Button^ subtractButton;
   System::Windows::Forms::Button^ addButton;
   System::Windows::Forms::Label ^ Label1;
   System::Windows::Forms::Label ^ Label2;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->subtractButton = gcnew System::Windows::Forms::Button;
      this->addButton = gcnew System::Windows::Forms::Button;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->Label2 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      
      //
      //subtractButton
      //
      this->subtractButton->Location = System::Drawing::Point( 192, 40 );
      this->subtractButton->Name = "subtractButton";
      this->subtractButton->TabIndex = 0;
      this->subtractButton->Text = "subtractButton";
      
      //
      //addButton
      //
      this->addButton->Location = System::Drawing::Point( 192, 80 );
      this->addButton->Name = "addButton";
      this->addButton->TabIndex = 1;
      this->addButton->Text = "addButton";
      
      //
      //Label1
      //
      this->Label1->Location = System::Drawing::Point( 24, 192 );
      this->Label1->Name = "Label1";
      this->Label1->Size = System::Drawing::Size( 240, 23 );
      this->Label1->TabIndex = 2;
      this->Label1->Text = "Label1";
      
      //
      //Label2
      //
      this->Label2->Location = System::Drawing::Point( 24, 224 );
      this->Label2->Name = "Label2";
      this->Label2->Size = System::Drawing::Size( 240, 23 );
      this->Label2->TabIndex = 3;
      this->Label2->Text = "Label2";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label2 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->addButton );
      this->Controls->Add( this->subtractButton );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   // The following code example creates points and sizes using several
   // of the overloaded operators defined for these types. It also
   // demonstrates how to use a SystemPen.
   // This example is designed to be used with Windows Forms. Create
   // a form that contains a Button named subtractButton. Paste the  
   // code into the form and call the CreatePointsAndSizes method  
   // from the form's Paint event-handling method, passing e as
   // PaintEventArgs.
   //<snippet1>
   void CreatePointsAndSizes( PaintEventArgs^ e )
   {
      // Create the starting point.
      Point startPoint = Point(subtractButton->Size);
      
      // Use the addition operator to get the end point.
      Point endPoint = startPoint + System::Drawing::Size( 140, 150 );
      
      // Draw a line between the points.
      e->Graphics->DrawLine( SystemPens::Highlight, startPoint, endPoint );
      
      // Convert the starting point to a size and compare it to the
      // subtractButton size.  
      System::Drawing::Size buttonSize = (System::Drawing::Size)startPoint;
      if ( buttonSize == subtractButton->Size )
      {
         e->Graphics->DrawString( "The sizes are equal.", gcnew System::Drawing::Font( this->Font,FontStyle::Italic ), Brushes::Indigo, 10.0F, 65.0F );
      }
   }
   //</snippet1>

   // The following code example demonstrates the G,B,R, and A 
   // properties of a Color and the Size.op_Implicit member.
   // This example is designed to be used with a Windows Form. 
   // Paste the code into the form and call the 
   // ShowPropertiesOfSlateBlue method from the form's Paint 
   // event-handling method, passing e as PaintEventArgs.
   //<snippet3>
   void ShowPropertiesOfSlateBlue( PaintEventArgs^ e )
   {
      Color slateBlue = Color::FromName( "SlateBlue" );
      Byte g = slateBlue.G;
      Byte b = slateBlue.B;
      Byte r = slateBlue.R;
      Byte a = slateBlue.A;
      array<Object^>^temp0 = {a,r,g,b};
      String^ text = String::Format( "Slate Blue has these ARGB values: Alpha:{0}, "
      "red:{1}, green: {2}, blue {3}", temp0 );
      e->Graphics->DrawString( text, gcnew System::Drawing::Font( this->Font,FontStyle::Italic ), gcnew SolidBrush( slateBlue ), RectangleF(PointF(0.0F,0.0F),this->Size) );
   }
   //</snippet3>

   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      
      //CreatePointsAndSizes(e)
      ShowPropertiesOfSlateBlue( e );
   }

   // The following code example demonstrates the Subtraction operator.  
   // The example is designed to be used with Windows Forms. 
   // To run the example, paste it into a form that contains a button 
   // named subtractionButton and associate this method with the
   // button's Click event.
   //<snippet2>
   void subtractButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      subtractButton->Size = subtractButton->Size - System::Drawing::Size( 10, 10 );
   }
   //</snippet2>

   // The following code example demonstrates the Addition operator.  
   // The example is designed to be used with Windows Forms. To run 
   // this example, paste it into a form that contains a button named 
   // addButton and associate this method with the button's Click event.
   //<snippet4>
   void addButton_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      addButton->Size = addButton->Size + System::Drawing::Size( 10, 10 );
   }
   //</snippet4>

   // The following code example demonstrates how to use static Round
   // and Truncate methods to convert a SizeF to a Size.  This example is 
   // designed to be used with Windows Forms. To run this example paste 
   // it into a form that contains two Label objects named Label1 
   // and Label2 and then call this method from the form's constructor.
   //<snippet5>
   void TruncateAndRoundSizes()
   {
      // Create a SizeF.
      SizeF theSize = SizeF(75.9F,75.9F);
      
      // Round the Size.
      System::Drawing::Size roundedSize = ::Size::Round( theSize );
      
      // Truncate the Size.
      System::Drawing::Size truncatedSize = ::Size::Truncate( theSize );
      
      //Print out the values on two labels.
      Label1->Text = String::Format( "Rounded size = {0}", roundedSize );
      Label2->Text = String::Format( "Truncated size = {0}", truncatedSize );
   }
   //</snippet5>

   // The following code example demonstrates how to use the 
   // Point#ctor(int) and Size#ctor(int, int) constructors and the 
   // ContentAlignment enumeration. To run this example paste this code into  
   // a Windows Form that contains a label named Label1 and call the 
   // IntializeLabel1 method in the form's constructor.
   //<snippet7>
   void InitializeLabel1()
   {
      // Set a border.
      Label1->BorderStyle = BorderStyle::FixedSingle;
      
      // Set the size, constructing a size from two integers.
      Label1->Size = System::Drawing::Size( 100, 50 );
      
      // Set the location, constructing a point from a 32-bit integer
      // (using hexadecimal).
      Label1->Location = Point(0x280028);
      
      // Set and align the text on the lower-right side of the label.
      Label1->TextAlign = ContentAlignment::BottomRight;
      Label1->Text = "Bottom Right Alignment";
   }
   //</snippet7>

   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      TruncateAndRoundSizes();
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
