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
   ImageList^ imageList1;

   // <Snippet1>
private:
   void AddMyImage()
   {
      // Assign an image to the imageList.
      imageList1->Images->Add( Image::FromFile( "C:\\Graphics\\MyBitmap.bmp" ) );
      // Assign the imageList to the button control.
      button1->ImageList = imageList1;
      // Select the image from the ImageList (using the ImageIndex property).
      button1->ImageIndex = 0;
   }
   // </Snippet1>
};
