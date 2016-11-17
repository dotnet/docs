    public class BoolTest
    {
        static void Main()
        {
            bool b = true;

            // WriteLine automatically converts the value of b to text.
            Console.WriteLine(b);

            int days = DateTime.Now.DayOfYear;


            // Assign the result of a boolean expression to b.
            b = (days % 2 == 0);

            // Branch depending on whether b is true or false.
            if (b)
            {
                Console.WriteLine("days is an even number");
            }
            else
            {
                Console.WriteLine("days is an odd number");
            }   
        }
    }
    /* Output:
      True
      days is an <even/odd> number
    */