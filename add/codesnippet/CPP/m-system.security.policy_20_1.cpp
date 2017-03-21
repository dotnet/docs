         Url^ url = gcnew Url( "http://www.treyresearch.com" );
         Console::WriteLine( "Adding host evidence {0}", url );
         ev2a->AddHost( url );
         Evidence^ ev2b = gcnew Evidence( ev2a );
         Console::WriteLine( "Copy evidence into new evidence" );
         IEnumerator^ enum1 = ev2b->GetHostEnumerator();
         enum1->MoveNext();
         Console::WriteLine( enum1->Current );
