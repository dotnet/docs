using System;
using System.Windows.Controls;

namespace ExpenseIt.Validation
{
    // Number Validation Rule
    public class NumberValidationRule : ValidationRule
    {
        bool _isFixedLength;
        int _length;

        /// <summary>
        /// Must the number be a specific length
        /// </summary>
        public bool IsFixedLength
        {
            get { return _isFixedLength; }
            set { _isFixedLength = value; }
        }

        /// <summary>
        /// The specific length of the number, if IsFixedLength is true
        /// </summary>
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            int number;

            // Is a number?
            if (!int.TryParse((string)value, out number))
            {
                return new ValidationResult(false, "Not a number.");
            }

            // Is as long as specified by _length?
            if (_isFixedLength && ((string)value).Length != _length)
            {
                string msg = string.Format("Number must be {0} digits long.", _length);
                return new ValidationResult(false, msg);
            }

            // Number is valid
            return new ValidationResult(true, null);
        }
    }
}
