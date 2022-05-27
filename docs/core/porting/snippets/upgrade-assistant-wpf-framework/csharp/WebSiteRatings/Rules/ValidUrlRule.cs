using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WebSiteRatings.Rules
{
    public class ValidUrlRule : ValidationRule
    {
        public ValidUrlRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string testValue;

            if (value is Uri uri)
                testValue = uri.ToString();
            else if (value is string str)
                testValue = str;
            else
                return new ValidationResult(false, "URL must begin with https:// or http://");

            if (testValue.StartsWith("https://", StringComparison.OrdinalIgnoreCase) || testValue.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                return ValidationResult.ValidResult;
            else
                return new ValidationResult(false, "URL must begin with https:// or http://");
        }
    }
}
