using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Windows;

namespace ObjectDataProviderSample
{
    class InvalidCharacterRule : ValidationRule
    {
        public InvalidCharacterRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
          double myvalue = 0.00;

          try
          {
            if (((string)value).Length > 0)
                myvalue = Double.Parse((String)value);
          }
          catch (Exception e)
          {
            return new ValidationResult(false, "Illegal characters or " +e.Message);
          }

          return new ValidationResult(true, null);
        }

    }
}
