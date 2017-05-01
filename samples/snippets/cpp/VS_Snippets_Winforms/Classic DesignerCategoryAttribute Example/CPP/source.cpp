

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;

// <Snippet1>
[Designer("System.Windows.Forms.Design.DocumentDesigner, System.Windows.Forms.Design",
IRootDesigner::typeid),
DesignerCategory("Form")]
ref class MyForm: public ContainerControl{
   // Insert code here.
};
// </Snippet1>

// <Snippet2>
int main()
{
   // Creates a new form.
   MyForm^ myNewForm = gcnew MyForm;

   // Gets the attributes for the collection.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewForm );

   /* Prints the name of the designer by retrieving the 
       * DesignerCategoryAttribute from the AttributeCollection. */
   DesignerCategoryAttribute^ myAttribute = dynamic_cast<DesignerCategoryAttribute^>(attributes[ DesignerCategoryAttribute::typeid ]);
   Console::WriteLine( "The category of the designer for this class is: {0}", myAttribute->Category );
   return 0;
}
// </Snippet2>
