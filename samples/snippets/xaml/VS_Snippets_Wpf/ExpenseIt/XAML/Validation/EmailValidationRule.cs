using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ExpenseIt.Validation
{
    // Email Validation Rule
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            // Is a valid email address?
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([,;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*";
            if( !Regex.IsMatch((string)value, pattern) )
            {
                return new ValidationResult(false, "Not a valid email address.");
            }

            // Number is valid
            return new ValidationResult(true, null);
        }
    }
}
