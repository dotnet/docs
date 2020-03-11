using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using SimpleFeedReader.Services;
using SimpleFeedReader.ViewModels;
using Xunit;

namespace SimpleFeedReader.Tests.Services
{
#nullable enable
    public class NewsServiceTests
    {
        private readonly NewsService _newsService;

        public NewsServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile<NewsStoryProfile>());
            mockMapper.AssertConfigurationIsValid();
            IMapper mapper = mockMapper.CreateMapper();

            _newsService = new NewsService(mapper);
        }

        [Fact]
        public async Task Returns_News_Stories_Given_Valid_Uri()
        {
            // Arrange
            var feedUrl = "https://azure.microsoft.com/en-us/blog/feed/";

            // <SnippetFixTestSignature>
            // Act
            IEnumerable<NewsStoryViewModel> result =
                await _newsService.GetNews(feedUrl);

            // Assert
            Assert.True(result.Any());
            // </SnippetFixTestSignature>
        }

        [Fact]
        public void Throws_UriFormatException_Given_Malformed_Uri()
        {
            // Arrange
            var feedUrl = "invalid_url";

            // Act & Assert
            Assert.ThrowsAsync<UriFormatException>(async () =>
                await _newsService.GetNews(feedUrl));
        }

        [Fact]
        public void Throws_WebException_Given_Unknown_Host_Uri()
        {
            // Arrange
            var feedUrl = "https://fail/test.rss";

            // Act & Assert
            Assert.ThrowsAsync<WebException>(async () =>
                await _newsService.GetNews(feedUrl));
        }
    }
}
