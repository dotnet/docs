

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System::Drawing;
using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing::Drawing2D;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      PopulateListBoxWithFonts();
      PopulateListBoxWithGraphicsResolution();
      this->Paint += gcnew PaintEventHandler( this, &Form1::Form1_Paint );
      this->Button1->Click += gcnew EventHandler( this, &Form1::Button1_Click );
      
      //Add any initialization after the InitializeComponent() call
   }

protected:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::ListBox^ listBox1;
   System::Windows::Forms::Button^ Button1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->listBox1 = gcnew System::Windows::Forms::ListBox;
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      //
      //listBox1
      //
      this->listBox1->Location = System::Drawing::Point( 88, 112 );
      this->listBox1->Name = "listBox1";
      this->listBox1->Size = System::Drawing::Size( 120, 95 );
      this->listBox1->TabIndex = 0;

      //
      //Button1
      //
      this->Button1->Location = System::Drawing::Point( 120, 24 );
      this->Button1->Name = "Button1";
      this->Button1->TabIndex = 1;
      this->Button1->Text = "Button1";

      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Button1 );
      this->Controls->Add( this->listBox1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   // The following code example shows all the font families in the
   // Families property of the FontFamily class. This example is 
   // designed to be used with a Windows Form. To run this example, 
   // add a ListBox named listBox1 to a form and call the 
   // PopulateListBoxWithFonts method from the form's constructor.

   //<snippet1>
private:
   void PopulateListBoxWithFonts()
   {
      listBox1->Width = 200;
      listBox1->Location = Point(40,120);
      System::Collections::IEnumerator^ myEnum = FontFamily::Families->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         FontFamily^ oneFontFamily = safe_cast<FontFamily^>(myEnum->Current);
         listBox1->Items->Add( oneFontFamily->Name );
      }
   }
   //</snippet1>

   // The following method shows the use of the DpiX and DpiY
   // properties. This example is designed for use with a Windows Form. 
   // To run this example, paste it into a form that contains a ListBox named 
   // listBox1 and call this method from the form's constructor or Load event.

   //<snippet4>
private:
   void PopulateListBoxWithGraphicsResolution()
   {
      Graphics^ boxGraphics = listBox1->CreateGraphics();

      // Graphics* formGraphics = this->CreateGraphics();
      listBox1->Items->Add( String::Format( "ListBox horizontal resolution: {0}", boxGraphics->DpiX ) );
      listBox1->Items->Add( String::Format( "ListBox vertical resolution: {0}", boxGraphics->DpiY ) );
      delete boxGraphics;
   }
   //</snippet4>

   // The following code example shows how to set a keyboard shortcut
   // when drawing a string with the Graphics object. It also 
   // demonstrates how to use the SystemBrush.FromSystemColor method. To  
   // run this example, paste the code into a form, handle the form's 
   // Paint event, and call the following method, passing e as 
   // PaintEventArgs.

   //<snippet2>
private:
   void ShowHotKey( PaintEventArgs^ e )
   {
      // Declare the string with a keyboard shortcut.
      String^ text = "&Click Here";

      // Declare a new StringFormat.
      StringFormat^ format = gcnew StringFormat;

      // Set the HotkeyPrefix property.
      format->HotkeyPrefix = System::Drawing::Text::HotkeyPrefix::Show;

      // Draw the string.
      Brush^ theBrush = SystemBrushes::FromSystemColor( SystemColors::Highlight );
      e->Graphics->DrawString( text, this->Font, theBrush, 30, 40, format );
   }
   //</snippet2>

   // The following code example adds a shadow to a ListBox using the
   // following members:
   //   Size.opImplicit
   //   SizeF.opAddition
   //   Point.opImplicit
   //   PointF.opAddition
   //   SolidBrush 
   // This example is designed to be used with a Windows Form. 
   // To run this example, paste this code into a form and call the
   // AddShadow method when handling the form's Paint event. Make
   // sure the form contains a ListBox named listBox1.

   //<snippet3>
