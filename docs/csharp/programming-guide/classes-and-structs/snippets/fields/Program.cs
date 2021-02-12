using System;

//<Snippet1>
public class CalendarEntry
{
    // private field
    private DateTime _Date;

    // public field (Generally not recommended.)
    public string day;

    // Public property exposes _Date field safely.
    public DateTime Date
    {
        get
        {
            return _Date;
        }
        set
        {
            // Set some reasonable boundaries for likely birth dates.
            if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
            {
                _Date = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    // Public method also exposes _Date field safely.
    // Example call: birthday.SetDate("1975, 6, 30");
    public void SetDate(string dateString)
    {
        DateTime dt = Convert.ToDateTime(dateString);

        // Set some reasonable boundaries for likely birth dates.
        if (dt.Year > 1900 && dt.Year <= DateTime.Today.Year)
        {
            _Date = dt;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public TimeSpan GetTimeSpan(string dateString)
    {
        DateTime dt = Convert.ToDateTime(dateString);

        if (dt.Ticks < date.Ticks)
        {
            return _Date - dt;
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
//</Snippet1>

class TestCalendarDate
{
    static void Main()
    {
        //<Snippet2>
        CalendarEntry birthday = new CalendarEntry();
        birthday.day = "Saturday";
        //</Snippet2>
    }
}

//<Snippet3>
public class CalendarDateWithInitialization
{
    public string day = "Monday";
    //...
}
//</Snippet3>
