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

   // Snippet for: M:System.Drawing.StringFormat.GetTabStops(System.Single@)
   // <snippet1>
public:
   void GetSetTabStopsExample1( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Tools used for drawing, painting.
      Pen^ redPen = gcnew Pen( Color::FromArgb( 255, 255, 0, 0 ) );
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::FromArgb( 255, 0, 0, 255 ) );

      // Layout and format for text.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Times New Roman",12 );
      StringFormat^ myStringFormat = gcnew StringFormat;
      Rectangle enclosingRectangle = Rectangle(20,20,500,100);
      array<Single>^tabStops = {150.0f,100.0f,100.0f};

      // Text with tabbed columns.
      String^ myString = "Name\tTab 1\tTab 2\tTab 3\nGeorge Brown\tOne\tTwo\tThree";

      // Set the tab stops, paint the text specified by myString, and draw the
      // rectangle that encloses the text.
      myStringFormat->SetTabStops( 0.0f, tabStops );
      g->DrawString( myString, myFont, blueBrush, enclosingRectangle, myStringFormat );
      g->DrawRectangle( redPen, enclosingRectangle );

      // Get the tab stops.
      float firstTabOffset;
      array<Single>^tabStopsObtained = myStringFormat->GetTabStops( firstTabOffset );
      for ( int j = 0; j < tabStopsObtained->Length; j++ )
      {
         // Inspect or use the value in tabStopsObtained[j].
         Console::WriteLine( "\n  Tab stop {0} = {1}", j, tabStopsObtained[ j ] );
      }
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.StringFormat.SetDigitSubstitution(System.Int32,System.Drawing.StringDigitSubstitute)
   // <snippet2>
