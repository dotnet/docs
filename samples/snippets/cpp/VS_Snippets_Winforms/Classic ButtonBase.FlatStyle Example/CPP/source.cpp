#using <system.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
private:
   Button^ button1;

   // <Snippet1>
private:
   void SetMyButtonProperties()
   {
      // Assign an image to the button.
      button1->Image = Image::FromFile( "C:\\Graphics\\MyBitmap.bmp" );
      // Align the image and text on the button.
      button1->ImageAlign = ContentAlignment::MiddleRight;
      button1->TextAlign = ContentAlignment::MiddleLeft;
      // Give the button a flat appearance.
      button1->FlatStyle = FlatStyle::Flat;
   }
   // </Snippet1>
};
