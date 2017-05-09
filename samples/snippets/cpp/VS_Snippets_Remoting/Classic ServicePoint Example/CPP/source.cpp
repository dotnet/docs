#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   void Method()
   {
      // <Snippet1>
      Uri^ myUri = gcnew Uri( "http://www.contoso.com/" );
      ServicePoint^ mySP = ServicePointManager::FindServicePoint( myUri );
      // </Snippet1>
   }
};
