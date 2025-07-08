//<Snippet43>
class SimpleMathExtension
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

static class TestSimpleMathExtension
{
    static void Main()
    {
        var obj = new SimpleMathExtension();
        
        //<Snippet47>
        int result = obj.DivideTwoNumbers(6,2);
        // The result is 3.
        Console.WriteLine(result);
        //</Snippet47>
    }
}

static class TestSimpleMath
{
    static void Main()
    {
        var obj = new SimpleMath();

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
