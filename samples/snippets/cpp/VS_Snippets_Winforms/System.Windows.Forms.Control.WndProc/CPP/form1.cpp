#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

//<Snippet1>
using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

namespace csTempWindowsApplication1
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:

      // Constant value was found in the "windows.h" header file.
      static const Int32 WM_ACTIVATEAPP = 0x001C;
      Boolean appActive;

   public:
      Form1()
      {
         appActive = true;
         this->Size = System::Drawing::Size( 300, 300 );
         this->Text = "Form1";
         this->Font = gcnew System::Drawing::Font( "Microsoft Sans Serif",18.0F,System::Drawing::FontStyle::Bold,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );
      }


   protected:
      virtual void OnPaint( PaintEventArgs^ e ) override
      {
         
         // Paint a string in different styles depending on whether the
         // application is active.
         if ( appActive )
         {
            e->Graphics->FillRectangle( SystemBrushes::ActiveCaption, 20, 20, 260, 50 );
            e->Graphics->DrawString( "Application is active", this->Font, SystemBrushes::ActiveCaptionText, 20, 20 );
         }
         else
         {
            e->Graphics->FillRectangle( SystemBrushes::InactiveCaption, 20, 20, 260, 50 );
            e->Graphics->DrawString( "Application is Inactive", this->Font, SystemBrushes::ActiveCaptionText, 20, 20 );
         }
      }


      [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
      virtual void WndProc( Message% m ) override
      {
         
         // Listen for operating system messages.
         switch ( m.Msg )
         {
            case WM_ACTIVATEAPP:
               
               // The WParam value identifies what is occurring.
               appActive = (int)m.WParam != 0;
               
               // Invalidate to get new text painted.
               this->Invalidate();
               break;
         }
         Form::WndProc( m );
      }

   };

}


[STAThread]
int main()
{
   Application::Run( gcnew csTempWindowsApplication1::Form1 );
}

//</Snippet1>
