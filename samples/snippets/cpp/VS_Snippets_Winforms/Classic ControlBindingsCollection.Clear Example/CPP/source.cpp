#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   GroupBox^ groupBox1;

   // <Snippet1>
private:
   void ClearAllBindings()
   {
      for each ( Control^ c in groupBox1->Controls )
      {
         c->DataBindings->Clear();
      }
   }
   // </Snippet1>
};
