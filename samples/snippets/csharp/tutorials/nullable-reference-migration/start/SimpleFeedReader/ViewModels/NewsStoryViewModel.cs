using System;

namespace SimpleFeedReader.ViewModels
{
    // <SnippetStarterViewModel>
    public class NewsStoryViewModel
    {
        public DateTimeOffset Published { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
    }
    // </SnippetStarterViewModel>
}
