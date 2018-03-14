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

   // Snippet for: M:System.Drawing.FontFamily.Equals(System.Object)
   // <snippet1>
public:
   void Equals_Example( PaintEventArgs^ /*e*/ )
   {
      // Create two FontFamily objects.
      FontFamily^ firstFontFamily = gcnew FontFamily( "Arial" );
      FontFamily^ secondFontFamily = gcnew FontFamily( "Times New Roman" );

      // Check to see if the two font families are equivalent.
      bool equalFonts = firstFontFamily->Equals( secondFontFamily );

      // Display the result of the test in a message box.
      MessageBox::Show( equalFonts.ToString() );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.FontFamily.GetCellAscent(System.Drawing.FontStyle)
   // <snippet2>
public:
   void GetCellAscent_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ ascentFontFamily = gcnew FontFamily( "arial" );

      // Get the cell ascent of the font family in design units.
      int cellAscent = ascentFontFamily->GetCellAscent( FontStyle::Regular );

      // Draw the result as a string to the screen.
      e->Graphics->DrawString( String::Format( "ascentFontFamily.GetCellAscent() returns {0}.", cellAscent ),
            gcnew System::Drawing::Font( ascentFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.FontFamily.GetCellDescent(System.Drawing.FontStyle)
   // <snippet3>
public:
   void GetCellDescent_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ descentFontFamily = gcnew FontFamily( "arial" );

      // Get the cell descent of the font family in design units.
      int cellDescent = descentFontFamily->GetCellDescent( FontStyle::Regular );

      // Draw the result as a string to the screen.
      e->Graphics->DrawString( String::Format( "descentFontFamily.GetCellDescent() returns {0}.", cellDescent ),
            gcnew System::Drawing::Font( descentFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.FontFamily.GetEmHeight(System.Drawing.FontStyle)
   // <snippet4>
public:
   void GetEmHeight_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ emFontFamily = gcnew FontFamily( "arial" );

      // Get the em height of the font family in design units.
      int emHeight = emFontFamily->GetEmHeight( FontStyle::Regular );

      // Draw the result as a string to the screen.
      e->Graphics->DrawString( String::Format( "emFontFamily.GetEmHeight() returns {0}.", emHeight ),
            gcnew System::Drawing::Font( emFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.FontFamily.GetFamilies(System.Drawing.Graphics)
   // <snippet5>
public:
   void GetFamilies_Example( PaintEventArgs^ e )
   {
      // Get an array of the available font families.
      array<FontFamily^>^families = FontFamily::GetFamilies( e->Graphics );

      // Draw text using each of the font families.
      System::Drawing::Font^ familiesFont;
      String^ familyString;
      float spacing = 0;
      IEnumerator^ myEnum = families->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         FontFamily^ family = safe_cast<FontFamily^>(myEnum->Current);
         if ( family->IsStyleAvailable( FontStyle::Regular ) )
         {
            familiesFont = gcnew System::Drawing::Font( family,16 );
            familyString = String::Format( "This is the {0} family.", family->Name );
            e->Graphics->DrawString( familyString, familiesFont, Brushes::Black, PointF(0,spacing) );
            spacing += familiesFont->Height;
         }
      }
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.FontFamily.GetHashCode
   // <snippet6>
public:
   void GetHashCode_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Get the hash code for myFontFamily.
      int hashCode = myFontFamily->GetHashCode();

      // Draw the value of hashCode to the screen as a string.
      e->Graphics->DrawString( String::Format( "hashCode = {0}", hashCode ),
            gcnew System::Drawing::Font( myFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.FontFamily.GetLineSpacing(System.Drawing.FontStyle)
   // <snippet7>
public:
   void GetLineSpacing_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Get the line spacing for myFontFamily.
      int lineSpacing = myFontFamily->GetLineSpacing( FontStyle::Regular );

      // Draw the value of lineSpacing to the screen as a string.
      e->Graphics->DrawString( String::Format( "lineSpacing = {0}", lineSpacing ),
            gcnew System::Drawing::Font( myFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }
   // </snippet7>

   // Snippet for: M:System.Drawing.FontFamily.GetName(System.Int32)
   // <snippet8>
public:
   void GetName_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Get the name of myFontFamily.
      String^ familyName = myFontFamily->GetName( 0 );

      // Draw the name of the myFontFamily to the screen as a string.
      e->Graphics->DrawString( String::Format( "The family name is {0}", familyName ),
            gcnew System::Drawing::Font( myFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }
   // </snippet8>

   // Snippet for: M:System.Drawing.FontFamily.IsStyleAvailable(System.Drawing.FontStyle)
   // <snippet9>
public:
   void IsStyleAvailable_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Test whether myFontFamily is available in Italic.
      if ( myFontFamily->IsStyleAvailable( FontStyle::Italic ) )
      {
         // Create a Font object using myFontFamily.
         System::Drawing::Font^ familyFont = gcnew System::Drawing::Font( myFontFamily,16,FontStyle::Italic );

         // Use familyFont to draw text to the screen.
         e->Graphics->DrawString( myFontFamily->Name + " is available in Italic",
               familyFont, Brushes::Black, PointF(0,0) );
      }
   }
   // </snippet9>

   // Snippet for: M:System.Drawing.FontFamily.ToString
   // <snippet10>
public:
   void ToString_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Draw a string representation of myFontFamily to the screen.
      e->Graphics->DrawString( myFontFamily->ToString(), gcnew System::Drawing::Font( myFontFamily,16 ),
            Brushes::Black, PointF(0,0) );
   }
   // </snippet10>
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
