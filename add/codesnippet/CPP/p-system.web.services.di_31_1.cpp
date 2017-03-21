         array<Object^>^myArray = gcnew array<Object^>(myExceptionDictionary->Count);
         myExceptionDictionary->Keys->CopyTo( (Array^)myArray, 0 );
         Console::WriteLine( " Keys are :" );

         for each(Object^ myObj in myArray)
         {
            Console::WriteLine(" " + myObj->ToString());
         }