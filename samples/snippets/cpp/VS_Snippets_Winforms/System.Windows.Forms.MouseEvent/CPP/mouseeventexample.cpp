

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace MouseEvent
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Panel^ panel1;
      System::Windows::Forms::Label ^ label1;
      System::Windows::Forms::Label ^ label2;
      System::Windows::Forms::Label ^ label3;
      System::Windows::Forms::Label ^ label4;
      System::Windows::Forms::Label ^ label5;
      System::Windows::Forms::Label ^ label6;
      System::Windows::Forms::Label ^ label7;
      System::Windows::Forms::Label ^ label8;
      System::Windows::Forms::Label ^ label9;
      System::Windows::Forms::Button^ clearButton;
      System::Drawing::Drawing2D::GraphicsPath^ mousePath;
      System::Windows::Forms::GroupBox^ groupBox1;
      int fontSize;

   public:
      Form1()
      {
         fontSize = 20;
         mousePath = gcnew System::Drawing::Drawing2D::GraphicsPath;
         this->panel1 = gcnew System::Windows::Forms::Panel;
         this->label1 = gcnew System::Windows::Forms::Label;
         this->clearButton = gcnew System::Windows::Forms::Button;
         this->label2 = gcnew System::Windows::Forms::Label;
         this->label3 = gcnew System::Windows::Forms::Label;
         this->label4 = gcnew System::Windows::Forms::Label;
         this->label5 = gcnew System::Windows::Forms::Label;
         this->label6 = gcnew System::Windows::Forms::Label;
         this->label7 = gcnew System::Windows::Forms::Label;
         this->label8 = gcnew System::Windows::Forms::Label;
         this->label9 = gcnew System::Windows::Forms::Label;
         this->groupBox1 = gcnew System::Windows::Forms::GroupBox;
         
         // Mouse Events Label
         this->label1->Location = System::Drawing::Point( 24, 504 );
         this->label1->Size = System::Drawing::Size( 392, 23 );
         
         // DoubleClickSize Label
         this->label2->AutoSize = true;
         this->label2->Location = System::Drawing::Point( 24, 48 );
         this->label2->Size = System::Drawing::Size( 35, 13 );
         
         // DoubleClickTime Label
         this->label3->AutoSize = true;
         this->label3->Location = System::Drawing::Point( 24, 72 );
         this->label3->Size = System::Drawing::Size( 35, 13 );
         
         // MousePresent Label
         this->label4->AutoSize = true;
         this->label4->Location = System::Drawing::Point( 24, 96 );
         this->label4->Size = System::Drawing::Size( 35, 13 );
         
         // MouseButtons Label
         this->label5->AutoSize = true;
         this->label5->Location = System::Drawing::Point( 24, 120 );
         this->label5->Size = System::Drawing::Size( 35, 13 );
         
         // MouseButtonsSwapped Label
         this->label6->AutoSize = true;
         this->label6->Location = System::Drawing::Point( 320, 48 );
         this->label6->Size = System::Drawing::Size( 35, 13 );
         
         // MouseWheelPresent Label
         this->label7->AutoSize = true;
         this->label7->Location = System::Drawing::Point( 320, 72 );
         this->label7->Size = System::Drawing::Size( 35, 13 );
         
         // MouseWheelScrollLines Label
         this->label8->AutoSize = true;
         this->label8->Location = System::Drawing::Point( 320, 96 );
         this->label8->Size = System::Drawing::Size( 35, 13 );
         
         // NativeMouseWheelSupport Label
         this->label9->AutoSize = true;
         this->label9->Location = System::Drawing::Point( 320, 120 );
         this->label9->Size = System::Drawing::Size( 35, 13 );
         
         // Mouse Panel
         this->panel1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
         this->panel1->BackColor = System::Drawing::SystemColors::ControlDark;
         this->panel1->Location = System::Drawing::Point( 16, 160 );
         this->panel1->Size = System::Drawing::Size( 664, 320 );
         this->panel1->MouseUp += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::panel1_MouseUp );
         this->panel1->Paint += gcnew System::Windows::Forms::PaintEventHandler( this, &Form1::panel1_Paint );
         this->panel1->MouseEnter += gcnew System::EventHandler( this, &Form1::panel1_MouseEnter );
         this->panel1->MouseHover += gcnew System::EventHandler( this, &Form1::panel1_MouseHover );
         this->panel1->MouseMove += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::panel1_MouseMove );
         this->panel1->MouseLeave += gcnew System::EventHandler( this, &Form1::panel1_MouseLeave );
         this->panel1->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::panel1_MouseDown );
         this->panel1->MouseWheel += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::panel1_MouseWheel );
         
         // Clear Button
         this->clearButton->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right);
         this->clearButton->Location = System::Drawing::Point( 592, 504 );
         this->clearButton->TabIndex = 1;
         this->clearButton->Text = "Clear";
         this->clearButton->Click += gcnew System::EventHandler( this, &Form1::clearButton_Click );
         
         // GroupBox
         this->groupBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left | System::Windows::Forms::AnchorStyles::Right);
         this->groupBox1->Location = System::Drawing::Point( 16, 24 );
         this->groupBox1->Size = System::Drawing::Size( 664, 128 );
         this->groupBox1->Text = "System::Windows::Forms::SystemInformation";
         
         // Set up how the form should be displayed and add the controls to the form.
         this->ClientSize = System::Drawing::Size( 696, 534 );
         array<System::Windows::Forms::Control^>^temp0 = {this->label9,this->label8,this->label7,this->label6,this->label5,this->label4,this->label3,this->label2,this->clearButton,this->panel1,this->label1,this->groupBox1};
         this->Controls->AddRange( temp0 );
         this->Text = "Mouse Event Example";
         
         //<Snippet6>
         // Displays information about the system mouse.
         label2->Text = "SystemInformation::DoubleClickSize: {0}",SystemInformation::DoubleClickSize;
         label3->Text = "SystemInformation::DoubleClickTime: {0}",SystemInformation::DoubleClickTime;
         label4->Text = "SystemInformation::MousePresent: {0}",SystemInformation::MousePresent;
         label5->Text = "SystemInformation::MouseButtons: {0}",SystemInformation::MouseButtons;
         label6->Text = "SystemInformation::MouseButtonsSwapped: {0}",SystemInformation::MouseButtonsSwapped;
         label7->Text = "SystemInformation::MouseWheelPresent: {0}",SystemInformation::MouseWheelPresent;
         label8->Text = "SystemInformation::MouseWheelScrollLines: {0}",SystemInformation::MouseWheelScrollLines;
         label9->Text = "SystemInformation::NativeMouseWheelSupport: {0}",SystemInformation::NativeMouseWheelSupport;
         //</Snippet6>
      }

      //<Snippet2>
   private:
      void panel1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         // Update the mouse path with the mouse information
         Point mouseDownLocation = Point(e->X,e->Y);
         String^ eventString = nullptr;
         switch ( e->Button )
         {
            case ::MouseButtons::Left:
               eventString = "L";
               break;

            case ::MouseButtons::Right:
               eventString = "R";
               break;

            case ::MouseButtons::Middle:
               eventString = "M";
               break;

            case ::MouseButtons::XButton1:
               eventString = "X1";
               break;

            case ::MouseButtons::XButton2:
               eventString = "X2";
               break;

            case ::MouseButtons::None:
            default:
               break;
         }
         if ( eventString != nullptr )
         {
            mousePath->AddString( eventString, FontFamily::GenericSerif, (int)FontStyle::Bold, (float)fontSize, mouseDownLocation, StringFormat::GenericDefault );
         }
         else
         {
            mousePath->AddLine( mouseDownLocation, mouseDownLocation );
         }

         panel1->Focus();
         panel1->Invalidate();
      }
      //</Snippet2>

      //<Snippet3>
      void panel1_MouseEnter( Object^ sender, System::EventArgs^ /*e*/ )
      {
         
         // Update the mouse event label to indicate the MouseEnter event occurred.
         label1->Text = String::Concat( sender->GetType(), ": MouseEnter" );
      }

      void panel1_MouseHover( Object^ sender, System::EventArgs^ /*e*/ )
      {
         
         // Update the mouse event label to indicate the MouseHover event occurred.
         label1->Text = String::Concat( sender->GetType(), ": MouseHover" );
      }

      void panel1_MouseLeave( Object^ sender, System::EventArgs^ /*e*/ )
      {
         
         // Update the mouse event label to indicate the MouseLeave event occurred.
         label1->Text = String::Concat( sender->GetType(), ": MouseLeave" );
      }

      void panel1_MouseMove( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         // Update the mouse path that is drawn onto the Panel.
         int mouseX = e->X;
         int mouseY = e->Y;
         mousePath->AddLine( mouseX, mouseY, mouseX, mouseY );
      }
      //</Snippet3>

      //<Snippet4>
      void panel1_MouseWheel( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         // Update the drawing based upon the mouse wheel scrolling.
         int numberOfTextLinesToMove = e->Delta * SystemInformation::MouseWheelScrollLines / 120;
         int numberOfPixelsToMove = numberOfTextLinesToMove * fontSize;
         if ( numberOfPixelsToMove != 0 )
         {
            System::Drawing::Drawing2D::Matrix^ translateMatrix = gcnew System::Drawing::Drawing2D::Matrix;
            translateMatrix->Translate( 0, (float)numberOfPixelsToMove );
            mousePath->Transform(translateMatrix);
         }

         panel1->Invalidate();
      }
      //</Snippet4>

      //<Snippet5>
      void panel1_MouseUp( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         Point mouseUpLocation = System::Drawing::Point( e->X, e->Y );
         
         // Show the number of clicks in the path graphic.
         int numberOfClicks = e->Clicks;
         mousePath->AddString( String::Format( "   {0}", numberOfClicks ), FontFamily::GenericSerif, (int)FontStyle::Bold, (float)fontSize, mouseUpLocation, StringFormat::GenericDefault );
         panel1->Invalidate();
      }
      //</Snippet5>

      void panel1_Paint( Object^ /*sender*/, System::Windows::Forms::PaintEventArgs^ e )
      {
         // Perform the painting of the Panel.
         e->Graphics->DrawPath( System::Drawing::Pens::DarkRed, mousePath );
      }

      void clearButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Clear the Panel display.
         delete mousePath;
         mousePath = gcnew System::Drawing::Drawing2D::GraphicsPath;
         panel1->Invalidate();
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew MouseEvent::Form1 );
}
//</Snippet1>
