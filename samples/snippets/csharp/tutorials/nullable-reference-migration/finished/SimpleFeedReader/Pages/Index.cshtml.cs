using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleFeedReader.Services;
using SimpleFeedReader.ViewModels;

namespace SimpleFeedReader.Pages
{
#nullable enable
    public class IndexModel : PageModel
    {
        private readonly NewsService _newsService;

        public IndexModel(NewsService newsService)
        {
            _newsService = newsService;
        }

        // <SnippetUpdateErrorText>
        public string? ErrorText { get; private set; }
        // </SnippetUpdateErrorText>

        // <SnippetInitializeNewsItems>
        public List<NewsStoryViewModel> NewsItems { get; } = new List<NewsStoryViewModel>();
        // </SnippetInitializeNewsItems>

        public async Task OnGet()
        {
            string feedUrl = Request.Query["feedurl"];

            if (!string.IsNullOrEmpty(feedUrl))
            {
                try
                {
                    // <SnippetAddRange>
                    NewsItems.AddRange(await _newsService.GetNews(feedUrl));
                    // </SnippetAddRange>
                }
                catch (UriFormatException)
                {
                    ErrorText = "There was a problem parsing the URL.";
                    return;
                }
                catch (WebException ex) when (ex.Status == WebExceptionStatus.NameResolutionFailure)
                {
                    ErrorText = "Unknown host name.";
                    return;
                }
                catch (WebException ex) when (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    ErrorText = "Syndication feed not found.";
                    return;
                }
                catch (AggregateException ae)
                {
                    ae.Handle((x) =>
                    {
                        if (x is XmlException)
                        {
                            ErrorText = "There was a problem parsing the feed. Are you sure that URL is a syndication feed?";
                            return true;
                        }
                        return false;
                    });
                }
            }
        }
    }
#nullable restore
}
