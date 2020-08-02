using System;
using System.IO;

namespace keywords
{
    public static class UsingStatements
    {
        public static void Examples()
        {
            UsingExample();
            ModernUsing();
            TryFinallyExample();
            DeclareMultipleVariables();
            ModernMultipleVariables();
            DeclareBeforeUsing();
        }

        private static void UsingExample()
        {
            // <SnippetFirstExample>
            string manyLines = @"This is line one
            This is line two
            Here is line three
            The penultimate line is line four
            This is the final, fifth line.";

            using (var reader = new StringReader(manyLines))
            {
                string? item;
                do
                {
                    item = reader.ReadLine();
                    Console.WriteLine(item);
                } while (item != null);
            }
            // </SnippetFirstExample>
        }

        private static void ModernUsing()
        {
            // <SnippetModernUsing>
            string manyLines = @"This is line one
            This is line two
            Here is line three
            The penultimate line is line four
            This is the final, fifth line.";

            using var reader = new StringReader(manyLines);
            string? item;
            do
            {
                item = reader.ReadLine();
                Console.WriteLine(item);
            } while (item != null);
            // </SnippetModernUsing>
        }

        private static void TryFinallyExample()
        {
            // The extra braces are necessary for the explanation. Do not remove them.
            // <SnippetTryFinallyExample>
            string manyLines = @"This is line one
            This is line two
            Here is line three
            The penultimate line is line four
            This is the final, fifth line.";

            {
                var reader = new StringReader(manyLines);
                try
                {
                    string? item;
                    do
                    {
                        item = reader.ReadLine();
                        Console.WriteLine(item);
                    } while (item != null);
                }
                finally
                {
                    reader?.Dispose();
                }
            }
            // </SnippetTryFinallyExample>
        }

        private static void DeclareMultipleVariables()
        {
            // <SnippetDeclareMultipleVariables>
            string numbers = @"One
            Two
            Three
            Four.";
            string letters = @"A
            B
            C
            D.";

            using (StringReader left = new StringReader(numbers),
                right = new StringReader(letters))
            {
                string? item;
                do
                {
                    item = left.ReadLine();
                    Console.Write(item);
                    Console.Write("    ");
                    item = right.ReadLine();
                    Console.WriteLine(item);
                } while (item != null);
            }
            // </SnippetDeclareMultipleVariables>
        }

        private static void ModernMultipleVariables()
        {
            // <SnippetModernMultipleVariables>
            string numbers = @"One
            Two
            Three
            Four.";
            string letters = @"A
            B
            C
            D.";

            using StringReader left = new StringReader(numbers),
                right = new StringReader(letters);
            string? item;
            do
            {
                item = left.ReadLine();
                Console.Write(item);
                Console.Write("    ");
                item = right.ReadLine();
                Console.WriteLine(item);
            } while (item != null);
            // </SnippetModernMultipleVariables>
        }

        private static void DeclareBeforeUsing()
        {
            // <SnippetDeclareBeforeUsing>
            string manyLines = @"This is line one
            This is line two
            Here is line three
            The penultimate line is line four
            This is the final, fifth line.";

            var reader = new StringReader(manyLines);
            using (reader)
            {
                string? item;
                do
                {
                    item = reader.ReadLine();
                    Console.WriteLine(item);
                } while (item != null);
            }
            // reader is in scope here, but has been disposed
            // </SnippetDeclareBeforeUsing>
        }
    }
}
