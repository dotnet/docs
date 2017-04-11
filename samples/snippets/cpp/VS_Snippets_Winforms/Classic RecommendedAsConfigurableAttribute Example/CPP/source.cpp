

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
public:
   [RecommendedAsConfigurable(true)]
   property int MyProperty 
   {
      int get()
      {
         // Insert code here.
         return 0;
      }
      void set( int /*value*/ )
      {
         // Insert code here.
      }
   }
   // </Snippet1>
   void Method1()
   {
      // <Snippet2>
      // Gets the attributes for the property.
      AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "MyProperty" ]->Attributes;

      // Checks to see if the value of the RecommendedAsConfigurableAttribute is Yes.
      if ( attributes[ RecommendedAsConfigurableAttribute::typeid ]->Equals( RecommendedAsConfigurableAttribute::Yes ) )
      {
         // Insert code here.
      }

      // This is another way to see if the property is recommended as configurable.
      RecommendedAsConfigurableAttribute^ myAttribute = dynamic_cast<RecommendedAsConfigurableAttribute^>(attributes[ RecommendedAsConfigurableAttribute::typeid ]);
      if ( myAttribute->RecommendedAsConfigurable )
      {
         // Insert code here.
      }
      // </Snippet2>
   }

   void Method2()
   {
      // <Snippet3>
      AttributeCollection^ attributes = TypeDescriptor::GetAttributes( MyProperty );
      if ( attributes[ RecommendedAsConfigurableAttribute::typeid ]->Equals( RecommendedAsConfigurableAttribute::Yes ) )
      {
         // Insert code here.
      }
      // </Snippet3>
   }
};

/*
This code produces the following output.

myQ is not synchronized.
mySyncdQ is synchronized.
*/
