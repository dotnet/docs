

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

// <Snippet1>
[Editor("System.Windows.Forms.ImageEditorIndex, System.Design",
UITypeEditor::typeid)]
public ref class MyImage{
   // Insert code here.
};
// </Snippet1>

// <Snippet2>
int main()
{
   // Creates a new component.
   MyImage^ myNewImage = gcnew MyImage;

   // Gets the attributes for the component.
   AttributeCollection^ attributes = TypeDescriptor::GetAttributes( myNewImage );

   /* Prints the name of the editor by retrieving the EditorAttribute 
       * from the AttributeCollection. */
   EditorAttribute^ myAttribute = dynamic_cast<EditorAttribute^>(attributes[ EditorAttribute::typeid ]);
   Console::WriteLine( "The editor for this class is: {0}", myAttribute->EditorTypeName );
   return 0;
}
// </Snippet2>
