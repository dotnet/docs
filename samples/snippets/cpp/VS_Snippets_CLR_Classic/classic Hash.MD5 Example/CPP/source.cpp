#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Security::Policy;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   Assembly^ myAssembly;

   void Method()
   {
      // <Snippet1>
      Hash^ hash = gcnew Hash( myAssembly );
      array<Byte>^ hashcode = hash->MD5;
      // </Snippet1>
   }
};
