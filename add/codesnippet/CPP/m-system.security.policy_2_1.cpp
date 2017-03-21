         array<Object^>^oa1 = {};
         Site^ site = gcnew Site( "www.wideworldimporters.com" );
         array<Object^>^oa2 = {url,site};
         Evidence^ ev3a = gcnew Evidence( oa1,oa2 );
         enum1 = ev3a->GetHostEnumerator();
         IEnumerator^ enum2 = ev3a->GetAssemblyEnumerator();
         enum2->MoveNext();
         Object^ obj1 = enum2->Current;
         enum2->MoveNext();
         Console::WriteLine( "URL = {0}  Site = {1}", obj1, enum2->Current );
         