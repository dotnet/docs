#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

//<Snippet1>
ActiveDesignerEventArgs^ CreateActiveDesignerEventArgs( IDesignerHost^ losingFocus, IDesignerHost^ gainingFocus )
{
   ActiveDesignerEventArgs^ e = gcnew ActiveDesignerEventArgs( losingFocus, gainingFocus );
   return e;
}
//</Snippet1>

void main(){}
