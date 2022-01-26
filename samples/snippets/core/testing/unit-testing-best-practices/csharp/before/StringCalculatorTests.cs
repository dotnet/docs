using System;
using UnitTestingBestPractices;
using Xunit;

namespace UnitTestingBestPracticesBefore
{
    public class StringCalculatorTests
    {
        // <SnippetBeforeSetup>
        private readonly StringCalculator stringCalculator;
        public StringCalculatorTests()
        {
            stringCalculator = new StringCalculator();
        }
        // </SnippetBeforeSetup>

        // <SnippetBeforeNaming>
        [Fact]
        public void Test_Single()
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add("0");

            Assert.Equal(0, actual);
        }
        // </SnippetBeforeNaming>

        // <SnippetBeforeArranging>
        [Fact]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var stringCalculator = new StringCalculator();

            // Assert
            Assert.Equal(0, stringCalculator.Add(""));
        }
        // </SnippetBeforeArranging>

        // <SnippetBeforeMinimallyPassing>
        [Fact]
        public void Add_SingleNumber_ReturnsSameNumber()
        {
            var stringCalculator = new StringCalculator();

            var actual = stringCalculator.Add("42");

            Assert.Equal(42, actual);
        }
        // </SnippetBeforeMinimallyPassing>

        // <SnippetBeforeHelperMethod>
        [Fact]
        public void Add_TwoNumbers_ReturnsSumOfNumbers()
        {
            var result = stringCalculator.Add("0,1");

            Assert.Equal(1, result);
        }
        // </SnippetBeforeHelperMethod>

        [Fact]
        public void Add_ThreeNumbers_ReturnsSumOfNumbers()
        {
            var result = stringCalculator.Add("0,1,2");

            Assert.Equal(3, result);
        }

        // <SnippetLogicInTests>
        [Fact]
        public void Add_MultipleNumbers_ReturnsCorrectResults()
        {
            var stringCalculator = new StringCalculator();
            var expected = 0;
            var testCases = new[]
            {
                "0,0,0",
                "0,1,2",
                "1,2,3"
            };

            foreach (var test in testCases)
            {
                Assert.Equal(expected, stringCalculator.Add(test));
                expected += 3;
            }
        }
        // </SnippetLogicInTests>

        // <SnippetBeforeMagicString>
        [Fact]
        public void Add_BigNumber_ThrowsException()
        {
            var stringCalculator = new StringCalculator();

            Action actual = () => stringCalculator.Add("1001");

            Assert.Throws<OverflowException>(actual);
        }
        // </SnippetBeforeMagicString>

        // <SnippetBeforeMultipleAsserts>
        [Fact]
        public void Add_EmptyEntries_ShouldBeTreatedAsZero()
        {
            // Act
            var actual1 = stringCalculator.Add("");
            var actual2 = stringCalculator.Add(",");

            // Assert
            Assert.Equal(0, actual1);
            Assert.Equal(0, actual2);
        }
        // </SnippetBeforeMultipleAsserts>
    }
}
