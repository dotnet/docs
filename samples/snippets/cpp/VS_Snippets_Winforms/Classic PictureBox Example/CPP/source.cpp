

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   PictureBox^ pictureBox1;

private:

   // <Snippet1>
   Bitmap^ MyImage;

public:
   void ShowMyImage( String^ fileToDisplay, int xSize, int ySize )
   {
      
      // Sets up an image object to be displayed.
      if ( MyImage != nullptr )
      {
         delete MyImage;
      }

      
      // Stretches the image to fit the pictureBox.
      pictureBox1->SizeMode = PictureBoxSizeMode::StretchImage;
      MyImage = gcnew Bitmap( fileToDisplay );
      pictureBox1->ClientSize = System::Drawing::Size( xSize, ySize );
      pictureBox1->Image = dynamic_cast<Image^>(MyImage);
   }

   // </Snippet1>
};

/*
This code produces the following output:

Reflection.Parameterinfo

Mymethodbase = Void mymethod(Int32, System.String ByRef, System.String ByRef)
For parameter # 0, the ParameterType is - System.Int32
For parameter # 1, the ParameterType is - System.String&
For parameter # 2, the ParameterType is - System.String&
*/
