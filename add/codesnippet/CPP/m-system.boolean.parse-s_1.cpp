   Boolean val;
   String^ input;
   input = Boolean::TrueString;
   val = Boolean::Parse( input );
   Console::WriteLine(  "'{0}' parsed as {1}", input, val );
   // The example displays the following output:
   //       'True' parsed as True        