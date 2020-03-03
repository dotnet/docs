

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
   void PrintBoundControls1()
   {
      
      // Get the BindingManagerBase for the Customers table.
      BindingManagerBase^ myBindingBase = this->BindingContext[ ds,"Customers" ];
      
      /* Print the information of each control managed by
            the BindingManagerBase. */
      System::Collections::IEnumerator^ myEnum = myBindingBase->Bindings->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Binding^ b = safe_cast<Binding^>(myEnum->Current);
         Console::WriteLine( b->Control );
      }
   }

   void PrintBoundControls2()
   {
      
      /* Get the BindingManagerBase for a child table of
            the Customers table. The RelationName of a DataRelation
            is appended to the parent table's name. */
      BindingManagerBase^ myBindingBase = this->BindingContext[ ds,"Customers::CustToOrders" ];
      
      /* Print the information of each control managed by
            the BindingManagerBase. */
      System::Collections::IEnumerator^ myEnum = myBindingBase->Bindings->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Binding^ b = safe_cast<Binding^>(myEnum->Current);
         Console::WriteLine( b->Control );
      }
   }

   // </Snippet1>
};
