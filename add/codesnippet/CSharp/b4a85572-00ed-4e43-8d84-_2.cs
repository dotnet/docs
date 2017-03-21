      if (arg is IFormattable) 
         return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
      else if (arg != null)
         return arg.ToString();