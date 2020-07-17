using System;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
    public partial class Attributes : Page
    {
        private void PageLoaded(object o, EventArgs e)
        {
            Snippet2();
            Snippet3();
            Snippet7();
        }

        public void Snippet2()
        {
            // <!-- <SnippetAttributesSnippet2> -->
            // Retreive the localization attributes from the button.
            string attributes = Localization.GetAttributes(buttonLocalized);
            // <!-- </SnippetAttributesSnippet2> -->
        }

        public void Snippet3()
        {
            // <!-- <SnippetAttributesSnippet3> -->
            // Set the localization attributes for the button.
            string attributes = "$Content(Text Readable Modifiable) FontFamily(Font Readable Unmodifiable)";
            Localization.SetAttributes(buttonLocalized, attributes);
            // <!-- </SnippetAttributesSnippet3> -->

            string attributesSet = Localization.GetAttributes(buttonLocalized);
        }

        public void Snippet7()
        {
            // <!-- <SnippetAttributesSnippet7> -->
            // Get the value of the Localization.AttributesProperty dependency property.
            string attributes = (string)buttonLocalized.GetValue(Localization.AttributesProperty);

            // Set the value of the Localization.AttributesProperty dependency property.
            string newAttributes = "$Content(Button Unreadable Unmodifiable) FontFamily(Font Unreadable Unmodifiable)";
            buttonLocalized.SetValue(Localization.AttributesProperty, newAttributes);
            // <!-- </SnippetAttributesSnippet7> -->

            string attributesSet = Localization.GetAttributes(buttonLocalized);
        }
    }
}