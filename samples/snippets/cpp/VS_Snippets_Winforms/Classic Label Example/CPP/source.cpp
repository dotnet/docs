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
   ImageList^ imageList1;

   // <Snippet1>
public:
   void CreateMyLabel()
   {
      // Create an instance of a Label.
      Label^ label1 = gcnew Label;
      
      // Set the border to a three-dimensional border.
      label1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      // Set the ImageList to use for displaying an image.
      label1->ImageList = imageList1;
      // Use the second image in imageList1.
      label1->ImageIndex = 1;
      // Align the image to the top left corner.
      label1->ImageAlign = ContentAlignment::TopLeft;
      
      // Specify that the text can display mnemonic characters.
      label1->UseMnemonic = true;
      // Set the text of the control and specify a mnemonic character.
      label1->Text = "First &Name:";
      
      /* Set the size of the control based on the PreferredHeight and PreferredWidth values. */
      label1->Size = System::Drawing::Size( label1->PreferredWidth, label1->PreferredHeight );
      
      //...Code to add the control to the form...
   }
   // </Snippet1>
};
