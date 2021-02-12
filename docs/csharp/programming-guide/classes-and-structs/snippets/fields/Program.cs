using System;

//<Snippet1>
public class CalendarEntry
{
    // public field (Generally not recommended.)
    public string Day;
    
    // private field
    private DateTime _Date;

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

        if (dt.Ticks < _Date.Ticks)
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
        birthday.Day = "Saturday";
        //</Snippet2>
    }
}

//<Snippet3>
public class CalendarDateWithInitialization
{
    public string Day = "Monday";
    //...
}
//</Snippet3>
