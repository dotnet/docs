

#using <system.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::ComponentModel;
ref class C
{
public:
   System::Drawing::Image^ m_Image1;

   property System::Drawing::Image^ MyImage 
   {

      // <Snippet1>
      [Description("The image associated with the control"),Category("Appearance")]
      System::Drawing::Image^ get()
      {
         // Insert code here.
         return m_Image1;
      }

      void set( System::Drawing::Image^ )
      {
         // Insert code here.
      }
   }
   // </Snippet1>

   void MyMethod()
   {
      // <Snippet2>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyImage" ]->Attributes;

      // Prints the description by retrieving the CategoryAttribute.
      // from the AttributeCollection.
      CategoryAttribute^ myAttribute = static_cast<CategoryAttribute^>(attributes[ CategoryAttribute::typeid ]);
      Console::WriteLine( myAttribute->Category );
      // </Snippet2>
   }
};
