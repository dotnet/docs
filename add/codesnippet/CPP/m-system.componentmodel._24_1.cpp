   // Push ten items on to the stack and output the value of each.
   for ( int number = 0; number < 10; number++ )
   {
      Console::WriteLine( "Value pushed to stack: {0}", number );
      stack->Push( number );
   }