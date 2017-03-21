void ParseTest()
{
   PhysicalAddress^ address = PhysicalAddress::Parse( L"AC1EBA22" );
   Console::WriteLine( L"Address parsed as {0}", address->ToString() );
   PhysicalAddress^ address2 = PhysicalAddress::Parse( L"ac1eba22" );
   Console::WriteLine( L"Address2 parsed as {0}", address2->ToString() );
   bool test = address->Equals( address2 );
   Console::WriteLine( L"Equal? {0}", test );
}