private:
   void AddShadow( PaintEventArgs^ e )
   {
      // Create two SizeF objects.
      SizeF shadowSize = listBox1->Size;
      SizeF addSize = SizeF(10.5F,20.8F);

      // Add them together and save the result in shadowSize.
      shadowSize = shadowSize + addSize;

      // Get the location of the ListBox and convert it to a PointF.
      PointF shadowLocation = listBox1->Location;

      // Add two points to get a new location.
      shadowLocation = shadowLocation + System::Drawing::Size( 5, 5 );

      // Create a rectangleF. 
      RectangleF rectFToFill = RectangleF(shadowLocation,shadowSize);

      // Create a custom brush using a semi-transparent color, and 
      // then fill in the rectangle.
      Color customColor = Color::FromArgb( 50, Color::Gray );
      SolidBrush^ shadowBrush = gcnew SolidBrush( customColor );
      array<RectangleF>^ temp0 = {rectFToFill};
      e->Graphics->FillRectangles( shadowBrush, temp0 );

      // Dispose of the brush.
      delete shadowBrush;
   }
   //</snippet3>

public:

   // The following code example demonstrates using a Matrix
   // and the GraphicsPath.Transform method to rotate a string.
   // This example is designed to be used with Windows Forms.
   // Create a form and paste the following code into it. Call the
   // DrawVerticalStringFromBottomUp method in the form's Paint 
   // event-handling method, passing e as PaintEventArgs.

   //<snippet5>
private:
   void DrawVerticalStringFromBottomUp( PaintEventArgs^ e )
   {
      // Create the string to draw on the form.
      String^ text = "Can you read this?";

      // Create a GraphicsPath.
      System::Drawing::Drawing2D::GraphicsPath^ path = gcnew System::Drawing::Drawing2D::GraphicsPath;

      // Add the string to the path; declare the font, font style, size, and
      // vertical format for the string.
      path->AddString( text, this->Font->FontFamily, 1, 15, PointF(0.0F,0.0F), gcnew StringFormat( StringFormatFlags::DirectionVertical ) );

      // Declare a matrix that will be used to rotate the text.
      System::Drawing::Drawing2D::Matrix^ rotateMatrix = gcnew System::Drawing::Drawing2D::Matrix;

      // Set the rotation angle and starting point for the text.
      rotateMatrix->RotateAt( 180.0F, PointF(10.0F,100.0F) );

      // Transform the text with the matrix.
      path->Transform(rotateMatrix);

      // Set the SmoothingMode to high quality for best readability.
      e->Graphics->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::HighQuality;

      // Fill in the path to draw the string.
      e->Graphics->FillPath( Brushes::Red, path );

      // Dispose of the path.
      delete path;
   }
   //</snippet5>

   // The following code example demonstrates how to use the KnownColor enum
   // to print out the name and colors of all its values. This example is 
   // designed to be used with Windows Forms. Create a form and paste
   // the following code into it.  Call the DisplayKnownColors method in the
   // form's Paint event-handling method, passing e as PaintEventArgs.

   //<snippet6>
private:
   void DisplayKnownColors( PaintEventArgs^ e )
   {
      this->Size = System::Drawing::Size( 650, 550 );

      // Get all the values from the KnownColor enumeration.
      System::Array^ colorsArray = Enum::GetValues( KnownColor::typeid );
      array<KnownColor>^allColors = gcnew array<KnownColor>(colorsArray->Length);
      Array::Copy( colorsArray, allColors, colorsArray->Length );

      // Loop through printing out the values' names in the colors 
      // they represent.
      float y = 0;
      float x = 10.0F;
      for ( int i = 0; i < allColors->Length; i++ )
      {
         // If x is a multiple of 30, start a new column.
         if ( i > 0 && i % 30 == 0 )
         {
            x += 105.0F;
            y = 15.0F;
         }
         else
         {
            // Otherwise, increment y by 15.
            y += 15.0F;
         }

         // Create a custom brush from the color and use it to draw
         // the brush's name.
         SolidBrush^ aBrush = gcnew SolidBrush( Color::FromName( allColors[ i ].ToString() ) );
         e->Graphics->DrawString( allColors[ i ].ToString(), this->Font, aBrush, x, y );

         // Dispose of the custom brush.
         delete aBrush;
      }
   }
   //</snippet6>

   // The following code example demonstrates how to use the MakeEmpty
   // method. This example is designed to be used with Windows Forms.
   // Create a form and paste the following code into it. Call the 
   // FillEmptyRegion method in the form's Paint event-handling method,
   // passing e as PaintEventArgs.

   //<snippet7>
