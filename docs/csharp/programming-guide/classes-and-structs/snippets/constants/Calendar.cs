//<Snippet1>
class Calendar1
{
    public const int Months = 12;
}
//</Snippet1>

//<Snippet2>
class Calendar2
{
    public const int Months = 12, Weeks = 52, Days = 365;
}
//</Snippet2>

//<Snippet3>
class Calendar3
{
    public const int Months = 12;
    public const int Weeks = 52;
    public const int Days = 365;

    public const double DaysPerWeek = (double) Days / (double) Weeks;
    public const double DaysPerMonth = (double) Days / (double) Months;
}
//</Snippet3>

class Calendar
{
    public const int Months = 12;

    static void Main()
    {
        //<Snippet4>
        int birthstones = Calendar.Months;
        //</Snippet4>

        Console.WriteLine(birthstones.ToString());
    }
}
