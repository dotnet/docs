

#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ text1;
   Panel^ panel1;

private:

   // <Snippet1>
   void SetAutoScrollMargins()
   {
      /* If the text box is outside the panel's bounds, 
             turn on auto-scrolling and set the margin. */
      if ( text1->Location.X > panel1->Location.X || text1->Location.Y > panel1->Location.Y )
      {
         panel1->AutoScroll = true;

         /* If the AutoScrollMargin is set to less 
                   than (5,5), set it to 5,5. */
         if ( panel1->AutoScrollMargin.Width < 5 || panel1->AutoScrollMargin.Height < 5 )
         {
            panel1->SetAutoScrollMargin( 5, 5 );
         }
      }
   }
   // </Snippet1>
};
