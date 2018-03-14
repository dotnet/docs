//<snippet1>
using System;

public class ChangeTypeTest {
    public static void Main() {

        Double d = -2.345;
        int i = (int)Convert.ChangeType(d, typeof(int));

        Console.WriteLine("The double value {0} when converted to an int becomes {1}", d, i);

        string s = "12/12/98";
        DateTime dt = (DateTime)Convert.ChangeType(s, typeof(DateTime));

        Console.WriteLine("The string value {0} when converted to a Date becomes {1}", s, dt);        
    }
}
//</snippet1>