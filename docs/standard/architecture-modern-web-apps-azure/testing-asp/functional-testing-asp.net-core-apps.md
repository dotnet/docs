---
title: Functional Testing ASP.NET Core Apps | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Functional Testing ASP.NET Core Apps
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Functional Testing ASP.NET Core Apps

For ASP&period;NET Core applications, the TestServer class makes functional tests fairly easy to write. You configure a TestServer using a WebHostBuilder, just as you normally do for your application. This WebHostBuilder should be configured just like your application's real host, but you can modify any aspects of it that make testing easier. Most of the time, you'll reuse the same TestServer for many test cases, so you can encapsulate it in a reusable method (perhaps in a base class):

```cs
public abstract class BaseWebTest
{
    protected readonly HttpClient _client;
    protected string _contentRoot;

    public BaseWebTest()
    {
        _client = GetClient();
    }
    
    protected HttpClient GetClient()
    {
        var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;
        _contentRoot = GetProjectPath("src", startupAssembly);
        var builder = new WebHostBuilder()
        .UseContentRoot(_contentRoot)
        .UseStartup&lt;Startup&gt;();
        var server = new TestServer(builder);
        var client = server.CreateClient();
        return client;
    }
}
```

The GetProjectPath method simply returns the physical path to the web project (download sample solution). The WebHostBuilder in this case simply specifies where the content root for the web application is, and references the same Startup class the real web application uses. To work with the TestServer, you use the standard System.Net.HttpClient type to make requests to it. TestServer exposes a helpful CreateClient method that provides a pre-configured client that is ready to make requests to the application running on the TestServer. You use this client (set to the protected \_client member on the base test above) when writing functional tests for your ASP&period;NET Core application:

```cs
public class CatalogControllerGetImage : BaseWebTest
{
    [Fact]
    public async Task ReturnsFileContentResultGivenValidId()
    {
        var testFilePath = Path.Combine(_contentRoot, "pics//1.png");
        var expectedFileBytes = File.ReadAllBytes(testFilePath);
        var response = await _client.GetAsync("/catalog/pic/1");
        response.EnsureSuccessStatusCode();
        var streamResponse = await response.Content.ReadAsStreamAsync();
        byte[] byteResult;
        using (var ms = new MemoryStream())
        {
            streamResponse.CopyTo(ms);
            byteResult = ms.ToArray();
        }
        Assert.Equal(expectedFileBytes, byteResult);
    }
}
```

This functional test exercises the full ASP&period;NET Core MVC application stack, including all middleware, filters, binders, etc. that may be in place. It verifies that a given route ("/catalog/pic/1") returns the expected byte array for a file in a known location. It does so without setting up a real web server, and so avoids much of the brittleness that using a real web server for testing can experience (for example, problems with firewall settings). Functional tests that run against TestServer are usually slower than integration and unit tests, but are much faster than tests that would run over the network to a test web server.

>[!div class="step-by-step"]
[Previous] (integration-testing-asp.net-core-apps.md)
[Next] (../development-process-for-azure/index.md)
