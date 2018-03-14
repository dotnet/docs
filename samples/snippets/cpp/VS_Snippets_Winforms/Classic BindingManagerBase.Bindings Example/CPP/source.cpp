

#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   TextBox^ text1;
   DataSet^ ds;

private:

   // <Snippet1>
   void PrintBoundControls()
   {
      BindingManagerBase^ myBindingBase = this->BindingContext[ ds,"customers" ];
      System::Collections::IEnumerator^ myEnum = myBindingBase->Bindings->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Binding^ b = safe_cast<Binding^>(myEnum->Current);
         Console::WriteLine( b->Control );
      }
   }

   // </Snippet1>
};
