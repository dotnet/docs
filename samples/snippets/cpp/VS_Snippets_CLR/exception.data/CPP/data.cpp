// <Snippet1>
using namespace System;
using namespace System::Collections;

void NestedRunTest( bool displayDetails ); // forward declarations
void NestedRoutine1( bool displayDetails );
void NestedRoutine2( bool displayDetails );
void RunTest( bool displayDetails );

int main()
{
   Console::WriteLine("\nException with some extra information..." );
   RunTest(false);
   Console::WriteLine("\nException with all extra information..." );
   RunTest(true);
}

void RunTest( bool displayDetails )
{
   try
   {
      NestedRoutine1( displayDetails );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "An exception was thrown." );
      Console::WriteLine( e->Message );
      if ( e->Data != nullptr )
      {
         Console::WriteLine( "  Extra details:" );

         for each (DictionaryEntry de in e->Data)
            Console::WriteLine("    Key: {0,-20}      Value: {1}", 
                               "'" + de.Key->ToString() + "'", de.Value);
      }
   }
}

void NestedRoutine1( bool displayDetails )
{
   try
   {
      NestedRoutine2( displayDetails );
   }
   catch ( Exception^ e ) 
   {
      e->Data[ "ExtraInfo" ] = "Information from NestedRoutine1.";
      e->Data->Add( "MoreExtraInfo", "More information from NestedRoutine1." );
      throw;
   }
}

void NestedRoutine2( bool displayDetails )
{
   Exception^ e = gcnew Exception( "This statement is the original exception message." );
   if ( displayDetails )
   {
      String^ s = "Information from NestedRoutine2.";
      int i = -903;
      DateTime dt = DateTime::Now;
      e->Data->Add( "stringInfo", s );
      e->Data[ "IntInfo" ] = i;
      e->Data[ "DateTimeInfo" ] = dt;
   }

   throw e;
}

/*
This example produces the following results:

Exception with some extra information...
An exception was thrown.
This statement is the original exception message.
  Extra details:
    The key is 'ExtraInfo' and the value is: Information from NestedRoutine1.
    The key is 'MoreExtraInfo' and the value is: More information from NestedRoutine1.

Exception with all extra information...
An exception was thrown.
This statement is the original exception message.
  Extra details:
    The key is 'stringInfo' and the value is: Information from NestedRoutine2.
    The key is 'IntInfo' and the value is: -903
    The key is 'DateTimeInfo' and the value is: 11/26/2002 2:12:58 PM
    The key is 'ExtraInfo' and the value is: Information from NestedRoutine1.
    The key is 'MoreExtraInfo' and the value is: More information from NestedRoutine1.
*/
//</snippet1>
