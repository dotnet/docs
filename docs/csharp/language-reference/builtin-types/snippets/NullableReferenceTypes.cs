using System;

namespace builtin_types
{
    #nullable enable
    public static class NullableReferenceTypes
    {
        public static void Examples()
        {
            FirstExample();
            WarningsExamples();
        }

        private static void FirstExample()
        {
            // <SnippetCoreSyntax>
            string notNull = "Hello";
            string? nullable = default;
            notNull = nullable!; // null forgiveness
            // </SnippetCoreSyntax>
        }

        // <SnippetClassWithNullable>
        public class GreetingContainer
        {
            private string greeting;
            private string? optionalGreeting;

            public GreetingContainer()
            {
                // Warning! greeting not initialize.
            }

            public GreetingContainer(string greeting) =>
                this.greeting = greeting;

            public void SetGreetings(string greet, string? optional=null)
            {
                greeting = greet;
                optionalGreeting = optional;
            }

            public string FullGreeting()
            {
                if (optionalGreeting.Length == 0) // Warning! dereference possible null
                {
                    return greeting;
                } else
                {
                    return $"{greeting}\n{optionalGreeting}";
                }
            }

            public string FormatGreeting()
            {
                if (optionalGreeting == null)
                {
                    return greeting;
                } else if (optionalGreeting.Length > 0) // OK, optionalGreeting can't be null.
                {
                    return $"{greeting}\n{optionalGreeting}";
                }
                return greeting;
            }
        }
        // </SnippetClassWithNullable>

        private static void WarningsExamples()
        {
            // <SnippetLocalWarnings>
            string greeting = default; // Warning! non-nullable set to null;
            var container = new GreetingContainer(greeting); // Warning! static analysis knows greeting maybe null.

            string hello = "hello";
            var item = new GreetingContainer(hello);

            item.SetGreetings("hello", "World!");
            // </SnippetLocalWarnings>
            string result = item.FormatGreeting();
        }
    }
    #nullable restore
}
