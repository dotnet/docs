using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

public class DiExampleService
{
    private readonly ILogger<DiExampleService> _logger;

    public DiExampleService(ILogger<DiExampleService> logger) =>
        _logger = logger;

    public void ProcessProductSale(Product product, int sold)
    {
        // Product sale processing logic.
        // Log results...

        _logger.LogProductSaleDetails(
            quantity: sold,
            description: product.GetFriendlyProductDescription());
    }
}
