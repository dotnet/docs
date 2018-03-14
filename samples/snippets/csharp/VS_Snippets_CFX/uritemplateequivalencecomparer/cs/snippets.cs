using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UriTemplateEquivalenceComparerSnippets
{
    public class Snippets
    {
        public static void Snippet2()
        {
            // <Snippet2>
            UriTemplate temp1 = new UriTemplate("weather/{state}/{city}");
            UriTemplate temp2 = new UriTemplate("weather/{country}/{village}");

            // Notice they are not reference equal, in other words
            // they are do not refer to the same object
            if (temp1 == temp2)
                Console.WriteLine("{0} and {1} are reference equal", temp1, temp2);
            else
                Console.WriteLine("{0} and {1} are NOT reference equal", temp1, temp2);

            // Notice they are structrually equal
            UriTemplateEquivalenceComparer comparer = new UriTemplateEquivalenceComparer();
            bool result = comparer.Equals(temp1, temp2);
            
            if (result)
                Console.WriteLine("{0} and {1} are structurally equal", temp1, temp2);
            else
                Console.WriteLine("{0} and {1} are NOT structurally equal", temp1, temp2);
            // </Snippet2>
        }
    }
}
