//<snippet1>
using System;

public class EqualsTest {
    enum Colors { Red, Green, Blue, Yellow };
    enum Mammals { Cat, Dog, Horse, Dolphin };

    public static void Main() {
        Mammals myPet = Mammals.Cat;
        Colors myColor = Colors.Red;
        Mammals yourPet = Mammals.Dog;
        Colors yourColor = Colors.Red;

        Console.WriteLine("My favorite animal is a {0}", myPet);
        Console.WriteLine("Your favorite animal is a {0}", yourPet);
        Console.WriteLine("Do we like the same animal? {0}", myPet.Equals(yourPet) ? "Yes" : "No");

        Console.WriteLine();
        Console.WriteLine("My favorite color is {0}", myColor);
        Console.WriteLine("Your favorite color is {0}", yourColor);
        Console.WriteLine("Do we like the same color? {0}", myColor.Equals(yourColor) ? "Yes" : "No");

        Console.WriteLine();
        Console.WriteLine("The value of my color ({0}) is {1}", myColor, Enum.Format(typeof(Colors), myColor, "d"));
        Console.WriteLine("The value of my pet (a {0}) is {1}", myPet, Enum.Format(typeof(Mammals), myPet, "d"));
        Console.WriteLine("Even though they have the same value, are they equal? {0}", 
                    myColor.Equals(myPet) ? "Yes" : "No");
    }
}
// The example displays the following output:
//    My favorite animal is a Cat
//    Your favorite animal is a Dog
//    Do we like the same animal? No
//    
//    My favorite color is Red
//    Your favorite color is Red
//    Do we like the same color? Yes
//    
//    The value of my color (Red) is 0
//    The value of my pet (a Cat) is 0
//    Even though they have the same value, are they equal? No
//</snippet1>