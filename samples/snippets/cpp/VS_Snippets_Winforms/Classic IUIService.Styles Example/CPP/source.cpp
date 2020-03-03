

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.Dll>

using namespace System;
using namespace System::ComponentModel::Design;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
public ref class Form1: public Form
{
private:

   // <Snippet1>
   // The specified IDesigner implements IUIService.
   System::Drawing::Font^ GetFont( IDesigner^ designer )
   {
      System::Drawing::Font^ hostfont;
      
      // Gets the dialog box font from the host environment.
      hostfont = dynamic_cast<System::Drawing::Font^>(dynamic_cast<IUIService^>(designer)->Styles[ "DialogFont" ]);
      return hostfont;
   }
   // </Snippet1>
};
