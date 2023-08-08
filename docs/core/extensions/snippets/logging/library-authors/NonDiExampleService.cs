using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

public class NonDiExampleService
{
    private readonly ILogger<NonDiExampleService> _logger;

    public NonDiExampleService()
    {
        _logger = LibraryConfiguration.LoggerFactory.CreateLogger<NonDiExampleService>();
    }

    public void ProcessProductSale(Product product, int sold)
    {
        // Product sale processing logic.
        // Log results...

        _logger.LogProductSaleDetails(
            quantity: sold,
            description: product.GetFriendlyProductDescription());
    }
}
