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

   // Snippet for: M:System.Drawing.Font.Clone
   // <snippet1>
public:
   void Clone_Example( PaintEventArgs^ e )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Create a copy of myFont.
      System::Drawing::Font^ cloneFont = dynamic_cast<System::Drawing::Font^>(myFont->Clone());

      // Use cloneFont to draw text to the screen.
      e->Graphics->DrawString( "This is a cloned font", cloneFont, Brushes::Black, 0, 0 );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Font.Equals(System.Object)
   // <snippet2>
public:
   void Equals_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ firstFont = gcnew System::Drawing::Font( "Arial",16 );

      // Create a second Font object.
      System::Drawing::Font^ secondFont = gcnew System::Drawing::Font( gcnew FontFamily( "Arial" ),16 );

      // Test to see if firstFont is identical to secondFont.
      bool fontTest = firstFont->Equals( secondFont );

      // Display a message box with the result of the test.
      MessageBox::Show( fontTest.ToString() );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Font.FromHfont(System.IntPtr)
   // <snippet3>
private:
   [System::Runtime::InteropServices::DllImportAttribute("gdi32.dll")]
   static IntPtr GetStockObject( int fnObject );

public:
   void FromHfont_Example( PaintEventArgs^ e )
   {
      // Get a handle for a GDI font.
      IntPtr hFont = GetStockObject( 17 );

      // Create a Font object from hFont.
      System::Drawing::Font^ hfontFont = System::Drawing::Font::FromHfont( hFont );

      // Use hfontFont to draw text to the screen.
      e->Graphics->DrawString( "This font is from a GDI HFONT", hfontFont, Brushes::Black, 0, 0 );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Font.GetHashCode
   // <snippet4>
public:
   void GetHashCode_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Get the hash code for myFont.
      int hashCode = myFont->GetHashCode();

      // Display the hash code in a message box.
      MessageBox::Show( hashCode.ToString() );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.Font.GetHeight(System.Drawing.Graphics)
   // <snippet5>
public:
   void GetHeight_Example( PaintEventArgs^ e )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      //Draw text to the screen with myFont.
      e->Graphics->DrawString( "This is the first line", myFont, Brushes::Black, PointF(0,0) );

      //Get the height of myFont.
      float height = myFont->GetHeight( e->Graphics );

      //Draw text immediately below the first line of text.
      e->Graphics->DrawString( "This is the second line", myFont, Brushes::Black, PointF(0,height) );
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.Font.ToHfont
   // <snippet6>
   //Reference the GDI DeleteObject method.
public:
   [System::Runtime::InteropServices::DllImport("GDI32.dll")]
   static bool DeleteObject( IntPtr objectHandle );
   void ToHfont_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Get a handle to the Font object.
      IntPtr hFont = myFont->ToHfont();

      // Display a message box with the value of hFont.
      MessageBox::Show( hFont.ToString() );

      //Dispose of the hFont.
      DeleteObject( hFont );
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.Font.ToString
   // <snippet7>
public:
   void ToString_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Get a string that represents myFont.
      String^ fontString = myFont->ToString();

      // Display a message box with fontString.
      MessageBox::Show( fontString );
   }
   // </snippet7>
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
