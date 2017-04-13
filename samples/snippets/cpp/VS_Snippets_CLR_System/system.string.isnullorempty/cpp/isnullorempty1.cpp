using namespace System;

bool Test( String^ s )
{
      bool result;
      // <Snippet1>
      result = s == nullptr || s == String::Empty;
      // </Snippet1>
      return result;
}

int main()
{
   String^ s1;
   String^ s2 = "";
   Console::WriteLine( "String s1 {0}.", Test( s1 ) );
   Console::WriteLine( "String s2 {0}.", Test( s2 ) );
}