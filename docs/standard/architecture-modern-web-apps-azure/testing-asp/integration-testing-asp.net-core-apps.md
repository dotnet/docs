---
title: Integration Testing ASP.NET Core Apps | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Integration Testing ASP.NET Core Apps
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Integration Testing ASP&period;NET Core Apps

```cs
    }
        catch (FileNotFoundException ex)
        {
            throw new CatalogImageMissingException(ex);
        }
    }
}
```

This service uses the IHostingEnvironment, just as the CatalogController code did before it was refactored into a separate service. Since this was the only code in the controller that used IHostingEnvironment, that dependency was removed from CatalogController's constructor.

To test that this service works correctly, you need to create a known test image file and verify that the service returns it given a specific input. You should take care not to use mock objects on the behavior you actually want to test (in this case, reading from the file system). However, mock objects may still be useful to set up integration tests. In this case, you can mock IHostingEnvironment so that its ContentRootPath points to the folder you're going to use for your test image. The complete working integration test class is shown here:

```cs
public class LocalFileImageServiceGetImageBytesById
{
    private byte[] _testBytes = new byte[] { 0x01, 0x02, 0x03 };
    private readonly Mock<IHostingEnvironment> _mockEnvironment = new Mock<IHostingEnvironment>();
    private int _testImageId = 123;
    private string _testFileName = "123.png";
    public LocalFileImageServiceGetImageBytesById()
    {
        // create folder if necessary
        Directory.CreateDirectory(Path.Combine(GetFileDirectory(), "Pics"));
        string filePath = GetFilePath(_testFileName);
        System.IO.File.WriteAllBytes(filePath, _testBytes);
        _mockEnvironment.SetupGet<string>(m => m.ContentRootPath).Returns(GetFileDirectory());
    }
    private string GetFilePath(string fileName)
    {
        return Path.Combine(GetFileDirectory(), "Pics", fileName);
        }
            private string GetFileDirectory()
        {
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            return Path.GetDirectoryName(location);
        }

        [Fact]
        public void ReturnsFileContentResultGivenValidId()
        {
            var fileService = new LocalFileImageService(_mockEnvironment.Object);
            var result = fileService.GetImageBytesById(_testImageId);
            Assert.Equal(_testBytes, result);
        }
    }
```

> [!NOTE]
> that the test itself is very simple – the bulk of the code is necessary to configure the system and create the testing infrastructure (in this case, an actual file to be read from disk). This is typical for integration tests, which often require more complex setup work than unit tests.


>[!div class="step-by-step"]
[Previous] (unit-testing-asp.net-core-apps.md)
[Next] (functional-testing-asp.net-core-apps.md)
