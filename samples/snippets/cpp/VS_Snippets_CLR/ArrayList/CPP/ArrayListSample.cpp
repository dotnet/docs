
//<snippet7>
using namespace System;
using namespace System::Text;
using namespace System::Collections;

//<snippet6> 
ref class ReverseStringComparer: public IComparer
{
public:
   virtual int Compare( Object^ x, Object^ y )
   {
      String^ s1 = dynamic_cast<String^>(x);
      String^ s2 = dynamic_cast<String^>(y);

      //negate the return value to get the reverse order
      return  -String::Compare( s1, s2 );
   }

};
//</snippet6>

//<snippet2> 
void PrintValues( String^ title, IEnumerable^ myList )
{
   Console::Write( "{0,10}: ", title );
   StringBuilder^ sb = gcnew StringBuilder;
   {
      IEnumerator^ en = myList->GetEnumerator();
      String^ s;
      while ( en->MoveNext() )
      {
         s = en->Current->ToString();
         sb->AppendFormat(  "{0}, ", s );
      }
   }
   sb->Remove( sb->Length - 2, 2 );
   Console::WriteLine( sb );
}
//</snippet2>

void main()
{
   //<snippet1> 
   // Creates and initializes a new ArrayList.
   ArrayList^ myAL = gcnew ArrayList;
   myAL->Add( "Eric" );
   myAL->Add( "Mark" );
   myAL->Add( "Lance" );
   myAL->Add( "Rob" );
   myAL->Add( "Kris" );
   myAL->Add( "Brad" );
   myAL->Add( "Kit" );
   myAL->Add( "Bradley" );
   myAL->Add( "Keith" );
   myAL->Add( "Susan" );

   // Displays the properties and values of the ArrayList.
   Console::WriteLine( "Count: {0}", myAL->Count.ToString() );
   //</snippet1>

   PrintValues( "Unsorted", myAL );

   //<snippet3> 
   myAL->Sort();
   PrintValues( "Sorted", myAL );
   //</snippet3>

   //<snippet4>
   myAL->Sort( gcnew ReverseStringComparer );
   PrintValues( "Reverse", myAL );
   //</snippet4>

   //<snippet5> 
   array<String^>^names = dynamic_cast<array<String^>^>(myAL->ToArray( String::typeid ));
   //</snippet5>
}
//</snippet7>
