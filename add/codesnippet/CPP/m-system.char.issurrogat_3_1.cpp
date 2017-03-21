using namespace System;
int main()
{
   
   // - escape params specifying Unicode not implemented in v7.0
   Console::WriteLine( Char::IsSurrogate( 'a' ) ); // Output: "False"
}
