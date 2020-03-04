

#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Runtime::InteropServices;

/*
*/
// <Snippet2>
interface class Baz
{
   void SetColor( [ComAliasName("stdole.OLE_COLOR")]int cl );

   [returnvalue:ComAliasName("stdole.OLE_COLOR")]
   int GetColor();
};

// </Snippet2>
