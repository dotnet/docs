using Microsoft.Extensions.Logging;

namespace Logging.LibraryAuthors;

public class DiExampleService(ILogger<DiExampleService> logger)
{
    public void ProcessProductSale(Product product, int sold)
    {
        // Product sale processing logic.
        // Log results...

        logger.LogProductSaleDetails(
            quantity: sold,
            description: product.GetFriendlyProductDescription());
    }
}
