namespace Enums
{
    using System;
    enum Color
    {
        Red,
        Green,
        Blue
    }
    class EnumExample
    {
        static void PrintColor(Color color) 
        {
            switch (color) 
            {
                case Color.Red:
                    Console.WriteLine("Red");
                    break;
                case Color.Green:
                    Console.WriteLine("Green");
                    break;
                case Color.Blue:
                    Console.WriteLine("Blue");
                    break;
                default:
                    Console.WriteLine("Unknown color");
                    break;
            }
        }
        static void Main() 
        {
            Color c = Color.Red;
            PrintColor(c);
            PrintColor(Color.Blue);
        }
    }

    enum Alignment: sbyte
    {
        Left = -1,
        Center = 0,
        Right = 1
    }

    class UsageCode
    {
        static void ConvertToInteger()
        {
            int i = (int)Color.Blue;    // int i = 2;
            Color c = (Color)2;         // Color c = Color.Blue;  

            if (i != 2)
                Console.WriteLine(c.ToString());          
        }

        static void Zero()
        {
            Color c = 0;

            if (c != Color.Red)
                Console.WriteLine("everything I knew about C# is wrong");
        }
    }
}