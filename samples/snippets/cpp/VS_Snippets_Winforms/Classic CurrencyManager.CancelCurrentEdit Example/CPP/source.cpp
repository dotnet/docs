

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   DataGrid^ dataGrid1;

   // <Snippet1>
private:
   void dataGrid1_KeyUp( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      if ( e->KeyCode == System::Windows::Forms::Keys::Escape )
      {
         
         // Escape key pressed.
         CurrencyManager^ gridCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[dataGrid1->DataSource, dataGrid1->DataMember]);
         gridCurrencyManager->CancelCurrentEdit();
         MessageBox::Show( "Escape!" );
      }
   }

   // </Snippet1>
};
