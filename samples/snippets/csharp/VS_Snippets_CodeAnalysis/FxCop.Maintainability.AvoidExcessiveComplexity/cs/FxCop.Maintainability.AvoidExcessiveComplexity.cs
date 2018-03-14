using System;


class someclass
{
    //<Snippet1>
    public void Method()
    {
        Console.WriteLine("Hello World!");
    }
    //</Snippet1>



    //<Snippet2>


    void Method(bool condition)
    {
        if (condition)
        {
            Console.WriteLine("Hello World!");
        }
    }
    //</Snippet2>

    //<Snippet3>
    public void Method(bool condition1, bool condition2)
    {
        if (condition1 || condition2)
        {
            Console.WriteLine("Hello World!");
        }
    }
    //</Snippet3>

    //<Snippet4>
    public void Method(DayOfWeek day)
    {

        switch (day)
        {
            case DayOfWeek.Monday:
                Console.WriteLine("Today is Monday!");
                break;
            case DayOfWeek.Tuesday:
                Console.WriteLine("Today is Tuesday!");
                break;
            case DayOfWeek.Wednesday:
                Console.WriteLine("Today is Wednesday!");
                break;
            case DayOfWeek.Thursday:
                Console.WriteLine("Today is Thursday!");
                break;
            case DayOfWeek.Friday:
                Console.WriteLine("Today is Friday!");
                break;
            case DayOfWeek.Saturday:
                Console.WriteLine("Today is Saturday!");
                break;
            case DayOfWeek.Sunday:
                Console.WriteLine("Today is Sunday!");
                break;
        }
    }

}
//</Snippet4>