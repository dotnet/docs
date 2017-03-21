      Int64 myVariable1 = 80;
      Int64 myVariable2 = 80;
      
      // Get and display the declaring type.
      Console::WriteLine( "\nType of 'myVariable1' is ' {0}' and  value is : {1}", myVariable1.GetType(), myVariable1 );
      Console::WriteLine( "Type of 'myVariable2' is ' {0}' and  value is : {1}", myVariable2.GetType(), myVariable2 );
      
      // Compare 'myVariable1' instance with 'myVariable2' Object.
      if ( myVariable1.Equals( myVariable2 ) )
            Console::WriteLine( "\nStructures 'myVariable1' and 'myVariable2' are equal" );
      else
            Console::WriteLine( "\nStructures 'myVariable1' and 'myVariable2' are not equal" );
      