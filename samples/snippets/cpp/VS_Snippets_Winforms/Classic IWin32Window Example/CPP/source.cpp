#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   Label^ label1;

   // <Snippet1>
public:
   Form1()
   {
      InitializeComponent();
      this->label1->Text = this->Handle.ToString();
   }
   // </Snippet1>

protected:
   void InitializeComponent(){}
};
