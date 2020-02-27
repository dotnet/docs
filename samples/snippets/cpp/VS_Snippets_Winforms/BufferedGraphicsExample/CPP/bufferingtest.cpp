

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace BufferingExample
{
   public ref class BufferingExample: public Form
   {
   private:
      BufferedGraphicsContext^ context;
      BufferedGraphics^ grafx;
      Byte bufferingMode;
      array<String^>^bufferingModeStrings;
      System::Windows::Forms::Timer^ timer1;
      Byte count;

   public:
      BufferingExample()
         : Form()
      {
         array<String^>^tempStrings = {"Draw to Form without OptimizedDoubleBufferring control style","Draw to Form using OptimizedDoubleBuffering control style","Draw to HDC for form"};
         bufferingModeStrings = tempStrings;

         // Configure the Form for this example.
         this->Text = "User double buffering";
         this->MouseDown += gcnew MouseEventHandler( this, &BufferingExample::MouseDownHandler );
         this->Resize += gcnew EventHandler( this, &BufferingExample::OnResize );
         this->SetStyle( static_cast<ControlStyles>(ControlStyles::AllPaintingInWmPaint | ControlStyles::UserPaint), true );

         // Configure a timer to draw graphics updates.
         timer1 = gcnew System::Windows::Forms::Timer;
         timer1->Interval = 200;
         timer1->Tick += gcnew EventHandler( this, &BufferingExample::OnTimer );
         bufferingMode = 2;
         count = 0;

         // Retrieves the BufferedGraphicsContext for the 
         // current application domain.
         context = BufferedGraphicsManager::Current;

         // Sets the maximum size for the primary graphics buffer
         // of the buffered graphics context for the application
         // domain.  Any allocation requests for a buffer larger 
         // than this will create a temporary buffered graphics 
         // context to host the graphics buffer.
         context->MaximumBuffer = System::Drawing::Size( this->Width + 1, this->Height + 1 );

         // Allocates a graphics buffer the size of this form
         // using the pixel format of the Graphics created by 
         // the Form.CreateGraphics() method, which returns a 
         // Graphics object that matches the pixel format of the form.
         grafx = context->Allocate( this->CreateGraphics(), Rectangle(0,0,this->Width,this->Height) );

         // Draw the first frame to the buffer.
         DrawToBuffer( grafx->Graphics );
      }

   private:
      void MouseDownHandler( Object^ /*sender*/, MouseEventArgs^ e )
      {
         if ( e->Button == ::MouseButtons::Right )
         {
            // Cycle the buffering mode.
            if ( ++bufferingMode > 2 )
                        bufferingMode = 0;

            // If the previous buffering mode used 
            // the OptimizedDoubleBuffering ControlStyle,
            // disable the control style.
            if ( bufferingMode == 1 )
                        this->SetStyle( ControlStyles::OptimizedDoubleBuffer, true );

            // If the current buffering mode uses
            // the OptimizedDoubleBuffering ControlStyle,
            // enabke the control style.
            if ( bufferingMode == 2 )
                        this->SetStyle( ControlStyles::OptimizedDoubleBuffer, false );

            // Cause the background to be cleared and redraw.
            count = 6;
            DrawToBuffer( grafx->Graphics );
            this->Refresh();
         }
         else
         {
            
            // Toggle whether the redraw timer is active.
            if ( timer1->Enabled )
                        timer1->Stop();
            else
                        timer1->Start();
         }
      }

   private:
      void OnTimer( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Draw randomly positioned ellipses to the buffer.
         DrawToBuffer( grafx->Graphics );

         // If in bufferingMode 2, draw to the form's HDC.
         if ( bufferingMode == 2 )

         // Render the graphics buffer to the form's HDC.
         grafx->Render( Graphics::FromHwnd( this->Handle ) );
         // If in bufferingMode 0 or 1, draw in the paint method.
         else

         // If in bufferingMode 0 or 1, draw in the paint method.
         this->Refresh();
      }

      void OnResize( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Re-create the graphics buffer for a new window size.
         context->MaximumBuffer = System::Drawing::Size( this->Width + 1, this->Height + 1 );
         if ( grafx != nullptr )
         {
            delete grafx;
            grafx = nullptr;
         }

         grafx = context->Allocate( this->CreateGraphics(), Rectangle(0,0,this->Width,this->Height) );

         // Cause the background to be cleared and redraw.
         count = 6;
         DrawToBuffer( grafx->Graphics );
         this->Refresh();
      }

      void DrawToBuffer( Graphics^ g )
      {
         // Clear the graphics buffer every five updates.
         if ( ++count > 5 )
         {
            count = 0;
            grafx->Graphics->FillRectangle( Brushes::Black, 0, 0, this->Width, this->Height );
         }

         // Draw randomly positioned and colored ellipses.
         Random^ rnd = gcnew Random;
         for ( int i = 0; i < 20; i++ )
         {
            int px = rnd->Next( 20, this->Width - 40 );
            int py = rnd->Next( 20, this->Height - 40 );
            g->DrawEllipse( gcnew Pen( Color::FromArgb( rnd->Next( 0, 255 ), rnd->Next( 0, 255 ), rnd->Next( 0, 255 ) ), 1.0f ), px, py, px + rnd->Next( 0, this->Width - px - 20 ), py + rnd->Next( 0, this->Height - py - 20 ) );
         }

         // Draw information strings.
         g->DrawString( String::Format( "Buffering Mode: {0}", bufferingModeStrings[ bufferingMode ] ), gcnew System::Drawing::Font( "Arial",8 ), Brushes::White, 10, 10 );
         g->DrawString( "Right-click to cycle buffering mode", gcnew System::Drawing::Font( "Arial",8 ), Brushes::White, 10, 22 );
         g->DrawString( "Left-click to toggle timed display refresh", gcnew System::Drawing::Font( "Arial",8 ), Brushes::White, 10, 34 );
      }

   protected:
      virtual void OnPaint( PaintEventArgs^ e ) override
      {
         grafx->Render( e->Graphics );
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew BufferingExample::BufferingExample );
}
//</Snippet1>
