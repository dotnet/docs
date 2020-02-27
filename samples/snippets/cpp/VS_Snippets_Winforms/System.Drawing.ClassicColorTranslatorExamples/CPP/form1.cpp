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
      this->components = gcnew System::ComponentModel::Container;
      this->Size = System::Drawing::Size( 300, 300 );
      this->Text = "Form1";
   }

   // Snippet for: M:System.Drawing.ColorTranslator.FromHtml(System.String)
   // <snippet1>
public:
   void FromHtml_Example( PaintEventArgs^ e )
   {
      // Create a string representation of an HTML color.
      String^ htmlColor = "Blue";

      // Translate htmlColor to a GDI+ Color structure.
      Color myColor = ColorTranslator::FromHtml( htmlColor );

      // Fill a rectangle with myColor.
      e->Graphics->FillRectangle( gcnew SolidBrush( myColor ), 0, 0, 100, 100 );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.ColorTranslator.FromOle(System.Int32)
   // <snippet2>
public:
   void FromOle_Example( PaintEventArgs^ e )
   {
      // Create an integer representation of an OLE color.
      int oleColor = 0xFF00;

      // Translate oleColor to a GDI+ Color structure.
      Color myColor = ColorTranslator::FromOle( oleColor );

      // Fill a rectangle with myColor.
      e->Graphics->FillRectangle( gcnew SolidBrush( myColor ), 0, 0, 100, 100 );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.ColorTranslator.FromWin32(System.Int32)
   // <snippet3>
public:
   void FromWin32_Example( PaintEventArgs^ e )
   {
      // Create an integer representation of a Windows color.
      int winColor = 0xA000;

      // Translate winColor to a GDI+ Color structure.
      Color myColor = ColorTranslator::FromWin32( winColor );

      // Fill a rectangle with myColor.
      e->Graphics->FillRectangle( gcnew SolidBrush( myColor ), 0, 0, 100, 100 );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color)
   // <snippet4>
public:
   void ToHtml_Example( PaintEventArgs^ /*e*/ )
   {
      // Create an instance of a Color structure.
      Color myColor = Color::Red;

      // Translate myColor to an HTML color.
      String^ htmlColor = ColorTranslator::ToHtml( myColor );

      // Show a message box with the value of htmlColor.
      MessageBox::Show( htmlColor );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.ColorTranslator.ToOle(System.Drawing.Color)
   // <snippet5>
public:
   void ToOle_Example( PaintEventArgs^ /*e*/ )
   {
      // Create an instance of a Color structure.
      Color myColor = Color::Red;

      // Translate myColor to an OLE color.
      int oleColor = ColorTranslator::ToOle( myColor );

      // Show a message box with the value of oleColor.
      MessageBox::Show( oleColor.ToString() );
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color)
   // <snippet6>
public:
   void ToWin32_Example( PaintEventArgs^ /*e*/ )
   {
      // Create an instance of a Color structure.
      Color myColor = Color::Red;

      // Translate myColor to an OLE color.
      int winColor = ColorTranslator::ToWin32( myColor );

      // Show a message box with the value of winColor.
      MessageBox::Show( winColor.ToString() );
   }
   // </snippet6>
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
