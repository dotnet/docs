//<SnippetMarginValidationRuleCODE>
using System.Globalization;
using System.Windows.Controls;

namespace SDKSample
{
    public class MarginValidationRule : ValidationRule
    {
        double minMargin;
        double maxMargin;

        public double MinMargin
        {
            get { return this.minMargin; }
            set { this.minMargin = value; }
        }

        public double MaxMargin
        {
            get { return this.maxMargin; }
            set { this.maxMargin = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double margin;

            // Is a number?
            if (!double.TryParse((string)value, out margin))
            {
                return new ValidationResult(false, "Not a number.");
            }

            // Is in range?
            if ((margin < this.minMargin) || (margin > this.maxMargin))
            {
                string msg = string.Format("Margin must be between {0} and {1}.", this.minMargin, this.maxMargin);
                return new ValidationResult(false, msg);
            }

            // Number is valid
            return new ValidationResult(true, null);
        }
    }
}
//</SnippetMarginValidationRuleCODE>