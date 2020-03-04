#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   PictureBox^ pictureBox1;
   ScrollBar^ hScrollBar1;
   ScrollBar^ vScrollBar1;

   // <Snippet1>
public:
   void DisplayScrollBars()
   {
      // Display or hide the scroll bars based upon  
      // whether the image is larger than the PictureBox.
      if ( pictureBox1->Width > pictureBox1->Image->Width )
      {
         hScrollBar1->Visible = false;
      }
      else
      {
         hScrollBar1->Visible = true;
      }

      if ( pictureBox1->Height > pictureBox1->Image->Height )
      {
         vScrollBar1->Visible = false;
      }
      else
      {
         vScrollBar1->Visible = true;
      }
   }
   // </Snippet1>
};
