#using <System.Data.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      
      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

protected:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Paint += gcnew System::Windows::Forms::PaintEventHandler( this, &Form1::Form1_Paint );
   }


   // <snippet1>
private:
   void Clone_Example1( PaintEventArgs^ e )
   {
      // Create a Bitmap object from a file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.jpg" );

      // Clone a portion of the Bitmap object.
      Rectangle cloneRect = Rectangle(0,0,100,100);
      System::Drawing::Imaging::PixelFormat format = myBitmap->PixelFormat;
      Bitmap^ cloneBitmap = myBitmap->Clone( cloneRect, format );

      // Draw the cloned portion of the Bitmap object.
      e->Graphics->DrawImage( cloneBitmap, 0, 0 );
   }
   // </snippet1>

   // <snippet2>
private:
   void Clone_Example2( PaintEventArgs^ e )
   {
      // Create a Bitmap object from a file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.jpg" );

      // Clone a portion of the Bitmap object.
      RectangleF cloneRect = RectangleF(0,0,100,100);
      System::Drawing::Imaging::PixelFormat format = myBitmap->PixelFormat;
      Bitmap^ cloneBitmap = myBitmap->Clone( cloneRect, format );

      // Draw the cloned portion of the Bitmap object.
      e->Graphics->DrawImage( cloneBitmap, 0, 0 );
   }
   // </snippet2>

   // <snippet3>
private:
	[System::Runtime::InteropServices::DllImportAttribute("user32.dll", CharSet = CharSet::Unicode)]
   static IntPtr LoadImage( int Hinstance, String^ name, int type, int width, int height, int load );

private:
   void Hicon_Example( PaintEventArgs^ e )
   {
      
      // Get a handle to an icon.
      IntPtr Hicon = LoadImage( 0, "smile.ico", 1, 0, 0, 16 );
      
      // Create a Bitmap object from the icon handle.
      Bitmap^ iconBitmap = Bitmap::FromHicon( Hicon );
      
      // Draw the Bitmap object to the screen.
      e->Graphics->DrawImage( iconBitmap, 0, 0 );
   }
   // </snippet3>

   // <snippet4>
   //<snippet11>
   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static bool DeleteObject( IntPtr hObject );
   //</snippet11>

private:
   void DemonstrateGetHbitmap()
   {
      Bitmap^ bm = gcnew Bitmap( "Picture.jpg" );
      IntPtr hBitmap = bm->GetHbitmap();
      
      // Do something with hBitmap.
      DeleteObject( hBitmap );
   }
   // </snippet4>

   // <snippet5>
   void DemonstrateGetHbitmapWithColor()
   {
      Bitmap^ bm = gcnew Bitmap( "Picture.jpg" );
      IntPtr hBitmap = bm->GetHbitmap( Color::Blue );
      
      // Do something with hBitmap.
      DeleteObject( hBitmap );
   }
   // </snippet5>

   // <snippet6>
private:
   [System::Runtime::InteropServices::DllImportAttribute("user32.dll",CharSet=CharSet::Auto)]
   static bool DestroyIcon( IntPtr handle );

private:
   [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   void GetHicon_Example( PaintEventArgs^ e )
   {
      
      // Create a Bitmap object from an image file.
      Bitmap^ myBitmap = gcnew Bitmap( "c:\\FakePhoto.jpg" );
      
      // Draw myBitmap to the screen.
      e->Graphics->DrawImage( myBitmap, 0, 0 );
      
      // Get an Hicon for myBitmap.
      IntPtr Hicon = myBitmap->GetHicon();
      
      // Create a new icon from the handle. 
      System::Drawing::Icon^ newIcon = ::Icon::FromHandle( Hicon );
      
      // Set the form Icon attribute to the new icon.
      this->Icon = newIcon;
      
      // You can now destroy the Icon, since the form creates
      // its own copy of the icon accesible through the Form.Icon property.
      DestroyIcon( newIcon->Handle );
   }
   // </snippet6>

   // <snippet7>
private:
   void GetPixel_Example( PaintEventArgs^ e )
   {
      // Create a Bitmap object from an image file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.jpg" );

      // Get the color of a pixel within myBitmap.
      Color pixelColor = myBitmap->GetPixel( 50, 50 );

      // Fill a rectangle with pixelColor.
      SolidBrush^ pixelBrush = gcnew SolidBrush( pixelColor );
      e->Graphics->FillRectangle( pixelBrush, 0, 0, 100, 100 );
   }
   // </snippet7>

   // <snippet8>
private:
   void MakeTransparent_Example1( PaintEventArgs^ e )
   {
      // Create a Bitmap object from an image file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.gif" );

      // Draw myBitmap to the screen.
      e->Graphics->DrawImage( myBitmap, 0, 0, myBitmap->Width, myBitmap->Height );

      // Make the default transparent color transparent for myBitmap.
      myBitmap->MakeTransparent();

      // Draw the transparent bitmap to the screen.
      e->Graphics->DrawImage( myBitmap, myBitmap->Width, 0, myBitmap->Width, myBitmap->Height );
   }
   // </snippet8>

   // <snippet9>
private:
   void MakeTransparent_Example2( PaintEventArgs^ e )
   {
      // Create a Bitmap object from an image file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.gif" );

      // Draw myBitmap to the screen.
      e->Graphics->DrawImage( myBitmap, 0, 0, myBitmap->Width, myBitmap->Height );

      // Get the color of a background pixel.
      Color backColor = myBitmap->GetPixel( 1, 1 );

      // Make backColor transparent for myBitmap.
      myBitmap->MakeTransparent( backColor );

      // Draw the transparent bitmap to the screen.
      e->Graphics->DrawImage( myBitmap, myBitmap->Width, 0, myBitmap->Width, myBitmap->Height );
   }
   // </snippet9>

   // <snippet10>
private:
   void SetPixel_Example( PaintEventArgs^ e )
   {
      // Create a Bitmap object from a file.
      Bitmap^ myBitmap = gcnew Bitmap( "Grapes.jpg" );

      // Draw myBitmap to the screen.
      e->Graphics->DrawImage( myBitmap, 0, 0, myBitmap->Width, myBitmap->Height );

      // Set each pixel in myBitmap to black.
      for ( int Xcount = 0; Xcount < myBitmap->Width; Xcount++ )
      {
         for ( int Ycount = 0; Ycount < myBitmap->Height; Ycount++ )
         {
            myBitmap->SetPixel( Xcount, Ycount, Color::Black );
         }
      }

      // Draw myBitmap to the screen again.
      e->Graphics->DrawImage( myBitmap, myBitmap->Width, 0, myBitmap->Width, myBitmap->Height );
   }
   // </snippet10>

private:
   void Form1_Paint( Object^ /*sender*/, System::Windows::Forms::PaintEventArgs^ /*e*/ ){}
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

/*
This example of the
  Decimal::ToInt64( Decimal ) and
  Decimal::ToUInt64( Decimal )
methods generates the following output. It
displays several converted Decimal values.

         Decimal argument     __int64/exception      unsigned __int64
         ----------------     -----------------      ----------------
                      123                   123                   123
                  123.000                   123                   123
                  123.999                   123                   123
 18446744073709551615.999     OverflowException  18446744073709551615
     18446744073709551616     OverflowException     OverflowException
  9223372036854775807.999   9223372036854775807   9223372036854775807
      9223372036854775808     OverflowException   9223372036854775808
                   -0.999                     0                     0
                       -1                    -1     OverflowException
 -9223372036854775808.999  -9223372036854775808     OverflowException
     -9223372036854775809     OverflowException     OverflowException
*/
