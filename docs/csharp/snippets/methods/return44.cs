//<Snippet43>
class SimpleMathExtnsion
{
    public int DivideTwoNumbers(int number1, int number2)
    {
        return number1 / number2;
    }
}
//</Snippet43>

//<Snippet44>
class SimpleMath
{
    public int AddTwoNumbers(int number1, int number2) =>
        number1 + number2;

    public int SquareANumber(int number) =>
        number * number;
}
//</Snippet44>

static class TestSimpleMath
{
    static void Main()
    {
        var obj = new SimpleMath();
        var obj2 = new SimpleMathExtnsion();

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

        //<Snippet47>
        result = obj2.DivideTwoNumbers(6,2);
        // The result is 3.
        Console.WriteLine(result);
        //</Snippet47>
    }
}
