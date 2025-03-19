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

    private static void ListSimilarChildCultures(string name)
    {
        // Create the neutral NumberFormatInfo object.
        NumberFormatInfo nfi = CultureInfo.GetCultureInfo(name).NumberFormat;
        // Retrieve all specific cultures of the neutral culture.
        CultureInfo[] cultures = Array.FindAll(CultureInfo.GetCultures(CultureTypes.SpecificCultures),
                                 culture => culture.Name.StartsWith(name + "-", StringComparison.OrdinalIgnoreCase));
        // Create an array of NumberFormatInfo properties
        PropertyInfo[] properties = typeof(NumberFormatInfo).GetProperties(BindingFlags.Instance | BindingFlags.Public);
        bool hasOneMatch = false;

        foreach (var ci in cultures)
        {
            bool match = true;
            // Get the NumberFormatInfo for a specific culture.
            NumberFormatInfo specificNfi = ci.NumberFormat;
            // Compare the property values of the two.
            foreach (var prop in properties)
            {
                // We're not interested in the value of IsReadOnly.
                if (prop.Name == "IsReadOnly") continue;

                // For arrays, iterate the individual elements to see if they are the same.
                if (prop.PropertyType.IsArray)
                {
                    IList nList = (IList)prop.GetValue(nfi, null);
                    IList sList = (IList)prop.GetValue(specificNfi, null);
                    if (nList.Count != sList.Count)
                    {
                        match = false;
                        break;
                    }

                    for (int ctr = 0; ctr < nList.Count; ctr++)
                    {
                        if (!nList[ctr].Equals(sList[ctr]))
                        {
                            match = false;
                            break;
                        }
                    }
                }
                else if (!prop.GetValue(specificNfi).Equals(prop.GetValue(nfi)))
                {
                    match = false;
                    break;
                }
            }
            if (match)
            {
                Console.WriteLine($"NumberFormatInfo object for '{name}' matches '{ci.Name}'");
                hasOneMatch = true;
            }
        }
        if (!hasOneMatch)
            Console.WriteLine($"NumberFormatInfo object for '{name}' --> No Match");

        Console.WriteLine();
    }
}
// </Snippet6>
