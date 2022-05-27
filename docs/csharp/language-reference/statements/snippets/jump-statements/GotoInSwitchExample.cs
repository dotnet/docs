using System;

public enum CoffeChoice
{
    Plain,
    WithMilk,
    WithIceCream,
}

public class GotoInSwitchExample
{
    public static void Main()
    {
        Console.WriteLine(CalculatePrice(CoffeChoice.Plain));  // output: 10.0
        Console.WriteLine(CalculatePrice(CoffeChoice.WithMilk));  // output: 15.0
        Console.WriteLine(CalculatePrice(CoffeChoice.WithIceCream));  // output: 17.0
    }

    private static decimal CalculatePrice(CoffeChoice choice)
    {
        decimal price = 0;
        switch (choice)
        {
            case CoffeChoice.Plain:
                price += 10.0m;
                break;

            case CoffeChoice.WithMilk:
                price += 5.0m;
                goto case CoffeChoice.Plain;

            case CoffeChoice.WithIceCream:
                price += 7.0m;
                goto case CoffeChoice.Plain;
        }
        return price;
    }
}
