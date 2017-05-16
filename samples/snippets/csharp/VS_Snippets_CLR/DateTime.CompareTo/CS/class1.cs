using System;

namespace CompareTo
{
    class Class1
    {
        static void Main(string[] args)
	{
            // <Snippet1>
            System.DateTime theDay = new System.DateTime(System.DateTime.Today.Year, 7, 28);
            int compareValue;

            try 
            {
                compareValue = theDay.CompareTo(DateTime.Today);
            } 
            catch (ArgumentException) 
            {
               Console.WriteLine("Value is not a DateTime");
               return;
            }

            if (compareValue < 0) 
               System.Console.WriteLine("{0:d} is in the past.", theDay);
            else if (compareValue == 0) 
               System.Console.WriteLine("{0:d} is today!", theDay);
            else // compareValue > 0
               System.Console.WriteLine("{0:d} has not come yet.", theDay);
            // </Snippet1>
        }
    }
}
