//<snippet1>
using System;

public class JoinTest {
    public static void Main() {

        Console.WriteLine(MakeLine(0, 5, ", "));
        Console.WriteLine(MakeLine(1, 6, "  "));
        Console.WriteLine(MakeLine(9, 9, ": "));
        Console.WriteLine(MakeLine(4, 7, "< "));
    }

    private static string MakeLine(int initVal, int multVal, string sep) {

        string [] sArr = new string [10];

        for (int i = initVal; i < initVal + 10; i++)
            sArr[i - initVal] = String.Format("{0,-3}", i * multVal);

        return String.Join(sep, sArr);
    }
}
// The example displays the following output:
//       0  , 5  , 10 , 15 , 20 , 25 , 30 , 35 , 40 , 45
//       6    12   18   24   30   36   42   48   54   60
//       81 : 90 : 99 : 108: 117: 126: 135: 144: 153: 162
//       28 < 35 < 42 < 49 < 56 < 63 < 70 < 77 < 84 < 91  
// </snippet1>