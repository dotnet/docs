// <Snippet6>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

public class InstantiateEx6
{
    public static void Main()
    {
        // Get all the neutral cultures
        List<String> names = new List<String>();
        Array.ForEach(CultureInfo.GetCultures(CultureTypes.NeutralCultures),
                      culture => names.Add(culture.Name));
        names.Sort();
        foreach (var name in names)
        {
            // Ignore the invariant culture.
            if (name == "") continue;

            ListSimilarChildCultures(name);
        }
    }

    private static void ListSimilarChildCultures(String name)
    {
        // Create the neutral DateTimeFormatInfo object.
        DateTimeFormatInfo dtfi = CultureInfo.GetCultureInfo(name).DateTimeFormat;
        // Retrieve all specific cultures of the neutral culture.
        CultureInfo[] cultures = Array.FindAll(CultureInfo.GetCultures(CultureTypes.SpecificCultures),
                                 culture => culture.Name.StartsWith(name + "-", StringComparison.OrdinalIgnoreCase));
        // Create an array of DateTimeFormatInfo properties
        PropertyInfo[] properties = typeof(DateTimeFormatInfo).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        bool hasOneMatch = false;

        foreach (var ci in cultures)
        {
            bool match = true;
            // Get the DateTimeFormatInfo for a specific culture.
            DateTimeFormatInfo specificDtfi = ci.DateTimeFormat;
            // Compare the property values of the two.
            foreach (var prop in properties)
            {
                // We're not interested in the value of IsReadOnly.
                if (prop.Name == "IsReadOnly") continue;

                // For arrays, iterate the individual elements to see if they are the same.
                if (prop.PropertyType.IsArray)
                {
                    IList nList = (IList)prop.GetValue(dtfi, null);
                    IList sList = (IList)prop.GetValue(specificDtfi, null);
                    if (nList.Count != sList.Count)
                    {
                        match = false;
                        Console.WriteLine($"   Different n in {prop.Name} array for {name} and {ci.Name}");
                        break;
                    }

                    for (int ctr = 0; ctr < nList.Count; ctr++)
                    {
                        if (!nList[ctr].Equals(sList[ctr]))
                        {
                            match = false;
                            Console.WriteLine($"   {prop.Name} value different for {name} and {ci.Name}");
                            break;
                        }
                    }

                    if (!match) break;
                }
                // Get non-array values.
                else
                {
                    Object specificValue = prop.GetValue(specificDtfi);
                    Object neutralValue = prop.GetValue(dtfi);

                    // Handle comparison of Calendar objects.
                    if (prop.Name == "Calendar")
                    {
                        // The cultures have a different calendar type.
                        if (specificValue.ToString() != neutralValue.ToString())
                        {
                            Console.WriteLine($"   Different calendar types for {name} and {ci.Name}");
                            match = false;
                            break;
                        }

                        if (specificValue is GregorianCalendar)
                        {
                            if (((GregorianCalendar)specificValue).CalendarType != ((GregorianCalendar)neutralValue).CalendarType)
                            {
                                Console.WriteLine($"   Different Gregorian calendar types for {name} and {ci.Name}");
                                match = false;
                                break;
                            }
                        }
                    }
                    else if (!specificValue.Equals(neutralValue))
                    {
                        match = false;
                        Console.WriteLine($"   Different {prop.Name} values for {name} and {ci.Name}");
                        break;
                    }
                }
            }
            if (match)
            {
                Console.WriteLine($"DateTimeFormatInfo object for '{name}' matches '{ci.Name}'");
                hasOneMatch = true;
            }
        }
        if (!hasOneMatch)
            Console.WriteLine($"DateTimeFormatInfo object for '{name}' --> No Match");

        Console.WriteLine();
    }
}
// </Snippet6>
