
// <Snippet1>
using namespace System;

// Declare an enum type.
public enum class NumEnum
{
   One, Two
};

int main()
{
    bool flag = false;
    NumEnum testEnum = NumEnum::One;
      
    // Get the type of myTestEnum.
    Type^ t = testEnum.GetType();
      
    // Get the IsValueType property of the myTestEnum
    // variable.
    flag = t->IsValueType;
    Console::WriteLine("{0} is a value type: {1}", t->FullName, flag);
}
// </Snippet1>
