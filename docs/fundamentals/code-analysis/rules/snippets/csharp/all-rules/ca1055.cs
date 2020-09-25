using System;

namespace ca1055
{
    //<snippet1>
    public class ErrorProne
    {
        // Violates rule UriPropertiesShouldNotBeStrings.
        public string SomeUri { get; set; }

        // Violates rule UriParametersShouldNotBeStrings.
        public void AddToHistory(string uriString) { }

        // Violates rule UriReturnValuesShouldNotBeStrings.
        public string GetReferrerUri(string httpHeader)
        {
            return "http://www.adventure-works.com";
        }
    }

    public class SaferWay
    {
        // To retrieve a string, call SomeUri.ToString().
        // To set using a string, call SomeUri = new Uri(string).
        public Uri SomeUri { get; set; }

        public void AddToHistory(string uriString)
        {
            // Check for UriFormatException.
            AddToHistory(new Uri(uriString));
        }

        public void AddToHistory(Uri uriType) { }

        public Uri GetReferrerUri(string httpHeader)
        {
            return new Uri("http://www.adventure-works.com");
        }
    }
    //</snippet1>
}
