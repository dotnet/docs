#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void MoveNext( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Count == 0 )
      {
         Console::WriteLine( "No records to move to." );
         return;
      }

      if ( myCurrencyManager->Position == myCurrencyManager->Count - 1 )
      {
         Console::WriteLine( "You're at end of the records" );
      }
      else
      {
         myCurrencyManager->Position += 1;
      }
   }

   void MoveFirst( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Count == 0 )
      {
         Console::WriteLine( "No records to move to." );
         return;
      }

      myCurrencyManager->Position = 0;
   }

   void MovePrevious( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Count == 0 )
      {
         Console::WriteLine( "No records to move to." );
         return;
      }

      if ( myCurrencyManager->Position == 0 )
      {
         Console::WriteLine( "You're at the beginning of the records." );
      }
      else
      {
         myCurrencyManager->Position -= 1;
      }
   }

   void MoveLast( CurrencyManager^ myCurrencyManager )
   {
      if ( myCurrencyManager->Count == 0 )
      {
         Console::WriteLine( "No records to move to." );
         return;
      }
      myCurrencyManager->Position = myCurrencyManager->Count - 1;
   }
   // </Snippet1>
};