public:
   void SetDigitSubExample( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::FromArgb( 255, 0, 0, 255 ) );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Courier New",12 );
      StringFormat^ myStringFormat = gcnew StringFormat;
      String^ myString = "0 1 2 3 4 5 6 7 8 9";

      // Arabic (0x0C01) digits.
      // Use National substitution method.
      myStringFormat->SetDigitSubstitution( 0x0C01, StringDigitSubstitute::National );
      g->DrawString( String::Format( "Arabic:\nMethod of substitution = National:     {0}", myString ), myFont, blueBrush, PointF(10.0f,20.0f), myStringFormat );

      // Use Traditional substitution method.
      myStringFormat->SetDigitSubstitution( 0x0C01, StringDigitSubstitute::Traditional );
      g->DrawString( String::Format( "Method of substitution = Traditional:  {0}", myString ), myFont, blueBrush, PointF(10.0f,55.0f), myStringFormat );

      // Thai (0x041E) digits.
      // Use National substitution method.
      myStringFormat->SetDigitSubstitution( 0x041E, StringDigitSubstitute::National );
      g->DrawString( String::Format( "Thai:\nMethod of substitution = National:     {0}", myString ), myFont, blueBrush, PointF(10.0f,85.0f), myStringFormat );

      // Use Traditional substitution method.
      myStringFormat->SetDigitSubstitution( 0x041E, StringDigitSubstitute::Traditional );
      g->DrawString( String::Format( "Method of substitution = Traditional:  {0}", myString ), myFont, blueBrush, PointF(10.0f,120.0f), myStringFormat );
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.StringFormat.SetMeasurableCharacterRanges(System.Drawing.CharacterRange[])
   // <snippet3>
   void SetMeasCharRangesExample( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;
      SolidBrush^ redBrush = gcnew SolidBrush( Color::FromArgb( 50, 255, 0, 0 ) );

      // Layout rectangles, font, and string format used for displaying string.
      Rectangle layoutRectA = Rectangle(20,20,165,80);
      Rectangle layoutRectB = Rectangle(20,110,165,80);
      Rectangle layoutRectC = Rectangle(20,200,240,80);
      System::Drawing::Font^ tnrFont = gcnew System::Drawing::Font( "Times New Roman",16 );
      StringFormat^ strFormat = gcnew StringFormat;

      // Ranges of character positions within a string.
      array<CharacterRange>^ charRanges = {CharacterRange(3,5),CharacterRange(15,2),CharacterRange(30,15)};

      // Each region specifies the area occupied by the characters within a
      // range of positions. the values are obtained by using a method that
      // measures the character ranges.
      array<System::Drawing::Region^>^charRegions = gcnew array<System::Drawing::Region^>(charRanges->Length);

      // String to be displayed.
      String^ str = "The quick, brown fox easily jumps over the lazy dog.";

      // Set the char ranges for the string format.
      strFormat->SetMeasurableCharacterRanges( charRanges );

      // loop counter (unsigned 8-bit integer)
      Byte i;

      // Measure the char ranges for a given string and layout rectangle. Each
      // area occupied by the characters in a range is stored as a region. Then
      // draw the string and layout rectangle, and paint the regions.
      charRegions = g->MeasureCharacterRanges( str, tnrFont, layoutRectA, strFormat );
      g->DrawString( str, tnrFont, Brushes::Blue, layoutRectA, strFormat );
      g->DrawRectangle( Pens::Black, layoutRectA );

      // Paint the regions.
      for ( i = 0; i < charRegions->Length; i++ )
         g->FillRegion( redBrush, charRegions[ i ] );

      // Repeat the above steps, but include trailing spaces in the char
      // range measurement by setting the appropriate string format flag.
      strFormat->FormatFlags = StringFormatFlags::MeasureTrailingSpaces;
      charRegions = g->MeasureCharacterRanges( str, tnrFont, layoutRectB, strFormat );
      g->DrawString( str, tnrFont, Brushes::Blue, layoutRectB, strFormat );
      g->DrawRectangle( Pens::Black, layoutRectB );
      for ( i = 0; i < charRegions->Length; i++ )
         g->FillRegion( redBrush, charRegions[ i ] );

      // Clear all the format flags.
      strFormat->FormatFlags = StringFormatFlags(0);

      // Repeat the steps, but use a different layout rectangle. the dimensions
      // of the layout rectangle and the size of the font both affect the
      // character range measurement.
      charRegions = g->MeasureCharacterRanges( str, tnrFont, layoutRectC, strFormat );
      g->DrawString( str, tnrFont, Brushes::Blue, layoutRectC, strFormat );
      g->DrawRectangle( Pens::Black, layoutRectC );

      // Paint the regions.
      for ( i = 0; i < charRegions->Length; i++ )
         g->FillRegion( redBrush, charRegions[ i ] );
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.StringFormat.SetTabStops(System.Single,System.Single[])
   // <snippet4>
   void GetSetTabStopsExample2( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Tools used for drawing, painting.
      Pen^ redPen = gcnew Pen( Color::FromArgb( 255, 255, 0, 0 ) );
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::FromArgb( 255, 0, 0, 255 ) );

      // Layout and format for text.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Times New Roman",12 );
      StringFormat^ myStringFormat = gcnew StringFormat;
      Rectangle enclosingRectangle = Rectangle(20,20,500,100);
      array<Single>^tabStops = {150.0f,100.0f,100.0f};

      // Text with tabbed columns.
      String^ myString = "Name\tTab 1\tTab 2\tTab 3\nGeorge Brown\tOne\tTwo\tThree";

      // Set the tab stops, paint the text specified by myString, draw the
      // rectangle that encloses the text.
      myStringFormat->SetTabStops( 0.0f, tabStops );
      g->DrawString( myString, myFont, blueBrush, enclosingRectangle, myStringFormat );
      g->DrawRectangle( redPen, enclosingRectangle );

      // Get the tab stops.
      float firstTabOffset;
      array<Single>^tabStopsObtained = myStringFormat->GetTabStops( firstTabOffset );
      for ( int j = 0; j < tabStopsObtained->Length; j++ )
      {
         // Inspect or use the value in tabStopsObtained[j].
         Console::WriteLine( "\n  Tab stop {0} = {1}", j, tabStopsObtained[ j ] );
      }
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.StringFormat.ToString
   // <snippet5>
   void ToStringExample( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::FromArgb( 255, 0, 0, 255 ) );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Times New Roman",14 );
      StringFormat^ myStringFormat = gcnew StringFormat;

      // String variable to hold the values of the StringFormat object.
      String^ strFmtString;

      // Convert the string format object to a string (only certain information
      // in the object is converted) and display the string.
      strFmtString = myStringFormat->ToString();
      g->DrawString( String::Format( "Before changing properties:   {0}", myStringFormat ), myFont, blueBrush, 20, 40 );

      // Change some properties of the string format
      myStringFormat->Trimming = StringTrimming::None;
      myStringFormat->FormatFlags = (StringFormatFlags)(StringFormatFlags::NoWrap | StringFormatFlags::NoClip);

      // Convert the string format object to a string and display the string.
      // The string will be different because the properties of the string
      // format have changed.
      strFmtString = myStringFormat->ToString();
      g->DrawString( String::Format( "After changing properties:   {0}", myStringFormat ), myFont, blueBrush, 20, 70 );
   }
   // </snippet5>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
