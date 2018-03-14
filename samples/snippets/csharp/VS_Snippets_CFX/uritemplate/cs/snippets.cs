using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace UriTemplateSnippets
{
    public class Snippets
    {
        public static void Snippet0()
        {
            // <Snippet0>
            // <Snippet1>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            // </Snippet1>
            Uri prefix = new Uri("http://localhost");

            Console.WriteLine("PathSegmentVariableNames:");
            foreach (string name in template.PathSegmentVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }
            Console.WriteLine();

            Console.WriteLine("QueryValueVariableNames:");
            foreach (string name in template.QueryValueVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }
            Console.WriteLine();

            Uri positionalUri = template.BindByPosition(prefix, "Washington", "Redmond", "Today");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("state", "Washington");
            parameters.Add("city", "Redmond");
            parameters.Add("day", "Today");
            Uri namedUri = template.BindByName(prefix, parameters);

            Uri fullUri = new Uri("http://localhost/weather/Washington/Redmond?forecast=today");
            UriTemplateMatch results = template.Match(prefix, fullUri);

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            if (results != null)
            {
                foreach (string variableName in results.BoundVariables.Keys)
                {
                    Console.WriteLine("   {0}: {1}", variableName, results.BoundVariables[variableName]);
                }
            }
            // </Snippet0>

        }

        public static void Snippet2()
        {
            // <Snippet2>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");

            Uri prefix = new Uri("http://localhost");

            Console.WriteLine("PathSegmentVariableNames:");
            foreach (string name in template.PathSegmentVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Console.WriteLine("QueryValueVariableNames:");
            foreach (string name in template.QueryValueVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("state", "Washington");
            parameters.Add("city", "Redmond");
            parameters.Add("day", "Today");
            Uri namedUri = template.BindByName(prefix, parameters);
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Uri positionalUri = template.BindByPosition(prefix, "Washington", "Redmond", "Today");
            // </Snippet5>
        }

        public static void Snippet6()
        {
            // <Snippet6>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            UriTemplate template2 = new UriTemplate("weather/{country}/{village}?forecast={type}");

            bool equiv = template.IsEquivalentTo(template2);
            // </Snippet6>
        }

        public static void Snippet7()
        {
            // <Snippet7>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Uri fullUri = new Uri("http://localhost/weather/Washington/Redmond?forecast=today");
            UriTemplateMatch results = template.Match(prefix, fullUri);

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            if (results != null)
            {
                foreach (string variableName in results.BoundVariables.Keys)
                {
                    Console.WriteLine("   {0}: {1}", variableName, results.BoundVariables[variableName]);
                }
            }
            // </Snippet7>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Console.WriteLine(template.ToString());
            // </Snippet8>
        }
    }
}
