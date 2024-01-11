// <Snippet11>
using System;
using System.Text;

public class Example13
{
    public static void Main()
    {
        StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
        MyStringBuilder.Replace('!', '?');
        Console.WriteLine(MyStringBuilder);
    }
}
// The example displays the following output:
//       Hello World?
// </Snippet11>
