

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

//This code example demonstrates ControlPaint.DrawReversibleLine, 
//ControlPaint.DrawFocusRectangle and ControlPaint.FillReversibleRectangle.
using namespace System::Windows::Forms;
using namespace System::Drawing;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      
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
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::Button^ Button2;
   System::Windows::Forms::Button^ Button3;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->Button2 = gcnew System::Windows::Forms::Button;
      this->Button3 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 48, 40 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 88, 80 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Click for focus rectangle on Button2";
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
      
      //
      //Button2
      //
      this->Button2->Location = System::Drawing::Point( 176, 48 );
      this->Button2->Name = "Button2";
      this->Button2->Size = System::Drawing::Size( 72, 64 );
      this->Button2->TabIndex = 1;
      this->Button2->Text = "Hover over me for filled rectangle";
      this->Button2->MouseHover += gcnew System::EventHandler( this, &Form1::Button2_MouseHover );
      this->Button2->MouseLeave += gcnew System::EventHandler( this, &Form1::Button2_MouseLeave );
      
      //
      //Button3
      //
      this->Button3->Location = System::Drawing::Point( 104, 160 );
      this->Button3->Name = "Button3";
      this->Button3->Size = System::Drawing::Size( 96, 72 );
      this->Button3->TabIndex = 2;
      this->Button3->Text = "Hover over for me for reversible lines";
      this->Button3->MouseHover += gcnew System::EventHandler( this, &Form1::Button3_MouseHover );
      this->Button3->MouseLeave += gcnew System::EventHandler( this, &Form1::Button3_MouseLeave );
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button3 );
      this->Controls->Add( this->Button2 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet2>
   // This method draws a focus rectangle on Button2 using the 
   // handle and client rectangle of Button2.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ControlPaint::DrawFocusRectangle( Graphics::FromHwnd( Button2->Handle ), Button2->ClientRectangle );
   }
   //</snippet2>

   //<snippet1>
   //When the mouse hovers over Button2, its ClientRectangle is filled.
   void Button2_MouseHover( Object^ sender, System::EventArgs^ /*e*/ )
   {
      Control^ senderControl = dynamic_cast<Control^>(sender);
      Rectangle screenRectangle = senderControl->RectangleToScreen( senderControl->ClientRectangle );
      ControlPaint::FillReversibleRectangle( screenRectangle, senderControl->BackColor );
   }

   // When the mouse leaves Button2, its ClientRectangle is cleared by
   // calling the FillReversibleRectangle method again.
   void Button2_MouseLeave( Object^ sender, System::EventArgs^ /*e*/ )
   {
      Control^ senderControl = dynamic_cast<Control^>(sender);
      Rectangle screenRectangle = senderControl->RectangleToScreen( senderControl->ClientRectangle );
      ControlPaint::FillReversibleRectangle( screenRectangle, senderControl->BackColor );
   }
   //</snippet1>

   //<snippet3>
   // When the mouse hovers over Button3, two reversible lines are 
   // drawn using the corner coordinates of Button3, which are first 
   // converted to screen coordinates.
   void Button3_MouseHover( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(0,0) ), Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Top) ), Button3->PointToScreen( Point(Button1->ClientRectangle.Left,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
   }

   // When the mouse moves from Button3, the reversible lines are erased by
   // using the same coordinates as are used in the Button3_MouseHover method.
   void Button3_MouseLeave( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(0,0) ), Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
      ControlPaint::DrawReversibleLine( Button3->PointToScreen( Point(Button3->ClientRectangle.Right,Button3->ClientRectangle.Top) ), Button3->PointToScreen( Point(Button3->ClientRectangle.Left,Button3->ClientRectangle.Bottom) ), SystemColors::Control );
   }
   //</snippet3>
};

int main()
{
   Application::Run( gcnew Form1 );
}
