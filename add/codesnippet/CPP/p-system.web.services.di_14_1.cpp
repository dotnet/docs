         array<Object^>^myCollectionArray = gcnew array<Object^>(myExceptionDictionary->Count);
         myExceptionDictionary->Values->CopyTo( (Array^)myCollectionArray, 0 );
         Console::WriteLine( " Values are :" );
         for each(Object^ myObj in myCollectionArray)
         {
            Console::WriteLine(" " + myObj->ToString());
         }