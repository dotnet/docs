// <Snippet1>
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Guest guest1 = new Guest("Ben", "Miller", 17);
            Console.WriteLine(guest1.GuestInfo());
        }
        catch (ArgumentOutOfRangeException outOfRange)
        {

            Console.WriteLine("Error: {0}", outOfRange.Message);
        }
    }
}

class Guest
{
    private string FirstName;
    private string LastName;
    private int Age;

    public Guest(string fName, string lName, int age)
    {
        FirstName = fName;
        LastName = lName;
        if (age < 21)
            throw new ArgumentOutOfRangeException("age","All guests must be 21-years-old or older.");
        else
            Age = age;
    }

    public string GuestInfo()
    {
        string gInfo = FirstName + " " + LastName + ", " + Age.ToString();
        return(gInfo);
    }
}
// </Snippet1>