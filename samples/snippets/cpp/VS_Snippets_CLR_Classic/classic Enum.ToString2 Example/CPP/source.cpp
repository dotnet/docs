
// <Snippet1>
using namespace System;
public ref class EnumSample
{
public:
   enum class Colors
   {
      Red = 1,
      Blue = 2
   };

   static void main()
   {
      Enum ^ myColors = Colors::Red;
      Console::WriteLine( "The value of this instance is '{0}'", myColors );
   }

};

int main()
{
   EnumSample::main();
}

/*
Output.
The value of this instance is 'Red'.
*/
// </Snippet1>
