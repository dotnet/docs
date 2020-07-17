using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SDKSample
{
    public partial class TypographyCodeSnippets : Page
    {
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            Stub01();
        }

        public void Stub01()
        {
            // <SnippetTypographyCodeSnippet1>
            MyParagraph.FontFamily = new FontFamily("Pescadero");
            MyParagraph.FontSize = 48;

            Run run_1 = new Run("CAPITALS ");
            MyParagraph.Inlines.Add(run_1);

            Run run_2 = new Run("Capitals ");
            run_2.Typography.Capitals = FontCapitals.SmallCaps;
            MyParagraph.Inlines.Add(run_2);

            Run run_3 = new Run("Capitals");
            run_3.Typography.Capitals = FontCapitals.AllSmallCaps;
            MyParagraph.Inlines.Add(run_3);

            MyParagraph.Inlines.Add(new LineBreak());
            // </SnippetTypographyCodeSnippet1>
        }
    }
}