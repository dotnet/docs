// </SnippetAddUsing>
using Microsoft.ML.Data;
// </SnippetAddUsing>

namespace ProductSalesAnomalyDetection
{
    // <SnippetDeclareTypes>
    public class ProductSalesData
    {
        [LoadColumn(0)]
        public string? Month;

        [LoadColumn(1)]
        public float numSales;
    }

    public class ProductSalesPrediction
    {
        //vector to hold alert,score,p-value values
        [VectorType(3)]
        public double[]? Prediction { get; set; }
    }
    // </SnippetDeclareTypes>
}
