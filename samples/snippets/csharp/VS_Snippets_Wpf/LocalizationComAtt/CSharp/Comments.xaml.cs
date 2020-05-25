using System;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
    public partial class Comments : Page
    {
        private void PageLoaded(object o, EventArgs e)
        {
            Snippet5();
            Snippet6();
            Snippet8();
        }

        public void Snippet5()
        {
            // <!-- <SnippetAttributesSnippet5> -->
            // Retreive the localization comments from the text block.
            string comments = Localization.GetComments(textBlockLocalized);
            // <!-- </SnippetAttributesSnippet5> -->
        }

        public void Snippet6()
        {
            // <!-- <SnippetAttributesSnippet6> -->
            // Set the localization comments for the text block.
            string comments = "$Content(Copyright info) FontSize(Logo point size)";
            Localization.SetComments(textBlockLocalized, comments);
            // <!-- </SnippetAttributesSnippet6> -->

            string commentsSet = Localization.GetComments(textBlockLocalized);
        }

        public void Snippet8()
        {
            // <!-- <SnippetAttributesSnippet8> -->
            // Get the value of the Localization.CommentsProperty dependency property.
            string comments = (string)textBlockLocalized.GetValue(Localization.CommentsProperty);

            // Set the value of the Localization.CommentsProperty dependency property.
            string newComments = "$Content(Trademark) FontSize(Trademark font size)";
            textBlockLocalized.SetValue(Localization.CommentsProperty, newComments);
            // <!-- </SnippetAttributesSnippet8> -->

            string commentsSet = Localization.GetComments(textBlockLocalized);
        }
    }
}