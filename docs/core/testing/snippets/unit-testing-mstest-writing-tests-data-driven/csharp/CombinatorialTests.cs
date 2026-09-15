using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Combinatorial;

namespace CombinatorialExample;

[TestClass]
public sealed class CombinatorialTests
{
    // <CombinatorialExample>
    [TestMethod]
    [CombinatorialData]
    public void Calculate_UsesEveryCombination(
        bool enabled,
        [CombinatorialValues(1, 3)] int factor,
        [CombinatorialRange(2, 6, 2)] int value,
        [CombinatorialRandomData(Count = 2, Minimum = 10, Maximum = 20, Seed = 42)] int offset)
    {
        int result = enabled ? (factor * value) + offset : value + offset;

        Assert.IsTrue(result >= 12);
    }
    // </CombinatorialExample>
}
