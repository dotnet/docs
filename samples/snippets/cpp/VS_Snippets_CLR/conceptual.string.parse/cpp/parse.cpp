// <snippet1>
using namespace System;

ref class StringParseMethod
{
public:
    static void Main()
    {
        // <snippet2>
        String^ MyString1 = "A";
        char MyChar = Char::Parse(MyString1);
        // MyChar now contains a Unicode "A" character.
        // </snippet2>

        // <snippet3>
        String^ MyString2 = "True";
        bool MyBool = bool::Parse(MyString2);
        // MyBool now contains a True Boolean value.
        // </snippet3>

        // <snippet4>
        String^ MyString3 = "Thursday";
        DayOfWeek MyDays = (DayOfWeek)Enum::Parse(DayOfWeek::typeid, MyString3);
        Console::WriteLine(MyDays);
        // The result is Thursday.
        // </snippet4>
    }
};

int main()
{
    StringParseMethod::Main();
}
// </snippet1>
