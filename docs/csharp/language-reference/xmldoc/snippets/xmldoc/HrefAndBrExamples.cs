using System;

namespace XmlDocumentationExamples
{
    /// <summary>
    /// This class demonstrates the use of href attribute and br tag in XML documentation.
    /// </summary>
    public class HrefAndBrExamples
    {
        //<UrlLinkingExample>
        /// <summary>
        /// This method demonstrates URL linking:
        /// <see cref="https://docs.microsoft.com/dotnet/csharp"/> (won't create clickable link)
        /// <see href="https://docs.microsoft.com/dotnet/csharp">C# documentation</see> (creates clickable link)
        /// </summary>
        public void UrlLinkingExample()
        {
            // This method demonstrates the difference between cref and href for URLs
        }
        //</UrlLinkingExample>

        //<FormattingExample>
        /// <summary>
        /// Example using para tags:
        /// <para>This is the first paragraph.</para>
        /// <para>This is the second paragraph with double spacing.</para>
        /// 
        /// Example using br tags:
        /// First line of text<br/>
        /// Second line of text with single spacing<br/>
        /// Third line of text
        /// </summary>
        public void FormattingExample()
        {
            // This method demonstrates paragraph and line break formatting
        }
        //</FormattingExample>

        /// <summary>
        /// Comprehensive example showing different link types:
        /// <see cref="Console.WriteLine(string)">Console.WriteLine</see> (code reference with custom text)<br/>
        /// <see href="https://github.com/dotnet/docs">GitHub repository</see> (external link)<br/>
        /// <see langword="null"/> (language keyword)<br/>
        /// <see cref="string"/> (type reference)
        /// </summary>
        /// <remarks>
        /// This example shows:
        /// <list type="bullet">
        /// <item>Using cref for code elements</item>
        /// <item>Using href for external URLs</item>
        /// <item>Using langword for language keywords</item>
        /// <item>Using br for line breaks in summaries</item>
        /// </list>
        /// </remarks>
        public void ComprehensiveExample()
        {
            // This method demonstrates various linking and formatting options
        }
    }
}