private:
   void FillEmptyRegion( PaintEventArgs^ e )
   {
      // Create a region from a rectangle.
      Rectangle originalRectangle = Rectangle(40,40,40,50);
      System::Drawing::Region^ smallRegion = gcnew System::Drawing::Region( originalRectangle );

      // Call MakeEmpty.
      smallRegion->MakeEmpty();

      // Fill the region in red and draw the original rectangle
      // in black. Note there is nothing filled in.
      e->Graphics->FillRegion( Brushes::Red, smallRegion );
      e->Graphics->DrawRectangle( Pens::Black, originalRectangle );
   }
   //</snippet7>

   // The following code example demonstrates how to use the MakeInfinite
   // method. This example is designed to be used with Windows Forms. 
   // Create a form and paste the following code into it. Call the
   // FillInfiniteRegion method in the form's Paint event-handling method, 
   // passing e as PaintEventArgs.

   //<snippet8>
private:
   void FillInfiniteRegion( PaintEventArgs^ e )
   {
      // Create a region from a rectangle.
      Rectangle originalRectangle = Rectangle(40,40,40,50);
      System::Drawing::Region^ smallRegion = gcnew System::Drawing::Region( originalRectangle );

      // Call MakeInfinite.
      smallRegion->MakeInfinite();

      // Fill the region in red and draw the original rectangle
      // in black. Note that the entire form is filled in.
      e->Graphics->FillRegion( Brushes::Red, smallRegion );
      e->Graphics->DrawRectangle( Pens::Black, originalRectangle );
   }
   //</snippet8>

   // The following code example demonstrates how to use the ToBitmap
   // method. This example is designed to be used with Windows Forms. 
   // Create a form and paste the following code into it. Call the 
   // IconToBitmap method in the form's Paint event-handling method, 
   // passing e as PaintEventArgs.

   //<snippet9>
private:
   void IconToBitmap( PaintEventArgs^ e )
   {
      // Construct an Icon.
      System::Drawing::Icon^ icon1 = gcnew System::Drawing::Icon( SystemIcons::Exclamation,40,40 );

      // Call ToBitmap to convert it.
      Bitmap^ bmp = icon1->ToBitmap();

      // Draw the bitmap.
      e->Graphics->DrawImage( bmp, Point(30,30) );
   }
   //</snippet9>

   // The following code example demonstrates how to use the 
   // TranslateTransform method. This example is designed to be used 
   // with Windows Forms.  Create a form and paste the following code 
   // into it. Call the TranslateAndTransform method in the form's 
   // Paint event-handling method, passing e as PaintEventArgs.

   //<snippet10>
