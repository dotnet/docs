using System;
using System.Collections.Generic;
using System.Text;

namespace UriTemplateMatchSnippets
{
    class Snippets
    {
        public static void Snippet1()
        {
            // <Snippet1>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                // BaseUri
                Console.WriteLine("BaseUri: {0}", results.BaseUri);
            }
            // output:
            // BaseUri: http://localhost
            // </Snippet1>
        }

        public static void Snippet2()
        {
            // <Snippet2>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                // BaseUri
                Console.WriteLine("BaseUri: {0}", results.BaseUri);

                Console.WriteLine("BoundVariables:");
                foreach (string variableName in results.BoundVariables.Keys)
                {
                    Console.WriteLine("    {0}: {1}", variableName, results.BoundVariables[variableName]);
                }
            }
            // Code output:
            // BaseUri: http://localhost/
            // BoundVariables:
            //  state: wa
            //  city: seattleConsole.WriteLine("BaseUri: {0}", results.BaseUri);
            // </Snippet2>
        }

        public static void Snippet3()
        {
            // <Snippet3>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                Object data = results.Data;
            }
            // </Snippet3>
        }

        public static void Snippet4()
        {
            // <Snippet4>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                Console.WriteLine("QueryParameters:");
                foreach (string queryName in results.QueryParameters.Keys)
                {
                    Console.WriteLine("    {0} : {1}", queryName, results.QueryParameters[queryName]);
                }
                Console.WriteLine();
            }
            // Code output:
            //  QueryParameters:
            //  forecast : today
            // </Snippet4>
        }

        public static void Snippet5()
        {
            // <Snippet5>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                Console.WriteLine("RelativePathSegments:");
                foreach (string segment in results.RelativePathSegments)
                {
                    Console.WriteLine("     {0}", segment);
                }
            }
            // Code output:
            // RelativePathSegments:
            //   weather
            //   wa
            //   seattle
            // </Snippet5>
        }

        public static void Snippet6()
        {
            // <Snippet6>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                Console.WriteLine("RequestUri:");
                Console.WriteLine(results.RequestUri);
            }
            // Code output:
            // RequestUri:
            // http://localhost/weather/WA/Seattle?forecast=today
            // </Snippet6>
        }

        public static void Snippet7()
        {
            // <Snippet7>
            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                Console.WriteLine("Template:");
                Console.WriteLine(results.Template);
            }
            // Code output:
            // Template:
            // weather/{state}/{city}?forecast=today

            // </Snippet7>
        }

        public static void Snippet8()
        {
            // <Snippet8>
            UriTemplate template = new UriTemplate("weather/{state}/*?forecast=today");
            Uri baseAddress = new Uri("http://localhost");
            Uri fullUri = new Uri("http://localhost/weather/WA/Seattle?forecast=today");

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            // Match a URI to a template
            UriTemplateMatch results = template.Match(baseAddress, fullUri);
            if (results != null)
            {
                Console.WriteLine("WildcardPathSegments:");
                foreach (string segment in results.WildcardPathSegments)
                {
                    Console.WriteLine("     {0}", segment);
                }
                Console.WriteLine();
            }
            // Code output:
            // WildcardPathSegments:
            //   seattle
            // </Snippet8>
        }
    }
}
