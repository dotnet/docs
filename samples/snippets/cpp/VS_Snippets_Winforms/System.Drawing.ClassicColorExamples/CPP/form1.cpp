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

public:

   // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32)
   // <snippet1>
   void FromArgb4( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Transparent red, green, and blue brushes.
      SolidBrush^ trnsRedBrush = gcnew SolidBrush( Color::FromArgb( 0x78FF0000 ) );
      SolidBrush^ trnsGreenBrush = gcnew SolidBrush( Color::FromArgb( 0x7800FF00 ) );
      SolidBrush^ trnsBlueBrush = gcnew SolidBrush( Color::FromArgb( 0x780000FF ) );

      // Base and height of the triangle that is used to position the
      // circles. Each vertex of the triangle is at the center of one of the
      // 3 circles. The base is equal to the diameter of the circles.
      float triBase = 100;
      float triHeight = (float)Math::Sqrt( 3 * (triBase * triBase) / 4 );

      // coordinates of first circle's bounding rectangle.
      float x1 = 40;
      float y1 = 40;

      // Fill 3 over-lapping circles. Each circle is a different color.
      g->FillEllipse( trnsRedBrush, x1, y1, 2 * triHeight, 2 * triHeight );
      g->FillEllipse( trnsGreenBrush, x1 + triBase / 2, y1 + triHeight, 2 * triHeight, 2 * triHeight );
      g->FillEllipse( trnsBlueBrush, x1 + triBase, y1, 2 * triHeight, 2 * triHeight );
   }
   // </snippet1>

   // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Drawing.Color)
   // <snippet2>
   void FromArgb3( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Opaque colors (alpha value defaults to 255 -- max value).
      Color red = Color::FromArgb( 255, 0, 0 );
      Color green = Color::FromArgb( 0, 255, 0 );
      Color blue = Color::FromArgb( 0, 0, 255 );

      // Solid brush initialized to red.
      SolidBrush^ myBrush = gcnew SolidBrush( red );
      int alpha;

      // x coordinate of first red rectangle
      int x = 50;

      // y coordinate of first red rectangle
      int y = 50;

      // Fill rectangles with red, varying the alpha value from 25 to 250.
      for ( alpha = 25; alpha <= 250; alpha += 25 )
      {
         myBrush->Color = Color::FromArgb( alpha, red );
         g->FillRectangle( myBrush, x, y, 50, 100 );
         g->FillRectangle( myBrush, x, y + 250, 50, 50 );
         x += 50;
      }
      x = 50;

      // y coordinate of first green rectangle
      y += 50;

      // Fill rectangles with green, varying the alpha value from 25 to 250.
      for ( alpha = 25; alpha <= 250; alpha += 25 )
      {
         myBrush->Color = Color::FromArgb( alpha, green );
         g->FillRectangle( myBrush, x, y, 50, 150 );
         x += 50;
      }
      x = 50;

      // y coordinate of first blue rectangle
      y += 100;

      // Fill rectangles with blue, varying the alpha value from 25 to 250.
      for ( alpha = 25; alpha <= 250; alpha += 25 )
      {
         myBrush->Color = Color::FromArgb( alpha, blue );
         g->FillRectangle( myBrush, x, y, 50, 150 );
         x += 50;
      }
   }
   // </snippet2>

   // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Int32,System.Int32)
   // <snippet3>
   void FromArgb2( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Opaque colors (alpha value defaults to 255 -- max value).
      Color red = Color::FromArgb( 255, 0, 0 );
      Color green = Color::FromArgb( 0, 255, 0 );
      Color blue = Color::FromArgb( 0, 0, 255 );

      // Solid brush initialized to red.
      SolidBrush^ myBrush = gcnew SolidBrush( red );
      int alpha;

      // x coordinate of first red rectangle
      int x = 50;

      // y coordinate of first red rectangle
      int y = 50;

      // Fill rectangles with red, varying the alpha value from 25 to 250.
      for ( alpha = 25; alpha <= 250; alpha += 25 )
      {
         myBrush->Color = Color::FromArgb( alpha, red );
         g->FillRectangle( myBrush, x, y, 50, 100 );
         g->FillRectangle( myBrush, x, y + 250, 50, 50 );
         x += 50;
      }
      x = 50;

      // y coordinate of first green rectangle.
      y += 50;

      // Fill rectangles with green, varying the alpha value from 25 to 250.
      for ( alpha = 25; alpha <= 250; alpha += 25 )
      {
         myBrush->Color = Color::FromArgb( alpha, green );
         g->FillRectangle( myBrush, x, y, 50, 150 );
         x += 50;
      }
      x = 50;

      // y coordinate of first blue rectangle.
      y += 100;

      // Fill rectangles with blue, varying the alpha value from 25 to 250.
      for ( alpha = 25; alpha <= 250; alpha += 25 )
      {
         myBrush->Color = Color::FromArgb( alpha, blue );
         g->FillRectangle( myBrush, x, y, 50, 150 );
         x += 50;
      }
   }
   // </snippet3>

   // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Int32,System.Int32,System.Int32)
   // <snippet4>
   void FromArgb1( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Transparent red, green, and blue brushes.
      SolidBrush^ trnsRedBrush = gcnew SolidBrush( Color::FromArgb( 120, 255, 0, 0 ) );
      SolidBrush^ trnsGreenBrush = gcnew SolidBrush( Color::FromArgb( 120, 0, 255, 0 ) );
      SolidBrush^ trnsBlueBrush = gcnew SolidBrush( Color::FromArgb( 120, 0, 0, 255 ) );

      // Base and height of the triangle that is used to position the
      // circles. Each vertex of the triangle is at the center of one of the
      // 3 circles. The base is equal to the diameter of the circles.
      float triBase = 100;
      float triHeight = (float)Math::Sqrt( 3 * (triBase * triBase) / 4 );

      // Coordinates of first circle's bounding rectangle.
      float x1 = 40;
      float y1 = 40;

      // Fill 3 over-lapping circles. Each circle is a different color.
      g->FillEllipse( trnsRedBrush, x1, y1, 2 * triHeight, 2 * triHeight );
      g->FillEllipse( trnsGreenBrush, x1 + triBase / 2, y1 + triHeight, 2 * triHeight, 2 * triHeight );
      g->FillEllipse( trnsBlueBrush, x1 + triBase, y1, 2 * triHeight, 2 * triHeight );
   }
   // </snippet4>

   // Snippet for: M:System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor)
   // <snippet5>
   void KnownColorBrightnessExample1( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Color structures. One is a variable used for temporary storage. The other
      // is a constant used for comparisons.
      Color someColor = Color::FromArgb( 0 );
      Color redShade = Color::FromArgb( 255, 200, 0, 100 );

      // Array to store KnownColor values that match the brightness of the
      // redShade color.
      array<KnownColor>^colorMatches = gcnew array<KnownColor>(15);

      // Number of matches found.
      int count = 0;

      // Iterate through the KnownColor enums until 15 matches are found.
      for ( KnownColor enumValue = (KnownColor)0; enumValue <= KnownColor::YellowGreen && count < 15; enumValue = enumValue + (KnownColor)1 )
      {
         someColor = Color::FromKnownColor( enumValue );
         if ( someColor.GetBrightness() == redShade.GetBrightness() )
                  colorMatches[ count++ ] = enumValue;
      }

      // Display the redShade color and its argb value.
      SolidBrush^ myBrush1 = gcnew SolidBrush( redShade );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",12 );
      int x = 20;
      int y = 20;
      someColor = redShade;
      g->FillRectangle( myBrush1, x, y, 100, 30 );
      g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );
      
      // Iterate through the matches that were found and display each color that
      // Corresponds with the enum value in the array. also display the name of
      // The KnownColor.
      for ( int i = 0; i < count; i++ )
      {
         y += 40;
         someColor = Color::FromKnownColor( colorMatches[ i ] );
         myBrush1->Color = someColor;
         g->FillRectangle( myBrush1, x, y, 100, 30 );
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );
      }
   }
   // </snippet5>

   // Snippet for: M:System.Drawing.Color.GetBrightness
   // <snippet6>
   void KnownColorBrightnessExample2( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Color structures. One is a variable used for temporary storage. The other
      // is a constant used for comparisons.
      Color someColor = Color::FromArgb( 0 );
      Color redShade = Color::FromArgb( 255, 200, 0, 100 );

      // Array to store KnownColor values that match the brightness of the
      // redShade color.
      array<KnownColor>^colorMatches = gcnew array<KnownColor>(15);

      // Number of matches found.
      int count = 0;

      // Iterate through the KnownColor enums until 15 matches are found.
      for ( KnownColor enumValue = (KnownColor)0; enumValue <= KnownColor::YellowGreen && count < 15; enumValue = enumValue + (KnownColor)1 )
      {
         someColor = Color::FromKnownColor( enumValue );
         if ( someColor.GetBrightness() == redShade.GetBrightness() )
                  colorMatches[ count++ ] = enumValue;
      }

      // display the redShade color and its argb value.
      SolidBrush^ myBrush1 = gcnew SolidBrush( redShade );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",12 );
      int x = 20;
      int y = 20;
      someColor = redShade;
      g->FillRectangle( myBrush1, x, y, 100, 30 );
      g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );

      // Iterate through the matches that were found and display each color that
      // corresponds with the enum value in the array. also display the name of
      // The KnownColor.
      for ( int i = 0; i < count; i++ )
      {
         y += 40;
         someColor = Color::FromKnownColor( colorMatches[ i ] );
         myBrush1->Color = someColor;
         g->FillRectangle( myBrush1, x, y, 100, 30 );
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );
      }
   }
   // </snippet6>

   // Snippet for: M:System.Drawing.Color.GetHue
   // <snippet7>
   void GetHueExample( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Color structures. One is a variable used for temporary storage. The other
      // is a constant used for comparisons.
      Color someColor = Color::FromArgb( 0 );
      Color redShade = Color::FromArgb( 255, 200, 0, 100 );

      // Array to store KnownColor values that match the hue of the redShade
      // color.
      array<KnownColor>^colorMatches = gcnew array<KnownColor>(15);

      // Number of matches found.
      int count = 0;

      // Iterate through the KnownColor enums until 15 matches are found.
      for ( KnownColor enumValue = (KnownColor)0; enumValue <= KnownColor::YellowGreen && count < 15; enumValue = enumValue + (KnownColor)1 )
      {
         someColor = Color::FromKnownColor( enumValue );
         if ( someColor.GetHue() == redShade.GetHue() )
                  colorMatches[ count++ ] = enumValue;
      }

      // Display the redShade color and its argb value.
      SolidBrush^ myBrush1 = gcnew SolidBrush( redShade );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",12 );
      int x = 20;
      int y = 20;
      someColor = redShade;
      g->FillRectangle( myBrush1, x, y, 100, 30 );
      g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );

      // Iterate through the matches that were found and display each color that
      // corresponds with the enum value in the array. also display the name of
      // the KnownColor.
      for ( int i = 0; i < count; i++ )
      {
         y += 40;
         someColor = Color::FromKnownColor( colorMatches[ i ] );
         myBrush1->Color = someColor;
         g->FillRectangle( myBrush1, x, y, 100, 30 );
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );
      }
   }
   // </snippet7>

   // Snippet for: M:System.Drawing.Color.GetSaturation
   // <snippet8>
   void GetSatExample( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Color structures. One is a variable used for temporary storage. The other
      // is a constant used for comparisons.
      Color someColor = Color::FromArgb( 0 );
      Color redShade = Color::FromArgb( 255, 200, 0, 100 );

      // Array to store KnownColor values that match the saturation of the
      // redShade color.
      array<KnownColor>^colorMatches = gcnew array<KnownColor>(15);

      // Number of matches found.
      int count = 0;

      // Iterate through the KnownColor enums until 15 matches are found.
      for ( KnownColor enumValue = (KnownColor)0; enumValue <= KnownColor::YellowGreen && count < 15; enumValue = enumValue + (KnownColor)1 )
      {
         someColor = Color::FromKnownColor( enumValue );
         if ( someColor.GetSaturation() == redShade.GetSaturation() )
                  colorMatches[ count++ ] = enumValue;
      }

      // Display the redShade color and its argb value.
      SolidBrush^ myBrush1 = gcnew SolidBrush( redShade );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",12 );
      int x = 20;
      int y = 20;
      someColor = redShade;
      g->FillRectangle( myBrush1, x, y, 100, 30 );
      g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );

      // Iterate through the matches that were found and display each color that
      // corresponds with the enum value in the array. also display the name of
      // the KnownColor.
      for ( int i = 0; i < count; i++ )
      {
         y += 40;
         someColor = Color::FromKnownColor( colorMatches[ i ] );
         myBrush1->Color = someColor;
         g->FillRectangle( myBrush1, x, y, 100, 30 );
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 120, (float)y );
      }
   }
   // </snippet8>

   // Snippet for: M:System.Drawing.Color.ToArgb
   // <snippet9>
   void ToArgbToStringExample1( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Color structure used for temporary storage.
      Color someColor = Color::FromArgb( 0 );

      // Array to store KnownColor values that match the criteria.
      array<KnownColor>^colorMatches = gcnew array<KnownColor>(167);

      // Number of matches found.
      int count = 0;

      // Iterate through the KnownColor enums to find all corresponding colors
      // that have a nonzero green component and zero-value red component and
      // that are not system colors.
      for ( KnownColor enumValue = (KnownColor)0; enumValue <= KnownColor::YellowGreen; enumValue = enumValue + (KnownColor)1 )
      {
         someColor = Color::FromKnownColor( enumValue );
         if ( someColor.G != 0 && someColor.R == 0 &&  !someColor.IsSystemColor )
                  colorMatches[ count++ ] = enumValue;
      }
      SolidBrush^ myBrush1 = gcnew SolidBrush( someColor );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",9 );
      int x = 40;
      int y = 40;

      // Iterate through the matches that were found and display each color that
      // corresponds with the enum value in the array. also display the name of
      // the KnownColor and the ARGB components.
      for ( int i = 0; i < count; i++ )
      {
         // Display the color.
         someColor = Color::FromKnownColor( colorMatches[ i ] );
         myBrush1->Color = someColor;
         g->FillRectangle( myBrush1, x, y, 50, 30 );

         // Display KnownColor name and the four component values. To display the
         // component values:  Use the ToArgb method to get the 32-bit ARGB value
         // of someColor, which was created from a KnownColor. Then create a
         // Color structure from the 32-bit ARGB value and set someColor equal to
         // this new Color structure. Then use the ToString method to convert it to
         // a string.
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 55, (float)y );
         someColor = Color::FromArgb( someColor.ToArgb() );
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 55, (float)y + 15 );
         y += 40;
      }
   }
   // </snippet9>

   // Snippet for: M:System.Drawing.Color.ToString
   // <snippet10>
   void ToArgbToStringExample2( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Color structure used for temporary storage.
      Color someColor = Color::FromArgb( 0 );

      // Array to store KnownColor values that match the criteria.
      array<KnownColor>^colorMatches = gcnew array<KnownColor>(167);

      // Number of matches found.
      int count = 0;

      // Iterate through the KnownColor enums to find all corresponding colors
      // that have a nonzero green component and zero-value red component and
      // that are not system colors.
      for ( KnownColor enumValue = (KnownColor)0; enumValue <= KnownColor::YellowGreen; enumValue = enumValue + (KnownColor)1 )
      {
         someColor = Color::FromKnownColor( enumValue );
         if ( someColor.G != 0 && someColor.R == 0 &&  !someColor.IsSystemColor )
                  colorMatches[ count++ ] = enumValue;
      }
      SolidBrush^ myBrush1 = gcnew SolidBrush( someColor );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",9 );
      int x = 40;
      int y = 40;

      // Iterate through the matches that were found and display each color that
      // corresponds with the enum value in the array. also display the name of
      // the KnownColor and the ARGB components.
      for ( int i = 0; i < count; i++ )
      {
         // Display the color.
         someColor = Color::FromKnownColor( colorMatches[ i ] );
         myBrush1->Color = someColor;
         g->FillRectangle( myBrush1, x, y, 50, 30 );
         
         // Display KnownColor name and the four component values. To display the
         // component values:  Use the ToArgb method to get the 32-bit ARGB value
         // of someColor, which was created from a KnownColor. Then create a
         // Color structure from the 32-bit ARGB value and set someColor equal to
         // this new Color structure. Then use the ToString method to convert it to
         // a string.
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 55, (float)y );
         someColor = Color::FromArgb( someColor.ToArgb() );
         g->DrawString( someColor.ToString(), myFont, Brushes::Black, (float)x + 55, (float)y + 15 );
         y += 40;
      }
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
