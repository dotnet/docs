
using namespace System;
int main()
{
   
   // <Snippet1>
   Boolean raining = false;
   Boolean busLate = true;
   Console::WriteLine(  "raining->ToString() returns {0}", raining.ToString() );
   Console::WriteLine(  "busLate->ToString() returns {0}", busLate.ToString() );
   // The example displays the following output:
   //       raining.ToString() returns False
   //       busLate.ToString() returns True
   // </Snippet1>

   // <Snippet2>
   Boolean val;
   String^ input;
   input = Boolean::TrueString;
   val = Boolean::Parse( input );
   Console::WriteLine(  "'{0}' parsed as {1}", input, val );
   // The example displays the following output:
   //       'True' parsed as True        
   // </Snippet2>
}

