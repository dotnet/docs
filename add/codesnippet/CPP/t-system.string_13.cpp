public:
   virtual String^ ToString(String^ format, IFormatProvider^ provider) 
   {
      if (String::IsNullOrEmpty(format)) format = "G";  
      if (provider == nullptr) provider = CultureInfo::CurrentCulture;
      
      switch (Convert::ToUInt16(format->ToUpperInvariant()))
      {
         // Return degrees in Celsius.    
         case 'G':
         case 'C':
            return temp.ToString("F2", provider) + L"�C";
         // Return degrees in Fahrenheit.
         case 'F': 
            return (temp * 9 / 5 + 32).ToString("F2", provider) + L"�F";
         // Return degrees in Kelvin.
         case 'K':   
            return (temp + 273.15).ToString();
         default:
            throw gcnew FormatException(
                  String::Format("The {0} format string is not supported.", 
                                 format));
      }                                   
   }