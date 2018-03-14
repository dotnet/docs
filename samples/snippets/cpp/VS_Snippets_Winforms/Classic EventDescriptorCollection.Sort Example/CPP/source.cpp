#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Coll1 abstract: public EventDescriptorCollection
{
protected:
   Object^ myNewColl;

public:
   Coll1() : EventDescriptorCollection( nullptr )
   {
   }

protected:
   void Method()
   {
      // <Snippet1>
      array<String^>^ temp0 = {"D","B"};
      myNewColl = this->Sort( temp0 );
      // </Snippet1>
   }
};
