using System;

namespace UnitTestingBestPractices
{
    public class StringCalculator
    {
        private const int MAXIMUM_RESULT = 1000;

        public int Add(string numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            int result;
            if (numbers.Contains(","))
            {
                result = HandleMultipleNumbers(numbers);
            }
            else
            {
                result = HandleSingleNumber(numbers);
            }

            return ValidateResult(result);
        }

        private static int HandleMultipleNumbers(string numbers)
        {
            var sum = 0;

            var numbersArray = numbers.Split(',');
            foreach (var number in numbersArray)
            {
                sum += HandleSingleNumber(number);
            }

            return ValidateResult(sum);
        }

        private static int HandleSingleNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            var result = int.TryParse(number, out var parsedNumber);
            if (result == false)
            {
                throw new ArgumentException($"Unable to parse {nameof(number)} as an Int32.", nameof(number));
            }

            return parsedNumber;
        }

        private static int ValidateResult(int sum)
        {
            if (sum > MAXIMUM_RESULT)
            {
                throw new OverflowException();
            }

            return sum;
        }
    }
}
