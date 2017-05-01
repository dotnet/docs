

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Data;
public ref class Test
{
private:
   TextBox^ textBox1;
   Test()
   {
      textBox1 = gcnew TextBox;
   }

   //<Snippet1>
   void PrintValue()
   {
      ControlBindingsCollection^ myControlBindings;
      myControlBindings = textBox1->DataBindings;
      
      // Get the Binding for the Text property.
      Binding^ myBinding = myControlBindings[ "Text" ];
      
      // Assuming the data source is a DataTable.
      DataRowView^ drv;
      drv = dynamic_cast<DataRowView^>(myBinding->BindingManagerBase->Current);
      
      // Assuming a column named S"custName" exists, print the value.
      Console::WriteLine( drv[ "custName" ] );
   }
   //</Snippet1>
};

int main(){}
