namespace AttributeSample
{
    using System;

    public class HelpAttribute: Attribute
    {
        string url;
        string topic;
        public HelpAttribute(string url) 
        {
            this.url = url;
        }

        public string Url => url;

        public string Topic {
            get { return topic; }
            set { topic = value; }
        }
    }
    
    [Help("https://docs.microsoft.com/dotnet/articles/csharp/tour-of-csharp/attributes")]
    public class Widget
    {
        [Help("https://docs.microsoft.com/dotnet/articles/csharp/tour-of-csharp/attributes", 
        Topic = "Display")]
        public void Display(string text) {}
    }

    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
