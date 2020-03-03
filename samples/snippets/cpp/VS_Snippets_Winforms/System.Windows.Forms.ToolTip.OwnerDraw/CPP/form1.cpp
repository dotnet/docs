

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::VisualStyles;

// Form for the ToolTip example.
public ref class ToolTipExampleForm: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::ToolTip^ toolTip1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::Windows::Forms::Button^ button3;

public:
   ToolTipExampleForm()
   {
      // Create the ToolTip and set initial values.
      this->toolTip1 = gcnew System::Windows::Forms::ToolTip;
      this->toolTip1->AutoPopDelay = 5000;
      this->toolTip1->InitialDelay = 500;
      this->toolTip1->OwnerDraw = true;
      this->toolTip1->ReshowDelay = 10;
      this->toolTip1->Draw += gcnew DrawToolTipEventHandler( this, &ToolTipExampleForm::toolTip1_Draw );
      
      // Create button1 and set initial values.
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button1->Location = System::Drawing::Point( 8, 8 );
      this->button1->Text = "Button 1";
      this->toolTip1->SetToolTip( this->button1, "Button1 tip text" );
      
      // Create button2 and set initial values.
      this->button2 = gcnew System::Windows::Forms::Button;
      this->button2->Location = System::Drawing::Point( 8, 32 );
      this->button2->Text = "Button 2";
      this->toolTip1->SetToolTip( this->button2, "Button2 tip text" );
      
      // Create button3 and set initial values.
      this->button3 = gcnew System::Windows::Forms::Button;
      this->button3->Location = System::Drawing::Point( 8, 56 );
      this->button3->Text = "Button 3";
      this->toolTip1->SetToolTip( this->button3, "Button3 tip text" );
      
      // Set up the Form.
      array<Control^>^temp0 = {this->button1,this->button2,this->button3};
      this->Controls->AddRange( temp0 );
      this->Text = "owner drawn ToolTip example";
   }

protected:

   ~ToolTipExampleForm()
   {
      if ( toolTip1 != nullptr )
      {
         delete toolTip1;
      }
   }

   //<Snippet5>
   // Handles drawing the ToolTip.
private:
   void toolTip1_Draw( System::Object^ /*sender*/, System::Windows::Forms::DrawToolTipEventArgs^ e )
   {
      // Draw the ToolTip differently depending on which 
      // control this ToolTip is for.
      //<Snippet2>
      // Draw a custom 3D border if the ToolTip is for button1.
      if ( e->AssociatedControl == button1 )
      {
         // Draw the standard background.
         e->DrawBackground();
         
         // Draw the custom border to appear 3-dimensional.
         array<Point>^ temp1 = {Point(0,e->Bounds.Height - 1),Point(0,0),Point(e->Bounds.Width - 1,0)};
         e->Graphics->DrawLines( SystemPens::ControlLightLight, temp1 );
         array<Point>^ temp2 = {Point(0,e->Bounds.Height - 1),Point(e->Bounds.Width - 1,e->Bounds.Height - 1),Point(e->Bounds.Width - 1,0)};
         e->Graphics->DrawLines( SystemPens::ControlDarkDark, temp2 );
         
         // Specify custom text formatting flags.
         TextFormatFlags sf = static_cast<TextFormatFlags>(TextFormatFlags::VerticalCenter | TextFormatFlags::HorizontalCenter | TextFormatFlags::NoFullWidthCharacterBreak);
         
         // Draw the standard text with customized formatting options.
         e->DrawText( sf );
      }
      //</Snippet2>
      //<Snippet3>
      // Draw a custom background and text if the ToolTip is for button2.
      else
      
      // Draw a custom background and text if the ToolTip is for button2.
      if ( e->AssociatedControl == button2 )
      {
         // Draw the custom background.
         e->Graphics->FillRectangle( SystemBrushes::ActiveCaption, e->Bounds );
         
         // Draw the standard border.
         e->DrawBorder();
         
         // Draw the custom text.
         // The using block will dispose the StringFormat automatically.
         StringFormat^ sf = gcnew StringFormat;
         try
         {
            sf->Alignment = StringAlignment::Center;
            sf->LineAlignment = StringAlignment::Center;
            sf->HotkeyPrefix = System::Drawing::Text::HotkeyPrefix::None;
            sf->FormatFlags = StringFormatFlags::NoWrap;
            System::Drawing::Font^ f = gcnew System::Drawing::Font( "Tahoma",9 );
            try
            {
               e->Graphics->DrawString( e->ToolTipText, f, SystemBrushes::ActiveCaptionText, e->Bounds, sf );
            }
            finally
            {
               if ( f )
                  delete safe_cast<IDisposable^>(f);
            }

         }
         finally
         {
            if ( sf )
               delete safe_cast<IDisposable^>(sf);
         }
      }
      //</Snippet3>
      //<Snippet4>
      // Draw the ToolTip using default values if the ToolTip is for button3.
      else if ( e->AssociatedControl == button3 )
      {
         e->DrawBackground();
         e->DrawBorder();
         e->DrawText();
      }
      //</Snippet4>
   }
   //</Snippet5>
};

// The main entry point for the application.

[STAThread]
int main()
{
   Application::Run( gcnew ToolTipExampleForm );
}
//</Snippet1>
