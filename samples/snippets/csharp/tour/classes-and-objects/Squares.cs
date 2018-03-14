namespace ClassesAndObjects
{
    using System;
    class Squares
    {
        public static void WriteSquares() 
        {
            int i = 0;
            int j;
            while (i < 10) 
            {
                j = i * i;
                Console.WriteLine($"{i} x {i} = {j}");
                i = i + 1;
            }
        }
    }
}