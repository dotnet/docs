

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   TextBox^ text1;

private:

   // <Snippet1>
   void PrintBindingInfo()
   {
      BindingsCollection^ bc = text1->DataBindings;
      for ( int i = 0; i < bc->Count; i++ )
         Console::WriteLine( bc[ i ]->BindingMemberInfo.BindingMember );
   }

   // </Snippet1>
};
