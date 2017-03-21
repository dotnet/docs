      StringDictionary myStringDictionary = Context.Parameters;
      if ( Context.Parameters.Count > 0 )
      {
         Console.WriteLine("Context Property : " );
         foreach( string myString in Context.Parameters.Keys)
         {
            Console.WriteLine( Context.Parameters[ myString ] );
         }
      }