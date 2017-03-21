      String^ initialString = L"Initial string for stringbuilder.";
      int startIndex = 0;
      int substringLength = 14;
      int capacity = 255;
      StringBuilder^ stringBuilder = gcnew StringBuilder(
         initialString,startIndex,substringLength,capacity );