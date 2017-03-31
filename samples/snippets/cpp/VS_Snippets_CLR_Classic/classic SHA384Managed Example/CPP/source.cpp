#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Security::Cryptography;

public ref class Sample
{
protected:
   void Method()
   {
      int DATA_SIZE = 1024;
      
      // <Snippet1>
      array<Byte>^ data = gcnew array<Byte>( DATA_SIZE );
      array<Byte>^ result;

      SHA384^ shaM = gcnew SHA384Managed;
      result = shaM->ComputeHash( data );
      // </Snippet1>
   }
};
