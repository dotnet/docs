//<snippet1>
using System;
using System.Collections.Generic;

public class Temperature : IComparable<Temperature>
{
    // Implement the generic CompareTo method with the Temperature 
    // class as the Type parameter. 
    //
    public int CompareTo(Temperature other)
    {
        // If other is not a valid object reference, this instance is greater.
        if (other == null) return 1;
        
        // The temperature comparison depends on the comparison of 
        // the underlying Double values. 
        return m_value.CompareTo(other.m_value);
    }

    // Define the is greater than operator.
    public static bool operator >  (Temperature operand1, Temperature operand2)
    {
       return operand1.CompareTo(operand2) == 1;
    }
    
    // Define the is less than operator.
    public static bool operator <  (Temperature operand1, Temperature operand2)
    {
       return operand1.CompareTo(operand2) == -1;
    }

    // Define the is greater than or equal to operator.
    public static bool operator >=  (Temperature operand1, Temperature operand2)
    {
       return operand1.CompareTo(operand2) >= 0;
    }
    
    // Define the is less than or equal to operator.
    public static bool operator <=  (Temperature operand1, Temperature operand2)
    {
       return operand1.CompareTo(operand2) <= 0;
    }

    // The underlying temperature value.
    protected double m_value = 0.0;

    public double Celsius    
    {
        get
        {
            return m_value - 273.15;
        }
    }

    public double Kelvin    
    {
        get
        {
            return m_value;
        }
        set
        {
            if (value < 0.0)
            {
                throw new ArgumentException("Temperature cannot be less than absolute zero.");
            }
            else
            {
                m_value = value;
            }
        }
    }

    public Temperature(double kelvins)
    {
        this.Kelvin = kelvins;
    }
}

public class Example
{
    public static void Main()
    {
        SortedList<Temperature, string> temps = 
            new SortedList<Temperature, string>();

        // Add entries to the sorted list, out of order.
        temps.Add(new Temperature(2017.15), "Boiling point of Lead");
        temps.Add(new Temperature(0), "Absolute zero");
        temps.Add(new Temperature(273.15), "Freezing point of water");
        temps.Add(new Temperature(5100.15), "Boiling point of Carbon");
        temps.Add(new Temperature(373.15), "Boiling point of water");
        temps.Add(new Temperature(600.65), "Melting point of Lead");

        foreach( KeyValuePair<Temperature, string> kvp in temps )
        {
            Console.WriteLine("{0} is {1} degrees Celsius.", kvp.Value, kvp.Key.Celsius);
        }
    }
}
/* This example displays the following output:
      Absolute zero is -273.15 degrees Celsius.
      Freezing point of water is 0 degrees Celsius.
      Boiling point of water is 100 degrees Celsius.
      Melting point of Lead is 327.5 degrees Celsius.
      Boiling point of Lead is 1744 degrees Celsius.
      Boiling point of Carbon is 4827 degrees Celsius.
*/
//</snippet1>



