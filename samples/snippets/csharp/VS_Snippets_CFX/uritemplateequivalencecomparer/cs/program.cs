using System;
using System.Collections.Generic;
using System.Text;

namespace UriTemplateEquivalenceComparerSnippet
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet0>
            // Define two structurally equivalent templates
            UriTemplate temp1 = new UriTemplate("weather/{state}/{city}");
            UriTemplate temp2 = new UriTemplate("weather/{country}/{village}");

            // Notice they are not reference equal, in other words
            // they are do not refer to the same object
            if (temp1 == temp2)
                Console.WriteLine("{0} and {1} are reference equal", temp1, temp2);
            else
                Console.WriteLine("{0} and {1} are NOT reference equal", temp1, temp2);

            // Notice they are structrually equal
            if (temp1.IsEquivalentTo(temp2))
                Console.WriteLine("{0} and {1} are structurally equal", temp1, temp2);
            else
                Console.WriteLine("{0} and {1} are NOT structurally equal", temp1, temp2);

            // <Snippet1>
            // Create a dictionary and use UriTemplateEquivalenceComparer as the comparer
            Dictionary<UriTemplate, object> templates = new Dictionary<UriTemplate, object>(new UriTemplateEquivalenceComparer());
            // </Snippet1>

            // Add template 1 into the dictionary
            templates.Add(temp1, "template1");

            // The UriTemplateEquivalenceComparer will be used here to compare the template in the table with template2
            // they are structurally equivalent, so ContainsKey will return true.
            if (templates.ContainsKey(temp2))
                Console.WriteLine("Both templates hash to the same value");
            else
                Console.WriteLine("Both templates do NOT hash to the same value");
            // </Snippet0>
        }
    }
}
