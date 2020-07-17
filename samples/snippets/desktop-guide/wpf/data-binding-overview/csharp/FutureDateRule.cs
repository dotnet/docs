using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace bindings
{
    // <FutureDateRule>
    public class FutureDateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Test if date is valid
            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {
                // Date is not in the future, fail
                if (DateTime.Now > date)
                    return new ValidationResult(false, "Please enter a date in the future.");
            }
            else
            {
                // Date is not a valid date, fail
                return new ValidationResult(false, "Value is not a valid date.");
            }

            // Date is valid and in the future, pass
            return ValidationResult.ValidResult;
        }
    }
    // </FutureDateRule>
}
