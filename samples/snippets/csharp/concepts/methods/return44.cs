using System;

//<Snippet44>
class SimpleMath
{
    public int AddTwoNumbers(int number1, int number2)
    {
        return number1 + number2;
    }

    public int SquareANumber(int number)
    {
        return number * number;
    }
}
//</Snippet44>

class TestSimpleMath
{
    static void Main()
    {
       SimpleMath obj = new SimpleMath();

       //<Snippet45>
       int result = obj.AddTwoNumbers(1, 2);
       result = obj.SquareANumber(result);
       // The result is 9.
       Console.WriteLine(result);
       //</Snippet45>

       //<Snippet46>
       result = obj.SquareANumber(obj.AddTwoNumbers(1, 2));
       // The result is 9.
       Console.WriteLine(result);
       //</Snippet46>
    }
}
