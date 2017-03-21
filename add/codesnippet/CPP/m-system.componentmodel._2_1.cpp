   // Pop each item off the stack.
   Object^ item = nullptr;
   while ( (item = stack->Pop()) != 0 )
      Console::WriteLine( "Value popped from stack: {0}", item );