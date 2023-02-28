using Xunit;
using static LinqSamples.Test.Shared;

namespace LinqSamples.Test
{
    public class OrderResultsOfJoinTest
    {
        [Fact]
        public void OrderResultsOfJoinTest1()
        {
            var sw = InitTest();

            OrderResultsOfJoin.OrderResultsOfJoin1();
            Assert.Equal(
@"Beverages
  Cola       1
  Tea        1
Condiments
  Mustard    2
  Pickles    2
Fruit
  Melons     5
  Peaches    5
Grains
Vegetables
  Bok Choy   3
  Carrots    3
", sw.ToString());
        }
    }
}
