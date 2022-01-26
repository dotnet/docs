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
        public class ProductDescription
        {
            private string shortDescription;
            private string? detailedDescription;

            public ProductDescription() // Warning! shortDescription not initialized.
            {
            }

            public ProductDescription(string productDescription) =>
                this.shortDescription = productDescription;

            public void SetDescriptions(string productDescription, string? details=null)
            {
                shortDescription = productDescription;
                detailedDescription = details;
            }

            public string GetDescription()
            {
                if (detailedDescription.Length == 0) // Warning! dereference possible null
                {
                    return shortDescription;
                }
                else
                {
                    return $"{shortDescription}\n{detailedDescription}";
                }
            }

            public string FullDescription()
            {
                if (detailedDescription == null)
                {
                    return shortDescription;
                }
                else if (detailedDescription.Length > 0) // OK, detailedDescription can't be null.
                {
                    return $"{shortDescription}\n{detailedDescription}";
                }
                return shortDescription;
            }
        }
        // </SnippetClassWithNullable>

        private static void WarningsExamples()
        {
            // <SnippetLocalWarnings>
            string shortDescription = default; // Warning! non-nullable set to null;
            var product = new ProductDescription(shortDescription); // Warning! static analysis knows shortDescription maybe null.

            string description = "widget";
            var item = new ProductDescription(description);

            item.SetDescriptions(description, "These widgets will do everything.");
            // </SnippetLocalWarnings>
            string result = item.FullDescription();
        }
    }
    #nullable restore
}
