using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WebSiteRatings.Rules
{
    public class EmptyTextRule : ValidationRule
    {
        public EmptyTextRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str && !string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str))
                return ValidationResult.ValidResult;

            return new ValidationResult(false, "Text cannot be empty");

        }
    }
}
