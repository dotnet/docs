// <snippet1>
using System;

class StringsParseMethod
{
    public static void Main()
    {
        // <snippet2>
        string MyString1 = "A";
        char MyChar = Char.Parse(MyString1);
        // MyChar now contains a Unicode "A" character.
        // </snippet2>

        // <snippet3>
        string MyString2 = "True";
        bool MyBool = bool.Parse(MyString2);
        // MyBool now contains a True Boolean value.
        // </snippet3>

        // <snippet4>
        string MyString3 = "Thursday";
        DayOfWeek MyDays = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), MyString3);
        Console.WriteLine(MyDays);
        // The result is Thursday.
        // </snippet4>
    }
}
// </snippet1>
