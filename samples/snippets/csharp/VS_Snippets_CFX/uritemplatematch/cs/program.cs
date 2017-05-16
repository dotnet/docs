using System;
using System.Collections.Generic;
using System.Text;

namespace UriTemplateMatchSnippets
{
    class Program
    {
        static void Main(string[] args)
        {
            // <Snippet0>
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

                Console.WriteLine("QueryParameters:");
                foreach (string queryName in results.QueryParameters.Keys)
                {
                    Console.WriteLine("    {0} : {1}", queryName, results.QueryParameters[queryName]);
                }
                Console.WriteLine();

                Console.WriteLine("RelativePathSegments:");
                foreach (string segment in results.RelativePathSegments)
                {
                    Console.WriteLine("     {0}", segment);
                }
                Console.WriteLine();

                Console.WriteLine("RequestUri:");
                Console.WriteLine(results.RequestUri);

                Console.WriteLine("Template:");
                Console.WriteLine(results.Template);

                Console.WriteLine("WildcardPathSegments:");
                foreach (string segment in results.WildcardPathSegments)
                {
                    Console.WriteLine("     {0}", segment);
                }
                Console.WriteLine();
            }
            // </Snippet0>
        }
    }
}
