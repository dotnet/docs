using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Car.Tests
{
    public class WheelTests
    {
        [Fact]
        public async Task RepairTest()
        {
            var wheelName = "This is a test name";
            var repair = "Simple repair";
            var wheel = new Wheel(wheelName);

            await wheel.RepairAsync(repair);

            Assert.Contains(wheel.Repairs, item => string.Equals(item, repair));
        }

        [Fact]
        public void NameTest()
        {
            var wheelName = "This is a test name";
            var wheel = new Wheel(wheelName);

            Assert.Equal(wheel.Name, wheelName);
        }
    }
}
