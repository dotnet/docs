      // Create Long and Validator.
      Int64 testLong =    17592186044416;
      Int64 minLongVal =  1099511627776;
      Int64 maxLongVal =  281474976710656;
      LongValidator myLongValidator = 
       new LongValidator(minLongVal, maxLongVal, false);