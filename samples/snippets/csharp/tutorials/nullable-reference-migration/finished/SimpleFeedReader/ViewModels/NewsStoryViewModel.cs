using System;

namespace SimpleFeedReader.ViewModels
{
    // <SnippetFinishedViewModel>
#nullable enable
    public class NewsStoryViewModel
    {
        public NewsStoryViewModel(DateTimeOffset published, string title, string uri) =>
            (Published, Title, Uri) = (published, title, uri);

        public DateTimeOffset Published { get; }
        public string Title { get; }
        public string Uri { get; }
    }
#nullable restore
    // </SnippetFinishedViewModel>
}
