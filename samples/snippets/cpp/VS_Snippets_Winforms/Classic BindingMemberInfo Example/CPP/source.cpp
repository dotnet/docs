#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void PrintBindingMemberInfo()
   {
      for each ( Control^ c in this->Controls )
      {
         for each ( Binding^ b in c->DataBindings )
         {
            Console::WriteLine( "\n {0}", c );
            BindingMemberInfo bInfo = b->BindingMemberInfo;
            Console::WriteLine( "Binding Path \t {0}", bInfo.BindingPath );
            Console::WriteLine( "Binding Field \t {0}", bInfo.BindingField );
            Console::WriteLine( "Binding Member \t {0}", bInfo.BindingMember );
         }
      }
   }
   // </Snippet1>
};
