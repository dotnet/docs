using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using SimpleFeedReader.ViewModels;

namespace SimpleFeedReader.Services
{
#nullable enable
    public class NewsService
    {
        private readonly IMapper _mapper;

        // <SnippetServiceConstructor>
        public NewsService(IMapper mapper)
        {
            _mapper = mapper;
        }
        // </SnippetServiceConstructor>

        // <SnippetGetNewsFinished>
        public async Task<IEnumerable<NewsStoryViewModel>> GetNews(string feedUrl)
        {
            var news = new List<NewsStoryViewModel>();
            var feedUri = new Uri(feedUrl);

            using (var xmlReader = XmlReader.Create(feedUri.ToString(),
                   new XmlReaderSettings { Async = true }))
            {
                try
                {
                    var feedReader = new RssFeedReader(xmlReader);

                    while (await feedReader.Read())
                    {
                        switch (feedReader.ElementType)
                        {
                            // RSS Item
                            case SyndicationElementType.Item:
                                ISyndicationItem item = await feedReader.ReadItem();
                                var newsStory = _mapper.Map<NewsStoryViewModel>(item);
                                news.Add(newsStory);
                                break;

                            // Something else
                            default:
                                break;
                        }
                    }
                }
                catch (AggregateException ae)
                {
                    throw ae.Flatten();
                }
            }

            return news.OrderByDescending(story => story.Published);
        }
        // </SnippetGetNewsFinished>
    }
#nullable restore

    // <SnippetConfigureAutoMapper>
#nullable enable
    public class NewsStoryProfile : Profile
    {
        public NewsStoryProfile()
        {
            // Create the AutoMapper mapping profile between the 2 objects.
            // ISyndicationItem.Id maps to NewsStoryViewModel.Uri.
            CreateMap<ISyndicationItem, NewsStoryViewModel>()
                .ForCtorParam("uri", opt => opt.MapFrom(src => src.Id));
        }
        // </SnippetConfigureAutoMapper>
    }
#nullable restore
}
