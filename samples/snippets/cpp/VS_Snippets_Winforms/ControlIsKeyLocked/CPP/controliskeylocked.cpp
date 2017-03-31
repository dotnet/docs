

// <Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
int main()
{
   if (Control::IsKeyLocked( Keys::CapsLock )) {
      MessageBox::Show( "The Caps Lock key is ON." );
   }
   else { 
      MessageBox::Show( "The Caps Lock key is OFF." );
   }

}

// </Snippet1>
