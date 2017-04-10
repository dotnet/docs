//<Snippet1>
using System;

public class GetNameTest {
    enum Colors { Red, Green, Blue, Yellow };
    enum Styles { Plaid, Striped, Tartan, Corduroy };

    public static void Main() {

        Console.WriteLine("The 4th value of the Colors Enum is {0}", Enum.GetName(typeof(Colors), 3));
        Console.WriteLine("The 4th value of the Styles Enum is {0}", Enum.GetName(typeof(Styles), 3));
    }
}
// The example displays the following output:
//       The 4th value of the Colors Enum is Yellow
//       The 4th value of the Styles Enum is Corduroy
//</Snippet1>
