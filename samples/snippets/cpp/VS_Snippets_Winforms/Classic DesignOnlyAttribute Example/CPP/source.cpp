

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Globalization;
public ref class Class1
{
protected:
   CultureInfo^ myCultureInfo;

   // <Snippet1>
public:
   [DesignOnly(true)]
   property CultureInfo^ GetLanguage 
   {
      CultureInfo^ get()
      {
         // Insert code here.
         return myCultureInfo;
      }
      void set( CultureInfo^ value )
      {
         // Insert code here.
      }
   }
   // </Snippet1>

private:
   property int Property1 
   {
      int get()
      {
         // <Snippet2>
         // Gets the attributes for the property.
         AttributeCollection^ attributes = TypeDescriptor::GetProperties( this )[ "GetLanguage" ]->Attributes;

         /* Prints whether the property is marked as DesignOnly 
		 by retrieving the DesignOnlyAttribute from the AttributeCollection. */
         DesignOnlyAttribute^ myAttribute = dynamic_cast<DesignOnlyAttribute^>(attributes[ DesignOnlyAttribute::typeid ]);
         Console::WriteLine( "This property is design only :{0}", myAttribute->IsDesignOnly );
         // </Snippet2>

         return 1;
      }
   }
};
