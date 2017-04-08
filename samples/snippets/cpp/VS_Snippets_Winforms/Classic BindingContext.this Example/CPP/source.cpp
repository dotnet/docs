

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Collections;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   DataView^ myDataView;
   ArrayList^ myArrayList;

private:

   // <Snippet1>
   void ReturnBindingManagerBase()
   {
      
      // Get the BindingManagerBase for a DataView. 
      BindingManagerBase^ bmCustomers = this->BindingContext[ myDataView ];
      
      /* Get the BindingManagerBase for an ArrayList. */
      BindingManagerBase^ bmOrders = this->BindingContext[ myArrayList ];
      
      // Get the BindingManagerBase for a TextBox control.
      BindingManagerBase^ baseArray = this->BindingContext[ textBox1->DataBindings[ nullptr ]->DataSource ];
   }

   // </Snippet1>
};
