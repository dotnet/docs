      int p = 0;
      Console::WriteLine( "\nCurrent evidence = " );
      if ( nullptr == myEvidence )
            return 0;

      IEnumerator^ list = myEvidence->GetEnumerator();
      IEnumerator^ myEnum1 = list;
      while ( myEnum1->MoveNext() )
      {
         Object^ obj = safe_cast<Object^>(myEnum1->Current);
         Console::WriteLine( obj );
         p++;
      }