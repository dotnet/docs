// <Snippet1>
using System;

public class Automobile
{
    public string _make;
    public string _model;
    public int _year;

    public Automobile(string make, string model, int year)
    {
        if (make == null)
           throw new ArgumentNullException("The make cannot be null.");
        else if (String.IsNullOrWhiteSpace(make))
           throw new ArgumentException("make cannot be an empty string or have space characters only.");
        _make = make;

        if (model == null)
           throw new ArgumentNullException("The model cannot be null.");
        else if (String.IsNullOrWhiteSpace(make))
           throw new ArgumentException("model cannot be an empty string or have space characters only.");
        _model = model;

        if (year < 1857 || year > DateTime.Now.Year + 2)
           throw new ArgumentException("The year is out of range.");
        _year = year;
    }

    public string Make
    { get { return _make; } }
    
    public string Model
    { get { return _model; } }

    public int Year
    { get { return _year; } }

    public override string ToString()
    {
        return String.Format("{0} {1} {2}", _year, _make, _model);
    }
}
// </Snippet1>

namespace IsA_Namespace
{
    // <Snippet2>
    using System;

    public class Example
    {
        public static void Main()
        {
            var packard = new Automobile("Packard", "Custom Eight", 1948);
            Console.WriteLine(packard);
        }
    }
    // The example displays the following output:
    //        1948 Packard Custom Eight
    // </Snippet2>
}