private:
   void TranslateAndTransform( PaintEventArgs^ e )
   {
      // Create a GraphicsPath.
      System::Drawing::Drawing2D::GraphicsPath^ myPath = gcnew System::Drawing::Drawing2D::GraphicsPath;

      // Create a rectangle.
      RectangleF layoutRectangle = RectangleF(20.0F,20.0F,40.0F,50.0F);

      // Add the rectangle to the path.
      myPath->AddRectangle( layoutRectangle );

      // Add a string to the path.
      myPath->AddString( "Path", this->Font->FontFamily, 2, 10.0F, layoutRectangle, gcnew StringFormat( StringFormatFlags::NoWrap ) );

      // Draw the path.
      e->Graphics->DrawPath( Pens::Black, myPath );

      // Call TranslateTransform and draw the path again.
      e->Graphics->TranslateTransform( 10.0F, 10.0F );
      e->Graphics->DrawPath( Pens::Red, myPath );
   }
   //</snippet10>

   void Form1_Paint( Object^ /*sender*/, PaintEventArgs^ e )
   {
      //FillEmptyRegion(e)
      //SetAndFillClip(e)
      //FillInfiniteRegion(e)
      //ShowHotKey(e)
      //AddShadow(e)
      //IconToBitmap(e)
      //DisplayKnownColors(e)
      //DrawVerticalStringFromBottomUp(e)
      TranslateAndTransform( e );
   }

   // The following code example demonstrates how to set the Font property of 
   // a button to a new, bold-style Font. This example is designed to be
   // used with Windows Forms. Create a form containing a button named 
   // Button1 and paste the following code into it. Associate the 
   // Button1_Click method with the button's Click event.

   //<snippet11>
private:
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Button1->Font = gcnew System::Drawing::Font( FontFamily::GenericSansSerif,12.0F,FontStyle::Bold );
   }
   //</snippet11>

   // The following code example demonstrates how to construct a Region
   // using the RegionData class. This example is designed to be used with Windows
   // Forms. To run this example paste it into a form and handle the form's Paint event
   // by calling the DemonstrateRegionData method, passing e as PaintEventArgs.

   // <snippet12>
private:
   void DemonstrateRegionData( PaintEventArgs^ e )
   {
      //Create a simple region.
      System::Drawing::Region^ region1 = gcnew System::Drawing::Region( Rectangle(10,10,100,100) );

      // Extract the region data.
      System::Drawing::Drawing2D::RegionData^ region1Data = region1->GetRegionData();

      // Create a new region using the region data.
      System::Drawing::Region^ region2 = gcnew System::Drawing::Region( region1Data );

      // Dispose of the first region.
      delete region1;

      // Call ExcludeClip passing in the second region.
      e->Graphics->ExcludeClip( region2 );

      // Fill in the client rectangle.
      e->Graphics->FillRectangle( Brushes::Red, this->ClientRectangle );
      delete region2;
   }
   // </snippet12>

   // The following code example demonstrates how use the Data from
   // one region to set the Data for another region. This example is designed 
   // to be used with Windows Forms. To run this example paste
   // it into a form and handle the form's Paint event
   // by calling the DemonstrateRegionData2 method, passing e as PaintEventArgs.

   // <snippet13>
private:
   void DemonstrateRegionData2( PaintEventArgs^ e )
   {
      //Create a simple region.
      System::Drawing::Region^ region1 = gcnew System::Drawing::Region( Rectangle(10,10,100,100) );

      // Extract the region data.
      System::Drawing::Drawing2D::RegionData^ region1Data = region1->GetRegionData();
      array<Byte>^data1;
      data1 = region1Data->Data;

      // Create a second region.
      System::Drawing::Region^ region2 = gcnew System::Drawing::Region;

      // Get the region data for the second region.
      System::Drawing::Drawing2D::RegionData^ region2Data = region2->GetRegionData();

      // Set the Data property for the second region to the Data from the first region.
      region2Data->Data = data1;

      // Construct a third region using the modified RegionData of the second region.
      System::Drawing::Region^ region3 = gcnew System::Drawing::Region( region2Data );

      // Dispose of the first and second regions.
      delete region1;
      delete region2;

      // Call ExcludeClip passing in the third region.
      e->Graphics->ExcludeClip( region3 );

      // Fill in the client rectangle.
      e->Graphics->FillRectangle( Brushes::Red, this->ClientRectangle );
      delete region3;
   }
   // </snippet13>
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
